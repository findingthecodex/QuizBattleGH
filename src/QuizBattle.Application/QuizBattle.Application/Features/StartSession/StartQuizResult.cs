using System;
using System.Collections.Generic;

namespace QuizBattle.Application.Features.StartSession;

public record StartQuizResult(
    Guid SessionId,
    IReadOnlyList<StartQuizResult.QuestionInfo> Questions)
{
    public record QuestionInfo(
        string QuestionCode, 
        string Text,
        IReadOnlyList<ChoiceInfo> Choices);

    public record ChoiceInfo(
        string ChoiceCode, 
        string Text);
}