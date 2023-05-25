namespace Client;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

/// <summary>
/// This hosted service allows for startup and shutdown activities related to the application itself.
/// </summary>
internal class AppLifecycle : IHostedService
{
    private readonly IConfig config;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppLifecycle"/> class.
    /// </summary>
    /// <param name="config">The configuration for this application.</param>
    public AppLifecycle(IConfig config)
    {
        this.config = config;
    }

    /// <summary>
    /// This method should contain all startup activities for the application.
    /// </summary>
    /// <param name="cancellationToken">A token that can be cancelled to abort startup.</param>
    /// <returns>A Task that is complete when the method is done.</returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        this.config.Validate();
        return Task.CompletedTask;
    }

    /// <summary>
    /// This method should contain all shutdown activities for the application.
    /// </summary>
    /// <param name="cancellationToken">A token that can be cancelled to abort startup.</param>
    /// <returns>A Task that is complete when the method is done.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}