// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Logs Activity protocol configuration at application startup.
/// </summary>
internal sealed class ActivityStartupLogger : IHostedService
{
    private readonly ILogger<ActivityStartupLogger> _logger;

    public ActivityStartupLogger(ILogger<ActivityStartupLogger> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Activity protocol registered (route: /activity/messages)");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
