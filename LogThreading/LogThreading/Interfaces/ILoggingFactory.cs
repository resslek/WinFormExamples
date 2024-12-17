namespace LogThreading.Interfaces;

public interface ILoggingFactory
{
    ILoggingHelper Create(string logName);
}