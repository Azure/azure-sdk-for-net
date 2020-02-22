// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusReceiverClient" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportConsumer" />
    ///
    internal class AmqpConsumer : TransportConsumer
    {
        /// <summary>The default prefetch count to use for the consumer.</summary>
        private const uint DefaultPrefetchCount = 0;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

        /// <summary>
        ///   Indicates whether or not this consumer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The name of the Service Bus entity to which the client is bound.
        /// </summary>
        ///
        public override string EntityName { get; }

        /// <summary>
        ///   The identifier of the Service Bus entity partition that this consumer is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        private string PartitionId { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        /// Indicates whether or not this is a receiver scoped to a session.
        /// </summary>
        private readonly bool _isSessionReceiver;

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private readonly AmqpConnectionScope _connectionScope;

        /// <summary>
        ///   The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        ///
        private readonly ReceiveMode _receiveMode;

        /// <inheritdoc/>
        public override TransportConnectionScope ConnectionScope =>
            _connectionScope;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConsumer"/> class.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Service Bus entity from which events will be consumed.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="connectionScope">The AMQP connection context for operations .</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        public AmqpConsumer(
            string entityName,
            ReceiveMode receiveMode,
            uint? prefetchCount,
            AmqpConnectionScope connectionScope,
            ServiceBusRetryPolicy retryPolicy,
            string sessionId,
            bool isSessionReceiver)
        {
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));
            EntityName = entityName;
            _connectionScope = connectionScope;
            _retryPolicy = retryPolicy;
            _isSessionReceiver = isSessionReceiver;
            _receiveMode = receiveMode;

            ReceiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    _connectionScope.OpenConsumerLinkAsync(
                        timeout: timeout,
                        prefetchCount: prefetchCount ?? DefaultPrefetchCount,
                        receiveMode: receiveMode,
                        sessionId: sessionId,
                        isSessionReceiver: isSessionReceiver,
                        cancellationToken: CancellationToken.None),
                link =>
                {
                    CloseLink(link);
                });
        }

        private void CloseLink(ReceivingAmqpLink link)
        {
            link.Session?.SafeClose();
            link.SafeClose();
        }

        /// <summary>
        ///   Receives a batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public override async Task<IEnumerable<ServiceBusMessage>> ReceiveAsync(
            int maximumMessageCount,
            CancellationToken cancellationToken)
        {
            IEnumerable<ServiceBusMessage> messages = null;
            Task receiveMessageTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                messages = await ReceiveAsyncInternal(
                    maximumMessageCount,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            EntityName,
            ConnectionScope,
            cancellationToken);
            await receiveMessageTask.ConfigureAwait(false);

            return messages;
        }

        /// <summary>
        ///   Receives a batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        internal async Task<IEnumerable<ServiceBusMessage>> ReceiveAsyncInternal(
            int maximumMessageCount,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpConsumer));
            Argument.AssertAtLeast(maximumMessageCount, 1, nameof(maximumMessageCount));

            var link = default(ReceivingAmqpLink);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedMessages = default(List<ServiceBusMessage>);

            var stopWatch = Stopwatch.StartNew();

            ServiceBusEventSource.Log.MessageReceiveStart(EntityName);

            link = await ReceiveLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, timeout)).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var messagesReceived = await Task.Factory.FromAsync
            (
                (callback, state) => link.BeginReceiveRemoteMessages(maximumMessageCount, TimeSpan.FromMilliseconds(20), timeout, callback, state),
                (asyncResult) => link.EndReceiveMessages(asyncResult, out amqpMessages),
                TaskCreationOptions.RunContinuationsAsynchronously
            ).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // If event messages were received, then package them for consumption and
            // return them.

            if ((messagesReceived) && (amqpMessages != null))
            {
                receivedMessages = new List<ServiceBusMessage>();

                foreach (AmqpMessage message in amqpMessages)
                {
                    if (_receiveMode == ReceiveMode.ReceiveAndDelete)
                    {
                        link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                    }
                    receivedMessages.Add(AmqpMessageConverter.AmqpMessageToSBMessage(message));
                    // message.Dispose();
                }

                stopWatch.Stop();

                return receivedMessages;
            }

            stopWatch.Stop();

            // No events were available.
            return Enumerable.Empty<ServiceBusMessage>();
        }

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="outcome"></param>
        /// <param name="timeout"></param>
        internal override async Task DisposeMessagesAsync(
            IEnumerable<Guid> lockTokens,
            Outcome outcome,
            TimeSpan timeout)
        {
            if (_isSessionReceiver)
            {
                // TODO -  ThrowIfSessionLockLost();
            }

            List<ArraySegment<byte>> deliveryTags = ConvertLockTokensToDeliveryTags(lockTokens);

            ReceivingAmqpLink receiveLink = null;
            try
            {
                ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
                //var ambientTransaction = Transaction.Current;
                //if (ambientTransaction != null)
                //{
                //    transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, ServiceBusConnection).ConfigureAwait(false);
                //}

                if (!ReceiveLink.TryGetOpenedObject(out receiveLink))
                {
                    receiveLink = await ReceiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
                }

                var disposeMessageTasks = new Task<Outcome>[deliveryTags.Count];
                var i = 0;
                foreach (ArraySegment<byte> deliveryTag in deliveryTags)
                {
                    disposeMessageTasks[i++] = Task.Factory.FromAsync(
                        (c, s) => receiveLink.BeginDisposeMessage(deliveryTag, transactionId, outcome, true, timeout, c, s),
                        a => receiveLink.EndDisposeMessage(a),
                        this);
                }

                var outcomes = await Task.WhenAll(disposeMessageTasks).ConfigureAwait(false);
                Error error = null;
                foreach (Outcome item in outcomes)
                {
                    var disposedOutcome = item.DescriptorCode == Rejected.Code && ((error = ((Rejected)item).Error) != null) ? item : null;
                    if (disposedOutcome != null)
                    {
                        if (error.Condition.Equals(AmqpErrorCode.NotFound))
                        {
                            if (_isSessionReceiver)
                            {
                                //  throw new SessionLockLostException(Resources.SessionLockExpiredOnMessageSession);
                            }

                            //   throw new MessageLockLostException(Resources.MessageLockLost);
                        }

                        // throw error.ToMessagingContractException();
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is OperationCanceledException &&
                    receiveLink != null && receiveLink.State != AmqpObjectState.Opened)
                {
                    // The link state is lost, We need to return a non-retriable error.
                    // MessagingEventSource.Log.LinkStateLost(ClientId, receiveLink.Name, receiveLink.State, isSessionReceiver, exception);
                    if (_isSessionReceiver)
                    {
                        //  throw new SessionLockLostException(Resources.SessionLockExpiredOnMessageSession);
                    }

                    // throw new MessageLockLostException(Resources.MessageLockLost);
                }

                // throw AmqpExceptionHelper.GetClientException(exception);
                throw;
            }
        }

        internal List<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
        }

        /// <summary>
        ///   Closes the connection to the transport consumer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return;
            }

            _closed = true;

            var clientId = GetHashCode().ToString();
            var clientType = GetType();

            try
            {
                ServiceBusEventSource.Log.ClientCloseStart(clientType, EntityName, clientId);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (ReceiveLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await ReceiveLink.CloseAsync().ConfigureAwait(false);
                }

                ReceiveLink?.Dispose();
            }
            catch (Exception ex)
            {
                _closed = false;
                ServiceBusEventSource.Log.ClientCloseError(clientType, EntityName, clientId, ex.Message);

                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(clientType, EntityName, clientId);
            }
        }

        /// <summary>
        ///   Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns>The smaller of the two specified intervals.</returns>
        ///
        private static TimeSpan UseMinimum(
            TimeSpan firstOption,
            TimeSpan secondOption) =>
            (firstOption < secondOption) ? firstOption : secondOption;

        /// <summary>
        /// Get the session Id corresponding to this consumer
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default)
        {
            if (!_isSessionReceiver)
            {
                return null;
            }
            ReceivingAmqpLink openedLink = null;

            await _retryPolicy.RunOperation(
               async (timeout) =>
               openedLink = await GetOrCreateLinkAsync(timeout).ConfigureAwait(false),
               EntityName,
               ConnectionScope,
               cancellationToken).ConfigureAwait(false);

            var source = (Source)openedLink.Settings.Source;
            source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var sessionId);
            return sessionId;
        }

        public override async Task<DateTimeOffset> GetSessionLockedUntilUtcAsync(CancellationToken cancellationToken = default)
        {
            ReceivingAmqpLink openedLink = null;

            await _retryPolicy.RunOperation(
               async (timeout) =>
               openedLink = await GetOrCreateLinkAsync(timeout).ConfigureAwait(false),
               EntityName,
               ConnectionScope,
               cancellationToken).ConfigureAwait(false);

            return openedLink.Settings.Properties.TryGetValue<long>(AmqpClientConstants.LockedUntilUtc, out var lockedUntilUtcTicks)
            ? new DateTimeOffset(lockedUntilUtcTicks, TimeSpan.Zero)
            : DateTimeOffset.MinValue;
        }

        internal override async Task<ReceivingAmqpLink> GetOrCreateLinkAsync(TimeSpan timeout)
        {
            return await ReceiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
        }

        internal override string GetReceiveLinkName()
        {
            string receiveLinkName = "";
            if (ReceiveLink.TryGetOpenedObject(out ReceivingAmqpLink link))
            {
                receiveLinkName = link.Name;
            }
            return receiveLinkName;
        }

    }
}
