// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        ///   The data associated with the event.
        /// </summary>
        ///
        /// <remarks>
        ///   If the means for deserializaing the raw data is not apparent to consumers, a
        ///   common technique is to make use of <see cref="EventData.Properties" /> to associate serialization hints
        ///   as an aid to consumers who wish to deserialize the binary data.
        /// </remarks>
        ///
        /// <seealso cref="EventData.Properties" />
        ///
        public ReadOnlyMemory<byte> Body { get; }

        /// <summary>
        ///   The set of free-form event properties which may be used for passing metadata associated with the event with the event body
        ///   during Event Hubs operations.
        /// </summary>
        ///
        /// <remarks>
        ///   A common use case for <see cref="EventData.Properties" /> is to associate serialization hints for the <see cref="EventData.Body" />
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
        public IDictionary<string, object> Properties { get; internal set; } = new Dictionary<string, object>();

        /// <summary>
        ///   The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service.
        /// </remarks>
        ///
        public long? SequenceNumber => SystemProperties?.SequenceNumber;

        /// <summary>
        ///   The offset of the event when it was received from the associated Event Hub partition.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service.
        /// </remarks>
        ///
        public long? Offset => SystemProperties?.Offset;

        /// <summary>
        ///   The date and time, in UTC, of when the event was enqueued in the Event Hub partition.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service.
        /// </remarks>
        ///
        public DateTimeOffset? EnqueuedTime => SystemProperties?.EnqueuedTime;

        /// <summary>
        ///   The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.
        /// </summary>
        ///
        /// <remarks>
        ///   This property is only populated for events received from the Event Hubs service.
        /// </remarks>
        ///
        public string PartitionKey => SystemProperties?.PartitionKey;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        ///
        public EventData(ReadOnlyMemory<byte> eventBody)
        {
            Body = eventBody;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        /// <param name="systemProperties">The set of system properties received from the Event Hubs service.</param>
        ///
        internal EventData(ReadOnlyMemory<byte> eventBody,
                           SystemEventProperties systemProperties) : this(eventBody)
        {
            SystemProperties = systemProperties;
        }

        /// <summary>
        ///   The set of event properties which are owned and populated by the Event Hubs service during
        ///   operations.
        /// </summary>
        ///
        protected internal SystemEventProperties SystemProperties { get; set; }

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
        ///   The set of event properties which are owned and populated by the Event Hubs service.
        /// </summary>
        ///
        protected internal sealed class SystemEventProperties
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="SystemEventProperties"/> class.
            /// </summary>
            ///
            public SystemEventProperties()
            {
            }

            /// <summary>
            ///   The logical sequence number of the <see cref="EventData" /> within the partition stream of the Event Hub.
            /// </summary>
            ///
            public long SequenceNumber { get; set; }

            /// <summary>
            ///   The date and time, in UTC, that the <see cref="EventData" /> was received by the partition.
            /// </summary>
            ///
            public DateTimeOffset EnqueuedTime { get; set; }

            /// <summary>
            ///   The offset of the <see cref="EventData" /> relative to the Event Hub partition stream.
            /// </summary>
            ///
            /// <remarks>
            ///   The offset is a marker or identifier for an event within the Event Hubs stream. The
            ///   identifier is unique within a partition of the Event Hubs stream.
            /// </remarks>
            ///
            public long Offset { get; set; }

            /// <summary>
            ///   The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.
            /// </summary>
            ///
            public string PartitionKey { get; set; }

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
        }
    }
}
