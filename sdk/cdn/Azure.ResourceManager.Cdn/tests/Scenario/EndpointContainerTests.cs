// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class EndpointContainerTests : CdnManagementTestBase
    {
        public EndpointContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await profile.GetEndpoints().CreateOrUpdateAsync(null, endpointData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            _ = lro2.Value;
            int count = 0;
            await foreach (var tempEndpoint in profile.GetEndpoints().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardMicrosoft);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            Endpoint getEndpoint = await profile.GetEndpoints().GetAsync(endpointName);
            AssertValidEndpoint(endpoint, getEndpoint);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await profile.GetEndpoints().GetAsync(null));
        }

        private static void AssertValidEndpoint(Endpoint model, Endpoint getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.OriginPath, getResult.Data.OriginPath);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.IsCompressionEnabled, getResult.Data.IsCompressionEnabled);
            Assert.AreEqual(model.Data.IsHttpAllowed, getResult.Data.IsHttpAllowed);
            Assert.AreEqual(model.Data.IsHttpsAllowed, getResult.Data.IsHttpsAllowed);
            Assert.AreEqual(model.Data.QueryStringCachingBehavior, getResult.Data.QueryStringCachingBehavior);
            Assert.AreEqual(model.Data.OptimizationType, getResult.Data.OptimizationType);
            Assert.AreEqual(model.Data.ProbePath, getResult.Data.ProbePath);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            //Todo: ContentTypesToCompress, GeoFilters, DefaultOriginGroup, UrlSigningKeys, DeliveryPolicy, WebApplicationFirewallPolicyLink, Origins, OriginGroups
        }
    }
}
