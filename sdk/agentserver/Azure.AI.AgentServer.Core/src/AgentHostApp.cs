// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Represents a configured and runnable agent server application.
/// Wraps the underlying <see cref="WebApplication"/> and provides
/// escape-hatch access for advanced scenarios.
/// </summary>
public sealed class AgentHostApp
{
    /// <summary>
    /// Initializes a new instance of <see cref="AgentHostApp"/>.
    /// </summary>
    internal AgentHostApp(WebApplication app)
    {
        App = app;
    }

    /// <summary>
    /// Escape hatch to the underlying <see cref="WebApplication"/>.
    /// Use this to add custom middleware, routes, or other ASP.NET Core configuration.
    /// </summary>
    public WebApplication App { get; }

    /// <summary>
    /// Start the server and block until shutdown (SIGTERM or Ctrl+C).
    /// </summary>
    public void Run()
    {
        App.Run();
    }

    /// <summary>
    /// Start the server asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to trigger graceful shutdown.</param>
    /// <returns>A task that completes when the server shuts down.</returns>
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.CanBeCanceled)
        {
            // WebApplication.RunAsync(string? url) doesn't accept a CancellationToken directly.
            // Use Lifetime.StopApplication() to honor the external token synchronously
            // without fire-and-forget async pitfalls.
            await using var reg = cancellationToken.Register(() => App.Lifetime.StopApplication());
            await App.RunAsync();
        }
        else
        {
            await App.RunAsync();
        }
    }
}
