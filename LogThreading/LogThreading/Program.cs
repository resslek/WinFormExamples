using LogThreading.Factories;
using LogThreading.Forms;
using LogThreading.Interfaces;
using LogThreading.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace LogThreading;

// Internal static class Program
internal static class Program
{
    // Static readonly fields to store the current year and month
    private static readonly string Year = DateTime.Now.ToString("yyyy");
    private static readonly string Month = DateTime.Now.ToString("MM");

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Configure logging
        ConfigureLogging();

        // Create the service provider
        var serviceProvider = CreateHostBuilder();

        // Create the form factory
        var formFactory = new FormFactory(serviceProvider);

        // Initialize application configuration
        ApplicationConfiguration.Initialize();
        // Run the main form
        Application.Run(formFactory.CreateMainForm());

        // Ensure to flush and close the log on application exit
        Log.CloseAndFlush();
    }

    /// <summary>
    /// Method to configure logging using Serilog
    /// </summary>
    private static void ConfigureLogging()
    {
        // Configure Serilog
        var log = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console()
            .MinimumLevel.Information()
            .WriteTo.Map(
                keyPropertyName: "LogName",
                defaultKey: "Main",
                configure: (logName, writeTo) => writeTo.File($"C:\\Temp\\LoggingTest\\{logName}\\{Year}\\{Month}\\{logName}.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff},{Level:u3} ---------------{Message}---------------\n{Exception} {Properties:j}\n",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    fileSizeLimitBytes: 10485760,
                    retainedFileCountLimit: Int32.MaxValue,
                    shared: true))
            .CreateLogger();
        // Set the global logger
        Log.Logger = log;
    }

    /// <summary>
    /// Method to create the host builder and configure services
    /// </summary>
    /// <returns></returns>
    private static IServiceProvider CreateHostBuilder()
    {
        var hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                // Register services with the dependency injection container
                services.AddSingleton<ILoggingFactory, SerilogHelperFactory>();
                services.AddSingleton<ILoggingServiceFactory, LoggingServiceFactory>();
                services.AddSingleton<MainForm>();
                services.AddTransient<Func<string, LoggingService>>(
                    container =>
                        something =>
                        {
                            var helloWorldService = container.GetRequiredService<ILoggingFactory>();
                            return new LoggingService(helloWorldService, something);
                        });
            });
        var host = hostBuilder.Build();
        // Return the service provider
        return host.Services;
    }
}