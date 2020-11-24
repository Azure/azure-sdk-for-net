// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusReceiver" /> is responsible for receiving
    /// <see cref="ServiceBusReceivedMessage" /> and settling messages from Queues and Subscriptions.
    /// It is constructed by calling <see cref="ServiceBusClient.CreateReceiver(string, ServiceBusReceiverOptions)"/>.
    /// </summary>
    public class ServiceBusReceiver : IAsyncDisposable
    {
        /// <summary>
        /// The fully qualified Service Bus namespace that the receiver is associated with.  This is likely
        /// to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        public string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        /// The path of the Service Bus entity that the receiver is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public string EntityPath { get; }

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        public ServiceBusReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Indicates whether the receiver entity is session enabled.
        /// </summary>
        internal bool IsSessionReceiver { get; }

        /// <summary>
        /// The number of messages that will be eagerly requested from Queues or Subscriptions and queued locally without regard to
        /// whether a processing is currently active, intended to help maximize throughput by allowing the receiver to receive
        /// from a local cache rather than waiting on a service request.
        /// </summary>
        public int PrefetchCount { get; }

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID.</remarks>
        internal string Identifier { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusReceiver"/> has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the receiver is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed
        {
            get => _closed;
            private set => _closed = value;
        }

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

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
        internal EntityScopeFactory ScopeFactory => _scopeFactory;
        private readonly EntityScopeFactory _scopeFactory;

        /// <summary>
        /// The list of plugins to apply to incoming messages.
        /// </summary>
        private readonly IList<ServiceBusPlugin> _plugins;

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
        /// <param name="plugins">The plugins to apply to incoming messages.</param>
        /// <param name="options">A set of options to apply when configuring the consumer.</param>
        /// <param name="sessionId">An optional session Id to scope the receiver to. If not specified,
        /// the next available session returned from the service will be used.</param>
        ///
        internal ServiceBusReceiver(
            ServiceBusConnection connection,
            string entityPath,
            bool isSessionEntity,
            IList<ServiceBusPlugin> plugins,
            ServiceBusReceiverOptions options,
            string sessionId = default)
        {
            Type type = GetType();
            Logger.ClientCreateStart(type, connection?.FullyQualifiedNamespace, entityPath);
            try
            {
                Argument.AssertNotNull(connection, nameof(connection));
                Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
                Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
                connection.ThrowIfClosed();

                options = options?.Clone() ?? new ServiceBusReceiverOptions();
                Identifier = DiagnosticUtilities.GenerateIdentifier(entityPath);
                _connection = connection;
                _retryPolicy = connection.RetryOptions.ToRetryPolicy();
                ReceiveMode = options.ReceiveMode;
                PrefetchCount = options.PrefetchCount;

                switch (options.SubQueue)
                {
                    case SubQueue.None:
                        EntityPath = entityPath;
                        break;
                    case SubQueue.DeadLetter:
                        EntityPath = EntityNameFormatter.FormatDeadLetterPath(entityPath);
                        break;
                    case SubQueue.TransferDeadLetter:
                        EntityPath = EntityNameFormatter.FormatTransferDeadLetterPath(entityPath);
                        break;
                }

                IsSessionReceiver = isSessionEntity;
                _innerReceiver = _connection.CreateTransportReceiver(
                    entityPath: EntityPath,
                    retryPolicy: _retryPolicy,
                    receiveMode: ReceiveMode,
                    prefetchCount: (uint)PrefetchCount,
                    identifier: Identifier,
                    sessionId: sessionId,
                    isSessionReceiver: IsSessionReceiver);
                _scopeFactory = new EntityScopeFactory(EntityPath, FullyQualifiedNamespace);
                _plugins = plugins;
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
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusReceiver" />.
        /// </summary>
        /// <param name="cancellationToken"> An optional<see cref="CancellationToken"/> instance to signal the
        /// request to cancel the operation.</param>
        public virtual async Task CloseAsync(
            CancellationToken cancellationToken = default)
        {
            IsClosed = true;
            Type clientType = GetType();

            Logger.ClientCloseStart(clientType, Identifier);
            try
            {
                await InnerReceiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
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
           CancellationToken cancellationToken = default)
        {
            Argument.AssertAtLeast(maxMessages, 1, nameof(maxMessages));
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            if (maxWaitTime.HasValue)
            {
                Argument.AssertPositive(maxWaitTime.Value, nameof(maxWaitTime));
            }
            if (PrefetchCount > 0 && maxMessages > PrefetchCount)
            {
                Logger.MaxMessagesExceedsPrefetch(Identifier, PrefetchCount, maxMessages);
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.ReceiveMessageStart(Identifier, maxMessages);

            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.ReceiveActivityName,
                DiagnosticProperty.ConsumerKind);

            scope.Start();

            IReadOnlyList<ServiceBusReceivedMessage> messages = null;

            try
            {
                messages = await InnerReceiver.ReceiveMessagesAsync(
                    maxMessages,
                    maxWaitTime,
                    cancellationToken).ConfigureAwait(false);
                await ApplyPlugins(messages).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.ReceiveMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.ReceiveMessageComplete(Identifier, messages.Count);
            scope.SetMessageData(messages);

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

        private async Task ApplyPlugins(IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
            foreach (ServiceBusPlugin plugin in _plugins)
            {
                string pluginType = plugin.GetType().Name;
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    try
                    {
                        Logger.PluginCallStarted(pluginType, message.MessageId);
                        await plugin.AfterMessageReceiveAsync(message).ConfigureAwait(false);
                        Logger.PluginCallCompleted(pluginType, message.MessageId);
                    }
                    catch (Exception ex)
                    {
                        Logger.PluginCallException(pluginType, message.MessageId, ex.ToString());
                        throw;
                    }
                }
            }
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

        /// Fetches a list of active messages without changing the state of the receiver or the message source.
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
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            Argument.AssertAtLeast(maxMessages, 1, nameof(maxMessages));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.PeekMessageStart(Identifier, sequenceNumber, maxMessages);
            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.PeekActivityName,
                DiagnosticProperty.ProducerKind);
            scope.Start();

            IReadOnlyList<ServiceBusReceivedMessage> messages = new List<ServiceBusReceivedMessage>();
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
                Logger.PeekMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.PeekMessageComplete(Identifier, messages.Count);
            scope.SetMessageData(messages);
            return messages;
        }

        /// <summary>
        /// Opens an AMQP link for use with receiver operations.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
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
        public virtual async Task CompleteMessageAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await CompleteMessageAsync(message.LockToken, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/>. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> message to complete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// This operation can only be performed on a message that was received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        internal virtual async Task CompleteMessageAsync(
            string lockToken,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.CompleteMessageStart(
                Identifier,
                1,
                lockToken);
            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.CompleteActivityName,
                DiagnosticProperty.ClientKind);
            scope.Start();

            try
            {
                await InnerReceiver.CompleteAsync(
                    lockToken,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.CompleteMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.CompleteMessageComplete(Identifier);
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
        public virtual async Task AbandonMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await AbandonMessageAsync(
                message.LockToken,
                propertiesToModify,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusReceivedMessage"/>. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token <see cref="ServiceBusReceivedMessage"/> to abandon.</param>
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
        internal virtual async Task AbandonMessageAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.AbandonMessageStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.AbandonActivityName,
                DiagnosticProperty.ClientKind);

            scope.Start();

            try
            {
                await InnerReceiver.AbandonAsync(
                    lockToken,
                    propertiesToModify,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.AbandonMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.AbandonMessageComplete(Identifier);
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
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await DeadLetterMessageAsync(
                lockToken: message.LockToken,
                propertiesToModify: propertiesToModify,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
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
        internal virtual async Task DeadLetterMessageAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default) =>
            await DeadLetterInternalAsync(
                lockToken: lockToken,
                propertiesToModify: propertiesToModify,
                cancellationToken: cancellationToken).ConfigureAwait(false);

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
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive a message from the dead-letter queue, you will need a new <see cref="ServiceBusReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await DeadLetterMessageAsync(
                lockToken: message.LockToken,
                deadLetterReason: deadLetterReason,
                deadLetterErrorDescription: deadLetterErrorDescription,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive a message from the dead-letter queue, you will need a new <see cref="ServiceBusReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        internal virtual async Task DeadLetterMessageAsync(
            string lockToken,
            string deadLetterReason,
            string deadLetterErrorDescription = null,
            CancellationToken cancellationToken = default) =>
            await DeadLetterInternalAsync(
                lockToken: lockToken,
                deadLetterReason: deadLetterReason,
                deadLetterErrorDescription: deadLetterErrorDescription,
                cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Moves a message to the dead-letter subqueue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token <see cref="ServiceBusReceivedMessage"/> to dead-letter.</param>
        /// <param name="deadLetterReason">The reason for dead-lettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for dead-lettering the message.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive a message from the dead-letter queue, you will need a new <see cref="ServiceBusReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        private async Task DeadLetterInternalAsync(
            string lockToken,
            string deadLetterReason = default,
            string deadLetterErrorDescription = default,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.DeadLetterMessageStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.DeadLetterActivityName,
                DiagnosticProperty.ClientKind);

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
                Logger.DeadLetterMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.DeadLetterMessageComplete(Identifier);
        }

        /// <summary> Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to defer.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the
        /// <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async Task DeferMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await DeferMessageAsync(
                message.LockToken,
                propertiesToModify,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lockToken of the <see cref="ServiceBusReceivedMessage"/> to defer.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the
        /// <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        internal virtual async Task DeferMessageAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.DeferMessageStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.DeferActivityName,
                DiagnosticProperty.ClientKind);

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
                Logger.DeferMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.DeferMessageComplete(Identifier);
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
        private static void ThrowIfLockTokenIsEmpty(string lockToken)
        {
            if (Guid.Parse(lockToken) == Guid.Empty)
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
        /// <returns>The deferred message identified by the specified sequence number. Returns null if no message is found.
        /// Throws if the message has not been deferred.</returns>
        /// <seealso cref="DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        /// <seealso cref="DeferMessageAsync(string, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task<ServiceBusReceivedMessage> ReceiveDeferredMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default) =>
            (await ReceiveDeferredMessagesAsync(new long[] { sequenceNumber }, cancellationToken).ConfigureAwait(false))[0];

        /// <summary>
        /// Receives a <see cref="IList{ServiceBusReceivedMessage}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        ///
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        /// <seealso cref="DeferMessageAsync(string, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            Argument.AssertNotNull(sequenceNumbers, nameof(sequenceNumbers));
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

            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.ReceiveDeferredActivityName,
                DiagnosticProperty.ConsumerKind);

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
        public virtual async Task RenewMessageLockAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            DateTimeOffset lockedUntil = await RenewMessageLockAsync(
                message.LockToken,
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
            string lockToken,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusReceiver));
            ThrowIfNotPeekLockMode();
            ThrowIfSessionReceiver();
            ThrowIfLockTokenIsEmpty(lockToken);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.RenewMessageLockStart(Identifier, 1, lockToken);

            using DiagnosticScope scope = ScopeFactory.CreateScope(
                DiagnosticProperty.RenewMessageLockActivityName,
                DiagnosticProperty.ClientKind);
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
                Logger.RenewMessageLockException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            Logger.RenewMessageLockComplete(Identifier);
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
        /// This is equivalent to calling <see cref="CloseAsync"/> with the default <see cref="LinkCloseMode"/>.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync() =>
            await CloseAsync().ConfigureAwait(false);

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
