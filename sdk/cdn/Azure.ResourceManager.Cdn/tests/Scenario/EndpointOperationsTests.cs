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
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
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
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
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
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
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
            ProfileData profileData = CreateProfileData(SkuName.StandardVerizon);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = new DeepCreatedOrigin("testOrigin")
            {
                HostName = "testsa4dotnetsdk.blob.core.windows.net"
            };
            endpointData.Origins.Add(deepCreatedOrigin);
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

        [TestCase]
        [RecordedTest]
        public async Task ValidateCustomDomain()
        {
            //A CName mapping needs to be created in advance to validate custom domain.
            //In this test is "customdomainrecord.azuretest.net" maps to "testEndpoint4dotnetsdk.azureedge.net"
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            ValidateCustomDomainInput validateCustomDomainInput1 = new ValidateCustomDomainInput("customdomainrecord.azuretest.net");
            ValidateCustomDomainOutput validateResult = await endpoint.ValidateCustomDomainAsync(validateCustomDomainInput1);
            Assert.True(validateResult.CustomDomainValidated);
            ValidateCustomDomainInput validateCustomDomainInput2 = new ValidateCustomDomainInput("customdomainvirtual.azuretest.net");
            validateResult = await endpoint.ValidateCustomDomainAsync(validateCustomDomainInput2);
            Assert.False(validateResult.CustomDomainValidated);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
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
            int count = 0;
            await foreach (var tempResourceUsage in endpoint.GetResourceUsageAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 8);
        }

        private static void AssertEndpointUpdate(Endpoint updatedEndpoint, EndpointUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedEndpoint.Data.IsHttpAllowed, updateParameters.IsHttpAllowed);
            Assert.AreEqual(updatedEndpoint.Data.OriginPath, updateParameters.OriginPath);
            Assert.AreEqual(updatedEndpoint.Data.OriginHostHeader, updateParameters.OriginHostHeader);
        }
    }
}
