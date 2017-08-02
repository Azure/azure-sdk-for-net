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
//using System.Text;

namespace Monitor.Tests.Scenarios
{
    public class AlertsTests : TestBase
    {
        private const string ResourceId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/microsoft.insights/alertrules/chiricutin";

        private RecordedDelegatingHandler handler;

        public AlertsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateOrUpdateRuleTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter();

                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                //var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
                //serializedObject = serializedObject.Replace('\x22' + "name" + '\x22' + ": " + '\x22', "\"name\": \"" + expectedParameters.Name + "\",\"id\": \"" + expectedParameters.Id + "\",");

                //string path = "/subscriptions/5e3bf1b3-f462-4796-bd1b-cf2e638827a7/resourceGroups/rg1/providers/microsoft.insights/alertrules/name1?api-version=2016-03-01";
                //var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));

                var result = insightsClient.AlertRules.CreateOrUpdate(
                    resourceGroupName: "Rac46PostSwapRG",
                    ruleName: expectedParameters.Name,
                    parameters: expectedParameters);

                if (!this.IsRecording)
                {
                    AreEqual(expectedParameters, result);
                }
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
                    AreEqual(expectedIncident, actualIncident);
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
                    AreEqual(expectedIncidentsResponse, actualIncidents.ToList());
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListRulesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expResponse = GetRuleResourceCollection();

                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var actualResponse = insightsClient.AlertRules.ListByResourceGroup(
                    resourceGroupName: "Rac46PostSwapRG");

                if (!this.IsRecording)
                {
                    AreEqual(expResponse, actualResponse.ToList<AlertRuleResource>());
                }
            }
        }

        [Fact(Skip = "Update is requiring 'location', but it was not specified so.")]
        [Trait("Category", "Scenario")]
        public void UpdateRulesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                AlertRuleResource resource = GetRuleResourceCollection().FirstOrDefault();
                resource.IsEnabled = false;
                resource.Tags = new Dictionary<string, string>()
                {
                    {"key2", "val2"}
                };

                AlertRuleResourcePatch pathResource = new AlertRuleResourcePatch(
                    name: resource.Name,
                    isEnabled: false,
                    tags: resource.Tags,
                    actions: resource.Actions,
                    condition: resource.Condition,
                    description: resource.Description,
                    lastUpdatedTime: resource.LastUpdatedTime
                );

                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var actualResponse = insightsClient.AlertRules.Update(
                    resourceGroupName: "Rac46PostSwapRG",
                    ruleName: resource.Name,
                    alertRulesResource: pathResource);

                if (!this.IsRecording)
                {
                    AreEqual(resource, actualResponse);
                }
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

        private static void AreEqual(Incident exp, Incident act)
        {
            if (exp != null)
            {
                Assert.True(exp.ActivatedTime.HasValue);
                Assert.True(act.ActivatedTime.HasValue);
                //Assert.Equal(exp.ActivatedTime.Value.ToUniversalTime(), act.ActivatedTime.Value.ToUniversalTime());
                //Assert.Equal(exp.IsActive, act.IsActive);
                Assert.Equal(exp.Name, act.Name);

                Assert.True(exp.ResolvedTime.HasValue);
                Assert.True(act.ResolvedTime.HasValue);
                //Assert.Equal(exp.ResolvedTime.Value.ToUniversalTime(), act.ResolvedTime.Value.ToUniversalTime());
                Assert.Equal(exp.RuleName, act.RuleName);
            }
        }

        private void AreEqual(IList<Incident> exp, IList<Incident> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(List<Incident> exp, IList<Incident> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(AlertRuleResource exp, AlertRuleResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Location, act.Location);
                AreEqual(exp.Tags, act.Tags);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.IsEnabled,act.IsEnabled);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
                //Assert.Equal(exp.LastUpdatedTime, act.LastUpdatedTime);
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(RuleCondition exp, RuleCondition act)
        {
            if (exp is LocationThresholdRuleCondition)
            {
                var expRuleCondition = exp as LocationThresholdRuleCondition;
                var actRuleCondition = act as LocationThresholdRuleCondition;

                AreEqual(expRuleCondition.DataSource, actRuleCondition.DataSource);
                Assert.Equal(expRuleCondition.FailedLocationCount, actRuleCondition.FailedLocationCount);
                Assert.Equal(expRuleCondition.WindowSize, actRuleCondition.WindowSize);
            }
            else if (exp is ThresholdRuleCondition)
            {
                var expRuleCondition = exp as ThresholdRuleCondition;
                var actRuleCondition = act as ThresholdRuleCondition;

                AreEqual(expRuleCondition.DataSource, actRuleCondition.DataSource);
                Assert.Equal(expRuleCondition.Threshold, actRuleCondition.Threshold);
                Assert.Equal(expRuleCondition.OperatorProperty, actRuleCondition.OperatorProperty);
                Assert.Equal(expRuleCondition.TimeAggregation, actRuleCondition.TimeAggregation);
                Assert.Equal(expRuleCondition.WindowSize, actRuleCondition.WindowSize);
            }
        }

        private void AreEqual(RuleDataSource exp, RuleDataSource act)
        {
            if (exp is RuleMetricDataSource)
            {
                var expMetricDataSource = exp as RuleMetricDataSource;
                var actMetricDataSource = act as RuleMetricDataSource;

                Assert.Equal(expMetricDataSource.MetricName, actMetricDataSource.MetricName);
                Assert.Equal(expMetricDataSource.ResourceUri, actMetricDataSource.ResourceUri);
            }
        }

        private void AreEqual(IList<RuleAction> exp, IList<RuleAction> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(RuleAction exp, RuleAction act)
        {
            if (exp is RuleEmailAction)
            {
                var expEmailRuleAction = exp as RuleEmailAction;
                var actEmailRuleAction = act as RuleEmailAction;

                AreEqual(expEmailRuleAction.CustomEmails, actEmailRuleAction.CustomEmails);
                Assert.Equal(expEmailRuleAction.SendToServiceOwners, actEmailRuleAction.SendToServiceOwners);
            }
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
                name: "chiricutin",
                location: "West US",
                alertRuleResourceName: "chiricutin",
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

        private void AreEqual(IList<AlertRuleResource> exp, IList<AlertRuleResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }
    }
}
