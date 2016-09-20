//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Newtonsoft.Json;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class Alerts : TestBase
    {
        #region ListRules

        private static AlertRuleResource ruleResource = new AlertRuleResource(
                id: "id1",
		        location: "location1",
		        name: "name1",
                actions: new List<RuleAction> {
                    new RuleEmailAction(
                        sendToServiceOwners: true,
                        customEmails: new List<string>
                        {
                            "eamil1",
                        }
                    )
                },
			    condition: new LocationThresholdRuleCondition(
				    dataSource: new RuleMetricDataSource(
					    metricName: "CpuPercentage",
                        resourceUri: "resUri1"
				    ),
				    failedLocationCount: 1,
				    windowSize: new TimeSpan(0,0,30,0)
			    ),
			    description: "description1",
			    isEnabled: true,
			    lastUpdatedTime: new DateTime(2016, 9, 15),
		        tags: new Dictionary<string, string> {
			        { "key1", "val1" }
		        }
            );

        private static List<AlertRuleResource> listRules = new List<AlertRuleResource>
        {
            ruleResource
        };

        #endregion

        [Fact]
        public void GetIncidentTest()
        {
            var expectedIncident = GetIncidents().First();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedIncident))
            };

            var handler = new RecordedDelegatingHandler(response);
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

            var baseContent = JsonConvert.SerializeObject(expectedIncidentsResponse);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{\"value\": ", baseContent, "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);

            var actualIncidents = insightsClient.AlertRuleIncidents.ListByAlertRule(
                resourceGroupName: "rg1",
                ruleName: "r1");

            AreEqual(expectedIncidentsResponse.ToList(), actualIncidents.ToList());
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

        //[Fact]
        public void CreateOrUpdateRuleTest()
        {
            RuleCreateOrUpdateParameters expectedParameters = GetCreateOrUpdateRuleParameter();

            var expectedResponseContent = JsonConvert.SerializeObject(ruleResource);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponseContent)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetInsightsManagementClient(handler);

            var result = insightsClient.AlertRules.CreateOrUpdate(resourceGroupName: "rg1", ruleName: expectedParameters.Name, parameters: expectedParameters);

            var actualParameters = handler.Request.FromJson<RuleCreateOrUpdateParameters>();

            AreEqual(expectedParameters, actualParameters);
        }

        //[Fact]
        public void ListRulesTest()
        {
            var expectedRuleResourceCollection = listRules;
            var baseContent = JsonConvert.SerializeObject(listRules);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{\"value\":", baseContent, "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);

            var actualResponse = insightsClient.AlertRules.ListByResourceGroup(resourceGroupName: " rg1", odataQuery: "resourceUri eq 'resUri'");

            AreEqual(expectedRuleResourceCollection, actualResponse.GetEnumerator());
        }

        [Fact]
        public void UpdateRuleTest()
        {
            // Not implemented because the method signature is the same as CreateOrUpdateRule
        }

        private void AreEqual(RuleCreateOrUpdateParameters exp, RuleCreateOrUpdateParameters act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Location, act.Location);
                AreEqual(exp.Tags, act.Tags);
                //Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.IsEnabled,act.IsEnabled);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
                Assert.Equal(exp.LastUpdatedTime, act.LastUpdatedTime);
            }
        }

        private void AreEqual(RuleResource exp, RuleResource act)
        {
            if (exp != null)
            {
                AreEqual(exp.Condition, act.Condition);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.IsEnabled, act.IsEnabled);
                Assert.True(exp.LastUpdatedTime.HasValue);
                Assert.True(act.LastUpdatedTime.HasValue);
                Assert.Equal(exp.LastUpdatedTime.Value.ToUniversalTime(), act.LastUpdatedTime.Value.ToUniversalTime());
                Assert.Equal(exp.Name, act.Name);
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

        private RuleCreateOrUpdateParameters GetCreateOrUpdateRuleParameter()
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

            return new RuleCreateOrUpdateParameters(
                location: "location",
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

        private List<RuleResource> GetRuleResourceCollection()
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

            return new List<RuleResource>
            {
                new RuleResource(
                    id: "id1",
                    location: "location1",
                    name: "name1",
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

        private void AreEqual(IList<RuleResource> exp, IEnumerator<RuleResource> act)
        {
            if (exp != null)
            {
                var actList = new List<RuleResource>();
                while (act.MoveNext())
                {
                    actList.Add(act.Current);
                }

                Assert.True(exp.Count == actList.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], actList[i]);
                }
            }
        }
    }
}
