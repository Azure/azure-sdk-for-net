// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Azure.Messaging.EventHubs.Core;

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
        public long SequenceNumber => SystemProperties.SequenceNumber;

        /// <summary>
        ///   The offset of the event when it was received from the associated Event Hub partition.
        /// </summary>
        ///
        public long Offset => SystemProperties.Offset;

        /// <summary>
        ///   The date and time, in UTC, of when the event was enqueued in the Event Hub partition.
        /// </summary>
        ///
        public DateTimeOffset EnqueuedTime => SystemProperties.EnqueuedTime;

        /// <summary>
        ///   The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.
        /// </summary>
        ///
        public string PartitionKey => SystemProperties.PartitionKey;

        /// <summary>
        ///   The set of event properties which are owned and populated by the Event Hubs service during
        ///   operations.
        /// </summary>
        ///
        internal SystemEventProperties SystemProperties { get; set; }

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
        internal sealed class SystemEventProperties : Dictionary<string, object>
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="SystemEventProperties"/> class.
            /// </summary>
            ///
            internal SystemEventProperties()
            {
            }

            /// <summary>
            ///   Initializes a new instance of the <see cref="SystemEventProperties"/> class.
            /// </summary>
            ///
            /// <param name="sequenceNumber">The logical sequence number of the event within the partition stream of the Event Hub.</param>
            /// <param name="enqueuedTime">The date and time, in UTC, that the event was received by the partition.</param>
            /// <param name="offset">The offset of the event relative to the Event Hub partition stream.</param>
            /// <param name="partitionKey">The partition hashing key associate with the batch that the event was grouped with when sent.</param>
            ///
            internal SystemEventProperties(long sequenceNumber,
                                           DateTimeOffset enqueuedTime,
                                           string offset,
                                           string partitionKey)
            {
                this[MessagePropertyName.SequenceNumber] = sequenceNumber;
                this[MessagePropertyName.EnqueuedTime] = enqueuedTime;
                this[MessagePropertyName.Offset] = offset;
                this[MessagePropertyName.PartitionKey] = partitionKey;
            }

            /// <summary>
            ///   The logical sequence number of the <see cref="EventData" /> within the partition stream of the Event Hub.
            /// </summary>
            ///
            internal long SequenceNumber
            {
                get
                {
                    if (this.TryGetValue(MessagePropertyName.SequenceNumber, out var value))
                    {
                        return (long)value;
                    }

                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.MissingSystemProperty, MessagePropertyName.SequenceNumber));
                }
            }

            /// <summary>
            ///   The date and time, in UTC, that the <see cref="EventData" /> was received by the partition.
            /// </summary>
            ///
            internal DateTimeOffset EnqueuedTime
            {
                get
                {
                    if (this.TryGetValue(MessagePropertyName.EnqueuedTime, out var value))
                    {
                        return (DateTimeOffset)value;
                    }

                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.MissingSystemProperty, MessagePropertyName.EnqueuedTime));
                }
            }

            /// <summary>
            ///   The offset of the <see cref="EventData" /> relative to the Event Hub partition stream.
            /// </summary>
            ///
            /// <remarks>
            ///   The offset is a marker or identifier for an event within the Event Hubs stream. The
            ///   identifier is unique within a partition of the Event Hubs stream.
            /// </remarks>
            ///
            internal long Offset
            {
                get
                {
                    if (this.TryGetValue(MessagePropertyName.Offset, out var value))
                    {
                        if (value is long offset)
                        {
                            return offset;
                        }

                        if ((value is string token) && (Int64.TryParse(token, out var parsedOffset)))
                        {
                            return parsedOffset;
                        }
                    }

                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.MissingSystemProperty, MessagePropertyName.Offset));
                }
            }

            /// <summary>
            ///   The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.
            /// </summary>
            ///
            internal string PartitionKey
            {
                get
                {
                    if (this.TryGetValue(MessagePropertyName.PartitionKey, out var value))
                    {
                        return (string)value;
                    }

                    return null;
                }
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
        }
    }
}
