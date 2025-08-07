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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            await cdnEndpoint.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnEndpoint.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            CdnEndpointPatch updateOptions = new CdnEndpointPatch
            {
                IsHttpAllowed = false,
                OriginPath = "/path/valid",
                OriginHostHeader = "www.bing.com"
            };
            var lro = await cdnEndpoint.UpdateAsync(WaitUntil.Completed, updateOptions);
            CdnEndpointResource updatedCdnEndpoint = lro.Value;
            ResourceDataHelper.AssertEndpointUpdate(updatedCdnEndpoint, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartAndStop()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            Assert.AreEqual(cdnEndpoint.Data.ResourceState, EndpointResourceState.Running);
            var lro1 = await cdnEndpoint.StopAsync(WaitUntil.Completed);
            Assert.AreEqual(lro1.Value.Data.ResourceState, EndpointResourceState.Stopped);
            var lro2 = await cdnEndpoint.StartAsync(WaitUntil.Completed);
            Assert.AreEqual(lro2.Value.Data.ResourceState, EndpointResourceState.Running);
        }

        [TestCase]
        [RecordedTest]
        public async Task LoadAndPurge()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointData cdnEndpointData = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = new DeepCreatedOrigin("testOrigin")
            {
                HostName = "testsa4dotnetsdk.blob.core.windows.net"
            };
            cdnEndpointData.Origins.Add(deepCreatedOrigin);
            var lro = await cdnProfile.GetCdnEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, cdnEndpointName, cdnEndpointData);
            CdnEndpointResource cdnEndpoint = lro.Value;
            PurgeContent purgeParameters = new PurgeContent(new List<string>
            {
                "/*"
            });
            Assert.DoesNotThrowAsync(async () => await cdnEndpoint.PurgeContentAsync(WaitUntil.Completed, purgeParameters));
            LoadContent loadParameters = new LoadContent(new List<string>
            {
                "/testfile/file1.txt"
            });
            Assert.DoesNotThrowAsync(async () => await cdnEndpoint.LoadContentAsync(WaitUntil.Completed, loadParameters));
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateCustomDomain()
        {
            //A CName mapping needs to be created in advance to validate custom domain.
            //In this test is "customdomainrecord.azuretest.net" maps to "testEndpoint4dotnetsdk.azureedge.net"
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk1");
            ValidateCustomDomainContent validateCustomDomainContent1 = new ValidateCustomDomainContent("customdomainrecord.clitest.azfdtest.xyz");
            ValidateCustomDomainResult validateResult = await cdnEndpoint.ValidateCustomDomainAsync(validateCustomDomainContent1);
            Assert.True(validateResult.IsCustomDomainValid);
            ValidateCustomDomainContent validateCustomDomainContent2 = new ValidateCustomDomainContent("customdomainvirtual.clitest.azfdtest.xyz");
            validateResult = await cdnEndpoint.ValidateCustomDomainAsync(validateCustomDomainContent2);
            Assert.False(validateResult.IsCustomDomainValid);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            int count = 0;
            await foreach (var tempResourceUsage in cdnEndpoint.GetResourceUsagesAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 8);
        }
    }
}
