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
    public class OriginGroupOperationsTests : CdnManagementTestBase
    {
        public OriginGroupOperationsTests(bool isAsync)
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
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroupData originGroupData = new OriginGroupData();
            originGroupData.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            var lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, originGroupData);
            OriginGroup originGroup = lro3.Value;
            await originGroup.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await originGroup.GetAsync());
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
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro2.Value;
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroupData originGroupData = new OriginGroupData();
            originGroupData.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            var lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, originGroupData);
            OriginGroup originGroup = lro3.Value;
            OriginGroupUpdateParameters originGroupUpdateParameters = new OriginGroupUpdateParameters()
            {
                HealthProbeSettings = new HealthProbeParameters
                {
                    ProbePath = "/healthz",
                    ProbeRequestType = HealthProbeRequestType.Head,
                    ProbeProtocol = ProbeProtocol.Https,
                    ProbeIntervalInSeconds = 60
                }
            };
            var lro4 = await originGroup.UpdateAsync(originGroupUpdateParameters);
            OriginGroup updatedOriginGroup = lro4.Value;
            AssertOriginGroupUpdate(updatedOriginGroup, originGroupUpdateParameters);
        }

        private static void AssertOriginGroupUpdate(OriginGroup updatedOriginGroup, OriginGroupUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbePath, updateParameters.HealthProbeSettings.ProbePath);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeRequestType, updateParameters.HealthProbeSettings.ProbeRequestType);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeProtocol, updateParameters.HealthProbeSettings.ProbeProtocol);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeIntervalInSeconds, updateParameters.HealthProbeSettings.ProbeIntervalInSeconds);
        }
    }
}
