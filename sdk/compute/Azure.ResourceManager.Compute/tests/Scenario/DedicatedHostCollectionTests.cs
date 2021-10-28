// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostCollectionTests : ComputeTestBase
    {
        public DedicatedHostCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroup> CreateDedicatedHostGroupAsync(string groupName)
        {
            var collection = (await CreateResourceGroupAsync()).GetDedicatedHostGroups();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(groupName, input);
            return lro.Value;
        }

        private async Task<DedicatedHostCollection> GetDedicatedHostCollectionAsync()
        {
            var hostGroupName = Recording.GenerateAssetName("testDHG-");
            var group = await CreateDedicatedHostGroupAsync(hostGroupName);
            return group.GetDedicatedHosts();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetDedicatedHostCollectionAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await collection.CreateOrUpdateAsync(hostName, input);
            var host = lro.Value;

            Assert.AreEqual(hostName, host.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetDedicatedHostCollectionAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await collection.CreateOrUpdateAsync(hostName, input);
            DedicatedHost host1 = lro.Value;
            DedicatedHost host2 = await collection.GetAsync(hostName);

            ResourceDataHelper.AssertHost(host1.Data, host2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var collection = await GetDedicatedHostCollectionAsync();
            var hostName = Recording.GenerateAssetName("testHost-");
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await collection.CreateOrUpdateAsync(hostName, input);
            DedicatedHost host = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(hostName));
            Assert.IsFalse(await collection.CheckIfExistsAsync(hostName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDedicatedHostCollectionAsync();
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            // We have a quota issue which limits we can only create one dedicate host under on host group
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testHost-"), input);
            int count = 0;
            await foreach (var host in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
