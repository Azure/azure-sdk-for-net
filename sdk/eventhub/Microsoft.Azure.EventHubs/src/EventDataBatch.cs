// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.EventHubs.Amqp;
    using Microsoft.Azure.EventHubs.Primitives;

    /// <summary>A helper class for creating an IEnumerable&lt;<see cref="Microsoft.Azure.EventHubs.EventData"/>&gt; taking into account the max size limit, so that the IEnumerable&lt;<see cref="Microsoft.Azure.EventHubs.EventData"/>&gt; can be passed to the Send or SendAsync method of an <see cref="Microsoft.Azure.EventHubs.EventHubClient"/> to send the <see cref="Microsoft.Azure.EventHubs.EventData"/> objects as a batch.</summary>
    public class EventDataBatch : IDisposable
    {
        const int MaxSizeLimit = 4 * 1024 * 1024;
        const int DiagnosticsIdOverhead = 64;

        readonly List<EventData> eventDataList;
        readonly long maxSize;

        long currentSize;
        bool disposed;

        /// <summary>
        /// Creates a new <see cref="EventDataBatch"/>.
        /// </summary>
        /// <param name="maxSizeInBytes">The maximum size allowed for the batch</param>
        /// <param name="partitionKey">Partition key associated with the batch</param>
        public EventDataBatch(long maxSizeInBytes, string partitionKey = null)
        {
            this.PartitionKey = partitionKey;
            this.maxSize = Math.Min(maxSizeInBytes, MaxSizeLimit);
            this.eventDataList = new List<EventData>();

            // Reserve for wrapper message.
            using (var batchMessage = AmqpMessage.Create())
            {
                batchMessage.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;
                AmqpMessageConverter.UpdateAmqpMessagePartitionKey(batchMessage, partitionKey);
                this.currentSize = batchMessage.SerializedMessageSize;
            }
        }

        /// <summary>Gets the current event count in the batch.</summary>
        public int Count
        {
            get
            {
                this.ThrowIfDisposed();
                return this.eventDataList.Count;
            }
        }

        /// <summary>Gets the current batch size in bytes.</summary>
        public long Size
        {
            get
            {
                this.ThrowIfDisposed();
                return this.currentSize;
            }
        }

        /// <summary>Tries to add an event data to the batch if permitted by the batch's size limit.</summary>
        /// <param name="eventData">The <see cref="Microsoft.Azure.EventHubs.EventData" /> to add.</param>
        /// <returns>A boolean value indicating if the event data has been added to the batch or not.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the EventData is null.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the batch is already disposed.</exception>
        /// <remarks>
        /// This method checks the sizes of the batch, the EventData object and the specified limit to determine
        /// if the EventData object can be added.
        /// </remarks>
        public bool TryAdd(EventData eventData)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);

            this.ThrowIfDisposed();
            long size = GetEventSizeForBatch(eventData);
            if (this.eventDataList.Count > 0 && this.currentSize + size > this.maxSize)
            {
                return false;
            }

            this.eventDataList.Add(eventData);
            this.currentSize += size;

            return true;
        }

        internal string PartitionKey { get; set; }

        long GetEventSizeForBatch(EventData eventData)
        {
            // Create AMQP message here.
            var amqpMessage = AmqpMessageConverter.EventDataToAmqpMessage(eventData);
            AmqpMessageConverter.UpdateAmqpMessagePartitionKey(amqpMessage, this.PartitionKey);

            // Calculate overhead depending on the message size. 
            // Overhead is smaller for messages smaller than 256 bytes.
            long overhead = amqpMessage.SerializedMessageSize < 256 ? 5 : 8;

            // We can use the same AMQP message unless diagnostics is enabled.
            // Diagnostics extension will stamp message with an id on the Send call.
            if (!EventHubsDiagnosticSource.IsEnabledForSendActivity)
            {
                eventData.AmqpMessage = amqpMessage;
            }
            else
            {
                // Reserve overhead for diagnostic-id property.
                overhead += DiagnosticsIdOverhead;
            }

            return amqpMessage.SerializedMessageSize + overhead;
        }

        /// <summary>
        /// Disposes resources attached to an EventDataBatch.
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
                    this.disposed = true;
                    foreach (var e in this.eventDataList)
                    {
                        e.Dispose();
                    }
                }

                disposed = true;
            }
        }

        void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }

        /// <summary>Returns the enumerator of EventData objects in the batch.</summary>
        /// <returns>IEnumerable of EventData objects.</returns>
        public IEnumerable<EventData> ToEnumerable()
        {
            this.ThrowIfDisposed();
            return this.eventDataList;
        }
    }
}
