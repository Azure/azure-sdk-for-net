// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Realtime;

// OpenAI.Realtime's RealtimeClient/RealtimeSessionClient -- the types this file builds on -- are
// experimental in the referenced OpenAI package version.
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Agents;

/// <summary> The client for starting real-time voice-agent sessions. </summary>
/// <remarks>
/// This type extends OpenAI's <see cref="RealtimeClient"/> so that voice-agent sessions share the
/// same transport, command, and event model as OpenAI's realtime protocol. Only the connection
/// handshake (endpoint shape, headers, and Microsoft Entra ID authentication) is specific to
/// Foundry voice agents; see <see cref="VoiceAgentSession"/> for the corresponding
/// <see cref="RealtimeSessionClient"/> override that performs it.
/// </remarks>
[Experimental("AAIP001")]
public partial class VoiceAgentWebSocket : RealtimeClient
{
    internal static readonly IReadOnlyDictionary<string, object> TokenContext = new Dictionary<string, object>
    {
        [GetTokenOptions.ScopesPropertyName] = new string[] { "https://ai.azure.com/.default" },
        [GetTokenOptions.AuthorizationUrlPropertyName] = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize"
    };

    // Also sent as the x-ms-client-sdk query parameter so identification survives on platforms that
    // disallow setting User-Agent on a WebSocket (e.g. .NET Framework) and through intermediaries that
    // strip non-standard headers.
    internal const string UserAgentValue = "Azure-VoiceAgents-SDK/.NET";

    private readonly Uri _endpoint;
    private readonly string _apiVersion;
    private readonly AuthenticationTokenProvider _tokenProvider;

    /// <summary> Initializes a new instance of <see cref="VoiceAgentWebSocket"/> for mocking. </summary>
    protected VoiceAgentWebSocket()
    {
    }

    internal VoiceAgentWebSocket(ClientDiagnostics clientDiagnostics, ClientPipeline pipeline, Uri endpoint, string apiVersion, AuthenticationTokenProvider tokenProvider)
        : base(pipeline, new RealtimeClientOptions { Endpoint = endpoint })
    {
        _endpoint = endpoint;
        _apiVersion = apiVersion;
        _tokenProvider = tokenProvider;
    }

    /// <summary> Starts a real-time session with the specified voice agent. </summary>
    /// <param name="agentName"> The name of the voice agent. </param>
    /// <param name="options"> Optional connection settings. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> A connected voice-agent session. </returns>
    public virtual async Task<VoiceAgentSession> StartSessionAsync(
        string agentName,
        VoiceAgentConnectionOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        options ??= new VoiceAgentConnectionOptions();
        VoiceAgentSession session = new VoiceAgentSession(_endpoint, agentName, this, _apiVersion, _tokenProvider, options);
        try
        {
            await session.ConnectInternalAsync(cancellationToken).ConfigureAwait(false);
            return session;
        }
        catch
        {
            session.Dispose();
            throw;
        }
    }

    /// <summary>
    /// This OpenAI-style overload starts an OpenAI realtime session and is not applicable to
    /// Foundry voice agents. Use
    /// <see cref="StartSessionAsync(string, VoiceAgentConnectionOptions, CancellationToken)"/>
    /// instead.
    /// </summary>
    public override Task<RealtimeSessionClient> StartSessionAsync(string model, string intent, RealtimeSessionClientOptions options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException($"{nameof(VoiceAgentWebSocket)} only supports Foundry voice-agent sessions; use {nameof(StartSessionAsync)}(string, {nameof(VoiceAgentConnectionOptions)}, CancellationToken) instead.");

    /// <summary>
    /// This OpenAI-style overload starts an OpenAI realtime session and is not applicable to
    /// Foundry voice agents. Use
    /// <see cref="StartSessionAsync(string, VoiceAgentConnectionOptions, CancellationToken)"/>
    /// instead.
    /// </summary>
    public override RealtimeSessionClient StartSession(string model, string intent, RealtimeSessionClientOptions options = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException($"{nameof(VoiceAgentWebSocket)} only supports Foundry voice-agent sessions; use {nameof(StartSessionAsync)}(string, {nameof(VoiceAgentConnectionOptions)}, CancellationToken) instead.");

    /// <summary> Ephemeral client secrets are an OpenAI-specific concept and are not supported by Foundry voice agents. </summary>
    public override ClientResult CreateRealtimeClientSecret(BinaryContent content, RequestOptions options = null)
        => throw new NotSupportedException($"{nameof(CreateRealtimeClientSecret)} is not supported by {nameof(VoiceAgentWebSocket)}; Foundry voice agents authenticate with Microsoft Entra ID instead of ephemeral client secrets.");

    /// <summary> Ephemeral client secrets are an OpenAI-specific concept and are not supported by Foundry voice agents. </summary>
    public override Task<ClientResult> CreateRealtimeClientSecretAsync(BinaryContent content, RequestOptions options = null)
        => throw new NotSupportedException($"{nameof(CreateRealtimeClientSecretAsync)} is not supported by {nameof(VoiceAgentWebSocket)}; Foundry voice agents authenticate with Microsoft Entra ID instead of ephemeral client secrets.");

    /// <summary> Ephemeral client secrets are an OpenAI-specific concept and are not supported by Foundry voice agents. </summary>
    public override ClientResult<CreateClientSecretResult> CreateRealtimeClientSecret(CreateClientSecretOptions options, CancellationToken cancellationToken = default)
        => throw new NotSupportedException($"{nameof(CreateRealtimeClientSecret)} is not supported by {nameof(VoiceAgentWebSocket)}; Foundry voice agents authenticate with Microsoft Entra ID instead of ephemeral client secrets.");

    /// <summary> Ephemeral client secrets are an OpenAI-specific concept and are not supported by Foundry voice agents. </summary>
    public override Task<ClientResult<CreateClientSecretResult>> CreateRealtimeClientSecretAsync(CreateClientSecretOptions options, CancellationToken cancellationToken = default)
        => throw new NotSupportedException($"{nameof(CreateRealtimeClientSecretAsync)} is not supported by {nameof(VoiceAgentWebSocket)}; Foundry voice agents authenticate with Microsoft Entra ID instead of ephemeral client secrets.");

    internal Uri CreateWebSocketUri(string agentName, VoiceAgentConnectionOptions options)
        => VoiceAgentSession.CreateWebSocketUri(_endpoint, agentName, _apiVersion, options);
}

/// <summary> Options for connecting to a Foundry voice agent. </summary>
[Experimental("AAIP001")]
public class VoiceAgentConnectionOptions
{
    /// <summary>
    /// Gets or sets an optional identifier sent as the <c>agent_session_id</c> connection-URL query
    /// parameter. This parameter is not part of the currently-documented Voice Agents WebSocket
    /// contract; live verification shows it is not echoed back anywhere in the <c>session.created</c>/
    /// <c>session.updated</c> payload (the service assigns its own <c>session.id</c>/<c>conversation_id</c>
    /// regardless of this value), so its effect, if any, is unconfirmed.
    /// </summary>
    public string SessionId { get; set; }

    /// <summary> Gets or sets whether this session's conversation is persisted, overriding the agent definition when specified. </summary>
    public bool? Store { get; set; }

    /// <summary> Gets or sets the agent version to use instead of the current default version. </summary>
    public string AgentVersion { get; set; }

    /// <summary> Gets or sets structured input values serialized as a JSON object, overriding the agent definition's defaults for this session only. </summary>
    public BinaryData StructuredInputs { get; set; }

    /// <summary> Gets or sets whether to negotiate the <c>realtime</c> WebSocket subprotocol. </summary>
    public bool UseRealtimeSubprotocol { get; set; } = true;

    /// <summary> Gets or sets the connection transport. Omit or use <c>"websocket"</c> for the default JSON/base64-audio transport, or <c>"webrtc"</c> to negotiate a WebRTC connection where the WebSocket carries only SDP signaling (see <see cref="VoiceAgentSession.CreateRtcCallSdpAsync(string, BinaryData, CancellationToken)"/>). </summary>
    public string Transport { get; set; }
}

/// <summary> Represents a connected real-time voice-agent session. </summary>
/// <remarks>
/// This type extends OpenAI's <see cref="RealtimeSessionClient"/>, reusing its command and event
/// model and its higher-level convenience methods (for example
/// <see cref="RealtimeSessionClient.SendInputAudioAsync(BinaryData, CancellationToken)"/>,
/// <see cref="RealtimeSessionClient.TruncateItemAsync(string, int, TimeSpan, CancellationToken)"/>,
/// or <see cref="RealtimeSessionClient.ReceiveUpdatesAsync(CancellationToken)"/> for OpenAI's
/// strongly-typed <see cref="RealtimeServerUpdate"/> sequence). Only the WebSocket connection
/// handshake is overridden here to reach the Foundry voice-agent endpoint.
/// </remarks>
[Experimental("AAIP001")]
public class VoiceAgentSession : RealtimeSessionClient, IAsyncDisposable
{
    private readonly Uri _endpoint;
    private readonly string _agentName;
    private readonly string _apiVersion;
    private readonly AuthenticationTokenProvider _tokenProvider;
    private readonly VoiceAgentConnectionOptions _options;
    private bool _disposed;

    internal VoiceAgentSession(
        Uri endpoint,
        string agentName,
        VoiceAgentWebSocket parentClient,
        string apiVersion,
        AuthenticationTokenProvider tokenProvider,
        VoiceAgentConnectionOptions options)
        : base(credential: null, endpoint: endpoint, model: agentName, intent: null, parentClient: parentClient)
    {
        _endpoint = endpoint;
        _agentName = agentName;
        _apiVersion = apiVersion;
        _tokenProvider = tokenProvider;
        _options = options;
    }

    /// <summary> Initializes a new instance of <see cref="VoiceAgentSession"/> for mocking or for wrapping an already-connected <see cref="WebSocket"/>. </summary>
    internal VoiceAgentSession(WebSocket webSocket, VoiceAgentWebSocket parentClient = null)
        : base(credential: null, endpoint: null, model: null, intent: null, parentClient: parentClient)
    {
        WebSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
    }

    /// <summary> Gets the current WebSocket connection state. </summary>
    public WebSocketState ConnectionState => WebSocket.State;

    /// <summary> Gets whether the session is connected. </summary>
    public bool IsConnected => WebSocket.State == WebSocketState.Open;

    // Bridges VoiceAgentWebSocket.StartSessionAsync (a sibling class, not a subclass) to the
    // protected ConnectAsync override below; ConnectAsync itself cannot be "protected internal"
    // because it overrides a protected-internal member declared in another assembly (OpenAI.dll).
    internal Task ConnectInternalAsync(CancellationToken cancellationToken)
        => ConnectAsync(cancellationToken: cancellationToken);

#pragma warning disable AZC0004 // WebSocket connections are asynchronous-only.
    /// <summary> Connects to the Foundry voice-agent endpoint for this session. </summary>
    protected override async Task ConnectAsync(string queryString = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
    {
        if (_tokenProvider is null)
        {
            throw new InvalidOperationException("A token provider is required to start a voice-agent session.");
        }

        ClientWebSocket webSocket = new ClientWebSocket();
        try
        {
            webSocket.Options.SetRequestHeader("Foundry-Features", "VoiceAgents=V1Preview");
            if (_options.UseRealtimeSubprotocol)
            {
                webSocket.Options.AddSubProtocol("realtime");
            }

            GetTokenOptions tokenOptions = _tokenProvider.CreateTokenOptions(VoiceAgentWebSocket.TokenContext)
                ?? throw new InvalidOperationException("The token provider does not support the Foundry authentication flow.");
            AuthenticationToken token = await _tokenProvider.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);
            webSocket.Options.SetRequestHeader("Authorization", $"{token.TokenType} {token.TokenValue}");

            try
            {
                webSocket.Options.SetRequestHeader("User-Agent", VoiceAgentWebSocket.UserAgentValue);
            }
            catch (ArgumentException)
            {
                // Some platforms (e.g. .NET Framework) do not allow setting the User-Agent header on a WebSocket.
            }

            await webSocket.ConnectAsync(CreateWebSocketUri(_endpoint, _agentName, _apiVersion, _options), cancellationToken).ConfigureAwait(false);
            WebSocket = webSocket;
        }
        catch
        {
            webSocket.Dispose();
            throw;
        }
    }
#pragma warning restore AZC0004

    internal static Uri CreateWebSocketUri(Uri endpoint, string agentName, string apiVersion, VoiceAgentConnectionOptions options)
    {
        UriBuilder builder = new UriBuilder(endpoint)
        {
            Scheme = string.Equals(endpoint.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ? "wss" : "ws",
            Port = -1,
            Path = $"{endpoint.AbsolutePath.TrimEnd('/')}/agents/{Uri.EscapeDataString(agentName)}/endpoint/protocols/voice"
        };

        StringBuilder query = new StringBuilder();
        AppendQueryParameter(query, "api-version", apiVersion);
        AppendQueryParameter(query, "x-ms-client-sdk", VoiceAgentWebSocket.UserAgentValue);
        AppendQueryParameter(query, "agent_session_id", options.SessionId);
        AppendQueryParameter(query, "store", options.Store.HasValue ? (options.Store.Value ? "true" : "false") : null);
        AppendQueryParameter(query, "x-agent-version-override", options.AgentVersion);
        AppendQueryParameter(query, "structured_input", options.StructuredInputs?.ToString());
        AppendQueryParameter(query, "transport", options.Transport);
        builder.Query = query.ToString();
        return builder.Uri;
    }

    private static void AppendQueryParameter(StringBuilder query, string name, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        if (query.Length > 0)
        {
            query.Append('&');
        }
        query.Append(Uri.EscapeDataString(name));
        query.Append('=');
        query.Append(Uri.EscapeDataString(value));
    }

    /// <summary> Sends a JSON command to the voice agent. </summary>
    public virtual Task SendCommandAsync(BinaryData command, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(command, nameof(command));
        return base.SendCommandAsync(command, new RequestOptions { CancellationToken = cancellationToken });
    }

    /// <summary> Sends a binary frame to the voice agent. Use only for non-JSON, transport-level extensions; the realtime protocol itself carries audio as base64 JSON (see <see cref="RealtimeSessionClient.SendInputAudioAsync(BinaryData, CancellationToken)"/>). </summary>
    public virtual async Task SendBinaryAsync(BinaryData data, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(data, nameof(data));
        await WebSocket.SendAsync(new ArraySegment<byte>(data.ToArray()), WebSocketMessageType.Binary, true, cancellationToken).ConfigureAwait(false);
    }

    /// <summary> Clears any buffered output audio that has not yet been played by the caller. </summary>
    public virtual Task ClearOutputAudioAsync(CancellationToken cancellationToken = default)
        => SendCommandAsync(new RealtimeClientCommandOutputAudioBufferClear(), cancellationToken);

    /// <summary> Truncates a prior assistant audio item at the given content index and playback position. </summary>
    /// <remarks> Overridden only to preserve this SDK's existing parameter names; delegates directly to the base implementation. </remarks>
    public override Task TruncateItemAsync(string itemId, int contentIndex, TimeSpan audioEndTime, CancellationToken cancellationToken = default)
        => base.TruncateItemAsync(itemId, contentIndex, audioEndTime, cancellationToken);

    /// <summary> Sends a <c>session.update</c> event with the raw session configuration payload. </summary>
    public virtual Task ConfigureSessionAsync(BinaryData session, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(session, nameof(session));
        BinaryData command = BuildEvent(RealtimeClientEventType.SessionUpdate, writer => WriteRawProperty(writer, "session", session));
        return SendCommandAsync(command, cancellationToken);
    }

    /// <summary> Adds a conversation item, optionally positioned after a specific existing item. </summary>
    public virtual Task AddItemAsync(BinaryData item, string previousItemId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(item, nameof(item));
        BinaryData command = BuildEvent(RealtimeClientEventType.ConversationItemCreate, writer =>
        {
            if (previousItemId is not null)
            {
                writer.WriteString("previous_item_id", previousItemId);
            }
            WriteRawProperty(writer, "item", item);
        });
        return SendCommandAsync(command, cancellationToken);
    }

    /// <summary> Requests generation of a new response, optionally with additional raw response options. </summary>
    public virtual Task StartResponseAsync(BinaryData responseOptions = null, CancellationToken cancellationToken = default)
    {
        BinaryData command = BuildEvent(RealtimeClientEventType.ResponseCreate, writer =>
        {
            if (responseOptions is not null)
            {
                WriteRawProperty(writer, "response", responseOptions);
            }
        });
        return SendCommandAsync(command, cancellationToken);
    }

    /// <summary> Sends a <c>session.avatar.connect</c> event to begin avatar media (SDP) negotiation. </summary>
    /// <param name="clientSdp"> The client's SDP offer for avatar media negotiation. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    public virtual Task ConnectAvatarAsync(string clientSdp, CancellationToken cancellationToken = default)
        => SendCommandAsync(new VoiceAgentClientCommandSessionAvatarConnect(clientSdp), cancellationToken);

    /// <summary> Sends a <c>rtc.call.sdp.create</c> event to begin WebRTC call signaling with an SDP offer. </summary>
    /// <param name="sdpOffer"> The client's SDP offer for the WebRTC connection. </param>
    /// <param name="session"> Optional raw session configuration; for an <c>/agents</c> endpoint the service rebuilds it authoritatively from the persisted agent definition. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    public virtual Task CreateRtcCallSdpAsync(string sdpOffer, BinaryData session = null, CancellationToken cancellationToken = default)
        => SendCommandAsync(new VoiceAgentClientCommandRtcCallSdpCreate(sdpOffer, session), cancellationToken);

    private static BinaryData BuildEvent(RealtimeClientEventType type, Action<Utf8JsonWriter> writeAdditionalProperties = null)
    {
        using MemoryStream stream = new MemoryStream();
        using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartObject();
            writer.WriteString("type", type.ToString());
            writeAdditionalProperties?.Invoke(writer);
            writer.WriteEndObject();
        }
        return BinaryData.FromBytes(stream.ToArray());
    }

    private static void WriteRawProperty(Utf8JsonWriter writer, string propertyName, BinaryData rawJson)
    {
        writer.WritePropertyName(propertyName);
        using JsonDocument document = JsonDocument.Parse(rawJson);
        document.RootElement.WriteTo(writer);
    }

    /// <summary> Receives text and binary messages from the voice agent. </summary>
    public new virtual async IAsyncEnumerable<VoiceAgentSessionMessage> ReceiveUpdatesAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        RequestOptions options = new RequestOptions { CancellationToken = cancellationToken };
        await foreach (ClientResult result in base.ReceiveUpdatesAsync(options).ConfigureAwait(false))
        {
            using PipelineResponse response = result.GetRawResponse();
            if (response?.Content is BinaryData data)
            {
                yield return new VoiceAgentSessionMessage(WebSocketMessageType.Text, data);
            }
        }
    }

    /// <summary> Closes the WebSocket session gracefully. </summary>
    public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        if (WebSocket.State == WebSocketState.Open || WebSocket.State == WebSocketState.CloseReceived)
        {
            await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client initiated close", cancellationToken).ConfigureAwait(false);
        }
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            _disposed = true;
            try
            {
                await CloseAsync().ConfigureAwait(false);
            }
            finally
            {
                Dispose();
            }
        }
    }
}

/// <summary> A text or binary message received from a voice-agent session. </summary>
[Experimental("AAIP001")]
public class VoiceAgentSessionMessage
{
    private bool _eventTypeParsed;
    private RealtimeServerEventType? _eventType;

    internal VoiceAgentSessionMessage(WebSocketMessageType messageType, BinaryData data)
    {
        MessageType = messageType;
        Data = data;
    }

    /// <summary> Gets the WebSocket message type. </summary>
    public WebSocketMessageType MessageType { get; }

    /// <summary> Gets the complete message payload. </summary>
    public BinaryData Data { get; }

    /// <summary> Gets the parsed <c>type</c> discriminator for JSON event messages, or <c>null</c> for non-JSON/binary messages. </summary>
    public RealtimeServerEventType? EventType
    {
        get
        {
            if (!_eventTypeParsed)
            {
                _eventType = TryParseEventType();
                _eventTypeParsed = true;
            }
            return _eventType;
        }
    }

    private RealtimeServerEventType? TryParseEventType()
    {
        if (MessageType != WebSocketMessageType.Text)
        {
            return null;
        }
        try
        {
            using JsonDocument document = JsonDocument.Parse(Data);
            return document.RootElement.TryGetProperty("type", out JsonElement typeElement) ? (RealtimeServerEventType)typeElement.GetString() : null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    /// <summary>
    /// Deserializes this message's payload as a strongly-typed realtime server update (for
    /// example <see cref="VoiceAgentServerUpdateSessionAvatarConnecting"/>). Check
    /// <see cref="EventType"/> first to determine which <typeparamref name="T"/> to use.
    /// </summary>
    /// <typeparam name="T"> The target realtime server update type, matching this message's <see cref="EventType"/>. </typeparam>
    public T As<T>() where T : RealtimeServerUpdate
        => ModelReaderWriter.Read<T>(Data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
}
