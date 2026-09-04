// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
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

namespace Azure.AI.Projects.Agents;

/// <summary> The client for starting real-time voice-agent sessions. </summary>
[Experimental("AAIP001")]
public partial class VoiceAgentWebSocket
{
    private static readonly IReadOnlyDictionary<string, object> s_tokenContext = new Dictionary<string, object>
    {
        [GetTokenOptions.ScopesPropertyName] = new string[] { "https://ai.azure.com/.default" },
        [GetTokenOptions.AuthorizationUrlPropertyName] = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize"
    };

    // Also sent as the x-ms-client-sdk query parameter so identification survives on platforms that
    // disallow setting User-Agent on a WebSocket (e.g. .NET Framework) and through intermediaries that
    // strip non-standard headers.
    private const string UserAgentValue = "Azure-VoiceAgents-SDK/.NET";

    private readonly Uri _endpoint;
    private readonly string _apiVersion;
    private readonly AuthenticationTokenProvider _tokenProvider;

    /// <summary> Initializes a new instance of <see cref="VoiceAgentWebSocket"/> for mocking. </summary>
    protected VoiceAgentWebSocket()
    {
    }

    /// <summary> Raised immediately before a JSON command is sent on any session started from this client. </summary>
    public event EventHandler<BinaryData> OnSendingCommand;

    /// <summary> Raised immediately after a JSON event is received on any session started from this client. </summary>
    public event EventHandler<BinaryData> OnReceivingCommand;

    internal void RaiseOnSendingCommand(VoiceAgentSession session, BinaryData data) => OnSendingCommand?.Invoke(session, data);

    internal void RaiseOnReceivingCommand(VoiceAgentSession session, BinaryData data) => OnReceivingCommand?.Invoke(session, data);

    internal VoiceAgentWebSocket(ClientDiagnostics clientDiagnostics, ClientPipeline pipeline, Uri endpoint, string apiVersion, AuthenticationTokenProvider tokenProvider)
    {
        _endpoint = endpoint;
        _apiVersion = apiVersion;
        _tokenProvider = tokenProvider;
    }

#pragma warning disable AZC0004 // WebSocket connections are asynchronous-only.
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

        if (_tokenProvider is null)
        {
            throw new InvalidOperationException("A token provider is required to start a voice-agent session.");
        }

        options ??= new VoiceAgentConnectionOptions();
        ClientWebSocket webSocket = new ClientWebSocket();

        try
        {
            webSocket.Options.SetRequestHeader("Foundry-Features", "VoiceAgents=V1Preview");
            if (options.StructuredInputs is not null)
            {
                webSocket.Options.SetRequestHeader("x-ms-voice-structured-inputs", options.StructuredInputs.ToString());
            }
            if (options.UseRealtimeSubprotocol)
            {
                webSocket.Options.AddSubProtocol("realtime");
            }

            GetTokenOptions tokenOptions = _tokenProvider.CreateTokenOptions(s_tokenContext)
                ?? throw new InvalidOperationException("The token provider does not support the Foundry authentication flow.");
            AuthenticationToken token = await _tokenProvider.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);
            webSocket.Options.SetRequestHeader("Authorization", $"Bearer {token.TokenValue}");

            try
            {
                webSocket.Options.SetRequestHeader("User-Agent", UserAgentValue);
            }
            catch (ArgumentException)
            {
                // Some platforms (e.g. .NET Framework) do not allow setting the User-Agent header on a WebSocket.
            }

            await webSocket.ConnectAsync(CreateWebSocketUri(agentName, options), cancellationToken).ConfigureAwait(false);
            return new VoiceAgentSession(webSocket, this);
        }
        catch
        {
            webSocket.Dispose();
            throw;
        }
    }
#pragma warning restore AZC0004

    internal Uri CreateWebSocketUri(string agentName, VoiceAgentConnectionOptions options)
    {
        UriBuilder builder = new UriBuilder(_endpoint)
        {
            Scheme = string.Equals(_endpoint.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ? "wss" : "ws",
            Port = -1,
            Path = $"{_endpoint.AbsolutePath.TrimEnd('/')}/agents/{Uri.EscapeDataString(agentName)}/endpoint/protocols/voice"
        };

        StringBuilder query = new StringBuilder();
        AppendQueryParameter(query, "api-version", _apiVersion);
        AppendQueryParameter(query, "x-ms-client-sdk", UserAgentValue);
        AppendQueryParameter(query, "agent_session_id", options.SessionId);
        AppendQueryParameter(query, "store", options.Store.HasValue ? (options.Store.Value ? "true" : "false") : null);
        AppendQueryParameter(query, "x-agent-version-override", options.AgentVersion);
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
}

/// <summary> Options for connecting to a Foundry voice agent. </summary>
[Experimental("AAIP001")]
public class VoiceAgentConnectionOptions
{
    /// <summary> Gets or sets an optional identifier used to correlate the session. </summary>
    public string SessionId { get; set; }

    /// <summary> Gets or sets whether this session's conversation is persisted, overriding the agent definition when specified. </summary>
    public bool? Store { get; set; }

    /// <summary> Gets or sets the agent version to use instead of the current default version. </summary>
    public string AgentVersion { get; set; }

    /// <summary> Gets or sets structured input values serialized as a JSON object. </summary>
    public BinaryData StructuredInputs { get; set; }

    /// <summary> Gets or sets whether to negotiate the <c>realtime</c> WebSocket subprotocol. </summary>
    public bool UseRealtimeSubprotocol { get; set; } = true;
}

/// <summary> Represents a connected real-time voice-agent session. </summary>
[Experimental("AAIP001")]
public class VoiceAgentSession : IDisposable, IAsyncDisposable
{
    private readonly WebSocket _webSocket;
    private readonly VoiceAgentWebSocket _parentClient;
    private readonly SemaphoreSlim _sendSemaphore = new SemaphoreSlim(1, 1);
    private readonly SemaphoreSlim _audioSendSemaphore = new SemaphoreSlim(1, 1);
    private bool _isSendingAudioStream;
    private int _receiveStarted;
    private bool _disposed;

    internal VoiceAgentSession(WebSocket webSocket, VoiceAgentWebSocket parentClient = null)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _parentClient = parentClient;
    }

    /// <summary> Gets the current WebSocket connection state. </summary>
    public WebSocketState ConnectionState => _webSocket.State;

    /// <summary> Gets whether the session is connected. </summary>
    public bool IsConnected => _webSocket.State == WebSocketState.Open;

    /// <summary> Sends a JSON command to the voice agent. </summary>
    public virtual Task SendCommandAsync(BinaryData command, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(command, nameof(command));
        _parentClient?.RaiseOnSendingCommand(this, command);
        return SendAsync(command, WebSocketMessageType.Text, cancellationToken);
    }

    /// <summary> Sends a binary frame to the voice agent. Use only for non-JSON, transport-level extensions; the realtime protocol itself carries audio as base64 JSON (see <see cref="SendInputAudioAsync(BinaryData, CancellationToken)"/>). </summary>
    public virtual Task SendBinaryAsync(BinaryData data, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(data, nameof(data));
        return SendAsync(data, WebSocketMessageType.Binary, cancellationToken);
    }

    /// <summary> Transmits a chunk of input audio as a base64-encoded <c>input_audio_buffer.append</c> event. </summary>
    public virtual async Task SendInputAudioAsync(BinaryData audio, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        await _audioSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_isSendingAudioStream)
            {
                throw new InvalidOperationException("Cannot send a standalone audio chunk while a stream is already in progress.");
            }
            await SendInputAudioChunkAsync(audio, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _audioSendSemaphore.Release();
        }
    }

    /// <summary> Transmits audio data from a stream, sent as a sequence of base64-encoded <c>input_audio_buffer.append</c> events until the stream is exhausted. </summary>
    public virtual async Task SendInputAudioAsync(Stream audio, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        await _audioSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_isSendingAudioStream)
            {
                throw new InvalidOperationException("Only one stream of audio may be sent at once.");
            }
            _isSendingAudioStream = true;
        }
        finally
        {
            _audioSendSemaphore.Release();
        }

        byte[] buffer = ArrayPool<byte>.Shared.Rent(16 * 1024);
        try
        {
            while (true)
            {
                int bytesRead = await audio.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                if (bytesRead == 0)
                {
                    break;
                }
                await SendInputAudioChunkAsync(BinaryData.FromBytes(buffer.AsMemory(0, bytesRead)), cancellationToken).ConfigureAwait(false);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
            await _audioSendSemaphore.WaitAsync(CancellationToken.None).ConfigureAwait(false);
            try
            {
                _isSendingAudioStream = false;
            }
            finally
            {
                _audioSendSemaphore.Release();
            }
        }
    }

    private Task SendInputAudioChunkAsync(BinaryData audio, CancellationToken cancellationToken)
    {
        BinaryData command = BuildEvent(RealtimeClientEventType.InputAudioBufferAppend,
            writer => writer.WriteString("audio", Convert.ToBase64String(audio.ToArray())));
        return SendCommandAsync(command, cancellationToken);
    }

    /// <summary> Clears any input audio that has been appended but not yet committed. </summary>
    public virtual Task ClearInputAudioAsync(CancellationToken cancellationToken = default)
        => SendCommandAsync(BuildEvent(RealtimeClientEventType.InputAudioBufferClear), cancellationToken);

    /// <summary> Commits the pending input audio buffer as a user turn. </summary>
    public virtual Task CommitPendingAudioAsync(CancellationToken cancellationToken = default)
        => SendCommandAsync(BuildEvent(RealtimeClientEventType.InputAudioBufferCommit), cancellationToken);

    /// <summary> Clears any buffered output audio that has not yet been played by the caller. </summary>
    public virtual Task ClearOutputAudioAsync(CancellationToken cancellationToken = default)
        => SendCommandAsync(BuildEvent(RealtimeClientEventType.OutputAudioBufferClear), cancellationToken);

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

    /// <summary> Requests retrieval of a server-side conversation item by id. </summary>
    public virtual Task RequestItemRetrievalAsync(string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));
        return SendCommandAsync(BuildEvent(RealtimeClientEventType.ConversationItemRetrieve, writer => writer.WriteString("item_id", itemId)), cancellationToken);
    }

    /// <summary> Deletes a conversation item by id. </summary>
    public virtual Task DeleteItemAsync(string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));
        return SendCommandAsync(BuildEvent(RealtimeClientEventType.ConversationItemDelete, writer => writer.WriteString("item_id", itemId)), cancellationToken);
    }

    /// <summary> Truncates a prior assistant audio item at the given content index and playback position. </summary>
    public virtual Task TruncateItemAsync(string itemId, int contentIndex, TimeSpan audioEndTime, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));
        BinaryData command = BuildEvent(RealtimeClientEventType.ConversationItemTruncate, writer =>
        {
            writer.WriteString("item_id", itemId);
            writer.WriteNumber("content_index", contentIndex);
            writer.WriteNumber("audio_end_ms", (long)audioEndTime.TotalMilliseconds);
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

    /// <summary> Cancels the response currently being generated, if any. </summary>
    public virtual Task CancelResponseAsync(CancellationToken cancellationToken = default)
        => SendCommandAsync(BuildEvent(RealtimeClientEventType.ResponseCancel), cancellationToken);

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

    private async Task SendAsync(BinaryData data, WebSocketMessageType messageType, CancellationToken cancellationToken)
    {
        ThrowIfDisposed();
        byte[] bytes = data.ToArray();
        await _sendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await _webSocket.SendAsync(new ArraySegment<byte>(bytes), messageType, true, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _sendSemaphore.Release();
        }
    }

    /// <summary> Receives text and binary messages from the voice agent. </summary>
    public virtual async IAsyncEnumerable<VoiceAgentSessionMessage> ReceiveUpdatesAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        if (Interlocked.Exchange(ref _receiveStarted, 1) != 0)
        {
            throw new InvalidOperationException("Only one receive operation may be active at a time.");
        }

        byte[] buffer = ArrayPool<byte>.Shared.Rent(16 * 1024);
        try
        {
            while (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseSent)
            {
                using MemoryStream message = new MemoryStream();
                WebSocketReceiveResult result;
                do
                {
                    result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        if (_webSocket.State == WebSocketState.CloseReceived)
                        {
                            await _webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Close acknowledged", cancellationToken).ConfigureAwait(false);
                        }
                        yield break;
                    }
                    message.Write(buffer, 0, result.Count);
                }
                while (!result.EndOfMessage);

                message.Position = 0;
                BinaryData data = BinaryData.FromStream(message);
                _parentClient?.RaiseOnReceivingCommand(this, data);
                yield return new VoiceAgentSessionMessage(result.MessageType, data);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
            Interlocked.Exchange(ref _receiveStarted, 0);
        }
    }

    /// <summary> Closes the WebSocket session gracefully. </summary>
    public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseReceived)
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client initiated close", cancellationToken).ConfigureAwait(false);
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        _disposed = true;
        _webSocket.Dispose();
        _sendSemaphore.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
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

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(VoiceAgentSession));
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
}
