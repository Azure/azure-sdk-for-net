﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
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
    ///   The <see cref="EventProcessorClient" /> is safe to cache and use for the lifetime of an application, and that is best practice when the application
    ///   processes events regularly or semi-regularly.  The processor holds responsibility for efficient resource management, working to keep resource usage low during
    ///   periods of inactivity and manage health during periods of higher use.  Calling either the <see cref="StopProcessingAsync" /> or <see cref="StopProcessing" />
    ///   method when processing is complete or as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.
    /// </remarks>
    ///
    [SuppressMessage("Usage", "CA1001:Types that own disposable fields should be disposable.", Justification = "Disposal is managed internally as part of the Stop operation.")]
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
        ///    Performs the tasks to initialize a partition, and its associated context, for event processing.
        ///
        ///   <para>It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.</para>
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
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
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
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
        ///  Performs the tasks needed to process a batch of events for a given partition as they are read from the Event Hubs service. Implementation is mandatory.
        ///
        ///  <para>Should an exception occur within the code for this handler, the <see cref="EventProcessorClient" /> will allow it to bubble and will not surface to the error handler or attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account, including the need to retry processing, and guard against them using try/catch blocks and other means,
        ///   as appropriate.</para>
        ///
        ///  <para>It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.</para>
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
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
        ///   <para>This error handler is invoked when there is an exception observed within the <see cref="EventProcessorClient" /> itself; it is not invoked for exceptions in
        ///   code that has been implemented to process events or other event handlers and extension points that execute developer code.  The <see cref="EventProcessorClient" /> will
        ///   make every effort to recover from exceptions and continue processing.  Should an exception that cannot be recovered from be encountered, the processor will attempt to forfeit
        ///   ownership of all partitions that it was processing so that work may be redistributed.</para>
        ///
        ///   <para>The exceptions surfaced to this method may be fatal or non-fatal; because the processor may not be able to accurately predict whether an
        ///   exception was fatal or whether its state was corrupted, this method has responsibility for making the determination as to whether processing
        ///   should be terminated or restarted.  The method may do so by calling Stop on the processor instance and then, if desired, calling Start on the processor.</para>
        ///
        ///   <para>It is recommended that, for production scenarios, the decision be made by considering observations made by this error handler, the method invoked
        ///   when initializing processing for a partition, and the method invoked when processing for a partition is stopped.  Many developers will also include
        ///   data from their monitoring platforms in this decision as well.</para>
        ///
        ///   <para>As with event processing, should an exception occur in the code for the error handler, the event processor will allow it to bubble and will not attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.</para>
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
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
        private StorageManager StorageManager { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.</para>
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
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.</para>
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
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.</para>
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
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   <para>The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.</para>
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
            StorageManager = CreateStorageManager(checkpointStore);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.
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
            StorageManager = CreateStorageManager(checkpointStore);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared access signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.
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
            StorageManager = CreateStorageManager(checkpointStore);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for persisting checkpoints and processor state to durable storage. The associated container is expected to exist.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   The container associated with the <paramref name="checkpointStore" /> is expected to exist; the <see cref="EventProcessorClient" />
        ///   does not assume the ability to manage the storage account and is safe to run with only read/write permission for blobs in the container.
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
            StorageManager = CreateStorageManager(checkpointStore);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="storageManager">Responsible for creation of checkpoints and for ownership claim.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
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
        internal EventProcessorClient(StorageManager storageManager,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      int cacheEventCount,
                                      TokenCredential credential,
                                      EventProcessorOptions clientOptions) : base(cacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
            Argument.AssertNotNull(storageManager, nameof(storageManager));

            DefaultStartingPosition = (clientOptions?.DefaultStartingPosition ?? DefaultStartingPosition);
            StorageManager = storageManager;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="storageManager">Responsible for creation of checkpoints and for ownership claim.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
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
        internal EventProcessorClient(StorageManager storageManager,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      int cacheEventCount,
                                      AzureNamedKeyCredential credential,
                                      EventProcessorOptions clientOptions) : base(cacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
            Argument.AssertNotNull(storageManager, nameof(storageManager));

            DefaultStartingPosition = (clientOptions?.DefaultStartingPosition ?? DefaultStartingPosition);
            StorageManager = storageManager;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="storageManager">Responsible for creation of checkpoints and for ownership claim.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
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
        internal EventProcessorClient(StorageManager storageManager,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      int cacheEventCount,
                                      AzureSasCredential credential,
                                      EventProcessorOptions clientOptions) : base(cacheEventCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
        {
            Argument.AssertNotNull(storageManager, nameof(storageManager));

            DefaultStartingPosition = (clientOptions?.DefaultStartingPosition ?? DefaultStartingPosition);
            StorageManager = storageManager;
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
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        internal Task UpdateCheckpointAsync(EventData eventData,
                                            PartitionContext context,
                                            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Argument.AssertNotNull(eventData, nameof(eventData));
            Argument.AssertInRange(eventData.Offset, long.MinValue + 1, long.MaxValue, nameof(eventData.Offset));
            Argument.AssertInRange(eventData.SequenceNumber, long.MinValue + 1, long.MaxValue, nameof(eventData.SequenceNumber));
            Argument.AssertNotNull(context, nameof(context));

            Logger.UpdateCheckpointStart(context.PartitionId, Identifier, EventHubName, ConsumerGroup);

            using var scope = EventDataInstrumentation.ScopeFactory.CreateScope(DiagnosticProperty.EventProcessorCheckpointActivityName);
            scope.Start();

            try
            {
                // Parameter validation is done by Checkpoint constructor.

                var checkpoint = new EventProcessorCheckpoint
                {
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    EventHubName = EventHubName,
                    ConsumerGroup = ConsumerGroup,
                    PartitionId = context.PartitionId,
                    StartingPosition = EventPosition.FromOffset(eventData.Offset)
                };

                return StorageManager.UpdateCheckpointAsync(checkpoint, eventData, cancellationToken);
            }
            catch (Exception ex)
            {
                // In case of failure, there is no need to call the error handler because the exception can
                // be thrown directly to the caller here.

                scope.Failed(ex);
                Logger.UpdateCheckpointError(context.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                throw;
            }
            finally
            {
                Logger.UpdateCheckpointComplete(context.PartitionId, Identifier, EventHubName, ConsumerGroup);
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
        ///   Produces a list of the available checkpoints for the Event Hub and consumer group associated with the
        ///   event processor instance, so that processing for a given set of partitions can be properly initialized.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of checkpoints for the processor to take into account when initializing partitions.</returns>
        ///
        /// <remarks>
        ///   Should a partition not have a corresponding checkpoint, the <see cref="EventProcessorOptions.DefaultStartingPosition" /> will
        ///   be used to initialize the partition for processing.
        ///
        ///   In the event that a custom starting point is desired for a single partition, or each partition should start at a unique place,
        ///   it is recommended that this method express that intent by returning checkpoints for those partitions with the desired custom
        ///   starting location set.
        /// </remarks>
        ///
        protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) =>
            throw new InvalidOperationException(Resources.ListCheckpointsAsyncObsolete);

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
        ///   Should a partition not have a corresponding checkpoint, the <see cref="EventProcessorOptions.DefaultStartingPosition" /> will
        ///   be used to initialize the partition for processing.
        ///
        ///   In the event that a custom starting point is desired for a single partition, or each partition should start at a unique place,
        ///   it is recommended that this method express that intent by returning checkpoints for those partitions with the desired custom
        ///   starting location set.
        /// </remarks>
        ///
        protected override async Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, CancellationToken cancellationToken)
        {
            var checkpoint = await StorageManager.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, cancellationToken).ConfigureAwait(false);

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
            StorageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken);

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
            StorageManager.ClaimOwnershipAsync(desiredOwnership, cancellationToken);

        /// <summary>
        ///   Performs the tasks needed to process a batch of events for a given partition as they are read from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="events">The batch of events to be processed.</param>
        /// <param name="partition">The context of the partition from which the events were read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <remarks>
        ///   <para>The number of events in the <paramref name="events" /> batch may vary.  The batch will contain a number of events between zero and batch size that was
        ///   requested when the processor was created, depending on the availability of events in the partition within the requested <see cref="EventProcessorOptions.MaximumWaitTime" />
        ///   interval.
        ///
        ///   If there are enough events available in the Event Hub partition to fill a batch of the requested size, the processor will populate the batch and dispatch it to this method
        ///   immediately.  If there were not a sufficient number of events available in the partition to populate a full batch, the event processor will continue reading from the partition
        ///   to reach the requested batch size until the <see cref="EventProcessorOptions.MaximumWaitTime" /> has elapsed, at which point it will return a batch containing whatever events were
        ///   available by the end of that period.
        ///
        ///   If a <see cref="EventProcessorOptions.MaximumWaitTime" /> was not requested, indicated by setting the option to <c>null</c>, the event processor will continue reading from the Event Hub
        ///   partition until a full batch of the requested size could be populated and will not dispatch any partial batches to this method.</para>
        ///
        ///   <para>Should an exception occur within the code for this method, the event processor will allow it to bubble and will not surface to the error handler or attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.</para>
        ///
        ///   <para>It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.</para>
        /// </remarks>
        ///
        protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                                  EventProcessorPartition partition,
                                                                  CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var context = default(PartitionContext);
            var eventArgs = default(ProcessEventArgs);
            var caughtExceptions = default(List<Exception>);
            var emptyBatch = true;

            try
            {
                Logger.EventBatchProcessingStart(partition.PartitionId, Identifier, EventHubName, ConsumerGroup);

                // Attempt to process each event in the batch, marking if the batch was non-empty.  Exceptions during
                // processing should be logged and cached, as the batch must be processed completely to avoid losing events.

                foreach (var eventData in events)
                {
                    emptyBatch = false;

                    try
                    {
                        context ??= new ProcessorPartitionContext(partition.PartitionId, () => ReadLastEnqueuedEventProperties(partition.PartitionId));
                        eventArgs = new ProcessEventArgs(context, eventData, updateToken => UpdateCheckpointAsync(eventData, context, updateToken), cancellationToken);

                        await _processEventAsync(eventArgs).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (!(ex is TaskCanceledException))
                    {
                        // This exception is not surfaced to the error handler or bubbled, as the entire batch must be
                        // processed or events will be lost.  Preserve the exceptions, should any occur.

                        Logger.EventBatchProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                        caughtExceptions ??= new List<Exception>();
                        caughtExceptions.Add(ex);
                    }
                }

                // If the event batch was empty, then dispatch to the handler; the base class will ensure that empty batches
                // are requested and will not invoke this method should empties not be sent to the handler.

                if (emptyBatch)
                {
                    eventArgs = new ProcessEventArgs(new EmptyPartitionContext(partition.PartitionId), null, EmptyEventUpdateCheckpoint, cancellationToken);
                    await _processEventAsync(eventArgs).ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (!(ex is TaskCanceledException))
            {
                // This exception was either not related to processing events or was the result of sending an empty batch to be
                // processed.  Since there would be no other caught exceptions, tread this like a single case.

                Logger.EventBatchProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                throw;
            }
            finally
            {
                Logger.EventBatchProcessingComplete(partition.PartitionId, Identifier, EventHubName, ConsumerGroup);
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

            var capturedValidationException = default(Exception);
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

                // Because the base class has no understanding of what concrete storage type is in use and
                // does not directly make use of some of its operations, such as writing a checkpoint.  Validate
                // these additional needs if a storage client is available.

                if (_containerClient != null)
                {
                    try
                    {
                        if (async)
                        {
                            await ValidateStartupAsync(async, _containerClient, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            ValidateStartupAsync(async, _containerClient, cancellationToken).EnsureCompleted();
                        }
                    }
                    catch (AggregateException ex)
                    {
                        // Capture the validation exception and log, but do not throw.  Because this is
                        // a fatal exception and the processing task was already started, StopProcessing
                        // will need to be called, which requires the semaphore.  The validation exception
                        // will be handled after the start operation has officially completed and the
                        // semaphore has been released.

                        capturedValidationException = ex.Flatten();
                    }
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

            // If there was a validation exception captured, then stop the processor now
            // that it is safe to do so.

            if (capturedValidationException != null)
            {
                try
                {
                    if (async)
                    {
                        await StopProcessingAsync(CancellationToken.None).ConfigureAwait(false);
                    }
                    else
                    {
                        StopProcessing(CancellationToken.None);
                    }
                }
                catch
                {
                    // An exception is expected here, as the processor configuration was invalid and
                    // processing was canceled.  It will have already been logged; ignore it here.
                }

                ExceptionDispatchInfo.Capture(capturedValidationException).Throw();
            }
        }

        /// <summary>
        ///   Creates a <see cref="StorageManager" /> to use for interacting with durable storage.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        ///
        /// <returns>A <see cref="StorageManager" /> with the requested configuration.</returns>
        ///
        private StorageManager CreateStorageManager(BlobContainerClient checkpointStore) => new BlobsCheckpointStore(checkpointStore, RetryPolicy);

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
                StartingPosition = PartitionStartingPositionDefaults.TryGetValue(partitionId, out EventPosition position) ? position : DefaultStartingPosition
            };
        }

        /// <summary>
        ///   Performs the tasks needed to validate basic configuration and permissions of the dependencies needed for
        ///   the processor to function.
        /// </summary>
        ///
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="containerClient">The <see cref="BlobContainerClient" /> to use for validating storage operations.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.</param>
        ///
        /// <exception cref="AggregateException">Any validation failures will result in an aggregate exception.</exception>
        ///
        private async Task ValidateStartupAsync(bool async,
                                                BlobContainerClient containerClient,
                                                CancellationToken cancellationToken = default)
        {
            var blobClient = containerClient.GetBlobClient($"EventProcessorPermissionCheck/{ Guid.NewGuid().ToString("N") }");

            // Write an blob with metadata, simulating the approach used for checkpoint and ownership
            // data creation.

            try
            {
                using var blobContent = new MemoryStream(Array.Empty<byte>());
                var blobMetadata = new Dictionary<string, string> {{ "name", blobClient.Name }};

                if (async)
                {
                    await blobClient.UploadAsync(blobContent, metadata: blobMetadata, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    blobClient.Upload(blobContent, metadata: blobMetadata, cancellationToken: cancellationToken);
                }
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
                    if (async)
                    {
                        await blobClient.DeleteIfExistsAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
                    }
                    else
                    {
                        blobClient.DeleteIfExists(cancellationToken: CancellationToken.None);
                    }
                }
                catch (Exception ex)
                {
                    Logger.ValidationCleanupError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                }
            }
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
            /// <param name="partitionId">The identifier of the partition that the context represents.</param>
            /// <param name="readLastEnqueuedEventProperties">A function that can be used to read the last enqueued event properties for the partition.</param>
            ///
            public ProcessorPartitionContext(string partitionId,
                                             Func<LastEnqueuedEventProperties> readLastEnqueuedEventProperties) : base(partitionId)
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
            /// <param name="partitionId">The identifier of the partition that the context represents.</param>
            ///
            public EmptyPartitionContext(string partitionId) : base(partitionId)
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
