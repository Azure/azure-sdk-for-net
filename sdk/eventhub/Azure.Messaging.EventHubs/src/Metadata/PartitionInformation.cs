// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Metadata
{
    /// <summary>
    ///   A set of information for a single partition of an Event Hub.
    /// </summary>
    ///
    public sealed class PartitionInformation
    {
        /// <summary>
        ///   The path of the Event Hub that contains the partitions, relative to the namespace
        ///   that contains it.
        /// </summary>
        ///
        public string Path { get; private set; }

        /// <summary>
        ///   The identifier of the partition, unique to the Event Hub which contains it.
        /// </summary>
        ///
        public string Identifier { get; private set; }

        /// <summary>
        ///   The first sequence number available for events in the partition.
        /// </summary>
        ///
        public long BeginningSequenceNumber { get; private set; }

        /// <summary>
        ///   The sequence number observed the last event to be enqueued in the partition.
        /// </summary>
        ///
        public long LastEnqueuedSequenceNumber { get; private set; }

        /// <summary>
        ///   The offset of the last event to be enqueed in the partition.
        /// </summary>
        ///
        /// <remarks>
        ///   The offset is a marker or identifier for an event within the Event Hubs stream. The
        ///   identifier is unique within a partition of the Event Hubs stream.
        /// </remarks>
        ///
        public string LastEnqueuedOffset { get; private set; }

        /// <summary>
        ///   The date and time, in UTC, that the last event was enqueued in the partition.
        /// </summary>
        ///
        public DateTime LastEnqueuedTimeUtc { get; private set; }

        /// <summary>
        ///   Indicates whether or not the partition is currently empty.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the partition is empty; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsEmpty { get; private set;}

        /// <summary>
        ///   The date and time, in UTC, that the information was retrieved from the
        ///   Event Hub.
        /// </summary>
        ///
        public DateTime InformationRetrievalTimeUtc { get; private set;}

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionInformation"/> class.
        /// </summary>
        ///
        /// <param name="path">The path of the Event Hub that contains the partitions.</param>
        /// <param name="key">The identifier of the partition.</param>
        /// <param name="beginningSequenceNumber">The first sequence number available for events in the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueed in the partition.</param>
        /// <param name="lastEnqueueUtc">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="isEmpty">Indicates whether or not the partition is currently empty.</param>
        /// <param name="retrievalTimeUtc">the date and time, in UTC, that the information was retrieved from the serivce; if not provided, the current date/time will be used.</param>
        ///
        internal PartitionInformation(string    path,
                                      string    key,
                                      long      beginningSequenceNumber,
                                      long      lastSequenceNumber,
                                      string    lastOffset,
                                      DateTime  lastEnqueueUtc,
                                      bool      isEmpty,
                                      DateTime? retrievalTimeUtc = null)
        {
            Path = path;
            Identifier = key;
            BeginningSequenceNumber = beginningSequenceNumber;
            LastEnqueuedSequenceNumber = lastSequenceNumber;
            LastEnqueuedOffset = lastOffset;
            LastEnqueuedTimeUtc = lastEnqueueUtc;
            IsEmpty = isEmpty;
            InformationRetrievalTimeUtc = retrievalTimeUtc ?? DateTime.UtcNow;
        }

        /// <summary>
        ///   Updates the current set of partition information using an <see cref="EventHubs.EventData" />
        ///   instance as the source.
        /// </summary>
        ///
        /// <param name="sourceEvent">The event to use as the information source for the updates.</param>
        ///
        internal void UpdateFromEvent(EventData sourceEvent)
        {
            Guard.ArgumentNotNull(nameof(sourceEvent), sourceEvent);

            LastEnqueuedSequenceNumber = sourceEvent.LastSequenceNumber;
            LastEnqueuedOffset = sourceEvent.LastEnqueuedOffset;
            LastEnqueuedTimeUtc = sourceEvent.LastEnqueuedTimeUtc;
            InformationRetrievalTimeUtc = sourceEvent.RetrievalTimeUtc;
        }
    }
}
