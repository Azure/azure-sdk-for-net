// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Primitives;
    using Microsoft.Azure.Storage;

    /// <summary>
    /// Represents a host for processing Event Hubs event data.
    /// </summary>
    public sealed class EventProcessorHost
    {
        // A processor host will work on either the token provider or the connection string.
        readonly ITokenProvider tokenProvider;
        string eventHubConnectionString;

        /// <summary>
        /// Create a new host to process events from an Event Hub.
        ///
        /// <para>Since Event Hubs are frequently used for scale-out, high-traffic scenarios, generally there will
        /// be only one host per process, and the processes will be run on separate machines. However, it is
        /// supported to run multiple hosts on one machine, or even within one process, if throughput is not
        /// a concern.</para>
        ///
        /// This overload of the constructor uses the default, built-in lease and checkpoint managers. The
        /// Azure Storage account specified by the storageConnectionString parameter is used by the built-in
        /// managers to record leases and checkpoints.
        /// </summary>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="eventHubConnectionString">Connection string for the Event Hub to receive from.</param>
        /// <param name="storageConnectionString">Connection string to Azure Storage account used for leases and checkpointing.</param>
        /// <param name="leaseContainerName">Azure Storage container name for use by built-in lease and checkpoint manager.</param>
        public EventProcessorHost(
            string eventHubPath,
            string consumerGroupName,
            string eventHubConnectionString,
            string storageConnectionString,
            string leaseContainerName)
            : this(EventProcessorHost.CreateHostName(null),
                eventHubPath,
                consumerGroupName,
                eventHubConnectionString,
                storageConnectionString,
                leaseContainerName,
                null)
        {
        }

        /// <summary>
        /// Create a new host to process events from an Event Hub.
        ///
        /// <para>This overload of the constructor uses the default, built-in lease and checkpoint managers.</para>
        /// </summary>
        /// <param name="hostName">Name of the processor host. MUST BE UNIQUE. Strongly recommend including a Guid to ensure uniqueness.</param>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="eventHubConnectionString">Connection string for the Event Hub to receive from.</param>
        /// <param name="storageConnectionString">Connection string to Azure Storage account used for leases and checkpointing.</param>
        /// <param name="leaseContainerName">Azure Storage container name for use by built-in lease and checkpoint manager.</param>
        /// <param name="storageBlobPrefix">Prefix used when naming blobs within the storage container.</param>
        public EventProcessorHost(
            string hostName,
            string eventHubPath,
            string consumerGroupName,
            string eventHubConnectionString,
            string storageConnectionString,
            string leaseContainerName,
            string storageBlobPrefix = null)
            : this(hostName,
                eventHubPath,
                consumerGroupName,
                eventHubConnectionString,
                new AzureStorageCheckpointLeaseManager(storageConnectionString, leaseContainerName, storageBlobPrefix))
        {
        }

        /// <summary>
        /// Create a new host to process events from an Event Hub.
        ///
        /// <para>This overload of the constructor allows maximum flexibility.
        /// This one allows the caller to specify the name of the processor host as well.
        /// The overload also allows the caller to provide their own lease and checkpoint managers to replace the built-in
        /// ones based on Azure Storage.</para>
        /// </summary>
        /// <param name="hostName">Name of the processor host. MUST BE UNIQUE. Strongly recommend including a Guid to ensure uniqueness.</param>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="eventHubConnectionString">Connection string for the Event Hub to receive from.</param>
        /// <param name="checkpointManager">Object implementing ICheckpointManager which handles partition checkpointing.</param>
        /// <param name="leaseManager">Object implementing ILeaseManager which handles leases for partitions.</param>
        public EventProcessorHost(
             string hostName,
             string eventHubPath,
             string consumerGroupName,
             string eventHubConnectionString,
             ICheckpointManager checkpointManager,
             ILeaseManager leaseManager)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(hostName), hostName);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(consumerGroupName), consumerGroupName);
            Guard.ArgumentNotNull(nameof(checkpointManager), checkpointManager);
            Guard.ArgumentNotNull(nameof(leaseManager), leaseManager);

            var csb = new EventHubsConnectionStringBuilder(eventHubConnectionString);
            if (string.IsNullOrEmpty(eventHubPath))
            {
                // Entity path is expected in the connection string if not provided with eventHubPath parameter.
                if (string.IsNullOrEmpty(csb.EntityPath))
                {
                    throw new ArgumentException(nameof(eventHubConnectionString),
                        "Provide EventHub entity path either in eventHubPath parameter or in eventHubConnectionString.");
                }
            }
            else
            {
                // Entity path should not conflict with connection string.
                if (!string.IsNullOrEmpty(csb.EntityPath) &&
                    string.Compare(csb.EntityPath, eventHubPath, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    throw new ArgumentException(nameof(eventHubConnectionString),
                        "Provided EventHub path in eventHubPath parameter conflicts with the path in provided EventHubs connection string.");
                }

                csb.EntityPath = eventHubPath;
            }

            this.HostName = hostName;
            this.EventHubPath = csb.EntityPath;
            this.ConsumerGroupName = consumerGroupName;
            this.eventHubConnectionString = csb.ToString();
            this.CheckpointManager = checkpointManager;
            this.LeaseManager = leaseManager;
            this.TransportType = csb.TransportType;
            this.OperationTimeout = csb.OperationTimeout;
            this.EndpointAddress = csb.Endpoint;
            this.PartitionManager = new PartitionManager(this);
            ProcessorEventSource.Log.EventProcessorHostCreated(this.HostName, this.EventHubPath);
        }

        /// <summary>
        /// Create a new host to process events from an Event Hub with provided <see cref="TokenProvider"/>
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="cloudStorageAccount">Azure Storage account used for leases and checkpointing.</param>
        /// <param name="leaseContainerName">Azure Storage container name for use by built-in lease and checkpoint manager.</param>
        public EventProcessorHost(
            Uri endpointAddress,
            string eventHubPath,
            string consumerGroupName,
            ITokenProvider tokenProvider,
            CloudStorageAccount cloudStorageAccount,
            string leaseContainerName)
            : this(EventProcessorHost.CreateHostName(null),
                  endpointAddress,
                  eventHubPath,
                  consumerGroupName,
                  tokenProvider,
                  cloudStorageAccount,
                  leaseContainerName)
        {
        }

        /// <summary>
        /// Create a new host to process events from an Event Hub with provided <see cref="TokenProvider"/>
        /// </summary>
        /// <param name="hostName">Name of the processor host. MUST BE UNIQUE. Strongly recommend including a Guid to ensure uniqueness.</param>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="cloudStorageAccount">Azure Storage account used for leases and checkpointing.</param>
        /// <param name="leaseContainerName">Azure Storage container name for use by built-in lease and checkpoint manager.</param>
        /// <param name="storageBlobPrefix">Prefix used when naming blobs within the storage container.</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations.</param>
        /// <param name="transportType">Transport type on connection.</param>
        public EventProcessorHost(
            string hostName,
            Uri endpointAddress,
            string eventHubPath,
            string consumerGroupName,
            ITokenProvider tokenProvider,
            CloudStorageAccount cloudStorageAccount,
            string leaseContainerName,
            string storageBlobPrefix = null,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
            : this(hostName,
                  endpointAddress,
                  eventHubPath,
                  consumerGroupName,
                  tokenProvider,
                  new AzureStorageCheckpointLeaseManager(cloudStorageAccount, leaseContainerName, storageBlobPrefix),
                  operationTimeout,
                  transportType)
        {
        }

        /// <summary>
        /// Create a new host to process events from an Event Hub with provided <see cref="TokenProvider"/>
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="cloudStorageAccount">Azure Storage account used for leases and checkpointing.</param>
        /// <param name="leaseContainerName">Azure Storage container name for use by built-in lease and checkpoint manager.</param>
        /// <param name="storageBlobPrefix">Prefix used when naming blobs within the storage container.</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations.</param>
        /// <param name="transportType">Transport type on connection.</param>
        public EventProcessorHost(
            Uri endpointAddress,
            string eventHubPath,
            string consumerGroupName,
            ITokenProvider tokenProvider,
            CloudStorageAccount cloudStorageAccount,
            string leaseContainerName,
            string storageBlobPrefix = null,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
            : this(EventProcessorHost.CreateHostName(null),
                endpointAddress,
                eventHubPath,
                consumerGroupName,
                tokenProvider,
                cloudStorageAccount,
                leaseContainerName,
                storageBlobPrefix,
                operationTimeout,
                transportType)
        {
        }

        /// <summary>
        /// Create a new host to process events from an Event Hub with provided <see cref="TokenProvider"/>
        /// </summary>
        /// <param name="hostName">Name of the processor host. MUST BE UNIQUE. Strongly recommend including a Guid to ensure uniqueness.</param>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="eventHubPath">The name of the EventHub.</param>
        /// <param name="consumerGroupName">The name of the consumer group within the Event Hub.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="checkpointManager">Object implementing ICheckpointManager which handles partition checkpointing.</param>
        /// <param name="leaseManager">Object implementing ILeaseManager which handles leases for partitions.</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations.</param>
        /// <param name="transportType">Transport type on connection.</param>
        public EventProcessorHost(
            string hostName,
            Uri endpointAddress,
            string eventHubPath,
            string consumerGroupName,
            ITokenProvider tokenProvider,
            ICheckpointManager checkpointManager,
            ILeaseManager leaseManager,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(hostName), hostName);
            Guard.ArgumentNotNull(nameof(endpointAddress), endpointAddress);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(consumerGroupName), consumerGroupName);
            Guard.ArgumentNotNull(nameof(tokenProvider), tokenProvider);
            Guard.ArgumentNotNull(nameof(checkpointManager), checkpointManager);
            Guard.ArgumentNotNull(nameof(leaseManager), leaseManager);

            this.HostName = hostName;
            this.EndpointAddress = endpointAddress;
            this.EventHubPath = eventHubPath;
            this.ConsumerGroupName = consumerGroupName;
            this.tokenProvider = tokenProvider;
            this.CheckpointManager = checkpointManager;
            this.LeaseManager = leaseManager;
            this.TransportType = transportType;
            this.OperationTimeout = operationTimeout ?? ClientConstants.DefaultOperationTimeout;
            this.PartitionManager = new PartitionManager(this);
            ProcessorEventSource.Log.EventProcessorHostCreated(this.HostName, this.EventHubPath);
        }

        // Using this intermediate constructor to create single combined manager to be used as
        // both lease manager and checkpoint manager.
        EventProcessorHost(
                string hostName,
                string eventHubPath,
                string consumerGroupName,
                string eventHubConnectionString,
                AzureStorageCheckpointLeaseManager combinedManager)
            : this(hostName,
                  eventHubPath,
                  consumerGroupName,
                  eventHubConnectionString,
                  combinedManager,
                  combinedManager)
        {
        }

        // Using this intermediate constructor to create single combined manager to be used as
        // both lease manager and checkpoint manager.
        EventProcessorHost(
            string hostName,
            Uri endpointAddress,
            string eventHubPath,
            string consumerGroupName,
            ITokenProvider tokenProvider,
            AzureStorageCheckpointLeaseManager combinedManager,
            TimeSpan? operationTimeout = null,
            TransportType transportType = TransportType.Amqp)
            : this(hostName,
                endpointAddress,
                eventHubPath,
                consumerGroupName,
                tokenProvider,
                combinedManager,
                combinedManager,
                operationTimeout,
                transportType)
        {
        }

        /// <summary>
        /// Returns processor host name.
        /// If the processor host name was automatically generated, this is the only way to get it.
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// Gets the event hub path.
        /// </summary>
        public string EventHubPath { get; }

        /// <summary>
        /// Gets the consumer group name.
        /// </summary>
        public string ConsumerGroupName { get; }

        /// <summary>
        /// Gets the event endpoint URI.
        /// </summary>
        public Uri EndpointAddress { get; }

        /// <summary>
        /// Gets the transport type.
        /// </summary>
        public TransportType TransportType { get; }

        /// <summary>
        /// Gets the operation timeout.
        /// </summary>
        public TimeSpan OperationTimeout { get; internal set; }

        /// <summary>Gets or sets the
        /// <see cref="PartitionManagerOptions" /> instance used by the
        /// <see cref="EventProcessorHost" /> object.</summary>
        /// <value>The <see cref="PartitionManagerOptions" /> instance.</value>
        public PartitionManagerOptions PartitionManagerOptions { get; set; }

        // All of these accessors are for internal use only.
        internal ICheckpointManager CheckpointManager { get; }

        internal EventProcessorOptions EventProcessorOptions { get; private set; }

        internal ILeaseManager LeaseManager { get; private set; }

        internal IEventProcessorFactory ProcessorFactory { get; private set; }

        internal PartitionManager PartitionManager { get; private set; }

        /// <summary>
        /// This registers <see cref="IEventProcessor"/> implementation with the host using <see cref="DefaultEventProcessorFactory{T}"/>.
        /// This also starts the host and causes it to start participating in the partition distribution process.
        /// </summary>
        /// <typeparam name="T">Implementation of your application specific <see cref="IEventProcessor"/>.</typeparam>
        /// <returns>A task to indicate EventProcessorHost instance is started.</returns>
        public Task RegisterEventProcessorAsync<T>() where T : IEventProcessor, new()
        {
            return RegisterEventProcessorAsync<T>(EventProcessorOptions.DefaultOptions);
        }

        /// <summary>
        /// This registers <see cref="IEventProcessor"/> implementation with the host using <see cref="DefaultEventProcessorFactory{T}"/>.
        /// This also starts the host and causes it to start participating in the partition distribution process.
        /// </summary>
        /// <typeparam name="T">Implementation of your application specific <see cref="IEventProcessor"/>.</typeparam>
        /// <param name="processorOptions"><see cref="EventProcessorOptions"/> to control various aspects of message pump created when ownership
        /// is acquired for a particular partition of EventHub.</param>
        /// <returns>A task to indicate EventProcessorHost instance is started.</returns>
        public Task RegisterEventProcessorAsync<T>(EventProcessorOptions processorOptions) where T : IEventProcessor, new()
        {
            IEventProcessorFactory f = new DefaultEventProcessorFactory<T>();
            return RegisterEventProcessorFactoryAsync(f, processorOptions);
        }

        /// <summary>
        /// This registers <see cref="IEventProcessorFactory"/> implementation with the host which is used to create an instance of
        /// <see cref="IEventProcessor"/> when it takes ownership of a partition.  This also starts the host and causes it to start participating
        /// in the partition distribution process.
        /// </summary>
        /// <param name="factory">Instance of <see cref="IEventProcessorFactory"/> implementation.</param>
        /// <returns>A task to indicate EventProcessorHost instance is started.</returns>
        public Task RegisterEventProcessorFactoryAsync(IEventProcessorFactory factory)
        {
            var epo = EventProcessorOptions.DefaultOptions;
            epo.ReceiveTimeout = TimeSpan.MinValue;
            return RegisterEventProcessorFactoryAsync(factory, epo);
        }

        /// <summary>
        /// This registers <see cref="IEventProcessorFactory"/> implementation with the host which is used to create an instance of
        /// <see cref="IEventProcessor"/> when it takes ownership of a partition.  This also starts the host and causes it to start participating
        /// in the partition distribution process.
        /// </summary>
        /// <param name="factory">Instance of <see cref="IEventProcessorFactory"/> implementation.</param>
        /// <param name="processorOptions"><see cref="EventProcessorOptions"/> to control various aspects of message pump created when ownership
        /// is acquired for a particular partition of EventHub.</param>
        /// <returns>A task to indicate EventProcessorHost instance is started.</returns>
        public async Task RegisterEventProcessorFactoryAsync(IEventProcessorFactory factory, EventProcessorOptions processorOptions)
        {
            Guard.ArgumentNotNull(nameof(factory), factory);
            Guard.ArgumentNotNull(nameof(processorOptions), processorOptions);

            // Initialize partition manager options with default values if not already set by the client.
            if (this.PartitionManagerOptions == null)
            {
                // Assign partition manager with default options.
                this.PartitionManagerOptions = new PartitionManagerOptions();
            }

            ProcessorEventSource.Log.EventProcessorHostOpenStart(this.HostName, factory.GetType().ToString());

            try
            {
                // Override operation timeout by receive timeout?
                if (processorOptions.ReceiveTimeout > TimeSpan.MinValue)
                {
                    this.OperationTimeout = processorOptions.ReceiveTimeout;

                    if (this.eventHubConnectionString != null)
                    {
                        var cbs = new EventHubsConnectionStringBuilder(this.eventHubConnectionString)
                        {
                            OperationTimeout = processorOptions.ReceiveTimeout
                        };
                        this.eventHubConnectionString = cbs.ToString();
                    }
                }

                // Initialize lease manager if this is an AzureStorageCheckpointLeaseManager
                (this.LeaseManager as AzureStorageCheckpointLeaseManager)?.Initialize(this);

                this.ProcessorFactory = factory;
                this.EventProcessorOptions = processorOptions;
                await this.PartitionManager.StartAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                ProcessorEventSource.Log.EventProcessorHostOpenError(this.HostName, e.ToString());
                throw;
            }
            finally
            {
                ProcessorEventSource.Log.EventProcessorHostOpenStop(this.HostName);
            }
        }

        /// <summary>
        /// Stop processing events.  Does not return until the shutdown is complete.
        /// </summary>
        /// <returns></returns>
        public async Task UnregisterEventProcessorAsync() // throws InterruptedException, ExecutionException
        {
            ProcessorEventSource.Log.EventProcessorHostCloseStart(this.HostName);
            try
            {
                await this.PartitionManager.StopAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                // Log the failure but nothing really to do about it.
                ProcessorEventSource.Log.EventProcessorHostCloseError(this.HostName, e.ToString());
                throw;
            }
            finally
            {
                ProcessorEventSource.Log.EventProcessorHostCloseStop(this.HostName);
            }
        }

        /// <summary>
        /// Convenience method for generating unique host names, safe to pass to the EventProcessorHost constructors
        /// that take a hostName argument.
        ///
        /// If a prefix is supplied, the constructed name begins with that string. If the prefix argument is null or
        /// an empty string, the constructed name begins with "host". Then a dash '-' and a unique ID are appended to
        /// create a unique name.
        /// </summary>
        /// <param name="prefix">String to use as the beginning of the name. If null or empty, a default is used.</param>
        /// <returns>A unique host name to pass to EventProcessorHost constructors.</returns>
        static string CreateHostName(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = "host";
            }

            return prefix + "-" + Guid.NewGuid();
        }

        internal EventHubClient CreateEventHubClient()
        {
            // Token provider already provided?
            if (this.tokenProvider == null)
            {
                return EventHubClient.CreateFromConnectionString(this.eventHubConnectionString);
            }
            else
            {
                return EventHubClient.CreateWithTokenProvider(
                    this.EndpointAddress,
                    this.EventHubPath,
                    this.tokenProvider,
                    this.OperationTimeout,
                    this.TransportType);
            }
        }
    }
}
