// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostContainerTests : ComputeTestBase
    {
        public DedicatedHostContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroup> CreateDedicatedHostGroupAsync(string groupName)
        {
            var container = (await CreateResourceGroupAsync()).GetDedicatedHostGroups();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await container.CreateOrUpdateAsync(groupName, input);
            return lro.Value;
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
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await container.CreateOrUpdateAsync(hostName, input);
            var host = lro.Value;

            Assert.AreEqual(hostName, host.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetDedicatedHostContainerAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await container.CreateOrUpdateAsync(hostName, input);
            DedicatedHost host1 = lro.Value;
            DedicatedHost host2 = await container.GetAsync(hostName);

            ResourceDataHelper.AssertHost(host1.Data, host2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetDedicatedHostContainerAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await container.CreateOrUpdateAsync(hostName, input);
            DedicatedHost host = lro.Value;
            Assert.IsTrue(await container.CheckIfExistsAsync(hostName));
            Assert.IsFalse(await container.CheckIfExistsAsync(hostName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetDedicatedHostContainerAsync();
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
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
