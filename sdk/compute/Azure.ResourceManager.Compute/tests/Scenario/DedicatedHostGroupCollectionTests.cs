// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostGroupCollectionTests : ComputeTestBase
    {
        public DedicatedHostGroupCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroupCollection> GetDedicatedHostGroupCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDedicatedHostGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, input);
            var group = lro.Value;
            Assert.AreEqual(groupName, group.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, input);
            DedicatedHostGroupResource group1 = lro.Value;
            DedicatedHostGroupResource group2 = await collection.GetAsync(groupName);
            ResourceDataHelper.AssertGroup(group1.Data, group2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, input);
            var group = lro.Value;
            Assert.IsTrue(await collection.ExistsAsync(groupName));
            Assert.IsFalse(await collection.ExistsAsync(groupName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testDHG-"), input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testDHG-"), input);
            int count = 0;
            await foreach (var group in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var groupName1 = Recording.GenerateAssetName("testDHG-");
            var groupName2 = Recording.GenerateAssetName("testDHG-");
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName1, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName2, input);

            DedicatedHostGroupResource group1 = null, group2 = null;
            await foreach (var group in DefaultSubscription.GetDedicatedHostGroupsAsync())
            {
                if (group.Data.Name == groupName1)
                    group1 = group;
                if (group.Data.Name == groupName2)
                    group2 = group;
            }

            Assert.NotNull(group1);
            Assert.NotNull(group2);
        }
    }
}
