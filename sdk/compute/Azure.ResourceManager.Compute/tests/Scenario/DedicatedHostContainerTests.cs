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
    public class DedicatedHostContainerTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;

        public DedicatedHostContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroup> CreateDedicatedHostGroupAsync(string groupName)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var container = _resourceGroup.GetDedicatedHostGroups();
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHostGroup(DefaultLocation);
            return await container.CreateOrUpdateAsync(groupName, input);
        }

        private async Task<DedicatedHostContainer> GetDedicatedHostContainerAsync()
        {
            var hostGroupName = Recording.GenerateAssetName("testDHG-");
            var group = await CreateDedicatedHostGroupAsync(hostGroupName);
            return group.GetDedicatedHosts();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetDedicatedHostContainerAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            DedicatedHost host = await container.CreateOrUpdateAsync(hostName, input);

            Assert.AreEqual(hostName, host.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetDedicatedHostContainerAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var hostOp = await container.StartCreateOrUpdateAsync(hostName, input);
            DedicatedHost host = await hostOp.WaitForCompletionAsync();

            Assert.AreEqual(hostName, host.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetDedicatedHostContainerAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            DedicatedHost host1 = await container.CreateOrUpdateAsync(hostName, input);
            DedicatedHost host2 = await container.GetAsync(hostName);

            DedicatedHostGroupHelper.AssertHost(host1.Data, host2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetDedicatedHostContainerAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            DedicatedHost host = await container.CreateOrUpdateAsync(hostName, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(hostName));
            Assert.IsFalse(await container.CheckIfExistsAsync(hostName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetDedicatedHostContainerAsync();
            var input = DedicatedHostGroupHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            // We have a quota issue which limits we can only create one dedicate host under on host group
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testHost-"), input);
            int count = 0;
            await foreach (var host in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
