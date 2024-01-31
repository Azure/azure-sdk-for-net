// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageCache.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests
{
    public class StorageCacheManagementTestBase : ManagementRecordedTestBase<StorageCacheManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
       protected ResourceGroupResource DefaultResourceGroup { get; private set; }
        protected Stack<Action> CleanupActions { get; } = new Stack<Action>();
        protected string amlFSSubnetResourceId;
        protected ResourceGroupResource amlFSResourceGroup;
        protected string amlFSStorageAccountId;

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
            DefaultResourceGroup = await this.DefaultSubscription.GetResourceGroupAsync("rg-amajaistoragecache");
            amlFSResourceGroup = DefaultResourceGroup;
            amlFSStorageAccountId = "/subscriptions/" + DefaultSubscription.Id.SubscriptionId +"/resourceGroups/"+ DefaultResourceGroup.Id.Name +"/providers/Microsoft.Storage/storageAccounts/" + "sdktestingstorageaccount";
            amlFSSubnetResourceId = this.amlFSResourceGroup.Id + "/providers/Microsoft.Network/virtualNetworks/" + "vnet1" + "/subnets/fsSubnet";
        }

        [TearDown]
        public void TearDown()
        {
            // this clean up is needed when running in live mode because at most 4 storagecache can be created in one subscription
            // enable it in live mode
            bool enableCleanup = false;
            while (enableCleanup && this.CleanupActions.Count > 0)
            {
                var action = this.CleanupActions.Pop();
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    // just log and ignore the exception when cleanup
                    Console.WriteLine("Exception thrown when cleanup: " + e.ToString());
                }
            }
        }

        protected async Task<StorageTargetResource> CreateOrUpdateStorageTarget(
            StorageCacheResource cache, string name = null, int verificationDelayInSeconds = 30, string targetIpAddress = "10.0.2.4", bool verifyResult = false)
        {
            StorageTargetCollection storageTargetCollectionVar = cache.GetStorageTargets();
            string storageTargetNameVar = name ?? Recording.GenerateAssetName("storagetarget");
            StorageTargetData dataVar = new StorageTargetData()
            {
                Nfs3 = new Nfs3Target()
                {
                    Target = targetIpAddress,
                    UsageModel = @"READ_ONLY",
                    VerificationDelayInSeconds = verificationDelayInSeconds
                },
                TargetType = StorageTargetType.Nfs3
            };
            ArmOperation<StorageTargetResource> lro = await storageTargetCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                storageTargetName: storageTargetNameVar,
                data: dataVar);
            if (verifyResult)
            {
                this.VerifyStorageTarget(lro.Value, dataVar);
            }
            return lro.Value;
        }

        protected async Task<StorageCacheResource> RetrieveExistingStorageCache(string resourceGroupName, string cacheName)
        {
            ResourceIdentifier storageCacheResourceId = StorageCacheResource.CreateResourceIdentifier(
                this.DefaultSubscription.Id.SubscriptionId,
                resourceGroupName: resourceGroupName,
                cacheName: cacheName);
            var cache = this.Client.GetStorageCacheResource(storageCacheResourceId);
            var targets = cache.GetStorageTargets().GetAllAsync();
            await foreach (var target in targets)
            {
                await target.DeleteAsync(WaitUntil.Completed);
            }
            return cache;
        }

        public void VerifyStorageTarget(StorageTargetResource actual, StorageTargetData expected)
        {
            Assert.AreEqual(actual.Data.TargetType, expected.TargetType);
            Assert.AreEqual(actual.Data.Nfs3.Target, expected.Nfs3.Target);
            Assert.AreEqual(actual.Data.Nfs3.UsageModel, expected.Nfs3.UsageModel);
            Assert.AreEqual(actual.Data.Nfs3.VerificationDelayInSeconds, expected.Nfs3.VerificationDelayInSeconds);
        }

        protected async Task<StorageCacheResource> CreateOrUpdateStorageCache(string name = null, string zone = "1", bool verifyResult = false)
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
            if (verifyResult)
            {
                this.VerifyStorageCache(lro.Value, dataVar);
            }
            return lro.Value;
        }

        protected void VerifyStorageCache(StorageCacheResource actual, StorageCacheData expected)
        {
            Assert.AreEqual(actual.Data.CacheSizeGB, expected.CacheSizeGB);
            Assert.AreEqual(actual.Data.SkuName, expected.SkuName);
            Assert.AreEqual(actual.Data.Subnet, expected.Subnet);
            Assert.AreEqual(actual.Data.Zones.Count, expected.Zones.Count);
            for (int i = 0; i < actual.Data.Zones.Count; i++)
                Assert.AreEqual(actual.Data.Zones[i], expected.Zones[i]);
        }

        protected async Task<AmlFileSystemResource> CreateOrUpdateAmlFilesystem(string name = null, string zone = "1", bool verifyResult = false)
        {
            AmlFileSystemCollection amlFSCollectionVar = this.amlFSResourceGroup.GetAmlFileSystems();
            string amlFSName = name ?? Recording.GenerateAssetName("testamlFS");
            string subnetId = this.amlFSResourceGroup.Id + "/providers/Microsoft.Network/virtualNetworks/" + TestEnvironment.vnetName +"/subnets/fsSubnet";
            string amlFSHsmContainer = amlFSStorageAccountId + "/blobServices/default/containers/importcontainer";
            string amlFSHsmLoggingContainer = amlFSStorageAccountId + "/blobServices/default/containers/loggingcontainer";
            AmlFileSystemData dataVar = new AmlFileSystemData(this.DefaultLocation)
            {
                Sku = new StorageCacheSkuName
                {
                    Name = @"AMLFS-Durable-Premium-125"
                },
                StorageCapacityTiB = (float?)16.0,
                FilesystemSubnet = subnetId,
                MaintenanceWindow = new AmlFileSystemPropertiesMaintenanceWindow
                {
                    DayOfWeek = MaintenanceDayOfWeekType.Monday,
                    TimeOfDayUTC = @"23:25"
                },
                Hsm = new AmlFileSystemPropertiesHsm
                {
                    Settings = new AmlFileSystemHsmSettings(amlFSHsmContainer, amlFSHsmLoggingContainer)
                },
                Zones =
                {
                    zone,
                }
            };
            ArmOperation<AmlFileSystemResource> lro = await amlFSCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                amlFileSystemName: amlFSName,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifyAmlFileSystem(lro.Value, dataVar);
            }
            return lro.Value;
        }

        protected void VerifyAmlFileSystem(AmlFileSystemResource actual, AmlFileSystemData expected)
        {
            Assert.AreEqual(actual.Data.Sku.Name, expected.Sku.Name);
            Assert.AreEqual(actual.Data.StorageCapacityTiB, expected.StorageCapacityTiB);
            Assert.AreEqual(actual.Data.FilesystemSubnet, expected.FilesystemSubnet);
            Assert.AreEqual(actual.Data.Zones.Count, expected.Zones.Count);
            Assert.AreEqual(actual.Data.MaintenanceWindow.DayOfWeek, expected.MaintenanceWindow.DayOfWeek);
            Assert.AreEqual(actual.Data.MaintenanceWindow.TimeOfDayUTC, expected.MaintenanceWindow.TimeOfDayUTC);
            Assert.AreEqual(actual.Data.Hsm.Settings.Container, expected.Hsm.Settings.Container);
            Assert.AreEqual(actual.Data.Hsm.Settings.LoggingContainer, expected.Hsm.Settings.LoggingContainer);
            for (int i = 0; i < actual.Data.Zones.Count; i++)
                Assert.AreEqual(actual.Data.Zones[i], expected.Zones[i]);
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
                        { "addressPrefix", "10.0.0.0/16" }
                    }
                }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(this.DefaultLocation)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var lro = await this.Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            // not add cleanup for the network which may trigger exception because the VM is not deleted yet because of timing issue
            // it should be fine to just leave it there which will be cleanup by TTL anyway later
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
            // seems the TestBase will do something more against the ResourceGroup later. Adding cleanup would trigger exception randomly
            // when running multiple test cases at one time. It should be fine just leave it there which will be handled by TTL later
            return lro.Value;
        }
    }
}
