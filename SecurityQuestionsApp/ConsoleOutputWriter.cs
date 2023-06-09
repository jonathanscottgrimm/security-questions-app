using SecurityQuestionsApp.Interfaces;

namespace SecurityQuestionsApp
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}