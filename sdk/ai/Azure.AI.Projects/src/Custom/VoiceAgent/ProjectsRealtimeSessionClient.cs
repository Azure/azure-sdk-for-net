// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Realtime;

namespace Azure.AI.Projects;

/// <summary>
/// A Realtime WebSocket session for a Foundry voice agent.
/// </summary>
/// <remarks>
/// Create a connected session with <see cref="AIProjectClient.ProjectsRealtimeClient"/> and
/// <see cref="ProjectsRealtimeClient.StartSessionAsync"/>. Use the inherited
/// <see cref="RealtimeSessionClient"/> methods to send messages or audio and receive updates.
/// </remarks>
[Experimental("AAIP002")]
public class ProjectsRealtimeSessionClient : RealtimeSessionClient
{
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly IReadOnlyDictionary<string, object> _tokenProperties;
    private readonly string _apiVersion;
    private readonly VoiceAgentRealtimeTelemetry _telemetry;

    /// <summary>
    /// Initializes a new instance for mocking.
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
        ProjectsRealtimeClient parentClient,
        VoiceAgentRealtimeTelemetry telemetry = null)
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
        _telemetry = telemetry;
    }

    // Bridges ProjectsRealtimeClient.StartSessionAsync (a sibling type, not a subclass, but in the
    // same assembly) to the protected ConnectAsync override below; the override itself cannot be
    // "protected internal" because it overrides a protected-internal member declared in another
    // assembly (OpenAI.dll).
    internal Task ConnectInternalAsync(string queryString, IDictionary<string, string> headers, CancellationToken cancellationToken)
        => ConnectAsync(queryString: queryString, headers: headers, cancellationToken: cancellationToken);

    /// <summary> Receives typed Realtime updates synchronously. </summary>
    /// <param name="cancellationToken"> Cancels receiving updates. </param>
    /// <returns> The updates received from the service. </returns>
    /// <remarks> This method blocks its calling thread. Use <see cref="RealtimeSessionClient.ReceiveUpdatesAsync(CancellationToken)"/> for nonblocking consumption. </remarks>
    public override IEnumerable<RealtimeServerUpdate> ReceiveUpdates(CancellationToken cancellationToken = default)
        => ReadSynchronously(() => ReceiveUpdatesAsync(cancellationToken));

    /// <summary> Receives raw Realtime updates synchronously. </summary>
    /// <param name="options"> The request options, including the cancellation token. </param>
    /// <returns> The raw updates received from the service. </returns>
    public override IEnumerable<ClientResult> ReceiveUpdates(RequestOptions options)
        => ReadSynchronously(() => ReceiveUpdatesAsync(options));

#pragma warning disable AZC0102 // WebSocket receive is asynchronous-only; preserve the synchronous API without reading ahead.
#pragma warning disable AZC0107 // The upstream synchronous receive overloads are stubs, so adapt the working asynchronous enumerators.
    private static IEnumerable<T> ReadSynchronously<T>(Func<IAsyncEnumerable<T>> updates)
    {
        bool dispatch = SynchronizationContext.Current != null || TaskScheduler.Current != TaskScheduler.Default;
        IAsyncEnumerator<T> enumerator = dispatch
            ? Task.Run(() => updates().GetAsyncEnumerator()).GetAwaiter().GetResult()
            : updates().GetAsyncEnumerator();
        try
        {
            while (true)
            {
                bool available;
                if (dispatch)
                {
                    // The upstream async reader captures context; do not block the context its continuation needs.
                    available = Task.Run(async () => await enumerator.MoveNextAsync().ConfigureAwait(false)).GetAwaiter().GetResult();
                }
                else
                {
                    ValueTask<bool> move = enumerator.MoveNextAsync();
                    available = move.IsCompleted
                        ? move.GetAwaiter().GetResult()
                        : move.AsTask().GetAwaiter().GetResult();
                }
                if (!available)
                {
                    yield break;
                }
                yield return enumerator.Current;
            }
        }
        finally
        {
            if (dispatch)
            {
                Task.Run(async () => await enumerator.DisposeAsync().ConfigureAwait(false)).GetAwaiter().GetResult();
            }
            else
            {
                ValueTask dispose = enumerator.DisposeAsync();
                if (dispose.IsCompleted)
                {
                    dispose.GetAwaiter().GetResult();
                }
                else
                {
                    dispose.AsTask().GetAwaiter().GetResult();
                }
            }
        }
    }
#pragma warning restore AZC0107
#pragma warning restore AZC0102

    /// <summary>
    /// Connects to the Foundry voice agent using the project's authentication, API version, and explicit feature opt-ins.
    /// </summary>
    /// <param name="queryString">Additional query parameters, such as <c>store=true</c>.</param>
    /// <param name="headers">Additional WebSocket headers.</param>
    /// <param name="cancellationToken">Cancels authentication and connection.</param>
    protected override async Task ConnectAsync(string queryString = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
    {
        Activity previousActivity = Activity.Current;
        if (_telemetry?.ConnectionActivity != null)
        {
            Activity.Current = _telemetry.ConnectionActivity;
        }
        try
        {
            // No "User-Agent" here: RealtimeSessionClient.ConnectAsync applies every entry in this
            // dictionary via ClientWebSocketOptions.SetRequestHeader, and .NET Framework's
            // implementation of that method rejects "User-Agent" as a restricted header (throwing
            // ArgumentException), unlike .NET/.NET Core. Since Azure.AI.Projects also targets
            // netstandard2.0 (loadable by .NET Framework consumers), sending it here would break the
            // WebSocket handshake for them.
            Dictionary<string, string> connectionHeaders = new(StringComparer.OrdinalIgnoreCase);
            string foundryFeatures = RealtimeClientHelper.ResolveFoundryFeatures(
                headers, ref queryString, requireVoiceAgentsPreview: false);
            if (foundryFeatures != null)
            {
                connectionHeaders["Foundry-Features"] = foundryFeatures;
            }
            if (headers is not null)
            {
                foreach (KeyValuePair<string, string> nameHeader in headers)
                {
                    if (nameHeader.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException("Authentication headers are managed by the client.", nameof(headers));
                    }
                    if (nameHeader.Key.Equals("Foundry-Features", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    if (nameHeader.Key.Equals("Sec-WebSocket-Protocol", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!string.Equals(nameHeader.Value, "realtime", StringComparison.Ordinal))
                        {
                            throw new ArgumentException("Only the realtime WebSocket subprotocol is supported.", nameof(headers));
                        }
                        continue;
                    }
                    connectionHeaders[nameHeader.Key] = nameHeader.Value;
                }
            }
            GetTokenOptions tokenOptions = _tokenProvider.CreateTokenOptions(_tokenProperties);
            if (tokenOptions == null)
            {
                throw new InvalidOperationException("The token provider does not support the Foundry Realtime authentication flow.");
            }
            AuthenticationToken token = await _tokenProvider.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);
            connectionHeaders["Authorization"] = $"{token.TokenType} {token.TokenValue}";
            _telemetry?.AddTraceHeaders(connectionHeaders);

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
            if (_telemetry != null)
            {
                WebSocket = new TelemetryWebSocket(WebSocket, _telemetry);
                _telemetry.Connected();
            }
        }
        finally
        {
            Activity.Current = previousActivity;
        }
    }
}
