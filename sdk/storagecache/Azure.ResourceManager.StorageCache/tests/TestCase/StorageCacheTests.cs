// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StorageCache.Models;
using Azure.ResourceManager.StorageCache.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.TestCase
{
    public class StorageCacheTests : StorageCacheManagementTestBase
    {
        public StorageCacheTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<StorageCacheCollection> GetStorageCacheCollectionAsync()
        {
            var resourcegroup = await CreateResourceGroupAsync();
            return resourcegroup.GetStorageCaches();
        }
        #region Subnet
        public async Task<ResourceIdentifier> GetsubnetID()
        {
            var resourcegroup = await CreateResourceGroupAsync();
            var vnetName = Recording.GenerateAssetName("virtualnetwork-");
            var subnetName1 = Recording.GenerateAssetName("subnet-");
            var subnetName2 = Recording.GenerateAssetName("subnet-");
            var vnetData = ResourceDataHelpers.GetVietualNetworkData(subnetName1);
            var subnetData = ResourceDataHelpers.GetSubnetData(subnetName2);
            var vnetCollection = resourcegroup.GetVirtualNetworks();
            //var vnetResource = await vnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData);
            //var subnetCollection = vnetResource.Value.GetSubnets();
            //SubnetResource subnetResource = (await subnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, subnetName2, subnetData)).Value;
            ResourceIdentifier subnetID;
            if (Mode == RecordedTestMode.Playback)
            {
                subnetID = SubnetResource.CreateResourceIdentifier(resourcegroup.Id.SubscriptionId, resourcegroup.Id.Name, vnetName, subnetName2);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    var vnetResource = await vnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData);
                    var subnetCollection = vnetResource.Value.GetSubnets();
                    SubnetResource subnetResource = (await subnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, subnetName2, subnetData)).Value;
                    subnetID = subnetResource.Data.Id;
                }
            }
            return subnetID;
        }
        #endregion
        [TestCase]
        public async Task StorageCacheApiTests()
        {
            //0.prepare
            //1.CreateOrUpdate
            var collection = await GetStorageCacheCollectionAsync();
            var name = Recording.GenerateAssetName("storagecachetest-");
            var name2 = Recording.GenerateAssetName("storagecachetest-");
            var name3 = Recording.GenerateAssetName("storagecachetest-");
            var subnetID = await GetsubnetID();
            var input = ResourceDataHelpers.GetStorageCacheData(subnetID);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            StorageCacheResource cache1 = lro.Value;
            Assert.AreEqual(name, cache1.Data.Name);
            //2.Get
            StorageCacheResource cache2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertStorageCacheData(cache1.Data, cache2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            StorageCacheResource cache3 = await cache1.GetAsync();

            ResourceDataHelpers.AssertStorageCacheData(cache1.Data, cache3.Data);
            //6.Delete
            await cache1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
