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
    public class ProfileCollectionTests : CdnManagementTestBase
    {
        public ProfileCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            Assert.AreEqual(profileName, profile.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(null, profile.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(profileName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            _ = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            int count = 0;
            await foreach (var tempProfile in rg.GetProfiles().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            int count = 0;
            await foreach (var tempProfile in subscription.GetProfilesAsync())
            {
                if (tempProfile.Data.Id == profile.Data.Id)
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            Profile getProfile = await rg.GetProfiles().GetAsync(profileName);
            ResourceDataHelper.AssertValidProfile(profile, getProfile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().GetAsync(null));
        }
    }
}
