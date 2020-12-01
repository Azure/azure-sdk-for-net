// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;

namespace Microsoft.Azure.WebJobs
{
    // TODO: remove when https://github.com/Azure/azure-sdk-for-net/issues/9117 is fixed
    internal class EventHubConsumerClientImpl : IEventHubConsumerClient
    {
        private readonly EventHubConsumerClient _client;

        public EventHubConsumerClientImpl(EventHubConsumerClient client)
        {
            _client = client;
        }

        public string EventHubName => _client.EventHubName;

        public string FullyQualifiedNamespace => _client.FullyQualifiedNamespace;

        public string ConsumerGroup => _client.ConsumerGroup;

        public async Task<string[]> GetPartitionsAsync() => (await _client.GetEventHubPropertiesAsync().ConfigureAwait(false)).PartitionIds;

        public Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId) => _client.GetPartitionPropertiesAsync(partitionId);
    }
}