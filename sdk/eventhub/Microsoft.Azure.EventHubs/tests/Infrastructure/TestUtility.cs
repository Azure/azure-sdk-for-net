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
            new Lazy<string>( () => ReadEnvironmentVariable(TestConstants.EventHubsConnectionStringEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> StorageConnectionStringInstance =
            new Lazy<string>( () => ReadEnvironmentVariable(TestConstants.StorageConnectionStringEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> EventHubsSubscriptionInstance =
          new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsSubscriptionEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Event Hubs resource group name, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsResourceGroupInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsResourceGroupEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Event Hubs namespace name, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsNamespaceInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsNamespaceEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory tenent that holds the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsTenantInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsTenantEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory client identifier of the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsClientInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsClientEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>The environment variable value for the Azure Active Directory client secret of the service principal, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsSecretInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsSecretEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);
        internal static string EventHubsConnectionString => EventHubsConnectionStringInstance.Value;

        internal static string StorageConnectionString => StorageConnectionStringInstance.Value;

        internal static string EventHubsSubscription => EventHubsSubscriptionInstance.Value;

        /// <summary>
        ///   The name of the resource group containing the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_RESOURCEGROUP" environment variable.</value>
        ///
        internal static string EventHubsResourceGroup => EventHubsResourceGroupInstance.Value;

        /// <summary>
        ///   The name of the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_NAMESPACE" environment variable.</value>
        ///
        internal static string EventHubsNamespace => EventHubsNamespaceInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory tenant that holds the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_TENANT" environment variable.</value>
        ///
        internal static string EventHubsTenant => EventHubsTenantInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory client identifier of the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_CLIENT" environment variable.</value>
        ///
        internal static string EventHubsClient => EventHubsClientInstance.Value;

        /// <summary>
        ///   The name of the Azure Active Directory client secret of the service principal to use for management
        ///   of the Event Hubs namespace during Live tests.
        /// </summary>
        ///
        /// <value>The name of the namespace is read from the "EVENT_HUBS_SECRET" environment variable.</value>
        ///
        internal static string EventHubsSecret => EventHubsSecretInstance.Value;

        /// <summary>
        ///   Builds a connection string for a specific Event Hub instance under the Event Hubs namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The namepsace connection string is read from the "EVENT_HUBS_CONNECTION_STRING" environment variable.</value>
        ///
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

        //private static string BuildEventHubsConnectionString(string sourceConnectionString)
        //{
        //    var connectionString = new EventHubsConnectionStringBuilder(sourceConnectionString);

        //    connectionString.EntityPath = connectionString.EntityPath ?? TestConstants.DefultEventHubName;
        //    connectionString.OperationTimeout = TestConstants.DefaultOperationTimeout;

        //    return connectionString.ToString();
        //}
        public static string BuildEventHubsConnectionString(string eventHubName)
        {
            var connectionString = new EventHubsConnectionStringBuilder(EventHubsConnectionString);

            connectionString.EntityPath = connectionString.EntityPath ?? eventHubName;
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
