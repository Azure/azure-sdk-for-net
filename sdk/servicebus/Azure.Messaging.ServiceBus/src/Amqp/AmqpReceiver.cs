// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Shared;
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
        /// <summary>
        /// Indicates whether or not this receiver has been closed by the user.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the receiver is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed => _closed;

        private volatile bool _closed;

        /// <summary>
        /// Indicates whether or not the session link has been closed.
        /// This is useful for session receiver scenarios because once the link is closed for a
        /// session receiver it will not be reopened.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the receiver link was closed; otherwise, <c>false</c>.
        /// </value>
        public override bool IsSessionLinkClosed => _isSessionReceiver && LinkException != null;

        /// <summary>
        /// The identifier for the receiver.
        /// </summary>
        public string Identifier { get; }

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
        private readonly FaultTolerantAmqpObject<ReceivingAmqpLink> _receiveLink;
        private readonly FaultTolerantAmqpObject<RequestResponseAmqpLink> _managementLink;

        private const int SizeOfGuidInBytes = 16;

        /// <summary>
        /// Gets the sequence number of the last peeked message.
        /// </summary>
        public long LastPeekedSequenceNumber { get; private set; }

        /// <summary>
        /// The Session Id associated with the receiver.
        /// </summary>
        public override string SessionId { get; protected set; }
        public override DateTimeOffset SessionLockedUntil { get; protected set; }

        public override int PrefetchCount
        {
            get => _prefetchCount;
            set
            {
                Argument.AssertAtLeast(value, 0, nameof(PrefetchCount));
                _prefetchCount = value;
                if (_receiveLink.TryGetOpenedObject(out var link))
                {
                    link.SetTotalLinkCredit((uint)value, true, true);
                }
            }
        }

        private volatile int _prefetchCount;

        private Exception LinkException { get; set; }

        /// <summary>
        ///    The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.
        /// </summary>
        private readonly AmqpMessageConverter _messageConverter;

        /// <summary>
        /// A map of locked messages received using the management link.
        /// </summary>
        internal readonly ConcurrentExpiringSet<Guid> RequestResponseLockedMessages;

        private readonly bool _isProcessor;

        private static readonly IReadOnlyList<ServiceBusReceivedMessage> s_emptyReceivedMessageList = Array.Empty<ServiceBusReceivedMessage>();

        private static readonly IReadOnlyList<AmqpMessage> s_emptyAmqpMessageList = Array.Empty<AmqpMessage>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AmqpReceiver"/> class.
        /// </summary>
        ///
        /// <param name="entityPath">The name of the Service Bus entity from which events will be consumed.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="connectionScope">The AMQP connection context for operations .</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="identifier">The identifier for the sender.</param>
        /// <param name="sessionId">The session ID to receive messages for.</param>
        /// <param name="isSessionReceiver">Whether or not this is a sessionful receiver link.</param>
        /// <param name="isProcessor">Whether or not the receiver is being created for a processor.</param>
        /// <param name="messageConverter">The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the
        /// open link operation. Only applicable for session receivers.</param>
        ///
        /// <remarks>
        /// As an internal type, this class performs only basic sanity checks against its arguments.  It
        /// is assumed that callers are trusted and have performed deep validation.
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
            bool isSessionReceiver,
            bool isProcessor,
            AmqpMessageConverter messageConverter,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            _entityPath = entityPath;
            _connectionScope = connectionScope;
            _retryPolicy = retryPolicy;
            _isSessionReceiver = isSessionReceiver;
            _isProcessor = isProcessor;
            _receiveMode = receiveMode;
            _prefetchCount = (int)prefetchCount;
            Identifier = identifier;
            RequestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();
            SessionId = sessionId;

            _receiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    OpenReceiverLinkAsync(
                        timeout: timeout,
                        prefetchCount: prefetchCount,
                        receiveMode: receiveMode,
                        identifier: identifier,
                        // The cancellationToken will always be CancellationToken.None for non-session receivers
                        // it is okay to register the user provided cancellationToken from the AcceptNextSessionAsync call in
                        // the fault tolerant object because session receivers are never reconnected.
                        cancellationToken: cancellationToken),
                link => _connectionScope.CloseLink(link));

            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => OpenManagementLinkAsync(timeout),
                link => _connectionScope.CloseLink(link));
            _messageConverter = messageConverter;
        }

        private async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(
            TimeSpan timeout)
        {
            RequestResponseAmqpLink link = await _connectionScope.OpenManagementLinkAsync(
                _entityPath,
                Identifier,
                timeout,
                CancellationToken.None).ConfigureAwait(false);
            link.Closed += OnManagementLinkClosed;
            return link;
        }

        private async Task<ReceivingAmqpLink> OpenReceiverLinkAsync(
            TimeSpan timeout,
            uint prefetchCount,
            ServiceBusReceiveMode receiveMode,
            string identifier,
            CancellationToken cancellationToken)
        {
            ServiceBusEventSource.Log.CreateReceiveLinkStart(Identifier);

            try
            {
                ReceivingAmqpLink link = await _connectionScope.OpenReceiverLinkAsync(
                    identifier: identifier,
                    entityPath: _entityPath,
                    timeout: timeout,
                    prefetchCount: prefetchCount,
                    receiveMode: receiveMode,
                    sessionId: SessionId,
                    isSessionReceiver: _isSessionReceiver,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                if (_isSessionReceiver)
                {
                    SessionLockedUntil = link.Settings.Properties.TryGetValue<long>(
                        AmqpClientConstants.LockedUntilUtc, out var lockedUntilUtcTicks)
                        ? new DateTime(lockedUntilUtcTicks, DateTimeKind.Utc)
                        : DateTime.MinValue;

                    var source = (Source)link.Settings.Source;
                    if (!source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var tempSessionId))
                    {
                        link.Session.SafeClose();
                        throw new ServiceBusException(true, Resources.SessionFilterMissing);
                    }

                    if (tempSessionId == null)
                    {
                        link.Session.SafeClose();
                        throw new ServiceBusException(true, Resources.AmqpFieldSessionId);
                    }
                    // This will only have changed if sessionId was left blank when constructing the session
                    // receiver.
                    SessionId = tempSessionId;
                }
                ServiceBusEventSource.Log.CreateReceiveLinkComplete(Identifier, SessionId);
                link.Closed += OnReceiverLinkClosed;
                return link;
            }
            catch (TimeoutException)
                when (_isSessionReceiver)
            {
                // When this occurs during accepting a session, it will be logged from
                // ServiceBusSessionReceiver.CreateSessionReceiverAsync so it would be redundant
                // to log here.
                throw;
            }
            catch (AmqpException amqpException)
                when (_isSessionReceiver && amqpException.Error.Condition.Equals(AmqpClientConstants.TimeoutError))
            {
                // When this occurs during accepting a session, it will be logged from
                // ServiceBusSessionReceiver.CreateSessionReceiverAsync so it would be redundant
                // to log here. This exception occurs if we get back a timeout error from the service before the client timeout.
                // Both exceptions would be translated to a ServiceBusException with ServiceBusFailureReason.ServiceTimeout before being
                // thrown to the user.
                throw;
            }
            catch (OperationCanceledException opEx)
                when (_isSessionReceiver && opEx is not TaskCanceledException)
            {
                // Do not log as this will be translated to a TimeoutException and logged from
                // ServiceBusSessionReceiver.CreateSessionReceiverAsync.
                throw;
            }
            catch (OperationCanceledException)
                when (_isProcessor && cancellationToken.IsCancellationRequested)
            {
                // do not log this as the processor is shutting down
                throw;
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CreateReceiveLinkException(Identifier, ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusReceivedMessage" /> from the entity using <see cref="ServiceBusReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessages">The maximum number of messages that will be received.</param>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for the first message before returning an empty list if no messages have been received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>List of messages received. Returns an empty list if no message is found.</returns>
        public override async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsync(
            int maxMessages,
            TimeSpan? maxWaitTime,
            CancellationToken cancellationToken)
        {
            return await _retryPolicy.RunOperation(static async (value, timeout, token) =>
            {
                var (receiver, maxMessages, maxWaitTime) = value;
                return await receiver.ReceiveMessagesAsyncInternal(
                    maxMessages,
                    maxWaitTime,
                    timeout,
                    token).ConfigureAwait(false);
            },
                (this, maxMessages, maxWaitTime),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusReceivedMessage" /> from the Service Bus entity.
        /// </summary>
        ///
        /// <param name="maxMessages">The maximum number of messages to receive.</param>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for the first message before returning an empty list if no messages have been received.
        ///     If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.</param>
        /// <param name="timeout">The per-try timeout specified in the RetryOptions.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The list of <see cref="ServiceBusMessage" /> from the Service Bus entity this receiver is associated with. If no messages are present, an empty list is returned.</returns>
        private async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsyncInternal(
            int maxMessages,
            TimeSpan? maxWaitTime,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var link = default(ReceivingAmqpLink);
            CancellationTokenRegistration registration;

            ThrowIfSessionLockLost();

            try
            {
                if (!_receiveLink.TryGetOpenedObject(out link))
                {
                    link = await _receiveLink.GetOrCreateAsync(timeout, cancellationToken)
                        .ConfigureAwait(false);
                }

                var messagesReceived = await link.ReceiveMessagesAsync(
                    maxMessages,
                    TimeSpan.FromMilliseconds(20),
                    maxWaitTime ?? timeout,
                    cancellationToken).ConfigureAwait(false);

                IReadOnlyCollection<AmqpMessage> messageList =
                    messagesReceived as IReadOnlyCollection<AmqpMessage> ?? messagesReceived?.ToList() ?? s_emptyAmqpMessageList;

                // If this is a session receiver and we didn't receive all requested messages, we need to drain the credits
                // to ensure FIFO ordering within each session. We exclude session processors, since those will always receive a single message
                // at a time.  If there are no messages, the session will be closed unless the processor was configured to receive from specific sessions.
                // The session won't be closed in the case that MaxConcurrentCallsPerSession > 1, but with concurrency, it is not possible to guarantee ordering.
                if (_isSessionReceiver && (!_isProcessor || SessionId != null) && messageList.Count < maxMessages)
                {
                    await link.DrainAsyc(cancellationToken).ConfigureAwait(false);

                    // These workarounds are necessary in order to resume prefetching after the link has been drained
                    // https://github.com/Azure/azure-amqp/issues/252#issuecomment-1942734342
                    if (_prefetchCount > 0)
                    {
                        link.Settings.TotalLinkCredit = 0;
                        link.SetTotalLinkCredit((uint)_prefetchCount, true, true);
                    }
                }

                List<ServiceBusReceivedMessage> receivedMessages = null;
                // If event messages were received, then package them for consumption and
                // return them.
                foreach (AmqpMessage message in messageList)
                {
                    // Getting the count of the underlying collection is good for performance/allocations to prevent the list from growing
                    receivedMessages ??= new List<ServiceBusReceivedMessage>(messageList.Count);

                    if (_receiveMode == ServiceBusReceiveMode.ReceiveAndDelete)
                    {
                        link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                    }

                    receivedMessages.Add(_messageConverter.AmqpMessageToSBReceivedMessage(message));
                    message.Dispose();
                }

                return receivedMessages ?? s_emptyReceivedMessageList;
            }
            catch (OperationCanceledException)
            {
                throw;
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
            finally
            {
                registration.Dispose();
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
            Guid lockToken,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, _) =>
                {
                    var (receiver, lockToken) = value;
                    await receiver.CompleteInternalAsync(
                        lockToken,
                        timeout).ConfigureAwait(false);
                },
                (this, lockToken),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/> using a lock token. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to complete.</param>
        /// <param name="timeout">The timeout for the operation.</param>
        private async Task CompleteInternalAsync(
            Guid lockToken,
            TimeSpan timeout)
        {
            ThrowIfSessionLockLost();
            if (RequestResponseLockedMessages.Contains(lockToken))
            {
                await DisposeMessageRequestResponseAsync(
                    lockToken,
                    timeout,
                    DispositionStatus.Completed,
                    SessionId).ConfigureAwait(false);
                return;
            }
            await DisposeMessageAsync(lockToken, AmqpConstants.AcceptedOutcome, DispositionStatus.Completed, timeout).ConfigureAwait(false);
        }

        /// <summary>
        /// Settles a <see cref="ServiceBusReceivedMessage"/> using a lock token.
        /// </summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to complete.</param>
        /// <param name="outcome">The outcome of the message - used when disposing over receive link.</param>
        /// <param name="disposition">The disposition of the message - used when disposing over the management link.</param>
        /// <param name="timeout">The timeout for the operation.</param>
        /// <param name="propertiesToModify">Properties to modify when deadlettering, deferring, or abandoning.</param>
        /// <param name="deadLetterReason">Dead letter reason. Only valid when deadlettering.</param>
        /// <param name="deadLetterDescription">Dead letter description. Only valid when deadlettering.</param>
        private async Task DisposeMessageAsync(
            Guid lockToken,
            Outcome outcome,
            DispositionStatus disposition,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterDescription = null)
        {
            byte[] bufferForLockToken = ArrayPool<byte>.Shared.Rent(SizeOfGuidInBytes);
            GuidUtilities.WriteGuidToBuffer(lockToken, bufferForLockToken.AsSpan(0, SizeOfGuidInBytes));

            ArraySegment<byte> deliveryTag = new ArraySegment<byte>(bufferForLockToken, 0, SizeOfGuidInBytes);
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

                Outcome outcomeResult = await receiveLink
                    .DisposeMessageAsync(deliveryTag, transactionId, outcome, true, timeout).ConfigureAwait(false);
                Error error = null;
                Outcome disposedOutcome =
                    outcomeResult.DescriptorCode == Rejected.Code && ((error = ((Rejected)outcomeResult).Error) != null)
                        ? outcomeResult
                        : null;
                if (disposedOutcome != null)
                {
                    if (error.Condition.Equals(AmqpErrorCode.NotFound))
                    {
                        if (_isSessionReceiver)
                        {
                            ThrowLockLostException();
                        }

                        // The message was not found on the link which can occur as a result of a reconnect.
                        // Attempt to settle the message over the management link.
                        await DisposeMessageRequestResponseAsync(
                            lockToken,
                            timeout,
                            disposition,
                            propertiesToModify: propertiesToModify,
                            deadLetterReason: deadLetterReason,
                            deadLetterDescription: deadLetterDescription).ConfigureAwait(false);
                        return;
                    }

                    throw error.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                if (exception is OperationCanceledException &&
                    receiveLink != null && receiveLink.State != AmqpObjectState.Opened)
                {
                    // The link state is lost, We need to return a non-retriable error.
                    ServiceBusEventSource.Log.LinkStateLost(
                        Identifier,
                        receiveLink.Name,
                        receiveLink.State.ToString(),
                        _isSessionReceiver,
                        exception.ToString());
                    ThrowLockLostException();
                }

                throw;
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(bufferForLockToken);
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
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockTokenGuid"/>,
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
            Guid lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, _) =>
                {
                    var (receiver, lockToken, properties) = value;
                    await receiver.DeferInternalAsync(
                        lockToken,
                        timeout,
                        properties).ConfigureAwait(false);
                },
                (this, lockToken, propertiesToModify),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="timeout">The timeout for the operation.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        ///
        private Task DeferInternalAsync(
            Guid lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            ThrowIfSessionLockLost();
            if (RequestResponseLockedMessages.Contains(lockToken))
            {
                return DisposeMessageRequestResponseAsync(
                    lockToken,
                    timeout,
                    DispositionStatus.Defered,
                    SessionId,
                    propertiesToModify);
            }
            return DisposeMessageAsync(
                lockToken,
                GetDeferOutcome(propertiesToModify),
                DispositionStatus.Defered,
                timeout,
                propertiesToModify: propertiesToModify);
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
            Guid lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, _) =>
                {
                    var (receiver, lockToken, properties) = value;
                    await receiver.AbandonInternalAsync(
                        lockToken,
                        timeout,
                        properties).ConfigureAwait(false);
                },
                (this, lockToken, propertiesToModify),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Abandons a <see cref="ServiceBusMessage"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="timeout">The timeout for the operation.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        private Task AbandonInternalAsync(
            Guid lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            ThrowIfSessionLockLost();
            if (RequestResponseLockedMessages.Contains(lockToken))
            {
                return DisposeMessageRequestResponseAsync(
                    lockToken,
                    timeout,
                    DispositionStatus.Abandoned,
                    SessionId,
                    propertiesToModify);
            }
            return DisposeMessageAsync(
                lockToken,
                GetAbandonOutcome(propertiesToModify),
                DispositionStatus.Abandoned,
                timeout,
                propertiesToModify: propertiesToModify);
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
        /// You can use <see cref="ServiceBusReceiverOptions.SubQueue"/> with <see cref="SubQueue.DeadLetter"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ServiceBusReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task DeadLetterAsync(
            Guid lockToken,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, _) =>
                {
                    var (receiver, lockToken, propertiesToModify, deadLetterReason, deadLetterErrorDescription) = value;
                    await receiver.DeadLetterInternalAsync(
                        lockToken,
                        timeout,
                        propertiesToModify,
                        deadLetterReason,
                        deadLetterErrorDescription).ConfigureAwait(false);
                },
                (this, lockToken, propertiesToModify, deadLetterReason, deadLetterErrorDescription),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to dead-letter.</param>
        /// <param name="timeout">The timeout for the operation.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to subqueue.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        internal virtual Task DeadLetterInternalAsync(
            Guid lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription)
        {
            Argument.AssertNotTooLong(deadLetterReason, Constants.MaxDeadLetterReasonLength, nameof(deadLetterReason));
            Argument.AssertNotTooLong(deadLetterErrorDescription, Constants.MaxDeadLetterReasonLength, nameof(deadLetterErrorDescription));
            ThrowIfSessionLockLost();

            if (RequestResponseLockedMessages.Contains(lockToken))
            {
                return DisposeMessageRequestResponseAsync(
                    lockToken,
                    timeout,
                    DispositionStatus.Suspended,
                    SessionId,
                    propertiesToModify,
                    deadLetterReason,
                    deadLetterErrorDescription);
            }

            return DisposeMessageAsync(
                lockToken,
                GetRejectedOutcome(propertiesToModify, deadLetterReason, deadLetterErrorDescription),
                DispositionStatus.Suspended,
                timeout,
                propertiesToModify,
                deadLetterReason,
                deadLetterErrorDescription);
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
        /// <param name="lockToken">Message lock token to update disposition status.</param>
        /// <param name="timeout"></param>
        /// <param name="dispositionStatus"></param>
        /// <param name="sessionId"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterDescription"></param>
        private async Task DisposeMessageRequestResponseAsync(
            Guid lockToken,
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

            amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = new Guid[] { lockToken };
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
        /// Also, unlike <see cref="ReceiveMessagesAsync"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns></returns>
        public override async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesAsync(
            long? sequenceNumber,
            int messageCount = 1,
            CancellationToken cancellationToken = default)
        {
            long seqNumber = sequenceNumber ?? LastPeekedSequenceNumber + 1;
            return await _retryPolicy.RunOperation(
                static async (value, timeout, token) =>
                {
                    var (receiver, seqNumber, messageCount) = value;
                    return await receiver.PeekMessagesInternalAsync(
                            seqNumber,
                            messageCount,
                            timeout,
                            token)
                        .ConfigureAwait(false);
                },
                (this, seqNumber, messageCount),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
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
                timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                cancellationToken)
                .ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            using AmqpMessage responseAmqpMessage = await link.RequestAsync(
                amqpRequestMessage.AmqpMessage,
                timeout.CalculateRemaining(stopWatch.GetElapsedTime()))
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(responseAmqpMessage);

            List<ServiceBusReceivedMessage> messages = null;
            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
            {
                ServiceBusReceivedMessage message = null;
                var messageList = amqpResponseMessage.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                // not using foreach for better performance
                for (var index = 0; index < messageList.Count; index++)
                {
                    AmqpMap entry = messageList[index];
                    // Getting the count of the underlying collection is good for performance/allocations to prevent the list from growing
                    messages ??= messageList is IReadOnlyCollection<AmqpMap> readOnlyList
                        ? new List<ServiceBusReceivedMessage>(readOnlyList.Count)
                        : new List<ServiceBusReceivedMessage>();

                    var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                    var amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                    message = _messageConverter.AmqpMessageToSBReceivedMessage(amqpMessage, true);
                    messages.Add(message);
                }

                if (message != null)
                {
                    LastPeekedSequenceNumber = message.SequenceNumber;
                }
                return messages ?? s_emptyReceivedMessageList;
            }

            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NoContent ||
                (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NotFound && Equals(AmqpClientConstants.MessageNotFoundError, amqpResponseMessage.GetResponseErrorCondition())))
            {
                return s_emptyReceivedMessageList;
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
            Guid lockToken,
            CancellationToken cancellationToken)
        {
            return await _retryPolicy.RunOperation(
                static async (value, timeout, _) =>
                {
                    var (receiver, lockToken) = value;
                    return await receiver.RenewMessageLockInternalAsync(
                        lockToken,
                        timeout).ConfigureAwait(false);
                },
                (this, lockToken),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
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
            Guid lockToken,
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
            amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = new Guid[] { lockToken };

            AmqpResponseMessage amqpResponseMessage = await ExecuteRequest(
                timeout,
                amqpRequestMessage).ConfigureAwait(false);

            if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
            {
                DateTime[] lockedUntilUtcTimes = amqpResponseMessage.GetValue<DateTime[]>(ManagementConstants.Properties.Expirations);
                lockedUntil = lockedUntilUtcTimes[0];
                if (RequestResponseLockedMessages.Contains(lockToken))
                {
                    RequestResponseLockedMessages.AddOrUpdate(lockToken, lockedUntil);
                }
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
            var lockedUntil = await _retryPolicy.RunOperation(
                static async (receiver, timeout, _) => await receiver.RenewSessionLockInternal(
                    timeout).ConfigureAwait(false),
                this,
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
            SessionLockedUntil = lockedUntil;
        }

        internal async Task<DateTimeOffset> RenewSessionLockInternal(TimeSpan timeout)
        {
            // Create an AmqpRequest Message to renew  lock
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, timeout, null);

            if (_receiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
            {
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
            }

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
            return await _retryPolicy.RunOperation(
                static async (receiver, timeout, _) => await receiver.GetStateInternal(timeout).ConfigureAwait(false),
                this,
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
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
                static async (value, timeout, _) =>
                {
                    var (receiver, sessionState) = value;
                    await receiver.SetStateInternal(
                        sessionState,
                        timeout).ConfigureAwait(false);
                },
                (this, sessionState),
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
        /// <returns>Messages identified by sequence number are returned.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public override async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(
            long[] sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            return await _retryPolicy.RunOperation(
                static async (value, timeout, _) =>
                {
                    var (receiver, sequenceNumbers) = value;
                    return await receiver.ReceiveDeferredMessagesAsyncInternal(
                        sequenceNumbers,
                        timeout).ConfigureAwait(false);
                },
                (this, sequenceNumbers),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
        }

        internal virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsyncInternal(
            long[] sequenceNumbers,
            TimeSpan timeout)
        {
            List<ServiceBusReceivedMessage> messages = null;
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
                    // not using foreach for better performance
                    for (var index = 0; index < amqpMapList.Count; index++)
                    {
                        var entry = amqpMapList[index];
                        // Getting the count of the underlying collection is good for performance/allocations to prevent the list from growing
                        messages ??= amqpMapList is IReadOnlyCollection<AmqpMap> readOnlyList
                            ? new List<ServiceBusReceivedMessage>(readOnlyList.Count)
                            : new List<ServiceBusReceivedMessage>();

                        var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        var amqpMessage =
                            AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        var message = _messageConverter.AmqpMessageToSBReceivedMessage(amqpMessage);
                        if (entry.TryGetValue<Guid>(ManagementConstants.Properties.LockToken, out var lockToken))
                        {
                            message.LockTokenGuid = lockToken;
                            RequestResponseLockedMessages.AddOrUpdate(lockToken, message.LockedUntil);
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

            return messages ?? s_emptyReceivedMessageList;
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

            RequestResponseLockedMessages.Dispose();

            if (_receiveLink?.TryGetOpenedObject(out var link) == true)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Allow in-flight messages to drain so that they do not remain locked by the service after closing the link.

                if (!_isSessionReceiver && link.LinkCredit > 0)
                {
                    await link.DrainAsyc(cancellationToken).ConfigureAwait(false);
                }

                await _receiveLink.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }

            if (_managementLink?.TryGetOpenedObject(out var _) == true)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                await _managementLink.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }

            _receiveLink?.Dispose();
            _managementLink?.Dispose();
        }

        private void OnReceiverLinkClosed(object receiver, EventArgs e)
        {
            var receivingAmqpLink = (ReceivingAmqpLink)receiver;
            if (receivingAmqpLink != null)
            {
                Exception exception = receivingAmqpLink.GetInnerException();
                if (_isSessionReceiver && ((exception is ServiceBusException sbException) && sbException.Reason != ServiceBusFailureReason.SessionLockLost) ||
                    !(exception is ServiceBusException))
                {
                    exception = new ServiceBusException(
                        Resources.SessionLockExpiredOnMessageSession,
                        ServiceBusFailureReason.SessionLockLost,
                        innerException: exception);
                }
                LinkException = exception;
            }

            if (IsSessionLinkClosed)
            {
                // Clean up and dispose the underlying resources. The receive link should already be closed, but management link may need to be
                // closed as well.
                _ = CloseAsync(CancellationToken.None);
            }

            ServiceBusEventSource.Log.ReceiveLinkClosed(
                Identifier,
                SessionId,
                receiver);
        }

        private void OnManagementLinkClosed(object managementLink, EventArgs e) =>
        ServiceBusEventSource.Log.ManagementLinkClosed(
            Identifier,
            managementLink);

        /// <summary>
        /// Opens an AMQP link for use with session receiver operations.
        /// </summary>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task OpenLinkAsync(CancellationToken cancellationToken)
        {
            _ = await _retryPolicy.RunOperation(
                static async (receiveLink, timeout, token) =>
                    await receiveLink.GetOrCreateAsync(timeout, token).ConfigureAwait(false),
                _receiveLink,
                _connectionScope,
                cancellationToken,
                true).ConfigureAwait(false);
        }

        private bool HasLinkCommunicationError(ReceivingAmqpLink link) =>
            !_closed && (link?.IsClosing() ?? false);

        private void ThrowIfSessionLockLost()
        {
            if (IsSessionLinkClosed)
            {
                throw LinkException;
            }
        }
    }
}
