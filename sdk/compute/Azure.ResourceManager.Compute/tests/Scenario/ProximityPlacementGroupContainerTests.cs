// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ProximityPlacementGroupContainerTests : ComputeTestBase
    {
        private ResourceGroup resourceGroup;
        public ProximityPlacementGroupContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private ProximityPlacementGroupData BasicProximityPlacementGroupData
        {
            get
            {
                return ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            }
        }

        private async Task<ProximityPlacementGroupContainer> GetProximityPlacementGroupContainerAsync()
        {
            resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetProximityPlacementGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetProximityPlacementGroupContainerAsync();
            //var groupName = Recording.GenerateAssetName("testPro-");
            var groupName = Recording.GenerateAssetName("management.azure.com");
            var input = ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            ProximityPlacementGroup group = await container.CreateOrUpdateAsync(groupName, input);
            Assert.AreEqual(groupName, group.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetProximityPlacementGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testPro-");
            var input = ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            var groupOp = await container.StartCreateOrUpdateAsync(groupName, input);
            ProximityPlacementGroup group = await groupOp.WaitForCompletionAsync();
            Assert.AreEqual(groupName, group.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetProximityPlacementGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testPro-");
            var input = ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            ProximityPlacementGroup group1 = await container.CreateOrUpdateAsync(groupName, input);
            ProximityPlacementGroup group2 = await container.GetAsync(groupName);
            ResourceDataHelper.AssertProximityPlacementGroup(group1.Data, group2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetProximityPlacementGroupContainerAsync();
            var groupName = Recording.GenerateAssetName("testPro-");
            var input = ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            ProximityPlacementGroup group = await container.CreateOrUpdateAsync(groupName, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(groupName));
            Assert.IsFalse(await container.CheckIfExistsAsync(groupName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetProximityPlacementGroupContainerAsync();
            var input = ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testPro-"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testPro-"), input);
            int count = 0;
            await foreach (var group in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
