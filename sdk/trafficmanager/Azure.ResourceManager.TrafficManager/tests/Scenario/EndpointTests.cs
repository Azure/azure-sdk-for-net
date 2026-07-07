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

        private async Task<TrafficManagerEndpointCollection> GetEndpointCollection()
        {
            TrafficManagerProfileResource profileResource = await GetDefaultProfile();
            return profileResource.GetTrafficManagerEndpoints();
        }

        [RecordedTest]
        public async Task GetTest()
        {
            TrafficManagerEndpointCollection endpointCollection = await GetEndpointCollection();
            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);

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
            // Verify the endpoint exists
            await CheckExists(expected: true);

            // Get the endpoint via collection and delete it
            TrafficManagerEndpointCollection endpointCollection = await GetEndpointCollection();
            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);
            Assert.IsNotNull(endpointResource);

            // Delete the endpoint
            await endpointResource.DeleteAsync(WaitUntil.Completed);

            await CheckExists(expected: false);
        }

        [RecordedTest]
        public async Task UpdateTest()
        {
            TrafficManagerEndpointCollection endpointCollection = await GetEndpointCollection();
            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);
            endpointResource.Data.Target = NewEndpointTarget;

            await endpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, EndpointTypeEnum, EndpointName1, endpointResource.Data);

            endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);

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

            TrafficManagerEndpointCollection endpointCollection = await GetEndpointCollection();

            await endpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, EndpointTypeEnum, NewEndpointName, newEndpointData);

            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, NewEndpointName);

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
            TrafficManagerEndpointCollection endpointCollection = await GetEndpointCollection();

            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);
            endpointResource.Data.Target = NewEndpointTarget;

            await endpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, EndpointTypeEnum, endpointResource.Data.Name, endpointResource.Data);

            endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);

            Assert.AreEqual(NewEndpointTarget, endpointResource.Data.Target);
        }

        [RecordedTest]
        public async Task GetOnCollectionTest()
        {
            TrafficManagerEndpointCollection endpointCollection = await GetEndpointCollection();

            TrafficManagerEndpointResource endpointResource = await endpointCollection.GetAsync(EndpointTypeEnum, EndpointName1);

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
                Assert.IsTrue(await endpointCollection.ExistsAsync(EndpointTypeEnum, EndpointName1));
            }
            else
            {
                Assert.IsFalse(await endpointCollection.ExistsAsync(EndpointTypeEnum, EndpointName1));
            }
        }
    }
}
