using SecurityQuestionsApp.Models;

namespace SecurityQuestionsApp.Persistence
{
    public interface ISecurityQuestionsAppRepository
    {
        Task<Person> GetPersonByNameAsync(string name);
        Task<List<SecurityQuestion>> GetQuestionsAsync();
        Task InsertOrUpdatePersonAsync(Person person);
    }
}