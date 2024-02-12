// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Allows for consuming and processing events across all partitions of a given Event Hub within the scope of a specific
    ///   consumer group.  The processor is capable of collaborating with other instances for the same Event Hub and consumer
    ///   group pairing to share work by using a common storage platform to communicate.  Fault tolerance is also built-in,
    ///   allowing the processor to be resilient in the face of errors.
    /// </summary>
    ///
    /// <remarks>
    ///   To enable coordination for sharing of partitions between <see cref="EventProcessorClient"/> instances, they will assert exclusive read access to partitions
    ///   for the consumer group.  No other readers should be active in the consumer group other than processors intending to collaborate.  Non-exclusive readers will
    ///   be denied access; exclusive readers, including processors using a different storage locations, will interfere with the processor's operation and performance.
    ///
    ///   The <see cref="EventProcessorClient" /> is safe to cache and use for the lifetime of an application, and that is best practice when the application
    ///   processes events regularly or semi-regularly.  The processor is responsible for ensuring efficient network, CPU, and memory use.  Calling either
    ///   <see cref="StopProcessingAsync" /> or <see cref="StopProcessing" /> when processing is complete or as the application is shutting down will ensure
    ///   that network resources and other unmanaged objects are properly cleaned up.
    /// </remarks>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples">Event Hubs event processor samples and discussion</seealso>
    ///
    [SuppressMessage("Usage", "CA1001:Types that own disposable fields should be disposable.", Justification = "Disposal is managed internally as part of the Stop operation.")]
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "Event Hubs are AMQP-based services and don't use ClientOptions functionality")]
    public class EventProcessorClient : EventProcessor<EventProcessorPartition>
    {
        /// <summary>The delegate to invoke when attempting to update a checkpoint using an empty event.</summary>
        private static readonly Func<CancellationToken, Task> EmptyEventUpdateCheckpoint = cancellationToken => throw new InvalidOperationException(Resources.CannotCreateCheckpointForEmptyEvent);

        /// <summary>The set of default options for the processor.</summary>
        private static readonly EventProcessorClientOptions DefaultClientOptions = new EventProcessorClientOptions();

        /// <summary>The default starting position for the processor.</summary>
        private readonly EventPosition DefaultStartingPosition = new EventProcessorOptions().DefaultStartingPosition;

        /// <summary>The set of default starting positions for partitions being processed; these are collected at initialization and are surfaced as checkpoints to override defaults on a partition-specific basis.</summary>
        private readonly ConcurrentDictionary<string, EventPosition> PartitionStartingPositionDefaults = new ConcurrentDictionary<string, EventPosition>();

        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>
        private readonly SemaphoreSlim ProcessorStatusGuard = new SemaphoreSlim(1, 1);

        /// <summary>The client provided to perform storage operations related to checkpoints and ownership.</summary>
        private BlobContainerClient _containerClient;

        /// <summary>The handler to be called just before event processing starts for a given partition.</summary>
        private Func<PartitionInitializingEventArgs, Task> _partitionInitializingAsync;

        /// <summary>The handler to be called once event processing stops for a given partition.</summary>
        private Func<PartitionClosingEventArgs, Task> _partitionClosingAsync;

        /// <summary>Responsible for processing events received from the Event Hubs service.</summary>
        private Func<ProcessEventArgs, Task> _processEventAsync;

        /// <summary>Responsible for processing unhandled exceptions thrown while this processor is running.</summary>
        private Func<ProcessErrorEventArgs, Task> _processErrorAsync;

        /// <summary>
        ///   Performs the tasks to initialize a partition, and its associated context, for event processing.
        ///
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        /// </summary>
        ///
        /// <remarks>
        ///   This handler will be invoked concurrently, limited to one call per partition.  The processor will await each invocation before starting to process
        ///   the associated partition.
        ///
        ///   The processor will wait indefinitely for execution of the handler to complete.  It is recommended for
        ///   implementations to avoid long-running operations, as they will delay processing for the associated partition.
        /// </remarks>
        ///
        /// <seealso cref="OnInitializingPartitionAsync"/>
        ///
        /// <exception cref="ArgumentException">If an attempt is made to remove a handler that doesn't match the current handler registered.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add or remove a handler while the processor is running.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add a handler when one is currently registered.</exception>
        ///
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<PartitionInitializingEventArgs, Task> PartitionInitializingAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(PartitionInitializingAsync));

                if (_partitionInitializingAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionInitializingAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(PartitionInitializingAsync));

                if (_partitionInitializingAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionInitializingAsync = default);
            }
        }

        /// <summary>
        ///   Performs the tasks needed when processing for a partition is being stopped.  This commonly occurs when the partition is claimed by another event processor instance or when
        ///   the current event processor instance is shutting down.
        ///
        ///   <para>It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.</para>
        /// </summary>
        ///
        /// <remarks>
        ///   This handler will be invoked concurrently, as each close is independent.  No time limit is imposed on an invocation of this handler; it is safe for
        ///   implementations to perform long-running operations and retries as needed.  This handler has no influence on processing for the associated partition
        ///   and offers no guarantee that execution will complete before processing for the partition is restarted or migrates to a new host.
        /// </remarks>
        ///
        /// <seealso cref="OnPartitionProcessingStoppedAsync"/>
        ///
        /// <exception cref="ArgumentException">If an attempt is made to remove a handler that doesn't match the current handler registered.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add or remove a handler while the processor is running.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add a handler when one is currently registered.</exception>
        ///
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<PartitionClosingEventArgs, Task> PartitionClosingAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(PartitionClosingAsync));

                if (_partitionClosingAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionClosingAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(PartitionClosingAsync));

                if (_partitionClosingAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionClosingAsync = default);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to process a batch of events for a given partition as they are read from the Event Hubs service. Implementation is mandatory.
        ///
        ///   Should an exception occur within the code for this method, the event processor will allow it to propagate up the stack without attempting to handle it in any way.
        ///   On most hosts, this will fault the task responsible for partition processing, causing it to be restarted from the last checkpoint.  On some hosts, it may crash the process.
        ///   Developers are strongly encouraged to take all exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        ///
        ///   It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        /// </summary>
        ///
        /// <remarks>
        ///   This handler will be invoked concurrently, limited to one call per partition.  The processor will await each invocation to ensure that the events from
        ///   the same partition are processed one-at-a-time in the order that they were read from the partition.
        ///
        ///   No time limit is imposed on an invocation of this handler; the processor will wait indefinitely for execution to complete before dispatching another
        ///   event for the associated partition.  It is safe for implementations to perform long-running operations, retries, delays, and dead-lettering activities.
        /// </remarks>
        ///
        /// <seealso cref="OnProcessingEventBatchAsync"/>
        ///
        /// <exception cref="ArgumentException">If an attempt is made to remove a handler that doesn't match the current handler registered.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add or remove a handler while the processor is running.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add a handler when one is currently registered.</exception>
        ///
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessEventArgs, Task> ProcessEventAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessEventAsync));

                if (_processEventAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processEventAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessEventAsync));

                if (_processEventAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processEventAsync = default);
            }
        }

        /// <summary>
        ///   Performs the tasks needed when an unexpected exception occurs within the operation of the event processor infrastructure.  Implementation is mandatory.
        ///
        ///   This error handler is invoked when there is an exception observed within the <see cref="EventProcessorClient" /> itself; it is not invoked for exceptions in
        ///   code that has been implemented to process events or other event handlers and extension points that execute developer code.  The <see cref="EventProcessorClient" /> will
        ///   make every effort to recover from exceptions and continue processing.  Should an exception that cannot be recovered from be encountered, the processor will attempt to forfeit
        ///   ownership of all partitions that it was processing so that work may be redistributed.
        ///
        ///   The exceptions surfaced to this method may be fatal or non-fatal; because the processor may not be able to accurately predict whether an
        ///   exception was fatal or whether its state was corrupted, this method has responsibility for making the determination as to whether processing
        ///   should be terminated or restarted.  If desired, this can be done safely by calling <see cref="StopProcessingAsync" />  and/or <see cref="StartProcessingAsync" />.
        ///
        ///   It is recommended that, for production scenarios, the decision be made by considering observations made by this error handler, the method invoked
        ///   when initializing processing for a partition, and the method invoked when processing for a partition is stopped.  Many developers will also include
        ///   data from their monitoring platforms in this decision as well.
        ///
        ///   As with event processing, should an exception occur in the code for the error handler, the event processor will allow it to bubble and will not attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        /// </summary>
        ///
        /// <remarks>
        ///   This handler will be invoked concurrently and is not awaited by the processor, as each error is independent.  No time limit is imposed on an invocation of this handler;
        ///   it is safe for implementations to perform long-running operations and retries as needed.
        /// </remarks>
        ///
        /// <exception cref="ArgumentException">If an attempt is made to remove a handler that doesn't match the current handler registered.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add or remove a handler while the processor is running.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add a handler when one is currently registered.</exception>
        ///
        /// <seealso cref="OnProcessingErrorAsync"/>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/TROUBLESHOOTING.md">Troubleshoot Event Hubs issues</seealso>
        ///
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = default);
            }
        }

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public new string FullyQualifiedNamespace
        {
            get => base.FullyQualifiedNamespace;
        }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public new string EventHubName
        {
            get => base.EventHubName;
        }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public new string ConsumerGroup
        {
            get => base.ConsumerGroup;
        }

        /// <summary>
        ///   Indicates whether or not this event processor is currently running.
        /// </summary>
        ///
        public new bool IsRunning
        {
            get => base.IsRunning;
            protected set => base.IsRunning = value;
        }

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        /// <remarks>
        ///   The identifier can be set using the <see cref="EventProcessorClientOptions.Identifier"/> property on the
        ///   <see cref="EventProcessorClientOptions"/> passed when constructing the processor.  If not specified, a
        ///   random identifier will be generated.
        ///
        ///   It is recommended that you set a stable unique identifier for processor instances, as this allows
        ///   the processor to recover partition ownership when an application or host instance is restarted.  It
        ///   also aids readability in Azure SDK logs and allows for more easily correlating logs to a specific
        ///   processor instance.
        /// </remarks>
        ///
        public new string Identifier => base.Identifier;

        /// <summary>
        ///   The instance of <see cref="EventProcessorClientEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal EventProcessorClientEventSource Logger { get; set; } = EventProcessorClientEventSource.Log;

        /// <summary>
        ///   Responsible for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private CheckpointStore CheckpointStore { get; }

        /// <summary>
        ///   The client diagnostics for this processor.
        /// </summary>
        ///
        internal MessagingClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.</para>
        ///
        ///   <para>If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.</para>
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString) : this(checkpointStore, consumerGroup, connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.</para>
        ///
        ///   <para>If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.</para>
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString,
                                    EventProcessorClientOptions clientOptions) : this(checkpointStore, consumerGroup, connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.</para>
        ///
        ///   <para>If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.</para>
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString,
                                    string eventHubName) : this(checkpointStore, consumerGroup, connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.</para>
        ///
        ///   <para>If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.</para>
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString,
                                    string eventHubName,
                                    EventProcessorClientOptions clientOptions) : base((clientOptions ?? DefaultClientOptions).CacheEventCount, consumerGroup, connectionString, eventHubName, CreateOptions(clientOptions))
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            _containerClient = checkpointStore;
            CheckpointStore = new BlobCheckpointStoreInternal(checkpointStore);
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.
        /// </remarks>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    AzureNamedKeyCredential credential,
                                    EventProcessorClientOptions clientOptions = default) : base((clientOptions ?? DefaultClientOptions).CacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, CreateOptions(clientOptions))
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            _containerClient = checkpointStore;
            CheckpointStore = new BlobCheckpointStoreInternal(checkpointStore);
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared access signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.
        /// </remarks>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    AzureSasCredential credential,
                                    EventProcessorClientOptions clientOptions = default) : base((clientOptions ?? DefaultClientOptions).CacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, CreateOptions(clientOptions))
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            _containerClient = checkpointStore;
            CheckpointStore = new BlobCheckpointStoreInternal(checkpointStore);
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage.  Processor instances sharing this storage will attempt to coordinate and share work.  The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.  It is
        ///   recommended that this container be unique to the Event Hub and consumer group used by the processor and that it not contain other blobs.
        /// </remarks>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    TokenCredential credential,
                                    EventProcessorClientOptions clientOptions = default) : base((clientOptions ?? DefaultClientOptions).CacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, CreateOptions(clientOptions))
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            _containerClient = checkpointStore;
            CheckpointStore = new BlobCheckpointStoreInternal(checkpointStore);
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">Responsible for creation of checkpoints and for ownership claim.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="cacheEventCount">The maximum number of events that will be read from the Event Hubs service and held in a local memory cache when reading is active and events are being emitted to an enumerator for processing.</param>
        /// <param name="credential">An Azure identity credential to satisfy base class requirements; this credential may not be <c>null</c> but will only be used in the case that <see cref="CreateConnection" /> has not been overridden.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        internal EventProcessorClient(CheckpointStore checkpointStore,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      int cacheEventCount,
                                      TokenCredential credential,
                                      EventProcessorOptions clientOptions) : base(cacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            DefaultStartingPosition = (clientOptions?.DefaultStartingPosition ?? DefaultStartingPosition);
            CheckpointStore = checkpointStore;
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                eventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">Responsible for creation of checkpoints and for ownership claim.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="cacheEventCount">The maximum number of events that will be read from the Event Hubs service and held in a local memory cache when reading is active and events are being emitted to an enumerator for processing.</param>
        /// <param name="credential">A shared access key credential to satisfy base class requirements; this credential may not be <c>null</c> but will only be used in the case that <see cref="CreateConnection" /> has not been overridden.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        internal EventProcessorClient(CheckpointStore checkpointStore,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      int cacheEventCount,
                                      AzureNamedKeyCredential credential,
                                      EventProcessorOptions clientOptions) : base(cacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            DefaultStartingPosition = (clientOptions?.DefaultStartingPosition ?? DefaultStartingPosition);
            CheckpointStore = checkpointStore;
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                eventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">Responsible for creation of checkpoints and for ownership claim.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="cacheEventCount">The maximum number of events that will be read from the Event Hubs service and held in a local memory cache when reading is active and events are being emitted to an enumerator for processing.</param>
        /// <param name="credential">A shared access signature credential to satisfy base class requirements; this credential may not be <c>null</c> but will only be used in the case that <see cref="CreateConnection" /> has not been overridden.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        internal EventProcessorClient(CheckpointStore checkpointStore,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      int cacheEventCount,
                                      AzureSasCredential credential,
                                      EventProcessorOptions clientOptions) : base(cacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));

            DefaultStartingPosition = (clientOptions?.DefaultStartingPosition ?? DefaultStartingPosition);
            CheckpointStore = checkpointStore;
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                eventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        protected EventProcessorClient() : base()
        {
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessorClient" /> once it starts running.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when either the <see cref="ProcessEventAsync" /> handler or <see cref="ProcessErrorAsync" /> handler has not been registered.</exception>
        ///
        /// <exception cref="AggregateException">
        ///   As the processor starts, it will attempt to detect configuration and permissions errors that would prevent it from
        ///   being able to recover without intervention.  For example, an incorrect connection string or the inability to write to the
        ///   storage container would be detected.  These exceptions will be packaged as an <see cref="AggregateException"/>, and will cause
        ///   <see cref="StartProcessingAsync" /> to fail.
        /// </exception>
        ///
        public override async Task StartProcessingAsync(CancellationToken cancellationToken = default) =>
             await StartProcessingInternalAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessorClient" /> once it starts running.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when either the <see cref="ProcessEventAsync" /> handler or <see cref="ProcessErrorAsync" /> handler has not been registered.</exception>
        ///
        /// <exception cref="AggregateException">
        ///   As the processor starts, it will attempt to detect configuration and permissions errors that would prevent it from
        ///   being able to recover without intervention.  For example, an incorrect connection string or the inability to write to the
        ///   storage container would be detected.  These exceptions will be packaged as an <see cref="AggregateException"/>, and will cause
        ///   <see cref="StartProcessing" /> to fail.
        /// </exception>
        ///
        public override void StartProcessing(CancellationToken cancellationToken = default) =>
            StartProcessingInternalAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessorClient" /> will keep running.</param>
        ///
        /// <remarks>
        ///   When stopping, the processor will update the ownership of partitions that it was responsible for processing and clean up network resources used for communication with
        ///   the Event Hubs service.  As a result, this method will perform network I/O and may need to wait for partition reads that were active to complete.
        ///
        ///   <para>Due to service calls and network latency, an invocation of this method may take slightly longer than the specified <see cref="EventProcessorClientOptions.MaximumWaitTime" /> or
        ///   if the wait time was not configured, the duration of the <see cref="EventHubsRetryOptions.TryTimeout" /> of the configured retry policy.</para>
        /// </remarks>
        ///
        public override Task StopProcessingAsync(CancellationToken cancellationToken = default) => base.StopProcessingAsync(cancellationToken);

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessorClient" /> will keep running.</param>
        ///
        /// <remarks>
        ///   When stopping, the processor will update the ownership of partitions that it was responsible for processing and clean up network resources used for communication with
        ///   the Event Hubs service.  As a result, this method will perform network I/O and may need to wait for partition reads that were active to complete.
        ///
        ///   <para>Due to service calls and network latency, an invocation of this method may take slightly longer than the specified <see cref="EventProcessorClientOptions.MaximumWaitTime" /> or
        ///   if the wait time was not configured, the duration of the <see cref="EventHubsRetryOptions.TryTimeout" /> of the configured retry policy.</para>
        /// </remarks>
        ///
        public override void StopProcessing(CancellationToken cancellationToken = default) => base.StopProcessing(cancellationToken);

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
        ///   Performs the tasks needed to validate basic configuration and permissions of the dependencies needed for
        ///   the processor to function.
        /// </summary>
        ///
        /// <param name="containerClient">The <see cref="BlobContainerClient" /> to use for validating storage operations.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.</param>
        ///
        /// <exception cref="AggregateException">Any validation failures will result in an aggregate exception.</exception>
        ///
        internal async Task ValidateStoragePermissionsAsync(BlobContainerClient containerClient,
                                                            CancellationToken cancellationToken = default)
        {
            var blobClient = containerClient.GetBlobClient($"EventProcessorPermissionCheck/{ Guid.NewGuid().ToString("N") }");

            // Write an blob with metadata, simulating the approach used for checkpoint and ownership
            // data creation.

            try
            {
                using var blobContent = new MemoryStream(Array.Empty<byte>());
                var blobMetadata = new Dictionary<string, string> {{ "name", blobClient.Name }};

                await blobClient.UploadAsync(blobContent, metadata: blobMetadata, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AggregateException(ex);
            }
            finally
            {
                // Remove the test blob if written; do so without respecting a cancellation request to
                // ensure that the container is left in a consistent state.

                try
                {
                    await blobClient.DeleteIfExistsAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Logger.ValidationCleanupError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                }
            }
        }

        /// <summary>
        ///   Performs the tasks needed to validate basic configuration and permissions of the dependencies needed for
        ///   the processor to function.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the validation.</param>
        ///
        /// <exception cref="AggregateException">Any validation failures will result in an aggregate exception.</exception>
        ///
        protected override async Task ValidateProcessingPreconditions(CancellationToken cancellationToken)
        {
            // Because the base class has no understanding of what concrete storage type is in use and
            // does not directly make use of some of its operations, such as writing a checkpoint.  Validate
            // these additional needs if a storage client is available.

            await base.ValidateProcessingPreconditions(cancellationToken).ConfigureAwait(false);
            await ValidateStoragePermissionsAsync(_containerClient, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="offset">The offset to associate with the checkpoint, intended as informational metadata. This will only be used for positioning if there is no value provided for <paramref name="sequenceNumber"/>.</param>
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        protected override Task UpdateCheckpointAsync(string partitionId,
                                                      long offset,
                                                      long? sequenceNumber,
                                                      CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Argument.AssertNotNull(partitionId, nameof(partitionId));

            Logger.UpdateCheckpointStart(partitionId, Identifier, EventHubName, ConsumerGroup);

            using var scope = ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorCheckpointActivityName, ActivityKind.Internal);
            scope.Start();

            try
            {
                return CheckpointStore.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, offset, sequenceNumber, cancellationToken);
            }
            catch (Exception ex)
            {
                // In case of failure, there is no need to call the error handler because the exception can
                // be thrown directly to the caller here.

                scope.Failed(ex);
                Logger.UpdateCheckpointError(partitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                throw;
            }
            finally
            {
                Logger.UpdateCheckpointComplete(partitionId, Identifier, EventHubName, ConsumerGroup);
            }
        }

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="startingPosition">The starting position to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        protected override Task UpdateCheckpointAsync(string partitionId,
                                                      CheckpointPosition startingPosition,
                                                      CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Argument.AssertNotNull(partitionId, nameof(partitionId));
            Argument.AssertAtLeast(startingPosition.SequenceNumber, 0, nameof(startingPosition.SequenceNumber));

            Logger.UpdateCheckpointStart(partitionId, Identifier, EventHubName, ConsumerGroup);

            using var scope = ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorCheckpointActivityName, ActivityKind.Internal);
            scope.Start();

            try
            {
                return CheckpointStore.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, Identifier, startingPosition, cancellationToken);
            }
            catch (Exception ex)
            {
                // In case of failure, there is no need to call the error handler because the exception can
                // be thrown directly to the caller here.

                scope.Failed(ex);
                Logger.UpdateCheckpointError(partitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                throw;
            }
            finally
            {
                Logger.UpdateCheckpointComplete(partitionId, Identifier, EventHubName, ConsumerGroup);
            }
        }

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> to use for communicating with the Event Hubs service.
        /// </summary>
        ///
        /// <returns>The requested <see cref="EventHubConnection" />.</returns>
        ///
        protected override EventHubConnection CreateConnection() => base.CreateConnection();

        /// <summary>
        ///   Returns a checkpoint for the Event Hub, consumer group, and partition ID associated with the
        ///   event processor instance, so that processing for a given partition can be properly initialized.
        /// </summary>
        ///
        /// <param name="partitionId">The ID of the partition for which to retrieve the checkpoint.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The checkpoint for the processor to take into account when initializing partition.</returns>
        ///
        /// <remarks>
        ///   Should a partition not have a corresponding checkpoint, the default starting position set by the <see cref="PartitionInitializingAsync" /> handler
        ///   will be applied.  If no partition-specific starting point was specified, the <see cref="EventProcessorOptions.DefaultStartingPosition" /> will
        ///   be used to initialize the partition for processing.
        /// </remarks>
        ///
        protected override async Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, CancellationToken cancellationToken)
        {
            var checkpoint = await CheckpointStore.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, cancellationToken).ConfigureAwait(false);

            // If there was no initialization handler, no custom starting positions
            // could have been specified.  Return the checkpoint without further processing.

            if (_partitionInitializingAsync == null)
            {
                return checkpoint;
            }

            // Process the checkpoints to inject mock checkpoints for partitions that
            // specify a custom default and do not have an actual checkpoint.

            return checkpoint ?? CreateCheckpointWithDefaultStartingPosition(partitionId);
        }

        /// <summary>
        ///   Produces a list of the ownership assignments for partitions between each of the cooperating event processor
        ///   instances for a given Event Hub and consumer group pairing.  This method is used when load balancing to allow
        ///   the processor to discover other active collaborators and to make decisions about how to best balance work
        ///   between them.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records to take into account when making load balancing decisions.</returns>
        ///
        protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) =>
            CheckpointStore.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken);

        /// <summary>
        ///   Attempts to claim ownership of the specified partitions for processing.  This method is used by
        ///   load balancing to allow event processor instances to distribute the responsibility for processing
        ///   partitions for a given Event Hub and consumer group pairing amongst the active event processors.
        /// </summary>
        ///
        /// <param name="desiredOwnership">The set of partition ownership desired by the event processor instance; this is the set of partitions that it will attempt to request responsibility for processing.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records for the partitions that were successfully claimed; this is expected to be the <paramref name="desiredOwnership" /> or a subset of those partitions.</returns>
        ///
        protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                                                                                                   CancellationToken cancellationToken) =>
            CheckpointStore.ClaimOwnershipAsync(desiredOwnership, cancellationToken);

        /// <summary>
        ///   Performs the tasks needed to process a batch of events for a given partition as they are read from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="events">The batch of events to be processed.</param>
        /// <param name="partition">The context of the partition from which the events were read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <remarks>
        ///   The number of events in the <paramref name="events"/> batch may vary, with the batch containing between zero and maximum batch size that was specified when the processor was created.
        ///   The actual number of events in a batch depends on the number events available in the processor's prefetch queue at the time when a read takes place.
        ///
        ///   When at least one event is available in the prefetch queue, they will be used to form the batch as close to the requested maximum batch size as possible without waiting for additional
        ///   events from the Event Hub partition to be read.  When no events are available in prefetch the processor will wait until at least one event is available or the requested
        ///   <see cref="EventProcessorOptions.MaximumWaitTime"/> has elapsed, after which the batch will be dispatched for processing.
        ///
        ///   If <see cref="EventProcessorOptions.MaximumWaitTime"/> is <c>null</c>, the processor will continue trying to read from the Event Hub partition until a batch with at least one event could
        ///   be formed and will not dispatch any empty batches to this method.
        ///
        ///   This method will be invoked concurrently, limited to one call per partition. The processor will await each invocation to ensure
        ///   that the events from the same partition are processed in the order that they were read from the partition.  No time limit is
        ///   imposed on an invocation of this handler; the processor will wait indefinitely for execution to complete before dispatching another
        ///   event for the associated partition.  It is safe for implementations to perform long-running operations, retries, delays, and dead-lettering activities.
        ///
        ///   Should an exception occur within the code for this method, the event processor will allow it to propagate up the stack without attempting to handle it in any way.
        ///   On most hosts, this will fault the task responsible for partition processing, causing it to be restarted from the last checkpoint.  On some hosts, it may crash the process.
        ///   Developers are strongly encouraged to take all exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        ///
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        /// </remarks>
        ///
        protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                                  EventProcessorPartition partition,
                                                                  CancellationToken cancellationToken)
        {
            // If cancellation was requested, then do not dispatch the events to be handled.  This
            // is considered a normal exit condition, rather than an exceptional case.

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var operation = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);
            var context = default(PartitionContext);
            var eventArgs = default(ProcessEventArgs);
            var caughtExceptions = default(List<Exception>);
            var emptyBatch = true;

            try
            {
                Logger.EventBatchProcessingStart(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation);

                // Attempt to process each event in the batch, marking if the batch was non-empty.  Exceptions during
                // processing should be logged and cached, as the batch must be processed completely to avoid losing events.

                foreach (var eventData in events)
                {
                    // If cancellation was requested, then either partition ownership was lost or the processor is
                    // shutting down.  In either case, dispatching of events to be handled should cease.  Since this
                    // flow is entirely internal, there's no benefit to throwing a cancellation exception; instead,
                    // just exit the loop.

                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    emptyBatch = false;

                    try
                    {
                        Logger.EventBatchProcessingHandlerCall(eventData.SequenceNumber.ToString(), partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation);

                        context ??= new ProcessorPartitionContext(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition.PartitionId, () => ReadLastEnqueuedEventProperties(partition.PartitionId));
                        eventArgs = new ProcessEventArgs(context, eventData, updateToken => UpdateCheckpointAsync(partition.PartitionId, CheckpointPosition.FromEvent(eventData), updateToken), cancellationToken);

                        await _processEventAsync(eventArgs).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (!(ex is TaskCanceledException))
                    {
                        // This exception is not surfaced to the error handler or bubbled, as the entire batch must be
                        // processed or events will be lost.  Preserve the exceptions, should any occur.

                        Logger.EventBatchProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation, ex.Message);

                        caughtExceptions ??= new List<Exception>();
                        caughtExceptions.Add(ex);
                    }
                }

                // If the event batch was empty, then dispatch to the handler; the base class will ensure that empty batches
                // are requested and will not invoke this method should empties not be sent to the handler.

                if (emptyBatch)
                {
                    Logger.EventBatchProcessingHandlerCall("<< No Event >>", partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation);

                    eventArgs = new ProcessEventArgs(new EmptyPartitionContext(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition.PartitionId), null, EmptyEventUpdateCheckpoint, cancellationToken);
                    await _processEventAsync(eventArgs).ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (!(ex is TaskCanceledException))
            {
                // This exception was either not related to processing events or was the result of sending an empty batch to be
                // processed.  Since there would be no other caught exceptions, tread this like a single case.

                Logger.EventBatchProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation, ex.Message);
                throw;
            }
            finally
            {
                Logger.EventBatchProcessingComplete(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation);
            }

            // Deal with any exceptions that occurred while processing the batch.  If more than one was
            // present, preserve them in an aggregate exception for transport.

            if (caughtExceptions != null)
            {
                if (caughtExceptions.Count == 1)
                {
                    ExceptionDispatchInfo.Capture(caughtExceptions[0]).Throw();
                }

                throw new AggregateException(Resources.AggregateEventProcessingExceptionMessage, caughtExceptions);
            }
        }

        /// <summary>
        ///   Performs the tasks needed when an unexpected exception occurs within the operation of the
        ///   event processor infrastructure.
        /// </summary>
        ///
        /// <param name="exception">The exception that occurred during operation of the event processor.</param>
        /// <param name="partition">The context of the partition associated with the error, if any; otherwise, <c>null</c>.  This may only be initialized for members of <see cref="EventProcessorPartition" />, depending on the point at which the error occurred.</param>
        /// <param name="operationDescription">A short textual description of the operation during which the exception occurred; intended to be informational only.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <remarks>
        ///   This error handler is invoked when there is an exception observed within the event processor itself; it is not invoked for exceptions in
        ///   code that has been implemented to process events or other overrides and extension points that are not critical to the processor's operation.
        ///   The event processor will make every effort to recover from exceptions and continue processing.  Should an exception that cannot be recovered
        ///   from be encountered, the processor will attempt to forfeit ownership of all partitions that it was processing so that work may be redistributed.
        ///
        ///   The exceptions surfaced to this method may be fatal or non-fatal; because the processor may not be able to accurately predict whether an
        ///   exception was fatal or whether its state was corrupted, this method has responsibility for making the determination as to whether processing
        ///   should be terminated or restarted.  The method may do so by calling Stop on the processor instance and then, if desired, calling Start on the processor.
        ///
        ///   It is recommended that, for production scenarios, the decision be made by considering observations made by this error handler, the method invoked
        ///   when initializing processing for a partition, and the method invoked when processing for a partition is stopped.  Many developers will also include
        ///   data from their monitoring platforms in this decision as well.
        ///
        ///   As with event processing, should an exception occur in the code for the error handler, the event processor will allow it to bubble and will not attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        /// </remarks>
        ///
        protected override async Task OnProcessingErrorAsync(Exception exception,
                                                             EventProcessorPartition partition,
                                                             string operationDescription,
                                                             CancellationToken cancellationToken)
        {
            var eventArgs = new ProcessErrorEventArgs(partition?.PartitionId, operationDescription, exception, cancellationToken);
            await _processErrorAsync(eventArgs).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks to initialize a partition, and its associated context, for event processing.
        /// </summary>
        ///
        /// <param name="partition">The context of the partition being initialized.  Only the well-known members of the <see cref="EventProcessorPartition" /> will be populated.  If a custom context is being used, the implementor of this method is responsible for initializing custom members.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the initialization.  This is most likely to occur if the partition is claimed by another event processor instance or the processor is shutting down.</param>
        ///
        /// <remarks>
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        /// </remarks>
        ///
        protected override async Task OnInitializingPartitionAsync(EventProcessorPartition partition,
                                                                   CancellationToken cancellationToken)
        {
            // Handlers cannot be changed while the processor is running; it is safe to check and call
            // without capturing a local reference.

            if (_partitionInitializingAsync != null)
            {
                var eventArgs = new PartitionInitializingEventArgs(partition.PartitionId, DefaultStartingPosition, cancellationToken);
                await _partitionInitializingAsync(eventArgs).ConfigureAwait(false);

                PartitionStartingPositionDefaults[partition.PartitionId] = eventArgs.DefaultStartingPosition;
            }
        }

        /// <summary>
        ///   Performs the tasks needed when processing for a partition is being stopped.  This commonly occurs when the partition
        ///   is claimed by another event processor instance or when the current event processor instance is shutting down.
        /// </summary>
        ///
        /// <param name="partition">The context of the partition for which processing is being stopped.</param>
        /// <param name="reason">The reason that processing is being stopped for the partition.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the processing.  This is not expected to signal under normal circumstances and will only occur if the processor encounters an unrecoverable error.</param>
        ///
        /// <remarks>
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        /// </remarks>
        ///
        protected override async Task OnPartitionProcessingStoppedAsync(EventProcessorPartition partition,
                                                                        ProcessingStoppedReason reason,
                                                                        CancellationToken cancellationToken)
        {
            // Handlers cannot be changed while the processor is running; it is safe to check and call
            // without capturing a local reference.

            if (_partitionClosingAsync != null)
            {
                var eventArgs = new PartitionClosingEventArgs(partition.PartitionId, reason, cancellationToken);
                await _partitionClosingAsync(eventArgs).ConfigureAwait(false);
            }

            PartitionStartingPositionDefaults.TryRemove(partition.PartitionId, out var _);
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to begin processing events.  If the processor is already
        ///   running when this is called, no action is taken.
        /// </summary>
        ///
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessor{TPartition}" /> once it starts running.</param>
        ///
        private async Task StartProcessingInternalAsync(bool async,
                                                        CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            var releaseGuard = false;

            try
            {
                // Acquire the semaphore used to synchronize processor starts and stops, respecting
                // the async flag.  When this is held, the state of the processor is stable.

                if (async)
                {
                    await ProcessorStatusGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    ProcessorStatusGuard.Wait(cancellationToken);
                }

                releaseGuard = true;

                // Validate that the required handlers are assigned.

                if (_processEventAsync == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessEventAsync)));
                }

                if (_processErrorAsync == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsync)));
                }

                // Allow the base class to perform its startup operation; this will include validation for
                // the basic Event Hubs and storage configuration.

                if (async)
                {
                    await base.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    base.StartProcessing(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                throw new TaskCanceledException();
            }
            finally
            {
                if (releaseGuard)
                {
                    ProcessorStatusGuard.Release();
                }
            }
        }

        /// <summary>
        ///   Creates a checkpoint with a default starting position set.
        /// </summary>
        ///
        /// <param name="partitionId">The partition id.</param>
        ///
        /// <returns>Returns an artificial checkpoint for a provided partition with a starting position set to <see cref="DefaultStartingPosition"/>.</returns>
        ///
        private EventProcessorCheckpoint CreateCheckpointWithDefaultStartingPosition(string partitionId)
        {
            return new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = partitionId,
                StartingPosition = PartitionStartingPositionDefaults.TryGetValue(partitionId, out EventPosition position) ? position : DefaultStartingPosition,
                ClientIdentifier = Identifier
            };
        }

        /// <summary>
        ///   Invokes a specified action only if this <see cref="EventProcessorClient" /> instance is not running.
        /// </summary>
        ///
        /// <param name="action">The action to invoke.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked while the event processor is running.</exception>
        ///
        private void EnsureNotRunningAndInvoke(Action action)
        {
            var releaseGuard = false;

            if (!IsRunning)
            {
                try
                {
                    ProcessorStatusGuard.Wait();
                    releaseGuard = true;

                    if (!IsRunning)
                    {
                        action?.Invoke();
                        return;
                    }
                }
                finally
                {
                    if (releaseGuard)
                    {
                        ProcessorStatusGuard.Release();
                    }
                }
            }

            throw new InvalidOperationException(Resources.RunningEventProcessorCannotPerformOperation);
        }

        /// <summary>
        ///   Creates the set of options to pass to the base <see cref="EventProcessorClient" />.
        /// </summary>
        ///
        /// <param name="clientOptions">The set of client options for the <see cref="EventProcessorClient" /> instance.</param>
        ///
        /// <returns>The set of options to use for the base processor.</returns>
        ///
        private static EventProcessorOptions CreateOptions(EventProcessorClientOptions clientOptions)
        {
            clientOptions ??= DefaultClientOptions;

            return new EventProcessorOptions
            {
                ConnectionOptions = clientOptions.ConnectionOptions.Clone(),
                RetryOptions = clientOptions.RetryOptions.Clone(),
                Identifier = clientOptions.Identifier,
                MaximumWaitTime = clientOptions.MaximumWaitTime,
                TrackLastEnqueuedEventProperties = clientOptions.TrackLastEnqueuedEventProperties,
                LoadBalancingStrategy = clientOptions.LoadBalancingStrategy,
                PrefetchCount = clientOptions.PrefetchCount,
                PrefetchSizeInBytes = clientOptions.PrefetchSizeInBytes,
                LoadBalancingUpdateInterval = clientOptions.LoadBalancingUpdateInterval,
                PartitionOwnershipExpirationInterval = clientOptions.PartitionOwnershipExpirationInterval
            };
        }

        /// <summary>
        ///   Represents a basic partition context for event processing within the processor client.
        /// </summary>
        ///
        /// <seealso cref="Azure.Messaging.EventHubs.Consumer.PartitionContext" />
        ///
        private class ProcessorPartitionContext : PartitionContext
        {
            /// <summary>A function that can be used to read the last enqueued event properties for the partition.</summary>
            private Func<LastEnqueuedEventProperties> _readLastEnqueuedEventProperties;

            /// <summary>
            ///   Initializes a new instance of the <see cref="EmptyPartitionContext" /> class.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
            /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
            /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
            /// <param name="readLastEnqueuedEventProperties">A function that can be used to read the last enqueued event properties for the partition.</param>
            ///
            public ProcessorPartitionContext(string fullyQualifiedNamespace,
                                             string eventHubName,
                                             string consumerGroup,
                                             string partitionId,
                                             Func<LastEnqueuedEventProperties> readLastEnqueuedEventProperties) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId)
            {
                _readLastEnqueuedEventProperties = readLastEnqueuedEventProperties;
            }

            /// <summary>
            ///   A set of information about the last enqueued event of a partition, not available for the
            ///   empty context.
            /// </summary>
            ///
            /// <returns>The set of properties for the last event that was enqueued to the partition.</returns>
            ///
            public override LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() => _readLastEnqueuedEventProperties();
        }

        /// <summary>
        ///   Represents a basic partition context for event processing when the
        ///   full context was not available.
        /// </summary>
        ///
        /// <seealso cref="Azure.Messaging.EventHubs.Consumer.PartitionContext" />
        ///
        private class EmptyPartitionContext : PartitionContext
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="EmptyPartitionContext" /> class.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
            /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
            /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
            ///
            public EmptyPartitionContext(string fullyQualifiedNamespace,
                                         string eventHubName,
                                         string consumerGroup,
                                         string partitionId) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId)
            {
            }

            /// <summary>
            ///   A set of information about the last enqueued event of a partition, not available for the
            ///   empty context.
            /// </summary>
            ///
            /// <returns>The set of properties for the last event that was enqueued to the partition.</returns>
            ///
            /// <exception cref="InvalidOperationException">The method call is not available on the <see cref="EmptyPartitionContext" />.</exception>
            ///
            public override LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() =>
                throw new InvalidOperationException(Resources.CannotReadLastEnqueuedEventPropertiesWithoutEvent);
        }
    }
}
