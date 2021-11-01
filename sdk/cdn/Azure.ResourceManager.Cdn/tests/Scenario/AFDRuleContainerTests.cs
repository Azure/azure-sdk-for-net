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
    public class AFDRuleContainerTests : CdnManagementTestBase
    {
        public AFDRuleContainerTests(bool isAsync)
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
            string ruleName = Recording.GenerateAssetName("AFDRule");
            Rule rule = await CreateRule(ruleSet, ruleName);
            Assert.AreEqual(ruleName, rule.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await ruleSet.GetRules().CreateOrUpdateAsync(null, rule.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await ruleSet.GetRules().CreateOrUpdateAsync(ruleName, null));
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
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string ruleName = Recording.GenerateAssetName("AFDRule");
            _ = await CreateRule(ruleSet, ruleName);
            int count = 0;
            await foreach (var tempRule in ruleSet.GetRules().GetAllAsync())
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
            string ruleName = Recording.GenerateAssetName("AFDRule");
            Rule rule = await CreateRule(ruleSet, ruleName);
            Rule getRule = await ruleSet.GetRules().GetAsync(ruleName);
            ResourceDataHelper.AssertValidRule(rule, getRule);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await ruleSet.GetRules().GetAsync(null));
        }
    }
}
