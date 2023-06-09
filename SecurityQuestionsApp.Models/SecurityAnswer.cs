using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityQuestionsApp.Models
{
    public class SecurityAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public Person Person { get; set; }

        [NotMapped]
        public bool IsAsked { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }

    }
}
