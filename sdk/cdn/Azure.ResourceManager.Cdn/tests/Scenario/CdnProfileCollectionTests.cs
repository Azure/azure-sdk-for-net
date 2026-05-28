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
    public class CdnProfileCollectionTests : CdnManagementTestBase
    {
        public CdnProfileCollectionTests(bool isAsync)
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
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            Assert.AreEqual(cdnProfileName, cdnProfile.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, null, cdnProfile.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, cdnProfileName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            _ = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            int count = 0;
            await foreach (var tempProfileResource in rg.GetProfiles().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        // disable due to a bug
        //[TestCase]
        //[RecordedTest]
        public async Task ListBySubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            int count = 0;
            await foreach (var tempProfile in subscription.GetProfilesAsync())
            {
                if (tempProfile.Data.Id == cdnProfile.Data.Id)
                {
                    count++;
                }
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
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            ProfileResource getCdnProfile = await rg.GetProfiles().GetAsync(cdnProfileName);
            ResourceDataHelper.AssertValidProfile(cdnProfile, getCdnProfile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().GetAsync(null));
        }
    }
}
