// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;

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
    public class ServiceBusProcessorClient : IAsyncDisposable
    {
        private Func<ServiceBusMessage, ServiceBusSession, Task> _processMessage;

        private Func<ExceptionReceivedEventArgs, Task> _processErrorAsync = default;
        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>

        private readonly object EventHandlerGuard = new object();
        /// <summary>The primitive for synchronizing access during start and close operations.</summary>

        private SemaphoreSlim MessageHandlerSemaphore;
        /// <summary>The primitive for synchronizing access during start and close operations.</summary>

        private readonly SemaphoreSlim ProcessingStartStopSemaphore = new SemaphoreSlim(1, 1);

        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        private readonly ServiceBusReceiverClient _receiver;

        /// <summary>
        ///   The running task responsible for performing partition load balancing between multiple <see cref="ServiceBusProcessorClient" />
        ///   instances, as well as managing partition processing tasks and ownership.
        /// </summary>
        ///
        private Task ActiveReceiveTask { get; set; }

        /// <summary>
        ///   Called when a 'process message' event is triggered.
        /// </summary>
        ///
        /// <param name="message">The set of arguments to identify the context of the event to be processed.</param>
        /// <param name="session"></param>
        ///
        private Task OnProcessMessageAsync(ServiceBusMessage message, ServiceBusSession session) => _processMessage(message, session);

        /// <summary>
        ///   Called when a 'process error' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the error to be processed.</param>
        ///
        private Task OnProcessErrorAsync(ExceptionReceivedEventArgs eventArgs) => _processErrorAsync(eventArgs);

        /// <summary>
        ///   The fully qualified Service Bus namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => _receiver.Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Service Bus entity that the consumer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName => _receiver.Connection.EntityName;

        /// <summary>
        ///
        /// </summary>
        public ReceiveMode ReceiveMode => _receiver.ReceiveMode;

        /// <summary>
        ///
        /// </summary>
        public bool IsSessionReceiver => _receiver.IsSessionReceiver;

        /// <summary>
        ///
        /// </summary>
        public uint PrefetchCount => _receiver.PrefetchCount;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusProcessorClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed => _receiver.IsClosed;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private ServiceBusRetryPolicy RetryPolicy => _receiver.RetryPolicy;

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        ///
        internal ServiceBusConnection Connection => _receiver.Connection;

        /// <summary>
        ///   An abstracted Service Bus entity transport-specific producer that is associated with the
        ///   Service Bus entity gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        internal TransportConsumer Consumer => _receiver.Consumer;

        /// <summary>
        ///
        /// </summary>
        public ServiceBusSession Session => _receiver.Session;

        /// <summary>
        ///
        /// </summary>
        public ServiceBusSubscription Subscription => _receiver.Subscription;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
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
        public ServiceBusProcessorClient(string connectionString)
            : this(new ServiceBusConnection(connectionString), new ServiceBusProcessorClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
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
        public ServiceBusProcessorClient(
            string connectionString,
            ServiceBusProcessorClientOptions clientOptions)
            : this(new ServiceBusConnection(connectionString, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusProcessorClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
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
        public ServiceBusProcessorClient(
            string connectionString,
            string queueOrSubscriptionName,
            ServiceBusProcessorClientOptions clientOptions = default)
            : this(new ServiceBusConnection(connectionString, queueOrSubscriptionName, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusProcessorClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
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
        public ServiceBusProcessorClient(
            string connectionString,
            string topicName,
            string subscriptionName,
            ServiceBusProcessorClientOptions clientOptions = default)
            : this(new ServiceBusConnection(connectionString, EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusProcessorClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="queueName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public ServiceBusProcessorClient(
            string fullyQualifiedNamespace,
            string queueName,
            TokenCredential credential,
            ServiceBusProcessorClientOptions clientOptions = default)
            : this(new ServiceBusConnection(fullyQualifiedNamespace, queueName, credential, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusProcessorClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public ServiceBusProcessorClient(
            string fullyQualifiedNamespace,
            string topicName,
            string subscriptionName,
            TokenCredential credential,
            ServiceBusProcessorClientOptions clientOptions = default)
            : this(new ServiceBusConnection(fullyQualifiedNamespace, EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), credential, clientOptions?.ConnectionOptions), clientOptions?.Clone() ?? new ServiceBusProcessorClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public ServiceBusProcessorClient(
            ServiceBusConnection connection,
            ServiceBusProcessorClientOptions clientOptions = default)
        {
            _receiver = new ServiceBusReceiverClient(connection, clientOptions?.ToServiceBusReceiverClientOptions() ?? new ServiceBusReceiverClientOptions());
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessorClient"/> class.
        /// </summary>
        ///
        protected ServiceBusProcessorClient()
        {
        }

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        /// <param name="lockToken">The lock token of the <see cref="ServiceBusMessage" />.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusMessage.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="ServiceBusMessage.SystemPropertiesCollection.SequenceNumber"/>
        /// and receive it using <see cref="ServiceBusReceiverClient.ReceiveDeferredMessageAsync(long, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeferAsync(string lockToken, IDictionary<string, object> propertiesToModify = null,
            CancellationToken cancellationToken = default)
        {
            // TODO implement
            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="ServiceBusProcessorClient"/>, with the corresponding path.
        /// You can use EntityNameHelper.FormatDeadLetterPath(string) to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public virtual async Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null,
            CancellationToken cancellationToken = default)
        {
            // TODO implement

            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
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
            message.SystemProperties.LockedUntilUtc = await _receiver.RenewLockAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            await _receiver.CloseAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusProcessorClient" />,
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
        ///   The event responsible for processing events received from the Event Hubs service.  Implementation
        ///   is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ServiceBusMessage, ServiceBusSession, Task> ProcessMessageAsync
        {
            add
            {
                lock (EventHandlerGuard)
                {

                    Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                    if (_processMessage != default)
                    {
                        throw new NotSupportedException(Resources1.HandlerHasAlreadyBeenAssigned);
                    }
                    EnsureNotRunningAndInvoke(() => _processMessage = value);
                }
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processMessage != value)
                {
                    throw new ArgumentException(Resources1.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processMessage = default);
            }
        }

        /// <summary>
        ///   The event responsible for processing unhandled exceptions thrown while this processor is running.
        ///   Implementation is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ExceptionReceivedEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != default)
                {
                    throw new NotSupportedException(Resources1.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != value)
                {
                    throw new ArgumentException(Resources1.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = default);
            }
        }

        /// <summary>
        ///   Signals the <see cref="ServiceBusProcessorClient" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        /// <param name="processingOptions"></param>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="ServiceBusProcessorClient" /> once it starts running.</param>
        ///
        /// exception cref="EventHubsException">Occurs when this <see cref="ServiceBusProcessorClient" /> instance is already closed./exception>
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessMessageAsync" /> or <see cref="ProcessErrorAsync" /> set.</exception>
        ///
        public virtual async Task StartProcessingAsync(
            ProcessingOptions processingOptions = default,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            if (ActiveReceiveTask == null && MessageHandlerSemaphore == null)
            {
                MessageHandlerSemaphore = new SemaphoreSlim(
                    processingOptions.MaxConcurrentCalls,
                    processingOptions.MaxConcurrentCalls);
                await ProcessingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    lock (EventHandlerGuard)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        if (ActiveReceiveTask == null)
                        {
                            if (_processMessage == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotStartEventProcessorWithoutHandler, nameof(ProcessMessageAsync)));
                            }

                            if (_processErrorAsync == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsync)));
                            }

                            // We expect the token source to be null, but we are playing safe.

                            RunningTaskTokenSource?.Cancel();
                            RunningTaskTokenSource?.Dispose();
                            RunningTaskTokenSource = new CancellationTokenSource();

                            // Start the main running task.  It is responsible for managing the active partition processing tasks and
                            // for partition load balancing among multiple event processor instances.

                            //Logger.EventProcessorStart(Identifier);
                            ActiveReceiveTask = RunReceiveTaskAsync(
                                processingOptions,
                                RunningTaskTokenSource.Token);
                        }
                    }
                }
                finally
                {
                    ProcessingStartStopSemaphore.Release();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        ///   Signals the <see cref="ServiceBusProcessorClient" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="ServiceBusProcessorClient" /> will keep running.</param>
        ///
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            //Logger.EventProcessorStopStart(Identifier);
            await ProcessingStartStopSemaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                if (ActiveReceiveTask != null)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    // Cancel the current running task.

                    RunningTaskTokenSource.Cancel();
                    RunningTaskTokenSource.Dispose();
                    RunningTaskTokenSource = null;

                    // Now that a cancellation request has been issued, wait for the running task to finish.  In case something
                    // unexpected happened and it stopped working midway, this is the moment we expect to catch an exception.

                    try
                    {
                        await ActiveReceiveTask.ConfigureAwait(false);
                    }
                    catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
                    {
                        // Nothing to do here.  These exceptions are expected.
                    }
                    catch (Exception)
                    {
                        //Logger.LoadBalancingTaskError(Identifier, ex.Message);
                    }

                    ActiveReceiveTask.Dispose();
                    ActiveReceiveTask = null;
                }
            }
            finally
            {
                ProcessingStartStopSemaphore.Release();
                //Logger.EventProcessorStopComplete(Identifier);
            }
        }

        /// <summary>
        ///   Runs the Receive task in as many threads as are
        ///   specified in the <see cref="ProcessingOptions.MaxConcurrentCalls"/> property.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RunReceiveTaskAsync(
            ProcessingOptions options,
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await MessageHandlerSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    Task _ = GetAndProcessMessagesAsync(options, cancellationToken);
                }
                catch (Exception)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                }
            }
            // If cancellation has been requested, throw an exception so we can keep a consistent behavior.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
        }

        private async Task GetAndProcessMessagesAsync(
            ProcessingOptions options,
            CancellationToken cancellationToken)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            bool useThreadLocalConsumer = false;
            TransportConsumer consumer;
            Task renewLock = null;

            if (IsSessionReceiver && Session.UserSpecifiedSessionId == null)
            {
                // If the user didn't specify a session, but this is a sessionful receiver,
                // we want to allow each thread to have its own consumer so we can access
                // multiple sessions concurrently.
                consumer = Connection.CreateTransportConsumer(
                    retryPolicy: RetryPolicy,
                    receiveMode: ReceiveMode,
                    isSessionReceiver: true);
                useThreadLocalConsumer = true;
            }
            else
            {
                consumer = Consumer;
            }

            try
            {
                // loop within the context of this thread
                while (!cancellationToken.IsCancellationRequested)
                {
                    ServiceBusMessage message = null;
                    string action = ExceptionReceivedEventArgsAction.Receive;
                    try
                    {
                        IEnumerable<ServiceBusMessage> messages = await consumer.ReceiveAsync(
                            1,
                            cancellationToken).ConfigureAwait(false);
                        var enumerator = messages.GetEnumerator();
                        if (enumerator.MoveNext())
                        {
                            message = enumerator.Current;
                        }
                        else
                        {
                            // no messages returned, so exit the loop as we are likely out of messages
                            // in the case of sessions, this means we will create a new consumer and potentially use a different session
                            break;
                        }

                        if (ReceiveMode == ReceiveMode.PeekLock && options.AutoRenewLock)
                        {
                            action = ExceptionReceivedEventArgsAction.RenewLock;
                            renewLockCancellationTokenSource = new CancellationTokenSource();
                            renewLockCancellationTokenSource.CancelAfter(options.MaxAutoLockRenewalDuration);
                            renewLock = RenewLock(
                                consumer,
                                message,
                                cancellationToken,
                                renewLockCancellationTokenSource.Token);
                        }

                        action = ExceptionReceivedEventArgsAction.UserCallback;

                        // if this is a session receiver, supply a session object to the callback so that users can
                        // perform operations on this session
                        ServiceBusSession session = null;
                        if (IsSessionReceiver)
                        {
                            session = new ServiceBusSession(consumer, message.SessionId);
                        }
                        await OnProcessMessageAsync(message, session).ConfigureAwait(false);

                        try
                        {
                            if (renewLockCancellationTokenSource != null)
                            {
                                renewLockCancellationTokenSource.Cancel();
                                await renewLock.ConfigureAwait(false);
                            }
                        }
                        catch (Exception ex) when (ex is OperationCanceledException)
                        {
                            // Nothing to do here.  These exceptions are expected.
                        }

                        if (ReceiveMode == ReceiveMode.PeekLock && options.AutoComplete)
                        {
                            action = ExceptionReceivedEventArgsAction.Complete;
                            await CompleteAsync(
                                message.SystemProperties.LockToken,
                                cancellationToken)
                                .ConfigureAwait(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        await RaiseExceptionReceived(
                            // TODO - add clientId implementation and pass as last argument to ExceptionReceivedEventArgs
                            new ExceptionReceivedEventArgs(ex, action, FullyQualifiedNamespace, EntityName, "")).ConfigureAwait(false);
                        await AbandonAsync(message.SystemProperties.LockToken).ConfigureAwait(false);

                    }
                    finally
                    {
                        renewLockCancellationTokenSource?.Cancel();
                        renewLockCancellationTokenSource?.Dispose();
                    }
                }
            }
            finally
            {
                MessageHandlerSemaphore.Release();
                if (useThreadLocalConsumer)
                {
                    await consumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
            }
        }

        private void CancelAutoRenewLock(object state)
        {
            var renewLockCancellationTokenSource = (CancellationTokenSource)state;
            try
            {
                renewLockCancellationTokenSource.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // Ignore this race.
            }
        }

        private async Task RenewLock(
            TransportConsumer consumer,
            ServiceBusMessage message,
            CancellationToken eventCancellationToken,
            CancellationToken renewLockCancellationToken)
        {
            while (!eventCancellationToken.IsCancellationRequested && !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    DateTimeOffset lockedUntil = default;
                    if (IsSessionReceiver)
                    {
                        lockedUntil = await consumer.GetSessionLockedUntilUtcAsync(eventCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        lockedUntil = message.SystemProperties.LockedUntilUtc;
                    }

                    TimeSpan delay = CalculateRenewDelay(lockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, renewLockCancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    if (IsSessionReceiver)
                    {
                        await Session.RenewSessionLockAsync(renewLockCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await RenewLockAsync(message, renewLockCancellationToken).ConfigureAwait(false);
                    }
                    //MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(this.messageReceiver.ClientId, message);
                }

                catch (Exception exception)
                {
                    //MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(this.messageReceiver.ClientId, message, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await RaiseExceptionReceived(
                            new ExceptionReceivedEventArgs(
                                exception,
                                ExceptionReceivedEventArgsAction.RenewLock,
                                FullyQualifiedNamespace,
                                EntityName,
                                "")).ConfigureAwait(false);
                    }

                    if (!(exception as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        private static TimeSpan CalculateRenewDelay(DateTimeOffset lockedUntilUtc)
        {
            var remainingTime = lockedUntilUtc - DateTime.UtcNow;

            if (remainingTime < TimeSpan.FromMilliseconds(400))
            {
                return TimeSpan.Zero;
            }

            var buffer = TimeSpan.FromTicks(Math.Min(remainingTime.Ticks / 2, Constants.MaximumRenewBufferDuration.Ticks));
            var renewAfter = remainingTime - buffer;

            return renewAfter;
        }

        /// <summary>
        ///   Invokes a specified action only if this <see cref="ServiceBusProcessorClient" /> instance is not running.
        /// </summary>
        ///
        /// <param name="action">The action to invoke.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked while the event processor is running.</exception>
        ///
        private void EnsureNotRunningAndInvoke(Action action)
        {
            if (ActiveReceiveTask == null)
            {
                lock (EventHandlerGuard)
                {
                    if (ActiveReceiveTask == null)
                    {
                        action?.Invoke();
                    }
                    else
                    {
                        throw new InvalidOperationException(Resources1.RunningMessageProcessorCannotPerformOperation);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(Resources1.RunningMessageProcessorCannotPerformOperation);
            }
        }

        internal async Task RaiseExceptionReceived(ExceptionReceivedEventArgs eventArgs)
        {
            try
            {
                await OnProcessErrorAsync(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.ExceptionReceivedHandlerThrewException(exception);
            }
        }
    }
}
