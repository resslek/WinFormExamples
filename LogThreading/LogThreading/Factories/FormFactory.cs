using LogThreading.Forms;
using LogThreading.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LogThreading.Factories;

/// <summary>
/// Factory class for creating form instances.
/// </summary>
internal class FormFactory(IServiceProvider serviceProvider) : IFormFactory
{
    /// <summary>
    /// Creates an instance of the MainForm.
    /// </summary>
    /// <returns>A new instance of MainForm.</returns>
    public MainForm CreateMainForm()
    {
        // Retrieve the MainForm instance from the service provider.
        return serviceProvider.GetRequiredService<MainForm>();
    }
}
