// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The WebPubSubService PubSub client.
    /// </summary>
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "WebPubSub clients are Websocket based and don't use ClientOptions functionality")]
    [SuppressMessage("Usage", "AZC0004:DO provide both asynchronous and synchronous variants for all service methods.", Justification = "Synchronous methods doesn't make sense in the scenario of WebPubSub client")]
    [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "WebPubSubClient is not a HTTP-based client.")]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "We don't want user to use client within a using block")]
    public class WebPubSubClient
    {
        private const string ErrorNameDuplicate = "Duplicate";
        private const string RecoverConnectionIdQuery = "awps_connection_id";
        private const string RecoverReconnectionTokenQuery = "awps_reconnection_token";

        private static readonly UnboundedChannelOptions s_unboundedChannelOptions = new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = true,
        };

        private readonly WebPubSubClientCredential _webPubSubClientCredential;
        private readonly WebPubSubClientOptions _options;
        private readonly WebPubSubProtocol _protocol;
        private readonly SequenceId _sequenceId = new SequenceId();
        private readonly ConcurrentDictionary<string, WebPubSubGroup> _groups = new();
        private readonly WebPubSubRetryPolicy _reconnectRetryPolicy;
        private readonly WebPubSubRetryPolicy _messageRetryPolicy;
        private readonly ClientState _clientState;
        private readonly Channel<GroupDataMessage> _groupDataChannel = Channel.CreateUnbounded<GroupDataMessage>(s_unboundedChannelOptions);
        private readonly Channel<ServerDataMessage> _serverDataChannel = Channel.CreateUnbounded<ServerDataMessage>(s_unboundedChannelOptions);
        private readonly Task _processingServerDataMessageTask;
        private readonly Task _processingGroupDataMessageTask;

        private readonly object _ackIdLock = new();
        private readonly object _stopLock = new();
#pragma warning disable CA2213 // Disposable fields should be disposed
        private readonly SemaphoreSlim _connectionLock = new SemaphoreSlim(1);
#pragma warning restore CA2213 // Disposable fields should be disposed
        private long _nextAckId = 0;

        // Fields per start stop
        private Task _stoppingTask;
#pragma warning disable CA2213 // Disposable fields should be disposed
        private volatile CancellationTokenSource _stoppedCts = new();
#pragma warning restore CA2213 // Disposable fields should be disposed

        // Fields per connection-id
        private Uri _clientAccessUri;
        private string _connectionId;
        private string _reconnectionToken;
        private bool _isInitialConnected;
        private DisconnectedMessage _latestDisconnectedMessage;
        private ConcurrentDictionary<long, AckEntity> _ackCache = new();

        // Fields per websocket
        private Task _receiveTask;
#pragma warning disable CA2213 // Disposable fields should be disposed
        private volatile IWebSocketClient _client;
#pragma warning restore CA2213 // Disposable fields should be disposed

        private volatile bool _disposed;

        /// <summary>
        /// The connection ID of the client. The ID is assigned when the client connects.
        /// </summary>
        public string ConnectionId => _connectionId;

        // Some exposed properties for testing
        internal IWebSocketClientFactory WebSocketClientFactory { get; set; }
        internal TimeSpan RecoverDelay { get; set; } = TimeSpan.FromSeconds(1);
        internal long CurrentSequenceId => _sequenceId.Current;

        /// <summary>
        /// Initializes a Web PubSub client.
        /// </summary>
        /// <param name="clientAccessUri">The uri to connect to the service.</param>
        public WebPubSubClient(Uri clientAccessUri) : this(clientAccessUri, null)
        {
        }

        /// <summary>
        /// Initializes a Web PubSub client.
        /// </summary>
        /// <param name="clientAccessUri">The uri to connect to the service.</param>
        /// <param name="options">A option for the client.</param>
        public WebPubSubClient(Uri clientAccessUri, WebPubSubClientOptions options) : this(new WebPubSubClientCredential(clientAccessUri), options)
        {
        }

        /// <summary>
        /// Initializes a Web PubSub client.
        /// </summary>
        /// <param name="credential">A uri provider that will be called to return the uri for each connecting or reconnecting.</param>
        /// <param name="options">A option for the client.</param>
        public WebPubSubClient(WebPubSubClientCredential credential, WebPubSubClientOptions options = null)
        {
            _webPubSubClientCredential = credential ?? throw new ArgumentNullException(nameof(credential));

            _options = options ?? new WebPubSubClientOptions();
            _protocol = _options.Protocol ?? throw new ArgumentNullException(nameof(options));
            WebSocketClientFactory = new WebSocketClientFactory();

            _clientState = new ClientState();

            _reconnectRetryPolicy = new WebPubSubRetryPolicy(_options.ReconnectRetryOptions);
            _messageRetryPolicy = new WebPubSubRetryPolicy(_options.MessageRetryOptions);

            // Process message
            _processingServerDataMessageTask = StartServerProcessingDataMessage();
            _processingGroupDataMessageTask = StartGroupProcessingDataMessage();
        }

        /// <summary>
        /// Constructor for mock.
        /// </summary>
        protected WebPubSubClient()
        {
        }

        /// <summary>
        /// Start connecting to the service.
        /// </summary>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns></returns>
        public virtual async Task StartAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            if (_stoppedCts.IsCancellationRequested)
            {
                throw new InvalidOperationException("Can not start a client during stopping");
            }

            await _connectionLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                lock (_stopLock)
                {
                    _stoppingTask = null;
                }

                if (_clientState.CurrentState != WebPubSubClientState.Stopped)
                {
                    throw new InvalidOperationException("Client can be only started when the state is Stopped");
                }

                try
                {
                    await StartAsyncCore(cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                    _clientState.ChangeState(WebPubSubClientState.Stopped);
                    throw;
                }
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        private async Task StartAsyncByReconnection(CancellationToken cancellationToken)
        {
            if (_stoppedCts.IsCancellationRequested)
            {
                throw new InvalidOperationException("Can not start a client during stopping");
            }

            await _connectionLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_clientState.CurrentState != WebPubSubClientState.Disconnected)
                {
                    throw new InvalidOperationException("Client restart should happen only when the state is Disconnected");
                }

                try
                {
                    await StartAsyncCore(cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                    _clientState.ChangeState(WebPubSubClientState.Disconnected);
                    throw;
                }
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        private async Task StartAsyncCore(CancellationToken cancellationToken)
        {
            _clientState.ChangeState(WebPubSubClientState.Connecting);
            WebPubSubClientEventSource.Log.ClientStarting();

            // Reset before new connection.
            _sequenceId.Reset();
            _isInitialConnected = false;
            _latestDisconnectedMessage = null;
            _reconnectionToken = null;
            _connectionId = null;
            _ackCache.Clear();

            _clientAccessUri = await _webPubSubClientCredential.GetClientAccessUriAsync(cancellationToken).ConfigureAwait(false);
            await ConnectAsync(_clientAccessUri, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Stop the client.
        /// </summary>
        /// <returns></returns>
        public virtual Task StopAsync()
        {
            ThrowIfDisposed();

            lock (_stopLock)
            {
                if (_stoppingTask == null)
                {
                    _stoppingTask = StopAsyncCore();
                }
                return _stoppingTask;
            }
        }

        private async Task StopAsyncCore()
        {
            // We will wait for StartAsync
            // After that, there will be two cases:
            //   1. Start success and ReceiveTask is set, then we just wait for the ReceiveTask
            //   2. Start failed. And in this case, another start will be blocked.
            await _connectionLock.WaitAsync().ConfigureAwait(false);
            try
            {
                try
                {
                    // Try close websocket gracefully first
                    await (_client?.StopAsync(CancellationToken.None) ?? Task.CompletedTask).ConfigureAwait(false);
                }
                catch { }

                try
                {
                    // Stop new StartAsync during this time and stop all related receiving tasks in running.
                    _stoppedCts.Cancel();
                    await (_receiveTask ?? Task.CompletedTask).ConfigureAwait(false);
                }
                catch { }
            }
            finally
            {
                // After stop, we can set a new CancellationToken and wait for another start.
                _stoppedCts = new CancellationTokenSource();
                _connectionLock.Release();
            }
        }

        /// <summary>
        /// Stop and close the client to the service
        /// </summary>
        /// <returns></returns>
#pragma warning disable AZC0003 // DO make service methods virtual.
        public async ValueTask DisposeAsync()
#pragma warning restore AZC0003 // DO make service methods virtual.
        {
            // Perform async cleanup.
            await DisposeAsyncCore().ConfigureAwait(false);

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
            // Suppress finalization.
            GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        }

        /// <summary>
        /// Stop and close the client to the service
        /// </summary>
        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            try
            {
                await StopAsyncCore().ConfigureAwait(false);
            }
            catch
            {
            }

            _serverDataChannel.Writer.TryComplete();
            _groupDataChannel.Writer.TryComplete();

            _stoppedCts.Cancel();
            _client?.Dispose();
            _stoppedCts.Dispose();
            _connectionLock.Dispose();
        }

        /// <summary>
        /// Join the target group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="ackId">An optional ack id. It's generated by SDK if not assigned.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation.</returns>
        public virtual async Task<WebPubSubResult> JoinGroupAsync(string group, long? ackId = null, CancellationToken cancellationToken = default)
        {
            Utils.AssertNotNegtive(ackId);
            ThrowIfDisposed();
            var groupEntity = _groups.GetOrAdd(group, n => new WebPubSubGroup(n));
            var ack = await OperationExecuteWithRetry(token => JoinGroupAttemptAsync(group, ackId, token), cancellationToken).ConfigureAwait(false);
            groupEntity.Joined = true;
            return ack;
        }

        internal virtual async Task<WebPubSubResult> JoinGroupAttemptAsync(string group, long? ackId = null, CancellationToken cancellationToken = default)
        {
            return await SendMessageWithAckAsync(id =>
            {
                return new JoinGroupMessage(group, id);
            }, ackId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Leave the target group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="ackId">An optional ack id. It's generated by SDK if not assigned.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation</returns>
        public virtual async Task<WebPubSubResult> LeaveGroupAsync(string group, long? ackId = null, CancellationToken cancellationToken = default)
        {
            Utils.AssertNotNegtive(ackId);
            ThrowIfDisposed();
            var groupEntity = _groups.GetOrAdd(group, n => new WebPubSubGroup(n));
            var ack = await OperationExecuteWithRetry(token => LeaveGroupAttemptAsync(group, ackId, token), cancellationToken).ConfigureAwait(false);
            groupEntity.Joined = false;
            return ack;
        }

        internal virtual async Task<WebPubSubResult> LeaveGroupAttemptAsync(string group, long? ackId = null, CancellationToken cancellationToken = default)
        {
            return await SendMessageWithAckAsync(id =>
            {
                return new LeaveGroupMessage(group, id);
            }, ackId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Publish data to group and wait for the ack.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="content">The data content.</param>
        /// <param name="dataType">The data type.</param>
        /// <param name="noEcho">If set to true, this message is not echoed back to the same connection. If not set, the default value is false.</param>
        /// <param name="fireAndForget">If set to true, the service won't return ack for this message. The return value will be Task of null </param>
        /// <param name="ackId">The ack-id for the operation. The message with the same ack-id is treated as the same message. Leave it omitted to generate by library.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation</returns>
        public virtual async Task<WebPubSubResult> SendToGroupAsync(string group, BinaryData content, WebPubSubDataType dataType, long? ackId = null, bool noEcho = false, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            Utils.AssertNotNegtive(ackId);
            ThrowIfDisposed();
            return await OperationExecuteWithRetry(token => SendToGroupAttemptAsync(group, content, dataType, ackId, noEcho, fireAndForget, token), cancellationToken).ConfigureAwait(false);
        }

        internal virtual async Task<WebPubSubResult> SendToGroupAttemptAsync(string group, BinaryData content, WebPubSubDataType dataType, long? ackId = null, bool noEcho = false, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            if (fireAndForget)
            {
                var message = new SendToGroupMessage(group, content, dataType, null, noEcho);
                await SendMessageWithoutAckAsync(message, cancellationToken).ConfigureAwait(false);
                return new WebPubSubResult();
            }

            return await SendMessageWithAckAsync(id =>
            {
                return new SendToGroupMessage(group, content, dataType, id, noEcho);
            }, ackId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Send custom event and wait for the ack.
        /// </summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="content">The data content.</param>
        /// <param name="dataType">The data type.</param>
        /// <param name="ackId">The ack-id for the operation. The message with the same ack-id is treated as the same message. Leave it omitted to generate by library.</param>
        /// <param name="fireAndForget">If set to true, the service won't return ack for this message. The return value will be Task of null </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation</returns>
        public virtual async Task<WebPubSubResult> SendEventAsync(string eventName, BinaryData content, WebPubSubDataType dataType, long? ackId = null, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            Utils.AssertNotNegtive(ackId);
            ThrowIfDisposed();
            return await OperationExecuteWithRetry(token => SendEventAttemptAsync(eventName, content, dataType, ackId, fireAndForget, token), cancellationToken).ConfigureAwait(false);
        }

        internal virtual async Task<WebPubSubResult> SendEventAttemptAsync(string eventName, BinaryData content, WebPubSubDataType dataType, long? ackId = null, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            if (fireAndForget)
            {
                var message = new SendEventMessage(eventName, content, dataType, null);
                await SendMessageWithoutAckAsync(message, cancellationToken).ConfigureAwait(false);
                return new WebPubSubResult();
            }

            return await SendMessageWithAckAsync(id =>
            {
                return new SendEventMessage(eventName, content, dataType, id);
            }, ackId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// An event triggered when the connection is connected
        /// </summary>
        public event Func<WebPubSubConnectedEventArgs, Task> Connected;

        /// <summary>
        /// An event triggered when the connection is disconnected
        /// </summary>
        public event Func<WebPubSubDisconnectedEventArgs, Task> Disconnected;

        /// <summary>
        /// An event triggered when the connection is stopped
        /// </summary>
        public event Func<WebPubSubStoppedEventArgs, Task> Stopped;

        /// <summary>
        /// A event triggered when received server data messages.
        /// </summary>
        public event Func<WebPubSubServerMessageEventArgs, Task> ServerMessageReceived;

        /// <summary>
        /// A event triggered when received group data messages.
        /// </summary>
        public event Func<WebPubSubGroupMessageEventArgs, Task> GroupMessageReceived;

        /// <summary>
        /// A event triggered when rejoin group failed in reconnection.
        /// </summary>
        public event Func<WebPubSubRejoinGroupFailedEventArgs, Task> RejoinGroupFailed;

        // This method is in a semaphore, DON'T make it endless.
        private async Task ConnectAsync(Uri uri, CancellationToken token)
        {
            var client = WebSocketClientFactory.CreateWebSocketClient(uri, _protocol.Name);

            try
            {
                await client.ConnectAsync(token).ConfigureAwait(false);
            }
            catch
            {
                client.Dispose();
                throw;
            }

            var oldClient = _client;
            _client = client;
            oldClient?.Dispose();

            _clientState.ChangeState(WebPubSubClientState.Connected);

            // Force to run in a thread pool to avoid long sync codes make it hung
            _receiveTask = Task.Run(() => ListenLoop(client, _stoppedCts.Token), default);
        }

        private async Task ListenLoop(IWebSocketClient client, CancellationToken token)
        {
            var sequenceAckTask = Task.CompletedTask;
            var sequenceAckCts = new CancellationTokenSource();
            if (_protocol.IsReliable)
            {
                sequenceAckTask = SequenceAckLoop(sequenceAckCts.Token);
            }

            using var buffer = new MemoryBufferWriter();
            WebSocketCloseStatus? closeStatus = null;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var result = await client.ReceiveOneFrameAsync(token).ConfigureAwait(false);
                    if (result.IsClosed)
                    {
                        closeStatus = result.CloseStatus;
                        break;
                    }
                    if (result.Payload.Length > 0)
                    {
                        try
                        {
                            foreach (var message in _protocol.ParseMessage(result.Payload))
                            {
                                await HandleMessageAsync(message, token).ConfigureAwait(false);
                            }
                        }
                        catch (Exception ex)
                        {
                            WebPubSubClientEventSource.Log.FailedToProcessMessage(ex.Message);
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToReceiveBytes(ex.Message);
            }
            finally
            {
                try
                {
                    WebPubSubClientEventSource.Log.WebSocketClosed();
                    sequenceAckCts.Cancel();
                    sequenceAckCts.Dispose();
                    await sequenceAckTask.ConfigureAwait(false);
                }
                catch
                {
                }

                await HandleConnectionClose(closeStatus, token).ConfigureAwait(false);
            }
        }

        internal virtual async Task SendCoreAsync(ReadOnlyMemory<byte> buffer, WebPubSubProtocolMessageType webPubSubProtocolMessageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            var messageType = webPubSubProtocolMessageType == WebPubSubProtocolMessageType.Text ? WebSocketMessageType.Text : WebSocketMessageType.Binary;
            await _client.SendAsync(buffer, messageType, endOfMessage, cancellationToken).ConfigureAwait(false);
        }

        internal async Task SendMessageWithoutAckAsync(WebPubSubMessage message, CancellationToken cancellationToken)
        {
            try
            {
                await SendCoreAsync(_protocol.GetMessageBytes(message), _protocol.WebSocketMessageType, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new SendMessageFailedException("Failed to send message.", null, ex);
            }
        }

        internal async Task<WebPubSubResult> SendMessageWithAckAsync(Func<long, WebPubSubMessage> GetMessage, long? ackId, CancellationToken token)
        {
            var id = ackId ?? NextAckId();
            var entity = CreateAckEntity(id);
            var message = GetMessage(id);
            try
            {
                await SendCoreAsync(_protocol.GetMessageBytes(message), _protocol.WebSocketMessageType, true, token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (_ackCache.TryRemove(id, out var e))
                {
                    e.SetCancelled();
                }
                throw new SendMessageFailedException("Failed to send message.", id, ex);
            }

            try
            {
                return await entity.Task.AwaitWithCancellation<WebPubSubResult>(token);
            }
            catch (OperationCanceledException ex)
            {
                throw new SendMessageFailedException("Cancelled by CancellationToken", id, ex);
            }
        }

        private Task HandleConnectionCloseAndNoRecovery(DisconnectedMessage disconnectedMessage, CancellationToken token)
        {
            _clientState.ChangeState(WebPubSubClientState.Disconnected);

            SafeInvokeDisconnectedAsync(new WebPubSubDisconnectedEventArgs(_connectionId, disconnectedMessage)).FireAndForget();

            if (_options.AutoReconnect)
            {
                return AutoReconnectAsync(token);
            }

            HandleClientStopped();
            return Task.CompletedTask;
        }

        internal async void HandleConnectionConnected(ConnectedMessage connectedMessage, CancellationToken token)
        {
            if (_options.AutoRejoinGroups)
            {
                foreach (var pair in _groups)
                {
                    var name = pair.Key;
                    var g = pair.Value;
                    if (g.Joined)
                    {
                        try
                        {
                            await JoinGroupAttemptAsync(name, cancellationToken: token).ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            SafeInvokeRejoinGroupFailedAsync(new WebPubSubRejoinGroupFailedEventArgs(name, ex, token)).FireAndForget();
                        }
                    }
                }
            }
            SafeInvokeConnectedAsync(new WebPubSubConnectedEventArgs(connectedMessage, token)).FireAndForget();
        }

        private void HandleClientStopped()
        {
            _clientState.ChangeState(WebPubSubClientState.Stopped);

            SafeInvokeStoppedAsync(new WebPubSubStoppedEventArgs(default)).FireAndForget();
        }

        private async Task SafeInvokeGroupMessageReceivedAsync(WebPubSubGroupMessageEventArgs eventArgs)
        {
            try
            {
                await (GroupMessageReceived?.Invoke(eventArgs) ?? Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToInvokeEvent(nameof(GroupMessageReceived), ex.Message);
            }
        }

        private async Task SafeInvokeServerMessageReceivedAsync(WebPubSubServerMessageEventArgs eventArgs)
        {
            try
            {
                await (ServerMessageReceived?.Invoke(eventArgs) ?? Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToInvokeEvent(nameof(ServerMessageReceived), ex.Message);
            }
        }

        private async Task SafeInvokeConnectedAsync(WebPubSubConnectedEventArgs eventArgs)
        {
            try
            {
                WebPubSubClientEventSource.Log.ConnectionConnected(_connectionId);
                await (Connected?.Invoke(eventArgs) ?? Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToInvokeEvent(nameof(Connected), ex.Message);
            }
        }

        private async Task SafeInvokeDisconnectedAsync(WebPubSubDisconnectedEventArgs eventArgs)
        {
            try
            {
                WebPubSubClientEventSource.Log.ConnectionDisconnected(_connectionId);
                await (Disconnected?.Invoke(eventArgs) ?? Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToInvokeEvent(nameof(Disconnected), ex.Message);
            }
        }

        private async Task SafeInvokeStoppedAsync(WebPubSubStoppedEventArgs eventArgs)
        {
            try
            {
                await (Stopped?.Invoke(eventArgs) ?? Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToInvokeEvent(nameof(Stopped), ex.Message);
            }
        }

        private async Task SafeInvokeRejoinGroupFailedAsync(WebPubSubRejoinGroupFailedEventArgs eventArgs)
        {
            try
            {
                await (RejoinGroupFailed?.Invoke(eventArgs) ?? Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WebPubSubClientEventSource.Log.FailedToInvokeEvent(nameof(RejoinGroupFailed), ex.Message);
            }
        }

        private async Task AutoReconnectAsync(CancellationToken token)
        {
            var isSuccess = false;
            var retryAttempt = 0;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        await StartAsyncByReconnection(token).ConfigureAwait(false);
                        isSuccess = true;
                        return;
                    }
                    catch (Exception ex)
                    {
                        WebPubSubClientEventSource.Log.FailedToReconnect(_connectionId, ex.Message);

                        retryAttempt++;
                        var delay = _reconnectRetryPolicy.NextRetryDelay(new RetryContext { RetryAttempt = retryAttempt });

                        if (delay == null)
                        {
                            return;
                        }

                        await Task.Delay(delay.Value, token).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                if (!isSuccess)
                {
                    HandleClientStopped();
                }
            }
        }

        private async Task HandleConnectionClose(WebSocketCloseStatus? closeStatus, CancellationToken token)
        {
            foreach (var entity in _ackCache)
            {
                if (_ackCache.TryRemove(entity.Key, out var value))
                {
                    value.SetException(new SendMessageFailedException("Connection is disconnected before receive ack from the service", entity.Value.AckId, string.Empty));
                }
            }

            if (closeStatus == WebSocketCloseStatus.PolicyViolation)
            {
                WebPubSubClientEventSource.Log.StopRecovery(_connectionId, $"The websocket close with status: {WebSocketCloseStatus.PolicyViolation}");
                await HandleConnectionCloseAndNoRecovery(_latestDisconnectedMessage, token).ConfigureAwait(false);
                return;
            }

            // Called StopAsync, don't recover or restart.
            if (token.IsCancellationRequested)
            {
                WebPubSubClientEventSource.Log.StopRecovery(_connectionId, "The client is stopped");
                await HandleConnectionCloseAndNoRecovery(_latestDisconnectedMessage, token).ConfigureAwait(false);
                return;
            }

            // Unrecoverable protocol
            if (!_protocol.IsReliable)
            {
                WebPubSubClientEventSource.Log.StopRecovery(_connectionId, "The protocol is not reliable, recovery is not applicable");
                await HandleConnectionCloseAndNoRecovery(_latestDisconnectedMessage, token).ConfigureAwait(false);
                return;
            }

            // Can't recovery
            if (!TryBuildRecoveryUri(out var uri))
            {
                WebPubSubClientEventSource.Log.StopRecovery(_connectionId, "Connection id or reconnection token is not availble");
                await HandleConnectionCloseAndNoRecovery(_latestDisconnectedMessage, token).ConfigureAwait(false);
                return;
            }

            // Totally timeout 30s as service will remove the connection if it's not recovered in 30s
            var recovered = false;
            _clientState.ChangeState(WebPubSubClientState.Recovering);
            var cts = new CancellationTokenSource(30 * 1000);
            var linkedTcs = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);
            try
            {
                while (!linkedTcs.IsCancellationRequested)
                {
                    try
                    {
                        await _connectionLock.WaitAsync(linkedTcs.Token).ConfigureAwait(false);
                        try
                        {
                            await ConnectAsync(uri, CancellationToken.None).ConfigureAwait(false);
                            recovered = true;
                            return;
                        }
                        finally
                        {
                            _connectionLock.Release();
                        }
                    }
                    catch (Exception ex)
                    {
                        WebPubSubClientEventSource.Log.FailedToRecoverConnection(_connectionId, ex.Message);
                        await Task.Delay(RecoverDelay, linkedTcs.Token).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                cts.Dispose();
                linkedTcs.Dispose();

                if (!recovered)
                {
                    WebPubSubClientEventSource.Log.StopRecovery(_connectionId, "Recovery attempts failed more than 30 seconds or the client is stopped");
                    await HandleConnectionCloseAndNoRecovery(_latestDisconnectedMessage, token).ConfigureAwait(false);
                }
            }
        }

        private Task HandleMessageAsync(WebPubSubMessage message, CancellationToken token)
        {
            switch (message)
            {
                case ConnectedMessage connectedMessage:
                    HandleConnectedMessage(connectedMessage);
                    break;
                case DisconnectedMessage disconnectedMessage:
                    HandleDisconnectedMessage(disconnectedMessage);
                    break;
                case AckMessage ackMessage:
                    HandleAckMessage(ackMessage);
                    break;
                case GroupDataMessage groupResponseMessage:
                    HandleGroupMessage(groupResponseMessage);
                    break;
                case ServerDataMessage serverResponseMessage:
                    HandleServerMessage(serverResponseMessage);
                    break;
                default:
                    throw new InvalidDataException($"Received unknown type of message {message.GetType()}");
            }

            return Task.CompletedTask;

            void HandleConnectedMessage(ConnectedMessage connectedMessage)
            {
                _connectionId = connectedMessage.ConnectionId;
                _reconnectionToken = connectedMessage.ReconnectionToken;

                if (!_isInitialConnected)
                {
                    _isInitialConnected = true;
                    HandleConnectionConnected(connectedMessage, token);
                }
            }

            void HandleDisconnectedMessage(DisconnectedMessage disconnectedMessage)
            {
                _latestDisconnectedMessage = disconnectedMessage;
            }

            void HandleGroupMessage(GroupDataMessage groupResponseMessage)
            {
                if (groupResponseMessage.SequenceId != null)
                {
                    if (!_sequenceId.TryUpdate(groupResponseMessage.SequenceId.Value))
                    {
                        // drop duplicated msg
                        return;
                    }
                }

                _groupDataChannel.Writer.TryWrite(groupResponseMessage);
            }

            void HandleServerMessage(ServerDataMessage serverResponseMessage)
            {
                if (serverResponseMessage.SequenceId != null)
                {
                    if (!_sequenceId.TryUpdate(serverResponseMessage.SequenceId.Value))
                    {
                        // drop duplicated msg
                        return;
                    }
                }

                _serverDataChannel.Writer.TryWrite(serverResponseMessage);
            }
        }

        internal void HandleAckMessage(AckMessage ackMessage)
        {
            if (_ackCache.TryRemove(ackMessage.AckId, out var entity))
            {
                if (ackMessage.Success ||
                    ackMessage.Error?.Name == ErrorNameDuplicate)
                {
                    entity.SetResult(new WebPubSubResult(ackMessage.AckId, ackMessage.Error?.Name == ErrorNameDuplicate));
                    return;
                }

                entity.SetException(new SendMessageFailedException($"Received non-success acknowledge from the service: {ackMessage.Error?.Message ?? string.Empty}", ackMessage.AckId, ackMessage.Error?.Name));
            }
        }

        private async Task StartServerProcessingDataMessage()
        {
            var reader = _serverDataChannel.Reader;
            while (await reader.WaitToReadAsync().ConfigureAwait(false))
            {
                while (reader.TryRead(out var message))
                {
                    await SafeInvokeServerMessageReceivedAsync(new WebPubSubServerMessageEventArgs(message, default)).ConfigureAwait(false);
                }
            }
        }

        private async Task StartGroupProcessingDataMessage()
        {
            var reader = _groupDataChannel.Reader;
            while (await reader.WaitToReadAsync().ConfigureAwait(false))
            {
                while (reader.TryRead(out var message))
                {
                    await SafeInvokeGroupMessageReceivedAsync(new WebPubSubGroupMessageEventArgs(message, default)).ConfigureAwait(false);
                }
            }
        }

        private async Task SequenceAckLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (_sequenceId.TryGetSequenceId(out var sequenceId))
                    {
                        var payload = _protocol.GetMessageBytes(new SequenceAckMessage(sequenceId));
                        await SendCoreAsync(payload, _protocol.WebSocketMessageType, true, token).ConfigureAwait(false);
                    }
                }
                catch
                {
                }
                finally
                {
                    await Task.Delay(1000, token).ConfigureAwait(false);
                }
            }
        }

        private bool TryBuildRecoveryUri(out Uri uri)
        {
            if (_connectionId != null && _reconnectionToken != null)
            {
                var builder = new UriBuilder(_clientAccessUri);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query.Add(RecoverConnectionIdQuery, _connectionId);
                query.Add(RecoverReconnectionTokenQuery, _reconnectionToken);
                builder.Query = query.ToString();
                uri = builder.Uri;
                return true;
            }
            uri = null;
            return false;
        }

        private AckEntity CreateAckEntity(long ackId)
        {
            return _ackCache.AddOrUpdate(ackId, new AckEntity(ackId), (_, oldEntity) => oldEntity);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("The client is already disposed");
            }
        }

        private long NextAckId()
        {
            lock (_ackIdLock)
            {
                return ++_nextAckId;
            }
        }

        private async Task<T> OperationExecuteWithRetry<T>(Func<CancellationToken, Task<T>> task, CancellationToken cancellationToken)
        {
            var retryAttempt = 0;

            while (true)
            {
                try
                {
                    return await task(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception)
                {
                    retryAttempt++;
                    var delay = _messageRetryPolicy.NextRetryDelay(new RetryContext { RetryAttempt = retryAttempt });

                    if (delay == null)
                    {
                        throw;
                    }

                    try
                    {
                        await Task.Delay(delay.Value, cancellationToken).ConfigureAwait(false);
                    }
                    catch { }

                    // If the cancellation token is request, we don't need another retry, but we respect the inner error
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                }
            }
        }

        private class AckEntity
        {
            public long AckId { get; }

            public AckEntity(long ackId)
            {
                AckId = ackId;
            }

            private TaskCompletionSource<WebPubSubResult> _tcs = new TaskCompletionSource<WebPubSubResult>(TaskCreationOptions.RunContinuationsAsynchronously);
            public void SetResult(WebPubSubResult message) => _tcs.TrySetResult(message);
            public void SetCancelled() => _tcs.TrySetException(new OperationCanceledException());
            public void SetException(Exception ex) => _tcs.TrySetException(ex);
            public Task<WebPubSubResult> Task => _tcs.Task;
        }

        private class SequenceId
        {
            private readonly object _lock = new object();
            private long _sequenceId;
            private bool _updated;

            public long Current => _sequenceId;

            public bool TryUpdate(long sequenceId)
            {
                lock (_lock)
                {
                    // Every time we got a message with sequence-id, we need to response a sequence ack after a period.
                    // Consider we receive 1,2,3 and connection drops. After recovery, we may get id 2. We need to also
                    // response 3 to tell the service what we've got.
                    _updated = true;

                    if (sequenceId > _sequenceId)
                    {
                        _sequenceId = sequenceId;
                        return true;
                    }
                    return false;
                }
            }

            public bool TryGetSequenceId(out long sequenceId)
            {
                lock (_lock)
                {
                    if (_updated)
                    {
                        sequenceId = _sequenceId;
                        _updated = false;
                        return true;
                    }

                    sequenceId = 0;
                    return false;
                }
            }

            public void Reset()
            {
                lock (_lock)
                {
                    _sequenceId = 0;
                    _updated = false;
                }
            }
        }

        private sealed class ClientState
        {
            private readonly object _lock = new();

            public WebPubSubClientState CurrentState { get; private set; } = WebPubSubClientState.Stopped;

            public void ChangeState(WebPubSubClientState newState)
            {
                lock (_lock)
                {
                    if (CurrentState != newState)
                    {
                        WebPubSubClientEventSource.Log.ClientStateChanged(newState.ToString(), CurrentState.ToString());
                        CurrentState = newState;
                    }
                }
            }
        }
    }
}
