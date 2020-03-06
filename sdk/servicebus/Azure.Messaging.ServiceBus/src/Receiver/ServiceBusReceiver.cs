// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A client responsible for reading <see cref="ServiceBusMessage" /> from a specific entity
    ///   as a member of a specific consumer group.
    ///
    ///   A consumer may be exclusive, which asserts ownership over associated partitions for the consumer
    ///   group to ensure that only one consumer from that group is reading the from the partition.
    ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
    ///
    ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
    ///   group to be actively reading events from a given partition.  These non-exclusive consumers are
    ///   sometimes referred to as "Non-Epoch Consumers."
    /// </summary>
    ///
    public class ServiceBusReceiver : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Service Bus entity that the consumer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName { get; }

        /// <summary>
        ///
        /// </summary>
        public ReceiveMode ReceiveMode { get; }

        /// <summary>
        ///
        /// </summary>
        public bool IsSessionReceiver { get; }

        /// <summary>
        ///
        /// </summary>
        public int PrefetchCount { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusReceiver"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; protected set; } = false;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        internal ServiceBusRetryPolicy RetryPolicy { get; private set; }

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        ///
        internal ServiceBusConnection Connection => _connection;

        private readonly ServiceBusConnection _connection;

        /// <summary>
        ///   An abstracted Service Bus entity transport-specific receiver that is associated with the
        ///   Service Bus entity gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        private readonly TransportReceiver _innerReceiver;

        /// <summary>
        ///
        /// </summary>
        public ServiceBusSessionManager SessionManager { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusSubscriptionManager SubscriptionManager { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal static async Task<ServiceBusReceiver> CreateSessionReceiverAsync(
            string queueName,
            ServiceBusConnection connection,
            string sessionId = default,
            ServiceBusReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            options = options?.Clone() ?? new ServiceBusReceiverOptions();

            var receiver = new ServiceBusReceiver(
                connection: connection,
                entityName: queueName,
                isSessionEntity: true,
                sessionId: sessionId,
                options: options);
            await receiver.OpenLinkAsync(cancellationToken).ConfigureAwait(false);
            return receiver;
        }


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal static ServiceBusReceiver CreateReceiver(
            string queueName,
            ServiceBusConnection connection,
            ServiceBusReceiverOptions options = default)
        {
            options = options?.Clone() ?? new ServiceBusReceiverOptions();
            return new ServiceBusReceiver(
                connection: connection,
                entityName: queueName,
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiver"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="entityName"></param>
        /// <param name="isSessionEntity"></param>
        /// <param name="sessionId"></param>
        /// <param name="options">A set of options to apply when configuring the consumer.</param>
        ///
        private ServiceBusReceiver(
            ServiceBusConnection connection,
            string entityName,
            bool isSessionEntity,
            string sessionId = default,
            ServiceBusReceiverOptions options = default)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            options ??= new ServiceBusReceiverOptions();

            IsSessionReceiver = isSessionEntity;
            _connection = connection;
            RetryPolicy = options.RetryOptions.ToRetryPolicy();
            ReceiveMode = options.ReceiveMode;
            PrefetchCount = options.PrefetchCount;
            EntityName = entityName;
            _innerReceiver = _connection.CreateTransportReceiver(
                entityName: EntityName,
                retryPolicy: RetryPolicy,
                receiveMode: ReceiveMode,
                prefetchCount: (uint) PrefetchCount,
                sessionId: sessionId,
                isSessionReceiver: IsSessionReceiver);
            SessionManager = new ServiceBusSessionManager(_innerReceiver);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiver"/> class.
        /// </summary>
        ///
        protected ServiceBusReceiver(){}

        /// <summary>
        ///  Receives a batch of <see cref="ServiceBusMessage" /> from the entity using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessages">The maximum number of messages that will be received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns></returns>
        public virtual async Task<IList<ServiceBusReceivedMessage>> ReceiveBatchAsync(
           int maxMessages,
           CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                return await _innerReceiver.ReceiveBatchAsync(maxMessages, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                // TODO: Add log - SeviceBusEventSource.Log.ReceiveBatchAsyncComplete();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceivedMessage> ReceiveAsync(
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusReceivedMessage> result = await ReceiveBatchAsync(maxMessages: 1).ConfigureAwait(false);
            foreach (ServiceBusReceivedMessage message in result)
            {
                return message;
            }
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceivedMessage> PeekAsync(
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusReceivedMessage> result = await PeekBatchBySequenceInternalAsync(
                fromSequenceNumber: null,
                maxMessages: 1,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            foreach (ServiceBusReceivedMessage message in result)
            {
                return message;
            }
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ServiceBusReceivedMessage> PeekBySequenceAsync(
            long fromSequenceNumber,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusReceivedMessage> result = await PeekBatchBySequenceAsync(
                fromSequenceNumber: fromSequenceNumber,
                maxMessages: 1)
                .ConfigureAwait(false);

            foreach (ServiceBusReceivedMessage message in result)
            {
                return message;
            }
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IList<ServiceBusReceivedMessage>> PeekBatchAsync(
            int maxMessages,
            CancellationToken cancellationToken = default) =>
            await PeekBatchBySequenceInternalAsync(
                fromSequenceNumber: null,
                maxMessages: maxMessages,
                cancellationToken: cancellationToken).ConfigureAwait(false);


        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IList<ServiceBusReceivedMessage>> PeekBatchBySequenceAsync(
            long fromSequenceNumber,
            int maxMessages = 1,
            CancellationToken cancellationToken = default) =>
            await PeekBatchBySequenceInternalAsync(
                fromSequenceNumber: fromSequenceNumber,
                maxMessages: maxMessages,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IList<ServiceBusReceivedMessage>> PeekBatchBySequenceInternalAsync(
            long? fromSequenceNumber,
            int maxMessages,
            CancellationToken cancellationToken) =>
            await _innerReceiver.PeekBatchBySequenceAsync(
                fromSequenceNumber,
                maxMessages,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task OpenLinkAsync(CancellationToken cancellationToken) =>
            await _innerReceiver.OpenLinkAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/>. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> message to complete.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// This operation can only be performed on a message that was received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        public virtual async Task CompleteAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            await CompleteAsync(new[] { message }, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task CompleteAsync(
            IEnumerable<ServiceBusReceivedMessage> receivedMessages,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            await _innerReceiver.CompleteAsync(
                receivedMessages,
                cancellationToken).ConfigureAwait(false);
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
        public virtual async Task AbandonAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();

            await _innerReceiver.AbandonAsync(
                message,
                propertiesToModify,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// In order to receive a message from the deadletter queue, you will need a new
        /// <see cref="ServiceBusReceiver"/> with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        public virtual async Task DeadLetterAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            await _innerReceiver.DeadLetterAsync(
                message: message,
                propertiesToModify: propertiesToModify,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="ServiceBusReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            await _innerReceiver.DeadLetterAsync(
                message: message,
                deadLetterReason: deadLetterReason,
                deadLetterErrorDescription: deadLetterErrorDescription,
                cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeferAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            await _innerReceiver.DeferAsync(
                message,
                propertiesToModify,
                cancellationToken).ConfigureAwait(false);
        }

        internal void ThrowIfNotPeekLockMode()
        {
            if (ReceiveMode != ReceiveMode.PeekLock)
            {
                throw new InvalidOperationException(Resources1.OperationNotSupported);
            }
        }

        /// <summary>
        /// Receives a specific deferred message identified by <paramref name="sequenceNumber"/>.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number of the message that will be received.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Message identified by sequence number <paramref name="sequenceNumber"/>. Returns null if no such message is found.
        /// Throws if the message has not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public virtual async Task<ServiceBusReceivedMessage> ReceiveDeferredMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusReceivedMessage> result = await ReceiveDeferredMessageBatchAsync(sequenceNumbers: new long[] { sequenceNumber }).ConfigureAwait(false);
            foreach (ServiceBusReceivedMessage message in result)
            {
                return message;
            }
            return null;
        }

        /// <summary>
        /// Receives a <see cref="IList{Message}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public virtual async Task<IList<ServiceBusReceivedMessage>> ReceiveDeferredMessageBatchAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            return await _innerReceiver.ReceiveDeferredMessageBatchAsync(
                sequenceNumbers,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Renews the lock on the message specified by the lock token. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        ///
        /// <remarks>
        /// When a message is received in <see cref="ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        ///
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task RenewLockAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            DateTime lockedUntilUtc = await _innerReceiver.RenewMessageLockAsync(
                message.LockToken,
                cancellationToken).ConfigureAwait(false);
            message.LockedUntilUtc = lockedUntilUtc;
            // MessagingEventSource.Log.MessageRenewLockStart(this.ClientId, 1, lockToken);
        }

        /// <summary>
        ///   Closes the consumer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            IsClosed = true;

            var clientHash = GetHashCode().ToString();
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusReceiver), EntityName, clientHash);

            // Attempt to close the transport consumer.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportConsumerException = default(Exception);

            try
            {
                await _innerReceiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusReceiver), EntityName, clientHash, ex.Message);
                transportConsumerException = ex;
            }

            // If there was an active exception pending from closing the individual
            // transport consumers, surface it now.

            if (transportConsumerException != default)
            {
                throw transportConsumerException;
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusReceiver" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
