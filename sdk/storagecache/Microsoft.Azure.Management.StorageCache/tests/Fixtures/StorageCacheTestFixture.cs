// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Helpers;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit.Abstractions;
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
        /// Log messages for the fixture to this.
        /// </summary>
        public List<string> notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCacheTestFixture"/> class.
        /// </summary>
        public StorageCacheTestFixture()
        {
            notes = new List<string>();
            notes.Add("Starting StorageCacheTestFixture");

            using (this.Context = new StorageCacheTestContext(this))
            {
                notes.Add("StorageCacheTestFixture Using New Context");
                notes.Add(Context.notes.ToString());

                this.Context = new StorageCacheTestContext(this);
                try
                {
                    notes.Add("StorageCacheTestFixture Using Second New Context");
                    notes.Add(Context.notes.ToString());

                    notes.Add("StorageCacheTestFixture After Second StorageCacheTestContext");

                    StorageCacheManagementClient storagecacheMgmtClient = this.Context.GetClient<StorageCacheManagementClient>();
                    storagecacheMgmtClient.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;

                    notes.Add("StorageCacheTestFixture After GetClient.");
                    notes.Add(Context.notes.ToString());

                    if (string.IsNullOrEmpty(StorageCacheTestEnvironmentUtilities.ResourceGroupName) &&
                        string.IsNullOrEmpty(StorageCacheTestEnvironmentUtilities.CacheName))
                    {
                        this.resGroupName = StorageCacheTestUtilities.GenerateName(StorageCacheTestEnvironmentUtilities.ResourcePrefix);
                        this.virNetworkName = "VNet-" + this.resGroupName;
                        this.subnetName = "Subnet-" + this.resGroupName;
                        this.cacheName = "Cache-" + this.resGroupName;

                        notes.Add($"StorageCacheTestFixture ResourceGroupName && CacheName is null or empty, using Group Name {resGroupName}, Vnet {virNetworkName}, Subnet {subnetName}, Cache {cacheName}.");
                    }
                    else
                    {
                        this.resGroupName = StorageCacheTestEnvironmentUtilities.ResourceGroupName;
                        this.cacheName = StorageCacheTestEnvironmentUtilities.CacheName;
                        this.ResourceGroup = this.Context.GetOrCreateResourceGroup(this.resGroupName, StorageCacheTestEnvironmentUtilities.Location);
                        this.Cache = this.Context.GetCacheIfExists(this.ResourceGroup, this.cacheName);

                        notes.Add($"StorageCacheTestFixture ResourceGroupName && CacheName is not null or empty, using Group Name {resGroupName}, Cache {cacheName}.");
                        notes.Add("SCTFixture Get cache if exists.");
                        notes.Add(Context.notes.ToString());

                        if (this.Cache != null)
                        {
                            Match subnetMatch = SubnetRegex.Match(this.Cache.Subnet);
                            this.virNetworkName = subnetMatch.Groups["VNetName"].Value;
                            this.subnetName = subnetMatch.Groups["SubnetName"].Value;
                            notes.Add($"SCTFixture Cache is not null using vnet {virNetworkName} and subnet {subnetName}");
                        }
                        else
                        {
                            this.virNetworkName = "VNet-" + this.resGroupName;
                            this.subnetName = "Subnet-" + this.resGroupName;
                            notes.Add($"SCTFixture Cache is null using vnet {virNetworkName} and subnet {subnetName}");
                        }
                    }

                    if (this.ResourceGroup == null)
                    {
                        notes.Add("SCTFixture ResourceGroup is null.  Get or create resource group");
                        this.ResourceGroup = this.Context.GetOrCreateResourceGroup(this.resGroupName, StorageCacheTestEnvironmentUtilities.Location);
                        notes.Add(Context.notes.ToString());
                    }

                    this.VirtualNetwork = this.Context.GetOrCreateVirtualNetwork(this.ResourceGroup, this.virNetworkName);
                    this.SubNet = this.Context.GetOrCreateSubnet(this.ResourceGroup, this.VirtualNetwork, this.subnetName);

                    notes.Add("SCTFixture Get or create vnet and subnet.");
                    notes.Add(Context.notes.ToString());

                    this.SubscriptionID = StorageCacheTestEnvironmentUtilities.SubscriptionId();
                    notes.Add($"SCTFixture Using subscription id {SubscriptionID.ToString()}.");

                    this.CacheHelper = new CacheHelper(this.SubscriptionID, storagecacheMgmtClient, this.ResourceGroup, this.VirtualNetwork, this.SubNet);

                    notes.Add($"SCTFixture New CacheHelper");
                    notes.Add(CacheHelper.notes.ToString());

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

                        CacheNetworkSettings cacheNetworkSettings = new CacheNetworkSettings();
                        cacheNetworkSettings.NtpServer = "time.windows.com";
                        cacheNetworkSettings.Mtu = 1500;

                        // Build up cache security settings.
                        CacheSecuritySettings cacheSecuritySettings = new CacheSecuritySettings();

                        NfsAccessPolicy nfsAccessPolicy = new NfsAccessPolicy();
                        nfsAccessPolicy.Name = "testAccessPolicy";

                        NfsAccessRule nfsAccessRule = new NfsAccessRule
                        {
                            Access = "rw",
                            Scope = "default",
                            Suid = false,
                            SubmountAccess = true,
                            RootSquash = false
                        };

                        List<NfsAccessRule> accessRules = new List<NfsAccessRule>();
                        accessRules.Add(nfsAccessRule);
                        nfsAccessPolicy.AccessRules = accessRules;

                        List<NfsAccessPolicy> accessPolicies = new List<NfsAccessPolicy>();
                        accessPolicies.Add(nfsAccessPolicy);
                        cacheSecuritySettings.AccessPolicies = accessPolicies;

                        notes.Add("SCTFixture CacheHelper Create Cache");
                        this.Cache = this.CacheHelper.Create(this.cacheName, sku, int_size, identity: cacheIdentity, networkSettings: cacheNetworkSettings);
                        if (HttpMockServer.Mode == HttpRecorderMode.Record)
                        {
                            notes.Add("SCTFixture CacheHelper Create Cache Record Mode Check Cache State");
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

            notes.Add("SCTFixture End");
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