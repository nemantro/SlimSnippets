using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleBoilerPlate
{
    class Program
    {
        private static IConsoleLogger _consoleLogger;
        private static IConfigurationRoot _configuration;

        static void Main(string[] args)
        {
            InitializeServices();

            _consoleLogger.LogDebug("Debug line 8-)");
            _consoleLogger.LogInformation("Information line :D");
            _consoleLogger.LogError("Error line :'( ");

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }        

        private static void InitializeServices()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();

            //Get Configuration
            var UseConsoleColors = _configuration.GetValue("UseConsoleColors", false);

            //Configure injection
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConsoleLogger>(
                provider => new ConsoleLogger(UseConsoleColors)
            );

            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Inject Services
            _consoleLogger = serviceProvider.GetService<IConsoleLogger>();
        }
    }
}
