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
    public class OriginContainerTests : CdnManagementTestBase
    {
        public OriginContainerTests(bool isAsync)
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
            DeepCreatedOriginGroup deepCreatedOriginGroup = CreateDeepCreatedOriginGroup();
            deepCreatedOriginGroup.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            endpointData.Origins.Add(deepCreatedOrigin);
            endpointData.OriginGroups.Add(deepCreatedOriginGroup);
            endpointData.DefaultOriginGroup = new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/originGroups/{deepCreatedOriginGroup.Name}"
            };
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            string originName = Recording.GenerateAssetName("origin-");
            OriginData originData = CreateOriginData();
            var lro3 = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, originData);
            Origin origin = lro3.Value;
            Assert.AreEqual(originName, origin.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOrigins().CreateOrUpdateAsync(null, originData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, null));
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
            DeepCreatedOriginGroup deepCreatedOriginGroup = CreateDeepCreatedOriginGroup();
            deepCreatedOriginGroup.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            endpointData.Origins.Add(deepCreatedOrigin);
            endpointData.OriginGroups.Add(deepCreatedOriginGroup);
            endpointData.DefaultOriginGroup = new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/originGroups/{deepCreatedOriginGroup.Name}"
            };
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            string originName = Recording.GenerateAssetName("origin-");
            OriginData originData = CreateOriginData();
            var lro3 = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, originData);
            _ = lro3.Value;
            int count = 0;
            await foreach (var tempOrigin in endpoint.GetOrigins().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
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
            DeepCreatedOriginGroup deepCreatedOriginGroup = CreateDeepCreatedOriginGroup();
            deepCreatedOriginGroup.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            endpointData.Origins.Add(deepCreatedOrigin);
            endpointData.OriginGroups.Add(deepCreatedOriginGroup);
            endpointData.DefaultOriginGroup = new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/originGroups/{deepCreatedOriginGroup.Name}"
            };
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            string originName = Recording.GenerateAssetName("origin-");
            OriginData originData = CreateOriginData();
            var lro3 = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, originData);
            Origin origin = lro3.Value;
            Origin getOrigin = await endpoint.GetOrigins().GetAsync(originName);
            AssertValidOrigin(origin, getOrigin);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOrigins().GetAsync(null));
        }

        private static void AssertValidOrigin(Origin model, Origin getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.HttpPort, getResult.Data.HttpPort);
            Assert.AreEqual(model.Data.HttpsPort, getResult.Data.HttpsPort);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.Priority, getResult.Data.Priority);
            Assert.AreEqual(model.Data.Weight, getResult.Data.Weight);
            Assert.AreEqual(model.Data.Enabled, getResult.Data.Enabled);
            Assert.AreEqual(model.Data.PrivateLinkAlias, getResult.Data.PrivateLinkAlias);
            Assert.AreEqual(model.Data.PrivateLinkResourceId, getResult.Data.PrivateLinkResourceId);
            Assert.AreEqual(model.Data.PrivateLinkLocation, getResult.Data.PrivateLinkLocation);
            Assert.AreEqual(model.Data.PrivateLinkApprovalMessage, getResult.Data.PrivateLinkApprovalMessage);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.PrivateEndpointStatus, getResult.Data.PrivateEndpointStatus);
        }
    }
}
