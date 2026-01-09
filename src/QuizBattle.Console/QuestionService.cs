
using System;
using System.Collections.Generic;
using System.Linq;
using QuizBattle.Domain;

namespace QuizBattle.Console
{
    public class QuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _repository = questionRepository;
            EnsureValid();
        }

        public Question GetRandomQuestion()
        {
            var questions = _repository.GetAll();
            return questions[new Random().Next(questions.Count)];
        }

        public List<Question> GetRandomQuestions(int count = 3)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");
            }

            var questions = _repository.GetAll();

            if (count >= questions.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be less than the total number of questions.");
            }

            return questions
                .OrderBy(_ => Random.Shared.Next()) // pseudo-slumpordning
                .Take(count)
                .ToList();
        }

        private void EnsureValid()
        {
            if (_repository is null)
            {
                throw new DomainException("questionRepository must not be null.");
            }
        }
    }
}
