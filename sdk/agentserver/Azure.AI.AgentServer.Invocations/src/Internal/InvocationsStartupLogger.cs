// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Logs Invocations protocol configuration at application startup.
/// </summary>
internal sealed class InvocationsStartupLogger : IHostedService
{
    private readonly ILogger<InvocationsStartupLogger> _logger;

    public InvocationsStartupLogger(ILogger<InvocationsStartupLogger> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Invocations protocol registered");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
