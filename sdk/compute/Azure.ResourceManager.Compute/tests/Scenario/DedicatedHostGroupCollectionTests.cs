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
            var lro = await collection.CreateOrUpdateAsync(groupName, input);
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
            var lro = await collection.CreateOrUpdateAsync(groupName, input);
            DedicatedHostGroup group1 = lro.Value;
            DedicatedHostGroup group2 = await collection.GetAsync(groupName);
            ResourceDataHelper.AssertGroup(group1.Data, group2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(groupName, input);
            var group = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(groupName));
            Assert.IsFalse(await collection.CheckIfExistsAsync(groupName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDedicatedHostGroupCollectionAsync();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testDHG-"), input);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testDHG-"), input);
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
            _ = await collection.CreateOrUpdateAsync(groupName1, input);
            _ = await collection.CreateOrUpdateAsync(groupName2, input);

            DedicatedHostGroup group1 = null, group2 = null;
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
