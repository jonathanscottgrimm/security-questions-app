using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace SecurityQuestionsApp.Models
{
    public class SecurityQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        [NotMapped]
        public bool IsAsked { get; set; }
        public List<SecurityAnswer> SecurityAnswers { get; } = new();
        public List<Person> People { get; } = new();
    }
}
