using System;

namespace QuizBattle.Application.Features.AnswerQuestion;

public class AnswerQuestionCommand
{
    public Guid SessionId { get; set; }
    public string QuestionCode { get; set; } = string.Empty;
    public string ChoiceCode { get; set; } = string.Empty;
}