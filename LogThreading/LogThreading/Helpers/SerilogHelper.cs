using LogThreading.Interfaces;
using Serilog;

namespace LogThreading.Helpers;

/// <summary>
/// Helper class for logging using Serilog.
/// Implements the <see cref="ILoggingHelper"/> interface.
/// </summary>
public class SerilogHelper(string logName) : ILoggingHelper
{
    /// <summary>
    /// Gets or sets the current serial being tested.
    /// </summary>
    public string CurrentSerialBeingTested { get; set; } = string.Empty;

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogInfo(string message)
    {
        Log.ForContext("LogName", logName).Information(CurrentSerialBeingTested == string.Empty ? message : $"{CurrentSerialBeingTested} {message}");
    }

    /// <summary>
    /// Logs an error message with an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    public void LogError(Exception ex)
    {
        Log.ForContext("LogName", logName).Error(ex, CurrentSerialBeingTested == string.Empty ? ex.Message : $"{CurrentSerialBeingTested} {ex.Message}");
    }

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogError(string message)
    {
        Log.ForContext("LogName", logName).Error(CurrentSerialBeingTested == string.Empty ? message : $"{CurrentSerialBeingTested} {message}");
    }

    /// <summary>
    /// Logs an error message with an exception.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="ex">The exception to log.</param>
    public void LogError(string message, Exception ex)
    {
        Log.ForContext("LogName", logName).Error(ex, CurrentSerialBeingTested == string.Empty ? message : $"{CurrentSerialBeingTested} {message}");
    }

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogDebug(string message)
    {
        Log.ForContext("LogName", logName).Debug(CurrentSerialBeingTested == string.Empty ? message : $"{CurrentSerialBeingTested} {message}");
    }
}
