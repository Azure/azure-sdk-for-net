// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusReceiver" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportReceiver" />
    ///
    internal class AmqpReceiver : TransportReceiver
    {
        /// <summary>The default prefetch count to use for the consumer.</summary>
        private const int DefaultPrefetchCount = 0;

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

        private readonly FaultTolerantAmqpObject<ReceivingAmqpLink> _receiveLink;

        private readonly FaultTolerantAmqpObject<RequestResponseAmqpLink> _managementLink;

        /// <inheritdoc/>
        public override TransportConnectionScope ConnectionScope =>
            _connectionScope;

        public long LastPeekedSequenceNumber { get; private set; }

        public override string SessionId { get; protected set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpReceiver"/> class.
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
        public AmqpReceiver(
            string entityName,
            ReceiveMode receiveMode,
            int? prefetchCount,
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

            _receiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    _connectionScope.OpenReceiverLinkAsync(
                        entityName: EntityName,
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

            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => _connectionScope.OpenManagementLinkAsync(
                    EntityName,
                    timeout,
                    CancellationToken.None),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
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
        public override async Task<IEnumerable<ServiceBusReceivedMessage>> ReceiveAsync(
            int maximumMessageCount,
            CancellationToken cancellationToken)
        {
            IEnumerable<ServiceBusReceivedMessage> messages = null;
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
        internal async Task<IEnumerable<ServiceBusReceivedMessage>> ReceiveAsyncInternal(
            int maximumMessageCount,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpReceiver));
            Argument.AssertAtLeast(maximumMessageCount, 1, nameof(maximumMessageCount));

            var link = default(ReceivingAmqpLink);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedMessages = default(List<ServiceBusReceivedMessage>);

            var stopWatch = Stopwatch.StartNew();

            ServiceBusEventSource.Log.MessageReceiveStart(EntityName);

            link = await _receiveLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, timeout)).ConfigureAwait(false);
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
                receivedMessages = new List<ServiceBusReceivedMessage>();

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
            return Enumerable.Empty<ServiceBusReceivedMessage>();
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

                if (!_receiveLink.TryGetOpenedObject(out receiveLink))
                {
                    receiveLink = await _receiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<ServiceBusReceivedMessage>> PeekAsync(
            TimeSpan timeout,
            long? fromSequenceNumber,
            int messageCount = 1,
            CancellationToken cancellationToken = default)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.PeekMessageOperation,
                    timeout,
                    null);

            if (_receiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
            {
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
            }

            amqpRequestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = fromSequenceNumber ?? LastPeekedSequenceNumber + 1;
            amqpRequestMessage.Map[ManagementConstants.Properties.MessageCount] = messageCount;

            if (!string.IsNullOrWhiteSpace(SessionId))
            {
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;
            }

            RequestResponseAmqpLink link = await _managementLink.GetOrCreateAsync(
                UseMinimum(ConnectionScope.SessionTimeout,
                timeout.CalculateRemaining(stopWatch.Elapsed)))
                .ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            using AmqpMessage responseAmqpMessage = await link.RequestAsync(
                amqpRequestMessage.AmqpMessage,
                timeout.CalculateRemaining(stopWatch.Elapsed))
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(responseAmqpMessage);

            var messages = new List<ServiceBusReceivedMessage>();
            //AmqpError.ThrowIfErrorResponse(responseAmqpMessage, EntityName);
            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
            {
                ServiceBusReceivedMessage message = null;
                IEnumerable<AmqpMap> messageList = amqpResponseMessage.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                foreach (AmqpMap entry in messageList)
                {
                    var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                    var amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                    message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage, true);
                    messages.Add(message);
                }

                if (message != null)
                {
                    LastPeekedSequenceNumber = message.SequenceNumber;
                }
                return messages;
            }

            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NoContent ||
                (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NotFound && Equals(AmqpClientConstants.MessageNotFoundError, amqpResponseMessage.GetResponseErrorCondition())))
            {
                return messages;
            }
            // TODO throw correct exception
            throw new Exception();
        }

        /// <summary>
        /// Updates the disposition status of deferred messages.
        /// </summary>
        ///
        /// <param name="lockTokens">Message lock tokens to update disposition status.</param>
        /// <param name="timeout"></param>
        /// <param name="dispositionStatus"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterDescription"></param>
        internal override async Task DisposeMessageRequestResponseAsync(
            Guid[] lockTokens,
            TimeSpan timeout,
            DispositionStatus dispositionStatus,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterDescription = null)
        {
            try
            {
                // Create an AmqpRequest Message to update disposition
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.UpdateDispositionOperation, timeout, null);

                if (_receiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = lockTokens;
                amqpRequestMessage.Map[ManagementConstants.Properties.DispositionStatus] = dispositionStatus.ToString().ToLowerInvariant();

                if (deadLetterReason != null)
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.DeadLetterReason] = deadLetterReason;
                }

                if (deadLetterDescription != null)
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.DeadLetterDescription] = deadLetterDescription;
                }

                if (propertiesToModify != null)
                {
                    var amqpPropertiesToModify = new AmqpMap();
                    foreach (var pair in propertiesToModify)
                    {
                        if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                        {
                            amqpPropertiesToModify[new MapKey(pair.Key)] = amqpObject;
                        }
                        else
                        {
                            throw new NotSupportedException(
                                Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                        }
                    }

                    if (amqpPropertiesToModify.Count > 0)
                    {
                        amqpRequestMessage.Map[ManagementConstants.Properties.PropertiesToModify] = amqpPropertiesToModify;
                    }
                }

                if (!string.IsNullOrWhiteSpace(SessionId))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;
                }

                if (_isSessionReceiver)
                {
                    // TODO -  ThrowIfSessionLockLost();
                }

                var amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _managementLink,
                    amqpRequestMessage,
                    timeout).ConfigureAwait(false);
                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    // throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception)
            {
                // throw AmqpExceptionHelper.GetClientException(exception);
                throw;
            }
        }

        internal List<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        ///
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <param name="timeout"></param>
        public override async Task<DateTime> RenewLockAsync(
            string lockToken,
            TimeSpan timeout)
        {
            DateTime lockedUntilUtc = DateTime.MinValue;
            try
            {
                // Create an AmqpRequest Message to renew  lock
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewLockOperation, timeout, null);

                if (_receiveLink.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }
                amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = new[] { new Guid(lockToken) };

                var amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _managementLink,
                    amqpRequestMessage,
                    timeout).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var lockedUntilUtcTimes = amqpResponseMessage.GetValue<IEnumerable<DateTime>>(ManagementConstants.Properties.Expirations);
                    lockedUntilUtc = lockedUntilUtcTimes.First();
                }
                else
                {
                    // throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                // TODO: throw AmqpExceptionHelper.GetClientException(exception);
                throw exception;
            }

            return lockedUntilUtc;
        }

        /// <summary>
        ///
        /// </summary>
        public override async Task<DateTime> RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));

            if (_receiveMode != ReceiveMode.PeekLock)
            {
                throw new InvalidOperationException(Resources1.OperationNotSupported);
            }

            // MessagingEventSource.Log.RenewSessionLockStart(this.SessionId);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                DateTime lockedUntil = default;
                await _retryPolicy.RunOperation(
                    async (timeout) =>
                    {
                            lockedUntil = await RenewSessionLockInternal(
                            timeout).ConfigureAwait(false);
                    },
                    EntityName,
                    ConnectionScope,
                    cancellationToken).ConfigureAwait(false);
                return lockedUntil;
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.RenewSessionLockException(this.SessionId, exception);
                throw exception;
            }
            finally
            {
                // this.diagnosticSource.RenewSessionLockStop(activity, this.SessionId);
            }
            // MessagingEventSource.Log.MessageRenewLockStop(this.SessionId);
        }

        /// <summary>
        ///
        /// </summary>
        ///
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="timeout"></param>
        internal async Task<DateTime> RenewSessionLockInternal(
            TimeSpan timeout)
        {
            DateTime lockedUntilUtc = DateTime.MinValue;
            try
            {
                // Create an AmqpRequest Message to renew  lock
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, timeout, null);

                if (_receiveLink.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;

                var amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _managementLink,
                    amqpRequestMessage,
                    timeout).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    lockedUntilUtc = amqpResponseMessage.GetValue<DateTime>(ManagementConstants.Properties.Expiration);
                }
                else
                {
                    // TODO: throw amqpResponseMessage.ToMessagingContractException();
                }
                return lockedUntilUtc;
            }
            catch (Exception exception)
            {
                // TODO: throw AmqpExceptionHelper.GetClientException(exception);
                throw exception;
            }

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

                if (_receiveLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await _receiveLink.CloseAsync().ConfigureAwait(false);
                }

                _receiveLink?.Dispose();
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
            return await _receiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
        }


        public override async Task OpenLinkAsync(CancellationToken cancellationToken)
        {
            ReceivingAmqpLink link = null;
            await _retryPolicy.RunOperation(
               async (timeout) =>
               link = await _receiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false),
               EntityName,
               ConnectionScope,
               cancellationToken).ConfigureAwait(false);
            var source = (Source)link.Settings.Source;
            if (source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var tempSessionId))
            {
                SessionId = tempSessionId;
            }
        }
    }
}
