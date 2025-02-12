// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostGroupOperationsTests : ComputeTestBase
    {
        public DedicatedHostGroupOperationsTests(bool isAsync)
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

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var groupName = Recording.GenerateAssetName("testDHG-");
            var dedicatedHostGroup = await CreateDedicatedHostGroupAsync(groupName);
            await dedicatedHostGroup.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var groupName = Recording.GenerateAssetName("testDHG-");
            var group1 = await CreateDedicatedHostGroupAsync(groupName);
            DedicatedHostGroupResource group2 = await group1.GetAsync();

            ResourceDataHelper.AssertGroup(group1.Data, group2.Data);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("testDHG-");
            var group = await CreateDedicatedHostGroupAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            DedicatedHostGroupResource updated = await group.SetTagsAsync(tags);

            Assert.AreEqual(tags, updated.Data.Tags);
        }
    }
}
