using Microsoft.Extensions.DependencyInjection;
using QuizBattle.Application.Features.AnswerQuestion;
using QuizBattle.Application.Features.FinishSession;
using QuizBattle.Application.Features.StartSession;
using QuizBattle.Application.Interfaces;
using QuizBattle.Application.Services;

namespace QuizBattle.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registrera alla "use case"-handlers så att de kan injiceras i t.ex. SessionService.
            // Scoped livstid är lämplig för handlers som kan ha beroenden till andra scoped services (t.ex. databaskontext).
            services.AddScoped<StartQuizHandler>();
            services.AddScoped<AnswerQuestionHandler>();
            services.AddScoped<FinishQuizHandler>();

            services.AddSingleton<IQuestionService, QuestionService>();
            services.AddSingleton<ISessionService, SessionService>();

            return services;
        }
    }
}
