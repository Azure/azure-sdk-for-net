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
    public class CdnEndpointOperationsTests : CdnManagementTestBase
    {
        public CdnEndpointOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            await cdnEndpoint.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnEndpoint.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            EndpointUpdateOptions updateOptions = new EndpointUpdateOptions
            {
                IsHttpAllowed = false,
                OriginPath = "/path/valid",
                OriginHostHeader = "www.bing.com"
            };
            var lro = await cdnEndpoint.UpdateAsync(updateOptions);
            CdnEndpoint updatedCdnEndpoint = lro.Value;
            ResourceDataHelper.AssertEndpointUpdate(updatedCdnEndpoint, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartAndStop()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            Assert.AreEqual(cdnEndpoint.Data.ResourceState, EndpointResourceState.Running);
            var lro1 = await cdnEndpoint.StopAsync();
            Assert.AreEqual(lro1.Value.ResourceState, EndpointResourceState.Stopped);
            var lro2 = await cdnEndpoint.StartAsync();
            Assert.AreEqual(lro2.Value.ResourceState, EndpointResourceState.Running);
        }

        [TestCase]
        [RecordedTest]
        public async Task LoadAndPurge()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardVerizon);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointData cdnEndpointData = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = new DeepCreatedOrigin("testOrigin")
            {
                HostName = "testsa4dotnetsdk.blob.core.windows.net"
            };
            cdnEndpointData.Origins.Add(deepCreatedOrigin);
            var lro = await cdnProfile.GetCdnEndpoints().CreateOrUpdateAsync(cdnEndpointName, cdnEndpointData);
            CdnEndpoint cdnEndpoint = lro.Value;
            PurgeOptions purgeParameters = new PurgeOptions(new List<string>
            {
                "/*"
            });
            Assert.DoesNotThrowAsync(async () => await cdnEndpoint.PurgeContentAsync(purgeParameters));
            LoadOptions loadParameters = new LoadOptions(new List<string>
            {
                "/testfile/file1.txt"
            });
            Assert.DoesNotThrowAsync(async () => await cdnEndpoint.LoadContentAsync(loadParameters));
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateCustomDomain()
        {
            //A CName mapping needs to be created in advance to validate custom domain.
            //In this test is "customdomainrecord.azuretest.net" maps to "testEndpoint4dotnetsdk.azureedge.net"
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpoint cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            ValidateCustomDomainInput validateCustomDomainInput1 = new ValidateCustomDomainInput("customdomainrecord.azuretest.net");
            ValidateCustomDomainOutput validateResult = await cdnEndpoint.ValidateCustomDomainAsync(validateCustomDomainInput1);
            Assert.True(validateResult.CustomDomainValidated);
            ValidateCustomDomainInput validateCustomDomainInput2 = new ValidateCustomDomainInput("customdomainvirtual.azuretest.net");
            validateResult = await cdnEndpoint.ValidateCustomDomainAsync(validateCustomDomainInput2);
            Assert.False(validateResult.CustomDomainValidated);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            int count = 0;
            await foreach (var tempResourceUsage in cdnEndpoint.GetResourceUsageAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 8);
        }
    }
}
