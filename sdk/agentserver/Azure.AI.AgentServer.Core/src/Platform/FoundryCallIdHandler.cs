// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// A <see cref="DelegatingHandler"/> that echoes the per-request
/// <c>x-agent-foundry-call-id</c> from the ambient <see cref="FoundryAgentRequestContext"/>
/// on every outbound request (container protocol version <c>2.0.0</c>).
/// </summary>
/// <remarks>
/// <para>
/// Add this handler to any <see cref="HttpClient"/> that calls Foundry platform
/// services (toolbox MCP, Files, Memories, Indexes, project Responses/Chat) so
/// the call id is attached automatically, instead of stamping it per call.
/// </para>
/// <para>
/// Only <c>x-agent-foundry-call-id</c> is attached; <c>x-agent-user-id</c> is
/// never echoed — the receiver resolves user identity from the call id. When no
/// call id is present (protocol <c>1.0.0</c> or local development) the request
/// is forwarded unchanged.
/// </para>
/// <example>
/// <code>
/// services.AddHttpClient("foundry").AddHttpMessageHandler&lt;FoundryCallIdHandler&gt;();
/// // or
/// new HttpClient(new FoundryCallIdHandler { InnerHandler = new HttpClientHandler() });
/// </code>
/// </example>
/// </remarks>
public sealed class FoundryCallIdHandler : DelegatingHandler
{
    /// <summary>
    /// Initializes a new instance of <see cref="FoundryCallIdHandler"/>.
    /// </summary>
    public FoundryCallIdHandler()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FoundryCallIdHandler"/> with an inner handler.
    /// </summary>
    /// <param name="innerHandler">The inner handler to delegate to.</param>
    public FoundryCallIdHandler(HttpMessageHandler innerHandler)
        : base(innerHandler)
    {
    }

    /// <inheritdoc />
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Stamp(request);
        return base.SendAsync(request, cancellationToken);
    }

#if NET8_0_OR_GREATER
    /// <inheritdoc />
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Stamp(request);
        return base.Send(request, cancellationToken);
    }
#endif

    private static void Stamp(HttpRequestMessage request)
    {
        var callId = FoundryAgentRequestContext.Current.CallId;
        if (callId is not null)
        {
            // Always overwrite so a stale/static value on DefaultRequestHeaders cannot
            // shadow the current request's call id. When no ambient call id is present
            // (null), this block is skipped and any existing header remains unchanged.
            request.Headers.Remove(PlatformHeaders.FoundryCallId);
            request.Headers.TryAddWithoutValidation(PlatformHeaders.FoundryCallId, callId);
        }
    }
}
