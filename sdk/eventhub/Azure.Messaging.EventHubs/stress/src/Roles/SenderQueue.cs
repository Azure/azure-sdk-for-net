// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Stress;

public class SenderQueue : IAsyncDisposable
{
    private readonly EventHubProducerClient _eventHubProducerClient;
    private readonly Metrics _metrics;

    public SenderQueue(
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
        var eventArray = BuildEventData(item);
        _metrics.Client.GetMetric(Metrics.BatchesPublished).TrackValue(1);
        await _eventHubProducerClient.SendAsync(eventArray, cancellationToken);
    }

    public async ValueTask DisposeAsync() => await _eventHubProducerClient.DisposeAsync();

    protected EventHubProducerClient GetProducerClient(TestConfiguration configuration)
    {
        return new EventHubProducerClient(
            configuration.EventHubsConnectionString,
            configuration.EventHub);
    }

    private EventData[] BuildEventData(string item)
    {
        return new[] { new EventData(item) };
    }
}