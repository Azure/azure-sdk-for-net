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
    public class Sample2_ManagingAfdRules
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
            ArmOperation<AfdRuleSetResource> lro2 = await AfdProfileResource.GetAfdRuleSets().CreateOrUpdateAsync(WaitUntil.Completed, ruleSetName);
            AfdRuleSetResource ruleSet = lro2.Value;
            // Get the rule collection from the specific rule set and create a rule
            string ruleName = "myAfdRule";
            AfdRuleData input3 = new AfdRuleData
            {
                Order = 1
            };
            input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersTypeName.DeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
            input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersTypeName.DeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
            {
                CacheDuration = new TimeSpan(0, 0, 20)
            }));
            ArmOperation<AfdRuleResource> lro3 = await ruleSet.GetAfdRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, input3);
            AfdRuleResource rule = lro3.Value;
            #endregion Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAfdRules()
        {
            #region Snippet:Managing_AfdRules_ListAllAzureFrontDoorRules
            // First we need to get the azure front door rule collection from the specific rule set
            ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
            AfdRuleSetResource ruleSet = await AfdProfileResource.GetAfdRuleSets().GetAsync("myAfdRuleSet");
            AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
            // With GetAllAsync(), we can get a list of the rule in the collection
            AsyncPageable<AfdRuleResource> response = ruleCollection.GetAllAsync();
            await foreach (AfdRuleResource rule in response)
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
            AfdRuleSetResource ruleSet = await AfdProfileResource.GetAfdRuleSets().GetAsync("myAfdRuleSet");
            AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
            // Now we can get the rule with GetAsync()
            AfdRuleResource rule = await ruleCollection.GetAsync("myAfdRule");
            // With UpdateAsync(), we can update the rule
            AfdRulePatch input = new AfdRulePatch
            {
                Order = 2
            };
            input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersTypeName.DeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
            input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersTypeName.DeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
            {
                CacheDuration = new TimeSpan(0, 0, 30)
            }));
            ArmOperation<AfdRuleResource> lro = await rule.UpdateAsync(WaitUntil.Completed, input);
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
            AfdRuleSetResource ruleSet = await AfdProfileResource.GetAfdRuleSets().GetAsync("myAfdRuleSet");
            AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
            // Now we can get the rule with GetAsync()
            AfdRuleResource rule = await ruleCollection.GetAsync("myAfdRule");
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
