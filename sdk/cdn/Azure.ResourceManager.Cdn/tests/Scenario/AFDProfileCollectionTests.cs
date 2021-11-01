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
    public class AFDProfileCollectionTests : CdnManagementTestBase
    {
        public AFDProfileCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            Assert.AreEqual(AFDProfileName, AFDProfile.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(null, AFDProfile.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(AFDProfileName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            _ = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempAFDProfile in rg.GetProfiles().GetAllAsync())
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
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempAFDProfile in subscription.GetProfilesAsync())
            {
                if (tempAFDProfile.Data.Id == AFDProfile.Data.Id)
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
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            Profile getAFDProfile = await rg.GetProfiles().GetAsync(AFDProfileName);
            ResourceDataHelper.AssertValidProfile(AFDProfile, getAFDProfile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().GetAsync(null));
        }
    }
}
