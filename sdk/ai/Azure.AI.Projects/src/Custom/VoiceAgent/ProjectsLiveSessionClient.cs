// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects;

#pragma warning disable AZC0015 // WebSocket commands, event streams, and disposal do not have HTTP responses.

/// <summary> An owned WebSocket session using the native Live protocol, independent of Realtime. </summary>
[Experimental("AAIP001")]
public class ProjectsLiveSessionClient : IDisposable, IAsyncDisposable
{
    private const int MaximumMessageBytes = 16 * 1024 * 1024;
    private readonly WebSocket _socket;
    private readonly SemaphoreSlim _sendLock = new(1, 1);
    private readonly SemaphoreSlim _receiveLock = new(1, 1);
    private readonly SemaphoreSlim _closeLock = new(1, 1);
    private readonly CancellationTokenSource _lifetime = new();
    private readonly Queue<(LiveServerEvent Event, int Bytes)> _deferredEvents = new();
    private LiveServerEvent _startupEvent;
    private volatile bool _closeRequested;
    private int _disposed;
    private int _enumerationActive;
    private int _deferredBytes;

    /// <summary> Initializes a new instance for mocking. </summary>
    protected ProjectsLiveSessionClient()
    {
    }

    internal ProjectsLiveSessionClient(WebSocket socket)
    {
        _socket = socket;
    }

    /// <summary> The native startup acknowledgment, including the negotiated session and optional Foundry conversation ID. </summary>
    public LiveServerEventLiveSessionStarted SessionStarted { get; private set; }

    /// <summary> The native terminal event, including final usage and closure reason. Null means finalization has not been confirmed. </summary>
    public LiveServerEventLiveSessionClosed SessionClosed { get; private set; }

    /// <summary> The state of the underlying WebSocket. </summary>
    public WebSocketState State => _socket?.State ?? WebSocketState.None;

    internal async Task InitializeAsync(CancellationToken cancellationToken)
    {
        BinaryData data = await ReceiveMessageAsync(cancellationToken).ConfigureAwait(false);
        if (data == null)
        {
            throw new InvalidOperationException("The Live connection closed before session startup completed.");
        }
        using JsonDocument document = JsonDocument.Parse(data);
        string type = document.RootElement.GetProperty("type").GetString();
        if (type == "error")
        {
            LiveServerEventLiveErrorEvent error = ModelReaderWriter.Read<LiveServerEventLiveErrorEvent>(
                data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
            if (error?.Error == null)
            {
                throw new InvalidDataException("The Live service returned a startup error without error details.");
            }
            throw new InvalidOperationException($"The Live service rejected session startup ({error.Error.Type}, " +
                $"code={error.Error.Code ?? "<not supplied>"}): {error.Error.Message}");
        }
        if (type != "session.started")
        {
            throw new InvalidDataException("Expected session.started as the first Live server event.");
        }
        SessionStarted = ModelReaderWriter.Read<LiveServerEventLiveSessionStarted>(data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        _startupEvent = SessionStarted;
    }

    /// <summary> Sends a generated native Live client event. Concurrent sends are serialized. </summary>
    /// <param name="clientEvent"> The native event to send. </param>
    /// <param name="cancellationToken"> Cancels the send. </param>
#pragma warning disable AZC0004 // Native WebSocket operations are asynchronous.
    public virtual Task SendEventAsync(LiveClientEvent clientEvent, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(clientEvent, nameof(clientEvent));
        return SendCommandAsync(ModelReaderWriter.Write(clientEvent, new ModelReaderWriterOptions("W"), AzureAIProjectsAgentsContext.Default), cancellationToken);
    }

    /// <summary> Sends a raw audio chunk using the format negotiated at startup, without a WAV or other container header. </summary>
    /// <param name="audio"> Raw audio bytes. PCM chunks must contain complete 16-bit samples. </param>
    /// <param name="cancellationToken"> Cancels the send. </param>
    public virtual Task SendInputAudioAsync(BinaryData audio, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        int length = audio.ToMemory().Length;
        if (length == 0 || (SessionStarted?.Session.Audio?.Format is LiveSessionAudioFormatPCMParam && length % 2 != 0))
        {
            throw new ArgumentException("Audio must be nonempty and contain complete samples in the negotiated format.", nameof(audio));
        }
        return SendEventAsync(new LiveClientEventLiveInputAudioAppendEvent(Convert.ToBase64String(audio.ToArray())), cancellationToken);
    }

    /// <summary> Streams raw audio without closing or committing a Realtime-style input buffer. The caller controls pacing. </summary>
    /// <param name="audio"> A readable stream in the startup-selected audio format. The stream remains owned by the caller. </param>
    /// <param name="cancellationToken"> Cancels reading and sending. </param>
    public virtual async Task SendInputAudioAsync(Stream audio, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        ThrowIfDisposed();
        using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _lifetime.Token);
        byte[] buffer = ArrayPool<byte>.Shared.Rent(9600);
        try
        {
            int pending = 0;
            bool pcm = SessionStarted?.Session.Audio?.Format is LiveSessionAudioFormatPCMParam;
            while (true)
            {
                int read = await audio.ReadAsync(buffer, pending, 9600 - pending, linked.Token).ConfigureAwait(false);
                if (read == 0)
                {
                    if (pending != 0)
                    {
                        throw new InvalidDataException("The PCM audio stream ended in the middle of a 16-bit sample.");
                    }
                    break;
                }
                int available = pending + read;
                int send = pcm ? available - available % 2 : available;
                if (send > 0)
                {
                    await SendInputAudioAsync(BinaryData.FromBytes(buffer.AsMemory(0, send)), linked.Token).ConfigureAwait(false);
                }
                pending = available - send;
                if (pending != 0)
                {
                    buffer[0] = buffer[send];
                }
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    /// <summary> Sends a JSON Live command, including protocol extensions not yet modeled by the SDK. </summary>
    /// <param name="command"> A UTF-8 JSON object with a native Live <c>type</c>. </param>
    /// <param name="cancellationToken"> Cancels the send. </param>
    public virtual async Task SendCommandAsync(BinaryData command, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(command, nameof(command));
        ThrowIfDisposed();
        if (command.ToMemory().Length > MaximumMessageBytes)
        {
            throw new ArgumentException("A Live command cannot exceed 16 MiB.", nameof(command));
        }
        string eventType;
        using (JsonDocument document = JsonDocument.Parse(command))
        {
            if (document.RootElement.ValueKind != JsonValueKind.Object ||
                !document.RootElement.TryGetProperty("type", out JsonElement type) ||
                type.ValueKind != JsonValueKind.String || string.IsNullOrEmpty(type.GetString()))
            {
                throw new ArgumentException("A Live command must contain a nonempty string type.", nameof(command));
            }
            eventType = type.GetString();
        }
        await SendCommandCoreAsync(command, eventType, false, cancellationToken).ConfigureAwait(false);
    }

    private async Task SendCommandCoreAsync(BinaryData command, string eventType, bool closing, CancellationToken cancellationToken)
    {
        using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _lifetime.Token);
        await _sendLock.WaitAsync(linked.Token).ConfigureAwait(false);
        try
        {
            ThrowIfDisposed();
            if (closing && (_closeRequested || SessionClosed != null || _socket.State != WebSocketState.Open))
            {
                return;
            }
            if (_socket.State != WebSocketState.Open || _closeRequested || SessionClosed != null)
            {
                throw new InvalidOperationException("The Live session is not open.");
            }
            await _socket.SendAsync(new ArraySegment<byte>(command.ToArray()), WebSocketMessageType.Text, true, linked.Token).ConfigureAwait(false);
            if (eventType == "session.close")
            {
                _closeRequested = true;
            }
        }
        finally
        {
            _sendLock.Release();
        }
    }

    /// <summary> Receives native Live events, including the initial startup acknowledgment. Only one enumeration may receive at a time. </summary>
    /// <param name="cancellationToken"> Cancels receiving. Disposing the session also cancels pending receives. </param>
    /// <returns> Generated native Live events. Service error events are returned for the caller to handle. </returns>
    public virtual async IAsyncEnumerable<LiveServerEvent> ReceiveEventsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        cancellationToken.ThrowIfCancellationRequested();
        if (Interlocked.CompareExchange(ref _enumerationActive, 1, 0) != 0)
        {
            throw new InvalidOperationException("Only one Live event receiver may be active at a time.");
        }
        try
        {
            using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _lifetime.Token);
            if (_startupEvent != null)
            {
                LiveServerEvent started = _startupEvent;
                _startupEvent = null;
                yield return started;
            }
            while (true)
            {
                LiveServerEvent serverEvent;
                await _receiveLock.WaitAsync(linked.Token).ConfigureAwait(false);
                try
                {
                    ThrowIfDisposed();
                    if (_deferredEvents.Count > 0)
                    {
                        (LiveServerEvent Event, int Bytes) deferred = _deferredEvents.Dequeue();
                        serverEvent = deferred.Event;
                        _deferredBytes -= deferred.Bytes;
                    }
                    else
                    {
                        if (SessionClosed != null || _socket.State is not (WebSocketState.Open or WebSocketState.CloseSent))
                        {
                            yield break;
                        }
                        BinaryData data = await ReceiveMessageAsync(linked.Token).ConfigureAwait(false);
                        if (data == null)
                        {
                            yield break;
                        }
                        serverEvent = ReadEvent(data);
                    }
                }
                finally
                {
                    _receiveLock.Release();
                }
                yield return serverEvent;
            }
        }
        finally
        {
            Volatile.Write(ref _enumerationActive, 0);
        }
    }

    /// <summary> Requests native session closure and completes the WebSocket closing handshake. May be called from the event-consumer loop; events read during shutdown remain available to that receiver. </summary>
    /// <param name="cancellationToken"> Cancels shutdown. The default shutdown budget is ten seconds. </param>
    public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        cancellationToken.ThrowIfCancellationRequested();
        using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _lifetime.Token);
        timeout.CancelAfter(TimeSpan.FromSeconds(10));
        await _closeLock.WaitAsync(timeout.Token).ConfigureAwait(false);
        try
        {
            await SendCommandCoreAsync(BinaryData.FromString("""{"type":"session.close"}"""), "session.close", true, timeout.Token).ConfigureAwait(false);
            await _receiveLock.WaitAsync(timeout.Token).ConfigureAwait(false);
            try
            {
                while (SessionClosed == null && _socket.State == WebSocketState.Open)
                {
                    BinaryData data = await ReceiveMessageAsync(timeout.Token).ConfigureAwait(false);
                    if (data == null)
                    {
                        break;
                    }
                    ReadShutdownEvent(data);
                }
                if (SessionClosed == null)
                {
                    throw new InvalidDataException("The Live connection closed without confirming native session finalization.");
                }
                await _sendLock.WaitAsync(timeout.Token).ConfigureAwait(false);
                try
                {
                    if (_socket.State == WebSocketState.Open)
                    {
                        await _socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, timeout.Token).ConfigureAwait(false);
                    }
                }
                finally
                {
                    _sendLock.Release();
                }
                while (_socket.State is WebSocketState.Open or WebSocketState.CloseSent)
                {
                    BinaryData data = await ReceiveMessageAsync(timeout.Token).ConfigureAwait(false);
                    if (data == null)
                    {
                        break;
                    }
                    ReadShutdownEvent(data);
                }
            }
            finally
            {
                _receiveLock.Release();
            }
        }
        finally
        {
            _closeLock.Release();
        }
    }
#pragma warning restore AZC0004

    private void ReadShutdownEvent(BinaryData data)
    {
        LiveServerEvent serverEvent = ReadEvent(data);
        if (Volatile.Read(ref _enumerationActive) != 0)
        {
            int bytes = data.ToMemory().Length;
            if (_deferredBytes + bytes > MaximumMessageBytes)
            {
                throw new InvalidDataException("Live shutdown events exceeded the 16 MiB receive buffer limit.");
            }
            // Shutdown may own the socket while an exclusive event consumer is suspended at a yield.
            _deferredEvents.Enqueue((serverEvent, bytes));
            _deferredBytes += bytes;
        }
    }

    private LiveServerEvent ReadEvent(BinaryData data)
    {
        LiveServerEvent serverEvent = ModelReaderWriter.Read<LiveServerEvent>(data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        if (serverEvent is LiveServerEventLiveSessionClosed closed)
        {
            SessionClosed = closed;
            _closeRequested = true;
        }
        return serverEvent;
    }

    private async Task<BinaryData> ReceiveMessageAsync(CancellationToken cancellationToken)
    {
        using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _lifetime.Token);
        byte[] buffer = ArrayPool<byte>.Shared.Rent(8192);
        try
        {
            using MemoryStream message = new();
            while (true)
            {
                WebSocketReceiveResult received = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), linked.Token).ConfigureAwait(false);
                if (received.MessageType == WebSocketMessageType.Close)
                {
                    if (_socket.State == WebSocketState.CloseReceived)
                    {
                        await _sendLock.WaitAsync(linked.Token).ConfigureAwait(false);
                        try
                        {
                            await _socket.CloseOutputAsync(received.CloseStatus ?? WebSocketCloseStatus.NormalClosure, null, linked.Token).ConfigureAwait(false);
                        }
                        finally
                        {
                            _sendLock.Release();
                        }
                    }
                    if (received.CloseStatus is not null and not WebSocketCloseStatus.NormalClosure and not WebSocketCloseStatus.EndpointUnavailable)
                    {
                        throw new WebSocketException("The Live service closed the connection with status " + (int)received.CloseStatus.Value + ".");
                    }
                    return null;
                }
                if (received.MessageType != WebSocketMessageType.Text)
                {
                    throw new InvalidDataException("Native Live events must be JSON text messages.");
                }
                if (message.Length + received.Count > MaximumMessageBytes)
                {
                    throw new InvalidDataException("A Live event exceeded the 16 MiB message limit.");
                }
                message.Write(buffer, 0, received.Count);
                if (received.EndOfMessage)
                {
                    return BinaryData.FromBytes(message.ToArray());
                }
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private void ThrowIfDisposed()
    {
        if (Volatile.Read(ref _disposed) != 0)
        {
            throw new ObjectDisposedException(nameof(ProjectsLiveSessionClient));
        }
    }

    /// <summary> Immediately releases the connection and cancels pending work. Use <see cref="CloseAsync"/> for graceful shutdown. </summary>
    public virtual void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            try
            {
                _lifetime.Cancel();
            }
            finally
            {
                _socket?.Dispose();
                _lifetime.Dispose();
            }
        }
        GC.SuppressFinalize(this);
    }

    /// <summary> Gracefully closes the session and releases the connection. </summary>
    public virtual async ValueTask DisposeAsync()
    {
        if (Volatile.Read(ref _disposed) != 0)
        {
            return;
        }
        try
        {
            if (_socket?.State is WebSocketState.Open or WebSocketState.CloseSent or WebSocketState.CloseReceived)
            {
                await CloseAsync().ConfigureAwait(false);
            }
        }
        finally
        {
            Dispose();
        }
    }
}
