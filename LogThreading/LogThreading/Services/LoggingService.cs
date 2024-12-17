using LogThreading.Interfaces;

namespace LogThreading.Services;

/// <summary>
/// The LoggingService class is responsible for logging information at regular intervals.
/// </summary>
public class LoggingService(ILoggingFactory loggingFactory, string name)
{
    /// <summary>
    /// Starts logging information every second for one minute.
    /// </summary>
    /// <returns>A task that represents the asynchronous logging operation.</returns>
    public async Task StartLoggingAsync()
    {
        var loggingHelper = loggingFactory.Create(name);

        for (var i = 0; i < 60; i++) // 60 seconds = 1 minute
        {
            loggingHelper.LogInfo($"{name} Log entry at {DateTime.Now}");
            await Task.Delay(1000); // Wait for 1 second
        }
        loggingHelper.LogInfo($"{name} has completed.");
    }
}