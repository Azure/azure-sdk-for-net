// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Publishes the effective Responses options to resilient-task registration after the host's
/// complete options pipeline has been evaluated.
/// </summary>
internal sealed class ResponsesResilientTaskOptions : IHostedService
{
    private bool? _steerable;
    private bool? _enabled;

    public void Initialize(ResponsesServerOptions options)
    {
        Argument.AssertNotNull(options, nameof(options));
        _steerable = options.SteerableConversations;
        _enabled = options.ResilientBackground || options.SteerableConversations;
    }

    public bool IsSteerable()
        => _steerable
            ?? throw new InvalidOperationException(
                "Responses resilient-task options were accessed before host startup.");

    public bool IsEnabled()
        => _enabled
            ?? throw new InvalidOperationException(
                "Responses resilient-task options were accessed before host startup.");

    Task IHostedService.StartAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    Task IHostedService.StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
