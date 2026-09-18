// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Realtime;

namespace Azure.AI.Projects;

/// <summary>
/// Realtime session client, using bearer token authentication.
/// </summary>
[Experimental("AAIP002")]
public class ProjectsRealtimeSessionClient : RealtimeSessionClient
{
    private readonly IReadOnlyDictionary<string, object> _tokenProperties;
    private readonly string _experimentalHeaders;
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly Uri _uri;
    /// <summary>
    /// Internal empty constructor for mocking.
    /// </summary>
    protected ProjectsRealtimeSessionClient(): base(null, null, default, default, null) { }

    /// <summary>
    /// Create a new instance of ProjectsRealtimeClient
    /// </summary>
    public ProjectsRealtimeSessionClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, ProjectsRealtimeSessionClientOptions options)
        : base(
            credential: null,
            endpoint: endpoint,
            model: options.Model,
            intent: options.Intent,
            parentClient: options.ParentClient
        )
    {
        _tokenProvider = tokenProvider;
        _tokenProperties = options.TokenProperties;
        _uri = RealtimeClientHelper.GetWebSocketEndpoint(endpoint, null);
        _experimentalHeaders = options.ExperimentalHeaders;
    }

    /// <summary>
    /// Connect to the web socket of the Voice Agent.
    /// </summary>
    /// <param name="queryString"></param>
    /// <param name="headers">Additional headers to ba added to the request.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected override async Task ConnectAsync(string queryString, IDictionary<string, string> headers, CancellationToken cancellationToken = default)
    {
        ClientWebSocket webSocket = new();
        webSocket.Options.SetRequestHeader("Foundry-Features", _experimentalHeaders);
        if (headers is not null)
        {
            foreach (KeyValuePair<string, string> nameHeader in headers)
            {
                webSocket.Options.SetRequestHeader(nameHeader.Key, nameHeader.Value);
            }
        }
        GetTokenOptions tokenOptions = new(_tokenProperties);
        AuthenticationToken token = await _tokenProvider.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);
        webSocket.Options.SetRequestHeader("Authorization", $"{token.TokenType} {token.TokenValue}");
        Uri socketUri = _uri;
        if (!string.IsNullOrEmpty(queryString))
        {
            UriBuilder builder = new(_uri)
            {
                Query = queryString
            };
            socketUri = builder.Uri;
        }
        await webSocket.ConnectAsync(socketUri, cancellationToken).ConfigureAwait(false);
    }
}
