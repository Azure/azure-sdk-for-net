// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

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
    public class ServiceBusReceiverClient : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Service Bus entity that the consumer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName => Connection.EntityName;

        /// <summary>
        ///
        /// </summary>
        public ReceiveMode ReceiveMode { get;}

        /// <summary>
        ///
        /// </summary>
        public bool IsSessionReceiver { get; }

        /// <summary>
        ///
        /// </summary>
        public uint PrefetchCount { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusReceiverClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; protected set; } = false;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="ServiceBusConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        internal bool OwnsConnection { get; set; } = true;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        internal ServiceBusRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        ///
        internal ServiceBusConnection Connection { get; set; }

        /// <summary>
        ///   An abstracted Service Bus entity transport-specific producer that is associated with the
        ///   Service Bus entity gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        internal TransportConsumer Consumer { get; }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusSession Session { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusSubscription Subscription { get; set; }

        /// <summary>
        /// A map of locked messages received using the management client.
        /// </summary>
        internal readonly ConcurrentExpiringSet<Guid> RequestResponseLockedMessages;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ SERVICE BUS ENTITY NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusReceiverClient(ServiceBusConnection connection)
            : this(connection, new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = false;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ SERVICE BUS ENTITY NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusReceiverClient(string connectionString)
            : this(new ServiceBusConnection(connectionString), new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = true;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ SERVICE BUS ENTITY NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusReceiverClient(
            string connectionString,
            ServiceBusReceiverClientOptions clientOptions)
            : this(new ServiceBusConnection(connectionString, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = true;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="queueOrSubscriptionName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="clientOptions"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="queueOrSubscriptionName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusReceiverClient(
            string connectionString,
            string queueOrSubscriptionName,
            ServiceBusReceiverClientOptions clientOptions = default)
            : this(new ServiceBusConnection(connectionString, queueOrSubscriptionName, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = true;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="clientOptions"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="topicName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusReceiverClient(
            string connectionString,
            string topicName,
            string subscriptionName,
            ServiceBusReceiverClientOptions clientOptions = default)
            : this(new ServiceBusConnection(connectionString, GetSubscriptionPath(topicName, subscriptionName), clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = true;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="queueName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public ServiceBusReceiverClient(
            string fullyQualifiedNamespace,
            string queueName,
            TokenCredential credential,
            ServiceBusReceiverClientOptions clientOptions = default)
            : this(new ServiceBusConnection(fullyQualifiedNamespace, queueName, credential, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = true;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public ServiceBusReceiverClient(
            string fullyQualifiedNamespace,
            string topicName,
            string subscriptionName,
            TokenCredential credential,
            ServiceBusReceiverClientOptions clientOptions = default)
            : this(new ServiceBusConnection(fullyQualifiedNamespace, GetSubscriptionPath(topicName, subscriptionName), credential, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusReceiverClientOptions())
        {
            OwnsConnection = true;
        }

        private static string GetSubscriptionPath(string topicName, string subscriptionName)
        {
            return $"{topicName}/{subscriptionName}";
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public ServiceBusReceiverClient(
            ServiceBusConnection connection,
            ServiceBusReceiverClientOptions clientOptions = default)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            clientOptions ??= new ServiceBusReceiverClientOptions();

            IsSessionReceiver = clientOptions.IsSessionEntity;
            Connection = connection;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            RequestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();
            ReceiveMode = clientOptions.ReceiveMode;
            PrefetchCount = clientOptions.PrefetchCount;
            Consumer = Connection.CreateTransportConsumer(
                retryPolicy: RetryPolicy,
                receiveMode: ReceiveMode,
                prefetchCount: PrefetchCount,
                sessionId: clientOptions.SessionId,
                isSessionReceiver: IsSessionReceiver);
            Session = new ServiceBusSession(
                Consumer,
                clientOptions.SessionId);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        protected ServiceBusReceiverClient()
        {
            OwnsConnection = false;
        }

        /// <summary>
        ///  Receives a batch of <see cref="ServiceBusMessage" /> from the entity using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessages">The maximum number of messages that will be received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<ServiceBusMessage>> ReceiveBatchAsync(
           int maxMessages,
           CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiverClient));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                return await Consumer.ReceiveAsync(maxMessages, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task<ServiceBusMessage> ReceiveAsync(
            CancellationToken cancellationToken = default)
        {
            // TODO implement to use ReceiveBatch
            IEnumerable<ServiceBusMessage> result = await PeekBatchBySequenceAsync(fromSequenceNumber: 1).ConfigureAwait(false);
            foreach (ServiceBusMessage message in result)
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
        public virtual async Task<ServiceBusMessage> PeekAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusMessage> result = null;
            await RetryPolicy.RunOperation(
                    async (timeout) =>
                    {
                        result = await PeekBatchBySequenceInternalAsync(
                            timeout,
                            null).ConfigureAwait(false);
                    },
                    EntityName,
                    Consumer.ConnectionScope,
                    cancellationToken).ConfigureAwait(false);

            foreach (ServiceBusMessage message in result)
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
        public virtual async Task<ServiceBusMessage> PeekBySequenceAsync(
            long fromSequenceNumber,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusMessage> result = await PeekBatchBySequenceAsync(fromSequenceNumber: fromSequenceNumber).ConfigureAwait(false);
            foreach (ServiceBusMessage message in result)
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
        public virtual async Task<IEnumerable<ServiceBusMessage>> PeekBatchAsync(
            int maxMessages,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusMessage> messages = null;
            await RetryPolicy.RunOperation(
                    async (timeout) =>
                    {
                        messages = await PeekBatchBySequenceInternalAsync(
                            timeout,
                            fromSequenceNumber: null,
                            maxMessages)
                            .ConfigureAwait(false);
                    },
                    EntityName,
                    Consumer.ConnectionScope,
                    cancellationToken).ConfigureAwait(false);

            return messages;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<ServiceBusMessage>> PeekBatchBySequenceAsync(
            long fromSequenceNumber,
            int maxMessages = 1,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusMessage> messages = null;
            await RetryPolicy.RunOperation(
                    async (timeout) =>
                    {
                        messages = await PeekBatchBySequenceInternalAsync(
                            timeout,
                            fromSequenceNumber: fromSequenceNumber,
                            maxMessages: maxMessages)
                            .ConfigureAwait(false);
                    },
                    EntityName,
                    Consumer.ConnectionScope,
                    cancellationToken).ConfigureAwait(false);

            return messages;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="timeout"></param>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<IEnumerable<ServiceBusMessage>> PeekBatchBySequenceInternalAsync(
            TimeSpan timeout,
            long? fromSequenceNumber,
            int maxMessages = 1,
            CancellationToken cancellationToken = default)
        {
            if (IsSessionReceiver)
            {
                // if this is a session receiver, the receive link must be open in order to peek messages
                await Consumer.GetOrCreateLinkAsync(timeout).ConfigureAwait(false);
            }

            string receiveLinkName = Consumer.GetReceiveLinkName();

            return await Connection.PeekAsync(
                timeout,
                fromSequenceNumber,
                maxMessages,
                await Session.GetSessionIdAsync(cancellationToken).ConfigureAwait(false),
                receiveLinkName,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Completes a <see cref="ServiceBusMessage"/> using its lock token. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task CompleteAsync(
            string lockToken,
            CancellationToken cancellationToken = default)
        {
            await CompleteAsync(new[] { lockToken }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task CompleteAsync(
            IEnumerable<string> lockTokens,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiverClient));
            ThrowIfNotPeekLockMode();
            Argument.AssertNotNullOrEmpty(lockTokens, nameof(lockTokens));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await RetryPolicy.RunOperation(
                    async (timeout) => await CompleteAsyncInternal(lockTokens, timeout).ConfigureAwait(false),
                    EntityName,
                    Consumer.ConnectionScope,
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
        /// Abandons a <see cref="ServiceBusMessage"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task AbandonAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiverClient));
            ThrowIfNotPeekLockMode();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await RetryPolicy.RunOperation(
                    async (timeout) => await AbandonAsyncInternal(lockToken, timeout, propertiesToModify).ConfigureAwait(false),
                    EntityName,
                    Consumer.ConnectionScope,
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
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new IMessageReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiverClient));
            ThrowIfNotPeekLockMode();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await RetryPolicy.RunOperation(
                    async (timeout) => await DeadLetterAsyncInternal(lockToken, timeout, propertiesToModify).ConfigureAwait(false),
                    EntityName,
                    Consumer.ConnectionScope,
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
            // MessagingEventSource.Log.MessageCompleteStop(ClientId);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="ServiceBusReceiverClient"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterAsync(
            string lockToken,
            string deadLetterReason,
            string deadLetterErrorDescription = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiverClient));
            ThrowIfNotPeekLockMode();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await RetryPolicy.RunOperation(
                    async (timeout) => await DeadLetterAsyncInternal(lockToken, timeout, null, deadLetterReason, deadLetterErrorDescription).ConfigureAwait(false),
                    EntityName,
                    Consumer.ConnectionScope,
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

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="ServiceBusMessage.SystemPropertiesCollection.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeferAsync(
            string lockToken,
            IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusReceiverClient));
            ThrowIfNotPeekLockMode();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await RetryPolicy.RunOperation(
                    async (timeout) => await DeferAsyncInternal(lockToken, timeout, propertiesToModify).ConfigureAwait(false),
                    EntityName,
                    Consumer.ConnectionScope,
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

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        ///
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="timeout"></param>
        internal virtual Task CompleteAsyncInternal(
            IEnumerable<string> lockTokens,
            TimeSpan timeout)
        {
            var lockTokenGuids = lockTokens.Select(lockToken => new Guid(lockToken)).ToArray();
            if (lockTokenGuids.Any(lockToken => RequestResponseLockedMessages.Contains(lockToken)))
            {
                string receiveLinkName = Consumer.GetReceiveLinkName();
                return Connection.DisposeMessageRequestResponseAsync(lockTokenGuids, timeout, DispositionStatus.Completed, IsSessionReceiver, Session.UserSpecifiedSessionId, receiveLinkName);
            }
            return Consumer.DisposeMessagesAsync(lockTokenGuids, AmqpConstants.AcceptedOutcome, timeout);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusMessage"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        internal virtual Task AbandonAsyncInternal(
            string lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            var lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any(lt => RequestResponseLockedMessages.Contains(lt)))
            {
                string receiveLinkName = Consumer.GetReceiveLinkName();
                return Connection.DisposeMessageRequestResponseAsync(lockTokens, timeout, DispositionStatus.Abandoned, IsSessionReceiver, Session.UserSpecifiedSessionId, receiveLinkName, propertiesToModify);
            }
            return Consumer.DisposeMessagesAsync(lockTokens, GetAbandonOutcome(propertiesToModify), timeout);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        internal virtual Task DeadLetterAsyncInternal(
            string lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterErrorDescription = null)
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
            if (lockTokens.Any(lt => RequestResponseLockedMessages.Contains(lt)))
            {
                string receiveLinkName = Consumer.GetReceiveLinkName();
                return Connection.DisposeMessageRequestResponseAsync(lockTokens, timeout, DispositionStatus.Suspended, IsSessionReceiver, Session.UserSpecifiedSessionId, receiveLinkName, propertiesToModify, deadLetterReason, deadLetterErrorDescription);
            }

            return Consumer.DisposeMessagesAsync(lockTokens, GetRejectedOutcome(propertiesToModify, deadLetterReason, deadLetterErrorDescription), timeout);
        }

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        ///
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="timeout"></param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        ///
        internal virtual Task DeferAsyncInternal(
            string lockToken,
            TimeSpan timeout,
            IDictionary<string, object> propertiesToModify = null)
        {
            var lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any(lt => RequestResponseLockedMessages.Contains(lt)))
            {
                string receiveLinkName = Consumer.GetReceiveLinkName();
                return Connection.DisposeMessageRequestResponseAsync(lockTokens, timeout, DispositionStatus.Defered, IsSessionReceiver, Session.UserSpecifiedSessionId, receiveLinkName, propertiesToModify);
            }
            return Consumer.DisposeMessagesAsync(lockTokens, GetDeferOutcome(propertiesToModify), timeout);
        }

        internal void ThrowIfNotPeekLockMode()
        {
            if (ReceiveMode != ReceiveMode.PeekLock)
            {
                throw new InvalidOperationException(Resources1.OperationNotSupported);
            }
        }

        internal Outcome GetAbandonOutcome(IDictionary<string, object> propertiesToModify)
        {
            return GetModifiedOutcome(propertiesToModify, false);
        }

        internal Outcome GetDeferOutcome(IDictionary<string, object> propertiesToModify)
        {
            return GetModifiedOutcome(propertiesToModify, true);
        }

        internal Outcome GetModifiedOutcome(
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

        internal Rejected GetRejectedOutcome(
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
                    rejected.Error.Info.Add(ServiceBusMessage.DeadLetterReasonHeader, deadLetterReason);
                }

                if (deadLetterErrorDescription != null)
                {
                    rejected.Error.Info.Add(ServiceBusMessage.DeadLetterErrorDescriptionHeader, deadLetterErrorDescription);
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

        /// <summary>
        /// Receives a specific deferred message identified by <paramref name="sequenceNumber"/>.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number of the message that will be received.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Message identified by sequence number <paramref name="sequenceNumber"/>. Returns null if no such message is found.
        /// Throws if the message has not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public virtual async Task<ServiceBusMessage> ReceiveDeferredMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<ServiceBusMessage> result = await ReceiveDeferredMessageBatchAsync(sequenceNumbers: new long[] { sequenceNumber }).ConfigureAwait(false);
            foreach (ServiceBusMessage message in result)
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
        public virtual async Task<IEnumerable<ServiceBusMessage>> ReceiveDeferredMessageBatchAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            // TODO implement
            return await PeekBatchAsync(10).ConfigureAwait(false);
        }

        /// <summary>
        /// Renews the lock on the message specified by the lock token. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <remarks>
        /// When a message is received in <see cref="ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        public virtual async Task RenewLockAsync(
            ServiceBusMessage message,
            CancellationToken cancellationToken = default)
        {
            message.SystemProperties.LockedUntilUtc = await RenewLockAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        /// </summary>
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// When a message is received in <see cref="ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        public virtual async Task<DateTime> RenewLockAsync(
            string lockToken,
            CancellationToken cancellationToken = default)
        {
            // TODO implement

            return await Task.FromResult(DateTime.Now).ConfigureAwait(false);
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
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusReceiverClient), EntityName, clientHash);

            // Attempt to close the transport consumer.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportConsumerException = default(Exception);

            try
            {
                await Consumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                RequestResponseLockedMessages.Close();
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusReceiverClient), EntityName, clientHash, ex.Message);
                transportConsumerException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusReceiverClient), EntityName, clientHash, ex.Message);
                transportConsumerException = null;
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusReceiverClient), EntityName, clientHash);
            }

            // If there was an active exception pending from closing the individual
            // transport consumers, surface it now.

            if (transportConsumerException != default)
            {
                throw transportConsumerException;
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusReceiverClient" />,
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
