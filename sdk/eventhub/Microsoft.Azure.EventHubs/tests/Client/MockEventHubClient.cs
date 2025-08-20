// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs;

    /// <summary>
    /// Anchor class - all EventHub client operations start here.
    /// See <see cref="EventHubClient.CreateFromConnectionString(string)"/>
    /// </summary>
    public class MockEventHubClient : EventHubClient
    {
        internal MockEventHubClient(EventHubsConnectionStringBuilder csb)
            : base(csb)
        {
            EventManager = new ConcurrentDictionary<string, ConcurrentQueue<EventData>>();
            PartitionRuntimeInformations = new ConcurrentDictionary<string, EventHubPartitionRuntimeInformation>();
        }

        internal ConcurrentDictionary<string, ConcurrentQueue<EventData>> EventManager;

        internal ConcurrentDictionary<string, EventHubPartitionRuntimeInformation> PartitionRuntimeInformations;

        protected override Task OnCloseAsync()
        {
            return Task.CompletedTask;
        }

        protected override PartitionReceiver OnCreateReceiver(string consumerGroupName, string partitionId, EventPosition eventPosition, long? epoch, ReceiverOptions receiverOptions)
        {
            EventManager.TryAdd(partitionId, new ConcurrentQueue<EventData>());
            return new MockPartitionReceiver(this, consumerGroupName, partitionId, eventPosition, epoch, receiverOptions);
        }

        protected override Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId)
        {
            return Task.FromResult(PartitionRuntimeInformations[partitionId]);
        }

        protected override Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync()
        {
            return Task.FromResult(new EventHubRuntimeInformation());
        }

        internal override EventDataSender OnCreateEventSender(string partitionId)
        {
            EventManager.TryAdd(partitionId, new ConcurrentQueue<EventData>());
            return new MockEventDataSender(this, partitionId);
        }
    }
}
