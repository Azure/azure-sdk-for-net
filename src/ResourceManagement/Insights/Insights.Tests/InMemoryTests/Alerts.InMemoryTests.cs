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
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class Alerts : TestBase
    {
        #region ListRules

        private const string ListRulesContent =
            @"{
	            'value': [{
		            'id': 'id1',
		            'location': 'location1',
		            'name': 'name1',
		            'properties': {
			            'action': {
				            'odata.type': 'Microsoft.Azure.Management.Insights.Models.RuleEmailAction',
				            'customEmails': ['eamil1'],
				            'sendToServiceOwners': true
			            },
			            'condition': {
				            'odata.type': 'Microsoft.Azure.Management.Insights.Models.LocationThresholdRuleCondition',
				            'dataSource': {
					            'odata.type': 'Microsoft.Azure.Management.Insights.Models.RuleMetricDataSource',
					            'metricName': 'CpuPercentage',
					            'metricNamespace': '',
					            'resourceUri': 'resUri1'
				            },
				            'failedLocationCount': 1,
				            'windowSize': 'PT30M'
			            },
			            'description': 'description1',
			            'isEnabled': true,
			            'lastUpdatedTime': '2014-08-25T18:56:21.4653748Z',
			            'name': 'name1'
		            },
		            'tags': {
			            'key1': 'val1'
		            }
	            }]
            }";

        #endregion

        [Fact]
        public void GetIncidentTest()
        {
            var expectedIncident = GetIncidents().First();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedIncident.ToJson())
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);

            var actualIncident = insightsClient.AlertOperations.GetIncident(
                resourceGroupName: "rg1",
                ruleName: "r1",
                incidentName: "i1");

            AreEqual(expectedIncident, actualIncident.Incident);
        }

        private static List<Incident> GetIncidents()
        {
            return new List<Incident>
            {
                new Incident
                {
                    ActivatedTime = DateTime.UtcNow,
                    IsActive = false,
                    Name = "i1",
                    ResolvedTime = DateTime.UtcNow,
                    RuleName = "r1"
                }
            };
        }

        private static void AreEqual(Incident exp, Incident act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ActivatedTime.ToUniversalTime(), act.ActivatedTime.ToUniversalTime());
                Assert.Equal(exp.IsActive, act.IsActive);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.ResolvedTime.Value.ToUniversalTime(), act.ResolvedTime.Value.ToUniversalTime());
                Assert.Equal(exp.RuleName, act.RuleName);
            }
        }

        [Fact]
        public void ListIncidentsTest()
        {
            var expectedIncidentsResponse = new IncidentListResponse()
            {
                Value = new List<Incident>()
                {
                    new Incident()
                    {
                        ActivatedTime = DateTime.Parse("2014-08-01T00:00:00Z"),
                        IsActive = false,
                        Name = "i1",
                        ResolvedTime = DateTime.Parse("2014-08-01T00:00:00Z"),
                        RuleName = "r1"
                    }
                }
            };

            string listIncidentsContent = @"{
                'value': [{
	                'activatedTime': '2014-08-01T00:00:00Z',
	                'isActive': false,
	                'name': 'i1',
	                'resolvedTime': '2014-08-01T00:00:00Z',
	                'ruleName': 'r1'
                }]
            }";

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(listIncidentsContent)
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);

            IncidentListResponse actualIncidents = insightsClient.AlertOperations.ListIncidentsForRule(
                resourceGroupName: "rg1",
                ruleName: "r1");

            AreEqual(expectedIncidentsResponse.Value, actualIncidents.Value);
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
            RuleCreateOrUpdateParameters expectedParameters = GetCreateOrUpdateRuleParameter();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);

            insightsClient.AlertOperations.CreateOrUpdateRule(resourceGroupName: "rg1", parameters: expectedParameters);

            var actualParameters = JsonExtensions.FromJson<RuleCreateOrUpdateParameters>(handler.Request);

            AreEqual(expectedParameters, actualParameters);
        }

        [Fact]
        public void ListRulesTest()
        {
            RuleResourceCollection expectedRuleResourceCollection = JsonExtensions.FromJson<RuleResourceCollection>(ListRulesContent);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ListRulesContent)
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);
            RuleListResponse actualResponse = insightsClient.AlertOperations.ListRules(resourceGroupName: " rg1", targetResourceUri: "resUri");

            AreEqual(expectedRuleResourceCollection, actualResponse.RuleResourceCollection);
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
                AreEqual(exp.Properties, act.Properties);
                AreEqual(exp.Tags, act.Tags);
            }
        }

        private void AreEqual(Rule exp, Rule act)
        {
            if (exp != null)
            {
                AreEqual(exp.Condition, act.Condition);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.IsEnabled, act.IsEnabled);
                Assert.Equal(exp.LastUpdatedTime.ToUniversalTime(), act.LastUpdatedTime.ToUniversalTime());
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
                Assert.Equal(expMetricDataSource.MetricNamespace, actMetricDataSource.MetricNamespace);
                Assert.Equal(expMetricDataSource.ResourceUri, actMetricDataSource.ResourceUri);
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

            return new RuleCreateOrUpdateParameters
            {
                Location = "location",
                Properties = new Rule()
                {
                    Actions = actions,
                    Condition = new LocationThresholdRuleCondition()
                    {
                        DataSource = new RuleMetricDataSource()
                        {
                            MetricName = "CPUPercentage",
                            MetricNamespace = "",
                            ResourceUri = "resourceUri"
                        },
                        FailedLocationCount = 1,
                        WindowSize = TimeSpan.FromMinutes(30)
                    },
                    Description = "description",
                    IsEnabled = true,
                    LastUpdatedTime = DateTime.UtcNow,
                    Name = "name1"
                },
                Tags = new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                }
            };
        }

        private RuleResourceCollection GetRuleResourceCollection()
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

            return new RuleResourceCollection
            {
                Value = new List<RuleResource>
                {
                    new RuleResource
                    {
                        Id = "id1",
                        Location = "location1",
                        Name = "name1",
                        Properties = new Rule()
                        {
                            Actions = actions,
                            Condition = new LocationThresholdRuleCondition()
                            {
                                DataSource = new RuleMetricDataSource()
                                {
                                    MetricNamespace = "",
                                    MetricName = "CpuPercentage",
                                    ResourceUri = "resUri1"
                                },
                                FailedLocationCount = 1,
                                WindowSize = TimeSpan.FromMinutes(30)
                            },
                            Description = "description1",
                            IsEnabled = true,
                            LastUpdatedTime = DateTime.UtcNow,
                            Name = "name1"
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"key1", "val1"}
                        }
                    }
                }
            };
        }

        private void AreEqual(RuleResourceCollection exp, RuleResourceCollection act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Value.Count; i++)
                {
                    AreEqual(exp.Value[i], act.Value[i]);
                }
            }
        }

        private void AreEqual(RuleResource exp, RuleResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.Name, act.Name);
                AreEqual(exp.Tags, act.Tags);
                AreEqual(exp.Properties, act.Properties);
            }
        }
    }
}
