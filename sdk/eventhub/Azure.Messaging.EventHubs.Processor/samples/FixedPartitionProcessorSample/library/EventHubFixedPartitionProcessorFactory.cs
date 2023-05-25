namespace EventHubProcessors;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

/// <summary>
/// A factory to get or create EventHubFixedPartitionProcessor. This should be registered as a singleton.
/// </summary>
[ExcludeFromCodeCoverage]
public class EventHubFixedPartitionProcessorFactory : IEventHubFixedPartitionProcessorFactory
{
    private readonly SemaphoreSlim procLock = new(1, 1);
    private readonly IEventHubFixedPartitionProcessorConfig config;
    private readonly IServiceProvider serviceProvider;
    private EventHubFixedPartitionProcessor processor;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventHubFixedPartitionProcessorFactory"/> class.
    /// </summary>
    /// <param name="config">The configuration.</param>
    /// <param name="serviceProvider">The service provider.</param>
    public EventHubFixedPartitionProcessorFactory(
        IEventHubFixedPartitionProcessorConfig config,
        IServiceProvider serviceProvider)
    {
        this.config = config;
        this.serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public async Task<EventHubFixedPartitionProcessor> GetAsync()
    {
        await this.procLock.WaitAsync();
        try
        {
            return this.processor;
        }
        finally
        {
            this.procLock.Release();
        }
    }

    /// <inheritdoc />
    public async Task<EventHubFixedPartitionProcessor> GetOrCreateAsync(EventPosition startingPosition, bool shouldCheckpoint)
    {
        await this.procLock.WaitAsync();
        try
        {
            // return an existing processor
            if (this.processor is not null)
            {
                return this.processor;
            }

            // create the container client
            var containerClient = new BlobContainerClient(this.config.STORAGE_CONNSTRING, this.config.STORAGE_CONTAINER_NAME);

            // create the options
            var options = new EventHubFixedPartitionProcessorOptions
            {
                MaxPartitions = this.config.ASSIGN_TO_X_PARTITIONS,
                ShouldCheckpoint = shouldCheckpoint,
                PartitionOwnershipExpirationInterval = this.config.LEASE_FOR_X_SEC,
                LoadBalancingUpdateInterval = this.config.RENEW_EVERY_X_SEC,
                DefaultStartingPosition = startingPosition,
            };

            // generate the logger
            var logger = this.serviceProvider.GetService<ILogger<EventHubFixedPartitionProcessor>>();

            // create the processor
            this.processor = new EventHubFixedPartitionProcessor(
                this.config.INBOUND_EVENTHUB_CONSUMER_GROUP,
                this.config.INBOUND_EVENTHUB_CONNSTRING,
                this.config.INBOUND_EVENTHUB_MAX_BATCH_SIZE,
                containerClient,
                options,
                logger);

            return this.processor;
        }
        finally
        {
            this.procLock.Release();
        }
    }
}
