using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleBoilerPlate
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);

            var configuration = builder.Build();

            var UseConsoleColors = configuration.GetValue("UseConsoleColors", false);

            ConsoleLogger consoleLogger = new ConsoleLogger(UseConsoleColors);

            consoleLogger.LogDebug("Debug line 8-)");
            consoleLogger.LogInformation("Information line :D");
            consoleLogger.LogError("Error line :'( ");
            
            Console.WriteLine("Press enter to exit");            
            Console.ReadLine();
        }
    }
}
