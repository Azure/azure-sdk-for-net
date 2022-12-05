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

        // Some exposed properties for testing
        internal IWebSocketClientFactory WebSocketClientFactory { get; set; }
        internal TimeSpan RecoverDelay { get; set; } = TimeSpan.FromSeconds(1);

        private readonly WebPubSubClientCredential _webPubSubClientCredential;
        private readonly WebPubSubClientOptions _options;
        private readonly WebPubSubProtocol _protocol;
        private readonly ConcurrentDictionary<string, WebPubSubGroup> _groups = new();
        private readonly WebPubSubRetryPolicy _reconnectRetryPolicy;
        private readonly WebPubSubRetryPolicy _messageRetryPolicy;
        private readonly ClientState _clientState;
        private ulong _nextAckId;

        private readonly object _ackIdLock = new();

        private ConcurrentDictionary<ulong, AckEntity> _ackCache = new();

        private volatile bool _disposed;

        /// <summary>
        /// The connection ID of the client. The ID is assigned when the client connects.
        /// </summary>
        public string ConnectionId { get; }

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
        public virtual Task StartAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop the client.
        /// </summary>
        /// <returns></returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Task StopAsync()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop and close the client to the service
        /// </summary>
        /// <returns></returns>
#pragma warning disable AZC0003 // DO make service methods virtual.
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public async ValueTask DisposeAsync()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
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
        protected virtual ValueTask DisposeAsyncCore()
        {
            if (_disposed)
            {
                return default;
            }

            _disposed = true;
            return default;
        }

        /// <summary>
        /// Join the target group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="ackId">An optional ack id. It's generated by SDK if not assigned.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation.</returns>
        public virtual async Task<WebPubSubResult> JoinGroupAsync(string group, ulong? ackId = null, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            var groupEntity = _groups.GetOrAdd(group, n => new WebPubSubGroup(n));
            var ack = await OperationExecuteWithRetry(token => JoinGroupAttemptAsync(group, ackId, token), cancellationToken).ConfigureAwait(false);
            groupEntity.Joined = true;
            return ack;
        }

        internal virtual async Task<WebPubSubResult> JoinGroupAttemptAsync(string group, ulong? ackId = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<WebPubSubResult> LeaveGroupAsync(string group, ulong? ackId = null, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            var groupEntity = _groups.GetOrAdd(group, n => new WebPubSubGroup(n));
            var ack = await OperationExecuteWithRetry(token => LeaveGroupAttemptAsync(group, ackId, token), cancellationToken).ConfigureAwait(false);
            groupEntity.Joined = false;
            return ack;
        }

        internal virtual async Task<WebPubSubResult> LeaveGroupAttemptAsync(string group, ulong? ackId = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<WebPubSubResult> SendToGroupAsync(string group, BinaryData content, WebPubSubDataType dataType, ulong? ackId = null, bool noEcho = false, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return await OperationExecuteWithRetry(token => SendToGroupAttemptAsync(group, content, dataType, ackId, noEcho, fireAndForget, token), cancellationToken).ConfigureAwait(false);
        }

        internal virtual async Task<WebPubSubResult> SendToGroupAttemptAsync(string group, BinaryData content, WebPubSubDataType dataType, ulong? ackId = null, bool noEcho = false, bool fireAndForget = false, CancellationToken cancellationToken = default)
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
        public virtual async Task<WebPubSubResult> SendEventAsync(string eventName, BinaryData content, WebPubSubDataType dataType, ulong? ackId = null, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return await OperationExecuteWithRetry(token => SendEventAttemptAsync(eventName, content, dataType, ackId, fireAndForget, token), cancellationToken).ConfigureAwait(false);
        }

        internal virtual async Task<WebPubSubResult> SendEventAttemptAsync(string eventName, BinaryData content, WebPubSubDataType dataType, ulong? ackId = null, bool fireAndForget = false, CancellationToken cancellationToken = default)
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

        internal virtual Task SendCoreAsync(ReadOnlyMemory<byte> buffer, WebPubSubProtocolMessageType webPubSubProtocolMessageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        internal async Task<WebPubSubResult> SendMessageWithAckAsync(Func<ulong, WebPubSubMessage> GetMessage, ulong? ackId, CancellationToken token)
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
            return await entity.Task.ConfigureAwait(false);
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

                entity.SetException(new SendMessageFailedException("Received non-success acknowledge from the service", ackMessage.AckId, ackMessage.Error));
            }
        }

        private AckEntity CreateAckEntity(ulong ackId)
        {
            return _ackCache.GetOrAdd(ackId, id => new AckEntity(id));
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("The client is already disposed");
            }
        }

        private ulong NextAckId()
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
            public ulong AckId { get; }

            public AckEntity(ulong ackId)
            {
                AckId = ackId;
            }

            private TaskCompletionSource<WebPubSubResult> _tcs = new TaskCompletionSource<WebPubSubResult>(TaskCreationOptions.RunContinuationsAsynchronously);
            public void SetResult(WebPubSubResult message) => _tcs.TrySetResult(message);
            public void SetCancelled() => _tcs.TrySetException(new OperationCanceledException());
            public void SetException(Exception ex) => _tcs.TrySetException(ex);
            public Task<WebPubSubResult> Task => _tcs.Task;
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
