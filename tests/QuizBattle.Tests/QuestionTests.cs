using QuizBattle.Domain;

namespace QuizBattle.Tests;

public class QuestionTests
{
    [Fact]
    public void QuestionText_IsNull_ThrowsDomainException()
    {
        try
        {
            var question = new Question(null!, null!, null!);
            Assert.Fail("Expected to throw DomainException with null parameters.");
        }
        catch(DomainException ex)
        {
            Console.WriteLine("Correct exception: ", ex.Message);
        }
    }
}
