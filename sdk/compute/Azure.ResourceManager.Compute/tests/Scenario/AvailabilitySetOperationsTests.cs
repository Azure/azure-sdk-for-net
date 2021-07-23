// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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
            var container = (await CreateResourceGroupAsync()).GetAvailabilitySets();
            var input = AvailabilitySetHelpers.GetBasicAvailabilitySetData(DefaultLocation, new Dictionary<string, string>() { { "key", "value" } });
            return await container.CreateOrUpdateAsync(setName, input);
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
        public async Task StartDelete()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var availabilitySet = await CreateAvailabilitySetAsync(setName);
            var deleteOp = await availabilitySet.StartDeleteAsync();
            await deleteOp.WaitForCompletionResponseAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var setName = Recording.GenerateAssetName("testAS-");
            var set1 = await CreateAvailabilitySetAsync(setName);
            AvailabilitySet set2 = await set1.GetAsync();

            AvailabilitySetHelpers.AssertAvailabilitySet(set1.Data, set2.Data);
        }
    }
}
