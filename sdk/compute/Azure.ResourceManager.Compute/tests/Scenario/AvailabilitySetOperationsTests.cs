// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [ClientTestFixture(true, "2022-08-01", "2021-04-01", "2020-06-01", "2022-11-01", "2023-03-01", "2023-07-01", "2023-09-01", "2024-03-01", "2024-11-01")]
    public class AvailabilitySetOperationsTests : ComputeTestBase
    {
        public AvailabilitySetOperationsTests(bool isAsync, string apiVersion)
            : base(isAsync, AvailabilitySetResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        private async Task<AvailabilitySetResource> CreateAvailabilitySetAsync(string setName)
        {
            var collection = (await CreateResourceGroupAsync()).GetAvailabilitySets();
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var availabilitySet = await CreateAvailabilitySetAsync(setName);
            await availabilitySet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var set1 = await CreateAvailabilitySetAsync(setName);
            AvailabilitySetResource set2 = await set1.GetAsync();

            ResourceDataHelper.AssertAvailabilitySet(set1.Data, set2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var set = await CreateAvailabilitySetAsync(setName);
            var updatedPlatformFaultDomainCount = 3;
            var update = new AvailabilitySetPatch()
            {
                PlatformFaultDomainCount = updatedPlatformFaultDomainCount
            };
            AvailabilitySetResource updatedSet = await set.UpdateAsync(update);

            Assert.AreEqual(updatedPlatformFaultDomainCount, updatedSet.Data.PlatformFaultDomainCount);
        }

        [RecordedTest]
        public async Task AvailableLocations()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var set = await CreateAvailabilitySetAsync(setName);
            var locations = await set.GetAvailableLocationsAsync();
            Assert.IsNotEmpty(locations.Value);
        }

        [RecordedTest]
        public async Task PlacementGroupId()
        {
            var asetName = Recording.GenerateAssetName("aset-");
            AvailabilitySetResource aset = await CreateAvailabilitySetAsync(asetName);
            var beforeAdd = aset.Data.ProximityPlacementGroupId;

            ResourceGroupResource rg = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(aset.Id.SubscriptionId, aset.Id.ResourceGroupName));
            var proxGrpName = Recording.GenerateAssetName("proxGrp-");
            ProximityPlacementGroupResource proxGrp = (await rg.GetProximityPlacementGroups().CreateOrUpdateAsync(WaitUntil.Completed, proxGrpName, new ProximityPlacementGroupData(DefaultLocation))).Value;

            AvailabilitySetPatch updateOptions = new AvailabilitySetPatch();
            updateOptions.ProximityPlacementGroupId = proxGrp.Id;
            aset = await aset.UpdateAsync(updateOptions);
            var addIdResult = aset.Data.ProximityPlacementGroupId;

            updateOptions.ProximityPlacementGroupId = null;
            aset = await aset.UpdateAsync(updateOptions);
            var removeIdResult = aset.Data.ProximityPlacementGroupId;

            var asetName2 = Recording.GenerateAssetName("aset-");
            AvailabilitySetResource aset2 = await CreateAvailabilitySetAsync(asetName2);
            var newBeforeAdd = aset2.Data.ProximityPlacementGroup?.Id;

            AvailabilitySetPatch updateOptions2 = new AvailabilitySetPatch();
            updateOptions2.ProximityPlacementGroup = new Resources.Models.WritableSubResource();
            updateOptions2.ProximityPlacementGroup.Id = proxGrp.Id;
            aset2 = await aset2.UpdateAsync(updateOptions2);
            var newAddIdResult = aset2.Data.ProximityPlacementGroup.Id;

            updateOptions2.ProximityPlacementGroup.Id = null;
            aset2 = await aset2.UpdateAsync(updateOptions2);
            var newRemoveIdResult = aset2.Data.ProximityPlacementGroup?.Id;

            updateOptions2.ProximityPlacementGroup.Id = proxGrp.Id;
            aset2 = await aset2.UpdateAsync(updateOptions2);
            Assert.NotNull(aset2.Data.ProximityPlacementGroup.Id);

            updateOptions2.ProximityPlacementGroup = null;
            aset2 = await aset2.UpdateAsync(updateOptions2);
            var newRemoveOuterIdResult = aset2.Data.ProximityPlacementGroup;

            Assert.AreEqual(beforeAdd, newBeforeAdd);
            Assert.AreEqual(addIdResult, newAddIdResult);
            Assert.AreEqual(removeIdResult, newRemoveIdResult);
            //Assert.AreEqual(removeIdResult, newRemoveOuterIdResult);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("aset-");
            var aset = await CreateAvailabilitySetAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            AvailabilitySetResource updated = await aset.SetTagsAsync(tags);

            Assert.AreEqual(tags, updated.Data.Tags);
        }
    }
}
