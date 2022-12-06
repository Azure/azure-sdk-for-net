// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_AfdRules_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
#endregion Manage_AfdRules_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Samples
{
    public class Sample2_ManagingFrontDoorRules
    {
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateAfdRules()
        {
            #region Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
            // Create a new azure front door profile
            string AfdProfileName = "myAfdProfile";
            var input1 = new ProfileData("Global", new CdnSku { Name = CdnSkuName.StandardAzureFrontDoor });
            ArmOperation<ProfileResource> lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, AfdProfileName, input1);
            ProfileResource AfdProfileResource = lro1.Value;
            // Get the rule set collection from the specific azure front door ProfileResource and create a rule set
            string ruleSetName = "myAfdRuleSet";
            ArmOperation<FrontDoorRuleSetResource> lro2 = await AfdProfileResource.GetFrontDoorRuleSets().CreateOrUpdateAsync(WaitUntil.Completed, ruleSetName);
            FrontDoorRuleSetResource ruleSet = lro2.Value;
            // Get the rule collection from the specific rule set and create a rule
            string ruleName = "myAfdRule";
            FrontDoorRuleData input3 = new FrontDoorRuleData
            {
                Order = 1
            };
            input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchCondition(RequestUriMatchConditionType.RequestUriCondition, RequestUriOperator.Any)));
            input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionProperties(CacheExpirationActionType.CacheExpirationAction, CacheBehaviorSetting.Override, CdnCacheLevel.All)
            {
                CacheDuration = new TimeSpan(0, 0, 20)
            }));
            ArmOperation<FrontDoorRuleResource> lro3 = await ruleSet.GetFrontDoorRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, input3);
            FrontDoorRuleResource rule = lro3.Value;
            #endregion Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAfdRules()
        {
            #region Snippet:Managing_AfdRules_ListAllAzureFrontDoorRules
            // First we need to get the azure front door rule collection from the specific rule set
            ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            FrontDoorRuleSetResource ruleSet = await AfdProfileResource.GetFrontDoorRuleSets().GetAsync("myAfdRuleSet");
            FrontDoorRuleCollection ruleCollection = ruleSet.GetFrontDoorRules();
            // With GetAllAsync(), we can get a list of the rule in the collection
            AsyncPageable<FrontDoorRuleResource> response = ruleCollection.GetAllAsync();
            await foreach (FrontDoorRuleResource rule in response)
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
            ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            FrontDoorRuleSetResource ruleSet = await AfdProfileResource.GetFrontDoorRuleSets().GetAsync("myAfdRuleSet");
            FrontDoorRuleCollection ruleCollection = ruleSet.GetFrontDoorRules();
            // Now we can get the rule with GetAsync()
            FrontDoorRuleResource rule = await ruleCollection.GetAsync("myAfdRule");
            // With UpdateAsync(), we can update the rule
            FrontDoorRulePatch input = new FrontDoorRulePatch
            {
                Order = 2
            };
            input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchCondition(RequestUriMatchConditionType.RequestUriCondition, RequestUriOperator.Any)));
            input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionProperties(CacheExpirationActionType.CacheExpirationAction, CacheBehaviorSetting.Override, CdnCacheLevel.All)
            {
                CacheDuration = new TimeSpan(0, 0, 30)
            }));
            ArmOperation<FrontDoorRuleResource> lro = await rule.UpdateAsync(WaitUntil.Completed, input);
            rule = lro.Value;
            #endregion Snippet:Managing_AfdRules_UpdateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAfdRules()
        {
            #region Snippet:Managing_AfdRules_DeleteAnAzureFrontDoorRule
            // First we need to get the azure front door rule collection from the specific rule set
            ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            FrontDoorRuleSetResource ruleSet = await AfdProfileResource.GetFrontDoorRuleSets().GetAsync("myAfdRuleSet");
            FrontDoorRuleCollection ruleCollection = ruleSet.GetFrontDoorRules();
            // Now we can get the rule with GetAsync()
            FrontDoorRuleResource rule = await ruleCollection.GetAsync("myAfdRule");
            // With DeleteAsync(), we can delete the rule
            await rule.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_AfdRules_DeleteAnAzureFrontDoorRule
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
