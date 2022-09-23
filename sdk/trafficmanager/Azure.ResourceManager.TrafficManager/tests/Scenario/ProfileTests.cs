// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TrafficManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.TrafficManager.Tests
{
    public sealed class ProfileTests : ProfileTestBase
    {
        public ProfileTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        { }

        [RecordedTest]
        public async Task GetTest()
        {
            ProfileResource profileResource = await GetDefaultProfile();

            Assert.IsNotNull(profileResource);
            Assert.IsNotNull(profileResource.Data);
            Assert.AreEqual(_profileName, profileResource.Data.Name);
            Assert.AreEqual(TrafficRoutingMethod.Weighted, profileResource.Data.TrafficRoutingMethod);
        }

        [RecordedTest]
        public async Task UpdateEntityTest()
        {
            ProfileResource profileResource = await GetDefaultProfile();

            profileResource.Data.TrafficRoutingMethod = TrafficRoutingMethod.Priority;

            // Cannot update the profile with the endpoints with the object update
            profileResource.Data.Endpoints.Clear();
            await profileResource.UpdateAsync(profileResource.Data);

            profileResource = await GetDefaultProfile();

            Assert.IsNotNull(profileResource);
            Assert.IsTrue(profileResource.HasData);
            Assert.IsNotNull(profileResource.Data);
            Assert.AreEqual(_profileName, profileResource.Data.Name);
            Assert.AreEqual(TrafficRoutingMethod.Priority, profileResource.Data.TrafficRoutingMethod);
        }

        [RecordedTest]
        public async Task UpdateCollectionTest()
        {
            ProfileResource profileResource = await GetDefaultProfile();

            profileResource.Data.TrafficRoutingMethod = TrafficRoutingMethod.Priority;

            await _profileCollection.CreateOrUpdateAsync(WaitUntil.Completed, _profileName, profileResource.Data);

            profileResource = await GetDefaultProfile();

            Assert.IsNotNull(profileResource);
            Assert.IsNotNull(profileResource.Data);
            Assert.AreEqual(_profileName, profileResource.Data.Name);
            Assert.AreEqual(TrafficRoutingMethod.Priority, profileResource.Data.TrafficRoutingMethod);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddTagTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            ProfileResource profileResource = await GetDefaultProfile();

            await profileResource.AddTagAsync(ExpectedKey, ExpectedValue);

            profileResource = await GetDefaultProfile();

            Assert.IsTrue(profileResource.Data.Tags.TryGetValue(ExpectedKey, out string value));
            Assert.AreEqual(ExpectedValue, value);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task SetTagsTest(bool? useTagResource)
        {
            // add one default tag to check if the method overrides all values as expected
            await AddTagTest(useTagResource);

            IDictionary<string, string> expectedTags = new Dictionary<string, string>
            {
                { "tagKey1", "tagKey1" },
                { "tagKey2", "tagKey2" },
                { "tagKey3", "tagKey3" }
            };

            ProfileResource profileResource = await GetDefaultProfile();

            await profileResource.SetTagsAsync(expectedTags);

            profileResource = await GetDefaultProfile();

            Assert.AreEqual(expectedTags.Count, profileResource.Data.Tags.Count);

            foreach (var item in expectedTags)
            {
                Assert.IsTrue(profileResource.Data.Tags.TryGetValue(item.Key, out string value));
                Assert.AreEqual(item.Value, value);
            }
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task RemoveTagTest(bool? useTagResource)
        {
            await AddTagTest(useTagResource);

            ProfileResource profileResource = await GetDefaultProfile();

            await profileResource.RemoveTagAsync(ExpectedKey);

            profileResource = await GetDefaultProfile();

            Assert.AreEqual(0, profileResource.Data.Tags.Count);
        }

        [RecordedTest]
        public async Task GetEndpointTest()
        {
            ProfileResource profileResource = await GetDefaultProfile();

            EndpointResource endpointResource = await profileResource.GetEndpointAsync("externalEndpoints", EndpointName1);

            Assert.IsNotNull(endpointResource);
            Assert.AreEqual(EndpointName1, endpointResource.Data.Name);
            Assert.AreEqual(EndpointType, endpointResource.Data.ResourceType);
        }

        [RecordedTest]
        public async Task GetHeatMapModelsTest()
        {
            ProfileResource profileResource = await GetDefaultProfile();

            Assert.IsNotNull(profileResource.GetHeatMapModels());
        }

        [PlaybackOnlyAttribute("Hard to generate test data for execution in RecordedTestMode.Live. The test data here is a data generated by real users.")]
        [RecordedTest]
        public async Task GetHeatMapModelTest()
        {
            await HeatMapTest();
        }

        [PlaybackOnlyAttribute("Hard to generate test data for execution in RecordedTestMode.Live. The test data here is a data generated by real users.")]
        [RecordedTest]
        public async Task GetHeatMapModelWithCoordinatesConstraintTest()
        {
            // Rio de Janeiro and San Paulo area
            await HeatMapTest(topLeft: new List<double> { -18.910742, -47.858517 }, botRight: new List<double> { -24.341378, -37.964283 });
        }

        [RecordedTest]
        public async Task GetAllTest()
        {
            int counter = 0;

            await foreach (var profile in _profileCollection.GetAllAsync())
            {
                counter++;
            }

            Assert.AreEqual(1, counter);
        }

        [RecordedTest]
        public async Task EnumeratorTest()
        {
            int counter = 0;

            await foreach (var profile in _profileCollection)
            {
                counter++;
            }

            Assert.AreEqual(1, counter);
        }

        [RecordedTest]
        public async Task ExistsTest()
        {
            Assert.IsTrue(await _profileCollection.ExistsAsync(_profileName));
        }

        private async Task HeatMapTest(IEnumerable<double> topLeft = null, IEnumerable<double> botRight = null)
        {
            const string ProfileWithHeatmapResourceGroupName = "dialtone-traffic-manager";
            const string ProfileWithHeatmapName = "az-int-int-msftmetrics";

            ResourceGroupResource resourceGroup = await _subscription.GetResourceGroupAsync(ProfileWithHeatmapResourceGroupName);

            ProfileCollection profileCollection = resourceGroup.GetProfiles();

            ProfileResource profileResource = await profileCollection.GetAsync(ProfileWithHeatmapName);

            HeatMapModelResource heatMapModelResource = await profileResource.GetHeatMapModelAsync(HeatMapType.Default, topLeft, botRight);

            Assert.IsNotNull(heatMapModelResource);
            Assert.IsTrue(heatMapModelResource.HasData);
            Assert.IsNotNull(heatMapModelResource.Data);
            Assert.IsTrue(heatMapModelResource.Data.TrafficFlows.Count > 0);
        }
    }
}
