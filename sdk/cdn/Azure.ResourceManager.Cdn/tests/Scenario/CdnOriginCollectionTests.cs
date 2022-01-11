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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOrigin cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            Assert.AreEqual(cdnOriginName, cdnOrigin.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOrigins().CreateOrUpdateAsync(null, cdnOrigin.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOrigins().CreateOrUpdateAsync(cdnOriginName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOrigin cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            CdnOrigin getCdnOrigin = await cdnEndpoint.GetCdnOrigins().GetAsync(cdnOriginName);
            ResourceDataHelper.AssertValidOrigin(cdnOrigin, getCdnOrigin);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOrigins().GetAsync(null));
        }
    }
}
