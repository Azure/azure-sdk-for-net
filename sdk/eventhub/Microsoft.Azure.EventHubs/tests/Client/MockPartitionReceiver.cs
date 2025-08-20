// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    public class MockPartitionReceiver : PartitionReceiver
    {
        private readonly MockEventHubClient eventHubClient;

        public MockPartitionReceiver(
            MockEventHubClient eventHubClient,
            string consumerGroupName = "consumerGroup",
            string partitionId = "1",
            EventPosition eventPosition = default,
            long? epoch = default,
            ReceiverOptions receiverOptions = default)
            : base(eventHubClient, consumerGroupName, partitionId, eventPosition ?? EventPosition.FromStart(), epoch, receiverOptions)
        {
            this.eventHubClient = eventHubClient;
        }

        protected override Task OnCloseAsync()
        {
            return Task.CompletedTask;
        }

        protected override Task<IList<EventData>> OnReceiveAsync(int maxMessageCount, TimeSpan waitTime)
        {
            IList<EventData> events = new List<EventData>();
            if (eventHubClient.EventManager.TryGetValue(PartitionId, out var eventQueue))
            {
                var count = 0;
                while (count < maxMessageCount && eventQueue.TryDequeue(out var eventData))
                {
                    eventData.RetrievalTime = DateTime.UtcNow;
                    events.Add(eventData);
                    count++;
                }
            }

            return Task.FromResult(events);
        }

        protected override void OnSetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }
    }
}