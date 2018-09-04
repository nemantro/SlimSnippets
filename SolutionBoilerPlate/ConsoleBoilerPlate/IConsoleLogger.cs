internal interface IConsoleLogger
{    
    void LogDebug(string message);
    void LogInformation(string message);
    void LogError(string message);
}