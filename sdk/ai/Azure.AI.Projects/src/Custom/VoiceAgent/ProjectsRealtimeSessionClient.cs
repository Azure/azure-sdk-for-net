// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Realtime;

namespace Azure.AI.Projects;

/// <summary>
/// Realtime session client, using bearer token authentication.
/// </summary>
/// <remarks>
/// This type extends OpenAI's <see cref="RealtimeSessionClient"/> so that voice-agent sessions
/// reuse its command and event model (for example
/// <see cref="RealtimeSessionClient.SendInputAudioAsync(BinaryData, CancellationToken)"/>,
/// <see cref="RealtimeSessionClient.AddItemAsync(RealtimeItem, string, CancellationToken)"/>, or
/// <see cref="RealtimeSessionClient.ReceiveUpdatesAsync(CancellationToken)"/> for OpenAI's
/// strongly-typed <see cref="RealtimeServerUpdate"/> sequence). Only the WebSocket connection
/// handshake is overridden here to reach the Foundry voice-agent endpoint
/// (<c>/agents/{agentName}/endpoint/protocols/voice</c>) instead of OpenAI's generic
/// <c>/realtime</c> endpoint. Use <see cref="AIProjectClient.GetProjectsRealtimeSessionClientAsync"/>
/// to obtain an already-connected instance.
/// </remarks>
[Experimental("AAIP002")]
public class ProjectsRealtimeSessionClient : RealtimeSessionClient
{
    // Reused across connections; matches the User-Agent value the REST pipeline sends elsewhere in
    // this SDK (see AIProjectClient/ProjectsRealtimeClient), so support engineers can identify the
    // SDK/version from either surface. The WebSocket handshake otherwise carries none, unlike a
    // normal HTTP request through a ClientPipeline (which adds this header automatically).
    private static readonly string s_userAgent = new TelemetryDetails(typeof(ProjectsRealtimeSessionClient).Assembly, null, null).UserAgent.ToString();

    private readonly string _experimentalHeaders;
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly Uri _endpoint;
    private readonly string _agentName;
    private readonly bool? _store;

    /// <summary>
    /// Internal empty constructor for mocking.
    /// </summary>
    protected ProjectsRealtimeSessionClient() : base(null, null, default, default, null) { }

    /// <summary>
    /// Create a new instance of ProjectsRealtimeSessionClient.
    /// </summary>
    /// <param name="endpoint">The Foundry project endpoint.</param>
    /// <param name="tokenProvider">The token provider used to authenticate the connection.</param>
    /// <param name="model">The name of the voice agent to connect to (used as the <c>{agentName}</c> path segment).</param>
    /// <param name="intent">The client intent.</param>
    /// <param name="store">Whether this session's conversation is persisted, overriding the agent definition when specified.</param>
    public ProjectsRealtimeSessionClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, string model, string intent = null, bool? store = null)
        : this(endpoint, tokenProvider, model, intent, store, parentClient: null)
    {
    }

    // Bridges AIProjectClient.GetProjectsRealtimeSessionClientAsync (a sibling type, not a subclass,
    // but in the same assembly): it alone needs to additionally wire up the ProjectsRealtimeClient
    // passed to the base OpenAI type, plus this type's own TokenProperties/ApiVersion used for its
    // WebSocket handshake -- none of which an external caller has any legitimate reason to supply.
    internal ProjectsRealtimeSessionClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, string model, string intent, bool? store, ProjectsRealtimeClient parentClient)
        : base(
            credential: null,
            endpoint: endpoint,
            model: model,
            intent: intent,
            parentClient: parentClient
        )
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));

        _tokenProvider = tokenProvider;
        _endpoint = endpoint;
        _agentName = model;
        _store = store;
        _experimentalHeaders = parentClient?.ExperimentalHeaders ?? RealtimeClientHelper.ExperimentalHeaders(null);
    }

    // Set by AIProjectClient.GetProjectsRealtimeSessionClientAsync right after construction; see the
    // internal constructor above for why these can't just be additional constructor parameters.
    internal IReadOnlyDictionary<string, object> TokenProperties { get; set; }
    internal string ApiVersion { get; set; }

    // Bridges AIProjectClient.GetProjectsRealtimeSessionClientAsync (a sibling type, not a subclass,
    // but in the same assembly) to the protected ConnectAsync override below; the override itself
    // cannot be "protected internal" because it overrides a protected-internal member declared in
    // another assembly (OpenAI.dll).
    internal Task ConnectInternalAsync(CancellationToken cancellationToken)
        => ConnectAsync(queryString: null, headers: null, cancellationToken: cancellationToken);

    /// <summary>
    /// Connect to the web socket of the Voice Agent.
    /// </summary>
    /// <param name="queryString"></param>
    /// <param name="headers">Additional headers to ba added to the request.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected override async Task ConnectAsync(string queryString = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
    {
        ClientWebSocket webSocket = new();
        try
        {
            webSocket.Options.AddSubProtocol("realtime");
            webSocket.Options.SetRequestHeader("User-Agent", s_userAgent);
            webSocket.Options.SetRequestHeader("Foundry-Features", _experimentalHeaders);
            if (headers is not null)
            {
                foreach (KeyValuePair<string, string> nameHeader in headers)
                {
                    webSocket.Options.SetRequestHeader(nameHeader.Key, nameHeader.Value);
                }
            }
            GetTokenOptions tokenOptions = new(TokenProperties);
            AuthenticationToken token = await _tokenProvider.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);
            webSocket.Options.SetRequestHeader("Authorization", $"{token.TokenType} {token.TokenValue}");

            Uri socketUri = BuildConnectionUri(queryString);
            await webSocket.ConnectAsync(socketUri, cancellationToken).ConfigureAwait(false);
            WebSocket = webSocket;
        }
        catch
        {
            webSocket.Dispose();
            throw;
        }
    }

    private Uri BuildConnectionUri(string queryString)
    {
        Uri baseUri = RealtimeClientHelper.GetAgentWebSocketEndpoint(_endpoint, _agentName);
        if (!string.IsNullOrEmpty(queryString))
        {
            return new UriBuilder(baseUri) { Query = queryString }.Uri;
        }

        StringBuilder query = new StringBuilder();
        RealtimeClientHelper.AppendQueryParameter(query, "api-version", ApiVersion);
        RealtimeClientHelper.AppendQueryParameter(query, "store", _store.HasValue ? (_store.Value ? "true" : "false") : null);
        return new UriBuilder(baseUri) { Query = query.ToString() }.Uri;
    }
}
