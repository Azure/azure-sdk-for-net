// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnEndpointCollectionTests : CdnManagementTestBase
    {
        public CdnEndpointCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            Assert.AreEqual(cdnEndpointName, cdnEndpoint.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnProfile.GetCdnEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, null, cdnEndpoint.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnProfile.GetCdnEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, cdnEndpointName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            _ = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            int count = 0;
            await foreach (var tempEndpoint in cdnProfile.GetCdnEndpoints().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            CdnEndpointResource getCdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync(cdnEndpointName);
            ResourceDataHelper.AssertValidEndpoint(cdnEndpoint, getCdnEndpoint);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnProfile.GetCdnEndpoints().GetAsync(null));
        }
    }
}
