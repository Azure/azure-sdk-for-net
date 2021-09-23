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
    public class OriginGroupContainerTests : CdnManagementTestBase
    {
        public OriginGroupContainerTests(bool isAsync)
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
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroupData originGroupData = new OriginGroupData();
            originGroupData.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            var lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, originGroupData);
            OriginGroup originGroup = lro3.Value;
            Assert.AreEqual(originGroupName, originGroup.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOriginGroups().CreateOrUpdateAsync(null, originGroupData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, null));
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
            Endpoint endpoint = lro2.Value;
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroupData originGroupData = new OriginGroupData();
            originGroupData.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            var lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, originGroupData);
            _ = lro3.Value;
            int count = 0;
            await foreach (var tempOriginGroup in endpoint.GetOriginGroups().GetAllAsync())
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
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroupData originGroupData = new OriginGroupData();
            originGroupData.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            var lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, originGroupData);
            OriginGroup originGroup = lro3.Value;
            OriginGroup getOriginGroup = await endpoint.GetOriginGroups().GetAsync(originGroupName);
            AssertValidOriginGroup(originGroup, getOriginGroup);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOriginGroups().GetAsync(null));
        }

        private static void AssertValidOriginGroup(OriginGroup model, OriginGroup getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.NotNull(model.Data.HealthProbeSettings);
                Assert.NotNull(getResult.Data.HealthProbeSettings);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeIntervalInSeconds, getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbePath, getResult.Data.HealthProbeSettings.ProbePath);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeProtocol, getResult.Data.HealthProbeSettings.ProbeProtocol);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeRequestType, getResult.Data.HealthProbeSettings.ProbeRequestType);
            }
            Assert.AreEqual(model.Data.Origins.Count, getResult.Data.Origins.Count);
            for (int i = 0; i < model.Data.Origins.Count; ++i)
            {
                Assert.AreEqual(model.Data.Origins[i].Id, getResult.Data.Origins[i].Id);
            }
            Assert.AreEqual(model.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes, getResult.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            //Todo: ResponseBasedOriginErrorDetectionSettings
        }
    }
}
