﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    internal class AmqpReceiver : TransportReceiver
    {
        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

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
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        private readonly ReceiveMode _receiveMode;
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
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
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
            ReceiveMode receiveMode,
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
            ConnectionScope = connectionScope;
            _retryPolicy = retryPolicy;
            _isSessionReceiver = isSessionReceiver;
            _receiveMode = receiveMode;
            _identifier = identifier;
            _requestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();

            _receiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    ConnectionScope.OpenReceiverLinkAsync(
                        entityPath: _entityPath,
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
                timeout => ConnectionScope.OpenManagementLinkAsync(
                    _entityPath,
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
        /// Receives a batch of <see cref="ServiceBusReceivedMessage" /> from the entity using <see cref="ReceiveMode"/> mode.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>List of messages received. Returns null if no message is found.</returns>
        public override async Task<IList<ServiceBusReceivedMessage>> ReceiveBatchAsync(
            int maximumMessageCount,
            CancellationToken cancellationToken)
        {
            IList<ServiceBusReceivedMessage> messages = null;
            await _retryPolicy.RunOperation(async (timeout) =>
            {
                messages = await ReceiveBatchAsyncInternal(
                    maximumMessageCount,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            ConnectionScope,
            cancellationToken).ConfigureAwait(false);

            return messages;
        }

        /// <summary>
        /// Receives a batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        private async Task<IList<ServiceBusReceivedMessage>> ReceiveBatchAsyncInternal(
            int maximumMessageCount,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var link = default(ReceivingAmqpLink);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedMessages = new List<ServiceBusReceivedMessage>();

            var stopWatch = Stopwatch.StartNew();

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
                foreach (AmqpMessage message in amqpMessages)
                {
                    if (_receiveMode == ReceiveMode.ReceiveAndDelete)
                    {
                        link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                    }
                    receivedMessages.Add(AmqpMessageConverter.AmqpMessageToSBMessage(message));
                    message.Dispose();
                }
            }

            stopWatch.Stop();
            return receivedMessages;
        }

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/>. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// This operation can only be performed on a message that was received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public override async Task CompleteAsync(
            IEnumerable<string> lockTokens,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) =>
                await CompleteInternalAsync(
                    lockTokens,
                    timeout).ConfigureAwait(false),
                ConnectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="timeout"></param>
        private async Task CompleteInternalAsync(
            IEnumerable<string> lockTokens,
            TimeSpan timeout)
        {
            Guid[] lockTokenGuids = lockTokens.Select(token => new Guid(token)).ToArray();
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
                ThrowIfSessionLockLost();
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
                        "ClientId",
                        receiveLink.Name,
                        receiveLink.State,
                        _isSessionReceiver,
                        exception);
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
                    ServiceBusException.FailureReason.SessionLockLost);
            }
            throw new ServiceBusException(
                Resources.MessageLockLost,
                ServiceBusException.FailureReason.MessageLockLost);
        }

        /// <summary> Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to defer.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using ReceiveDeferredMessageBatchAsync(IEnumerable, CancellationToken).
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
                ConnectionScope,
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
            Guid[] lockTokens = new[] { new Guid(lockToken) };
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
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
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
                ConnectionScope,
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
            Guid[] lockTokens = new[] { new Guid(lockToken) };
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
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the deadletter queue, you will need a new
        /// <see cref="ServiceBusReceiver"/> with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
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
                ConnectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        internal virtual Task DeadLetterInternalAsync(
            string lockToken,
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

            var lockTokens = new[] { new Guid(lockToken) };
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
            Rejected rejected = AmqpConstants.RejectedOutcome;
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

        private Outcome GetAbandonOutcome(IDictionary<string, object> propertiesToModify) =>
            GetModifiedOutcome(propertiesToModify, false);

        private Outcome GetDeferOutcome(IDictionary<string, object> propertiesToModify) =>
            GetModifiedOutcome(propertiesToModify, true);

        private List<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
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
        /// Fetches the next batch of active messages without changing the state of the receiver or the message source.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number from where to read the message.</param>
        /// <param name="messageCount">The maximum number of messages that will be fetched.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// The first call to PeekBatchBySequenceAsync(long, int, CancellationToken) fetches the first active message for this receiver. Each subsequent call
        /// fetches the subsequent message in the entity.
        /// Unlike a received message, peeked message will not have lock token associated with it, and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveBatchAsync(int, CancellationToken)"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns></returns>
        public override async Task<IList<ServiceBusReceivedMessage>> PeekBatchAtAsync(
            long? sequenceNumber,
            int messageCount = 1,
            CancellationToken cancellationToken = default)
        {

            long seqNumber = sequenceNumber ?? LastPeekedSequenceNumber + 1;
            IList<ServiceBusReceivedMessage> messages = null;

            await _retryPolicy.RunOperation(
                async (timeout) =>
                messages = await PeekBatchAtInternalAsync(
                    seqNumber,
                    messageCount,
                    timeout,
                    cancellationToken)
                .ConfigureAwait(false),
                ConnectionScope,
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
        private async Task<IList<ServiceBusReceivedMessage>> PeekBatchAtInternalAsync(
            long sequenceNumber,
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

            amqpRequestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = sequenceNumber;
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

        private void ThrowIfSessionLockLost()
        {
            if (LinkException != null)
            {
                throw LinkException;
            }
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
                ConnectionScope,
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
                IEnumerable<DateTime> lockedUntilUtcTimes = amqpResponseMessage.GetValue<IEnumerable<DateTime>>(ManagementConstants.Properties.Expirations);
                lockedUntil = lockedUntilUtcTimes.First();
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

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                DateTimeOffset lockedUntil;
                await _retryPolicy.RunOperation(
                    async (timeout) =>
                    {
                        lockedUntil = await RenewSessionLockInternal(
                            timeout).ConfigureAwait(false);
                    },
                    ConnectionScope,
                    cancellationToken).ConfigureAwait(false);
                SessionLockedUntil = lockedUntil;
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

        internal async Task<DateTimeOffset> RenewSessionLockInternal(
            TimeSpan timeout)
        {
            try
            {
                // Create an AmqpRequest Message to renew  lock
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, timeout, null);

                if (_receiveLink.TryGetOpenedObject(out var receiveLink))
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
            catch (Exception exception)
            {
                // TODO: throw AmqpExceptionHelper.GetClientException(exception);
                throw exception;
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
        public override async Task<IList<ServiceBusReceivedMessage>> ReceiveDeferredMessageBatchAsync(
            IList<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            IList<ServiceBusReceivedMessage> messages = null;
            await _retryPolicy.RunOperation(
                async (timeout) => messages = await ReceiveDeferredMessagesAsyncInternal(
                    sequenceNumbers.ToArray(),
                    timeout).ConfigureAwait(false),
                ConnectionScope,
                cancellationToken).ConfigureAwait(false);
            return messages;
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
                throw AmqpExceptionHelper.TranslateException(exception);
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

            _receiveLink?.Dispose();

        }

        private void OnSessionReceiverLinkClosed(object receiver, EventArgs e)
        {
            var receivingAmqpLink = (ReceivingAmqpLink)receiver;
            if (receivingAmqpLink != null)
            {
                Exception exception = receivingAmqpLink.GetInnerException();
                if (((exception is ServiceBusException sbException) && sbException.Reason != ServiceBusException.FailureReason.SessionLockLost) || !(exception is ServiceBusException))
                {
                    exception = new ServiceBusException(
                        Resources.SessionLockExpiredOnMessageSession, ServiceBusException.FailureReason.SessionLockLost,
                        innerException: exception);
                }

                LinkException = exception;
                ServiceBusEventSource.Log.SessionReceiverLinkClosed(
                    _identifier,
                    SessionId,
                    LinkException);
            }
        }

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
               ConnectionScope,
               cancellationToken).ConfigureAwait(false);

            if (_isSessionReceiver)
            {
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
                SessionId = tempSessionId;
                SessionLockedUntil = link.Settings.Properties.TryGetValue<long>(AmqpClientConstants.LockedUntilUtc, out var lockedUntilUtcTicks)
                ? new DateTime(lockedUntilUtcTicks, DateTimeKind.Utc)
                : DateTime.MinValue;
                link.Closed += OnSessionReceiverLinkClosed;

            }
        }
    }
}
