// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit.Abstractions;
    using Xunit.Sdk;

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
        /// <param name="client">Object representing a cache management client.</param>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="virtualNetwork">Object representing a virtual network.</param>
        /// <param name="subnet">Object representing a subnet for cache.</param>
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
        /// <param name="identity">Cache identity type.</param>
        /// <param name="keyVaultResourceId">Describes a resource Id to source Key vault.</param>
        /// <param name="encryptionKeyURL">The URL referencing a key encryption key in key vault.</param>
        /// <param name="skipGet">Skip get cache before creating it.</param>
        /// <returns>Cache object.</returns>
        public Cache Create(string name, string sku, int cacheSize, CacheIdentity identity, KeyVaultKeyReferenceSourceVault keyVaultResourceId = null, string encryptionKeyURL = null, bool skipGet = false)
        {
            Cache cache;
            CacheEncryptionSettings cacheEncryptionSettings;
            KeyVaultKeyReference keyVaultKeyReference;
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
                if (encryptionKeyURL is null || keyVaultResourceId is null)
                {
                    keyVaultKeyReference = new KeyVaultKeyReference() { };
                    cacheEncryptionSettings = new CacheEncryptionSettings() { };
                }
                else
                {
                    keyVaultKeyReference = new KeyVaultKeyReference()
                    {
                        KeyUrl = encryptionKeyURL,
                        SourceVault = keyVaultResourceId,
                    };
                    cacheEncryptionSettings = new CacheEncryptionSettings()
                    {
                        KeyEncryptionKey = keyVaultKeyReference,
                    };
                }


                var cacheParameters = new Cache()
                {
                    CacheSizeGB = cacheSize,
                    Location = this.resourceGroup.Location,
                    Sku = cacheSku,
                    Subnet = subnetUri,
                    Identity = identity,
                    EncryptionSettings = cacheEncryptionSettings,
                };
                cache = this.StoragecacheManagementClient.Caches.CreateOrUpdate(this.resourceGroup.Name, name, cacheParameters);
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
        public string GetCacheHealthState(string name)
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
            this.WaitForCacheState(this.GetCacheHealthState, name, "Healthy").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets storage target.
        /// </summary>
        /// <param name="cacheName">Storage cache name.</param>
        /// <param name="storageTargetName">Storage target name.</param>
        /// <param name="raise">Raise exception.</param>
        /// <returns>Storage target.</returns>
        public StorageTarget GetStorageTarget(string cacheName, string storageTargetName, bool raise = false)
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
        /// <param name="testOutputHelper">Object representing a ITestOutputHelper.</param>
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
        /// <param name="namespacePath"> namepace path.</param>
        /// <param name="subscriptionId">Subscription id.</param>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <returns>CLFS storage target parameters.</returns>
        public StorageTarget CreateClfsStorageTargetParameters(
            string storageAccountName,
            string containerName,
            string namespacePath,
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
                NamespacePath = namespacePath,
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
        /// <param name="storageTargetParameters">Object representing a Storage target parameters.</param>
        /// <param name="testOutputHelper">Object representing a ITestOutputHelper.</param>
        /// <param name="waitForStorageTarget">Wait for storage target to deploy.</param>
        /// <param name="maxRequestTries">Max retries.</param>
        /// <param name="delayBetweenTries">Delay between each retries in seconds.</param>
        /// <returns>CLFS storage target.</returns>
        public StorageTarget CreateStorageTarget(
            string cacheName,
            string storageTargetName,
            StorageTarget storageTargetParameters,
            ITestOutputHelper testOutputHelper = null,
            bool waitForStorageTarget = true,
            int maxRequestTries = 25,
            int delayBetweenTries = 90)
        {
            StorageTarget storageTarget;
            storageTarget = this.Retry(
                () =>
            this.StoragecacheManagementClient.StorageTargets.CreateOrUpdate(
                this.resourceGroup.Name,
                cacheName,
                storageTargetName,
                storageTargetParameters),
                maxRequestTries,
                delayBetweenTries,
                "hasn't sufficient permissions",
                testOutputHelper);

            if (waitForStorageTarget)
            {
                this.WaitForStoragteTargetState(cacheName, storageTargetName, "Succeeded", testOutputHelper).GetAwaiter().GetResult();
            }

            return storageTarget;
        }

        /// <summary>
        /// Blocks until storage target ProvisioningState is as expected or timeout occurs.
        /// </summary>
        /// <param name="cacheName">Name of the cache.</param>
        /// <param name="storageTargetName">Name of the storage target.</param>
        /// <param name="state">Expected sate of the storage target.</param>
        /// <param name="testOutputHelper">Object representing a Storage target parameters.</param>
        /// <param name="polling_delay">Delay between cache polling.</param>
        /// <param name="timeout">Timeout for cache polling.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WaitForStoragteTargetState(
            string cacheName,
            string storageTargetName,
            string state,
            ITestOutputHelper testOutputHelper = null,
            int polling_delay = 60,
            int timeout = 900)
        {
            var waitTask = Task.Run(async () =>
            {
                string currentState = null;
                while (!string.Equals(currentState, state))
                {
                    currentState = this.GetStorageTarget(cacheName, storageTargetName).ProvisioningState;
                    if (testOutputHelper != null)
                    {
                        testOutputHelper.WriteLine($"Waiting for successful deploy of storage target {storageTargetName}, current state is {currentState}");
                    }

                    if (string.Equals(currentState, "Failed"))
                    {
                        throw new Exception($"Storage target {storageTargetName} failed to deploy.");
                    }

                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        await Task.Delay(new TimeSpan(0, 0, polling_delay));
                    }
                }
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(new TimeSpan(0, 0, timeout))))
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
        public async Task WaitForCacheState(
            Func<string, string> operation,
            string name,
            string state,
            int timeout = 1800,
            int polling_delay = 120)
        {
            var waitTask = Task.Run(async () =>
            {
                string currentState = null;
                while (!string.Equals(currentState, state))
                {
                    currentState = operation(name);
                    if (operation == this.GetCacheProvisioningState
                        && string.Equals(currentState, "Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception(string.Format("Cache {0} failed to deploy.", name));
                    }

                    await Task.Delay(new TimeSpan(0, 0, polling_delay));
                }

                if (operation == this.GetCacheProvisioningState)
                {
                    this.ProvisioningState = currentState;
                }

                if (operation == this.GetCacheHealthState)
                {
                    this.CacheHealth = currentState;
                }
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(new TimeSpan(0, 0, timeout))))
            {
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// Retry on CloudErrorException with particular message.
        /// </summary>
        /// <typeparam name="TRet">Method return type.</typeparam>
        /// <param name="action">Method to execute.</param>
        /// <param name="maxRequestTries">Max retries.</param>
        /// <param name="delayBetweenTries">Delay between each retries in seconds.</param>
        /// <param name="exceptionMessage">Exception message to verify.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <returns>Whatever action parameter returns.</returns>
        public TRet Retry<TRet>(
            Func<TRet> action,
            int maxRequestTries,
            int delayBetweenTries,
            string exceptionMessage,
            ITestOutputHelper testOutputHelper = null)
        {
            var remainingTries = maxRequestTries;
            var exceptions = new List<Exception>();

            do
            {
                --remainingTries;
                try
                {
                    return action();
                }
                catch (CloudErrorException e)
                {
                    if (e.Body.Error.Message.Contains(exceptionMessage))
                    {
                        if (remainingTries > 0)
                        {
                            if (testOutputHelper != null)
                            {
                                testOutputHelper.WriteLine(e.Body.Error.Message);
                                testOutputHelper.WriteLine($"Sleeping for {delayBetweenTries} time before retrying.");
                            }

                            TestUtilities.Wait(new TimeSpan(0, 0, delayBetweenTries));
                        }

                        exceptions.Add(e);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            while (remainingTries > 0);
            throw this.AggregatedExceptions(exceptions);
        }

        /// <summary>
        /// An exception handler which returns an unique or aggregated exception.
        /// </summary>
        /// <param name="exceptions">List of an exceptions.</param>
        /// <returns>an aggregate or unique exception.</returns>
        private Exception AggregatedExceptions(List<Exception> exceptions)
        {
            var uniqueExceptions = exceptions.Distinct(new ExceptionEqualityComparer());

            // If all the requests failed with the same exception,
            // just return one exception to represent them all.
            if (uniqueExceptions.Count() == 1)
            {
                return uniqueExceptions.First();
            }

            // If all the requests failed but for different reasons, return an AggregateException
            // with all the root-cause exceptions.
            return new AggregateException("There is a problem with the service.", uniqueExceptions);
        }

        /// <summary>
        /// Used to aggregate exceptions that occur on request retries.
        /// </summary>
        private class ExceptionEqualityComparer : IEqualityComparer<Exception>
        {
            public bool Equals(Exception e1, Exception e2)
            {
                if (e2 == null && e1 == null)
                {
                    return true;
                }
                else if (e1 == null | e2 == null)
                {
                    return false;
                }
                else if (e1.GetType().Name.Equals(e2.GetType().Name) && e1.Message.Equals(e2.Message))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(Exception e)
            {
                return (e.GetType().Name + e.Message).GetHashCode();
            }
        }
    }
}