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
    public class AvailabilitySetOperationsTests : ComputeTestBase
    {
        public AvailabilitySetOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AvailabilitySet> CreateAvailabilitySetAsync(string setName)
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
            AvailabilitySet set2 = await set1.GetAsync();

            ResourceDataHelper.AssertAvailabilitySet(set1.Data, set2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var set = await CreateAvailabilitySetAsync(setName);
            var updatedPlatformFaultDomainCount = 3;
            var update = new PatchableAvailabilitySetData()
            {
                PlatformFaultDomainCount = updatedPlatformFaultDomainCount
            };
            AvailabilitySet updatedSet = await set.UpdateAsync(update);

            Assert.AreEqual(updatedPlatformFaultDomainCount, updatedSet.Data.PlatformFaultDomainCount);
        }

        [RecordedTest]
        public async Task AvailableLocations()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var set = await CreateAvailabilitySetAsync(setName);
            var locations = await set.GetAvailableLocationsAsync();
            Assert.IsNotEmpty(locations);
        }

        [RecordedTest]
        public async Task PlacementGroupId()
        {
            var asetName = Recording.GenerateAssetName("aset-");
            AvailabilitySet aset = await CreateAvailabilitySetAsync(asetName);
            var beforeAdd = aset.Data.ProximityPlacementGroupId;

            ResourceGroup rg = Client.GetResourceGroup(ResourceGroup.CreateResourceIdentifier(aset.Id.SubscriptionId, aset.Id.ResourceGroupName));
            var proxGrpName = Recording.GenerateAssetName("proxGrp-");
            ProximityPlacementGroup proxGrp = (await rg.GetProximityPlacementGroups().CreateOrUpdateAsync(WaitUntil.Completed, proxGrpName, new ProximityPlacementGroupData(DefaultLocation))).Value;

            PatchableAvailabilitySetData updateOptions = new PatchableAvailabilitySetData();
            updateOptions.ProximityPlacementGroupId = proxGrp.Id;
            aset = await aset.UpdateAsync(updateOptions);
            var addIdResult = aset.Data.ProximityPlacementGroupId;

            updateOptions.ProximityPlacementGroupId = null;
            aset = await aset.UpdateAsync(updateOptions);
            var removeIdResult = aset.Data.ProximityPlacementGroupId;

            var asetName2 = Recording.GenerateAssetName("aset-");
            AvailabilitySet aset2 = await CreateAvailabilitySetAsync(asetName2);
            var newBeforeAdd = aset2.Data.ProximityPlacementGroup?.Id;

            PatchableAvailabilitySetData updateOptions2 = new PatchableAvailabilitySetData();
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
            var newRemoveOuterIdResult = aset2.Data.ProximityPlacementGroup?.Id;

            Assert.AreEqual(beforeAdd, newBeforeAdd);
            Assert.AreEqual(addIdResult, newAddIdResult);
            Assert.AreEqual(removeIdResult, newRemoveIdResult);
            Assert.AreEqual(removeIdResult, newRemoveOuterIdResult);
        }
    }
}
