namespace Client;

using System.Threading;
using System.Threading.Tasks;
using EventHubProcessors;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs;

/// <summary>
/// This hosted service allows for startup and shutdown activities related to the application itself.
/// </summary>
internal class Consumer : IHostedService
{
    private readonly IEventHubFixedPartitionProcessorFactory factory;
    private readonly ILogger<Consumer> logger;
    private EventHubFixedPartitionProcessor processor;

    /// <summary>
    /// Initializes a new instance of the <see cref="Consumer"/> class.
    /// </summary>
    /// <param name="factory">The factory for creating the processor.</param>
    /// <param name="logger">The logger for this class.</param>
    public Consumer(IEventHubFixedPartitionProcessorFactory factory, ILogger<Consumer> logger)
    {
        this.factory = factory;
        this.logger = logger;
    }

    /// <summary>
    /// This method should contain all startup activities for the consumer service.
    /// </summary>
    /// <param name="cancellationToken">A token that can be cancelled to abort startup.</param>
    /// <returns>A Task that is complete when the method is done.</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        this.processor = await this.factory.GetOrCreateAsync(EventPosition.Earliest, shouldCheckpoint: true);
        this.processor.OnAssignedAsync += this.OnAssignedAsync;
        this.processor.OnRenewedAsync += this.OnRenewedAsync;
        this.processor.OnReleasedAsync += this.OnReleasedAsync;
        this.processor.OnBatchAsync += this.OnBatchAsync;
        this.processor.OnErrorAsync += this.OnErrorAsync;
        await this.processor.StartProcessingAsync(cancellationToken);
    }

    /// <summary>
    /// This method should contain all shutdown activities for the consumer service.
    /// </summary>
    /// <param name="cancellationToken">A token that can be cancelled to abort startup.</param>
    /// <returns>A Task that is complete when the method is done.</returns>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        this.processor.OnAssignedAsync -= this.OnAssignedAsync;
        this.processor.OnRenewedAsync -= this.OnRenewedAsync;
        this.processor.OnReleasedAsync -= this.OnReleasedAsync;
        this.processor.OnBatchAsync -= this.OnBatchAsync;
        this.processor.OnErrorAsync -= this.OnErrorAsync;
        await this.processor.StopProcessingAsync(cancellationToken);
    }

    private Task OnAssignedAsync(object sender, string partitionId)
    {
        this.logger.LogInformation("this replica took ownership of partition {pid}.", partitionId);
        return Task.CompletedTask;
    }

    private Task OnRenewedAsync(object sender, string partitionId)
    {
        this.logger.LogDebug("this replica retained ownership of partition {pid}.", partitionId);
        return Task.CompletedTask;
    }

    private Task OnReleasedAsync(object sender, string partitionId)
    {
        // NOTE: this is showing a use-case where you might want to exit the application
        // if it loses control of a partition.
        this.logger.LogCritical("this replica lost ownership of partition {pid}.", partitionId);
        Environment.Exit(1000);
        return Task.CompletedTask;
    }

    private Task OnBatchAsync(object sender, IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        try
        {
            foreach (var evt in events)
            {
                this.logger.LogInformation(
                    "received message on partition {pid}: {msg}",
                    partition.PartitionId,
                    evt.EventBody.ToString());
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "an error was raised while trying to process events...");
        }

        return Task.CompletedTask;
    }

    private Task OnErrorAsync(object sender, Exception ex, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken)
    {
        this.logger.LogError(ex, "an error was raised while trying to read from Event Hub...");
        return Task.CompletedTask;
    }
}