// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs;

    internal static class TestUtility
    {
        private static readonly Lazy<string> EventHubsConnectionStringInstance =
            new Lazy<string>( () => BuildEventHubsConnectionString(ReadEnvironmentVariable(TestConstants.EventHubsConnectionStringEnvironmentVariableName)), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> StorageConnectionStringInstance =
            new Lazy<string>( () => ReadEnvironmentVariable(TestConstants.StorageConnectionStringEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        internal static string EventHubsConnectionString => EventHubsConnectionStringInstance.Value;

        internal static string StorageConnectionString => StorageConnectionStringInstance.Value;

        internal static string GetEntityConnectionString(string entityName) =>
            new EventHubsConnectionStringBuilder(EventHubsConnectionString) { EntityPath = entityName }.ToString();

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

        internal static async Task<Dictionary<string, string>> DiscoverEndOfStreamForPartitionsAsync(EventHubClient ehClient, string[] partitionIds)
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

        private static string BuildEventHubsConnectionString(string sourceConnectionString)
        {
            var connectionString = new EventHubsConnectionStringBuilder(sourceConnectionString);

            connectionString.EntityPath = connectionString.EntityPath ?? TestConstants.DefultEventHubName;
            connectionString.OperationTimeout = TestConstants.DefaultOperationTimeout;

            return connectionString.ToString();
        }

        private static string ReadEnvironmentVariable(string variableName)
        {
            var environmentVar = Environment.GetEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(environmentVar))
            {
                throw new InvalidOperationException($"'{variableName}' environment variable was not found!");
            }

            return environmentVar;
        }
    }
}
