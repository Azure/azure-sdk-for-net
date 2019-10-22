// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests.Infrastructure
{
    /// <summary>
    ///  Provides a dynamically created Azure blob container instance which exists only in the context
    ///  of the scope; disposal removes the instance.
    /// </summary>
    ///
    /// <seealso cref="System.IAsyncDisposable" />
    ///
    public sealed class StorageScope : IAsyncDisposable
    {
        /// <summary>The set of characters considered invalid in a blob container name.</summary>
        private static readonly Regex InvalidContainerCharactersExpression = new Regex("[^a-z0-9]", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>The manager for common live test resource operations.</summary>
        private static readonly LiveResourceManager ResourceManager = new LiveResourceManager();

        /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
        private bool _disposed = false;

        /// <summary>
        ///  The name of the blob storage container that was created.
        /// </summary>
        ///
        public string ContainerName { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="StorageScope"/> class.
        /// </summary>
        ///
        /// <param name="containerName">The name of the blob container that was created.</param>
        ///
        private StorageScope(string containerName)
        {
            ContainerName = containerName;
        }

        /// <summary>
        ///   Performs the tasks needed to remove the dynamically created blob container.
        /// </summary>
        ///
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var storageAccount = StorageTestEnvironment.StorageAccountName;
            var token = await ResourceManager.AquireManagementTokenAsync();
            var client = new StorageManagementClient(new TokenCredentials(token)) { SubscriptionId = TestEnvironment.EventHubsSubscription };

            try
            {
                await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.BlobContainers.DeleteAsync(resourceGroup, storageAccount, ContainerName));
            }
            catch
            {
                // This should not be considered a critical failure that results in a test failure.  Due
                // to ARM being temperamental, some management operations may be rejected.  Throwing here
                // does not help to ensure resource cleanup only flags the test itself as a failure.
                //
                // If a blob container fails to be deleted, removing of the associated storage account at the end
                // of the test run will also remove the orphan.
            }
            finally
            {
                client?.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        ///   Performs the tasks needed to create a new blob container instance with a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The <see cref="StorageScope" /> in which the test should be executed.</returns>
        ///
        public static async Task<StorageScope> CreateAsync([CallerMemberName] string caller = "")
        {
            caller = InvalidContainerCharactersExpression.Replace(caller.ToLowerInvariant(), string.Empty);
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var storageAccount = StorageTestEnvironment.StorageAccountName;
            var token = await ResourceManager.AquireManagementTokenAsync();

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            using (var client = new StorageManagementClient(new TokenCredentials(token)) { SubscriptionId = TestEnvironment.EventHubsSubscription })
            {
                BlobContainer container = await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.BlobContainers.CreateAsync(resourceGroup, storageAccount, CreateName(), PublicAccess.None));
                return new StorageScope(container.Name);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hubs namespace within a resource group, intended to be used as
        ///   an ephemeral container for the Event Hub instances used in a given test run.
        /// </summary>
        ///
        /// <returns>The key attributes for identifying and accessing a dynamically created Event Hubs namespace.</returns>
        ///
        public static async Task<StorageProperties> CreateStorageAccountAsync()
        {
            var subscription = TestEnvironment.EventHubsSubscription;
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var token = await ResourceManager.AquireManagementTokenAsync();

            static string CreateName() => $"neteventhubs{ Guid.NewGuid().ToString("N").Substring(0, 12) }";

            using (var client = new StorageManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                var location = await ResourceManager.QueryResourceGroupLocationAsync(token, resourceGroup, subscription);
                var sku = new Sku(SkuName.StandardLRS, SkuTier.Standard);
                var parameters = new StorageAccountCreateParameters(sku, Kind.BlobStorage, location: location, tags: ResourceManager.GenerateTags(), accessTier: AccessTier.Hot);
                StorageAccount storageAccount = await ResourceManager.CreateRetryPolicy<StorageAccount>().ExecuteAsync(() => client.StorageAccounts.CreateAsync(resourceGroup, CreateName(), parameters));

                StorageAccountListKeysResult storageKeys = await ResourceManager.CreateRetryPolicy<StorageAccountListKeysResult>().ExecuteAsync(() => client.StorageAccounts.ListKeysAsync(resourceGroup, storageAccount.Name));
                return new StorageProperties(storageAccount.Name, $"DefaultEndpointsProtocol=https;AccountName={ storageAccount.Name };AccountKey={ storageKeys.Keys[0].Value };EndpointSuffix=core.windows.net");
            }
        }

        /// <summary>
        ///   Performs the tasks needed to remove an ephemeral Azure storage account used as a container for checkpoint instances
        ///   for a specific test run.
        /// </summary>
        ///
        /// <param name="accountName">The name of the storage account to delete.</param>
        ///
        public static async Task DeleteStorageAccountAsync(string accountName)
        {
            var subscription = TestEnvironment.EventHubsSubscription;
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var token = await ResourceManager.AquireManagementTokenAsync();

            using (var client = new StorageManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.StorageAccounts.DeleteAsync(resourceGroup, accountName));
            }
        }

        /// <summary>
        ///   The key attributes for identifying and accessing a dynamically created Azure storage account,
        ///   intended to serve as an ephemeral container for the checkpoints created during a test run.
        /// </summary>
        ///
        public struct StorageProperties
        {
            /// <summary>The name of the Azure storage account that was dynamically created.</summary>
            public readonly string Name;

            /// <summary>The connection string to use for accessing the dynamically created namespace.</summary>
            public readonly string ConnectionString;

            /// <summary>
            ///   Initializes a new instance of the <see cref="StorageProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the storage account.</param>
            /// <param name="connectionString">The connection string to use for accessing the namespace.</param>
            ///
            internal StorageProperties(string name,
                                       string connectionString)
            {
                Name = name;
                ConnectionString = connectionString;
            }
        }
    }
}
