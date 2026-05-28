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
    public class CdnOriginCollectionTests : CdnManagementTestBase
    {
        public CdnOriginCollectionTests(bool isAsync)
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
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOriginResource cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            Assert.AreEqual(cdnOriginName, cdnOrigin.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOrigins().CreateOrUpdateAsync(WaitUntil.Completed, null, cdnOrigin.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOrigins().CreateOrUpdateAsync(WaitUntil.Completed, cdnOriginName, null));
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
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            _ = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            int count = 0;
            await foreach (var tempOrigin in cdnEndpoint.GetCdnOrigins().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
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
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOriginResource cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            CdnOriginResource getCdnOrigin = await cdnEndpoint.GetCdnOrigins().GetAsync(cdnOriginName);
            ResourceDataHelper.AssertValidOrigin(cdnOrigin, getCdnOrigin);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOrigins().GetAsync(null));
        }
    }
}
