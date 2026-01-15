using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizBattle.Application.Features.AnswerQuestion;

public sealed class AnswerQuestionHandler
{
    private readonly IQuestionRepository _questionRepository;

    public AnswerQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
    }

    public async Task<AnswerQuestionResult> Handle(AnswerQuestionCommand command, CancellationToken ct = default)
    {
        var question = await _questionRepository.GetByCodeAsync(command.QuestionCode, ct);

        if (question is null)
        {
            throw new Exception($"Question with code {command.QuestionCode} not found.");
        }

        // Check if the submitted choice code matches the question's correct answer code.
        bool isCorrect = question.CorrectAnswerCode == command.ChoiceCode;

        // The correct choice code is directly on the question object.
        string correctChoiceCode = question.CorrectAnswerCode;

        return new AnswerQuestionResult(isCorrect, correctChoiceCode);
    }
}