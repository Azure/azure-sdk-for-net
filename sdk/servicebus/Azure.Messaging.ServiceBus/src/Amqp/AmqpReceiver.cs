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

        public long LastPeekedSequenceNumber { get; private set; }

        public override string SessionId { get; protected set; }

        /// <summary>
        /// A map of locked messages received using the management client.
        /// </summary>
        private readonly ConcurrentExpiringSet<Guid> _requestResponseLockedMessages;

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
            uint prefetchCount,
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
            _requestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();

            _receiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    _connectionScope.OpenReceiverLinkAsync(
                        entityName: EntityName,
                        timeout: timeout,
                        prefetchCount: prefetchCount,
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
        public override async Task<IList<ServiceBusReceivedMessage>> ReceiveBatchAsync(
            int maximumMessageCount,
            CancellationToken cancellationToken)
        {
            IList<ServiceBusReceivedMessage> messages = null;
            Task receiveMessageTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                messages = await ReceiveBatchAsyncInternal(
                    maximumMessageCount,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            EntityName,
            _connectionScope,
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
        internal async Task<IList<ServiceBusReceivedMessage>> ReceiveBatchAsyncInternal(
            int maximumMessageCount,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(ServiceBusReceiver));
            Argument.AssertAtLeast(maximumMessageCount, 1, nameof(maximumMessageCount));

            var link = default(ReceivingAmqpLink);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedMessages = new List<ServiceBusReceivedMessage>();

            var stopWatch = Stopwatch.StartNew();

            ServiceBusEventSource.Log.MessageReceiveStart(EntityName);

            link = await _receiveLink.GetOrCreateAsync(UseMinimum(_connectionScope.SessionTimeout, timeout)).ConfigureAwait(false);
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
                foreach (AmqpMessage message in amqpMessages)
                {
                    if (_receiveMode == ReceiveMode.ReceiveAndDelete)
                    {
                        link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                    }
                    receivedMessages.Add(AmqpMessageConverter.AmqpMessageToSBMessage(message));
                    // message.Dispose();
                }
            }

            stopWatch.Stop();
            return receivedMessages;
        }

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/>. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="receivedMessages">An <see cref="IEnumerable{T}"/> containing the list of <see cref="ServiceBusReceivedMessage"/> messages to complete.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        public override async Task CompleteAsync(
            IEnumerable<ServiceBusReceivedMessage> receivedMessages,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            Argument.AssertNotNullOrEmpty(receivedMessages, nameof(receivedMessages));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await _retryPolicy.RunOperation(
                    async (timeout) =>
                    await CompleteInternalAsync(
                        receivedMessages,
                        timeout).ConfigureAwait(false),
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageCompleteException(ClientId, exception);
                throw exception;
            }
            finally
            {
                // diagnosticSource.CompleteStop(activity, lockTokenList, completeTask?.Status);
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            // MessagingEventSource.Log.MessageCompleteStop(ClientId);
        }

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="receivedMessages">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="timeout"></param>
        internal async Task CompleteInternalAsync(
            IEnumerable<ServiceBusReceivedMessage> receivedMessages,
            TimeSpan timeout)
        {
            var lockTokenGuids = receivedMessages.Select(m => new Guid(m.LockToken)).ToArray();
            if (lockTokenGuids.Any(lockToken => _requestResponseLockedMessages.Contains(lockToken)))
            {
                await DisposeMessageRequestResponseAsync(
                    lockTokenGuids,
                    timeout,
                    DispositionStatus.Completed,
                    _isSessionReceiver,
                    SessionId).ConfigureAwait(false);
                return;
            }
            await DisposeMessagesAsync(lockTokenGuids, AmqpConstants.AcceptedOutcome, timeout).ConfigureAwait(false);
        }

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="outcome"></param>
        /// <param name="timeout"></param>
        private async Task DisposeMessagesAsync(
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

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="message">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using <see cref="ServiceBusReceiver.ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public override async Task DeferAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await _retryPolicy.RunOperation(
                    async (timeout) => await DeferInternalAsync(message, timeout, propertiesToModify).ConfigureAwait(false),
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageDeferException(ClientId, exception);
                throw exception;
            }
            finally
            {
                // diagnosticSource.DisposeStop(activity, lockToken, deferTask?.Status);
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            // MessagingEventSource.Log.MessageDeferStop(ClientId);
        }

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="message">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        ///
        internal virtual Task DeferInternalAsync(
            ServiceBusReceivedMessage message,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            var lockTokens = new[] { new Guid(message.LockToken) };
            if (lockTokens.Any(lt => _requestResponseLockedMessages.Contains(lt)))
            {
                return DisposeMessageRequestResponseAsync(
                    lockTokens,
                    timeout,
                    DispositionStatus.Defered,
                    _isSessionReceiver,
                    SessionId,
                    propertiesToModify);
            }
            return DisposeMessagesAsync(lockTokens, GetDeferOutcome(propertiesToModify), timeout);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusReceivedMessage"/>. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        public override async Task AbandonAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await _retryPolicy.RunOperation(
                    async (timeout) => await AbandonInternalAsync(message, timeout, propertiesToModify).ConfigureAwait(false),
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageAbandonException(ClientId, exception);
                throw exception;
            }
            finally
            {
                // diagnosticSource.DisposeStop(activity, lockToken, abandonTask?.Status);
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            // MessagingEventSource.Log.MessageAbandonStop(ClientId);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusMessage"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="message">The lock token of the corresponding message to abandon.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        internal virtual Task AbandonInternalAsync(
            ServiceBusReceivedMessage message,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            var lockTokens = new[] { new Guid(message.LockToken) };
            if (lockTokens.Any(lt => _requestResponseLockedMessages.Contains(lt)))
            {
                return DisposeMessageRequestResponseAsync(
                    lockTokens,
                    timeout,
                    DispositionStatus.Abandoned,
                    _isSessionReceiver,
                    SessionId,
                    propertiesToModify);
            }
            return DisposeMessagesAsync(lockTokens, GetAbandonOutcome(propertiesToModify), timeout);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="ServiceBusReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public override async Task DeadLetterAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            try
            {
                await _retryPolicy.RunOperation(
                    async (timeout) => await DeadLetterInternalAsync(message, timeout, propertiesToModify, deadLetterReason, deadLetterErrorDescription).ConfigureAwait(false),
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageDeadLetterException(ClientId, exception);
                throw exception;
            }
            finally
            {
                // diagnosticSource.DisposeStop(activity, lockToken, deadLetterTask?.Status);
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            // MessagingEventSource.Log.MessageDeadLetterStop(ClientId);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="message">The lock token of the corresponding message to deadletter.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        internal virtual Task DeadLetterInternalAsync(
            ServiceBusReceivedMessage message,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription)
        {
            if (deadLetterReason != null && deadLetterReason.Length > Constants.MaxDeadLetterReasonLength)
            {
                throw new ArgumentOutOfRangeException(nameof(deadLetterReason), string.Format(Resources1.MaxPermittedLength, Constants.MaxDeadLetterReasonLength));
            }

            if (deadLetterErrorDescription != null && deadLetterErrorDescription.Length > Constants.MaxDeadLetterReasonLength)
            {
                throw new ArgumentOutOfRangeException(nameof(deadLetterErrorDescription), string.Format(Resources1.MaxPermittedLength, Constants.MaxDeadLetterReasonLength));
            }

            var lockTokens = new[] { new Guid(message.LockToken) };
            if (lockTokens.Any(lt => _requestResponseLockedMessages.Contains(lt)))
            {
                return DisposeMessageRequestResponseAsync(
                    lockTokens,
                    timeout,
                    DispositionStatus.Suspended,
                    _isSessionReceiver,
                    SessionId,
                    propertiesToModify,
                    deadLetterReason,
                    deadLetterErrorDescription);
            }

            return DisposeMessagesAsync(
                lockTokens,
                GetRejectedOutcome(propertiesToModify, deadLetterReason, deadLetterErrorDescription),
                timeout);
        }

        private Rejected GetRejectedOutcome(
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription)
        {
            var rejected = AmqpConstants.RejectedOutcome;
            if (deadLetterReason != null || deadLetterErrorDescription != null || propertiesToModify != null)
            {
                rejected = new Rejected { Error = new Error { Condition = AmqpClientConstants.DeadLetterName, Info = new Fields() } };
                if (deadLetterReason != null)
                {
                    rejected.Error.Info.Add(ServiceBusReceivedMessage.DeadLetterReasonHeader, deadLetterReason);
                }

                if (deadLetterErrorDescription != null)
                {
                    rejected.Error.Info.Add(ServiceBusReceivedMessage.DeadLetterErrorDescriptionHeader, deadLetterErrorDescription);
                }

                if (propertiesToModify != null)
                {
                    foreach (var pair in propertiesToModify)
                    {
                        if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                        {
                            rejected.Error.Info.Add(pair.Key, amqpObject);
                        }
                        else
                        {
                            throw new NotSupportedException(Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                        }
                    }
                }
            }

            return rejected;
        }

        private Outcome GetAbandonOutcome(IDictionary<string, object> propertiesToModify)
        {
            return GetModifiedOutcome(propertiesToModify, false);
        }

        private Outcome GetDeferOutcome(IDictionary<string, object> propertiesToModify)
        {
            return GetModifiedOutcome(propertiesToModify, true);
        }

        private Outcome GetModifiedOutcome(
            IDictionary<string, object> propertiesToModify,
            bool undeliverableHere)
        {
            Modified modified = new Modified();
            if (undeliverableHere)
            {
                modified.UndeliverableHere = true;
            }

            if (propertiesToModify != null)
            {
                modified.MessageAnnotations = new Fields();
                foreach (var pair in propertiesToModify)
                {
                    if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                    {
                        modified.MessageAnnotations.Add(pair.Key, amqpObject);
                    }
                    else
                    {
                        throw new NotSupportedException(Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                    }
                }
            }

            return modified;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IList<ServiceBusReceivedMessage>> PeekBatchBySequenceAsync(
            long? fromSequenceNumber,
            int messageCount = 1,
            CancellationToken cancellationToken = default)
        {

            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                IList<ServiceBusReceivedMessage> messages = null;
                await _retryPolicy.RunOperation(
                    async (timeout) =>
                    messages = await PeekBatchBySequenceAsyncInternal(
                        fromSequenceNumber,
                        messageCount,
                        timeout,
                        cancellationToken)
                    .ConfigureAwait(false),
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);
                return messages;
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageAbandonException(ClientId, exception);
                throw exception;
            }
            finally
            {
                // diagnosticSource.DisposeStop(activity, lockToken, abandonTask?.Status);
            }

            // MessagingEventSource.Log.MessageAbandonStop(ClientId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IList<ServiceBusReceivedMessage>> PeekBatchBySequenceAsyncInternal(
            long? fromSequenceNumber,
            int messageCount,
            TimeSpan timeout,
            CancellationToken cancellationToken)
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
                UseMinimum(_connectionScope.SessionTimeout,
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
        /// <param name="isSessionReceiver"></param>
        /// <param name="sessionId"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterDescription"></param>
        private async Task DisposeMessageRequestResponseAsync(
            Guid[] lockTokens,
            TimeSpan timeout,
            DispositionStatus dispositionStatus,
            bool isSessionReceiver,
            string sessionId = null,
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

                if (!string.IsNullOrWhiteSpace(sessionId))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = sessionId;
                }

                if (isSessionReceiver)
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
        /// <param name="cancellationToken"></param>
        public override async Task<DateTime> RenewMessageLockAsync(
            string lockToken,
            CancellationToken cancellationToken)
        {
            DateTime lockedUntilUtc = DateTime.MinValue;
            try
            {
                await _retryPolicy.RunOperation(
                    async (timeout) =>
                    {
                        lockedUntilUtc = await RenewLockInternalAsync(
                            lockToken,
                            timeout).ConfigureAwait(false);
                    },
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);

                return lockedUntilUtc;
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageRenewLockException(this.ClientId, exception);
                throw exception;
            }
            finally
            {
                // this.diagnosticSource.RenewLockStop(activity, lockToken, renewTask?.Status, lockedUntilUtc);
            }

            // MessagingEventSource.Log.MessageRenewLockStop(this.ClientId);
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        ///
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <param name="timeout"></param>
        private async Task<DateTime> RenewLockInternalAsync(
            string lockToken,
            TimeSpan timeout)
        {
            DateTime lockedUntilUtc = DateTime.MinValue;
            try
            {
                // Create an AmqpRequest Message to renew  lock
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.RenewLockOperation,
                    timeout,
                    null);

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
                    IEnumerable<DateTime> lockedUntilUtcTimes = amqpResponseMessage.GetValue<IEnumerable<DateTime>>(ManagementConstants.Properties.Expirations);
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
                    _connectionScope,
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
        /// Receives a <see cref="IList{Message}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public override async Task<IList<ServiceBusReceivedMessage>> ReceiveDeferredMessageBatchAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            IList<ServiceBusReceivedMessage> messages = null;
            try
            {
                await _retryPolicy.RunOperation(
                    async (timeout) => messages = await ReceiveDeferredMessagesAsyncInternal(
                        sequenceNumbers.ToArray(),
                        timeout).ConfigureAwait(false),
                    EntityName,
                    _connectionScope,
                    cancellationToken).ConfigureAwait(false);
                return messages;
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.MessageDeadLetterException(ClientId, exception);
                throw exception;
            }
            finally
            {
                // diagnosticSource.DisposeStop(activity, lockToken, deadLetterTask?.Status);
            }
        }

        internal virtual async Task<IList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsyncInternal(
            long[] sequenceNumbers,
            TimeSpan timeout)
        {
            var messages = new List<ServiceBusReceivedMessage>();
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.ReceiveBySequenceNumberOperation, timeout, null);

                if (_receiveLink.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }
                amqpRequestMessage.Map[ManagementConstants.Properties.SequenceNumbers] = sequenceNumbers;
                amqpRequestMessage.Map[ManagementConstants.Properties.ReceiverSettleMode] = (uint)(_receiveMode == ReceiveMode.ReceiveAndDelete ? 0 : 1);
                if (!string.IsNullOrWhiteSpace(SessionId))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;
                }

                var response = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _managementLink,
                    amqpRequestMessage,
                    timeout).ConfigureAwait(false);

                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var amqpMapList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                    foreach (var entry in amqpMapList)
                    {
                        var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        var amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        var message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
                        if (entry.TryGetValue<Guid>(ManagementConstants.Properties.LockToken, out var lockToken))
                        {
                            message.LockTokenGuid = lockToken;
                            _requestResponseLockedMessages.AddOrUpdate(lockToken, message.LockedUntilUtc);
                        }

                        messages.Add(message);
                    }
                }
                else
                {
                    //throw response.ToMessagingContractException();
                }
            }
            catch (Exception)
            {
               // throw AmqpExceptionHelper.GetClientException(exception);
            }

            return messages;
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task OpenLinkAsync(CancellationToken cancellationToken)
        {
            ReceivingAmqpLink link = null;
            await _retryPolicy.RunOperation(
               async (timeout) =>
               link = await _receiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false),
               EntityName,
               _connectionScope,
               cancellationToken).ConfigureAwait(false);
            var source = (Source)link.Settings.Source;
            if (source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var tempSessionId))
            {
                SessionId = tempSessionId;
            }
        }
    }
}
