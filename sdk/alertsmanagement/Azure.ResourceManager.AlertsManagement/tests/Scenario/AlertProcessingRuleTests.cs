// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.AlertsManagement.Models;
using System.Collections.Generic;
using System;
using Azure.ResourceManager.Models;
using NUnit.Framework.Constraints;
using Azure.ResourceManager.AlertsManagement.Tests.Helpers;

namespace Azure.ResourceManager.AlertsManagement.Tests.Scenario
{
    [TestFixture]
    public class AlertProcessingRuleTests : AlertsManagementManagementTestBase
    {
        public AlertProcessingRuleTests() : base(true)
        {
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task CreateAndUpdateAlertProcessingRule()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.WestUS);
            string resourceName = Recording.GenerateAssetName("AlertProcessingRule");

            List<string> scopes = new List<string>
            {
                "/subscriptions/042ebc40-492c-4e4e-a02a-c04b5ba7ee23"
            };

            ResourceIdentifier resourceIdentifier = new ResourceIdentifier("alertProcessingRule");

            // Create Alert processing Rule
            AlertProcessingRuleData alertProcessingRule = new AlertProcessingRuleData(
                resourceIdentifier,
                "AlertProcessingRuleTest",
                "Microsoft.AlertsManagement/actionRules",
                new SystemData(),
                tags: new Dictionary<string, string>(),
                "Global",
                new AlertProcessingRuleProperties(
                        scopes,
                        new List<AlertProcessingRuleCondition> { new AlertProcessingRuleCondition("Severity","Equals",new List<string> { "Sev2" }) },
                        null,
                        new List<AlertProcessingRuleAction> { new AlertProcessingRuleRemoveAllGroupsAction()},
                        null,
                        true)
                );

            var createAlertProcessingRuleOperation = await rg.GetAlertProcessingRules().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, alertProcessingRule);
            await createAlertProcessingRuleOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAlertProcessingRuleOperation.HasCompleted);
            Assert.IsTrue(createAlertProcessingRuleOperation.HasValue);

            // Get Alert processing rule by name
            AlertProcessingRuleResource fetchedAlertProcessingRule = await rg.GetAlertProcessingRules().GetAsync(resourceName);

            AlertsManagementTestUtilities.AreEqual(alertProcessingRule, fetchedAlertProcessingRule.Data);

            // Delete created alert processing rule
            //await fetchedAlertProcessingRule.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task FilterBySubscriptionGetAlertProcessingRulesTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            // Get alerts filtered for particular target resource
            AsyncPageable<AlertProcessingRuleResource> alertProcessingRules = subscription.GetAlertProcessingRulesAsync();

            await foreach (AlertProcessingRuleResource alertProcessingRule in alertProcessingRules)
            {
              Console.WriteLine(alertProcessingRule.Data.Name);
            }

            Assert.NotNull(alertProcessingRules);
        }

        [TestCase]
        public async Task FilterByResourceGroupGetAlertProcessingRulesTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            // Get alerts filtered for particular target resource
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync("ActionRulesRG");
            AsyncPageable<AlertProcessingRuleResource> alertProcessingRules = rg.GetAlertProcessingRules().GetAllAsync();

            await foreach (AlertProcessingRuleResource alertProcessingRule in alertProcessingRules)
            {
                Console.WriteLine(alertProcessingRule.Data.Name);
            }

            Assert.NotNull(alertProcessingRules);
        }
    }
}
