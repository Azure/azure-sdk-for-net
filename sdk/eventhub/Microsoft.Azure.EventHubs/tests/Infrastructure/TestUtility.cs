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
        private static readonly Lazy<string> EventHubsSubscriptionInstance =
          new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsSubscriptionEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> EventHubsResourceGroupInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsResourceGroupEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> EventHubsTenantInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsTenantEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> EventHubsClientInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsClientEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> EventHubsSecretInstance =
            new Lazy<string>(() => ReadEnvironmentVariable(TestConstants.EventHubsSecretEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> AuthorityHostInstance =
            new Lazy<string>(() => ReadOptionalEnvironmentVariable(TestConstants.AuthorityHostEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> ServiceManagementUrlInstance =
            new Lazy<string>(() => ReadOptionalEnvironmentVariable(TestConstants.ServiceManagementUrlEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> ResourceManagerInstance =
            new Lazy<string>(() => ReadOptionalEnvironmentVariable(TestConstants.ResourceManagerEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<string> StorageEndpointSuffixInstance =
           new Lazy<string>(() => ReadOptionalEnvironmentVariable(TestConstants.StorageEndpointSuffixEnvironmentVariableName), LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<EventHubScope.AzureResourceProperties> ActiveEventHubsNamespace =
            new Lazy<EventHubScope.AzureResourceProperties>(CreateNamespace, LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<EventHubScope.AzureResourceProperties> ActiveStorageAccount =
            new Lazy<EventHubScope.AzureResourceProperties>(CreateStorageAccount, LazyThreadSafetyMode.ExecutionAndPublication);

        public static bool ShouldRemoveNamespaceAfterTestRunCompletion => (ActiveEventHubsNamespace.IsValueCreated && ActiveEventHubsNamespace.Value.ShouldRemoveAtCompletion);

        public static bool ShouldRemoveStorageAfterTestRunCompletion => (ActiveStorageAccount.IsValueCreated && ActiveStorageAccount.Value.ShouldRemoveAtCompletion);

        internal static string EventHubsConnectionString => ActiveEventHubsNamespace.Value.ConnectionString;

        internal static string EventHubsNamespace => ActiveEventHubsNamespace.Value.Name;

        internal static string StorageConnectionString => ActiveStorageAccount.Value.ConnectionString;

        internal static string StorageAccountName => ActiveStorageAccount.Value.Name;

        internal static string EventHubsSubscription => EventHubsSubscriptionInstance.Value;

        internal static string EventHubsResourceGroup => EventHubsResourceGroupInstance.Value;

        internal static string EventHubsTenant => EventHubsTenantInstance.Value;

        internal static string EventHubsClient => EventHubsClientInstance.Value;

        internal static string EventHubsSecret => EventHubsSecretInstance.Value;

        internal static string AuthorityHost => AuthorityHostInstance.Value ?? "https://login.microsoftonline.com/";

        internal static string ServiceManagementUrl => ServiceManagementUrlInstance.Value ?? "https://management.core.windows.net/";

        internal static Uri ResourceManager => new Uri(ResourceManagerInstance.Value ?? "https://management.azure.com/");

        internal static string StorageEndpointSuffix => StorageEndpointSuffixInstance.Value ?? "core.windows.net";

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

        internal static async Task SendToPartitionAsync(EventHubClient ehClient, string partitionId, EventDataBatch batch)
        {
            TestUtility.Log($"Starting to send {batch.Count} messages to partition {partitionId}.");
            var partitionSender = ehClient.CreatePartitionSender(partitionId);
            await partitionSender.SendAsync(batch);
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

        public static string BuildEventHubsConnectionString(string eventHubName)
        {
            var connectionString = new EventHubsConnectionStringBuilder(EventHubsConnectionString);

            connectionString.EntityPath = connectionString.EntityPath ?? eventHubName;
            connectionString.OperationTimeout = TestConstants.DefaultOperationTimeout;

            return connectionString.ToString();
        }

        private static string ReadEnvironmentVariable(string variableName)
        {
            var environmentVar = ReadOptionalEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(environmentVar))
            {
                throw new InvalidOperationException($"'{variableName}' environment variable was not found!");
            }

            return environmentVar;
        }

        private static string ReadOptionalEnvironmentVariable(string variableName) => Environment.GetEnvironmentVariable(variableName);

        private static EventHubScope.AzureResourceProperties CreateNamespace()
        {
            var environmentConnectionString = ReadOptionalEnvironmentVariable(TestConstants.EventHubsNamespaceConnectionStringEnvironmentVariable);

            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                var parsed = new EventHubsConnectionStringBuilder(environmentConnectionString);

                return new EventHubScope.AzureResourceProperties
                (
                    parsed.Endpoint.Host.Substring(0, parsed.Endpoint.Host.IndexOf('.')),
                    environmentConnectionString.Replace($";EntityPath={ parsed.EntityPath }", string.Empty),
                    shouldRemoveAtCompletion: false
                );
            }

            return Task
                .Run(async () => await EventHubScope.CreateNamespaceAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        private static EventHubScope.AzureResourceProperties CreateStorageAccount()
        {
            var environmentConnectionString = ReadOptionalEnvironmentVariable(TestConstants.StorageConnectionStringEnvironmentVariable);

            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                return new EventHubScope.AzureResourceProperties
                (
                    TestConstants.StorageConnectionStringEnvironmentVariable,
                    environmentConnectionString,
                    shouldRemoveAtCompletion: false
                );
            }

            return Task
                .Run(async () => await EventHubScope.CreateStorageAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}
