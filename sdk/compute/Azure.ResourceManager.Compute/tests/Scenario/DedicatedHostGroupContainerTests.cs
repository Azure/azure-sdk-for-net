// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostGroupContainerTests : ComputeTestBase
    {
        public DedicatedHostGroupContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroupContainer> GetDedicatedHostGroupContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDedicatedHostGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetDedicatedHostGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            DedicatedHostGroup group = await container.CreateOrUpdateAsync(groupName, DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation));
            Assert.AreEqual(groupName, group.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetDedicatedHostGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation);
            var groupOp = await container.StartCreateOrUpdateAsync(groupName, input);
            DedicatedHostGroup group = await groupOp.WaitForCompletionAsync();
            Assert.AreEqual(groupName, group.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetDedicatedHostGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation);
            DedicatedHostGroup group1 = await container.CreateOrUpdateAsync(groupName, input);
            DedicatedHostGroup group2 = await container.GetAsync(groupName);
            DedicatedHostGroupHelper.AssertGroup(group1.Data, group2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExistsAsync()
        {
            var container = await GetDedicatedHostGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testDHG-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation);
            DedicatedHostGroup group = await container.CreateOrUpdateAsync(groupName, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(groupName));
            Assert.IsFalse(await container.CheckIfExistsAsync(groupName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetDedicatedHostGroupContainerAsync();
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testDHG-"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testDHG-"), input);
            int count = 0;
            await foreach (var group in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var container = await GetDedicatedHostGroupContainerAsync();
            var groupName1 = Recording.GenerateAssetName("testDHG-");
            var groupName2 = Recording.GenerateAssetName("testDHG-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(groupName1, input);
            _ = await container.CreateOrUpdateAsync(groupName2, input);

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
