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
    [ClientTestFixture(true, "2021-04-01", "2020-06-01", "2022-08-01", "2022-11-01", "2023-03-01", "2023-07-01", "2023-09-01", "2024-03-01", "2024-11-01")]
    public class AvailabilitySetCollectionTests : ComputeTestBase
    {
        public AvailabilitySetCollectionTests(bool isAsync, string apiVersion)
            : base(isAsync, AvailabilitySetResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
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
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, input);
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
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, input);
            AvailabilitySetResource set1 = lro.Value;
            AvailabilitySetResource set2 = await collection.GetAsync(setName);

            ResourceDataHelper.AssertAvailabilitySet(set1.Data, set2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetAvailabilitySetCollectionAsync();
            var setName = Recording.GenerateAssetName("testAS-");
            var input = ResourceDataHelper.GetBasicAvailabilitySetData(DefaultLocation);
            input.Tags.ReplaceWith(new Dictionary<string, string>
            {
                { "key", "value" }
            });
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, input);
            var availabilitySet = lro.Value;
            Assert.IsTrue(await collection.ExistsAsync(setName));
            Assert.IsFalse(await collection.ExistsAsync(setName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
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
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAS-"), input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAs-"), input);
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
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName1, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName2, input);

            AvailabilitySetResource set1 = null, set2 = null;
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
