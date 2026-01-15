namespace QuizBattle.Application.Features.AnswerQuestion;

public record AnswerQuestionResult(
    bool IsCorrect,
    string CorrectChoiceCode);