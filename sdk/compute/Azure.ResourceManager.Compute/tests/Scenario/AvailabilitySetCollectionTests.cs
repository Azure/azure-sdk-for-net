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
    public class AvailabilitySetCollectionTests : ComputeTestBase
    {
        public AvailabilitySetCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AvailabilitySetCollection> GetAvailabilitySetCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAvailabilitySets();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetAvailabilitySetCollectionAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            var lro = await collection.CreateOrUpdateAsync(setName, input);
            var availabilitySet = lro.Value;
            Assert.AreEqual(setName, availabilitySet.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetAvailabilitySetCollectionAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            var lro = await collection.CreateOrUpdateAsync(setName, input);
            AvailabilitySet set1 = lro.Value;
            AvailabilitySet set2 = await collection.GetAsync(setName);

            ResourceDataHelper.AssertAvailabilitySet(set1.Data, set2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var collection = await GetAvailabilitySetCollectionAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            var lro = await collection.CreateOrUpdateAsync(setName, input);
            var availabilitySet = lro.Value;
            Assert.IsTrue(await collection.CheckIfExistsAsync(setName));
            Assert.IsFalse(await collection.CheckIfExistsAsync(setName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetAvailabilitySetCollectionAsync();
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testAS-"), input);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testAs-"), input);
            int count = 0;
            await foreach (var availabilitySet in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var collection = await GetAvailabilitySetCollectionAsync();
            var setName1 = Recording.GenerateAssetName("testAS-");
            var setName2 = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            _ = await collection.CreateOrUpdateAsync(setName1, input);
            _ = await collection.CreateOrUpdateAsync(setName2, input);

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
