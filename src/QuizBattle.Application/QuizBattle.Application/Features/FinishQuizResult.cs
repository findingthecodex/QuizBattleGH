namespace QuizBattle.Application.Features.FinishSession;

public class FinishQuizResult
{
    
}

public sealed record FinishQuizCommand(Guid SessionId);
public sealed class FinishQuizHandler
{
    public Task<FinishQuizResult> Handle(FinishQuizCommand command, CancellationToken ct)
    {
        return Task.FromResult(new FinishQuizResult());
    }
}