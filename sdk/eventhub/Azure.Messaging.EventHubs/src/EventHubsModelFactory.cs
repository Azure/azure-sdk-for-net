// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Azure.Core.Shared;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;

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
        ///   Initializes a new instance of the <see cref="EventHubs.EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="name">The name of the Event Hub.</param>
        /// <param name="createdOn">The date and time at which the Event Hub was created.</param>
        /// <param name="partitionIds">The set of unique identifiers for each partition.</param>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubProperties EventHubProperties(string name,
                                                            DateTimeOffset createdOn,
                                                            string[] partitionIds) =>
           new EventHubProperties(name, createdOn, partitionIds, false);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubs.EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="name">The name of the Event Hub.</param>
        /// <param name="createdOn">The date and time at which the Event Hub was created.</param>
        /// <param name="partitionIds">The set of unique identifiers for each partition.</param>
        /// <param name="isGeoReplicationEnabled">A flag indicating whether or not the Event Hubs namespace has geo-replication enabled.</param>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubProperties EventHubProperties(string name,
                                                            DateTimeOffset createdOn,
                                                            string[] partitionIds,
                                                            bool isGeoReplicationEnabled) =>
           new EventHubProperties(name, createdOn, partitionIds, isGeoReplicationEnabled);

        /// <summary>
        ///   Obsolete.
        ///
        ///   Initializes a new instance of the <see cref="EventHubs.PartitionProperties"/> class.
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
        /// <remarks>
        ///   This method is obsolete and should no longer be used.  Please use the overload with a string-based offset instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetParameterObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PartitionProperties PartitionProperties(string eventHubName,
                                                              string partitionId,
                                                              bool isEmpty,
                                                              long beginningSequenceNumber,
                                                              long lastSequenceNumber,
                                                              long lastOffset,
                                                              DateTimeOffset lastEnqueuedTime) =>
            new PartitionProperties(eventHubName, partitionId, isEmpty, beginningSequenceNumber, lastSequenceNumber, (lastOffset > long.MinValue) ? lastOffset.ToString(CultureInfo.InvariantCulture) : null, lastEnqueuedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubs.PartitionProperties"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="isEmpty">Indicates whether or not the partition is currently empty.</param>
        /// <param name="beginningSequenceNumber">The first sequence number available for events in the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffsetString">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        ///
        public static PartitionProperties PartitionProperties(string eventHubName,
                                                              string partitionId,
                                                              bool isEmpty,
                                                              long beginningSequenceNumber,
                                                              long lastSequenceNumber,
                                                              string lastOffsetString,
                                                              DateTimeOffset lastEnqueuedTime) =>
            new PartitionProperties(eventHubName, partitionId, isEmpty, beginningSequenceNumber, lastSequenceNumber, lastOffsetString, lastEnqueuedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Producer.PartitionPublishingProperties"/> class.
        /// </summary>
        ///
        /// <param name="isIdempotentPublishingEnabled">Indicates whether idempotent publishing is enabled.</param>
        /// <param name="producerGroupId">The identifier of the producer group associated with the partition.</param>
        /// <param name="ownerLevel">The owner level associated with the partition.</param>
        /// <param name="lastPublishedSequenceNumber">The sequence number assigned to the event that was last successfully published to the partition.</param>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PartitionPublishingProperties PartitionPublishingProperties(bool isIdempotentPublishingEnabled,
                                                                                    long? producerGroupId,
                                                                                    short? ownerLevel,
                                                                                    int? lastPublishedSequenceNumber) =>
            new PartitionPublishingProperties(isIdempotentPublishingEnabled, producerGroupId, ownerLevel, lastPublishedSequenceNumber);

                /// <summary>
        ///   Initializes a new instance of the <see cref="Consumer.LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetParameterObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LastEnqueuedEventProperties LastEnqueuedEventProperties(long? lastSequenceNumber,
                                                                              long? lastOffset,
                                                                              DateTimeOffset? lastEnqueuedTime,
                                                                              DateTimeOffset? lastReceivedTime) =>
            new LastEnqueuedEventProperties(lastSequenceNumber, lastOffset?.ToString(CultureInfo.InvariantCulture), lastEnqueuedTime, lastReceivedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Consumer.LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffsetString">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        public static LastEnqueuedEventProperties LastEnqueuedEventProperties(long? lastSequenceNumber,
                                                                              string lastOffsetString,
                                                                              DateTimeOffset? lastEnqueuedTime,
                                                                              DateTimeOffset? lastReceivedTime) =>
            new LastEnqueuedEventProperties(lastSequenceNumber, lastOffsetString, lastEnqueuedTime, lastReceivedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Consumer.PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="lastEnqueuedEventProperties">The set of properties to be returned when <see cref="PartitionContext.ReadLastEnqueuedEventProperties" /> is invoked.</param>
        ///
        public static PartitionContext PartitionContext(string fullyQualifiedNamespace,
                                                        string eventHubName,
                                                        string consumerGroup,
                                                        string partitionId,
                                                        LastEnqueuedEventProperties lastEnqueuedEventProperties = default) =>
            new FactoryPartitionContext(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, lastEnqueuedEventProperties);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Consumer.PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="lastEnqueuedEventProperties">The set of properties to be returned when <see cref="PartitionContext.ReadLastEnqueuedEventProperties" /> is invoked.</param>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PartitionContext PartitionContext(string partitionId,
                                                        LastEnqueuedEventProperties lastEnqueuedEventProperties = default) =>
            new FactoryPartitionContext("<< NULL >>", "<< NULL >>", "<< NULL >>", partitionId, lastEnqueuedEventProperties);

        /// <summary>
        ///   Obsolete.
        ///
        ///   Initializes a new instance of the <see cref="EventHubs.EventData"/> class.
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
        /// <remarks>
        ///   This method is obsolete and should no longer be used.  Please use the overload with a string-based offset instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetParameterObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventData EventData(BinaryData eventBody,
                                          IDictionary<string, object> properties = null,
                                          IReadOnlyDictionary<string, object> systemProperties = null,
                                          string partitionKey = null,
                                          long sequenceNumber = long.MinValue,
                                          long offset = long.MinValue,
                                          DateTimeOffset enqueuedTime = default) =>
            EventData(eventBody, properties, systemProperties, partitionKey, sequenceNumber, (offset > long.MinValue) ? offset.ToString(CultureInfo.InvariantCulture) : null, enqueuedTime);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubs.EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The data to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties that accompany events read from the Event Hubs service.</param>
        /// <param name="partitionKey">The partition hashing key associated with the event when it was published.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offsetString">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        ///
        public static EventData EventData(BinaryData eventBody,
                                          IDictionary<string, object> properties = null,
                                          IReadOnlyDictionary<string, object> systemProperties = null,
                                          string partitionKey = null,
                                          long sequenceNumber = long.MinValue,
                                          string offsetString = default,
                                          DateTimeOffset enqueuedTime = default) =>
             new EventData(eventBody, properties, systemProperties, sequenceNumber, offsetString, enqueuedTime, partitionKey);

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
        /// <remarks>
        ///   It is important to note that the batch will keep an internal copy of events accepted by <see cref="EventDataBatch.TryAdd" />; changes made to
        ///   <paramref name="batchEventStore" /> outside of the batch will not be reflected by the batch.
        /// </remarks>
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
            return new EventDataBatch(transportBatch, "Mock", "Mock", batchOptions, new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock"));
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
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
            /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
            /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
            /// <param name="lastEnqueuedEventProperties">The set of properties to be returned when <see cref="ReadLastEnqueuedEventProperties" /> is invoked.</param>
            ///
            internal FactoryPartitionContext(string fullyQualifiedNamespace,
                                             string eventHubName,
                                             string consumerGroup,
                                             string partitionId,
                                             LastEnqueuedEventProperties lastEnqueuedEventProperties) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId) =>
                _lastEnqueuedEventProperties = lastEnqueuedEventProperties;
        }

        /// <summary>
        ///   Allows for the transport event batch created by the factory to be injected for testing purposes.
        /// </summary>
        ///
        private sealed class ListTransportBatch : TransportEventBatch
        {
            /// <summary>
            ///  The converter to use for transforming events into AMQP messages.
            /// </summary>
            ///
            private static AmqpMessageConverter MessageConverter { get; } = new AmqpMessageConverter();

            /// <summary>The backing store for storing events in the batch.</summary>
            private readonly IList<EventData> _backingStore;

            /// <summary>A callback to be invoked when an adding an event via <see cref="TryAdd"/></summary>
            private readonly Func<EventData, bool> _tryAddCallback;

            /// <summary>The set of events that have been added to the batch, in their <see cref="AmqpMessage" /> serialized format.</summary>
            private List<AmqpMessage> _batchMessages;

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
            ///     The first sequence number of the batch; if not sequenced, <c>null</c>.
            /// </summary>
            ///
            public override int? StartingSequenceNumber => (_backingStore.Count == 0) ? null : _backingStore[0].PendingPublishSequenceNumber;

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
            ///   Represents the batch as a set of the AMQP-specific representations of an event.
            /// </summary>
            ///
            /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
            ///
            /// <returns>The set of events as an enumerable of the requested type.</returns>
            ///
            public override IReadOnlyCollection<T> AsReadOnlyCollection<T>()
            {
                if (typeof(T) != typeof(AmqpMessage))
                {
                    throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
                }

                // The AMQP messages must be recreated for each transform request to
                // ensure that the idempotent publishing properties are current and correct.
                //
                // This is a safe pattern, because the method is internal and only invoked
                // during a send operation, during which the batch is locked to prevent
                // changes or parallel attempts to send.
                //
                // Multiple requests to produce the collection would happen if this batch instance
                // is being published more than once, which is only valid if a call to SendAsync fails
                // across all retries, making it a fairly rare occurrence.

                if (_batchMessages != null)
                {
                    foreach (var message in _batchMessages)
                    {
                        message.Dispose();
                    }
                }

                _batchMessages = new(_backingStore.Count);

                // Serialize the events in the batch into their AMQP transport format.  Because
                // the batch holds responsibility for disposing these, hold onto the references.

                foreach (var eventData in _backingStore)
                {
                    _batchMessages.Add(MessageConverter.CreateMessageFromEvent(eventData));
                }

                return _batchMessages as IReadOnlyCollection<T>;
            }

            /// <summary>
            ///   Assigns message sequence numbers and publisher metadata to the batch in
            ///   order to prepare it to be sent when certain features, such as idempotent retries,
            ///   are active.
            /// </summary>
            ///
            /// <param name="lastSequenceNumber">The sequence number assigned to the event that was most recently published to the associated partition successfully.</param>
            /// <param name="producerGroupId">The identifier of the producer group for which publishing is being performed.</param>
            /// <param name="ownerLevel">TThe owner level for which publishing is being performed.</param>
            ///
            /// <returns>The last sequence number applied to the batch.</returns>
            ///
            public override int ApplyBatchSequencing(int lastSequenceNumber,
                                                     long? producerGroupId,
                                                     short? ownerLevel)
            {
                foreach (var eventData in _backingStore)
                {
                    if (unchecked(++lastSequenceNumber < 0))
                    {
                        lastSequenceNumber = 0;
                    }

                    eventData.PendingPublishSequenceNumber = lastSequenceNumber;
                    eventData.PendingProducerGroupId = producerGroupId;
                    eventData.PendingProducerOwnerLevel = ownerLevel;
                }

                return lastSequenceNumber;
            }

            /// <summary>
            ///   Resets the batch to remove sequencing information and publisher metadata assigned
            ///    by <see cref="ApplyBatchSequencing" />.
            /// </summary>
            ///
            public override void ResetBatchSequencing()
            {
                foreach (var eventData in _backingStore)
                {
                    eventData.PendingPublishSequenceNumber = null;
                    eventData.PendingProducerGroupId = null;
                    eventData.PendingProducerOwnerLevel = null;
                }
            }

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
