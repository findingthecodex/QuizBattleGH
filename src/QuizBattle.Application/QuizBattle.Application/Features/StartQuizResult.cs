namespace QuizBattle.Application.Features.StartSession;

public sealed record StartQuizCommand(int questionCount, string? category, int? difficulty);
public class StartQuizResult
{
    
}

public sealed class StartQuizHandler
{
    public Task<StartQuizResult> Handle(StartQuizCommand command, CancellationToken ct)
    {
        return Task.FromResult(new StartQuizResult());
    }
}