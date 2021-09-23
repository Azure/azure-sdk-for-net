// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class OriginOperationsTests : CdnManagementTestBase
    {
        public OriginOperationsTests(bool isAsync)
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
            await origin.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await origin.GetAsync());
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
            OriginUpdateParameters originUpdateParameters = new OriginUpdateParameters()
            {
                HttpPort = 81,
                HttpsPort = 442,
                Priority = 1,
                Weight = 150
            };
            var lro4 = await origin.UpdateAsync(originUpdateParameters);
            Origin updatedOrigin = lro4.Value;
            AssertOriginUpdate(updatedOrigin, originUpdateParameters);
        }

        private static void AssertOriginUpdate(Origin updatedOrigin, OriginUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedOrigin.Data.HttpPort, updateParameters.HttpPort);
            Assert.AreEqual(updatedOrigin.Data.HttpsPort, updateParameters.HttpsPort);
            Assert.AreEqual(updatedOrigin.Data.Priority, updateParameters.Priority);
            Assert.AreEqual(updatedOrigin.Data.Weight, updateParameters.Weight);
        }
    }
}
