// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
//using System.Text;

namespace Monitor.Tests.Scenarios
{
    public class AlertsTests : TestBase
    {
        private const string ResourceGroupName = "Rac46PostSwapRG";
        private const string RuleName = "chiricutin";
        private const string ResourceId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/" + ResourceGroupName + "/providers/microsoft.insights/alertrules/" + RuleName;

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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter();

                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                //var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
                //serializedObject = serializedObject.Replace('\x22' + "name" + '\x22' + ": " + '\x22', "\"name\": \"" + expectedParameters.Name + "\",\"id\": \"" + expectedParameters.Id + "\",");

                //string path = "/subscriptions/5e3bf1b3-f462-4796-bd1b-cf2e638827a7/resourceGroups/rg1/providers/microsoft.insights/alertrules/name1?api-version=2016-03-01";
                //var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));

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
                    Assert.Equal(1, selected.Count);
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
                Assert.Throws(
                    typeof(ErrorResponseException),
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

                Assert.Throws(
                    typeof(CloudException),
                    () => insightsClient.AlertRules.Get(
                            resourceGroupName: ResourceGroupName,
                            ruleName: RuleName));
            }
        }

        [Fact(Skip = "Possible error in the spec, using name instead of id for the incidents.")]
        [Trait("Category", "Scenario")]
        public void GetIncidentTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expectedIncident = GetIncidents().First();

                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var actualIncident = insightsClient.AlertRuleIncidents.Get(
                    resourceGroupName: "Rac46PostSwapRG",
                    ruleName: "chiricutin",
                    incidentName: "L3N1YnNjcmlwdGlvbnMvMDdjMGIwOWQtOWY2OS00ZTZlLThkMDUtZjU5ZjY3Mjk5Y2IyL3Jlc291cmNlR3JvdXBzL1JhYzQ2UG9zdFN3YXBSRy9wcm92aWRlcnMvbWljcm9zb2Z0Lmluc2lnaHRzL2FsZXJ0cnVsZXMvY2hpcmljdXRpbjA2MzYzNzEzNjQxNDc2ODQyMDc=");

                if (!this.IsRecording)
                {
                    Utilities.AreEqual(expectedIncident, actualIncident);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListIncidentsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expectedIncidentsResponse = new List<Incident>
                {
                    new Incident(
                        activatedTime: DateTime.Parse("2017-07-31T10:20:14Z"),
                        isActive: false,
                        name: null,
                        resolvedTime: DateTime.Parse("2017-07-31T10:25:15Z"),
                        ruleName: "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/microsoft.insights/alertrules/chiricutin"
                        )
                };

                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var actualIncidents = insightsClient.AlertRuleIncidents.ListByAlertRule(
                    resourceGroupName: "Rac46PostSwapRG",
                    ruleName: "chiricutin");

                if (!this.IsRecording)
                {
                    Utilities.AreEqual(expectedIncidentsResponse, actualIncidents.ToList());
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

        private static List<Incident> GetIncidents()
        {
            return new List<Incident>
            {
                new Incident(
                    activatedTime: new DateTime(2017,07,31,15,20,14,768,DateTimeKind.Utc),
                    isActive: false,
                    name: "",
                    resolvedTime: new DateTime(2017,07,31,15,25,15,672,DateTimeKind.Utc),
                    ruleName: "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/microsoft.insights/alertrules/chiricutin"
                )
            };
        }

        private AlertRuleResource GetCreateOrUpdateRuleParameter()
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
                id: ResourceId,
                name: RuleName,
                location: "West US",
                alertRuleResourceName: RuleName,
                actions: actions,
                condition: new ThresholdRuleCondition()
                {
                    DataSource = new RuleMetricDataSource()
                    {
                        MetricName = "Requests",
                        ResourceUri = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest"
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

        private List<AlertRuleResource> GetRuleResourceCollection()
        {
            return new List<AlertRuleResource>
            {
                GetCreateOrUpdateRuleParameter()
            };
        }
    }
}
