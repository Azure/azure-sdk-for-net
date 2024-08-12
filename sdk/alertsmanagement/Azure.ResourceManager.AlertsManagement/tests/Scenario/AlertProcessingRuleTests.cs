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
        public AlertProcessingRuleTests() : base(true)//, RecordedTestMode.Record)
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
                "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c"
            };

            ResourceIdentifier resourceIdentifier = new ResourceIdentifier("alertProcessingRule");

            // Create Alert processing Rule
            AlertProcessingRuleData alertProcessingRule = new AlertProcessingRuleData("Global")
            {
                Properties = new AlertProcessingRuleProperties(
                        scopes,
                        new List<AlertProcessingRuleAction> { new AlertProcessingRuleRemoveAllGroupsAction() })
                {
                    Conditions =
                    {
                        new AlertProcessingRuleCondition()
                        {
                            Field = "Severity",
                            Operator = "Equals",
                            Values =
                            {
                                "Sev2"
                            }
                        },
                    },
                    IsEnabled = true,
                }
            };

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
