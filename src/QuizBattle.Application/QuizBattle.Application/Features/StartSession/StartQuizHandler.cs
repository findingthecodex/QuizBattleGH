using QuizBattle.Application.Interfaces;
using QuizBattle.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizBattle.Application.Features.StartSession;

public sealed class StartQuizHandler
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ISessionRepository _sessionRepository;

    public StartQuizHandler(
        IQuestionRepository questionRepository,
        ISessionRepository sessionRepository)
    {
        _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
    }

    public async Task<StartQuizResult> Handle(
        StartQuizCommand command,
        CancellationToken ct = default)
    {
        if (command.QuestionCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(command.QuestionCount));

        // 1. Hämta frågor
        var questions = await _questionRepository.GetRandomAsync(
            command.Category,
            command.Difficulty,
            command.QuestionCount,
            ct);

        // 2. Skapa session (Domain sköter regler)
        var session = QuizSession.Create(command.QuestionCount);

        // 3. Spara session
        await _sessionRepository.SaveAsync(session, ct);

        // 4. Returnera resultat (UI-vänligt format)
        return new StartQuizResult(
            session.Id,
            questions.Select(q => new StartQuizResult.QuestionInfo(
                q.Code,
                q.Text,
                q.Choices.Select(c =>
                    new StartQuizResult.ChoiceInfo(c.Code, c.Text)
                ).ToList()
            )).ToList()
        );
    }
}