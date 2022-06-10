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
    public class AfdRuleSetCollectionTests : CdnManagementTestBase
    {
        public AfdRuleSetCollectionTests(bool isAsync)
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
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            FrontDoorRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            Assert.AreEqual(afdRuleSetName, afdRuleSet.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorRuleSets().CreateOrUpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            _ = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            int count = 0;
            await foreach (var tempRuleSet in afdProfileResource.GetFrontDoorRuleSets().GetAllAsync())
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
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            FrontDoorRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            FrontDoorRuleSetResource getAfdRuleSet = await afdProfileResource.GetFrontDoorRuleSets().GetAsync(afdRuleSetName);
            ResourceDataHelper.AssertValidAfdRuleSet(afdRuleSet, getAfdRuleSet);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorRuleSets().GetAsync(null));
        }
    }
}
