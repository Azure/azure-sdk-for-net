// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostOperationsTests : ComputeTestBase
    {
        public DedicatedHostOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroupResource> CreateDedicatedHostGroupAsync(string groupName)
        {
            var collection = (await CreateResourceGroupAsync()).GetDedicatedHostGroups();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, input);
            return lro.Value;
        }

        private async Task<DedicatedHostResource> CreateDedicatedHostAsync(string hostName)
        {
            var hostGroupName = Recording.GenerateAssetName("testDHG-");
            var collection = (await CreateDedicatedHostGroupAsync(hostGroupName)).GetDedicatedHosts();
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            var dedicatedHost = await CreateDedicatedHostAsync(hostName);
            await dedicatedHost.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            var host1 = await CreateDedicatedHostAsync(hostName);
            DedicatedHostResource host2 = await host1.GetAsync();

            ResourceDataHelper.AssertHost(host1.Data, host2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            DedicatedHostResource dedicatedHost = await CreateDedicatedHostAsync(hostName);
            var updatedAutoReplaceOnFailure = false;
            var update = new DedicatedHostPatch()
            {
                AutoReplaceOnFailure = updatedAutoReplaceOnFailure
            };
            var lro = await dedicatedHost.UpdateAsync(WaitUntil.Completed, update);
            DedicatedHostResource updatedHost = lro.Value;

            Assert.AreEqual(updatedAutoReplaceOnFailure, updatedHost.Data.AutoReplaceOnFailure);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("testHost-");
            var host = await CreateDedicatedHostAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            DedicatedHostResource updated = await host.SetTagsAsync(tags);

            Assert.AreEqual(tags, updated.Data.Tags);
        }
    }
}
