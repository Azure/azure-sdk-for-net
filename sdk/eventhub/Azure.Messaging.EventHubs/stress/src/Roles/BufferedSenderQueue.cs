// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Stress;

public class BuffSenderQueue : IAsyncDisposable
{
    private readonly EventHubBufferedProducerClient _eventHubProducerClient;
    private readonly Metrics _metrics;

    public BuffSenderQueue(
        TestConfiguration configuration,
        Metrics metrics)
    {
        _metrics = metrics;
        _eventHubProducerClient = GetProducerClient(configuration);
    }

    public virtual async Task EnqueueAsync(string item, CancellationToken cancellationToken = default)
    {
        if (String.IsNullOrEmpty(item))
            throw new ArgumentNullException(nameof(item));

        await _eventHubProducerClient.EnqueueEventAsync(new EventData(item), cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        _eventHubProducerClient.SendEventBatchSucceededAsync -= SendSuccessfulHandler;
        _eventHubProducerClient.SendEventBatchFailedAsync -= SendFailedHandler;
        await _eventHubProducerClient.DisposeAsync();
    }

    protected EventHubBufferedProducerClient GetProducerClient(TestConfiguration configuration)
    {
        var eventHubBufferedProducerClient = new EventHubBufferedProducerClient(
                        configuration.EventHubsConnectionString,
                        configuration.EventHub);
        eventHubBufferedProducerClient.SendEventBatchSucceededAsync += SendSuccessfulHandler;
        eventHubBufferedProducerClient.SendEventBatchFailedAsync += SendFailedHandler;

        return eventHubBufferedProducerClient;
    }

    private Task SendSuccessfulHandler(SendEventBatchSucceededEventArgs args)
    {
        var numEvents = args.EventBatch.Count;

        _metrics.Client.GetMetric(Metrics.SuccessfullySentFromQueue, "PartitionId").TrackValue(numEvents, args.PartitionId);
        _metrics.Client.GetMetric(Metrics.BatchesPublished).TrackValue(1);
        return Task.CompletedTask;
    }

    private Task SendFailedHandler(SendEventBatchFailedEventArgs args)
    {
        var numEvents = args.EventBatch.Count;

        _metrics.Client.GetMetric(Metrics.EventsNotSentAfterEnqueue, "PartitionId").TrackValue(numEvents, args.PartitionId);
        _metrics.Client.TrackException(args.Exception);
        return Task.CompletedTask;
    }
}