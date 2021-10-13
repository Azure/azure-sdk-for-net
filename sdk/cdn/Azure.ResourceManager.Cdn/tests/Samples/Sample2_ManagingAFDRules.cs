// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_AFDRules_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
#endregion Manage_AFDRules_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Samples
{
    public class Sample2_ManagingAFDRules
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateAFDRules()
        {
            #region Snippet:Managing_AFDRules_CreateAnAzureFrontDoorRule
            // Create a new azure front door profile
            string AFDProfileName = "myAFDProfile";
            var input1 = new ProfileData("Global", new Sku { Name = SkuName.StandardAzureFrontDoor });
            ProfileCreateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(AFDProfileName, input1);
            Profile AFDProfile = lro1.Value;
            // Get the rule set container from the specific azure front door profile and create a rule set
            string ruleSetName = "myAFDRuleSet";
            RuleSetCreateOperation lro2 = await AFDProfile.GetRuleSets().CreateOrUpdateAsync(ruleSetName);
            RuleSet ruleSet = lro2.Value;
            // Get the rule container from the specific rule set and create a rule
            string ruleName = "myAFDRule";
            RuleData input3 = new RuleData
            {
                Order = 1
            };
            input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
            input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
            {
                CacheDuration = "00:00:20"
            }));
            RuleCreateOperation lro3 = await ruleSet.GetRules().CreateOrUpdateAsync(ruleName, input3);
            Rule rule = lro3.Value;
            #endregion Snippet:Managing_AFDRules_CreateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAFDRules()
        {
            #region Snippet:Managing_AFDRules_ListAllAzureFrontDoorRules
            // First we need to get the rule container from the specific rule set
            Profile AFDProfile = await resourceGroup.GetProfiles().GetAsync("myAFDProfile");
            RuleSet ruleSet = await AFDProfile.GetRuleSets().GetAsync("myAFDRuleSet");
            RuleContainer ruleContainer = ruleSet.GetRules();
            // With GetAllAsync(), we can get a list of the rule in the container
            AsyncPageable<Rule> response = ruleContainer.GetAllAsync();
            await foreach (Rule rule in response)
            {
                Console.WriteLine(rule.Data.Name);
            }
            #endregion Snippet:Managing_AFDRules_ListAllAzureFrontDoorRules
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAFDRules()
        {
            #region Snippet:Managing_AFDRules_UpdateAnAzureFrontDoorRule
            // First we need to get the rule container from the specific rule set
            Profile AFDProfile = await resourceGroup.GetProfiles().GetAsync("myAFDProfile");
            RuleSet ruleSet = await AFDProfile.GetRuleSets().GetAsync("myAFDRuleSet");
            RuleContainer ruleContainer = ruleSet.GetRules();
            // Now we can get the rule with GetAsync()
            Rule rule = await ruleContainer.GetAsync("myAFDRule");
            // With UpdateAsync(), we can update the rule
            RuleUpdateParameters input = new RuleUpdateParameters
            {
                Order = 2
            };
            input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
            input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
            {
                CacheDuration = "00:00:30"
            }));
            RuleUpdateOperation lro = await rule.UpdateAsync(input);
            rule = lro.Value;
            #endregion Snippet:Managing_AFDRules_UpdateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAFDRules()
        {
            #region Snippet:Managing_AFDRules_DeleteAnAzureFrontDoorRule
            // First we need to get the rule container from the specific rule set
            Profile AFDProfile = await resourceGroup.GetProfiles().GetAsync("myAFDProfile");
            RuleSet ruleSet = await AFDProfile.GetRuleSets().GetAsync("myAFDRuleSet");
            RuleContainer ruleContainer = ruleSet.GetRules();
            // Now we can get the rule with GetAsync()
            Rule rule = await ruleContainer.GetAsync("myAFDRule");
            // With DeleteAsync(), we can delete the rule
            await rule.DeleteAsync();
            #endregion Snippet:Managing_AFDRules_DeleteAnAzureFrontDoorRule
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;

            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
