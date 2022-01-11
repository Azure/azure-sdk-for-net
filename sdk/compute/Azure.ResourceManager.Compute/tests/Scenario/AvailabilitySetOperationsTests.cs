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
            var lro = await collection.CreateOrUpdateAsync(setName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var availabilitySet = await CreateAvailabilitySetAsync(setName);
            await availabilitySet.DeleteAsync();
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
            var update = new AvailabilitySetUpdate()
            {
                PlatformFaultDomainCount = updatedPlatformFaultDomainCount
            };
            AvailabilitySet updatedSet = await set.UpdateAsync(update);

            Assert.AreEqual(updatedPlatformFaultDomainCount, updatedSet.Data.PlatformFaultDomainCount);
        }
    }
}
