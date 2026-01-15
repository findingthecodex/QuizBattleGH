// Använder nu 'StartQuizResult.QuestionInfo' från Application-lagret istället för 'Question' från Domain-lagret.
// Detta minskar kopplingen mellan UI och domänmodellen.
using QuizBattle.Application.Features.StartSession;

namespace QuizBattle.Console.Presentation
{
    /// <summary>
    /// Console-specifik presenter som ansvarar för att
    /// rendera frågor och läsa in användarens val.
    /// Lever endast i Console-klienten.
    /// </summary>
    public interface IConsoleQuestionPresenter
    {
        void DisplayQuestion(StartQuizResult.QuestionInfo question, int number);
        int PromptForAnswer(StartQuizResult.QuestionInfo question);
    }
}
