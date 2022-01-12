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
    public class CdnOriginGroupCollectionTests : CdnManagementTestBase
    {
        public CdnOriginGroupCollectionTests(bool isAsync)
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
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroup cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            Assert.AreEqual(cdnOriginGroupName, cdnOriginGroup.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOriginGroups().CreateOrUpdateAsync(null, cdnOriginGroup.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOriginGroups().CreateOrUpdateAsync(cdnOriginGroupName, null));
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
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            _ = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            int count = 0;
            await foreach (var tempOriginGroup in cdnEndpoint.GetCdnOriginGroups().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
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
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroup cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            CdnOriginGroup getCdnOriginGroup = await cdnEndpoint.GetCdnOriginGroups().GetAsync(cdnOriginGroupName);
            ResourceDataHelper.AssertValidOriginGroup(cdnOriginGroup, getCdnOriginGroup);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOriginGroups().GetAsync(null));
        }
    }
}
