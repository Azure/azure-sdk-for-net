// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit.Abstractions;

    /// <summary>
    /// Storage cache helper.
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// Target resource group.
        /// </summary>
        private readonly ResourceGroup resourceGroup;

        /// <summary>
        /// Target virtual network.
        /// </summary>
        private readonly VirtualNetwork virtualNetwork;

        /// <summary>
        /// Target subent.
        /// </summary>
        private readonly Subnet subNet;

        /// <summary>
        /// Subscription id.
        /// </summary>
        private readonly string subscriptionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheHelper"/> class.
        /// </summary>
        /// <param name="subscription_id">Subscription id.</param>
        /// <param name="client">Cache management client.</param>
        /// <param name="resourceGroup">Resource group.</param>
        /// <param name="virtualNetwork">Virtual network.</param>
        /// <param name="subnet">Subnet for cache.</param>
        public CacheHelper(string subscription_id, StorageCacheManagementClient client, ResourceGroup resourceGroup, VirtualNetwork virtualNetwork, Subnet subnet)
        {
            this.StoragecacheManagementClient = client;
            this.resourceGroup = resourceGroup;
            this.virtualNetwork = virtualNetwork;
            this.subNet = subnet;
            this.subscriptionId = subscription_id;
        }

        /// <summary>
        /// Gets or Sets the Storage cache management client.
        /// </summary>
        public StorageCacheManagementClient StoragecacheManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the CacheHealth
        /// Gets or sets cache health.
        /// </summary>
        public string CacheHealth { get; set; }

        /// <summary>
        /// Gets or sets the ProvisioningState
        /// Gets or sets cache provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Get cache.
        /// </summary>
        /// <param name="name">Name of the cache.</param>
        /// <returns>Cache object.</returns>
        public Cache Get(string name)
        {
            return this.StoragecacheManagementClient.Caches.Get(this.resourceGroup.Name, name);
        }

        /// <summary>
        /// Create cache.
        /// </summary>
        /// <param name="name">Name of the cache.</param>
        /// <param name="sku">Name of the SKU.</param>
        /// <param name="cacheSize">Size of cache.</param>
        /// <param name="skipGet">Skip get cache before creating it.</param>
        /// <returns>Cache object.</returns>
        public Cache Create(string name, string sku, int cacheSize, bool skipGet = false)
        {
            Cache cache;
            if (!skipGet)
            {
                try
                {
                    cache = this.Get(name);
                }
                catch (CloudErrorException ex)
                {
                    if (ex.Body.Error.Code == "ResourceNotFound")
                    {
                        cache = null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                cache = null;
            }

            if (cache == null)
            {
                var cacheSku = new CacheSku() { Name = sku };
                var subnetUri = $"/subscriptions/{this.subscriptionId}/resourcegroups/{this.resourceGroup.Name}/providers/Microsoft.Network/virtualNetworks/{this.virtualNetwork.Name}/subnets/{this.subNet.Name}";
                var cacheParameters = new Cache() { CacheSizeGB = cacheSize, Location = this.resourceGroup.Location, Sku = cacheSku, Subnet = subnetUri };
                cache = this.StoragecacheManagementClient.Caches.Create(this.resourceGroup.Name, name, cacheParameters);
            }

            return cache;
        }

        /// <summary>
        /// Get cache provisioning state.
        /// </summary>
        /// <param name="name">Name of the cache.</param>
        /// <returns>Cache provisioning state.</returns>
        public string GetCacheProvisioningState(string name)
        {
            try
            {
                var cache = this.Get(name);
                string state = cache.ProvisioningState;
                return state;
            }
            catch (CloudException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get cache health.
        /// </summary>
        /// <param name="name">Name of the cache.</param>
        /// <returns>Cache health.</returns>
        public string GetCacheHealthgState(string name)
        {
            try
            {
                var cache = this.Get(name);
                string state = cache.Health.State;
                return state;
            }
            catch (CloudException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Check both provisioning and health state of the cache.
        /// </summary>
        /// <param name="name">Name of the cache.</param>
        public void CheckCacheState(string name)
        {
            this.WaitForCacheState(this.GetCacheProvisioningState, name, "Succeeded").GetAwaiter().GetResult();
            this.WaitForCacheState(this.GetCacheHealthgState, name, "Healthy").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets storage target.
        /// </summary>
        /// <param name="cacheName">Storage cache name.</param>
        /// <param name="storageTargetName">Storage target name.</param>
        /// <param name="raise">Raise exception.</param>
        /// <returns>Storage target.</returns>
        public StorageTarget GetstorageTarget(string cacheName, string storageTargetName, bool raise = false)
        {
            StorageTarget storageTarget;
            try
            {
               storageTarget = this.StoragecacheManagementClient.StorageTargets.Get(this.resourceGroup.Name, cacheName, storageTargetName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code == "ResourceNotFound")
                {
                    if (raise)
                    {
                        throw;
                    }

                    storageTarget = null;
                }
                else
                {
                    throw;
                }
            }

            return storageTarget;
        }

        /// <summary>
        /// Deletes storage target.
        /// </summary>
        /// <param name="cacheName">Storage cache name.</param>
        /// <param name="storageTargetName">Storage target name.</param>
        /// <param name="testOutputHelper">Test output helper.</param>
        public void DeleteStorageTarget(string cacheName, string storageTargetName, ITestOutputHelper testOutputHelper = null)
        {
            this.StoragecacheManagementClient.StorageTargets.Delete(this.resourceGroup.Name, cacheName, storageTargetName);
            this.WaitForStoragteTargetState(cacheName, storageTargetName, "Deleting", testOutputHelper).GetAwaiter().GetResult();
            this.WaitForStoragteTargetState(cacheName, storageTargetName, "Succeeded", testOutputHelper).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create CLFS storage target parameters.
        /// </summary>
        /// <param name="storageAccountName">Storage account name.</param>
        /// <param name="containerName"> Storage container name.</param>
        /// <param name="namepacePath"> namepace path.</param>
        /// <param name="subscriptionId">Subscription id.</param>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <returns>CLFS storage target parameters.</returns>
        public StorageTarget CreateClfsStorageTargetParameters(
            string storageAccountName,
            string containerName,
            string namepacePath,
            string subscriptionId = null,
            string resourceGroupName = null)
        {
            var subscriptionID = string.IsNullOrEmpty(subscriptionId) ? this.subscriptionId : subscriptionId;
            var resourceGroup = string.IsNullOrEmpty(resourceGroupName) ? this.resourceGroup.Name : resourceGroupName;
            ClfsTarget clfsTarget = new ClfsTarget()
            {
                Target =
                $"/subscriptions/{subscriptionID}/" +
                $"resourceGroups/{resourceGroup}/" +
                $"providers/Microsoft.Storage/storageAccounts/{storageAccountName}/" +
                $"blobServices/default/containers/{containerName}",
            };

            NamespaceJunction namespaceJunction = new NamespaceJunction()
            {
                NamespacePath = namepacePath,
                TargetPath = "/",
            };

            StorageTarget storageTargetParameters = new StorageTarget
            {
                TargetType = "clfs",
                Clfs = clfsTarget,
                Junctions = new List<NamespaceJunction>() { namespaceJunction },
            };

            return storageTargetParameters;
        }

        /// <summary>
        /// Create CLFS storage target.
        /// </summary>
        /// <param name="cacheName">Storage cache name.</param>
        /// <param name="storageTargetName">Storage target name.</param>
        /// <param name="storageTargetParameters">Storage target parameters.</param>
        /// <param name="testOutputHelper">test output helper.</param>
        /// <returns>CLFS storage target.</returns>
        public StorageTarget CreateStorageTarget(
            string cacheName,
            string storageTargetName,
            StorageTarget storageTargetParameters,
            ITestOutputHelper testOutputHelper = null)
        {
            StorageTarget storageTarget;
            storageTarget = this.StoragecacheManagementClient.StorageTargets.Create(
                this.resourceGroup.Name,
                cacheName,
                storageTargetName,
                storageTargetParameters);

            this.WaitForStoragteTargetState(cacheName, storageTargetName, "Succeeded", testOutputHelper).GetAwaiter().GetResult();
            return storageTarget;
        }

        /// <summary>
        /// Blocks until storage target ProvisioningState is as expected or timeout occurs.
        /// </summary>
        /// <param name="cacheName">Name of the cache.</param>
        /// <param name="storageTargetName">Name of the storage target.</param>
        /// <param name="state">Expected sate of the storage target.</param>
        /// <param name="testOutputHelper">Test output helper.</param>
        /// <param name="polling_delay">Delay between cache polling.</param>
        /// <param name="timeout">Timeout for cache polling.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WaitForStoragteTargetState(string cacheName, string storageTargetName, string state, ITestOutputHelper testOutputHelper, int polling_delay = 60, int timeout = -1)
        {
            var waitTask = Task.Run(async () =>
            {
                string currentState = null;
                while (!string.Equals(currentState, state))
                {
                    currentState = this.GetstorageTarget(cacheName, storageTargetName).ProvisioningState;
                    if (testOutputHelper != null)
                    {
                        testOutputHelper.WriteLine($"Waiting for successful deploy of storage target {storageTargetName}, current state is {currentState}");
                    }

                    if (string.Equals(currentState, "Failed"))
                    {
                        throw new Exception($"Storage target {storageTargetName} failed to deploy.");
                    }

                    await Task.Delay(new TimeSpan(0, 0, polling_delay));
                }
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout)))
            {
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// Wait for expected cache state.
        /// </summary>
        /// <param name="operation">Function to call.</param>
        /// <param name="name">Name of the cache.</param>
        /// <param name="state">Expected sate of the cache.</param>
        /// <param name="timeout">Timeout for polling.</param>
        /// <param name="polling_delay">Delay between polling.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WaitForCacheState(Func<string, string> operation, string name, string state, int timeout = -1, int polling_delay = 60)
        {
            var waitTask = Task.Run(async () =>
            {
                string curr_state = null;
                while (!string.Equals(curr_state, state, StringComparison.OrdinalIgnoreCase))
                {
                    curr_state = operation(name);
                    if (operation == this.GetCacheProvisioningState)
                    {
                        this.ProvisioningState = curr_state;
                    }

                    if (operation == this.GetCacheHealthgState)
                    {
                        this.CacheHealth = curr_state;
                    }

                    if (operation == this.GetCacheProvisioningState
                        && string.Equals(curr_state, "Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception(string.Format("Cache {0} failed to deploy.", name));
                    }

                    await Task.Delay(new TimeSpan(0, 0, polling_delay));
                }
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout)))
            {
                throw new TimeoutException();
            }
        }
    }
}