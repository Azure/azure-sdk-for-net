// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A factory for the creation of Event Hubs model types to
    ///   assist with mocking and testing.
    /// </summary>
    ///
    public static class EventHubsModelFactory
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="name">The name of the Event Hub.</param>
        /// <param name="createdOn">The date and time at which the Event Hub was created.</param>
        /// <param name="partitionIds">The set of unique identifiers for each partition.</param>
        ///
        public static EventHubProperties EventHubProperties(string name,
                                                            DateTimeOffset createdOn,
                                                            string[] partitionIds) =>
           new EventHubProperties(name, createdOn, partitionIds);

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionProperties"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="isEmpty">Indicates whether or not the partition is currently empty.</param>
        /// <param name="beginningSequenceNumber">The first sequence number available for events in the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        ///
        public static PartitionProperties PartitionProperties(string eventHubName,
                                                              string partitionId,
                                                              bool isEmpty,
                                                              long beginningSequenceNumber,
                                                              long lastSequenceNumber,
                                                              long lastOffset,
                                                              DateTimeOffset lastEnqueuedTime) =>
            new PartitionProperties(eventHubName, partitionId, isEmpty, beginningSequenceNumber, lastSequenceNumber, lastOffset, lastEnqueuedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="isIdempotentPublishingEnabled">Indicates whether idempotent publishing is enabled.</param>
        /// <param name="producerGroupId">The identifier of the producer group associated with the partition.</param>
        /// <param name="ownerLevel">The owner level associated with the partition.</param>
        /// <param name="lastPublishedSequenceNumber">The sequence number assigned to the event that was last successfully published to the partition.</param>
        ///
        public static PartitionPublishingProperties PartitionPublishingProperties(bool isIdempotentPublishingEnabled,
                                                                                  long? producerGroupId,
                                                                                  short? ownerLevel,
                                                                                  int? lastPublishedSequenceNumber) =>
            new PartitionPublishingProperties(isIdempotentPublishingEnabled, producerGroupId, ownerLevel, lastPublishedSequenceNumber);

        /// <summary>
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        public static LastEnqueuedEventProperties LastEnqueuedEventProperties(long? lastSequenceNumber,
                                                                              long? lastOffset,
                                                                              DateTimeOffset? lastEnqueuedTime,
                                                                              DateTimeOffset? lastReceivedTime) =>
            new LastEnqueuedEventProperties(lastSequenceNumber, lastOffset, lastEnqueuedTime, lastReceivedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="lastEnqueuedEventProperties">The set of properties to be returned when <see cref="PartitionContext.ReadLastEnqueuedEventProperties" /> is invoked.</param>
        ///
        public static PartitionContext PartitionContext(string partitionId,
                                                        LastEnqueuedEventProperties lastEnqueuedEventProperties = default) =>
            new FactoryPartitionContext(partitionId, lastEnqueuedEventProperties);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The data to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties that accompany events read from the Event Hubs service.</param>
        /// <param name="partitionKey">The partition hashing key associated with the event when it was published.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        ///
        public static EventData EventData(BinaryData eventBody,
                                          IDictionary<string, object> properties = null,
                                          IReadOnlyDictionary<string, object> systemProperties = null,
                                          string partitionKey = null,
                                          long sequenceNumber = long.MinValue,
                                          long offset = long.MinValue,
                                          DateTimeOffset enqueuedTime = default) =>
             new EventData(eventBody, properties, systemProperties, sequenceNumber, offset, enqueuedTime, partitionKey);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventDataBatch" /> class.
        /// </summary>
        ///
        /// <param name="batchSizeBytes">The size, in bytes, that the batch should report; this is a static value and will not mutate as events are added.</param>
        /// <param name="batchEventStore">A list to which events will be added when <see cref="EventDataBatch.TryAdd" /> calls are successful.</param>
        /// <param name="batchOptions">The set of options to consider when creating this batch.</param>
        /// <param name="tryAddCallback">A function that will be invoked when <see cref="EventDataBatch.TryAdd" /> is called; the return of this callback represents the result of <see cref="EventDataBatch.TryAdd" />.  If not provided, all events will be accepted into the batch.</param>
        ///
        /// <returns>The <see cref="EventDataBatch" /> instance that was created.</returns>
        ///
        public static EventDataBatch EventDataBatch(long batchSizeBytes,
                                                    IList<EventData> batchEventStore,
                                                    CreateBatchOptions batchOptions = default,
                                                    Func<EventData, bool> tryAddCallback = default)
        {
            tryAddCallback ??= _ => true;
            batchOptions ??= new CreateBatchOptions();
            batchOptions.MaximumSizeInBytes ??= long.MaxValue;

            var transportBatch = new ListTransportBatch(batchOptions.MaximumSizeInBytes.Value, batchSizeBytes, batchEventStore, tryAddCallback);
            return new EventDataBatch(transportBatch, "Mock", "Mock", batchOptions);
        }

        /// <summary>
        ///   Represents an Event Hub partition and its relative state, as scoped to an associated
        ///   operation performed against it.
        /// </summary>
        ///
        private sealed class FactoryPartitionContext : PartitionContext
        {
            /// <summary>The set of properties to be returned when <see cref="ReadLastEnqueuedEventProperties" /> is invoked.</summary>
            private readonly LastEnqueuedEventProperties _lastEnqueuedEventProperties;

            /// <summary>
            ///   A set of information about the last enqueued event of a partition, as observed by the associated EventHubs client
            ///   associated with this context as events are received from the Event Hubs service.  This is only available if the consumer was
            ///   created with <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> set.
            /// </summary>
            ///
            /// <returns>The set of properties for the last event that was enqueued to the partition.  If no events were read or tracking was not set, the properties will be returned with default values.</returns>
            ///
            /// <remarks>
            ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
            ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
            ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
            ///   against periodically making requests for partition properties using an Event Hub client.
            /// </remarks>
            ///
            /// <exception cref="EventHubsException">Occurs when the Event Hubs client needed to read this information is no longer available.</exception>
            ///
            public override LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() => _lastEnqueuedEventProperties;

            /// <summary>
            ///   Initializes a new instance of the <see cref="FactoryPartitionContext"/> class.
            /// </summary>
            ///
            /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
            /// <param name="lastEnqueuedEventProperties">The set of properties to be returned when <see cref="ReadLastEnqueuedEventProperties" /> is invoked.</param>
            ///
            internal FactoryPartitionContext(string partitionId,
                                             LastEnqueuedEventProperties lastEnqueuedEventProperties) : base(partitionId) =>
                _lastEnqueuedEventProperties = lastEnqueuedEventProperties;
        }

        /// <summary>
        ///   Allows for the transport event batch created by the factory to be injected for testing purposes.
        /// </summary>
        ///
        private sealed class ListTransportBatch : TransportEventBatch
        {
            /// <summary>The backing store for storing events in the batch.</summary>
            private readonly IList<EventData> _backingStore;

            /// <summary>A callback to be invoked when an adding an event via <see cref="TryAdd"/></summary>
            private readonly Func<EventData, bool> _tryAddCallback;

            /// <summary>
            ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
            ///   well as any overhead for the batch itself when sent to the Event Hubs service.
            /// </summary>
            ///
            public override long MaximumSizeInBytes { get; }

            /// <summary>
            ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
            ///   service.
            /// </summary>
            ///
            public override long SizeInBytes { get; }

            /// <summary>
            ///   The flags specifying the set of special transport features that have been opted-into.
            /// </summary>
            ///
            public override TransportProducerFeatures ActiveFeatures { get; } = TransportProducerFeatures.None;

            /// <summary>
            ///   The count of events contained in the batch.
            /// </summary>
            ///
            public override int Count => _backingStore.Count;

            /// <summary>
            ///   Initializes a new instance of the <see cref="ListTransportBatch"/> class.
            /// </summary>
            ///
            /// <param name="maximumSizeInBytes"> The maximum size allowed for the batch, in bytes.</param>
            /// <param name="sizeInBytes">The size of the batch, in bytes; this will be treated as a static value for the property.</param>
            /// <param name="backingStore">The backing store for holding events in the batch.</param>
            /// <param name="tryAddCallback">A callback for deciding if a TryAdd attempt is successful.</param>
            ///
            internal ListTransportBatch(long maximumSizeInBytes,
                                        long sizeInBytes,
                                        IList<EventData> backingStore,
                                        Func<EventData, bool> tryAddCallback) =>
                (MaximumSizeInBytes, SizeInBytes, _backingStore, _tryAddCallback) = (maximumSizeInBytes, sizeInBytes, backingStore, tryAddCallback);

            /// <summary>
            ///   Attempts to add an event to the batch, ensuring that the size
            ///   of the batch does not exceed its maximum.
            /// </summary>
            ///
            /// <param name="eventData">The event to attempt to add to the batch.</param>
            ///
            /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
            ///
            public override bool TryAdd(EventData eventData)
            {
                if (_tryAddCallback(eventData))
                {
                    _backingStore.Add(eventData);
                    return true;
                }

                return false;
            }

            /// <summary>
            ///   Clears the batch, removing all events and resetting the
            ///   available size.
            /// </summary>
            ///
            public override void Clear() => _backingStore.Clear();

            /// <summary>
            ///   Represents the batch as an enumerable set of transport-specific
            ///   representations of an event.
            /// </summary>
            ///
            /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
            ///
            /// <returns>The set of events as an enumerable of the requested type.</returns>
            ///
            public override IEnumerable<T> AsEnumerable<T>() => (IEnumerable<T>)_backingStore;

            /// <summary>
            ///   Performs the task needed to clean up resources used by the <see cref="TransportEventBatch" />.
            /// </summary>
            ///
            public override void Dispose()
            {
            }
        }
    }
}
