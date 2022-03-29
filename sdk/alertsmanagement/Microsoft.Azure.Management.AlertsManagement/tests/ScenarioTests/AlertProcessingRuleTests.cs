// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AlertsManagement.Tests.Helpers;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Action = Microsoft.Azure.Management.AlertsManagement.Models.Action;

namespace AlertsManagement.Tests.ScenarioTests
{
    public class AlertProcessingRuleTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public AlertProcessingRuleTests() : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void FilterBySubscriptionGetAlertProcessingRulesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                // Get alerts filtered for particular target resource
                var alertProcessingRules = alertsManagementClient.AlertProcessingRules.ListBySubscription();
                
                if (!this.IsRecording)
                {
                    Assert.NotNull(alertProcessingRules);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void FilterByResourceGroupGetAlertProcessingRulesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                // Get alerts filtered for particular target resource
                string resourceGroupName = "ActionRules-Powershell-Test";
                var alertProcessingRules = alertsManagementClient.AlertProcessingRules.ListByResourceGroup(resourceGroupName: resourceGroupName);

                if (!this.IsRecording)
                {
                    Assert.NotNull(alertProcessingRules);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateAndDeleteAlertProcessingRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                string resourceGroupName = "ActionRules-Powershell-Test";
                string alertProcessingRuleName = "ScenarioTest-AlertProcessingRule";

                // Create Alert Processing Rule
                AlertProcessingRule alertProcessingRule = new AlertProcessingRule(
                    location: "Global",
                    tags: new Dictionary<string, string>(),
                    properties: new AlertProcessingRuleProperties(
                        scopes: new List<string>
                            {
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab",
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs"
                            },
                        conditions: new List<Condition>
                        {
                            new Condition(
                                field: "Severity",
                                operatorProperty: "Equals",
                                values: new List<string>
                                {
                                    "Sev2"
                                })
                        },
                        schedule: new Schedule(
                            effectiveFrom: "2019-12-22T11:00:00",
                            effectiveUntil: "2020-09-24T11:00:00",
                            timeZone: "Pacific Standard Time",
                            recurrences: new List<Recurrence>
                            { 
                                new DailyRecurrence (startTime: "06:00:00", endTime: "14:00:00")
                            }
                        ),
                        actions: new List<Action> { new RemoveAllActionGroups() },
                        description: "Test Supression Rule",
                        enabled: true
                    )
                );

                var createdAlertProcessingRule = alertsManagementClient.AlertProcessingRules.CreateOrUpdate(resourceGroupName: resourceGroupName, alertProcessingRuleName: alertProcessingRuleName, alertProcessingRule: alertProcessingRule);

                // Get Alert processing rule by name
                var fetchedAlertProcessingRule = alertsManagementClient.AlertProcessingRules.GetByName(resourceGroupName: resourceGroupName, alertProcessingRuleName: alertProcessingRuleName);

                if (!this.IsRecording)
                {
                    ComparisonUtility.AreEqual(createdAlertProcessingRule, fetchedAlertProcessingRule);
                }

                // Delete created alert processing rule
                alertsManagementClient.AlertProcessingRules.Delete(resourceGroupName: resourceGroupName, alertProcessingRuleName: alertProcessingRuleName);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateAndUpdateAlertProcessingRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                string resourceGroupName = "ActionRules-Powershell-Test";
                string alertProcessingRuleName = "ScenarioTest-AlertProcessingRule";

                // Create Alert processing Rule
                AlertProcessingRule alertProcessingRule = new AlertProcessingRule(
                    location: "Global",
                    tags: new Dictionary<string, string>(),
                    properties: new AlertProcessingRuleProperties(
                        scopes: new List<string>
                            {
                             "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab",
                             "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs"
                             },
                        conditions: new List<Condition>
                        {
                            new Condition(
                                field: "Severity",
                                operatorProperty: "Equals",
                                values: new List<string>
                                {
                                    "Sev2"
                                })
                        },
                        schedule: new Schedule(
                            effectiveFrom: "2019-12-22T11:00:00",
                            effectiveUntil: "2020-09-24T11:00:00",
                            timeZone: "Pacific Standard Time",
                            recurrences: new List<Recurrence>
                            {
                                new DailyRecurrence (startTime: "06:00:00", endTime: "14:00:00")
                            }
                        ),
                        actions: new List<Action> 
                        {
                            new AddActionGroups(new List<string> 
                            {
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/actionrules-powershell-test/providers/microsoft.insights/actionGroups/powershell-test-ag"
                            })
                        },
                        description: "Test Add Action Group Rule",
                        enabled: true
                    )
                );

                var createdAlertProcessingRule = alertsManagementClient.AlertProcessingRules.CreateOrUpdate(resourceGroupName: resourceGroupName, alertProcessingRuleName: alertProcessingRuleName, alertProcessingRule: alertProcessingRule);

                // Update Alert processing Rule
                PatchObject patchObject = new PatchObject(
                        enabled: false
                    );
                var updatePatch = alertsManagementClient.AlertProcessingRules.Update(resourceGroupName: resourceGroupName, alertProcessingRuleName: alertProcessingRuleName, alertProcessingRulePatch: patchObject);

                // Get again to verify update
                var fetchedAlertProcessingRule = alertsManagementClient.AlertProcessingRules.GetByName(resourceGroupName: resourceGroupName, alertProcessingRuleName: alertProcessingRuleName);

                if (!this.IsRecording)
                {
                    Assert.False(fetchedAlertProcessingRule.Properties.Enabled);
                }
            }
        }
    }
}