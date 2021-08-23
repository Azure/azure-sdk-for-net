// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ProximityPlacementGroupOperationTests : ComputeTestBase
    {
       public ProximityPlacementGroupOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<ProximityPlacementGroup> CreateProximityPlacementGroupAsync(string groupName)
        {
            var container = (await CreateResourceGroupAsync()).GetProximityPlacementGroups();
            var input = ResourceDataHelper.GetBasicProximityPlacementGroupData(DefaultLocation);
            var Iro_group =  await container.CreateOrUpdateAsync(groupName, input);
            ProximityPlacementGroup group = Iro_group.Value;
            return group;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var groupName = Recording.GenerateAssetName("testPro-");
            var dedicatedHostGroup = await CreateProximityPlacementGroupAsync(groupName);
            await dedicatedHostGroup.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var groupName = Recording.GenerateAssetName("testPro-");
            var group1 = await CreateProximityPlacementGroupAsync(groupName);
            ProximityPlacementGroup group2 = await group1.GetAsync();

            ResourceDataHelper.AssertProximityPlacementGroup(group1.Data, group2.Data);
        }
    }
}
