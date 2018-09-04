using System;

internal class ConsoleLogger : IConsoleLogger
{
    //Initialization
    private readonly bool _useConsoleColors;
    private readonly ConsoleColor _defaultConsoleColor;

    public ConsoleLogger(bool useConsoleColors)
    {
        _useConsoleColors = useConsoleColors;
        _defaultConsoleColor = Console.ForegroundColor;
    }

    //Interface implementation
    public void LogDebug(string message)
    {
        LogMessage(message, LogLevel.Debug);
    }

    public void LogInformation(string message)
    {
        LogMessage(message, LogLevel.Information);
    }

    public void LogError(string message)
    {
        LogMessage(message, LogLevel.Error);
    }    

    //Private methods
    private void LogMessage(string message, LogLevel LogLevel)
    {
        ChangeConsoleFontColor(LogLevel);
        Console.WriteLine($"[{LogLevel}] : {message}");
        RestoreConsoleFontColor();
    }

    private void ChangeConsoleFontColor(LogLevel logLevel)
    {
        if (!_useConsoleColors)
            return;

        var consoleColor = _defaultConsoleColor;
        switch (logLevel)
        {
            case LogLevel.Debug:
                consoleColor = ConsoleColor.Green;
                break;
            case LogLevel.Information:
                consoleColor = ConsoleColor.White;
                break;
            case LogLevel.Error:
                consoleColor = ConsoleColor.Red;
                break;
        }

        Console.ForegroundColor = consoleColor;
    }

    private void RestoreConsoleFontColor()
    {
        Console.ForegroundColor = _defaultConsoleColor;
    }    
}