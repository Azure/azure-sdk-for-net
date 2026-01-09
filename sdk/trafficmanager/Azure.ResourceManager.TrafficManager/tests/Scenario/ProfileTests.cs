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
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            Assert.That(profileResource, Is.Not.Null);
            Assert.That(profileResource.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(profileResource.Data.Name, Is.EqualTo(_profileName));
                Assert.That(profileResource.Data.TrafficRoutingMethod, Is.EqualTo(TrafficRoutingMethod.Weighted));
            });
        }

        [RecordedTest]
        public async Task UpdateEntityTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            profileResource.Data.TrafficRoutingMethod = TrafficRoutingMethod.Priority;

            // Cannot update the profile with the endpoints with the object update
            profileResource.Data.Endpoints.Clear();
            await profileResource.UpdateAsync(profileResource.Data);

            profileResource = await GetDefaultProfile();

            Assert.That(profileResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(profileResource.HasData, Is.True);
                Assert.That(profileResource.Data, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(profileResource.Data.Name, Is.EqualTo(_profileName));
                Assert.That(profileResource.Data.TrafficRoutingMethod, Is.EqualTo(TrafficRoutingMethod.Priority));
            });
        }

        [RecordedTest]
        public async Task UpdateCollectionTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            profileResource.Data.TrafficRoutingMethod = TrafficRoutingMethod.Priority;

            await _profileCollection.CreateOrUpdateAsync(WaitUntil.Completed, _profileName, profileResource.Data);

            profileResource = await GetDefaultProfile();

            Assert.That(profileResource, Is.Not.Null);
            Assert.That(profileResource.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(profileResource.Data.Name, Is.EqualTo(_profileName));
                Assert.That(profileResource.Data.TrafficRoutingMethod, Is.EqualTo(TrafficRoutingMethod.Priority));
            });
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddTagTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            await profileResource.AddTagAsync(ExpectedKey, ExpectedValue);

            profileResource = await GetDefaultProfile();

            Assert.Multiple(() =>
            {
                Assert.That(profileResource.Data.Tags.TryGetValue(ExpectedKey, out string value), Is.True);
                Assert.That(value, Is.EqualTo(ExpectedValue));
            });
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

            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            await profileResource.SetTagsAsync(expectedTags);

            profileResource = await GetDefaultProfile();

            Assert.That(profileResource.Data.Tags.Count, Is.EqualTo(expectedTags.Count));

            foreach (var item in expectedTags)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(profileResource.Data.Tags.TryGetValue(item.Key, out string value), Is.True);
                    Assert.That(value, Is.EqualTo(item.Value));
                });
            }
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task RemoveTagTest(bool? useTagResource)
        {
            await AddTagTest(useTagResource);

            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            await profileResource.RemoveTagAsync(ExpectedKey);

            profileResource = await GetDefaultProfile();

            Assert.That(profileResource.Data.Tags.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task GetEndpointTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            TrafficManagerEndpointResource endpointResource = await profileResource.GetTrafficManagerEndpointAsync("externalEndpoints", EndpointName1);

            Assert.That(endpointResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(endpointResource.Data.Name, Is.EqualTo(EndpointName1));
                Assert.That(endpointResource.Data.ResourceType.ToString(), Is.EqualTo(EndpointType));
            });
        }

        [RecordedTest]
        public async Task GetHeatMapModelsTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            Assert.That(profileResource.GetTrafficManagerHeatMaps(), Is.Not.Null);
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

            Assert.That(counter, Is.EqualTo(1));
        }

        [RecordedTest]
        public async Task EnumeratorTest()
        {
            int counter = 0;

            await foreach (var profile in _profileCollection)
            {
                counter++;
            }

            Assert.That(counter, Is.EqualTo(1));
        }

        [RecordedTest]
        public async Task ExistsTest()
        {
            Assert.That((bool)await _profileCollection.ExistsAsync(_profileName), Is.True);
        }

        private async Task HeatMapTest(IEnumerable<double> topLeft = null, IEnumerable<double> botRight = null)
        {
            const string ProfileWithHeatmapResourceGroupName = "dialtone-traffic-manager";
            const string ProfileWithHeatmapName = "az-int-int-msftmetrics";

            ResourceGroupResource resourceGroup = await _subscription.GetResourceGroupAsync(ProfileWithHeatmapResourceGroupName);

            TrafficManagerProfileCollection profileCollection = resourceGroup.GetTrafficManagerProfiles();

            TrafficManagerProfileResource profileResource = await profileCollection.GetAsync(ProfileWithHeatmapName);

            TrafficManagerHeatMapResource heatMapModelResource = await profileResource.GetTrafficManagerHeatMapAsync(TrafficManagerHeatMapType.Default, topLeft, botRight);

            Assert.That(heatMapModelResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(heatMapModelResource.HasData, Is.True);
                Assert.That(heatMapModelResource.Data, Is.Not.Null);
            });
            Assert.That(heatMapModelResource.Data.TrafficFlows, Is.Not.Empty);
        }
    }
}
