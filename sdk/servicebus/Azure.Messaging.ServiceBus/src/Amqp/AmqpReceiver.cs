// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// A transport client abstraction responsible for brokering operations for AMQP-based connections.
    /// It is intended that the public <see cref="ServiceBusReceiver" /> make use of an instance
    /// via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportReceiver" />
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal class AmqpReceiver : TransportReceiver
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed;

        /// <summary>
        /// Indicates whether or not this receiver has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the receiver is closed; otherwise, <c>false</c>.
        /// </value>
        public override bool IsClosed => _closed;

        /// <summary>
        /// The name of the Service Bus entity to which the receiver is bound.
        /// </summary>
        ///
        private readonly string _entityPath;

        /// <summary>
        /// The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        /// Indicates whether or not this is a receiver scoped to a session.
        /// </summary>
        private readonly bool _isSessionReceiver;

        /// <summary>
        /// The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private readonly AmqpConnectionScope _connectionScope;

        /// <summary>
        /// The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        private readonly ServiceBusReceiveMode _receiveMode;
        private readonly string _identifier;
        private readonly FaultTolerantAmqpObject<ReceivingAmqpLink> _receiveLink;

        private readonly FaultTolerantAmqpObject<RequestResponseAmqpLink> _managementLink;

        /// <summary>
        /// Gets the sequence number of the last peeked message.
        /// </summary>
        public long LastPeekedSequenceNumber { get; private set; }

        /// <summary>
        /// The Session Id associated with the receiver.
        /// </summary>
        public override string SessionId { get; protected set; }

        public override DateTimeOffset SessionLockedUntil { get; protected set; }

        private Exception LinkException { get; set; }

        /// <summary>
        /// A map of locked messages received using the management client.
        /// </summary>
        private readonly ConcurrentExpiringSet<Guid> _requestResponseLockedMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmqpReceiver"/> class.
        /// </summary>
        ///
        /// <param name="entityPath">The name of the Service Bus entity from which events will be consumed.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="connectionScope">The AMQP connection context for operations .</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="identifier"></param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        ///
        /// <remarks>
        /// As an internal type, this class performs only basic sanity checks against its arguments.  It
        /// is assumed that callers are trusted and have performed deep validation.
        ///
        /// Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        /// creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        /// caller.
        /// </remarks>
        public AmqpReceiver(
            string entityPath,
            ServiceBusReceiveMode receiveMode,
            uint prefetchCount,
            AmqpConnectionScope connectionScope,
            ServiceBusRetryPolicy retryPolicy,
            string identifier,
            string sessionId,
            bool isSessionReceiver)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            _entityPath = entityPath;
            _connectionScope = connectionScope;
            _retryPolicy = retryPolicy;
            _isSessionReceiver = isSessionReceiver;
            _receiveMode = receiveMode;
            _identifier = identifier;
            _requestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();
            SessionId = sessionId;

            _receiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    OpenReceiverLinkAsync(
                        timeout: timeout,
                        prefetchCount: prefetchCount,
                        receiveMode: receiveMode,
                        isSessionReceiver: isSessionReceiver,
                        identifier: identifier),
                link => CloseLink(link));

            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => OpenManagementLinkAsync(timeout),
                link => CloseLink(link));
        }

        private async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(
            TimeSpan timeout)
        {
            RequestResponseAmqpLink link = await _connectionScope.OpenManagementLinkAsync(
                _entityPath,
                _identifier,
                timeout,
                CancellationToken.None).ConfigureAwait(false);
            link.Closed += OnManagementLinkClosed;
            return link;
        }

        private async Task<ReceivingAmqpLink> OpenReceiverLinkAsync(
            TimeSpan timeout,
            uint prefetchCount,
            ServiceBusReceiveMode receiveMode,
            bool isSessionReceiver,
            string identifier)
        {
            ServiceBusEventSource.Log.CreateReceiveLinkStart(_identifier);

            try
            {
                ReceivingAmqpLink link = await _connectionScope.OpenReceiverLinkAsync(
                    identifier: identifier,
                    entityPath: _entityPath,
                    timeout: timeout,
                    prefetchCount: prefetchCount,
                    receiveMode: receiveMode,
                    sessionId: SessionId,
                    isSessionReceiver: isSessionReceiver,
                    cancellationToken: CancellationToken.None).ConfigureAwait(false);
                if (isSessionReceiver)
                {
                    SessionLockedUntil = link.Settings.Properties.TryGetValue<long>(
                        AmqpClientConstants.LockedUntilUtc, out var lockedUntilUtcTicks) ?
                        new DateTime(lockedUntilUtcTicks, DateTimeKind.Utc)
                        : DateTime.MinValue;

                    var source = (Source)link.Settings.Source;
                    if (!source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var tempSessionId))
                    {
                        link.Session.SafeClose();
                        throw new ServiceBusException(true, Resources.SessionFilterMissing);
                    }

                    if (string.IsNullOrWhiteSpace(tempSessionId))
                    {
                        link.Session.SafeClose();
                        throw new ServiceBusException(true, Resources.AmqpFieldSessionId);
                    }
                    // This will only have changed if sessionId was left blank when constructing the session
                    // receiver.
                    SessionId = tempSessionId;
                }
                ServiceBusEventSource.Log.CreateReceiveLinkComplete(_identifier, SessionId);
                link.Closed += OnReceiverLinkClosed;
                return link;
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CreateReceiveLinkException(_identifier, ex.ToString());
                throw;
            }
        }

        private static void CloseLink(ReceivingAmqpLink link)
        {
            link.Session?.SafeClose();
            link.SafeClose();
        }

        private static void CloseLink(RequestResponseAmqpLink link)
        {
            link.Session?.SafeClose();
            link.SafeClose();
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusReceivedMessage" /> from the entity using <see cref="ServiceBusReceiveMode"/> mode.
        /// </summary>
        ///
        /// <param name="maxMessages">The maximum number of messages that will be received.</param>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for the first message before returning an empty list if no messages have been received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>List of messages received. Returns an empty list if no message is found.</returns>
        public override async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsync(
            int maxMessages,
            TimeSpan? maxWaitTime,
            CancellationToken cancellationToken)
        {
            IReadOnlyList<ServiceBusReceivedMessage> messages = null;
            await _retryPolicy.RunOperation(async (timeout) =>
            {
                messages = await ReceiveMessagesAsyncInternal(
                    maxMessages,
                    maxWaitTime,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            _connectionScope,
            cancellationToken).ConfigureAwait(false);

            return messages;
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusMessage" /> from the Service Bus entity.
        /// </summary>
        ///
        /// <param name="maxMessages">The maximum number of messages to receive.</param>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for the first message before returning an empty list if no messages have been received.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.</param>
        /// <param name="timeout">The per-try timeout specified in the RetryOptions.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The list of <see cref="ServiceBusMessage" /> from the Service Bus entity this receiver is associated with. If no messages are present, an empty list is returned.</returns>
        ///
        private async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsyncInternal(
            int maxMessages,
            TimeSpan? maxWaitTime,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var link = default(ReceivingAmqpLink);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedMessages = new List<ServiceBusReceivedMessage>();

            ThrowIfSessionLockLost();

            try
            {
                if (!_receiveLink.TryGetOpenedObject(out link))
                {
                    link = await _receiveLink.GetOrCreateAsync(UseMinimum(_connectionScope.SessionTimeout, timeout)).ConfigureAwait(false);
                }
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var messagesReceived = await Task.Factory.FromAsync
                (
                    (callback, state) => link.BeginReceiveRemoteMessages(
                        maxMessages,
                        TimeSpan.FromMilliseconds(20),
                        maxWaitTime ?? timeout,
                        callback,
                        state),
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
                        if (_receiveMode == ServiceBusReceiveMode.ReceiveAndDelete)
                        {
                            link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                        }
                        receivedMessages.Add(AmqpMessageConverter.AmqpMessageToSBMessage(message));
                        message.Dispose();
                    }
                }

                return receivedMessages;
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    link?.GetTrackingId(),
                    null,
                    !cancellationToken.IsCancellationRequested && HasLinkCommunicationError(link)))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/>. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to complete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// This operation can only be performed on a message that was received by this receiver
        /// when <see cref="ServiceBusReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task CompleteAsync(
            string lockToken,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) =>
                await CompleteInternalAsync(
                    lockToken,
                    timeout).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to complete.</param>
        /// <param name="timeout"></param>
        private async Task CompleteInternalAsync(
            string lockToken,
            TimeSpan timeout)
        {
            Guid lockTokenGuid = new Guid(lockToken);
            var lockTokenGuids = new[] { lockTokenGuid };
            if (_requestResponseLockedMessages.Contains(lockTokenGuid))
            {
                await DisposeMessageRequestResponseAsync(
                    lockTokenGuids,
                    timeout,
                    DispositionStatus.Completed,
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
            ThrowIfSessionLockLost();
            List<ArraySegment<byte>> deliveryTags = ConvertLockTokensToDeliveryTags(lockTokens);

            ReceivingAmqpLink receiveLink = null;
            try
            {
                ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
                Transaction ambientTransaction = Transaction.Current;
                if (ambientTransaction != null)
                {
                    transactionId = await AmqpTransactionManager.Instance.EnlistAsync(
                        ambientTransaction,
                        _connectionScope,
                        timeout).ConfigureAwait(false);
                }

                if (!_receiveLink.TryGetOpenedObject(out receiveLink))
                {
                    receiveLink = await _receiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
                }

                var disposeMessageTasks = new Task<Outcome>[deliveryTags.Count];
                var i = 0;
                foreach (ArraySegment<byte> deliveryTag in deliveryTags)
                {
                    disposeMessageTasks[i++] = receiveLink.DisposeMessageAsync(deliveryTag, transactionId, outcome, true, timeout);
                }

                Outcome[] outcomes = await Task.WhenAll(disposeMessageTasks).ConfigureAwait(false);
                Error error = null;
                foreach (Outcome item in outcomes)
                {
                    Outcome disposedOutcome = item.DescriptorCode == Rejected.Code && ((error = ((Rejected)item).Error) != null) ? item : null;
                    if (disposedOutcome != null)
                    {
                        if (error.Condition.Equals(AmqpErrorCode.NotFound))
                        {
                            ThrowLockLostException();
                        }

                        throw error.ToMessagingContractException();
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is OperationCanceledException &&
                    receiveLink != null && receiveLink.State != AmqpObjectState.Opened)
                {
                    // The link state is lost, We need to return a non-retriable error.
                    ServiceBusEventSource.Log.LinkStateLost(
                        _identifier,
                        receiveLink.Name,
                        receiveLink.State.ToString(),
                        _isSessionReceiver,
                        exception.ToString());
                    ThrowLockLostException();
                }

                throw;
            }
        }

        private void ThrowLockLostException()
        {
            if (_isSessionReceiver)
            {
                throw new ServiceBusException(
                    Resources.SessionLockExpiredOnMessageSession,
                    ServiceBusFailureReason.SessionLockLost);
            }
            throw new ServiceBusException(
                Resources.MessageLockLost,
                ServiceBusFailureReason.MessageLockLost);
        }

        /// <summary> Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to defer.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ServiceBusReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save
        /// the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessagesAsync"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task DeferAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) => await DeferInternalAsync(
                    lockToken,
                    timeout,
                    propertiesToModify).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        ///
        private Task DeferInternalAsync(
            string lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            Guid lockTokenGuid = new Guid(lockToken);
            var lockTokenGuids = new[] { lockTokenGuid };
            if (_requestResponseLockedMessages.Contains(lockTokenGuid))
            {
                return DisposeMessageRequestResponseAsync(
                    lockTokenGuids,
                    timeout,
                    DispositionStatus.Defered,
                    SessionId,
                    propertiesToModify);
            }
            return DisposeMessagesAsync(lockTokenGuids, GetDeferOutcome(propertiesToModify), timeout);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusReceivedMessage"/>. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ServiceBusReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task AbandonAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) => await AbandonInternalAsync(
                    lockToken,
                    timeout,
                    propertiesToModify).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Abandons a <see cref="ServiceBusMessage"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        private Task AbandonInternalAsync(
            string lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            Guid lockTokenGuid = new Guid(lockToken);
            var lockTokenGuids = new[] { lockTokenGuid };
            if (_requestResponseLockedMessages.Contains(lockTokenGuid))
            {
                return DisposeMessageRequestResponseAsync(
                    lockTokenGuids,
                    timeout,
                    DispositionStatus.Abandoned,
                    SessionId,
                    propertiesToModify);
            }
            return DisposeMessagesAsync(lockTokenGuids, GetAbandonOutcome(propertiesToModify), timeout);
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to subqueue.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the dead-letter queue, you will need a new
        /// <see cref="ServiceBusReceiver"/> with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ServiceBusReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task DeadLetterAsync(
            string lockToken,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) => await DeadLetterInternalAsync(
                    lockToken,
                    timeout,
                    propertiesToModify,
                    deadLetterReason,
                    deadLetterErrorDescription).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to dead-letter.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to subqueue.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        internal virtual Task DeadLetterInternalAsync(
            string lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription)
        {
            Argument.AssertNotTooLong(deadLetterReason, Constants.MaxDeadLetterReasonLength, nameof(deadLetterReason));
            Argument.AssertNotTooLong(deadLetterErrorDescription, Constants.MaxDeadLetterReasonLength, nameof(deadLetterErrorDescription));

            Guid lockTokenGuid = new Guid(lockToken);
            var lockTokenGuids = new[] { lockTokenGuid };
            if (_requestResponseLockedMessages.Contains(lockTokenGuid))
            {
                return DisposeMessageRequestResponseAsync(
                    lockTokenGuids,
                    timeout,
                    DispositionStatus.Suspended,
                    SessionId,
                    propertiesToModify,
                    deadLetterReason,
                    deadLetterErrorDescription);
            }

            return DisposeMessagesAsync(
                lockTokenGuids,
                GetRejectedOutcome(propertiesToModify, deadLetterReason, deadLetterErrorDescription),
                timeout);
        }

        private static Rejected GetRejectedOutcome(
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription)
        {
            Rejected rejected = AmqpConstants.RejectedOutcome;
            if (deadLetterReason != null || deadLetterErrorDescription != null || propertiesToModify != null)
            {
                rejected = new Rejected { Error = new Error { Condition = AmqpClientConstants.DeadLetterName, Info = new Fields() } };
                if (deadLetterReason != null)
                {
                    rejected.Error.Info.Add(AmqpMessageConstants.DeadLetterReasonHeader, deadLetterReason);
                }

                if (deadLetterErrorDescription != null)
                {
                    rejected.Error.Info.Add(AmqpMessageConstants.DeadLetterErrorDescriptionHeader, deadLetterErrorDescription);
                }

                if (propertiesToModify != null)
                {
                    foreach (KeyValuePair<string, object> pair in propertiesToModify)
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

        /// <summary>
        /// Updates the disposition status of deferred messages.
        /// </summary>
        ///
        /// <param name="lockTokens">Message lock tokens to update disposition status.</param>
        /// <param name="timeout"></param>
        /// <param name="dispositionStatus"></param>
        /// <param name="sessionId"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterDescription"></param>
        private async Task DisposeMessageRequestResponseAsync(
            Guid[] lockTokens,
            TimeSpan timeout,
            DispositionStatus dispositionStatus,
            string sessionId = null,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterDescription = null)
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
                foreach (KeyValuePair<string, object> pair in propertiesToModify)
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

            AmqpResponseMessage amqpResponseMessage = await ExecuteRequest(
                timeout,
                amqpRequestMessage).ConfigureAwait(false);

            if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
            {
                throw amqpResponseMessage.ToMessagingContractException();
            }
        }

        private static Outcome GetAbandonOutcome(IDictionary<string, object> propertiesToModify) =>
            GetModifiedOutcome(propertiesToModify, false);

        private static Outcome GetDeferOutcome(IDictionary<string, object> propertiesToModify) =>
            GetModifiedOutcome(propertiesToModify, true);

        private static List<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
        }

        private static Outcome GetModifiedOutcome(
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
                foreach (KeyValuePair<string, object> pair in propertiesToModify)
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
        /// Fetches a list of active messages without changing the state of the receiver or the message source.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number from where to read the message.</param>
        /// <param name="messageCount">The maximum number of messages that will be fetched.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// The first call to <see cref="PeekMessagesAsync"/>(long, int, CancellationToken) fetches the first active message for this receiver.
        /// Each subsequent call fetches the subsequent message in the entity.
        /// Unlike a received message, peeked message will not have lock token associated with it,
        /// and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveMessagesAsync(int, TimeSpan?, CancellationToken)"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns></returns>
        public override async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesAsync(
            long? sequenceNumber,
            int messageCount = 1,
            CancellationToken cancellationToken = default)
        {
            long seqNumber = sequenceNumber ?? LastPeekedSequenceNumber + 1;
            IReadOnlyList<ServiceBusReceivedMessage> messages = null;

            await _retryPolicy.RunOperation(
                async (timeout) =>
                messages = await PeekMessagesInternalAsync(
                    seqNumber,
                    messageCount,
                    timeout,
                    cancellationToken)
                .ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

            return messages;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesInternalAsync(
            long sequenceNumber,
            int messageCount,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var stopWatch = ValueStopwatch.StartNew();

            AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.PeekMessageOperation,
                    timeout,
                    null);

            if (_receiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
            {
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
            }

            amqpRequestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = sequenceNumber;
            amqpRequestMessage.Map[ManagementConstants.Properties.MessageCount] = messageCount;

            if (!string.IsNullOrWhiteSpace(SessionId))
            {
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;
            }

            RequestResponseAmqpLink link = await _managementLink.GetOrCreateAsync(
                UseMinimum(_connectionScope.SessionTimeout,
                timeout.CalculateRemaining(stopWatch.GetElapsedTime())))
                .ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            using AmqpMessage responseAmqpMessage = await link.RequestAsync(
                amqpRequestMessage.AmqpMessage,
                timeout.CalculateRemaining(stopWatch.GetElapsedTime()))
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(responseAmqpMessage);

            var messages = new List<ServiceBusReceivedMessage>();
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

            throw amqpResponseMessage.ToMessagingContractException();
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public override async Task<DateTimeOffset> RenewMessageLockAsync(
            string lockToken,
            CancellationToken cancellationToken)
        {
            DateTimeOffset lockedUntil = DateTimeOffset.MinValue;
            await _retryPolicy.RunOperation(
                async (timeout) =>
                {
                    lockedUntil = await RenewMessageLockInternalAsync(
                        lockToken,
                        timeout).ConfigureAwait(false);
                },
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
            return lockedUntil;
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        ///
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <param name="timeout"></param>
        private async Task<DateTimeOffset> RenewMessageLockInternalAsync(
            string lockToken,
            TimeSpan timeout)
        {
            DateTimeOffset lockedUntil;

            // Create an AmqpRequest Message to renew  lock
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                ManagementConstants.Operations.RenewLockOperation,
                timeout,
                null);

            if (_receiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
            {
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
            }
            amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = new[] { new Guid(lockToken) };

            AmqpResponseMessage amqpResponseMessage = await ExecuteRequest(
                timeout,
                amqpRequestMessage).ConfigureAwait(false);

            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
            {
                DateTime[] lockedUntilUtcTimes = amqpResponseMessage.GetValue<DateTime[]>(ManagementConstants.Properties.Expirations);
                lockedUntil = lockedUntilUtcTimes[0];
            }
            else
            {
                throw amqpResponseMessage.ToMessagingContractException();
            }

            return lockedUntil;
        }

        private async Task<AmqpResponseMessage> ExecuteRequest(TimeSpan timeout, AmqpRequestMessage amqpRequestMessage)
        {
            ThrowIfSessionLockLost();
            AmqpResponseMessage amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                _connectionScope,
                _managementLink,
                amqpRequestMessage,
                timeout).ConfigureAwait(false);
            return amqpResponseMessage;
        }

        /// <summary>
        /// Renews the lock on the session specified by the <see cref="SessionId"/>. The lock will be renewed based on the setting specified on the entity.
        /// </summary>
        public override async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            DateTimeOffset lockedUntil;
            await _retryPolicy.RunOperation(
                async (timeout) =>
                {
                    lockedUntil = await RenewSessionLockInternal(
                        timeout).ConfigureAwait(false);
                },
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
            SessionLockedUntil = lockedUntil;
        }

        internal async Task<DateTimeOffset> RenewSessionLockInternal(TimeSpan timeout)
        {
            // Create an AmqpRequest Message to renew  lock
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, timeout, null);

            if (!_receiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
            {
                receiveLink = await _receiveLink.GetOrCreateAsync(UseMinimum(_connectionScope.SessionTimeout, timeout)).ConfigureAwait(false);
            }
            amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;

            amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;

            AmqpResponseMessage amqpResponseMessage = await ExecuteRequest(
                timeout,
                amqpRequestMessage).ConfigureAwait(false);

            DateTimeOffset lockedUntil;
            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
            {
                lockedUntil = amqpResponseMessage.GetValue<DateTime>(ManagementConstants.Properties.Expiration);
            }
            else
            {
                throw amqpResponseMessage.ToMessagingContractException();
            }
            return lockedUntil;
        }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The session state as <see cref="BinaryData"/>.</returns>
        public override async Task<BinaryData> GetStateAsync(CancellationToken cancellationToken = default)
        {
            BinaryData sessionState = default;
            await _retryPolicy.RunOperation(
                async (timeout) =>
                {
                    sessionState = await GetStateInternal(timeout).ConfigureAwait(false);
                },
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
            return sessionState;
        }

        internal async Task<BinaryData> GetStateInternal(TimeSpan timeout)
        {
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.GetSessionStateOperation, timeout, null);

            if (_receiveLink.TryGetOpenedObject(out var receiveLink))
            {
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
            }

            amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;

            var amqpResponseMessage = await ExecuteRequest(timeout, amqpRequestMessage).ConfigureAwait(false);

            BinaryData sessionState = default;
            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
            {
                if (amqpResponseMessage.Map[ManagementConstants.Properties.SessionState] != null)
                {
                    sessionState = new BinaryData(amqpResponseMessage.GetValue<ArraySegment<byte>>(ManagementConstants.Properties.SessionState).Array ?? Array.Empty<byte>());
                }
            }
            else
            {
                throw amqpResponseMessage.ToMessagingContractException();
            }

            return sessionState;
        }

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetStateAsync"/>.
        /// </summary>
        ///
        /// <param name="sessionState">A <see cref="BinaryData"/> of session state</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task SetStateAsync(
            BinaryData sessionState,
            CancellationToken cancellationToken)
        {
            await _retryPolicy.RunOperation(
                async (timeout) =>
                {
                    await SetStateInternal(
                        sessionState,
                        timeout).ConfigureAwait(false);
                },
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
        }

        internal async Task SetStateInternal(
            BinaryData sessionState,
            TimeSpan timeout)
        {
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.SetSessionStateOperation, timeout, null);

            if (_receiveLink.TryGetOpenedObject(out var receiveLink))
            {
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
            }

            amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;

            if (sessionState != null)
            {
                var value = new ArraySegment<byte>(sessionState.ToArray());
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = value;
            }
            else
            {
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = null;
            }

            var amqpResponseMessage = await ExecuteRequest(timeout, amqpRequestMessage).ConfigureAwait(false);
            if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
            {
                throw amqpResponseMessage.ToMessagingContractException();
            }
        }

        /// <summary>
        /// Receives a <see cref="IList{Message}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        /// <param name="sequenceNumbers">A <see cref="IList{SequenceNumber}"/> containing the sequence numbers to receive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public override async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(
            long[] sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<ServiceBusReceivedMessage> messages = null;
            await _retryPolicy.RunOperation(
                async (timeout) => messages = await ReceiveDeferredMessagesAsyncInternal(
                    sequenceNumbers,
                    timeout).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
            return messages;
        }

        internal virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsyncInternal(
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
                amqpRequestMessage.Map[ManagementConstants.Properties.ReceiverSettleMode] = (uint)(_receiveMode == ServiceBusReceiveMode.ReceiveAndDelete ? 0 : 1);
                if (!string.IsNullOrWhiteSpace(SessionId))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = SessionId;
                }

                var response = await ExecuteRequest(
                    timeout,
                    amqpRequestMessage).ConfigureAwait(false);

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
                            _requestResponseLockedMessages.AddOrUpdate(lockToken, message.LockedUntil);
                        }

                        messages.Add(message);
                    }
                }
                else
                {
                    throw response.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(exception))
                    .Throw();

                throw; // will never be reached
            }

            return messages;
        }

        /// <summary>
        /// Closes the connection to the transport receiver instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public override async Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return;
            }

            _closed = true;

            if (_receiveLink?.TryGetOpenedObject(out var _) == true)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                await _receiveLink.CloseAsync().ConfigureAwait(false);
            }

            if (_managementLink?.TryGetOpenedObject(out var _) == true)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                await _managementLink.CloseAsync().ConfigureAwait(false);
            }

            _receiveLink?.Dispose();
            _managementLink?.Dispose();
        }

        private void OnReceiverLinkClosed(object receiver, EventArgs e)
        {
            var receivingAmqpLink = (ReceivingAmqpLink)receiver;
            if (_isSessionReceiver && receivingAmqpLink != null)
            {
                Exception exception = receivingAmqpLink.GetInnerException();
                if (((exception is ServiceBusException sbException) && sbException.Reason != ServiceBusFailureReason.SessionLockLost) ||
                    !(exception is ServiceBusException))
                {
                    exception = new ServiceBusException(
                        Resources.SessionLockExpiredOnMessageSession,
                        ServiceBusFailureReason.SessionLockLost,
                        innerException: exception);
                }
                LinkException = exception;
            }
            ServiceBusEventSource.Log.ReceiveLinkClosed(
                _identifier,
                SessionId,
                receiver);
        }

        private void OnManagementLinkClosed(object managementLink, EventArgs e) =>
        ServiceBusEventSource.Log.ManagementLinkClosed(
            _identifier,
            managementLink);

        /// <summary>
        /// Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns>The smaller of the two specified intervals.</returns>
        private static TimeSpan UseMinimum(
            TimeSpan firstOption,
            TimeSpan secondOption) =>
            (firstOption < secondOption) ? firstOption : secondOption;

        /// <summary>
        /// Opens an AMQP link for use with receiver operations.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task OpenLinkAsync(CancellationToken cancellationToken)
        {
            ReceivingAmqpLink link = null;
            await _retryPolicy.RunOperation(
               async (timeout) =>
               link = await _receiveLink.GetOrCreateAsync(timeout).ConfigureAwait(false),
               _connectionScope,
               cancellationToken).ConfigureAwait(false);
        }

        private bool HasLinkCommunicationError(ReceivingAmqpLink link) =>
            !_closed && (link?.IsClosing() ?? false);

        private void ThrowIfSessionLockLost()
        {
            if (_isSessionReceiver && LinkException != null)
            {
                throw LinkException;
            }
        }
    }
}
