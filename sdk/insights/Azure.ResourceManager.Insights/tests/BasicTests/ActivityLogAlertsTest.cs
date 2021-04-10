// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class ActivityLogAlertsTest : InsightsManagementClientMockedBase
    {
        public ActivityLogAlertsTest(bool isAsync)
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
        public async Task ActivityLogAlertsCreateOrUpdateTest()
        {
            var expectActivityLogAlertResource = GetActivityLogAlertResource();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
                    {
                        'id': 'Id',
                        'name': 'Name',
                        'type': 'Type',
                        'location': 'West us',
                        'tags': { },
                        'properties':
                        {
                                    'scopes': [],
                            'enabled': true,
                            'condition': {
                                'allOf': []
                        },
                            'actions': {
                                'actionGroups': []
                    },
                            'description': 'Description'
                        }
                    }
                    ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.ActivityLogAlerts.CreateOrUpdateAsync("rg1", "activityLog1", expectActivityLogAlertResource)).Value;
            AreEqual(expectActivityLogAlertResource, result);
        }

        private void AreEqual(ActivityLogAlertResource exp, ActivityLogAlertResource act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Location, act.Location);
            Assert.AreEqual(exp.Type, act.Type);
            Assert.AreEqual(exp.Description, act.Description);
        }

        [Test]
        public async Task ActivityLogAlertsDeleteTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            await insightsClient.ActivityLogAlerts.DeleteAsync("rg1", "activityLog1");
        }

        [Test]
        public async Task ActivityLogAlertsGetTest()
        {
            var expectActivityLogAlertResource = GetActivityLogAlertResource();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
                    {
                        'id': 'Id',
                        'name': 'Name',
                        'type': 'Type',
                        'location': 'West us',
                        'tags': { },
                        'properties':
                        {
                                    'scopes': [],
                            'enabled': true,
                            'condition': {
                                'allOf': []
                        },
                            'actions': {
                                'actionGroups': []
                    },
                            'description': 'Description'
                        }
                    }
                    ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ActivityLogAlerts.GetAsync("rg1", "activityLog1");
            AreEqual(expectActivityLogAlertResource, result);
        }

        [Test]
        public async Task ActivityLogAlertsListByResourceGroupTest()
        {
            var ActivityLogAlertResourceList = new List<ActivityLogAlertResource>() { GetActivityLogAlertResource() };
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
'value':[
                {
                        'id': 'Id',
                        'name': 'Name',
                        'type': 'Type',
                        'location': 'West us',
                        'tags': { },
                        'properties':
                        {
                                    'scopes': [],
                            'enabled': true,
                            'condition': {
                                'allOf': []
                        },
                            'actions': {
                                'actionGroups': []
                    },
                            'description': 'Description'
                        }
                    }
]
}".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ActivityLogAlerts.ListByResourceGroupAsync("rg1").ToEnumerableAsync();
            AreEqual(ActivityLogAlertResourceList, result);
        }

        private void AreEqual(List<ActivityLogAlertResource> exp, List<ActivityLogAlertResource> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        [Test]
        public async Task ActivityLogAlertsListBySubscriptionIdTest()
        {
            var ActivityLogAlertResourceList = new List<ActivityLogAlertResource>() { GetActivityLogAlertResource() };
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
'value':[
{
                        'id': 'Id',
                        'name': 'Name',
                        'type': 'Type',
                        'location': 'West us',
                        'tags': { },
                        'properties':
                        {
                                    'scopes': [],
                            'enabled': true,
                            'condition': {
                                'allOf': []
                        },
                            'actions': {
                                'actionGroups': []
                    },
                            'description': 'Description'
                        }
                    }
]
}".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ActivityLogAlerts.ListBySubscriptionIdAsync().ToEnumerableAsync();
            AreEqual(ActivityLogAlertResourceList, result);
        }

        private ActivityLogAlertResource GetActivityLogAlertResource()
        {
            var ActivityLogAlert = new ActivityLogAlertResource("Id", "Name", "Type", "West us",
                                                       new Dictionary<string, string>(),
                                                       new List<string>(), true,
                                                       new ActivityLogAlertAllOfCondition(new List<ActivityLogAlertLeafCondition>()),
                                                       new ActivityLogAlertActionList(), "Description");
            return ActivityLogAlert;
        }
    }
}
