// Använder nu 'StartQuizResult.QuestionInfo' för att anpassa sig till det uppdaterade IConsoleQuestionPresenter-gränssnittet.
using QuizBattle.Application.Features.StartSession;

namespace QuizBattle.Console.Presentation
{
    /// <summary>
    /// Ren Console-implementation som skriver/läser via System.Console.
    /// </summary>
    public sealed class ConsoleQuestionPresenter : IConsoleQuestionPresenter
    {
        public void DisplayQuestion(StartQuizResult.QuestionInfo question, int number)
        {
            System.Console.WriteLine($"Fråga {number}: {question.Text}");

            for (var i = 0; i < question.Choices.Count; i++)
            {
                var choice = question.Choices[i];
                System.Console.WriteLine($"  {i + 1}. {choice.Text}");
            }
        }

        public int PromptForAnswer(StartQuizResult.QuestionInfo question)
        {
            // Använder 'question.Choices.Count' direkt istället för en GetChoiceCount()-metod.
            System.Console.Write($"Ditt svar (1–{question.Choices.Count}): ");

            int pick;
            while (!int.TryParse(System.Console.ReadLine(), out pick) ||
                   pick < 1 ||
                   pick > question.Choices.Count)
            {
                System.Console.Write("Ogiltigt val. Försök igen: ");
            }

            return pick;
        }
    }
}
