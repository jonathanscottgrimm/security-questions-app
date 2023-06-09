using SecurityQuestionsApp.Interfaces;

namespace SecurityQuestionsApp
{
    public class ConsoleInputReader : IInputReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
