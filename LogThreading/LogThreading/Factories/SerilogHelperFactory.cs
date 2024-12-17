using LogThreading.Interfaces;
using LogThreading.Helpers;

namespace LogThreading.Factories;

public class SerilogHelperFactory : ILoggingFactory
{
    // This method creates an instance of SerilogHelper with the provided logName
    public ILoggingHelper Create(string logName)
    {
        return new SerilogHelper(logName);
    }
}