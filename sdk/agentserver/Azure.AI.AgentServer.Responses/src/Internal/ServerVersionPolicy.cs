// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Pipeline policy that sets the <c>User-Agent</c> header on outbound Foundry
/// storage requests to include the AgentServer service version identity.
/// Reads segments lazily from <see cref="ServerVersionRegistry"/> on each request
/// so that registrations after pipeline construction are included.
/// </summary>
internal sealed class ServerVersionPolicy : HttpPipelinePolicy
{
    private const string UserAgentHeader = "User-Agent";
    private readonly ServerVersionRegistry _registry;

    /// <summary>
    /// Initializes a new instance of <see cref="ServerVersionPolicy"/>.
    /// </summary>
    /// <param name="registry">The shared version registry to read segments from.</param>
    public ServerVersionPolicy(ServerVersionRegistry registry)
    {
        _registry = registry;
    }

    /// <inheritdoc/>
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ApplyUserAgent(message, _registry);
        ProcessNext(message, pipeline);
    }

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ApplyUserAgent(message, _registry);
        await ProcessNextAsync(message, pipeline);
    }

    internal static void ApplyUserAgent(HttpMessage message, ServerVersionRegistry registry)
    {
        var segments = registry.GetSegments();
        if (segments.Count == 0)
        {
            return;
        }

        var serverVersion = string.Join(" ", segments);
        ApplyUserAgent(message, serverVersion);
    }

    /// <summary>
    /// Applies a user-agent string to the request, prepending to any existing value.
    /// </summary>
    internal static void ApplyUserAgent(HttpMessage message, string userAgent)
    {
        if (message.Request.Headers.TryGetValue(UserAgentHeader, out var existing))
        {
            message.Request.Headers.SetValue(UserAgentHeader, $"{userAgent} {existing}");
        }
        else
        {
            message.Request.Headers.SetValue(UserAgentHeader, userAgent);
        }
    }
}
