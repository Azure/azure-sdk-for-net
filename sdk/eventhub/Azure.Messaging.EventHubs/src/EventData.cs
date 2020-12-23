// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Azure.Core.Serialization;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A set of data encapsulating an event and the associated metadata for
    ///   use with Event Hubs operations.
    /// </summary>
    ///
    public class EventData
    {
        /// <summary>
        ///   The data associated with the event, in <see cref="BinaryData" /> form, providing support
        ///   for a variety of data transformations and <see cref="ObjectSerializer" /> integration.
        /// </summary>
        ///
        /// <remarks>
        ///   <para>If the means for deserializing the raw data is not apparent to consumers, a
        ///   common technique is to make use of <see cref="EventData.Properties" /> to associate serialization hints
        ///   as an aid to consumers who wish to deserialize the binary data.</para>
        /// </remarks>
        ///
        /// <seealso cref="BinaryData" />
        /// <seealso cref="EventData.Properties" />
        ///
        public BinaryData EventBody { get; }

        /// <summary>
        ///   The set of free-form event properties which may be used for passing metadata associated with the event body
        ///   during Event Hubs operations.
        /// </summary>
        ///
        /// <remarks>
        ///   A common use case for <see cref="EventData.Properties" /> is to associate serialization hints for the <see cref="EventData.EventBody" />
        ///   as an aid to consumers who wish to deserialize the binary data.
        /// </remarks>
        ///
        /// <example>
        ///   <code>
        ///     var eventData = new EventData(serializedTelemetryData);
        ///     eventData.Properties["eventType"] = "com.microsoft.Azure.monitoring.EtlEvent";
        ///   </code>
        /// </example>
        ///
        public IDictionary<string, object> Properties { get; }

        /// <summary>
        ///   The set of free-form event properties which were provided by the Event Hubs service to pass metadata associated with the
        ///   event or associated Event Hubs operation.
        /// </summary>
        ///
        /// <remarks>
        ///   These properties are only populated for events received from the Event Hubs service.  The set is otherwise
        ///   empty.
        /// </remarks>
        ///
        public IReadOnlyDictionary<string, object> SystemProperties { get; }

        /// <summary>
        ///   The publishing sequence number assigned to the event at the time it was successfully published.
        /// </summary>
        ///
        /// <value>
        ///   The sequence number that was assigned during publishing, if the event was successfully
        ///   published by a sequence-aware producer.  If the producer was not configured to apply
        ///   sequence numbering or if the event has not yet been successfully published, this member
        ///   will be <c>null</c>.
        /// </value>
        ///
        /// <remarks>
        ///   The published sequence number is only populated and relevant when certain features
        ///   of the producer are enabled.  For example, it is used by idempotent publishing.
        /// </remarks>
        ///
        public int? PublishedSequenceNumber { get; private set; }

        /// <summary>
        ///   The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service. If this
        ///   EventData was not received from the Event Hubs service, the value is <see cref="long.MinValue"/>.
        /// </remarks>
        ///
        public long SequenceNumber { get; }

        /// <summary>
        ///   The offset of the event when it was received from the associated Event Hub partition.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service. If this
        ///   EventData was not received from the Event Hubs service, the value is <see cref="long.MinValue"/>.
        /// </remarks>
        ///
        public long Offset { get; }

        /// <summary>
        ///   The date and time, in UTC, of when the event was enqueued in the Event Hub partition.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service. If this
        ///   EventData was not received from the Event Hubs service, the value <c>default(DateTimeOffset)</c>.
        /// </remarks>
        ///
        public DateTimeOffset EnqueuedTime { get; }

        /// <summary>
        ///   The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was published with.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service.
        /// </remarks>
        ///
        public string PartitionKey { get; }

        /// <summary>
        ///   The data associated with the event.
        /// </summary>
        ///
        /// <remarks>
        ///   This member exists only to preserve backward compatibility.  It is recommended to
        ///   prefer the <see cref="EventBody" /> where possible in order to take advantage of
        ///   additional functionality and improved usability for common scenarios.
        /// </remarks>
        ///
        /// <seealso cref="EventData.EventBody" />
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyMemory<byte> Body => EventBody.ToMemory();

        /// <summary>
        ///   The data associated with the event, in stream form.
        /// </summary>
        ///
        /// <value>
        ///   A <see cref="Stream" /> containing the raw data representing the <see cref="EventBody" />
        ///   of the event.  The caller is assumed to have ownership of the stream, including responsibility
        ///   for managing its lifespan and ensuring proper disposal.
        /// </value>
        ///
        /// <remarks>
        ///   This member exists only to preserve backward compatibility.  It is recommended to
        ///   prefer the <see cref="EventBody" /> where possible in order to take advantage of
        ///   additional functionality and improved usability for common scenarios.
        /// </remarks>
        ///
        /// <seealso cref="BinaryData.ToStream" />
        /// <seealso cref="EventData.EventBody" />
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Stream BodyAsStream => EventBody.ToStream();

        /// <summary>
        ///   The sequence number of the event that was last enqueued into the Event Hub partition from which this
        ///   event was received.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received using an reader specifying
        ///   <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> as enabled.
        /// </remarks>
        ///
        internal long? LastPartitionSequenceNumber { get; }

        /// <summary>
        ///   The offset of the event that was last enqueued into the Event Hub partition from which this event was
        ///   received.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received using an reader specifying
        ///   <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> as enabled.
        /// </remarks>
        ///
        internal long? LastPartitionOffset { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last event was enqueued into the Event Hub partition from
        ///   which this event was received.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received using an reader specifying
        ///   <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> as enabled.
        /// </remarks>
        ///
        internal DateTimeOffset? LastPartitionEnqueuedTime { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last event information for the Event Hub partition was retrieved
        ///   from the Event Hubs service.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received using an reader specifying
        ///   <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> as enabled.
        /// </remarks>
        ///
        internal DateTimeOffset? LastPartitionPropertiesRetrievalTime { get; }

        /// <summary>
        ///   The publishing sequence number assigned to the event as part of a publishing operation.
        /// </summary>
        ///
        /// <value>
        ///   This member is only populated while a publishing operation is taking place; once the
        ///   operation has completed, successfully or not, the value is cleared.
        /// </value>
        ///
        /// <remarks>
        ///   The published sequence number is only populated and relevant when certain features
        ///   of the producer are enabled.  For example, it is used by idempotent publishing.
        /// </remarks>
        ///
        internal int? PendingPublishSequenceNumber { get; set; }

        /// <summary>
        ///   The producer group identifier assigned to the event as part of a publishing operation.
        /// </summary>
        ///
        /// <value>
        ///   This member is only populated while a publishing operation is taking place; once the
        ///   operation has completed, successfully or not, the value is cleared.
        /// </value>
        ///
        /// <remarks>
        ///   The producer group identifier is only populated and relevant when certain features
        ///   of the producer are enabled.  For example, it is used by idempotent publishing.
        /// </remarks>
        ///
        internal long? PendingProducerGroupId { get; set; }

        /// <summary>
        ///   The producer owner level assigned to the event as part of a publishing operation.
        /// </summary>
        ///
        /// <value>
        ///   This member is only populated while a publishing operation is taking place; once the
        ///   operation has completed, successfully or not, the value is cleared.
        /// </value>
        ///
        /// <remarks>
        ///   The producer group identifier is only populated and relevant when certain features
        ///   of the producer are enabled.  For example, it is used by idempotent publishing.
        /// </remarks>
        ///
        internal short? PendingProducerOwnerLevel { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data as binary to use as the body of the event.</param>
        ///
        public EventData(BinaryData eventBody) : this(eventBody, lastPartitionSequenceNumber: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        ///
        public EventData(ReadOnlyMemory<byte> eventBody) : this(new BinaryData(eventBody), lastPartitionSequenceNumber: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties received from the Event Hubs service.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        /// <param name="partitionKey">The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.</param>
        /// <param name="lastPartitionSequenceNumber">The sequence number that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionOffset">The offset that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionEnqueuedTime">The date and time, in UTC, of the event that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionPropertiesRetrievalTime">The date and time, in UTC, that the last event information for the Event Hub partition was retrieved from the service.</param>
        /// <param name="publishedSequenceNumber">The publishing sequence number assigned to the event at the time it was successfully published.</param>
        /// <param name="pendingPublishSequenceNumber">The publishing sequence number assigned to the event as part of a publishing operation.</param>
        /// <param name="pendingProducerGroupId">The producer group identifier assigned to the event as part of a publishing operation.</param>
        /// <param name="pendingOwnerLevel">The producer owner level assigned to the event as part of a publishing operation.</param>
        ///
        internal EventData(ReadOnlyMemory<byte> eventBody,
                           IDictionary<string, object> properties = null,
                           IReadOnlyDictionary<string, object> systemProperties = null,
                           long sequenceNumber = long.MinValue,
                           long offset = long.MinValue,
                           DateTimeOffset enqueuedTime = default,
                           string partitionKey = null,
                           long? lastPartitionSequenceNumber = null,
                           long? lastPartitionOffset = null,
                           DateTimeOffset? lastPartitionEnqueuedTime = null,
                           DateTimeOffset? lastPartitionPropertiesRetrievalTime = null,
                           int? publishedSequenceNumber = null,
                           int? pendingPublishSequenceNumber = null,
                           long? pendingProducerGroupId = null,
                           short? pendingOwnerLevel = null) : this(new BinaryData(eventBody), properties, systemProperties, sequenceNumber, offset, enqueuedTime, partitionKey,
                           lastPartitionSequenceNumber, lastPartitionOffset, lastPartitionEnqueuedTime, lastPartitionPropertiesRetrievalTime, publishedSequenceNumber, pendingPublishSequenceNumber,
                           pendingProducerGroupId, pendingOwnerLevel)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data as binary to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties received from the Event Hubs service.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        /// <param name="partitionKey">The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.</param>
        /// <param name="lastPartitionSequenceNumber">The sequence number that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionOffset">The offset that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionEnqueuedTime">The date and time, in UTC, of the event that was last enqueued into the Event Hub partition.</param>
        /// <param name="lastPartitionPropertiesRetrievalTime">The date and time, in UTC, that the last event information for the Event Hub partition was retrieved from the service.</param>
        /// <param name="publishedSequenceNumber">The publishing sequence number assigned to the event at the time it was successfully published.</param>
        /// <param name="pendingPublishSequenceNumber">The publishing sequence number assigned to the event as part of a publishing operation.</param>
        /// <param name="pendingProducerGroupId">The producer group identifier assigned to the event as part of a publishing operation.</param>
        /// <param name="pendingOwnerLevel">The producer owner level assigned to the event as part of a publishing operation.</param>
        ///
        internal EventData(BinaryData eventBody,
                           IDictionary<string, object> properties = null,
                           IReadOnlyDictionary<string, object> systemProperties = null,
                           long sequenceNumber = long.MinValue,
                           long offset = long.MinValue,
                           DateTimeOffset enqueuedTime = default,
                           string partitionKey = null,
                           long? lastPartitionSequenceNumber = null,
                           long? lastPartitionOffset = null,
                           DateTimeOffset? lastPartitionEnqueuedTime = null,
                           DateTimeOffset? lastPartitionPropertiesRetrievalTime = null,
                           int? publishedSequenceNumber = null,
                           int? pendingPublishSequenceNumber = null,
                           long? pendingProducerGroupId = null,
                           short? pendingOwnerLevel = null)
        {
            EventBody = eventBody;
            Properties = properties ?? new Dictionary<string, object>();
            SystemProperties = systemProperties ?? new Dictionary<string, object>();
            SequenceNumber = sequenceNumber;
            Offset = offset;
            EnqueuedTime = enqueuedTime;
            PartitionKey = partitionKey;
            LastPartitionSequenceNumber = lastPartitionSequenceNumber;
            LastPartitionOffset = lastPartitionOffset;
            LastPartitionEnqueuedTime = lastPartitionEnqueuedTime;
            LastPartitionPropertiesRetrievalTime = lastPartitionPropertiesRetrievalTime;
            PublishedSequenceNumber = publishedSequenceNumber;
            PendingPublishSequenceNumber = pendingPublishSequenceNumber;
            PendingProducerGroupId = pendingProducerGroupId;
            PendingProducerOwnerLevel = pendingOwnerLevel;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties received from the Event Hubs service.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        /// <param name="partitionKey">The partition hashing key associated with the event when it was published.</param>
        ///
        protected EventData(BinaryData eventBody,
                            IDictionary<string, object> properties = null,
                            IReadOnlyDictionary<string, object> systemProperties = null,
                            long sequenceNumber = long.MinValue,
                            long offset = long.MinValue,
                            DateTimeOffset enqueuedTime = default,
                            string partitionKey = null) : this(eventBody, properties, systemProperties, sequenceNumber, offset, enqueuedTime, partitionKey, lastPartitionSequenceNumber: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties received from the Event Hubs service.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        /// <param name="partitionKey">The partition hashing key associated with the event when it was published.</param>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected EventData(ReadOnlyMemory<byte> eventBody,
                            IDictionary<string, object> properties = null,
                            IReadOnlyDictionary<string, object> systemProperties = null,
                            long sequenceNumber = long.MinValue,
                            long offset = long.MinValue,
                            DateTimeOffset enqueuedTime = default,
                            string partitionKey = null) : this(new BinaryData(eventBody), properties, systemProperties, sequenceNumber, offset, enqueuedTime, partitionKey, lastPartitionSequenceNumber: null)
        {
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Transitions the pending state to its permanent form.
        /// </summary>
        ///
        internal void CommitPublishingState()
        {
            PublishedSequenceNumber = PendingPublishSequenceNumber;
            ClearPublishingState();
        }

        /// <summary>
        ///   Clears the pending publishing state.
        /// </summary>
        ///
        internal void ClearPublishingState()
        {
            PendingProducerGroupId = default;
            PendingProducerOwnerLevel = default;
            PendingPublishSequenceNumber = default;
        }

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventData" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventData" />.</returns>
        ///
        internal EventData Clone() =>
            new EventData
            (
                EventBody,
                new Dictionary<string, object>(Properties),
                SystemProperties,
                SequenceNumber,
                Offset,
                EnqueuedTime,
                PartitionKey,
                LastPartitionSequenceNumber,
                LastPartitionOffset,
                LastPartitionEnqueuedTime,
                LastPartitionPropertiesRetrievalTime,
                PublishedSequenceNumber,
                PendingPublishSequenceNumber
            );
    }
}
