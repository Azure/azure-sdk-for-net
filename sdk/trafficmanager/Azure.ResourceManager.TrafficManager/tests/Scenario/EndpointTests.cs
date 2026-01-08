// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.TrafficManager.Tests
{
    public sealed class EndpointTests : ProfileTestBase
    {
        private const string NewEndpointTarget = "az-int-black111.int.microsoftmetrics.com";
        private const string NewEndpointName = "anotherEndpoint";
        private const int NewEndpointWeight = 500;

        public EndpointTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        private TrafficManagerEndpointResource DefaultEndpointResource =>
            new TrafficManagerEndpointResource(
                Client,
                TrafficManagerEndpointResource.CreateResourceIdentifier(
                    _subscription.Data.SubscriptionId,
                    _resourceGroup.Data.Name,
                    _profileName,
                    EndpointTypeName,
                    EndpointName1));

        [RecordedTest]
        public async Task GetTest()
        {
            TrafficManagerEndpointResource endpointResource = await DefaultEndpointResource.GetAsync();

            Assert.That(endpointResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(endpointResource.HasData, Is.True);
                Assert.That(endpointResource.Data, Is.Not.Null);
            });
            Assert.That(endpointResource.Data.Name, Is.EqualTo(EndpointName1));
        }

        [RecordedTest]
        public async Task ExistsTest()
        {
            await CheckExists(expected: true);
        }

        [RecordedTest]
        public async Task DeleteTest()
        {
            await DefaultEndpointResource.DeleteAsync(WaitUntil.Completed);

            await CheckExists(expected: false);
        }

        [RecordedTest]
        public async Task UpdateTest()
        {
            TrafficManagerEndpointResource endpointResource = await DefaultEndpointResource.GetAsync();
            endpointResource.Data.Target = NewEndpointTarget;
            await endpointResource.UpdateAsync(endpointResource.Data);

            endpointResource = await DefaultEndpointResource.GetAsync();

            Assert.That(endpointResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(endpointResource.HasData, Is.True);
                Assert.That(endpointResource.Data, Is.Not.Null);
            });
            Assert.That(endpointResource.Data.Target, Is.EqualTo(NewEndpointTarget));
        }

        [RecordedTest]
        public async Task CreateTest()
        {
            TrafficManagerEndpointData newEndpointData =
                new TrafficManagerEndpointData
                {
                    Name = NewEndpointName,
                    ResourceType = EndpointType,
                    Target = NewEndpointTarget,
                    Weight = NewEndpointWeight
                };

            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            TrafficManagerEndpointCollection endpointCollection = profileResource.GetTrafficManagerEndpoints();

            await endpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, EndpointTypeName, NewEndpointName, newEndpointData);

            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeName, NewEndpointName);

            Assert.That(endpointResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(endpointResource.HasData, Is.True);
                Assert.That(endpointResource.Data, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(endpointResource.Data.Name, Is.EqualTo(NewEndpointName));
                Assert.That(endpointResource.Data.Weight, Is.EqualTo(NewEndpointWeight));
                Assert.That(endpointResource.Data.Target, Is.EqualTo(NewEndpointTarget));
            });
        }

        [RecordedTest]
        public async Task UpdateOnCollectionTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();
            TrafficManagerEndpointCollection endpointCollection = profileResource.GetTrafficManagerEndpoints();

            TrafficManagerEndpointResource endpointResource = await DefaultEndpointResource.GetAsync();
            endpointResource.Data.Target = NewEndpointTarget;

            await endpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, EndpointTypeName, endpointResource.Data.Name, endpointResource.Data);

            endpointResource = await DefaultEndpointResource.GetAsync();

            Assert.That(endpointResource.Data.Target, Is.EqualTo(NewEndpointTarget));
        }

        [RecordedTest]
        public async Task GetOnCollectionTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();
            TrafficManagerEndpointCollection endpointCollection = profileResource.GetTrafficManagerEndpoints();

            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeName, EndpointName1);

            Assert.That(endpointResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(endpointResource.HasData, Is.True);
                Assert.That(endpointResource.Data, Is.Not.Null);
            });
            Assert.That(endpointResource.Data.Name, Is.EqualTo(EndpointName1));
        }

        private async Task CheckExists(bool expected)
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            TrafficManagerEndpointCollection endpointCollection = profileResource.GetTrafficManagerEndpoints();

            if (expected)
            {
                Assert.That((bool)await endpointCollection.ExistsAsync(EndpointTypeName, EndpointName1), Is.True);
            }
            else
            {
                Assert.That((bool)await endpointCollection.ExistsAsync(EndpointTypeName, EndpointName1), Is.False);
            }
        }
    }
}
