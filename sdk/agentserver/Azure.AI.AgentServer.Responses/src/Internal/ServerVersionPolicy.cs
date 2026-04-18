// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Pipeline policy that sets the <c>User-Agent</c> header on outbound Foundry
/// storage requests to include the AgentServer service version identity.
/// </summary>
internal sealed class ServerVersionPolicy : HttpPipelinePolicy
{
    private const string UserAgentHeader = "User-Agent";
    private readonly string _userAgent;

    /// <summary>
    /// Initializes a new instance of <see cref="ServerVersionPolicy"/>.
    /// </summary>
    /// <param name="userAgent">The User-Agent value to set on outbound requests.</param>
    public ServerVersionPolicy(string userAgent)
    {
        _userAgent = userAgent;
    }

    /// <inheritdoc/>
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ApplyUserAgent(message, _userAgent);
        ProcessNext(message, pipeline);
    }

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ApplyUserAgent(message, _userAgent);
        await ProcessNextAsync(message, pipeline);
    }

    /// <summary>
    /// Applies the server version user-agent to the request, prepending to any existing value.
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
