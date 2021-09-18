// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class EndpointOperationsTests : CdnManagementTestBase
    {
        public EndpointOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData(profile.Id, endpointName);
            DeepCreatedOrigin origin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(origin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            await endpoint.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await endpoint.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData(profile.Id, endpointName);
            DeepCreatedOrigin origin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(origin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            EndpointUpdateParameters updateParameters = new EndpointUpdateParameters
            {
                IsHttpAllowed = false,
                OriginPath = "/path/valid",
                OriginHostHeader = "www.bing.com"
            };
            var lro3 = await endpoint.UpdateAsync(updateParameters);
            Endpoint updatedEndpoint = lro3.Value;
            AssertEndpointUpdate(updatedEndpoint, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartAndStop()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData(profile.Id, endpointName);
            DeepCreatedOrigin origin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(origin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            Assert.AreEqual(endpoint.Data.ResourceState, EndpointResourceState.Running);
            var lro3 = await endpoint.StopAsync();
            Assert.AreEqual(lro3.Value.ResourceState, EndpointResourceState.Stopped);
            var lro4 = await endpoint.StartAsync();
            Assert.AreEqual(lro4.Value.ResourceState, EndpointResourceState.Running);
        }

        [TestCase]
        [RecordedTest]
        public async Task LoadAndPurge()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData(profile.Id, endpointName);
            DeepCreatedOrigin origin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(origin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            PurgeParameters purgeParameters = new PurgeParameters(new List<string>
            {
                "/*"
            });
            Assert.DoesNotThrowAsync(async () => await endpoint.PurgeContentAsync(purgeParameters));
            LoadParameters loadParameters = new LoadParameters(new List<string>
            {
                "/testfile/file1.txt"
            });
            Assert.DoesNotThrowAsync(async () => await endpoint.LoadContentAsync(loadParameters));
        }

        //[TestCase]
        //[RecordedTest]
        //public async Task ValidateCustomDomain()
        //{

        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetResourceUsage()
        //{

        //}

        private static void AssertEndpointUpdate(Endpoint updatedEndpoint, EndpointUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedEndpoint.Data.IsHttpAllowed, updateParameters.IsHttpAllowed);
            Assert.AreEqual(updatedEndpoint.Data.OriginPath, updateParameters.OriginPath);
            Assert.AreEqual(updatedEndpoint.Data.OriginHostHeader, updateParameters.OriginHostHeader);
        }
    }
}
