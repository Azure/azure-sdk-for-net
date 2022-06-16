// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Processor;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Stress;

public class EventTracking
{
    public static readonly string SequencePropertyName = "SequenceNumber";
    public static readonly string PublishTimePropertyName = "PublishTime";
    public static readonly string PartitionPropertyName = "Partition";
    public static readonly string IdPropertyName = "Identifier";
    public static readonly string EventDataHashPropertyName = "EventDataHash";

    private ConcurrentDictionary<string, byte> ReadEvents { get; } = new ConcurrentDictionary<string, byte>();
    private ConcurrentDictionary<string, int> LastReadPartitionSequence { get; } = new ConcurrentDictionary<string, int>();

    public static void AugmentEvent(EventData eventData, int sequenceNumber, string partition=null)
    {
        eventData.Properties.Add(SequencePropertyName, sequenceNumber);
        eventData.Properties.Add(PublishTimePropertyName, DateTimeOffset.UtcNow);
        eventData.Properties.Add(IdPropertyName, Guid.NewGuid().ToString());
        //eventData.Properties.Add(EventDataHashPropertyName, ) TODO

        if (!string.IsNullOrEmpty(partition))
        {
            eventData.Properties.Add(PartitionPropertyName, partition);
        }
    }

    public async Task ProcessEvent(ProcessEventArgs args, Metrics metrics)
    {
        var hasID = args.Data.Properties.TryGetValue(IdPropertyName, out var eventIdProperty);
        var eventId = eventIdProperty?.ToString();

        var hasPartition = args.Data.Properties.TryGetValue(PartitionPropertyName, out var partitionProperty);
        var partitionSent = partitionProperty?.ToString();

        var hasSequence = args.Data.Properties.TryGetValue(SequencePropertyName, out var sequenceProperty);
        var sequenceNumber = sequenceProperty?.ToString();

        if (hasID && ReadEvents.ContainsKey(eventId))
        {
            metrics.Client.GetMetric(Metrics.DuplicateEventsDiscarded).TrackValue(1);
            return; //?
        }

        metrics.Client.GetMetric(Metrics.EventsRead).TrackValue(1);

        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}