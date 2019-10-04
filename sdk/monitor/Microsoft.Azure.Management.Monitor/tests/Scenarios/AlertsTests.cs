// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using System.Globalization;

namespace Monitor.Tests.Scenarios
{
    public class AlertsTests : TestBase
    {
        private const string ResourceGroupName = "Rac46PostSwapRG";
        private const string RuleName = "chiricutin";
        private const string ResourceId = "/subscriptions/{0}/resourceGroups/" + ResourceGroupName + "/providers/microsoft.insights/alertrules/" + RuleName;
        private const string Location = "westus";

        private RecordedDelegatingHandler handler;

        public AlertsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void MetricBasedRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter(insightsClient.SubscriptionId);
                AlertRuleResource result = insightsClient.AlertRules.CreateOrUpdate(
                    resourceGroupName: ResourceGroupName,
                    ruleName: RuleName,
                    parameters: expectedParameters);

                if (!this.IsRecording)
                {
                    Check(result);
                }

                AlertRuleResource retrievedRule = insightsClient.AlertRules.Get(
                    resourceGroupName: ResourceGroupName,
                    ruleName: RuleName);

                if (!this.IsRecording)
                {
                    Check(retrievedRule);

                    Utilities.AreEqual(result, retrievedRule);
                }

                IEnumerable<AlertRuleResource> enumOfRules = insightsClient.AlertRules.ListByResourceGroup(
                    resourceGroupName: ResourceGroupName);

                if (!this.IsRecording)
                {
                    var listOfRules = enumOfRules.ToList();
                    var selected = listOfRules.Where(r => string.Equals(r.Id, retrievedRule.Id, StringComparison.OrdinalIgnoreCase)).ToList();

                    Assert.NotNull(selected);
                    Assert.NotEmpty(selected);
                    Assert.True(selected.Count == 1);
                    Utilities.AreEqual(retrievedRule, selected[0]);
                }

                var newTags = new Dictionary<string, string>()
                {
                    {"key2", "val2"}
                };

                // TODO: Update is requiring 'location', but it was not specified so.
                AlertRuleResourcePatch pathResource = new AlertRuleResourcePatch(
                    name: retrievedRule.Name,
                    isEnabled: !retrievedRule.IsEnabled,
                    tags: newTags,
                    actions: retrievedRule.Actions,
                    condition: retrievedRule.Condition,
                    description: retrievedRule.Description,
                    lastUpdatedTime: retrievedRule.LastUpdatedTime
                );

                AlertRuleResource updatedRule = null;
                Assert.Throws<ErrorResponseException>(
                    () => updatedRule = insightsClient.AlertRules.Update(
                        resourceGroupName: ResourceGroupName,
                        ruleName: RuleName,
                        alertRulesResource: pathResource));

                if (!this.IsRecording && updatedRule != null)
                {
                    Check(updatedRule);

                    Assert.NotEqual(retrievedRule.Tags, updatedRule.Tags);
                    Assert.True(retrievedRule.IsEnabled = !updatedRule.IsEnabled);
                    Assert.Equal(retrievedRule.Name, updatedRule.Name);
                    Assert.Equal(retrievedRule.Location, updatedRule.Location);
                    Assert.Equal(retrievedRule.Id, updatedRule.Id);
                }

                AlertRuleResource retrievedUpdatedRule = insightsClient.AlertRules.Get(
                    resourceGroupName: ResourceGroupName,
                    ruleName: RuleName);

                if (!this.IsRecording && updatedRule != null)
                {
                    Check(retrievedRule);

                    Utilities.AreEqual(updatedRule, retrievedUpdatedRule);
                }

                insightsClient.AlertRules.Delete(
                    resourceGroupName: ResourceGroupName,
                    ruleName: RuleName);

                Assert.Throws<CloudException>(
                    () => insightsClient.AlertRules.Get(
                            resourceGroupName: ResourceGroupName,
                            ruleName: RuleName));
            }
        }

        [Fact(Skip = "Possible error in the spec, using name instead of id for the incidents.")]
        [Trait("Category", "Scenario")]
        public void GetIncidentTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var actualIncidents = insightsClient.AlertRuleIncidents.ListByAlertRule(
                    resourceGroupName: ResourceGroupName,
                    ruleName: RuleName);

                var incidentsList = actualIncidents.ToList();
                if (incidentsList != null && incidentsList.Count > 0)
                {
                    var actualIncident = insightsClient.AlertRuleIncidents.Get(
                        resourceGroupName: ResourceGroupName,
                        ruleName: RuleName,
                        incidentName: "L3N1YnNjcmlwdGlvbnMvMDdjMGIwOWQtOWY2OS00ZTZlLThkMDUtZjU5ZjY3Mjk5Y2IyL3Jlc291cmNlR3JvdXBzL1JhYzQ2UG9zdFN3YXBSRy9wcm92aWRlcnMvbWljcm9zb2Z0Lmluc2lnaHRzL2FsZXJ0cnVsZXMvY2hpcmljdXRpbjA2MzYzNzEzNjQxNDc2ODQyMDc=");

                    if (!this.IsRecording)
                    {
                        var expectedIncident = GetIncidents(insightsClient.SubscriptionId).First();

                        Utilities.AreEqual(expectedIncident, actualIncident);
                    }
                }
            }
        }

        [Fact(Skip = "Fails because the alert rule does not exist.")]
        [Trait("Category", "Scenario")]
        public void ListGetIncidentsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                // NOTE: for this test to work the alert rule must exist
                var actualIncidents = insightsClient.AlertRuleIncidents.ListByAlertRule(
                    resourceGroupName: ResourceGroupName,
                    ruleName: RuleName);

                Assert.NotNull(actualIncidents);

                List<Incident> incidentsList = actualIncidents.ToList();

                if (!this.IsRecording)
                {
                    Assert.True(incidentsList.Count > 0, "List of incidents should not be 0 length.");
                    Assert.Equal(string.Format(provider: CultureInfo.InvariantCulture, format: ResourceId, args: insightsClient.SubscriptionId), incidentsList[0].RuleName, ignoreCase: true);
                }

                if (incidentsList.Count > 0)
                {
                    string incidentName = incidentsList[0].Name;

                    var actualIncident = insightsClient.AlertRuleIncidents.Get(
                        resourceGroupName: ResourceGroupName,
                        ruleName: RuleName,
                        incidentName: incidentName);

                    if (!this.IsRecording)
                    {
                        Utilities.AreEqual(incidentsList[0], actualIncident);
                    }
                }
            }
        }

        private static void Check(AlertRuleResource act)
        {
            if (act != null)
            {
                Assert.False(string.IsNullOrWhiteSpace(act.Name));
                Assert.Equal(act.Name, act.AlertRuleResourceName);
                Assert.False(string.IsNullOrWhiteSpace(act.Id));
                Assert.False(string.IsNullOrWhiteSpace(act.Location));
                Assert.False(string.IsNullOrWhiteSpace(act.Type));
            }
            else
            {
                // Guarantee failure, act should not be null
                Assert.NotNull(act);
            }
        }

        private static List<Incident> GetIncidents(string subscriptionId)
        {
            return new List<Incident>
            {
                new Incident(
                    activatedTime: new DateTime(2017,07,31,15,20,14,768,DateTimeKind.Utc),
                    isActive: false,
                    name: "",
                    resolvedTime: new DateTime(2017,07,31,15,25,15,672,DateTimeKind.Utc),
                    ruleName: string.Format(provider: CultureInfo.InvariantCulture, format: ResourceId, args: subscriptionId)
                )
            };
        }

        private AlertRuleResource GetCreateOrUpdateRuleParameter(string subscriptionId)
        {
            List<RuleAction> actions = new List<RuleAction>
            {
                new RuleEmailAction()
                {
                    CustomEmails = new List<string>()
                        {
                            "gu@ms.com"
                        },
                    SendToServiceOwners = true
                }
            };

            // Name and id won't be serialized since thwy are readonly
            return new AlertRuleResource(
                id: string.Format(provider: CultureInfo.InvariantCulture, format: ResourceId, args: subscriptionId),
                name: RuleName,
                location: Location,
                alertRuleResourceName: RuleName,
                actions: actions,
                condition: new ThresholdRuleCondition()
                {
                    DataSource = new RuleMetricDataSource()
                    {
                        MetricName = "Requests",
                        ResourceUri = string.Format(
                            provider: CultureInfo.InvariantCulture, 
                            format: "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/sites/alertruleTest",
                            args: new [] { subscriptionId, ResourceGroupName }),
                    },
                    OperatorProperty = ConditionOperator.GreaterThan,
                    Threshold = 2,
                    WindowSize = TimeSpan.FromMinutes(5),
                    TimeAggregation = TimeAggregationOperator.Total
                },
                description: "description",
                isEnabled: true,
                lastUpdatedTime: DateTime.UtcNow,
                tags: new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                }
            );
        }
    }
}
