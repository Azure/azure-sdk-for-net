// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
    using Azure.Amqp;

    /// <summary>
    /// The data structure encapsulating the Event being sent-to and received-from EventHubs.
    /// Each EventHubs partition can be visualized as a Stream of EventData.
    /// </summary>
    public class EventData : IDisposable
    {
        bool disposed;

        /// <summary>
        /// Construct EventData to send to EventHub.
        /// Typical pattern to create a Sending EventData is:
        /// <para>i. Serialize the sending ApplicationEvent to be sent to EventHubs into bytes.</para>
        /// <para>ii. If complex serialization logic is involved (for example: multiple types of data) - add a Hint using the <see cref="EventData.Properties"/> for the Consumer.</para>
        /// </summary>
        /// <example>Sample Code:
        /// <code>
        /// EventData eventData = new EventData(telemetryEventBytes);
        /// eventData.Properties["eventType"] = "com.microsoft.azure.monitoring.EtlEvent";
        /// await partitionSender.SendAsync(eventData);
        /// </code>
        /// </example>
        /// <param name="array">The actual payload of data in bytes to be sent to the EventHub.</param>
        public EventData(byte[] array)
            : this(new ArraySegment<byte>(array))
        {
        }

        /// <summary>
        /// Construct EventData to send to EventHub.
        /// Typical pattern to create a Sending EventData is:
        /// <para>i.  Serialize the sending ApplicationEvent to be sent to EventHub into bytes.</para>
        /// <para>ii. If complex serialization logic is involved (for example: multiple types of data) - add a Hint using the <see cref="EventData.Properties"/> for the Consumer.</para>
        /// </summary>
        /// <example>Sample Code:
        /// <code>
        /// EventData eventData = new EventData(new ArraySegment&lt;byte&gt;(eventBytes, offset, count));
        /// eventData.Properties["eventType"] = "com.microsoft.azure.monitoring.EtlEvent";
        /// await partitionSender.SendAsync(eventData);
        /// </code>
        /// </example>
        /// <param name="arraySegment">The payload bytes, offset and length to be sent to the EventHub.</param>
        public EventData(ArraySegment<byte> arraySegment)
        {
            this.Body = arraySegment;
            this.Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Get the actual Payload/Data wrapped by EventData.
        /// This is intended to be used after receiving EventData using <see cref="PartitionReceiver"/>.
        /// </summary>
        public ArraySegment<byte> Body { get; }

        /// <summary>
        /// Application property bag
        /// </summary>
        public IDictionary<string, object> Properties { get; internal set; }

        /// <summary>
        /// SystemProperties that are populated by EventHubService.
        /// As these are populated by Service, they are only present on a Received EventData.
        /// </summary>
        public SystemPropertiesCollection SystemProperties
        {
            get; set;
        }

        /// <summary>
        /// Gets and sets type of the content.
        /// </summary>
        public string ContentType { get; set; }

        internal AmqpMessage AmqpMessage { get; set; }

        internal long LastSequenceNumber { get; set; }

        internal string LastEnqueuedOffset { get; set; }

        internal DateTime LastEnqueuedTime { get; set; }

        internal DateTime RetrievalTime { get; set; }

        /// <summary>
        /// Disposes resources attached to an Event Data
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    AmqpMessage?.Dispose();
                }

                disposed = true;
            }
        }

        /// <summary>
        /// A collection used to store properties which are set by the Event Hubs service.
        /// </summary>
        public sealed class SystemPropertiesCollection : Dictionary<string, object>
        {
            internal SystemPropertiesCollection()
            {
            }

            /// <summary>
            /// Construct and initialize a new instance.
            /// </summary>
            /// <param name="sequenceNumber"></param>
            /// <param name="enqueuedTimeUtc"></param>
            /// <param name="offset"></param>
            /// <param name="partitionKey"></param>
            public SystemPropertiesCollection(long sequenceNumber, DateTime enqueuedTimeUtc, string offset, string partitionKey)
            {
                this[ClientConstants.SequenceNumberName] = sequenceNumber;
                this[ClientConstants.EnqueuedTimeUtcName] = enqueuedTimeUtc;
                this[ClientConstants.OffsetName] = offset;
                this[ClientConstants.PartitionKeyName] = partitionKey;
            }

            /// <summary>Gets the logical sequence number of the event within the partition stream of the Event Hub.</summary>
            public long SequenceNumber
            {
                get
                {
                    object value;
                    if (this.TryGetValue(ClientConstants.SequenceNumberName, out value))
                    {
                        return (long)value;
                    }

                    throw new ArgumentException(Resources.MissingSystemProperty.FormatForUser(ClientConstants.SequenceNumberName));
                }
            }

            /// <summary>Gets or sets the date and time of the sent time in UTC.</summary>
            /// <value>The enqueue time in UTC. This value represents the actual time of enqueuing the message.</value>
            public DateTime EnqueuedTimeUtc
            {
                get
                {
                    object value;
                    if (this.TryGetValue(ClientConstants.EnqueuedTimeUtcName, out value))
                    {
                        return (DateTime)value;
                    }

                    throw new ArgumentException(Resources.MissingSystemProperty.FormatForUser(ClientConstants.EnqueuedTimeUtcName));
                }
            }

            /// <summary>
            /// Gets the offset of the data relative to the Event Hub partition stream. The offset is a marker or identifier for an event within the Event Hubs stream. The identifier is unique within a partition of the Event Hubs stream.
            /// </summary>
            public string Offset
            {
                get
                {
                    object value;
                    if (this.TryGetValue(ClientConstants.OffsetName, out value))
                    {
                        return (string)value;
                    }

                    throw new ArgumentException(Resources.MissingSystemProperty.FormatForUser(ClientConstants.OffsetName));
                }
            }

            /// <summary>Gets the partition key of the corresponding partition that stored the <see cref="EventData"/></summary>
            public string PartitionKey
            {
                get
                {
                    object value;
                    if (this.TryGetValue(ClientConstants.PartitionKeyName, out value))
                    {
                        return (string)value;
                    }

                    return null;
                }
            }
        }
    }
}

