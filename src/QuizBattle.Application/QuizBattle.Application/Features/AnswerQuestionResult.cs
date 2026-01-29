namespace QuizBattle.Application.Features.AnswerQuestion;

public class AnswerQuestionResult
{
    
}

public sealed record AnswerQuestionCommand(Guid SessionId, string QuestionCode, string SelectedChoiceCode);
public sealed class AnswerQuestionHandler
{
    public Task<AnswerQuestionResult> Handle(AnswerQuestionCommand command, CancellationToken ct)
    {
        
        return Task.FromResult(new AnswerQuestionResult());
    }
}
