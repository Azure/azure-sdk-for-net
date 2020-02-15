// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Receiver
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
    public abstract class ServiceBusReceiverClient : IAsyncDisposable
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
        internal string EntityName => Connection.EntityName;

        /// <summary>
        ///
        /// </summary>
        public ReceiveMode ReceiveMode { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public int PrefetchCount { get; }

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
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        /// <param name="sessionId"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        internal ServiceBusReceiverClient(
            string connectionString,
            string entityName,
            string sessionId,
            ServiceBusReceiverClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));

            OwnsConnection = true;
            Connection = new ServiceBusConnection(connectionString, entityName, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            ReceiveMode = clientOptions.ReceiveMode;
            Consumer = Connection.CreateTransportConsumer(retryPolicy: RetryPolicy, sessionId: sessionId);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="sessionId"></param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        internal ServiceBusReceiverClient(
            string fullyQualifiedNamespace,
            string entityName,
            TokenCredential credential,
            string sessionId,
            ServiceBusReceiverClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));

            OwnsConnection = true;
            Connection = new ServiceBusConnection(fullyQualifiedNamespace, entityName, credential, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            ReceiveMode = clientOptions.ReceiveMode;
            Consumer = Connection.CreateTransportConsumer(retryPolicy: RetryPolicy, sessionId:sessionId);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="sessionId"></param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        internal ServiceBusReceiverClient(
            ServiceBusConnection connection,
            string sessionId,
            ServiceBusReceiverClientOptions clientOptions)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));

            OwnsConnection = false;
            Connection = connection;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            ReceiveMode = clientOptions.ReceiveMode;
            Consumer = Connection.CreateTransportConsumer(retryPolicy: RetryPolicy, sessionId: sessionId);
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
        ///
        /// </summary>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async IAsyncEnumerable<ServiceBusMessage> ReceiveRangeAsync(
            int maxMessages,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            foreach (ServiceBusMessage message in await Consumer.ReceiveAsync(maxMessages, TimeSpan.FromSeconds(100), cancellationToken).ConfigureAwait(false))
            {
                yield return message;
            }
        }

        /// <summary>
        /// Get a SessionReceiverClient scoped to the ServiceBusReceiverClient entity and a specified session.
        /// Note once the SessionReceiverClient is created it will be scoped to only the specified session for its lifetime.
        /// </summary>
        /// <param name="sessionId">Session to receive messages from.</param>
        /// <returns>A SessionReceiverClient instance scoped to the ServiceBusReceiverClient entity and specified session.</returns>
        public SessionReceiverClient GetSessionReceiverClient(string sessionId) =>
            new SessionReceiverClient(Connection, sessionId);

        /// <summary>
        /// Get a SessionReceiverClient scoped to the current entity without specifying a particular session.
        /// The broker will decide what session to use for operations. Note once the SessionReceiverClient is created,
        /// it will be scoped to only one session for its lifetime.
        /// </summary>
        /// <returns>A SessionReceiverClient instance scoped to the ServiceBusReceiverClient entity and session determined by the broker.</returns>
        public SessionReceiverClient GetSessionReceiverClient() =>
            GetSessionReceiverClient(null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ServiceBusMessage> ReceiveAsync(
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerator<ServiceBusMessage> result = PeekRangeBySequenceAsync(fromSequenceNumber: 1).GetAsyncEnumerator();
            await result.MoveNextAsync().ConfigureAwait(false);
            return result.Current;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ServiceBusMessage> PeekAsync(CancellationToken cancellationToken = default)
        {
            IAsyncEnumerator<ServiceBusMessage> result = PeekRangeBySequenceAsync(fromSequenceNumber: 1).GetAsyncEnumerator();
            await result.MoveNextAsync().ConfigureAwait(false);
            return result.Current;
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
            var result = PeekRangeBySequenceAsync(fromSequenceNumber: fromSequenceNumber).GetAsyncEnumerator();
            await result.MoveNextAsync().ConfigureAwait(false);
            return result.Current;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async IAsyncEnumerable<ServiceBusMessage> PeekRangeAsync(
            int maxMessages,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<ServiceBusMessage> ret = PeekRangeBySequenceAsync(fromSequenceNumber: 1, maxMessages);
            await foreach (ServiceBusMessage msg in ret.ConfigureAwait(false))
            {
                yield return msg;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async IAsyncEnumerable<ServiceBusMessage> PeekRangeBySequenceAsync(
            long fromSequenceNumber,
            int maxMessages = 1,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<ServiceBusMessage> ret = PeekRangeBySequenceInternal(
                fromSequenceNumber: fromSequenceNumber,
                maxMessages: maxMessages,
                cancellationToken: cancellationToken);
            await foreach (ServiceBusMessage msg in ret.ConfigureAwait(false))
            {
                yield return msg;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async IAsyncEnumerable<ServiceBusMessage> PeekRangeBySequenceInternal(
            long? fromSequenceNumber,
            int maxMessages = 1,
            string sessionId = null,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            string receiveLinkName = "";

            if (Consumer.ReceiveLink.TryGetOpenedObject(out ReceivingAmqpLink link))
            {
                receiveLinkName = link.Name;
            }

            foreach (ServiceBusMessage message in await Connection.PeekAsync(
                RetryPolicy,
                fromSequenceNumber,
                maxMessages,
                sessionId,
                receiveLinkName,
                cancellationToken)
                .ConfigureAwait(false))
            {
                yield return message;
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
        public virtual async Task<ServiceBusMessage> ReceiveDeferredMessageAsync(long sequenceNumber,
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerator<ServiceBusMessage> result = ReceiveDeferredMessageRangeAsync(sequenceNumbers: new long[] { sequenceNumber }).GetAsyncEnumerator();
            await result.MoveNextAsync().ConfigureAwait(false);
            return result.Current;
        }

        /// <summary>
        /// Receives a <see cref="IList{Message}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public virtual async IAsyncEnumerable<ServiceBusMessage> ReceiveDeferredMessageRangeAsync(
            IEnumerable<long> sequenceNumbers,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<ServiceBusMessage> result = PeekRangeAsync(10);
            await foreach (ServiceBusMessage msg in result.ConfigureAwait(false))
            {
                yield return msg;
            }
        }
        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="ServiceBusMessage.SystemPropertiesCollection.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeferAsync(string lockToken, IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            // TODO implement
            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new IMessageReceiver"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify = null, CancellationToken cancellationToken = default)
        {
            // TODO implement

            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="ServiceBusReceiverClient"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null,
            CancellationToken cancellationToken = default)
        {
            // TODO implement

            await Task.Delay(1).ConfigureAwait(false);
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
        /// Completes a <see cref="ServiceBusMessage"/> using its lock token. This will delete the message from the service.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task CompleteAsync(string lockToken, CancellationToken cancellationToken = default)
        {
            // TODO implement

            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        /// Completes a series of <see cref="ServiceBusMessage"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <param name="cancellationToken"></param>
        public virtual async Task CompleteAsync(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            // TODO implement

            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        /// Abandons a <see cref="ServiceBusMessage"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken"></param>
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
            // TODO implement

            await Task.Delay(1).ConfigureAwait(false);
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


        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.
        /// Use  cref="RegisterMessageHandler(Func{Message,CancellationToken,Task}, MessageHandlerOptions)"/> to configure the settings of the pump.</remarks>
        ///
        // TODO remove if won't be used
        public void RegisterMessageHandler(Func<ServiceBusMessage, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            this.RegisterMessageHandler(handler, new MessageHandlerOptions(exceptionReceivedHandler));
        }

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="messageHandlerOptions">The <see cref="MessageHandlerOptions"/> options used to configure the settings of the pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.</remarks>
        // TODO remove if won't be used
        protected void RegisterMessageHandler(Func<ServiceBusMessage, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
        }

        /// <summary>
        /// Receive session messages continuously from the queue. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{IMessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the queue client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{IMessageSession, Message, CancellationToken, Task}"/> that processes messages.
        ///  cref="IMessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="ServiceBusMessage"/></param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.
        /// Use  cref="RegisterSessionHandler(Func{IMessageSession,Message,CancellationToken,Task}, SessionHandlerOptions)"/> to configure the settings of the pump.</remarks>
        // TODO remove if won't be used

        public void RegisterSessionHandler(Func<SessionReceiverClient, ServiceBusMessage, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            var sessionHandlerOptions = new SessionHandlerOptions(exceptionReceivedHandler);
            this.RegisterSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>
        /// Receive session messages continuously from the queue. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{IMessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the queue client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{IMessageSession, Message, CancellationToken, Task}"/> that processes messages.
        ///  cref="IMessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="ServiceBusMessage"/></param>
        /// <param name="sessionHandlerOptions">Options used to configure the settings of the session pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate. </remarks>
        public void RegisterSessionHandler(Func<SessionReceiverClient, ServiceBusMessage, CancellationToken, Task> handler, SessionHandlerOptions sessionHandlerOptions)
        {
            // TODO remove if won't be used

        }

        internal RetriableContext CreateRetriableContext(CancellationToken cancellationToken) =>
             new RetriableContext(
                Consumer.ConnectionScope,
                new Stopwatch(),
                RetryPolicy,
                EntityName,
                cancellationToken);
    }
}
