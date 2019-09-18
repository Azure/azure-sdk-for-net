// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Amqp;
using TrackOne.Amqp;
using TrackOne.Primitives;

namespace TrackOne
{
    /// <summary>A helper class for creating an IEnumerable&lt;<see cref="TrackOne.EventData"/>&gt; taking into account the max size limit, so that the IEnumerable&lt;<see cref="TrackOne.EventData"/>&gt; can be passed to the Send or SendAsync method of an <see cref="TrackOne.EventHubClient"/> to send the <see cref="TrackOne.EventData"/> objects as a batch.</summary>
    internal class EventDataBatch : IDisposable
    {
        private const int MaxSizeLimit = 4 * 1024 * 1024;
        private readonly List<EventData> eventDataList;
        private readonly long maxSize;
        private long currentSize;
        private bool disposed;

        /// <summary>
        /// Creates a new <see cref="EventDataBatch"/>.
        /// </summary>
        /// <param name="maxSizeInBytes">The maximum size allowed for the batch</param>
        /// <param name="partitionKey">Partition key associate with the batch</param>
        public EventDataBatch(long maxSizeInBytes, string partitionKey = null)
        {
            PartitionKey = partitionKey;
            maxSize = Math.Min(maxSizeInBytes, MaxSizeLimit);
            eventDataList = new List<EventData>();

            // Reserve for wrapper message.
            using (var batchMessage = AmqpMessage.Create())
            {
                batchMessage.MessageFormat = AmqpConstants.AmqpBatchedMessageFormat;
                AmqpMessageConverter.UpdateAmqpMessagePartitionKey(batchMessage, partitionKey);
                currentSize = batchMessage.SerializedMessageSize;
            }
        }

        /// <summary>Gets the current event count in the batch.</summary>
        public int Count
        {
            get
            {
                ThrowIfDisposed();
                return eventDataList.Count;
            }
        }

        /// <summary>Tries to add an event data to the batch if permitted by the batch's size limit.</summary>
        /// <param name="eventData">The <see cref="TrackOne.EventData" /> to add.</param>
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

            ThrowIfDisposed();
            long size = GetEventSizeForBatch(eventData);
            if (eventDataList.Count > 0 && currentSize + size > maxSize)
            {
                return false;
            }

            eventDataList.Add(eventData);
            currentSize += size;

            return true;
        }

        internal string PartitionKey { get; set; }

        private long GetEventSizeForBatch(EventData eventData)
        {
            // Create AMQP message here. We will use the same message while sending to save compute time.
            AmqpMessage amqpMessage = AmqpMessageConverter.EventDataToAmqpMessage(eventData);
            AmqpMessageConverter.UpdateAmqpMessagePartitionKey(amqpMessage, PartitionKey);
            eventData.AmqpMessage = amqpMessage;

            // Calculate overhead depending on the message size. 
            // Overhead is smaller for messages smaller than 256 bytes.
            long overhead = eventData.AmqpMessage.SerializedMessageSize < 256 ? 5 : 8;

            return eventData.AmqpMessage.SerializedMessageSize + overhead;
        }

        /// <summary>
        /// Disposes resources attached to an EventDataBatch.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    disposed = true;
                    foreach (EventData e in eventDataList)
                    {
                        e.Dispose();
                    }
                }

                disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        /// <summary>Returns the enumerator of EventData objects in the batch.</summary>
        /// <returns>IEnumerable of EventData objects.</returns>
        public IEnumerable<EventData> ToEnumerable()
        {
            ThrowIfDisposed();
            return eventDataList;
        }
    }
}
