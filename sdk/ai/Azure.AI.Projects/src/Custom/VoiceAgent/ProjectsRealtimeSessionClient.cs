// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
/// strongly-typed <see cref="RealtimeServerUpdate"/> sequence). Only the query string/header
/// values are Foundry-specific here (see the <see cref="ConnectAsync"/> override below); the
/// WebSocket handshake itself is performed by the base <see cref="RealtimeSessionClient.ConnectAsync"/>
/// implementation, targeting the Foundry voice-agent endpoint
/// (<c>/agents/{agentName}/endpoint/protocols/voice</c>) this instance was constructed with instead
/// of OpenAI's generic <c>/realtime</c> endpoint. Use
/// <see cref="ProjectsRealtimeClient.StartSessionAsync"/> (via <see cref="AIProjectClient.ProjectsRealtimeClient"/>)
/// to obtain an already-connected instance.
/// </remarks>
[Experimental("AAIP002")]
public class ProjectsRealtimeSessionClient : RealtimeSessionClient
{
    private readonly string _experimentalHeaders;
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly IReadOnlyDictionary<string, object> _tokenProperties;
    private readonly string _apiVersion;

    /// <summary>
    /// Internal empty constructor for mocking.
    /// </summary>
    protected ProjectsRealtimeSessionClient() : base(null, null, default, default, null) { }

    // No public constructor: an instance created outside this assembly could never reach a
    // connected state -- ConnectAsync is only reachable via the internal ConnectInternalAsync
    // bridge below, which only ProjectsRealtimeClient.StartSessionAsync calls -- so it would be a
    // permanently disconnected client whose WebSocket is always null. Use
    // AIProjectClient.ProjectsRealtimeClient.StartSessionAsync to obtain an already-connected
    // instance instead.
    //
    // Bridges ProjectsRealtimeClient.StartSessionAsync (a sibling type, not a subclass, but in the
    // same assembly): it alone needs to additionally wire up the ProjectsRealtimeClient passed to
    // the base OpenAI type, plus this type's own tokenProperties/apiVersion used for its WebSocket
    // handshake -- none of which an external caller has any legitimate reason to supply.
    //
    // The agent-scoped WebSocket endpoint (.../agents/{model}/endpoint/protocols/voice) is resolved
    // once, here, and handed to the base RealtimeSessionClient constructor as its own endpoint. That
    // lets the base ConnectAsync's own URI building (endpoint + queryString) produce the correct
    // Foundry URL unmodified -- see the ConnectAsync override below, which only needs to supply the
    // Foundry-specific query string/headers, not rebuild the whole URI itself.
    internal ProjectsRealtimeSessionClient(
        Uri endpoint,
        AuthenticationTokenProvider tokenProvider,
        string model,
        string intent,
        IReadOnlyDictionary<string, object> tokenProperties,
        string apiVersion,
        ProjectsRealtimeClient parentClient)
        : base(
            credential: null,
            endpoint: RealtimeClientHelper.GetAgentWebSocketEndpoint(endpoint, model),
            model: model,
            intent: intent,
            parentClient: parentClient
        )
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));

        _tokenProvider = tokenProvider;
        _tokenProperties = tokenProperties;
        _apiVersion = apiVersion;
        _experimentalHeaders = parentClient?.ExperimentalHeaders ?? RealtimeClientHelper.ExperimentalHeaders(null);
    }

    // Bridges ProjectsRealtimeClient.StartSessionAsync (a sibling type, not a subclass, but in the
    // same assembly) to the protected ConnectAsync override below; the override itself cannot be
    // "protected internal" because it overrides a protected-internal member declared in another
    // assembly (OpenAI.dll).
    internal Task ConnectInternalAsync(string queryString, IDictionary<string, string> headers, CancellationToken cancellationToken)
        => ConnectAsync(queryString: queryString, headers: headers, cancellationToken: cancellationToken);

    /// <summary>
    /// Connects to the Foundry voice-agent endpoint this instance was constructed with. Only the
    /// Foundry-specific query string (api-version, merged with any caller-supplied query string --
    /// see <paramref name="queryString"/> -- such as ProjectsRealtimeClient.StartSessionAsync's
    /// "store" option) and headers (Foundry-Features, bearer Authorization) are computed here; the
    /// WebSocket handshake itself (subprotocol negotiation, applying the headers, connecting,
    /// assigning <see cref="RealtimeSessionClient.WebSocket"/>) is entirely delegated to
    /// <see cref="RealtimeSessionClient.ConnectAsync"/>.
    /// </summary>
    /// <param name="queryString">An additional query string merged in after api-version.</param>
    /// <param name="headers">Additional headers to merge with the ones this override computes.</param>
    /// <param name="cancellationToken"></param>
    protected override async Task ConnectAsync(string queryString = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
    {
        GetTokenOptions tokenOptions = new(_tokenProperties);
        AuthenticationToken token = await _tokenProvider.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);

        // No "User-Agent" here: RealtimeSessionClient.ConnectAsync applies every entry in this
        // dictionary via ClientWebSocketOptions.SetRequestHeader, and .NET Framework's
        // implementation of that method rejects "User-Agent" as a restricted header (throwing
        // ArgumentException), unlike .NET/.NET Core. Since Azure.AI.Projects also targets
        // netstandard2.0 (loadable by .NET Framework consumers), sending it here would break the
        // WebSocket handshake for them.
        Dictionary<string, string> connectionHeaders = new()
        {
            ["Foundry-Features"] = _experimentalHeaders,
            ["Authorization"] = $"{token.TokenType} {token.TokenValue}",
        };
        if (headers is not null)
        {
            foreach (KeyValuePair<string, string> nameHeader in headers)
            {
                connectionHeaders[nameHeader.Key] = nameHeader.Value;
            }
        }

        StringBuilder mergedQueryString = new();
        RealtimeClientHelper.AppendQueryParameter(mergedQueryString, "api-version", _apiVersion);
        if (!string.IsNullOrEmpty(queryString))
        {
            if (mergedQueryString.Length > 0)
            {
                mergedQueryString.Append('&');
            }
            mergedQueryString.Append(queryString);
        }

        await base.ConnectAsync(
            queryString: mergedQueryString.ToString(),
            headers: connectionHeaders,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
