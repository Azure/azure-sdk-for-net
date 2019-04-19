// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs;

    static class TestUtility
    {
        static TestUtility()
        {
            var ehConnectionString = Environment.GetEnvironmentVariable(TestConstants.EventHubsConnectionStringEnvironmentVariableName);
            var storageConnectionString = Environment.GetEnvironmentVariable(TestConstants.StorageConnectionStringEnvironmentVariableName);

            if (string.IsNullOrWhiteSpace(ehConnectionString))
            {
                throw new InvalidOperationException($"'{TestConstants.EventHubsConnectionStringEnvironmentVariableName}' environment variable was not found!");
            }

            if (string.IsNullOrWhiteSpace(storageConnectionString))
            {
                throw new InvalidOperationException($"'{TestConstants.StorageConnectionStringEnvironmentVariableName}' environment variable was not found!");
            }

            StorageConnectionString = storageConnectionString;

            // Validate the connection string
            var ehCsb = new EventHubsConnectionStringBuilder(ehConnectionString);
            if (ehCsb.EntityPath == null)
            {
                ehCsb.EntityPath = TestConstants.DefultEventHubName;
            }

            // Update operation timeout on ConnectionStringBuilder.
            ehCsb.OperationTimeout = TimeSpan.FromSeconds(30);

            EventHubsConnectionString = ehCsb.ToString();
        }

        internal static string EventHubsConnectionString { get; }

        internal static string StorageConnectionString { get; }

        internal static string GetEntityConnectionString(string entityName)
        {
            // If the entity name is populated in the connection string, it will be overridden.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubsConnectionString)
            {
                EntityPath = entityName
            };
            return connectionStringBuilder.ToString();
        }

        internal static Task SendToPartitionAsync(EventHubClient ehClient, string partitionId, string messageBody, int numberOfMessages = 1)
        {
            return SendToPartitionAsync(ehClient, partitionId, new EventData(Encoding.UTF8.GetBytes(messageBody)), numberOfMessages);
        }

        internal static async Task SendToPartitionAsync(EventHubClient ehClient, string partitionId, EventData eventData, int numberOfMessages = 1)
        {
            TestUtility.Log($"Starting to send {numberOfMessages} messages to partition {partitionId}.");
            var partitionSender = ehClient.CreatePartitionSender(partitionId);

            for (int i = 0; i < numberOfMessages; i++)
            {
                await partitionSender.SendAsync(eventData);
            }

            TestUtility.Log("Sends done.");
        }

        internal static async Task<Dictionary<string, string>> DiscoverEndOfStreamForPartitionsAsync(
            EventHubClient ehClient, 
            string[] partitionIds)
        {
            // Mark offsets in all partitions so we can attempt to receive from that point.
            var partitionOffsets = new Dictionary<string, string>();

            // Discover the end of stream on each partition.
            TestUtility.Log("Discovering end of stream on each partition.");
            foreach (var partitionId in partitionIds)
            {
                var lastEvent = await ehClient.GetPartitionRuntimeInformationAsync(partitionId);
                partitionOffsets.Add(partitionId, lastEvent.LastEnqueuedOffset);
                TestUtility.Log($"Partition {partitionId} has last message with offset {lastEvent.LastEnqueuedOffset}");
            }

            return partitionOffsets;
        }

        internal static async Task<Tuple<string, DateTime, string>> DiscoverEndOfStreamForPartitionAsync(EventHubClient ehClient, string partitionId)
        {
            TestUtility.Log($"Getting partition information for {partitionId}.");
            var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(partitionId);
            return Tuple.Create(pInfo.LastEnqueuedOffset, pInfo.LastEnqueuedTimeUtc, pInfo.LastEnqueuedOffset);
        }

        internal static void Log(string message)
        {
            var formattedMessage = $"{DateTime.Now.TimeOfDay}: {message}";
            Debug.WriteLine(formattedMessage);
            Console.WriteLine(formattedMessage);
        }
    }
}
 