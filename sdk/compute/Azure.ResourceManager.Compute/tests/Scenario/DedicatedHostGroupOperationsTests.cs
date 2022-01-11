// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        private async Task<DedicatedHostGroup> CreateDedicatedHostGroupAsync(string groupName)
        {
            var collection = (await CreateResourceGroupAsync()).GetDedicatedHostGroups();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            var lro = await collection.CreateOrUpdateAsync(groupName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var groupName = Recording.GenerateAssetName("testDHG-");
            var dedicatedHostGroup = await CreateDedicatedHostGroupAsync(groupName);
            await dedicatedHostGroup.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var groupName = Recording.GenerateAssetName("testDHG-");
            var group1 = await CreateDedicatedHostGroupAsync(groupName);
            DedicatedHostGroup group2 = await group1.GetAsync();

            ResourceDataHelper.AssertGroup(group1.Data, group2.Data);
        }
    }
}
