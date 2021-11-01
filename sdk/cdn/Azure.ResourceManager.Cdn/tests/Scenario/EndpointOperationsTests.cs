// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            await endpoint.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await endpoint.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            EndpointUpdateParameters updateParameters = new EndpointUpdateParameters
            {
                IsHttpAllowed = false,
                OriginPath = "/path/valid",
                OriginHostHeader = "www.bing.com"
            };
            var lro = await endpoint.UpdateAsync(updateParameters);
            Endpoint updatedEndpoint = lro.Value;
            ResourceDataHelper.AssertEndpointUpdate(updatedEndpoint, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartAndStop()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            Assert.AreEqual(endpoint.Data.ResourceState, EndpointResourceState.Running);
            var lro1 = await endpoint.StopAsync();
            Assert.AreEqual(lro1.Value.ResourceState, EndpointResourceState.Stopped);
            var lro2 = await endpoint.StartAsync();
            Assert.AreEqual(lro2.Value.ResourceState, EndpointResourceState.Running);
        }

        [TestCase]
        [RecordedTest]
        public async Task LoadAndPurge()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardVerizon);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            EndpointData endpointData = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = new DeepCreatedOrigin("testOrigin")
            {
                HostName = "testsa4dotnetsdk.blob.core.windows.net"
            };
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            Endpoint endpoint = lro.Value;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            int count = 0;
            await foreach (var tempResourceUsage in endpoint.GetResourceUsageAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 8);
        }
    }
}
