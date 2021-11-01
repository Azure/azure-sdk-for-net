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
    public class AFDRuleSetCollectionTests : CdnManagementTestBase
    {
        public AFDRuleSetCollectionTests(bool isAsync)
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
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            Assert.AreEqual(ruleSetName, ruleSet.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetRuleSets().CreateOrUpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            _ = await CreateRuleSet(AFDProfile, ruleSetName);
            int count = 0;
            await foreach (var tempRuleSet in AFDProfile.GetRuleSets().GetAllAsync())
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
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            RuleSet getRuleSet = await AFDProfile.GetRuleSets().GetAsync(ruleSetName);
            ResourceDataHelper.AssertValidRuleSet(ruleSet, getRuleSet);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetRuleSets().GetAsync(null));
        }
    }
}
