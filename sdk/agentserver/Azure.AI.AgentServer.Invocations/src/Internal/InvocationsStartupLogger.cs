// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
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
        _logger.LogInformation(
            "Invocations protocol registered (route: /invocations, /invocations_ws); ws_keepalive_interval={WsKeepAliveInterval}",
            FoundryEnvironment.WebSocketKeepAliveInterval == Timeout.InfiniteTimeSpan
                ? "disabled"
                : FoundryEnvironment.WebSocketKeepAliveInterval.ToString());

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
