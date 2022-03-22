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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroupResource cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            Assert.AreEqual(cdnOriginGroupName, cdnOriginGroup.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOriginGroups().CreateOrUpdateAsync(WaitUntil.Completed, null, cdnOriginGroup.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOriginGroups().CreateOrUpdateAsync(WaitUntil.Completed, cdnOriginGroupName, null));
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
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroupResource cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            CdnOriginGroupResource getCdnOriginGroup = await cdnEndpoint.GetCdnOriginGroups().GetAsync(cdnOriginGroupName);
            ResourceDataHelper.AssertValidOriginGroup(cdnOriginGroup, getCdnOriginGroup);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnOriginGroups().GetAsync(null));
        }
    }
}
