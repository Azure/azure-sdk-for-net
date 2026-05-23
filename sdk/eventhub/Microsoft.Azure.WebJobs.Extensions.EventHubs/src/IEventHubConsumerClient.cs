// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs
{
    // TODO: remove when https://github.com/Azure/azure-sdk-for-net/issues/9117 is fixed
    internal interface IEventHubConsumerClient
    {
        string EventHubName { get; }
        string FullyQualifiedNamespace { get; }
        string ConsumerGroup { get; }
        Task<string[]> GetPartitionsAsync();
        Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId);
    }
}