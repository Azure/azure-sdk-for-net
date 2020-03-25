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

namespace AlertsManagement.Tests.ScenarioTests
{
    public class ActionRuleTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public ActionRuleTests() : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void FilterByParametersGetActionRulesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                // Get alerts filtered for particular target resource
                string severity = Severity.Sev3;
                string monitorService = MonitorService.Platform;
                var actionRules = alertsManagementClient.ActionRules.ListBySubscription(severity: severity, monitorService: monitorService);

                if (!this.IsRecording)
                {
                    IEnumerator<ActionRule> enumerator = actionRules.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ActionRule current = enumerator.Current;
                        if (current.Properties.Conditions?.MonitorService != null)
                        {
                            Assert.Contains(monitorService, current.Properties.Conditions.MonitorService.Values);
                        }

                        if (current.Properties.Conditions?.Severity != null)
                        {
                            Assert.Contains(severity, current.Properties.Conditions.Severity.Values);
                        }
                    }
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void FilterByResourceGroupGetActionRulesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                // Get alerts filtered for particular target resource
                string resourceGroupName = "ActionRules-Powershell-Test";
                var actionRules = alertsManagementClient.ActionRules.ListByResourceGroup(resourceGroupName: resourceGroupName);

                if (!this.IsRecording)
                {
                    Assert.NotNull(actionRules);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateAndDeleteActionRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                string resourceGroupName = "ActionRules-Powershell-Test";
                string actionRuleName = "ScenarioTest-ActionRule";

                // Create Action Rule
                ActionRule actionRule = new ActionRule(
                    location: "Global",
                    tags: new Dictionary<string, string>(),
                    properties: new Suppression (
                        scope: new Scope(
                            scopeType: ScopeType.ResourceGroup,
                            values: new List<string>
                            {
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab",
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs"
                            }
                        ),
                        conditions: new Conditions(
                            severity: new Condition(
                            operatorProperty: "Equals",
                                values: new List<string>
                                {
                                    "Sev2"
                                })
                        ),
                        suppressionConfig: new SuppressionConfig(
                            recurrenceType: "Once",
                            schedule: new SuppressionSchedule(
                                startDate: "12/09/2018",
                                endDate: "12/18/2018",
                                startTime: "06:00:00",
                                endTime: "14:00:00"
                            )
                        ),
                        description: "Test Supression Rule",
                        status: "Enabled"
                    )
                );
                 
                var createdActionRule = alertsManagementClient.ActionRules.CreateUpdate(resourceGroupName: resourceGroupName, actionRuleName: actionRuleName, actionRule: actionRule);

                // Get Action rule by name
                var fetchedActionRule = alertsManagementClient.ActionRules.GetByName(resourceGroupName: resourceGroupName, actionRuleName: actionRuleName);

                if (!this.IsRecording)
                {
                    ComparisonUtility.AreEqual(createdActionRule, fetchedActionRule);
                }

                // Delete created action rule
                bool? deleted = alertsManagementClient.ActionRules.Delete(resourceGroupName: resourceGroupName, actionRuleName: actionRuleName);

                if (!this.IsRecording)
                {
                    Assert.True(deleted);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateAndUpdateActionRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                string resourceGroupName = "ActionRules-Powershell-Test";
                string actionRuleName = "ScenarioTest-ActionRule";

                // Create Action Rule
                ActionRule actionRule = new ActionRule(
                    location: "Global",
                    tags: new Dictionary<string, string>(),
                    properties: new ActionGroup(
                        scope: new Scope(
                            scopeType: ScopeType.ResourceGroup,
                            values: new List<string>
                            {
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab",
                                "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs"
                            }
                        ),
                        conditions: new Conditions(
                            severity: new Condition(
                            operatorProperty: "Equals",
                                values: new List<string>
                                {
                                    "Sev2"
                                })
                        ),
                        actionGroupId: "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/actionrules-powershell-test/providers/microsoft.insights/actionGroups/powershell-test-ag",
                        description: "Test Supression Rule",
                        status: "Enabled"
                    )
                );

                var createdActionRule = alertsManagementClient.ActionRules.CreateUpdate(resourceGroupName: resourceGroupName, actionRuleName: actionRuleName, actionRule: actionRule);

                // Update Action Rule
                PatchObject patchObject = new PatchObject(
                        status: "Disabled"
                    );
                var updatePatch = alertsManagementClient.ActionRules.Update(resourceGroupName: resourceGroupName, actionRuleName: actionRuleName, actionRulePatch: patchObject);

                // Get again to verify update
                var fetchedActionRule = alertsManagementClient.ActionRules.GetByName(resourceGroupName: resourceGroupName, actionRuleName: actionRuleName);

                if (!this.IsRecording)
                {
                    Assert.Equal("Disabled", fetchedActionRule.Properties.Status);
                }
            }
        }
    }
}