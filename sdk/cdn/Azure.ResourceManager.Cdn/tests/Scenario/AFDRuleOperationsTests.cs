// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AFDRuleOperationsTests : CdnManagementTestBase
    {
        public AFDRuleOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string ruleName = Recording.GenerateAssetName("AFDRule");
            Rule rule = await CreateRule(ruleSet, ruleName);
            await rule.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rule.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string ruleName = Recording.GenerateAssetName("AFDRule");
            Rule rule = await CreateRule(ruleSet, ruleName);
            RuleUpdateParameters updateParameters = new RuleUpdateParameters
            {
                Order = 2
            };
            updateParameters.Conditions.Add(ResourceDataHelper.CreateDeliveryRuleCondition());
            updateParameters.Actions.Add(ResourceDataHelper.UpdateDeliveryRuleOperation());
            var lro = await rule.UpdateAsync(updateParameters);
            Rule updatedRule = lro.Value;
            ResourceDataHelper.AssertRuleUpdate(updatedRule, updateParameters);
        }
    }
}
