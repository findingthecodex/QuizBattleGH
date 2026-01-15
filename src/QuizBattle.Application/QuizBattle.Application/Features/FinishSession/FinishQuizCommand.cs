using System;
using System.Collections.Generic;

namespace QuizBattle.Application.Features.FinishSession;

// Innehåller all data som behövs för att kunna rätta quizet utan att hämta från databas.
public class FinishQuizCommand
{
    public List<QuizQuestion> Questions { get; set; } = new();
    public List<UserAnswer> Answers { get; set; } = new();
}

// Representerar en fråga med dess korrekta svar.
public class QuizQuestion
{
    public string QuestionCode { get; set; } = string.Empty;
    public string CorrectChoiceCode { get; set; } = string.Empty;
}

// Representerar användarens svar på en fråga.
public class UserAnswer
{
    public string QuestionCode { get; set; } = string.Empty;
    public string ChoiceCode { get; set; } = string.Empty;
}