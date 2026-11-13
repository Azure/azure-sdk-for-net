// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;

/// <summary>
/// Pipeline policy that sets the <c>User-Agent</c> header on outbound Foundry
/// task storage requests to include the AgentServer service version identity.
/// </summary>
internal sealed class ServerVersionPolicy : HttpPipelinePolicy
{
    private const string UserAgentHeader = "User-Agent";
    private readonly ServerVersionRegistry _registry;

    public ServerVersionPolicy(ServerVersionRegistry registry)
    {
        _registry = registry;
    }

    /// <inheritdoc/>
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ApplyUserAgent(message);
        ProcessNext(message, pipeline);
    }

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ApplyUserAgent(message);
        await ProcessNextAsync(message, pipeline);
    }

    private void ApplyUserAgent(HttpMessage message)
    {
        var segments = _registry.GetSegments();
        if (segments.Count == 0)
        {
            return;
        }

        var serverVersion = string.Join(" ", segments);
        if (message.Request.Headers.TryGetValue(UserAgentHeader, out var existing))
        {
            message.Request.Headers.SetValue(UserAgentHeader, $"{serverVersion} {existing}");
        }
        else
        {
            message.Request.Headers.SetValue(UserAgentHeader, serverVersion);
        }
    }
}
