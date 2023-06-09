using SecurityQuestionsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace SecurityQuestionsApp.Persistence
{
    public class SecurityQuestionsAppRepository : ISecurityQuestionsAppRepository
    {
        private readonly SecurityQuestionsAppContext _context;

        public SecurityQuestionsAppRepository(SecurityQuestionsAppContext context) => _context = context;

        public async Task<Person?> GetPersonByNameAsync(string name)
        {
            var result = await _context.People
                .Include(p => p.SecurityAnswers)
                .ThenInclude(p => p.SecurityQuestion)
                .SingleOrDefaultAsync(p => p.Name == name);

            return result;
        }

        public async Task<List<SecurityQuestion>> GetQuestionsAsync() => await _context.SecurityQuestions.ToListAsync();

        public async Task InsertOrUpdatePersonAsync(Person person)
        {
            if (person.Id > 0)
            {
                _context.People.Update(person);
            }
            else
            {
                await _context.People.AddAsync(person);
            }

            await _context.SaveChangesAsync();
        }
    }
}