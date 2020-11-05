// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class ScheduledQueryRulesTest : InsightsManagementClientMockedBase
    {
        public ScheduledQueryRulesTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task ScheduledQueryRulesCreateOrUpdateTest()
        {
            var LogSearchRuleResourceExcept = GetLogSearchRuleResource();
            var content = @"
{
    'properties':
        {
                'description': 'Description1',
            'enabled': 'False',
            'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00',
            'provisioningState': 'ProvisonStateValue',
            'source': {
                    'query': 'query1',
                'authorizedResources': [],
                'dataSourceId': 'dataSource1',
                'queryType': 'QueryTypevalue'
            },
            'schedule': {
                'frequencyInMinutes': 1,
                'timeWindowInMinutes': 2
            },
            'action': {
                'odata.type':'odataType1'
}
        },
    'id': 'Id1',
    'name': 'name1',
    'type': 'Type1',
    'location': 'location1',
    'tags': {}
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.ScheduledQueryRules.CreateOrUpdateAsync("resourceGroupName1", "rule1", LogSearchRuleResourceExcept)).Value;
            AreEqual(LogSearchRuleResourceExcept, result);
        }

        [Test]
        public async Task ScheduledQueryRulesDeleteTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            await insightsClient.ScheduledQueryRules.DeleteAsync("resourceGroupName1", "rule1");
        }

        [Test]
        public async Task ScheduledQueryRulesGetTest()
        {
            var LogSearchRuleResourceExcept = GetLogSearchRuleResource();
            var ss = LogSearchRuleResourceExcept.ToJson();
            var content = @"
{
    'properties':
        {
                'description': 'Description1',
            'enabled': 'False',
            'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00',
            'provisioningState': 'ProvisonStateValue',
            'source': {
                    'query': 'query1',
                'authorizedResources': [],
                'dataSourceId': 'dataSource1',
                'queryType': 'QueryTypevalue'
            },
            'schedule': {
                'frequencyInMinutes': 1,
                'timeWindowInMinutes': 2
            },
            'action': {
                'odata.type':'odataType1'
}
        },
    'id': 'Id1',
    'name': 'name1',
    'type': 'Type1',
    'location': 'location1',
    'tags': {}
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.ScheduledQueryRules.GetAsync("resourceGroupName1", "rule1")).Value;
            AreEqual(LogSearchRuleResourceExcept, result);
        }

        [Test]
        public async Task ScheduledQueryRulesListByResourceGroupTest()
        {
            var LogSearchRuleResourceExceptList = new List<LogSearchRuleResource>() { GetLogSearchRuleResource() };
            var content = @"
{
    'value':[
                {
                    'properties':
                        {
                                'description': 'Description1',
                            'enabled': 'False',
                            'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00',
                            'provisioningState': 'ProvisonStateValue',
                            'source': {
                                    'query': 'query1',
                                'authorizedResources': [],
                                'dataSourceId': 'dataSource1',
                                'queryType': 'QueryTypevalue'
                            },
                            'schedule': {
                                'frequencyInMinutes': 1,
                                'timeWindowInMinutes': 2
                            },
                            'action': {
                                'odata.type':'odataType1'
                }
                        },
                    'id': 'Id1',
                    'name': 'name1',
                    'type': 'Type1',
                    'location': 'location1',
                    'tags': {}
                }
            ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ScheduledQueryRules.ListByResourceGroupAsync("resourceGroupName1").ToEnumerableAsync();
            AreEqual(LogSearchRuleResourceExceptList, result);
        }

        [Test]
        public async Task ScheduledQueryRulesListBySubscriptionTest()
        {
            var LogSearchRuleResourceExceptList = new List<LogSearchRuleResource>() { GetLogSearchRuleResource() };
            var content = @"
{
    'value':[
                {
                    'properties':
                        {
                                'description': 'Description1',
                            'enabled': 'False',
                            'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00',
                            'provisioningState': 'ProvisonStateValue',
                            'source': {
                                    'query': 'query1',
                                'authorizedResources': [],
                                'dataSourceId': 'dataSource1',
                                'queryType': 'QueryTypevalue'
                            },
                            'schedule': {
                                'frequencyInMinutes': 1,
                                'timeWindowInMinutes': 2
                            },
                            'action': {
                                'odata.type':'odataType1'
                }
                        },
                    'id': 'Id1',
                    'name': 'name1',
                    'type': 'Type1',
                    'location': 'location1',
                    'tags': {}
                }
            ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ScheduledQueryRules.ListBySubscriptionAsync().ToEnumerableAsync();
            AreEqual(LogSearchRuleResourceExceptList, result);
        }

        private void AreEqual(List<LogSearchRuleResource> exp, List<LogSearchRuleResource> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(LogSearchRuleResource exp, LogSearchRuleResource act)
        {
            Assert.AreEqual(exp.Description, act.Description);
            Assert.AreEqual(exp.Enabled.Value, act.Enabled.Value);
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.LastUpdatedTime, act.LastUpdatedTime);
            Assert.AreEqual(exp.Location, act.Location);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.ProvisioningState.Value, act.ProvisioningState.Value);
            Assert.AreEqual(exp.Type, act.Type);
            Assert.AreEqual(exp.Action.OdataType, act.Action.OdataType);
            AreEqual(exp.Schedule, act.Schedule);

            AreEqual(exp.Source, act.Source);
            AreEqual(exp.Tags, act.Tags);
        }

        private void AreEqual(Schedule exp, Schedule act)
        {
            Assert.AreEqual(exp.FrequencyInMinutes, act.FrequencyInMinutes);
            Assert.AreEqual(exp.TimeWindowInMinutes, act.TimeWindowInMinutes);
        }

        private void AreEqual(Source exp, Source act)
        {
            AreEqual(exp.AuthorizedResources, act.AuthorizedResources);
            Assert.AreEqual(exp.DataSourceId, act.DataSourceId);
            Assert.AreEqual(exp.Query, act.Query);
            Assert.AreEqual(exp.QueryType.Value, act.QueryType.Value);
        }

        private LogSearchRuleResource GetLogSearchRuleResource()
        {
            return new LogSearchRuleResource("Id1", "name1", "Type1", "location1", new Dictionary<string, string>(), "Description1", Enabled.False, DateTime.Parse("2014-04-15T21:06:11.7882792Z"), new ProvisioningState("ProvisonStateValue"),
                                                new Source("query1", new List<string>(), "dataSource1", new QueryType("QueryTypevalue")), new Schedule(1, 2), new Models.Action("odataType1"));
        }
    }
}
