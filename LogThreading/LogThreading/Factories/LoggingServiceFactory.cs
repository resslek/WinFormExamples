using LogThreading.Interfaces;
using LogThreading.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LogThreading.Factories;

// The LoggingServiceFactory class implements the ILoggingServiceFactory interface
// and provides a method to create instances of LoggingService.
internal class LoggingServiceFactory(IServiceProvider serviceProvider) : ILoggingServiceFactory
{
    // The Create method takes a logName as a parameter and returns an instance of LoggingService.
    public LoggingService Create(string logName)
    {
        // Retrieve a factory function for creating LoggingService instances from the service provider.
        var loggingServiceFactory = serviceProvider.GetRequiredService<Func<string, LoggingService>>();

        // Use the factory function to create and return a LoggingService instance with the specified logName.
        return loggingServiceFactory(logName);
    }
}
