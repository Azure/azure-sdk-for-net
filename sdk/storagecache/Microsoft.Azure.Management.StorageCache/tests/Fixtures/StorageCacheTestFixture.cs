// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Fixtures
{
    using System;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Helpers;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit.Sdk;

    /// <summary>
    /// Defines the <see cref="StorageCacheTestFixture" />.
    /// </summary>
    public class StorageCacheTestFixture : TestBase, IDisposable
    {
        /// <summary>
        /// Defines the SubnetRegex.
        /// </summary>
        private static readonly Regex SubnetRegex = new Regex(@"^(/subscriptions/[-0-9a-f]{36}/resourcegroups/[-\w\._\(\)]+/providers/Microsoft.Network/virtualNetworks/(?<VNetName>[-\w\._\(\)]+))/subnets/(?<SubnetName>[-\w\._\(\)]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Defines the resGroupName.
        /// </summary>
        private readonly string resGroupName;

        /// <summary>
        /// Defines the virNetworkName.
        /// </summary>
        private readonly string virNetworkName;

        /// <summary>
        /// Defines the subnetName.
        /// </summary>
        private readonly string subnetName;

        /// <summary>
        /// Defines the cacheName.
        /// </summary>
        private readonly string cacheName;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCacheTestFixture"/> class.
        /// </summary>
        public StorageCacheTestFixture()
        {
            using (this.Context = new StorageCacheTestContext(this))
            {
                this.Context = new StorageCacheTestContext(this);
                try
                {
                    StorageCacheManagementClient storagecacheMgmtClient = this.Context.GetClient<StorageCacheManagementClient>();
                    storagecacheMgmtClient.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;

                    if (string.IsNullOrEmpty(StorageCacheTestEnvironmentUtilities.ResourceGroupName) &&
                        string.IsNullOrEmpty(StorageCacheTestEnvironmentUtilities.CacheName))
                    {
                        this.resGroupName = StorageCacheTestUtilities.GenerateName(StorageCacheTestEnvironmentUtilities.ResourcePrefix);
                        this.virNetworkName = "VNet-" + this.resGroupName;
                        this.subnetName = "Subnet-" + this.resGroupName;
                        this.cacheName = "Cache-" + this.resGroupName;
                    }
                    else
                    {
                        this.resGroupName = StorageCacheTestEnvironmentUtilities.ResourceGroupName;
                        this.cacheName = StorageCacheTestEnvironmentUtilities.CacheName;
                        this.ResourceGroup = this.Context.GetOrCreateResourceGroup(this.resGroupName, StorageCacheTestEnvironmentUtilities.Location);
                        this.Cache = this.Context.GetCacheIfExists(this.ResourceGroup, this.cacheName);

                        if (this.Cache != null)
                        {
                            Match subnetMatch = SubnetRegex.Match(this.Cache.Subnet);
                            this.virNetworkName = subnetMatch.Groups["VNetName"].Value;
                            this.subnetName = subnetMatch.Groups["SubnetName"].Value;
                        }
                        else
                        {
                            this.virNetworkName = "VNet-" + this.resGroupName;
                            this.subnetName = "Subnet-" + this.resGroupName;
                        }
                    }

                    if (this.ResourceGroup == null)
                    {
                        this.ResourceGroup = this.Context.GetOrCreateResourceGroup(this.resGroupName, StorageCacheTestEnvironmentUtilities.Location);
                    }

                    this.VirtualNetwork = this.Context.GetOrCreateVirtualNetwork(this.ResourceGroup, this.virNetworkName);
                    this.SubNet = this.Context.GetOrCreateSubnet(this.ResourceGroup, this.VirtualNetwork, this.subnetName);

                    this.SubscriptionID = StorageCacheTestEnvironmentUtilities.SubscriptionId();
                    this.CacheHelper = new CacheHelper(this.SubscriptionID, storagecacheMgmtClient, this.ResourceGroup, this.VirtualNetwork, this.SubNet);
                    var sku = StorageCacheTestEnvironmentUtilities.CacheSku;
                    var size = StorageCacheTestEnvironmentUtilities.CacheSize;
                    var int_size = int.Parse(size);
                    if (this.Cache == null)
                    {
                        this.Cache = null;
                        CacheIdentity cacheIdentity;
                        if (StorageCacheTestEnvironmentUtilities.APIVersion == "2019-11-01")
                        {
                            cacheIdentity = new CacheIdentity() { Type = CacheIdentityType.None };
                        }
                        else
                        {
                            cacheIdentity = new CacheIdentity() { Type = CacheIdentityType.SystemAssigned };
                        }

                        this.Cache = this.CacheHelper.Create(this.cacheName, sku, int_size, identity: cacheIdentity);
                        if (HttpMockServer.Mode == HttpRecorderMode.Record)
                        {
                            this.CacheHelper.CheckCacheState(this.cacheName);
                        }
                    }
                }
                catch (Exception)
                {
                    this.Context.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the subscriptionID.
        /// </summary>
        public string SubscriptionID { get; }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        public StorageCacheTestContext Context { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroup.
        /// </summary>
        public ResourceGroup ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the VirtualNetwork.
        /// </summary>
        public VirtualNetwork VirtualNetwork { get; set; }

        /// <summary>
        /// Gets or sets the SubNet.
        /// </summary>
        public Subnet SubNet { get; set; }

        /// <summary>
        /// Gets or sets the Hpc cache.
        /// </summary>
        public CacheHelper CacheHelper { get; set; }

        /// <summary>
        /// Gets or sets the Cache.
        /// </summary>
        public Cache Cache { get; set; }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}