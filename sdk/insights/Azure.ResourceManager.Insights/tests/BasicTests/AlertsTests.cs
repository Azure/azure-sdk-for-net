// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class AlertsTests : InsightsManagementClientMockedBase
    {
        public AlertsTests(bool isAsync)
            : base(isAsync)
        { }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [Test]
        public async Task CreateOrUpdateRuleTest()
        {
            AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'namePropertiesName': 'name1',
                    'id': null,
                    'name': 'name1',
                    'type': null,
                    'location': 'location',
                    'tags': {
                                'key1': 'val1'
                    },
                    'properties': {
                        'description': 'description',
                        'isEnabled': true,
                        'condition': {
                                        'dataSource': {
                                                        'resourceUri': 'resourceUri'
                                                      }
                                     },
                        'actions': [
                            {
                                'odata.type':'Microsoft.Azure.Management.Insights.Models.RuleEmailAction',
                                'sendToServiceOwners': true,
                                'customEmails': [
                                    'emailid1'
                                ]
                    }
                        ],
                        'lastUpdatedTime': '2020-09-22T07:43:19.9383848+00:00'
                    }
                }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.AlertRules.CreateOrUpdateAsync(resourceGroupName: "rg1", ruleName: expectedParameters.Name, parameters: expectedParameters)).Value;
            AreEqual(expectedParameters, result);
        }

        [Test]
        public async Task AlertRulesDeleteTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            await insightsClient.AlertRules.DeleteAsync("rg1", "rule1");
        }

        [Test]
        public async Task AlertRulesGetTest()
        {
            AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'namePropertiesName': 'name1',
                    'id': null,
                    'name': 'name1',
                    'type': null,
                    'location': 'location',
                    'tags': {
                                'key1': 'val1'
                    },
                    'properties': {
                        'description': 'description',
                        'isEnabled': true,
                        'condition': {
                                        'dataSource': {
                                                        'resourceUri': 'resourceUri'
                                                      }
                                     },
                        'actions': [
                            {
                                'odata.type':'Microsoft.Azure.Management.Insights.Models.RuleEmailAction',
                                'sendToServiceOwners': true,
                                'customEmails': [
                                    'emailid1'
                                ]
                    }
                        ],
                        'lastUpdatedTime': '2020-09-22T07:43:19.9383848+00:00'
                    }
                }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.AlertRules.GetAsync("rg1","rule1")).Value;
            AreEqual(expectedParameters, result);
        }

        [Test]
        public async Task GetIncidentTest()
        {
            var expectedIncident = GetIncidents().First();

            var serializedObject = expectedIncident.ToJson();

            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(serializedObject);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualIncident = (await insightsClient.AlertRuleIncidents.GetAsync(
                resourceGroupName: "rg1",
                ruleName: "r1",
                incidentName: "i1")).Value;
            AreEqual(expectedIncident, actualIncident);
        }

        private static void AreEqual(Incident exp, Incident act)
        {
            if (exp != null)
            {
                Assert.True(exp.ActivatedTime.HasValue);
                Assert.True(act.ActivatedTime.HasValue);
                Assert.AreEqual(exp.ActivatedTime.Value.ToUniversalTime(), act.ActivatedTime.Value.ToUniversalTime());
                Assert.AreEqual(exp.IsActive, act.IsActive);
                Assert.AreEqual(exp.Name, act.Name);

                Assert.True(exp.ResolvedTime.HasValue);
                Assert.True(act.ResolvedTime.HasValue);
                Assert.AreEqual(exp.ResolvedTime.Value.ToUniversalTime(), act.ResolvedTime.Value.ToUniversalTime());
                Assert.AreEqual(exp.RuleName, act.RuleName);
            }
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

        [Test]
        public async Task ListIncidentsTest()
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
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(string.Concat("{ \"value\":", expectedIncidentsResponse.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualIncidents = await insightsClient.AlertRuleIncidents.ListByAlertRuleAsync(
                resourceGroupName: "rg1",
                ruleName: "r1").ToEnumerableAsync();

            AreEqual(expectedIncidentsResponse, actualIncidents.ToList());
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

        private AlertRuleResource GetCreateOrUpdateRuleParameter()
        {
            List<RuleAction> actions = new List<RuleAction>();
            actions.Add(new RuleEmailAction("Microsoft.Azure.Management.Insights.Models.RuleEmailAction", true, new List<string>()
                        {
                            "emailid1"
                        })
            );
            return new AlertRuleResource(null, "name1", null,
                location: "location",
                namePropertiesName: "name1",
                actions: actions,
                condition: new RuleCondition(null, new RuleDataSource()
                {
                    ResourceUri = "resourceUri"
                }),
                description: "description",
                isEnabled: true,
                lastUpdatedTime: DateTime.UtcNow,
                tags: new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                }
            );
        }

        [Test]
        public async Task AlertRulesListByResourceGroupTest()
        {
            var expResponse = GetRuleResourceCollection();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                            'value': [
                                {
                                    'namePropertiesName': 'name1',
                                    'id': 'id1',
                                    'name': 'name1',
                                    'type': null,
                                    'location': 'location1',
                                    'tags': {
                                            'key1': 'val1'
                                    },
                                    'properties': {
                                            'description': 'description1',
                                        'isEnabled': true,
                                        'condition': {
                                                'dataSource': {
                                                    'resourceUri': 'resourceUri'
                                                }
                                            },
                                        'actions': [
                                            {
                                                'odata.type':'Microsoft.Azure.Management.Insights.Models.RuleEmailAction',
                                                'sendToServiceOwners': true,
                                                'customEmails': [
                                                    'eamil1'
                                                ]
                            }
                                        ],
                                        'lastUpdatedTime': '2020-09-22T09:16:06.5637048+00:00'
                                    }
                                }
                            ]
                        }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);

            var actualResponse = await insightsClient.AlertRules.ListByResourceGroupAsync("rg1").ToEnumerableAsync();

            AreEqual(expResponse, actualResponse.ToList<AlertRuleResource>());
        }

        [Test]
        public async Task AlertRulesListBySubscriptionTest()
        {
            var expResponse = GetRuleResourceCollection();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                            'value': [
                                {
                                    'namePropertiesName': 'name1',
                                    'id': 'id1',
                                    'name': 'name1',
                                    'type': null,
                                    'location': 'location1',
                                    'tags': {
                                            'key1': 'val1'
                                    },
                                    'properties': {
                                            'description': 'description1',
                                        'isEnabled': true,
                                        'condition': {
                                                'dataSource': {
                                                    'resourceUri': 'resourceUri'
                                                }
                                            },
                                        'actions': [
                                            {
                                                'odata.type':'Microsoft.Azure.Management.Insights.Models.RuleEmailAction',
                                                'sendToServiceOwners': true,
                                                'customEmails': [
                                                    'eamil1'
                                                ]
                            }
                                        ],
                                        'lastUpdatedTime': '2020-09-22T09:16:06.5637048+00:00'
                                    }
                                }
                            ]
                        }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualResponse = await insightsClient.AlertRules.ListBySubscriptionAsync().ToEnumerableAsync();
            AreEqual(expResponse, actualResponse.ToList<AlertRuleResource>());
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

        private List<AlertRuleResource> GetRuleResourceCollection()
        {
            List<RuleAction> actions = new List<RuleAction>();
            actions.Add(new RuleEmailAction("Microsoft.Azure.Management.Insights.Models.RuleEmailAction", true, new List<string>()
                        {
                            "eamil1"
                        })
            );
            return new List<AlertRuleResource>
            {
                new AlertRuleResource(
                    id: "id1",
                    location: "location1",
                    name: "name1",
                    type:null,
                    namePropertiesName: "name1",
                    actions: actions,
                    condition: new RuleCondition(null, new RuleDataSource()
                    {
                       ResourceUri = "resourceUri"
                    }),
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

        private void AreEqual(AlertRuleResource exp, AlertRuleResource act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Location, act.Location);
                AreEqual(exp.Tags, act.Tags);
                Assert.AreEqual(exp.Name, act.Name);
                Assert.AreEqual(exp.Description, act.Description);
                Assert.AreEqual(exp.IsEnabled, act.IsEnabled);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
            }
        }

        private void AreEqual(RuleCondition exp, RuleCondition act)
        {
            Assert.AreEqual(exp.DataSource.ResourceUri, act.DataSource.ResourceUri);
        }

        private void AreEqual(IList<RuleAction> exp, IList<RuleAction> act)
        {
            Assert.NotNull(exp);
            Assert.NotNull(act);

            Assert.AreEqual(exp.Count, act.Count);

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
                Assert.AreEqual(expEmailRuleAction.SendToServiceOwners, actEmailRuleAction.SendToServiceOwners);
            }
        }
    }
}
