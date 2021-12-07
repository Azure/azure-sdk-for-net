// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_AfdRules_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
#endregion Manage_AfdRules_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Samples
{
    public class Sample2_ManagingAfdRules
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateAfdRules()
        {
            #region Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
            // Create a new azure front door profile
            string AfdProfileName = "myAfdProfile";
            var input1 = new ProfileData("Global", new Sku { Name = SkuName.StandardAzureFrontDoor });
            ProfileCreateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(AfdProfileName, input1);
            Profile AfdProfile = lro1.Value;
            // Get the rule set collection from the specific azure front door profile and create a rule set
            string ruleSetName = "myAfdRuleSet";
            AfdRuleSetCreateOperation lro2 = await AfdProfile.GetAfdRuleSets().CreateOrUpdateAsync(ruleSetName);
            AfdRuleSet ruleSet = lro2.Value;
            // Get the rule collection from the specific rule set and create a rule
            string ruleName = "myAfdRule";
            AfdRuleData input3 = new AfdRuleData
            {
                Order = 1
            };
            input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
            input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
            {
                CacheDuration = "00:00:20"
            }));
            AfdRuleCreateOperation lro3 = await ruleSet.GetAfdRules().CreateOrUpdateAsync(ruleName, input3);
            AfdRule rule = lro3.Value;
            #endregion Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAfdRules()
        {
            #region Snippet:Managing_AfdRules_ListAllAzureFrontDoorRules
            // First we need to get the azure front door rule collection from the specific rule set
            Profile AfdProfile = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            AfdRuleSet ruleSet = await AfdProfile.GetAfdRuleSets().GetAsync("myAfdRuleSet");
            AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
            // With GetAllAsync(), we can get a list of the rule in the collection
            AsyncPageable<AfdRule> response = ruleCollection.GetAllAsync();
            await foreach (AfdRule rule in response)
            {
                Console.WriteLine(rule.Data.Name);
            }
            #endregion Snippet:Managing_AfdRules_ListAllAzureFrontDoorRules
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAfdRules()
        {
            #region Snippet:Managing_AfdRules_UpdateAnAzureFrontDoorRule
            // First we need to get the azure front door rule collection from the specific rule set
            Profile AfdProfile = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            AfdRuleSet ruleSet = await AfdProfile.GetAfdRuleSets().GetAsync("myAfdRuleSet");
            AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
            // Now we can get the rule with GetAsync()
            AfdRule rule = await ruleCollection.GetAsync("myAfdRule");
            // With UpdateAsync(), we can update the rule
            RuleUpdateOptions input = new RuleUpdateOptions
            {
                Order = 2
            };
            input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
            input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
            {
                CacheDuration = "00:00:30"
            }));
            AfdRuleUpdateOperation lro = await rule.UpdateAsync(input);
            rule = lro.Value;
            #endregion Snippet:Managing_AfdRules_UpdateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAfdRules()
        {
            #region Snippet:Managing_AfdRules_DeleteAnAzureFrontDoorRule
            // First we need to get the azure front door rule collection from the specific rule set
            Profile AfdProfile = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            AfdRuleSet ruleSet = await AfdProfile.GetAfdRuleSets().GetAsync("myAfdRuleSet");
            AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
            // Now we can get the rule with GetAsync()
            AfdRule rule = await ruleCollection.GetAsync("myAfdRule");
            // With DeleteAsync(), we can delete the rule
            await rule.DeleteAsync();
            #endregion Snippet:Managing_AfdRules_DeleteAnAzureFrontDoorRule
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
