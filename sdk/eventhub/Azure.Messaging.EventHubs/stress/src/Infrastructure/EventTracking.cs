// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Messaging.EventHubs.Processor;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   A class that allows for keeping track of events as they are sent from one of the producer clients
///   until they are received by the processor or consumer client. It is used by the producer client to
///   add property values to the <see cref="EventData"/>. It is used by the processors and consumers
///   to keep track of previously read events and determine if events being processed are out of order,
///   duplicated, or have corrupted bodies.
/// </summary>
///
public class EventTracking
{
    /// <summary>Holds the set of events that have been read by this instance. The key is the unique Id set by the producer.</summary>
    private ConcurrentDictionary<string, byte> ReadEvents { get; } = new ConcurrentDictionary<string, byte>();

    /// <summary>Holds the last read sequence value for each partition this instance has read from so far.</summary>
    private ConcurrentDictionary<string, int> LastReadPartitionSequence { get; } = new ConcurrentDictionary<string, int>();

    /// <summary>
    ///   The name of the <see cref="EventData"/> property that holds the producer-assigned index number.
    /// </summary>
    ///
    public static readonly string IndexNumberPropertyName = "IndexNumber";

    /// <summary>
    ///   The name of the <see cref="EventData"/> property that holds the gtime the event was published.
    /// </summary>
    ///
    public static readonly string PublishTimePropertyName = "PublishTime";

    /// <summary>
    ///   The name of the <see cref="EventData"/> property that holds the partition the producer
    ///   was intending to send to.
    /// </summary>
    ///
    public static readonly string PartitionPropertyName = "Partition";

    /// <summary>
    ///   The name of the <see cref="EventData"/> property that holds the ID assigned to this event by
    ///   the producer.
    /// </summary>
    ///
    public static readonly string IdPropertyName = "Identifier";

    /// <summary>
    ///   The name of the <see cref="EventData"/> property that holds the hash of the event body assigned by the producer.
    /// </summary>
    ///
    public static readonly string EventBodyHashPropertyName = "EventDataHash";

    /// <summary>
    ///   Adds properties to the given <see cref="EventData"/> instance, allowing for the processor to determine that events
    ///   were received in order, not duplicated, and have valid event bodies.
    /// </summary>
    ///
    /// <param name="eventData">The <see cref="EventData"/> instance to augment.</param>
    /// <param name="indexNumber">The producer assigned index number for this event.</param>
    /// <param name="partition">The partition, if any, that this event was intended to be sent to.</param>
    ///
    public static void AugmentEvent(EventData eventData,
                                    int indexNumber,
                                    string partition=null)
    {
        eventData.Properties.Add(IndexNumberPropertyName, indexNumber);
        eventData.Properties.Add(PublishTimePropertyName, DateTimeOffset.UtcNow);
        eventData.Properties.Add(IdPropertyName, Guid.NewGuid().ToString());

        using (SHA256 sha256Hash = SHA256.Create())
        {
            eventData.Properties.Add(EventBodyHashPropertyName, sha256Hash.ComputeHash(eventData.EventBody.ToArray()).ToString());
        }

        if (!string.IsNullOrEmpty(partition))
        {
            eventData.Properties.Add(PartitionPropertyName, partition);
        }
    }

    /// <summary>
    ///   Processes the <see cref="EventData"/> instance held in the <see cref="ProcessEventArgs"/> in order to determine
    ///   if the event has already been seen, if the event was received out of order, or if the body is invalid.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessEventArgs"/> received from the processor client to be used for processing.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send information about the processed event to Application Insights.</param>
    ///
    public async void ProcessEventAsync(ProcessEventArgs args,
                                        Metrics metrics)
    {
        var indexNumber = CheckEvent(args.Data, args.Partition.PartitionId, metrics);

        if (indexNumber % 100 == 0)
        {
            await args.UpdateCheckpointAsync(args.CancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    ///   Processes the <see cref="EventData"/> instance held in the <see cref="PartitionEvent"/> in order to determine
    ///   if the event has already been seen, if the event was received out of order, or if the body is invalid.
    /// </summary>
    ///
    /// <param name="partitionEvent">The <see cref="PartitionEvent"/> received from the consumer client to be used for processing.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send information about the processed event to Application Insights.</param>
    ///
    public void ConsumeEvent(PartitionEvent partitionEvent, Metrics metrics) => CheckEvent(partitionEvent.Data, partitionEvent.Partition.PartitionId, metrics);

    /// <summary>
    ///   Gets the assigned partitions for the <see cref="PartitionPublisher"/>. This allows each partition publisher instance to publish
    ///   to distinct and separate partitions. This is necessary so that missing and duplicate events can be detected by the <see cref="Role.Consumer"/>
    ///   role without needing access to the <see cref="PartitionPublisher"/> instance.
    /// </summary>
    ///
    /// <param name="partitionCount"></param>
    /// <param name="roleIndex"></param>
    /// <param name="partitionIds"></param>
    ///
    /// <returns>The set of partitions that a given <see cref="PartitionPublisher"/> should send to.</returns>
    ///
    public static List<string> GetAssignedPartitions(int partitionCount,
                                                     int roleIndex,
                                                     string[] partitionIds,
                                                     Role[] roles)
    {
        var roleList = new List<Role>(roles);

        var numPublishers = roleList.Count(role => (role == Role.Publisher || role == Role.BufferedPublisher || role == Role.PartitionPublisher));
        var thisPublisherIndex = (roleList.GetRange(0,roleIndex)).Count(role => (role == Role.Publisher || role == Role.BufferedPublisher || role == Role.PartitionPublisher));

        var baseNum = partitionCount/numPublishers;
        var remainder = partitionCount % numPublishers;

        var startPartition = 0;
        var endPartition = 0;

        if (thisPublisherIndex >= remainder)
        {
            startPartition = (baseNum*thisPublisherIndex) + remainder;
            endPartition = startPartition + baseNum;
        }
        else
        {
            startPartition = (baseNum*thisPublisherIndex) + thisPublisherIndex;
            endPartition = startPartition + baseNum + 1;
        }

        var assignedPartitions = new List<string>();

        for (int i = startPartition; i < endPartition; i++)
        {
            assignedPartitions.Add(partitionIds[i]);
        }

        return assignedPartitions;
    }

    /// <summary>
    ///   Validates an event. This instance checks if the event has an id, if the event has already been seen before by this instance, that the
    ///   intended partition was the one the event was received from, that the event was received in order, and that none were missed, and that
    ///   the body is valid.
    /// </summary>
    ///
    /// <param name="eventData"></param>
    /// <param name="partitionReceivedFrom"></param>
    /// <param name="metrics"></param>
    ///
    /// <returns>The publisher assigned index number of the event that was just read, or -1 if this event was unkown or a duplicate.</returns>
    ///
    /// <remarks>
    ///   One instance should be created for each processor or consumer role. This instance will be able to keep track of all the events the
    ///   processor or consumer has received for each partition it is reading or processing from.
    /// </remarks>
    ///
    private int CheckEvent(EventData eventData,
                           string partitionReceivedFrom,
                           Metrics metrics)
    {
        // Id Checks
        var hasId = eventData.Properties.TryGetValue(IdPropertyName, out var eventIdProperty);
        var eventId = eventIdProperty?.ToString();

        if (!hasId)
        {
            metrics.Client.GetMetric(Metrics.UnknownEventsProcessed).TrackValue(1);
            return -1;
        }

        if (ReadEvents.ContainsKey(eventId))
        {
            metrics.Client.GetMetric(Metrics.DuplicateEventsDiscarded).TrackValue(1);
            return -1;
        }

        // Partition Checks
        var hasPartition = eventData.Properties.TryGetValue(PartitionPropertyName, out var partitionProperty);
        var publisherSetPartitionProperty = partitionProperty?.ToString();;

        if (partitionReceivedFrom != publisherSetPartitionProperty)
        {
            metrics.Client.GetMetric(Metrics.EventReceivedFromWrongPartition).TrackValue(1); //want an event here? or exception? This doesn't give much info
        }

        // Index Value checks
        var hasIndex = eventData.Properties.TryGetValue(IndexNumberPropertyName, out var IndexProperty);
        int.TryParse(IndexProperty.ToString(), out var indexNumber);

        var seenEventFromThisPartition = LastReadPartitionSequence.TryGetValue(partitionReceivedFrom, out var lastReadFromPartition);

        if (seenEventFromThisPartition && lastReadFromPartition >= indexNumber)
        {
            metrics.Client.GetMetric(Metrics.MissingOrOutOfOrderEvent).TrackValue(1);

            var eventProperties = new Dictionary<string,string>();
            eventProperties.Add(Metrics.PublisherAssignedIndex, indexNumber.ToString());
            eventProperties.Add(Metrics.EventBody, eventData.EventBody.ToString());
            metrics.Client.TrackEvent(Metrics.MissingOrOutOfOrderEvent, eventProperties);
        }

        LastReadPartitionSequence.AddOrUpdate(partitionReceivedFrom, _ => indexNumber, (k,v) => Math.Max(v, indexNumber));

        // Hashed event body checks
        using (SHA256 sha256Hash = SHA256.Create())
        {
            eventData.Properties.TryGetValue(EventBodyHashPropertyName, out var expected);
            var expectedEventBodyHash = expected.ToString();
            var receivedEventBodyHash = sha256Hash.ComputeHash(eventData.EventBody.ToArray()).ToString();

            if (expectedEventBodyHash != receivedEventBodyHash)
            {
                var eventProperties = new Dictionary<string,string>();
                eventProperties.Add(Metrics.PublisherAssignedIndex, indexNumber.ToString());
                eventProperties.Add(Metrics.EventBody, eventData.EventBody.ToString());
                metrics.Client.TrackEvent(Metrics.InvalidBodies, eventProperties);
                return -1;
            }
        }

        // Finished Checks - mark as read
        ReadEvents.TryAdd(eventId, 0);

        return indexNumber;
    }
}