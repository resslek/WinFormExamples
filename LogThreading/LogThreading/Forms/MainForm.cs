using LogThreading.Interfaces;

namespace LogThreading.Forms;

/// <summary>
/// The MainForm class is the main form of the application. It initializes the logging services and handles the start button click event to start logging tasks.
/// </summary>
public partial class MainForm : Form
{
    private readonly ILoggingServiceFactory _loggingServiceFactory;
    private readonly ILoggingHelper _loggingHelper;

    /// <summary>
    /// Initializes a new instance of the MainForm class.
    /// </summary>
    /// <param name="loggingServiceFactory">The logging service factory.</param>
    /// <param name="loggingFactory">The logging factory.</param>
    public MainForm(ILoggingServiceFactory loggingServiceFactory, ILoggingFactory loggingFactory)
    {
        _loggingServiceFactory = loggingServiceFactory;
        _loggingHelper = loggingFactory.Create("Main");
        InitializeComponent();
    }

    /// <summary>
    /// Handles the start button click event to start logging tasks.
    /// </summary>
    private async void Start_Click(object sender, EventArgs e)
    {
        try
        {
            // Create an array to hold the tasks
            var tasks = new Task[4];
            _loggingHelper.LogInfo("All tasks are starting...");
            // Initialize the tasks
            for (var i = 0; i < 4; i++)
            {
                var taskNumber = i + 1; // Capture the loop variable
                tasks[i] = Task.Run(async () => { await LoggingTask(taskNumber); });
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            _loggingHelper.LogInfo("All tasks have completed.");
            MessageBox.Show("All tasks have completed.");
        }
        catch (Exception ex)
        {
            _loggingHelper.LogError("Main application failed.", ex);
        }
    }

    /// <summary>
    /// Represents a logging task that logs information at regular intervals.
    /// </summary>
    /// <param name="taskNumber">The task number.</param>
    private async Task LoggingTask(int taskNumber)
    {
        _loggingHelper.LogInfo($"Task{taskNumber} created.");
        // form factory
        var loggingService = _loggingServiceFactory.Create($"Task{taskNumber}");
        await loggingService.StartLoggingAsync();
        _loggingHelper.LogInfo($"Task{taskNumber} ended.");
    }
}
