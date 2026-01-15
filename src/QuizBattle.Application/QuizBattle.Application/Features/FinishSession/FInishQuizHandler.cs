using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizBattle.Application.Features.FinishSession;

public sealed class FinishQuizHandler
{
    // Inget repository behövs längre.
    public FinishQuizHandler()
    {
    }

    public Task<FinishQuizResult> Handle(FinishQuizCommand command, CancellationToken ct = default)
    {
        // Skapa en lookup för snabb åtkomst till de korrekta svaren.
        var correctAnswersLookup = command.Questions
            .ToDictionary(q => q.QuestionCode, q => q.CorrectChoiceCode);

        int correctAnswersCount = 0;
        foreach (var userAnswer in command.Answers)
        {
            // Kontrollera om frågan existerar och om användarens svar matchar det korrekta.
            if (correctAnswersLookup.TryGetValue(userAnswer.QuestionCode, out var correctChoiceCode) &&
                userAnswer.ChoiceCode == correctChoiceCode)
            {
                correctAnswersCount++;
            }
        }

        int totalQuestions = command.Questions.Count;
        double score = totalQuestions > 0 ? (double)correctAnswersCount / totalQuestions * 100 : 0;

        var result = new FinishQuizResult(
            Guid.NewGuid(), // Ett nytt ID genereras eftersom vi inte har en sparad session.
            correctAnswersCount,
            totalQuestions,
            score);

        return Task.FromResult(result);
    }
}