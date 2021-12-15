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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            AfdRule afdRule = await CreateAfdRule(afdRuleSet, afdRuleName);
            Assert.AreEqual(afdRuleName, afdRule.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdRuleSet.GetAfdRules().CreateOrUpdateAsync(null, afdRule.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdRuleSet.GetAfdRules().CreateOrUpdateAsync(afdRuleName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            _ = await CreateAfdRule(afdRuleSet, afdRuleName);
            int count = 0;
            await foreach (var tempRule in afdRuleSet.GetAfdRules().GetAllAsync())
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
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            AfdRule afdRule = await CreateAfdRule(afdRuleSet, afdRuleName);
            AfdRule getAfdRule = await afdRuleSet.GetAfdRules().GetAsync(afdRuleName);
            ResourceDataHelper.AssertValidAfdRule(afdRule, getAfdRule);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdRuleSet.GetAfdRules().GetAsync(null));
        }
    }
}
