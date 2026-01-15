using System;

namespace QuizBattle.Application.Features.FinishSession;

public record FinishQuizResult(
    Guid SessionId,
    int CorrectAnswers,
    int TotalQuestions,
    double Score);