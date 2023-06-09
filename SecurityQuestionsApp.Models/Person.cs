using System.ComponentModel.DataAnnotations;

namespace SecurityQuestionsApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SecurityAnswer> SecurityAnswers { get; set; } = new();
    }
}