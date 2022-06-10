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
    public class AfdRuleCollectionTests : CdnManagementTestBase
    {
        public AfdRuleCollectionTests(bool isAsync)
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
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            FrontDoorRuleResource afdRule = await CreateAfdRule(afdRuleSet, afdRuleName);
            Assert.AreEqual(afdRuleName, afdRule.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdRuleSet.GetFrontDoorRules().CreateOrUpdateAsync(WaitUntil.Completed, null, afdRule.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdRuleSet.GetFrontDoorRules().CreateOrUpdateAsync(WaitUntil.Completed, afdRuleName, null));
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
            FrontDoorRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            _ = await CreateAfdRule(afdRuleSet, afdRuleName);
            int count = 0;
            await foreach (var tempRule in afdRuleSet.GetFrontDoorRules().GetAllAsync())
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
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            FrontDoorRuleResource afdRule = await CreateAfdRule(afdRuleSet, afdRuleName);
            FrontDoorRuleResource getAfdRule = await afdRuleSet.GetFrontDoorRules().GetAsync(afdRuleName);
            ResourceDataHelper.AssertValidAfdRule(afdRule, getAfdRule);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdRuleSet.GetFrontDoorRules().GetAsync(null));
        }
    }
}
