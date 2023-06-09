using Microsoft.Extensions.DependencyInjection;
using SecurityQuestionsApp.Interfaces;
using SecurityQuestionsApp.Persistence;

namespace SecurityQuestionsApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var serviceProvider = ConfigureServices();

            var securityQuestionApp = serviceProvider.GetService<ISecurityQuestionsApp>();
            await securityQuestionApp.RunAsync();
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddScoped<IInputReader, ConsoleInputReader>()
                .AddScoped<IOutputWriter, ConsoleOutputWriter>()
                .AddScoped<ISecurityQuestionsApp, SecurityQuestionApp>()
                .AddScoped<ISecurityQuestionsAppRepository, SecurityQuestionsAppRepository>()
                .AddDbContext<SecurityQuestionsAppContext>()
                .BuildServiceProvider();
        }
    }
}