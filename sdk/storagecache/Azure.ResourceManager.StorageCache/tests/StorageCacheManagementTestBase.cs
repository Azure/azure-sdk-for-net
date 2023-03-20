// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Compatibility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.StorageCache.Tests
{
    public class StorageCacheManagementTestBase : ManagementRecordedTestBase<StorageCacheManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected ResourceGroupResource DefaultResourceGroup { get; private set; }
        protected Stack<Action> CleanupActions { get; } = new Stack<Action>();

        protected StorageCacheManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected StorageCacheManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            DefaultResourceGroup = await this.CreateResourceGroup(this.DefaultSubscription, "storagecachetestrg", this.DefaultLocation);
        }

        [TearDown]
        public void TearDown()
        {
            while (this.CleanupActions.Count > 0)
            {
                var action = this.CleanupActions.Pop();
                action();
            }
        }

        protected async Task<StorageCacheResource> CreateOrUpdateStorageCache(string name = null, string zone = "1")
        {
            StorageCacheCollection storageCacheCollectionVar = this.DefaultResourceGroup.GetStorageCaches();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testsc");
            this.CreateVirtualNetwork(out string vNetId, out string subNetId);
            StorageCacheData dataVar = new StorageCacheData(this.DefaultLocation)
            {
                CacheSizeGB = 3072,
                SkuName = @"Standard_2G",
                Subnet = new ResourceIdentifier(subNetId),
                Zones =
                {
                    zone,
                }
            };
            ArmOperation<StorageCacheResource> lro = await storageCacheCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                cacheName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            return lro.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork()
        {
            var vnetName = Recording.GenerateAssetName("scTestVNet-");
            var subnetName = Recording.GenerateAssetName("scTestSubnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{this.DefaultResourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                    {
                        { "addressPrefix", "10.0.2.0/24" }
                    }
                }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var lro = await this.Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            return lro.Value;
        }

        protected void CreateVirtualNetwork(out string vNetId, out string subNetId)
        {
            var vNet = this.CreateVirtualNetwork().Result;
            vNetId = vNet.Id;

            var properties = vNet.Data.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            subNetId = subnet["id"] as string;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            return lro.Value;
        }
    }
}
