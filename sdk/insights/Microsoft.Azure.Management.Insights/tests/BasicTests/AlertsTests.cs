// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Xunit;

namespace Insights.Tests.BasicTests
{
    public class AlertsTests : TestBase
    {
        [Fact]
        public void GetIncidentTest()
        {
            var expectedIncident = GetIncidents().First();

            var serializedObject = expectedIncident.ToJson();
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetInsightsManagementClient(handler);

            var actualIncident = insightsClient.AlertRuleIncidents.Get(
                resourceGroupName: "rg1",
                ruleName: "r1",
                incidentName: "i1");

            AreEqual(expectedIncident, actualIncident);
        }

        private static List<Incident> GetIncidents()
        {
            return new List<Incident>
            {
                new Incident(
                    activatedTime: DateTime.UtcNow,
                    isActive: false,
                    name: "i1",
                    resolvedTime: DateTime.UtcNow,
                    ruleName: "r1"
                )
            };
        }

        private static void AreEqual(Incident exp, Incident act)
        {
            if (exp != null)
            {
                Assert.True(exp.ActivatedTime.HasValue);
                Assert.True(act.ActivatedTime.HasValue);
                Assert.Equal(exp.ActivatedTime.Value.ToUniversalTime(), act.ActivatedTime.Value.ToUniversalTime());
                Assert.Equal(exp.IsActive, act.IsActive);
                Assert.Equal(exp.Name, act.Name);

                Assert.True(exp.ResolvedTime.HasValue);
                Assert.True(act.ResolvedTime.HasValue);
                Assert.Equal(exp.ResolvedTime.Value.ToUniversalTime(), act.ResolvedTime.Value.ToUniversalTime());
                Assert.Equal(exp.RuleName, act.RuleName);
            }
        }

        [Fact]
        public void ListIncidentsTest()
        {
            var expectedIncidentsResponse = new List<Incident>
            {
                new Incident(
                    activatedTime: DateTime.Parse("2014-08-01T00:00:00Z"),
                    isActive: false,
                    name: "i1",
                    resolvedTime: DateTime.Parse("2014-08-01T00:00:00Z"),
                    ruleName: "r1"
                    )
            };

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", expectedIncidentsResponse.ToJson(), "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);

            var actualIncidents = insightsClient.AlertRuleIncidents.ListByAlertRule(
                resourceGroupName: "rg1",
                ruleName: "r1");

            AreEqual(expectedIncidentsResponse, actualIncidents.ToList());
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
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        [Fact]
        public void CreateOrUpdateRuleTest()
        {
            AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            var result = insightsClient.AlertRules.CreateOrUpdate(resourceGroupName: "rg1", ruleName: expectedParameters.Name, parameters: expectedParameters);

            AreEqual(expectedParameters, result);
        }

        [Fact]
        public void ListRulesTest()
        {
            var expResponse = GetRuleResourceCollection();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            var actualResponse = insightsClient.AlertRules.ListByResourceGroup(resourceGroupName: " rg1", odataQuery: "resourceUri eq 'resUri'");

            AreEqual(expResponse, actualResponse.ToList<AlertRuleResource>());
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
            Assert.NotNull(exp);
            Assert.NotNull(act);

            Assert.Equal(exp.Count, act.Count);

            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
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
            List<RuleAction> actions = new List<RuleAction>();
            actions.Add(new RuleEmailAction()
                    {
                        CustomEmails = new List<string>()
                        {
                            "emailid1"
                        },
                        SendToServiceOwners = true
                    });

            return new AlertRuleResource(
                location: "location",
                alertRuleResourceName: "name1",
                actions: actions,
                condition: new LocationThresholdRuleCondition()
                {
                    DataSource = new RuleMetricDataSource()
                    {
                        MetricName = "CPUPercentage",
                        ResourceUri = "resourceUri"
                    },
                    FailedLocationCount = 1,
                    WindowSize = TimeSpan.FromMinutes(30)
                },
                description: "description",
                isEnabled: true,
                lastUpdatedTime: DateTime.UtcNow,
                name: "name1",
                tags: new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                }
            );
        }

        private List<AlertRuleResource> GetRuleResourceCollection()
        {
            List<RuleAction> actions = new List<RuleAction>();
            actions.Add(new RuleEmailAction()
            {
                CustomEmails = new List<string>()
                        {
                            "eamil1"
                        },
                SendToServiceOwners = true
            });

            return new List<AlertRuleResource>
            {
                new AlertRuleResource(
                    id: "id1",
                    location: "location1",
                    name: "name1",
                    alertRuleResourceName: "name1",
                    actions: actions,
                    condition: new LocationThresholdRuleCondition()
                    {
                        DataSource = new RuleMetricDataSource()
                        {
                            MetricName = "CpuPercentage",
                            ResourceUri = "resUri1"
                        },
                        FailedLocationCount = 1,
                        WindowSize = TimeSpan.FromMinutes(30)
                    },
                    description: "description1",
                    isEnabled: true,
                    lastUpdatedTime: DateTime.UtcNow,
                    tags: new Dictionary<string, string>()
                    {
                        {"key1", "val1"}
                    }
                )
            };
        }

        private void AreEqual(IList<AlertRuleResource> exp, IList<AlertRuleResource> act)
        {
            if (exp != null)
            {
                Assert.True(exp.Count == act.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }
    }
}
