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

            Assert.IsNotNull(endpointResource);
            Assert.IsTrue(endpointResource.HasData);
            Assert.IsNotNull(endpointResource.Data);
            Assert.AreEqual(EndpointName1, endpointResource.Data.Name);
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

            Assert.IsNotNull(endpointResource);
            Assert.IsTrue(endpointResource.HasData);
            Assert.IsNotNull(endpointResource.Data);
            Assert.AreEqual(NewEndpointTarget, endpointResource.Data.Target);
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

            Assert.IsNotNull(endpointResource);
            Assert.IsTrue(endpointResource.HasData);
            Assert.IsNotNull(endpointResource.Data);
            Assert.AreEqual(NewEndpointName, endpointResource.Data.Name);
            Assert.AreEqual(NewEndpointWeight, endpointResource.Data.Weight);
            Assert.AreEqual(NewEndpointTarget, endpointResource.Data.Target);
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

            Assert.AreEqual(NewEndpointTarget, endpointResource.Data.Target);
        }

        [RecordedTest]
        public async Task GetOnCollectionTest()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();
            TrafficManagerEndpointCollection endpointCollection = profileResource.GetTrafficManagerEndpoints();

            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeName, EndpointName1);

            Assert.IsNotNull(endpointResource);
            Assert.IsTrue(endpointResource.HasData);
            Assert.IsNotNull(endpointResource.Data);
            Assert.AreEqual(EndpointName1, endpointResource.Data.Name);
        }

        private async Task CheckExists(bool expected)
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();

            TrafficManagerEndpointCollection endpointCollection = profileResource.GetTrafficManagerEndpoints();

            if (expected)
            {
                Assert.IsTrue(await endpointCollection.ExistsAsync(EndpointTypeName, EndpointName1));
            }
            else
            {
                Assert.IsFalse(await endpointCollection.ExistsAsync(EndpointTypeName, EndpointName1));
            }
        }
    }
}
