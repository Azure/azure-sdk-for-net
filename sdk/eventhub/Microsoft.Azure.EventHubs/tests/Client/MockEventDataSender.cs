// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class MockEventDataSender : EventDataSender
    {
        private readonly MockEventHubClient eventHubClient;

        internal MockEventDataSender(MockEventHubClient eventHubClient, string partitionId)
            : base(eventHubClient, partitionId)
        {
            this.RetryPolicy = eventHubClient.RetryPolicy.Clone();
            this.eventHubClient = eventHubClient;
        }

        public override Task CloseAsync()
        {
            return Task.CompletedTask;
        }

        protected override Task OnSendAsync(IEnumerable<EventData> eventDatas, string partitionKey)
        {
            if (eventHubClient.EventManager.TryGetValue(PartitionId, out var eventQueue))
            {
                var utcNow = DateTime.UtcNow;
                foreach (var eventData in eventDatas)
                {
                    eventData.LastEnqueuedTime = utcNow;
                    eventData.SystemProperties = new EventData.SystemPropertiesCollection(1, eventData.LastEnqueuedTime, eventData.LastEnqueuedOffset, partitionKey);

                    eventHubClient.PartitionRuntimeInformations.TryAdd(partitionKey, new EventHubPartitionRuntimeInformation());
                    eventHubClient.PartitionRuntimeInformations[partitionKey].LastEnqueuedOffset = eventData.LastEnqueuedOffset;
                    eventHubClient.PartitionRuntimeInformations[partitionKey].LastEnqueuedTimeUtc = eventData.LastEnqueuedTime;
                    eventHubClient.PartitionRuntimeInformations[partitionKey].LastEnqueuedSequenceNumber = eventData.LastSequenceNumber;
                    eventQueue.Enqueue(eventData);
                }
            }

            return Task.CompletedTask;
        }
    }
}