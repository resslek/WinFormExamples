namespace LogThreading.Interfaces;

public interface ILoggingHelper
{
    string CurrentSerialBeingTested { get; set; }

    void LogInfo(string message);
    void LogError(Exception ex);
    void LogError(string message);
    void LogError(string message, Exception ex);
    void LogDebug(string message);
}