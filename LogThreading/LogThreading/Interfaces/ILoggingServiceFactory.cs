using LogThreading.Services;

namespace LogThreading.Interfaces;

public interface ILoggingServiceFactory
{
    LoggingService Create(string logName);
}