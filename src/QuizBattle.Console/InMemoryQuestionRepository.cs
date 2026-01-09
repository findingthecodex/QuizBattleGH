using QuizBattle.Domain;

namespace QuizBattle.Console
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        public List<Question> GetAll() => QuestionUtils.SeedQuestions();
    }
}
