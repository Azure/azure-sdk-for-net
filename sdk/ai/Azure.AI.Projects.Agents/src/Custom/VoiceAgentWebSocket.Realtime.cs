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
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
public partial class VoiceAgentWebSocket
{
    private static readonly IReadOnlyDictionary<string, object> s_tokenContext = new Dictionary<string, object>
    {
        [GetTokenOptions.ScopesPropertyName] = new string[] { "https://ai.azure.com/.default" },
        [GetTokenOptions.AuthorizationUrlPropertyName] = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize"
    };

    private readonly AuthenticationTokenProvider _tokenProvider;

    internal VoiceAgentWebSocket(ClientPipeline pipeline, Uri endpoint, string apiVersion, AuthenticationTokenProvider tokenProvider)
        : this(pipeline, endpoint, apiVersion)
    {
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

            await webSocket.ConnectAsync(CreateWebSocketUri(agentName, options), cancellationToken).ConfigureAwait(false);
            return new VoiceAgentSession(webSocket);
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
    private readonly SemaphoreSlim _sendSemaphore = new SemaphoreSlim(1, 1);
    private int _receiveStarted;
    private bool _disposed;

    internal VoiceAgentSession(WebSocket webSocket)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
    }

    /// <summary> Gets the current WebSocket connection state. </summary>
    public WebSocketState ConnectionState => _webSocket.State;

    /// <summary> Gets whether the session is connected. </summary>
    public bool IsConnected => _webSocket.State == WebSocketState.Open;

    /// <summary> Sends a JSON command to the voice agent. </summary>
    public virtual Task SendCommandAsync(BinaryData command, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(command, nameof(command));
        return SendAsync(command, WebSocketMessageType.Text, cancellationToken);
    }

    /// <summary> Sends a binary frame to the voice agent. </summary>
    public virtual Task SendBinaryAsync(BinaryData data, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(data, nameof(data));
        return SendAsync(data, WebSocketMessageType.Binary, cancellationToken);
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
                yield return new VoiceAgentSessionMessage(result.MessageType, BinaryData.FromStream(message));
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
    internal VoiceAgentSessionMessage(WebSocketMessageType messageType, BinaryData data)
    {
        MessageType = messageType;
        Data = data;
    }

    /// <summary> Gets the WebSocket message type. </summary>
    public WebSocketMessageType MessageType { get; }

    /// <summary> Gets the complete message payload. </summary>
    public BinaryData Data { get; }
}