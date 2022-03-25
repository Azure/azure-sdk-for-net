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
    public class AfdProfileCollectionTests : CdnManagementTestBase
    {
        public AfdProfileCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            Assert.AreEqual(afdProfileName, afdProfile.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, null, afdProfile.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, afdProfileName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            _ = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempAfdProfileResource in rg.GetProfiles().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            int count = 0;
            await foreach (var tempAfdProfileResource in subscription.GetProfilesAsync())
            {
                if (tempAfdProfile.Data.Id == afdProfile.Data.Id)
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
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            ProfileResource getAfdProfileResource = await rg.GetProfiles().GetAsync(afdProfileName);
            ResourceDataHelper.AssertValidProfile(afdProfile, getAfdProfile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().GetAsync(null));
        }
    }
}
