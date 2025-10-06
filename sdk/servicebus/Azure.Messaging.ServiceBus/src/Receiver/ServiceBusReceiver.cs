// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusReceiver" /> is responsible for receiving
    /// <see cref="ServiceBusReceivedMessage" /> and settling messages from Queues and Subscriptions.
    /// It is constructed by calling <see cref="ServiceBusClient.CreateReceiver(string, ServiceBusReceiverOptions)"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="ServiceBusReceiver" /> is safe to cache and use for the lifetime of an
    /// application or until the <see cref="ServiceBusClient" /> that it was created by is disposed.
    /// Caching the receiver is recommended when the application is consuming messages
    /// regularly or semi-regularly.  The receiver is responsible for ensuring efficient network, CPU,
    /// and memory use.  Calling <see cref="DisposeAsync" /> on the associated <see cref="ServiceBusClient" />
    /// as the application is shutting down will ensure that network resources and other unmanaged objects used
    /// by the receiver are properly cleaned up.
    ///</remarks>
    public class ServiceBusReceiver : IAsyncDisposable
    {
        /// <summary>The maximum number of messages to delete in a single batch.  This cap is established and enforced by the service.</summary>
        internal const int MaxDeleteMessageCount = 500;

        /// <summary>The set of default options to use for initialization when no explicit options were provided.</summary>
        private static ServiceBusReceiverOptions s_defaultOptions;

        /// <summary>
        /// The fully qualified Service Bus namespace that the receiver is associated with.  This is likely
        /// to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        public virtual string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        /// The path of the Service Bus entity that the receiver is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public virtual string EntityPath { get; }

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received.
        /// </summary>
        /// <value>
        /// The option to auto complete messages is specified when creating the receiver
        /// using <see cref="ServiceBusReceiverOptions.ReceiveMode"/> and has a default mode of
        /// <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </value>
        public virtual ServiceBusReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Indicates whether the receiver entity is session enabled.
        /// </summary>
        internal bool IsSessionReceiver { get; }

        /// <summary>
        /// The number of messages that will be eagerly requested from Queues or Subscriptions and queued locally without regard to
        /// whether a processing is currently active, intended to help maximize throughput by allowing the receiver to receive
        /// from a local cache rather than waiting on a service request
        /// </summary>
        /// <value>
        /// The option to auto complete messages is specified when creating the receiver
        /// using <see cref="ServiceBusReceiverOptions.PrefetchCount"/> and has a default value of 0.
        /// </value>
        public virtual int PrefetchCount
        {
            get
            {
                return InnerReceiver.PrefetchCount;
            }
            internal set
            {
                InnerReceiver.PrefetchCount = value;
            }
        }

        /// <summary>
        /// A name used to identify the receiver client.  If <c>null</c> or empty, a random unique value will be will be used.
        /// </summary>
        public virtual string Identifier { get; internal set; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusReceiver"/> has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the receiver is closed; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsClosed
        {
            get => _closed;
            private set => _closed = value;
        }

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>
        /// Indicates whether or not the user has called CloseAsync or DisposeAsync on the receiver.
        /// </summary>
        internal bool IsDisposed => _closed;

        /// <summary>
        /// The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        /// The active connection to the Azure Service Bus service, enabling client communications for metadata
        /// about the associated Service Bus entity and access to transport-aware receivers.
        /// </summary>
        ///
        private readonly ServiceBusConnection _connection;

        /// <summary>
        /// An abstracted Service Bus transport-specific receiver that is associated with the
        /// Service Bus entity gateway; intended to perform delegated operations.
        /// </summary>
        internal TransportReceiver InnerReceiver => _innerReceiver;
        private readonly TransportReceiver _innerReceiver;

        /// <summary>
        /// Responsible for creating entity scopes.
        /// </summary>
        internal MessagingClientDiagnostics ClientDiagnostics => _clientDiagnostics;
        private readonly MessagingClientDiagnostics _clientDiagnostics;

        /// <summary>
        ///   The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="entityPath"></param>
        /// <param name="isSessionEntity"></param>
        /// <param name="options">A set of options to apply when configuring the consumer.</param>
        /// <param name="sessionId">An optional session Id to scope the receiver to. If not specified,
        ///     the next available session returned from the service will be used.</param>
        /// <param name="isProcessor">Whether or not the receiver is being created for a processor.</param>
        /// <param name="cancellationToken">The cancellation token to use when opening the receiver link.</param>
        internal ServiceBusReceiver(
            ServiceBusConnection connection,
            string entityPath,
            bool isSessionEntity,
            ServiceBusReceiverOptions options,
            string sessionId = default,
            bool isProcessor = default,
            CancellationToken cancellationToken = default)
        {
            Type type = GetType();
            Logger.ClientCreateStart(type, connection?.FullyQualifiedNamespace, entityPath);

            // cancellationToken should not be passed for non-session entities
            Debug.Assert(isSessionEntity || cancellationToken == default);

            try
            {
                Argument.AssertNotNull(connection, nameof(connection));
                Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
                Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
                connection.ThrowIfClosed();

                // If no explicit options were provided, use the default set, creating them as needed.  There is
                // a benign race condition here where multiple sets of default options may be created when initializing.
                // The cost of hitting the race is lower than the cost of synchronizing each access.
                options ??= s_defaultOptions ??= new ServiceBusReceiverOptions();

                Identifier = string.IsNullOrEmpty(options.Identifier) ? DiagnosticUtilities.GenerateIdentifier(entityPath) : options.Identifier;
                _connection = connection;
                _retryPolicy = connection.RetryOptions.ToRetryPolicy();
                ReceiveMode = options.ReceiveMode;

                EntityPath = EntityNameFormatter.FormatEntityPath(entityPath, options.SubQueue);

                IsSessionReceiver = isSessionEntity;
                _innerReceiver = _connection.CreateTransportReceiver(
                    entityPath: EntityPath,
                    retryPolicy: _retryPolicy,
                    receiveMode: ReceiveMode,
                    prefetchCount: (uint)options.PrefetchCount,
                    identifier: Identifier,
                    sessionId: sessionId,
                    isSessionReceiver: IsSessionReceiver,
                    isProcessor: isProcessor,
                    cancellationToken: cancellationToken);
                _clientDiagnostics = new MessagingClientDiagnostics(
                    DiagnosticProperty.DiagnosticNamespace,
                    DiagnosticProperty.ResourceProviderNamespace,
                    DiagnosticProperty.ServiceBusServiceContext,
                    FullyQualifiedNamespace,
                    EntityPath);
                if (!isSessionEntity)
                {
                    // don't log client completion for session receiver here as it is not complete until
                    // the link is opened.
                    Logger.ClientCreateComplete(type, Identifier);
                }
            }
            catch (Exception ex)
            {
                Logger.ClientCreateException(type, connection?.FullyQualifiedNamespace, entityPath, ex);
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class for mocking.
        /// </summary>
        ///
        protected ServiceBusReceiver() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class for use with derived types.
        /// </summary>
        /// <param name="client">The client instance to use for the receiver.</param>
        /// <param name="queueName">The name of the queue to receive from.</param>
        /// <param name="options">The set of options to use when configuring the receiver.</param>
        protected ServiceBusReceiver(ServiceBusClient client, string queueName, ServiceBusReceiverOptions options) :
            this(client?.Connection, queueName, false,  options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiver"/> class for use with derived types.
        /// </summary>
        /// <param name="client">The client instance to use for the receiver.</param>
        /// <param name="topicName">The topic to create a receiver for.</param>
        /// <param name="subscriptionName">The subscription to create a receiver for.</param>
        /// <param name="options">The set of options to use when configuring the receiver.</param>
        protected ServiceBusReceiver(ServiceBusClient client, string topicName, string subscriptionName, ServiceBusReceiverOptions options) :
            this(client?.Connection, EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), false,  options)
        {
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusReceiver" />.
        /// </summary>
        /// <param name="cancellationToken"> An optional<see cref="CancellationToken"/> instance to signal the
        /// request to cancel the operation.</param>
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            _closed = true;
            Type clientType = GetType();

            Logger.ClientCloseStart(clientType, Identifier);
            try
            {
                await InnerReceiver.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.ClientCloseException(clientType, Identifier, ex);
                throw;
            }

            Logger.ClientCloseComplete(clientType, Identifier);
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusReceivedMessage" /> from the entity using <see cref="ReceiveMode"/> mode.
        /// <see cref="ReceiveMode"/> defaults to PeekLock mode.
        /// This method doesn't guarantee to return exact `maxMessages` messages,
        /// even if there are `maxMessages` messages available in the queue or topic.
        /// </summary>
        ///
        /// <param name="maxMessages">The maximum number of messages that will be received.</param>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for the first message before returning an empty list if no messages are available.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>List of messages received. Returns an empty list if no message is found.</returns>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsync(
            int maxMessages,
            TimeSpan? maxWaitTime = default,
            CancellationToken cancellationToken = default) =>
            await ReceiveMessagesAsync(maxMessages, maxWaitTime, false, cancellationToken).ConfigureAwait(false);

        internal async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsync(
            int maxMessages,
            TimeSpan? maxWaitTime,
            bool isProcessor,
            CancellationToken cancellationToken)
        {
            Argument.AssertAtLeast(maxMessages, 1, nameof(maxMessages));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();

            if (maxWaitTime.HasValue)
            {
                // maxWaitTime could be zero only when prefetch enabled
                if (PrefetchCount > 0)
                {
                    Argument.AssertNotNegative(maxWaitTime.Value, nameof(maxWaitTime));
                }
                else
                {
                    Argument.AssertPositive(maxWaitTime.Value, nameof(maxWaitTime));
                }
            }
            if (PrefetchCount > 0 && maxMessages > PrefetchCount)
            {
                Logger.MaxMessagesExceedsPrefetch(Identifier, PrefetchCount, maxMessages);
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.ReceiveMessageStart(Identifier, maxMessages);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.ReceiveActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Receive);

            IReadOnlyList<ServiceBusReceivedMessage> messages = null;
            var startTime = DateTime.UtcNow;
            try
            {
                messages = await InnerReceiver.ReceiveMessagesAsync(
                    maxMessages,
                    maxWaitTime,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException ex)
                when (cancellationToken.IsCancellationRequested)
            {
                scope.BackdateStart(startTime);
                if (isProcessor)
                    Logger.ProcessorStoppingReceiveCanceled(Identifier, ex.ToString());
                else
                    Logger.ReceiveMessageCanceled(Identifier, ex.ToString());
                scope.Failed(ex);
                throw;
            }
            catch (Exception exception)
            {
                scope.BackdateStart(startTime);
                Logger.ReceiveMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            scope.SetMessageData(messages);
            scope.BackdateStart(startTime);

            Logger.ReceiveMessageComplete(Identifier, messages);

            return messages;
        }

        /// <summary>
        /// Receives messages as an asynchronous enumerable from the entity using <see cref="ReceiveMode"/> mode.
        /// <see cref="ReceiveMode"/> defaults to PeekLock mode. Messages will be received from the entity as
        /// the IAsyncEnumerable is iterated. If no messages are available, this method will continue polling
        /// until messages are available, i.e. it will never return null.
        /// </summary>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the
        /// request to cancel the operation.</param>
        /// <returns>The message received.</returns>
        public virtual async IAsyncEnumerable<ServiceBusReceivedMessage> ReceiveMessagesAsync(
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var msg = await ReceiveMessageAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                if (msg == null)
                {
                    continue;
                }
                yield return msg;
            }

            // Surface the TCE to ensure deterministic behavior when cancelling.
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
        }

        /// <summary>
        /// Receives a <see cref="ServiceBusReceivedMessage" /> from the entity using <see cref="ReceiveMode"/> mode.
        /// <see cref="ReceiveMode"/> defaults to PeekLock mode.
        /// </summary>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for a message before returning
        /// null if no messages are available.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the
        /// operation.</param>
        ///
        /// <returns>The message received. Returns null if no message is found.</returns>
        public virtual async Task<ServiceBusReceivedMessage> ReceiveMessageAsync(
            TimeSpan? maxWaitTime = default,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusReceivedMessage> result = await ReceiveMessagesAsync(
                maxMessages: 1,
                maxWaitTime: maxWaitTime,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            foreach (ServiceBusReceivedMessage message in result)
            {
                return message;
            }
            return null;
        }

        /// <summary>
        /// Fetches the next active <see cref="ServiceBusReceivedMessage"/> without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="fromSequenceNumber">An optional sequence number from where to peek the
        /// message. This corresponds to the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the
        /// operation.</param>
        ///
        /// <remarks>
        /// The first call to <see cref="PeekMessageAsync(long?, CancellationToken)"/> fetches the first active message for this receiver. Each subsequent call fetches the subsequent message in the entity.
        /// Unlike a received message, a peeked message will not have a lock token associated with it, and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveMessageAsync(TimeSpan?, CancellationToken)"/>, this method will fetch even Deferred messages (but not Deadlettered message).
        /// </remarks>
        ///
        /// <returns>The <see cref="ServiceBusReceivedMessage" /> that represents the next message to be read. Returns null when nothing to peek.</returns>
        /// <seealso href="https://aka.ms/azsdk/servicebus/message-browsing">Service Bus message browsing</seealso>
        public virtual async Task<ServiceBusReceivedMessage> PeekMessageAsync(
            long? fromSequenceNumber = default,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusReceivedMessage> result = await PeekMessagesInternalAsync(
                sequenceNumber: fromSequenceNumber,
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
        /// Fetches a list of active messages without changing the state of the receiver or the message source.
        /// </summary>
        ///
        /// <param name="maxMessages">The maximum number of messages that will be fetched.</param>
        /// <param name="fromSequenceNumber">An optional sequence number from where to peek the
        /// message. This corresponds to the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel
        /// the operation.</param>
        ///
        /// <remarks>
        /// Unlike a received message, a peeked message will not have a lock token associated with it, and hence it cannot be
        /// Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveMessageAsync(TimeSpan?, CancellationToken)"/>, this method will fetch even Deferred messages (but not Deadlettered messages).
        /// </remarks>
        ///
        /// <returns>An <see cref="IReadOnlyList{ServiceBusReceivedMessage}" /> of messages that were peeked.</returns>
        /// <seealso href="https://aka.ms/azsdk/servicebus/message-browsing">Service Bus message browsing</seealso>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesAsync(
            int maxMessages,
            long? fromSequenceNumber = default,
            CancellationToken cancellationToken = default) =>
            await PeekMessagesInternalAsync(
                sequenceNumber: fromSequenceNumber,
                maxMessages: maxMessages,
                cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Fetches a list of active messages without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number from where to peek the message.</param>
        /// <param name="maxMessages">The maximum number of messages that will be fetched.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>An <see cref="IList{ServiceBusReceivedMessage}" /> of messages that were peeked.</returns>
        private async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesInternalAsync(
            long? sequenceNumber,
            int maxMessages,
            CancellationToken cancellationToken)
        {
            Argument.AssertAtLeast(maxMessages, 1, nameof(maxMessages));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.PeekMessageStart(Identifier, sequenceNumber, maxMessages);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.PeekActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Receive);

            IReadOnlyList<ServiceBusReceivedMessage> messages;
            var startTime = DateTime.UtcNow;

            try
            {
                messages = await InnerReceiver.PeekMessagesAsync(
                    sequenceNumber,
                    maxMessages,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                scope.BackdateStart(startTime);
                Logger.PeekMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.PeekMessageComplete(Identifier, messages.Count);
            scope.SetMessageData(messages);
            scope.BackdateStart(startTime);
            return messages;
        }

        /// <summary>
        /// Opens an AMQP link for use with receiver operations.
        /// </summary>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        internal async Task OpenLinkAsync(CancellationToken cancellationToken) =>
            await InnerReceiver.OpenLinkAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/>. This will delete the message from the service.
        /// </summary>
        /// <param name="message">The message to complete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// This operation can only be performed on a message that was received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        /// <exception cref="ServiceBusException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The lock for the message has expired or the message has already been completed. This does not apply for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         The lock for the session has expired or the message has already been completed. This only applies for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        public virtual async Task CompleteMessageAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            ThrowIfNotPeekLockMode();
            Guid lockToken = message.LockTokenGuid;
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.CompleteMessageStart(
                Identifier,
                1,
                message.LockTokenGuid);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.CompleteActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Settle);
            scope.SetMessageData(message);
            scope.Start();

            try
            {
                await InnerReceiver.CompleteAsync(
                    lockToken,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.CompleteMessageException(Identifier, exception.ToString(), lockToken);
                scope.Failed(exception);
                throw;
            }

            Logger.CompleteMessageComplete(Identifier, lockToken);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusReceivedMessage"/>.This will make the message available again for immediate processing as the lock on the message held by the receiver will be released.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        /// <exception cref="ServiceBusException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The lock for the message has expired or the message has already been completed. This does not apply for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         The lock for the session has expired or the message has already been completed. This only applies for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        public virtual async Task AbandonMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            ThrowIfNotPeekLockMode();
            Guid lockToken = message.LockTokenGuid;
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.AbandonMessageStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.AbandonActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Settle);

            scope.SetMessageData(message);
            scope.Start();

            try
            {
                await InnerReceiver.AbandonAsync(
                    message.LockTokenGuid,
                    propertiesToModify,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.AbandonMessageException(Identifier, exception.ToString(), lockToken);
                scope.Failed(exception);
                throw;
            }

            Logger.AbandonMessageComplete(Identifier, lockToken);
        }

        /// <summary>
        /// Attempts to purge all messages from an entity.  Locked messages are not eligible for removal and
        /// will remain in the entity.
        /// </summary>
        /// <param name="beforeEnqueueTime">An optional <see cref="DateTimeOffset"/>, in UTC, representing the cutoff time for deletion. Only messages that were enqueued before this time will be deleted.  If not specified, <see cref="DateTimeOffset.UtcNow"/> will be assumed.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <remarks>
        /// If the lock for a message is held by a receiver, it will be respected and the message will not be deleted.
        ///
        /// This method may invoke multiple service requests to delete all messages.  As a result, it may exceed the configured <see cref="ServiceBusRetryOptions.TryTimeout"/>.
        /// If you need control over the amount of time the operation takes, it is recommended that you pass a <paramref name="cancellationToken"/> with the desired timeout set for cancellation.
        ///
        /// Because multiple service requests may be made, the possibility of partial success exists.  In this scenario, the method will stop attempting to delete additional messages
        /// and throw the exception that was encountered.  It is recommended to evaluate this exception and determine which messages may not have been deleted.
        /// </remarks>
        /// <returns>The number of messages that were deleted.</returns>
        internal virtual async Task<int> PurgeMessagesAsync(
            DateTimeOffset? beforeEnqueueTime = null,
            CancellationToken cancellationToken = default)
        {
            beforeEnqueueTime ??= DateTimeOffset.UtcNow;
            Logger.PurgeMessagesStart(Identifier, beforeEnqueueTime.Value);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.PurgeActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Settle);

            scope.Start();

            int purgeCount;

            try
            {
                purgeCount = await DeleteMessagesAsync(MaxDeleteMessageCount, beforeEnqueueTime.Value, cancellationToken).ConfigureAwait(false);

                // The service currently has a known bug that should be fixed before GA, where the
                // delete operation may not delete the requested batch size in a single call, even
                // when there are enough messages to do so.  This logic should check "purgeCount == MaxDeleteMessageCount"
                // for efficiency, as should the while condition below.
                //
                // Until this is fixed, we'll need to loop if there were any messages purgeCount, which will cost an extra
                // service call. see: https://github.com/Azure/azure-sdk-for-net/issues/43801
                if (purgeCount > 0)
                {
                   var batchCount = purgeCount;

                   while (batchCount > 0)
                   {
                       batchCount = await DeleteMessagesAsync(MaxDeleteMessageCount, beforeEnqueueTime.Value, cancellationToken).ConfigureAwait(false);
                       purgeCount += batchCount;
                   }
                }
            }
            catch (Exception exception)
            {
                Logger.PurgeMessagesException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.PurgeMessagesComplete(Identifier, purgeCount);
            return purgeCount;
        }

        /// <summary>
        /// Deletes up to <paramref name="messageCount"/> messages from the entity. The actual number
        /// of deleted messages may be less if there are fewer eligible messages in the entity.
        /// </summary>
        /// <param name="messageCount">The desired number of messages to delete.  This value is limited by the service and governed <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quotas">Service Bus quotas</see>.  The service may delete fewer messages than this limit.</param>
        /// <param name="beforeEnqueueTime">An optional <see cref="DateTimeOffset"/>, in UTC, representing the cutoff time for deletion. Only messages that were enqueued before this time will be deleted.  If not specified, <see cref="DateTimeOffset.UtcNow"/> will be assumed.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The number of messages that were deleted.</returns>
        /// <remarks>If the lock for a message is held by a receiver, it will be respected and the message will not be deleted.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Occurs when the <paramref name="messageCount"/> is less than 1 or exceeds the maximum allowed, as determined by the Service Bus service.
        /// For more information on service limits, see <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quotas#messaging-quotas"/>.
        /// </exception>
        internal virtual async Task<int> DeleteMessagesAsync(
            int messageCount,
            DateTimeOffset? beforeEnqueueTime = null,
            CancellationToken cancellationToken = default)
        {
            // Remove after service bug fixed.  Currently, the service responds
            // with a completely indecipherable message when the count is too high.
            // https://github.com/Azure/azure-sdk-for-net/issues/43801
            Argument.AssertInRange(messageCount, 1, MaxDeleteMessageCount, nameof(messageCount));

            Argument.AssertAtLeast(messageCount, 1, nameof(messageCount));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();

            beforeEnqueueTime ??= DateTimeOffset.UtcNow;
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.DeleteMessagesStart(Identifier, messageCount, beforeEnqueueTime.Value);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.DeleteActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Settle);

            scope.Start();

            int numMessagesDeleted;
            try
            {
                numMessagesDeleted = await InnerReceiver.DeleteMessagesAsync(messageCount, beforeEnqueueTime.Value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.DeleteMessagesException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.DeleteMessagesComplete(Identifier, numMessagesDeleted);
            return numMessagesDeleted;
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to subqueue.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the dead-letter queue or transfer dead-letter queue,
        /// set the <see cref="ServiceBusReceiverOptions.SubQueue"/> property to <see cref="SubQueue.DeadLetter"/>
        /// or <see cref="SubQueue.TransferDeadLetter"/> when calling
        /// <see cref="ServiceBusClient.CreateReceiver(string, ServiceBusReceiverOptions)"/> or
        /// <see cref="ServiceBusClient.CreateReceiver(string, string, ServiceBusReceiverOptions)"/>.
        /// This operation can only be performed when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        /// <exception cref="ServiceBusException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The lock for the message has expired or the message has already been completed. This does not apply for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         The lock for the session has expired or the message has already been completed. This only applies for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await DeadLetterInternalAsync(
                message: message,
                propertiesToModify: propertiesToModify,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to subqueue.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the dead-letter queue or transfer dead-letter queue,
        /// set the <see cref="ServiceBusReceiverOptions.SubQueue"/> property to <see cref="SubQueue.DeadLetter"/>
        /// or <see cref="SubQueue.TransferDeadLetter"/> when calling
        /// <see cref="ServiceBusClient.CreateReceiver(string, ServiceBusReceiverOptions)"/> or
        /// <see cref="ServiceBusClient.CreateReceiver(string, string, ServiceBusReceiverOptions)"/>.
        /// This operation can only be performed when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// The dead letter reason and error description can only be specified either through the method parameters or hard coded
        /// using this properties.
        /// </remarks>
        /// <exception cref="ServiceBusException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The lock for the message has expired or the message has already been completed. This does not apply for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         The lock for the session has expired or the message has already been completed. This only applies for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The dead letter reason or dead letter error exception was specified in both the parameter and the properties dictionary.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The dead letter reason or dead letter error description exceeded the maximum length of 4096.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotNull(propertiesToModify, nameof(propertiesToModify));

            // Prevent properties and arguments from setting distinct deadletter reasons or error descriptions
            bool containsReasonHeader = propertiesToModify.TryGetValue(AmqpMessageConstants.DeadLetterReasonHeader, out object reasonHeaderProperty);
            bool containsDescriptionHeader = propertiesToModify.TryGetValue(AmqpMessageConstants.DeadLetterErrorDescriptionHeader, out object descriptionHeaderProperty);

            bool setsReasonHeaderTwice = containsReasonHeader && deadLetterReason != null;
            bool setsDescriptionHeaderTwice = containsDescriptionHeader && deadLetterErrorDescription != null;

            if (setsReasonHeaderTwice && (reasonHeaderProperty is not string || reasonHeaderProperty.ToString() != deadLetterReason))
            {
                throw new InvalidOperationException("Differing deadletter reasons cannot be specified for both the 'propertiesToModify' and 'deadLetterReason' parameters. The values should either be identical or only be specified in one of the parameters.");
            }

            if (setsDescriptionHeaderTwice && (descriptionHeaderProperty is not string || descriptionHeaderProperty.ToString() != deadLetterErrorDescription))
            {
                throw new InvalidOperationException("Differing deadletter error descriptions cannot be specified for both the 'propertiesToModify' and 'deadLetterErrorDescription' parameters. The values should either be identical or only be specified in one of the parameters.");
            }

            await DeadLetterInternalAsync(
                message: message,
                deadLetterReason: deadLetterReason,
                deadLetterErrorDescription: deadLetterErrorDescription,
                propertiesToModify: propertiesToModify,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the dead-letter queue or transfer dead-letter queue,
        /// set the <see cref="ServiceBusReceiverOptions.SubQueue"/> property to <see cref="SubQueue.DeadLetter"/>
        /// or <see cref="SubQueue.TransferDeadLetter"/> when calling
        /// <see cref="ServiceBusClient.CreateReceiver(string, ServiceBusReceiverOptions)"/> or
        /// <see cref="ServiceBusClient.CreateReceiver(string, string, ServiceBusReceiverOptions)"/>.
        /// This operation can only be performed when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        /// <exception cref="ServiceBusException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The lock for the message has expired or the message has already been completed. This does not apply for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         The lock for the session has expired or the message has already been completed. This only applies for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The dead letter reason or dead letter error description exceeded the maximum length of 4096.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await DeadLetterInternalAsync(
                message: message,
                deadLetterReason: deadLetterReason,
                deadLetterErrorDescription: deadLetterErrorDescription,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockTokenGuid"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive a message from the dead-letter queue, you will need a new <see cref="ServiceBusReceiver"/>, with the corresponding path.
        /// You can use <see cref="ServiceBusReceiverOptions.SubQueue"/> with <see cref="SubQueue.DeadLetter"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        internal virtual async Task DeadLetterInternalAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason = default,
            string deadLetterErrorDescription = default,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            ThrowIfNotPeekLockMode();
            Guid lockToken = message.LockTokenGuid;
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.DeadLetterMessageStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.DeadLetterActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Settle);

            scope.SetMessageData(message);
            scope.Start();

            try
            {
                await InnerReceiver.DeadLetterAsync(
                    lockToken: lockToken,
                    deadLetterReason: deadLetterReason,
                    deadLetterErrorDescription: deadLetterErrorDescription,
                    propertiesToModify: propertiesToModify,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.DeadLetterMessageException(Identifier, exception.ToString(), lockToken);
                scope.Failed(exception);
                throw;
            }

            Logger.DeadLetterMessageComplete(Identifier, lockToken);
        }

        /// <summary> Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to defer.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive this message again in the future, you will need to save the
        /// <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        /// <exception cref="ServiceBusException">
        ///   <list type="bullet">
        ///     <item>
        ///       <description>
        ///         The lock for the message has expired or the message has already been completed. This does not apply for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         The lock for the session has expired or the message has already been completed. This only applies for session-enabled entities.
        ///         The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionLockLost"/> in this case.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </exception>
        public virtual async Task DeferMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            ThrowIfNotPeekLockMode();
            Guid lockToken = message.LockTokenGuid;
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.DeferMessageStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.DeferActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Settle);

            scope.SetMessageData(message);
            scope.Start();

            try
            {
                await InnerReceiver.DeferAsync(
                    lockToken,
                    propertiesToModify,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.DeferMessageException(Identifier, exception.ToString(), lockToken);
                scope.Failed(exception);
                throw;
            }

            Logger.DeferMessageComplete(Identifier, lockToken);
        }

        /// <summary>
        /// Throws an InvalidOperationException when not in PeekLock mode.
        /// </summary>
        private void ThrowIfNotPeekLockMode()
        {
            if (ReceiveMode != ServiceBusReceiveMode.PeekLock)
            {
                throw new InvalidOperationException(Resources.OperationNotSupported);
            }
        }

        /// <summary>
        /// Throws an InvalidOperationException when the lock token is empty.
        /// </summary>
        private static void ThrowIfLockTokenIsEmpty(Guid lockToken)
        {
            if (lockToken == Guid.Empty)
            {
                throw new InvalidOperationException(Resources.PeekLockModeRequired);
            }
        }

        /// <summary>
        /// Receives a deferred message identified by <paramref name="sequenceNumber"/>.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number of the message to receive. This corresponds to
        /// the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The deferred message identified by the specified sequence number.
        /// Throws if the message has not been deferred.</returns>
        /// <seealso cref="DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        /// <exception cref="ServiceBusException">
        ///   The specified sequence number does not correspond to a message that has been deferred.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageNotFound"/> in this case.
        /// </exception>
        public virtual async Task<ServiceBusReceivedMessage> ReceiveDeferredMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default) =>
            (await ReceiveDeferredMessagesAsync(new long[] { sequenceNumber }, cancellationToken).ConfigureAwait(false))[0];

        /// <summary>
        /// Receives a list of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        ///
        /// <returns>Messages identified by sequence number are returned.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        /// <exception cref="ServiceBusException">
        ///   The specified sequence number does not correspond to a message that has been deferred.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageNotFound"/> in this case.
        /// </exception>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(sequenceNumbers, nameof(sequenceNumbers));
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // the sequence numbers MUST be in array form for them to be encoded correctly
            long[] sequenceArray = sequenceNumbers switch
            {
                long[] alreadyArray => alreadyArray,
                _ => sequenceNumbers.ToArray()
            };

            if (sequenceArray.Length == 0)
            {
                return Array.Empty<ServiceBusReceivedMessage>();
            }

            Logger.ReceiveDeferredMessageStart(Identifier, sequenceArray);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.ReceiveDeferredActivityName,
                ActivityKind.Client,
                MessagingDiagnosticOperation.Receive);

            scope.Start();

            IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = null;
            try
            {
                deferredMessages = await InnerReceiver.ReceiveDeferredMessagesAsync(
                    sequenceArray,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.ReceiveDeferredMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.ReceiveDeferredMessageComplete(Identifier, deferredMessages.Count);
            scope.SetMessageData(deferredMessages);
            return deferredMessages;
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        ///
        /// <remarks>
        /// When a message is received in <see cref="ServiceBusReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to renew the lock for.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="ServiceBusException">
        ///   The lock for the message has expired or the message has already been completed.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageLockLost"/> in this case.
        /// </exception>
        public virtual async Task RenewMessageLockAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            DateTimeOffset lockedUntil = await RenewMessageLockAsync(
                message.LockTokenGuid,
                cancellationToken).ConfigureAwait(false);
            message.LockedUntil = lockedUntil;
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        ///
        /// <remarks>
        /// When a message is received in <see cref="ServiceBusReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to renew the lock for.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        internal virtual async Task<DateTimeOffset> RenewMessageLockAsync(
            Guid lockToken,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusReceiver));
            _connection.ThrowIfClosed();
            ThrowIfNotPeekLockMode();
            ThrowIfSessionReceiver();
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.RenewMessageLockStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                DiagnosticProperty.RenewMessageLockActivityName,
                ActivityKind.Client);
            scope.Start();

            DateTimeOffset lockedUntil;
            try
            {
                lockedUntil = await InnerReceiver.RenewMessageLockAsync(
                    lockToken,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.RenewMessageLockException(Identifier, exception.ToString(), lockToken);
                scope.Failed(exception);
                throw;
            }

            Logger.RenewMessageLockComplete(Identifier, lockToken);
            return lockedUntil;
        }

        /// <summary>
        /// Throws an exception if the receiver instance is a session receiver.
        /// </summary>
        private void ThrowIfSessionReceiver()
        {
            if (IsSessionReceiver)
            {
                throw new InvalidOperationException(Resources.CannotLockMessageOnSessionEntity);
            }
        }

        /// <summary>
        /// Performs the task needed to clean up resources used by the <see cref="ServiceBusReceiver" />.
        /// This is equivalent to calling <see cref="CloseAsync"/>.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async ValueTask DisposeAsync()
        {
            await CloseAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
