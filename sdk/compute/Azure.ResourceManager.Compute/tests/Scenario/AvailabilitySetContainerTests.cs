// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class AvailabilitySetContainerTests : ComputeTestBase
    {
        public AvailabilitySetContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AvailabilitySetContainer> GetAvailabilitySetContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAvailabilitySets();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetAvailabilitySetContainerAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            AvailabilitySet availabilitySet = await container.CreateOrUpdateAsync(setName, input);
            Assert.AreEqual(setName, availabilitySet.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetAvailabilitySetContainerAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            var availabilitySetOp = await container.StartCreateOrUpdateAsync(setName, input);
            AvailabilitySet availabilitySet = await availabilitySetOp.WaitForCompletionAsync();
            Assert.AreEqual(setName, availabilitySet.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetAvailabilitySetContainerAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            AvailabilitySet set1 = await container.CreateOrUpdateAsync(setName, input);
            AvailabilitySet set2 = await container.GetAsync(setName);

            ResourceDataHelper.AssertAvailabilitySet(set1.Data, set2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetAvailabilitySetContainerAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            AvailabilitySet availabilitySet = await container.CreateOrUpdateAsync(setName, input);
            Assert.IsTrue(await container.CheckIfExistsAsync(setName));
            Assert.IsFalse(await container.CheckIfExistsAsync(setName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetAvailabilitySetContainerAsync();
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testAS-"), input);
            _ = await container.CreateOrUpdateAsync(Recording.GenerateAssetName("testAs-"), input);
            int count = 0;
            await foreach (var availabilitySet in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var container = await GetAvailabilitySetContainerAsync();
            var setName1 = Recording.GenerateAssetName("testAS-");
            var setName2 = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            _ = await container.CreateOrUpdateAsync(setName1, input);
            _ = await container.CreateOrUpdateAsync(setName2, input);

            AvailabilitySet set1 = null, set2 = null;
            await foreach (var availabilitySet in DefaultSubscription.GetAvailabilitySetsAsync())
            {
                if (availabilitySet.Data.Name == setName1)
                    set1 = availabilitySet;
                if (availabilitySet.Data.Name == setName2)
                    set2 = availabilitySet;
            }

            Assert.NotNull(set1);
            Assert.NotNull(set2);
        }
    }
}
