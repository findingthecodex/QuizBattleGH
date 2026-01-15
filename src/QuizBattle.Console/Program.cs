using Microsoft.Extensions.DependencyInjection;
using QuizBattle.Application.Extensions;
using QuizBattle.Application.Interfaces;
using QuizBattle.Application.Services;
using QuizBattle.Console.Extensions;
using QuizBattle.Console.Presentation;
using QuizBattle.Infrastructure.Extensions;

// Ändrat från 3 till 2 eftersom det bara finns 2 frågor i "CS"-kategorin.
const int numberOfQuestions = 2;

// konfigurera dependency injection (DI) in konsol
var services = new ServiceCollection();

services.AddInfrastructureRepositories()    // Definierad i QuizBattle.Infrastructure
        .AddApplicationServices()           // Definierad i QuizBattle.Application
        .AddConsolePresentation();          // Definierad i QuizBattle.Console

// bygg en service provider
var provider = services.BuildServiceProvider();

// skapa ett nytt scope för den här applikationen
using var scope = provider.CreateScope();

// hämtar QuestionService och SessionService med korrekt beroenden (repository)
var questionService = scope.ServiceProvider.GetRequiredService<IQuestionService>();
var sessionService = scope.ServiceProvider.GetRequiredService<ISessionService>();
var presenter = scope.ServiceProvider.GetRequiredService<IConsoleQuestionPresenter>();

Console.Title = "QuizBattle – Konsol (v.2 dag 1–2)";
Console.WriteLine("Välkommen till QuizBattle!");
Console.WriteLine($"Detta är en minimal code‑along‑loop för dag 1–2 ({numberOfQuestions} frågor).");
Console.WriteLine("Tryck valfri tangent för att starta...");

Console.ReadKey(intercept: true);
Console.WriteLine();

// Starta en session via Application.
// Lade till 'category: "CS"' för att säkerställa att vi hämtar från en känd kategori.
var start = await sessionService.StartAsync(questionCount: numberOfQuestions, category: "CS");

// UI-loop (Console-only)
var score = 0;
var asked = 0;

// 'start.Questions' innehåller nu en lista av 'StartQuizResult.QuestionInfo' istället för 'Question'.
foreach (var question in start.Questions)
{
    asked++;
    presenter.DisplayQuestion(question, asked);

    var pick = presenter.PromptForAnswer(question);
    // Egenskapen för svarskoden har bytt namn från 'Code' till 'ChoiceCode'.
    var selectedCode = question.Choices[pick - 1].ChoiceCode;

    // Registrera svar i applikationen (handlers via SessionService)
    // Egenskapen för frågekoden har bytt namn från 'Code' till 'QuestionCode'.
    var answerResult = await sessionService.AnswerAsync(start.SessionId, question.QuestionCode, selectedCode);

    System.Console.WriteLine(answerResult.IsCorrect ? "✔ Rätt!" : "✖ Fel.");
    if (answerResult.IsCorrect) score++;
    System.Console.WriteLine();
}

var finished = await sessionService.FinishAsync(start.SessionId);
// Egenskapen för totalt antal frågor har bytt namn från 'AnsweredCount' till 'TotalQuestions'.
System.Console.WriteLine($"Klart! Poäng: {finished.Score}/{finished.TotalQuestions}");
System.Console.WriteLine("Tryck valfri tangent för att avsluta...");
System.Console.ReadKey(intercept: true);
