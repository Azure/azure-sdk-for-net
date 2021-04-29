// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace Microsoft.Azure.WebJobs
{
    internal class EventDataBatchImpl : IEventDataBatch
    {
        public EventDataBatchImpl(EventDataBatch eventDataBatch)
        {
            Batch = eventDataBatch;
        }

        public int Count => Batch.Count;
        public long MaximumSizeInBytes => Batch.MaximumSizeInBytes;
        public EventDataBatch Batch { get; }

        public bool TryAdd(EventData eventData)
        {
            return Batch.TryAdd(eventData);
        }
    }
}