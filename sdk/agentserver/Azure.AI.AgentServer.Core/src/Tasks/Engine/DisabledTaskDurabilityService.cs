// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>Host-lifecycle placeholder used when durable tasks were not opted in.</summary>
internal sealed class DisabledTaskDurabilityService : IHostedService
{
    private readonly ILogger _logger;

    public DisabledTaskDurabilityService(ILogger logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Resilient task runtime is disabled; task storage, recovery scan, and recovery loop were not initialized.");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
