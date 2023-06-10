using SecurityQuestionsApp.Interfaces;
using SecurityQuestionsApp.Models;
using SecurityQuestionsApp.Persistence;

namespace SecurityQuestionsApp
{
    public class SecurityQuestionApp : ISecurityQuestionsApp
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private readonly ISecurityQuestionsAppRepository _repo;

        public SecurityQuestionApp(IInputReader inputReader, IOutputWriter outputWriter, ISecurityQuestionsAppRepository repo)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;
            _repo = repo;
        }

        public async Task RunAsync()
        {
            await NameFlowAsync();
        }

        private async Task NameFlowAsync()
        {

            _outputWriter.WriteLine("Hi, what is your name?");
            var name = _inputReader.ReadLine();

            var person = await _repo.GetPersonByNameAsync(name);

            if (person == null)
            {
                person = new Person { Name = name };
                await StoreFlowAsync(person);
            }
            else
            {
                _outputWriter.WriteLine("Do you want to answer a security question? (Y/N)");
                var answerSecurityQuestion = _inputReader.ReadLine().ToLowerInvariant();
                if (answerSecurityQuestion.Equals("y") || answerSecurityQuestion.Equals("yes"))
                {
                    await AnswerFlowAsync(person);
                }
                else
                {
                    await StoreFlowAsync(person);
                }
            }
        }

        private async Task StoreFlowAsync(Person person)
        {
            _outputWriter.WriteLine("Would you like to store answers to security questions? (Y/N)");
            var storeAnswer = _inputReader.ReadLine().ToLowerInvariant();
            if (storeAnswer.Equals("n") || storeAnswer.Equals("no"))
            {
                await NameFlowAsync();
                return;
            }

            var newSecurityAnswers = new List<SecurityAnswer>();

            if (storeAnswer.Equals("yes") || storeAnswer.Equals("y"))
            {
                var questions = await _repo.GetQuestionsAsync();
                
                //randomize order of questions
                questions = questions.OrderBy(q => Guid.NewGuid()).ToList();

                int answeredQuestions = 0;
                foreach (var question in questions.Where(q => !q.IsAsked))
                {
                    if (answeredQuestions == 3)
                        break;


                    _outputWriter.WriteLine(question.Question);
                    var answer = _inputReader.ReadLine().ToLowerInvariant();

                    if (string.IsNullOrWhiteSpace(answer))
                    {
                        question.IsAsked = true;
                        continue;
                    }

                    newSecurityAnswers.Add(new SecurityAnswer
                    {
                        Answer = answer,
                        Person = person,
                        SecurityQuestion = question
                    });

                    answeredQuestions++;
                }

                if (person.SecurityAnswers.Any())
                    person.SecurityAnswers.Clear();

                if (answeredQuestions.Equals(3))
                {
                    person.SecurityAnswers.AddRange(newSecurityAnswers);
                    await _repo.InsertOrUpdatePersonAsync(person);
                }

                questions = ResetIsAsked(questions);
                
                await NameFlowAsync();
            }
        }

        private async Task AnswerFlowAsync(Person person)
        {
            //randomize question order
            var securityQuestionsAndAnswers = person.SecurityAnswers.OrderBy(s => Guid.NewGuid());

            foreach (var question in securityQuestionsAndAnswers.Where(s => !s.IsAsked))
            {
                _outputWriter.WriteLine(question.SecurityQuestion.Question);
                question.IsAsked = true;
                var answer = _inputReader.ReadLine();

                if (string.Equals(answer, question.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    _outputWriter.WriteLine($"Congratulations, {person.Name}! You have answered the security questions correctly.");
                    break;
                }
            }

            if (!securityQuestionsAndAnswers.Any())
                _outputWriter.WriteLine("You have run out of questions to answer.");

            person.SecurityAnswers = ResetIsAsked(person.SecurityAnswers);

            await NameFlowAsync();
        }

        private List<SecurityAnswer> ResetIsAsked(List<SecurityAnswer> securityAnswers)
        {
            foreach (var securityAnswer in securityAnswers.Where(sa => sa.IsAsked))
                securityAnswer.IsAsked = false;

            return securityAnswers;
        }

        private List<SecurityQuestion> ResetIsAsked(List<SecurityQuestion> securityQuestions)
        {
            foreach (var question in securityQuestions.Where(sa => sa.IsAsked))
                question.IsAsked = false;

            return securityQuestions;
        }
    }
}
