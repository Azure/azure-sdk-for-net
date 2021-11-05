// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class MetricAlertsTest : InsightsManagementClientMockedBase
    {
        public MetricAlertsTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task MetricAlertsCreateTest()
        {
            var MetricAlertResourceExcept = GetMetricAlertResource();
            var content = @"
{
    'id': 'Id1',
    'name': 'name1',
    'type': 'type1',
    'location': 'location1',
    'tags': { },
    'properties':{
                'description': 'description',
        'severity': 1,
        'enabled': true,
        'scopes': [],
        'evaluationFrequency': 'PT0S',
        'windowSize': 'PT0S',
        'targetResourceType': 'tragetResourceType1',
        'targetResourceRegion': 'targetResourceRegion1',
        'criteria': {},
        'autoMitigate': true,
        'actions': [],
        'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00'
    }
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.MetricAlerts.CreateOrUpdateAsync("rg1","rule1", MetricAlertResourceExcept);
            AreEqual(MetricAlertResourceExcept, result);
        }

        private void AreEqual(MetricAlertResource exp, MetricAlertResource act)
        {
            Assert.AreEqual(exp.AutoMitigate, act.AutoMitigate);
            Assert.AreEqual(exp.Description, act.Description);
            Assert.AreEqual(exp.Enabled, act.Enabled);
            Assert.AreEqual(exp.EvaluationFrequency, act.EvaluationFrequency);
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.LastUpdatedTime, act.LastUpdatedTime);
            Assert.AreEqual(exp.Location, act.Location);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Severity, act.Severity);
            Assert.AreEqual(exp.TargetResourceRegion, act.TargetResourceRegion);
            Assert.AreEqual(exp.TargetResourceType, act.TargetResourceType);
            Assert.AreEqual(exp.Type, act.Type);
            Assert.AreEqual(exp.WindowSize, act.WindowSize);
        }

        [Test]
        public async Task MetricAlertsDeleteTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            await insightsClient.MetricAlerts.DeleteAsync("rg1","rule1");
        }

        [Test]
        public async Task MetricAlertsGetTest()
        {
            var MetricAlertResourceExcept = GetMetricAlertResource();
            var content = @"
{
    'id': 'Id1',
    'name': 'name1',
    'type': 'type1',
    'location': 'location1',
    'tags': { },
    'properties':{
                'description': 'description',
        'severity': 1,
        'enabled': true,
        'scopes': [],
        'evaluationFrequency': 'PT0S',
        'windowSize': 'PT0S',
        'targetResourceType': 'tragetResourceType1',
        'targetResourceRegion': 'targetResourceRegion1',
        'criteria': {},
        'autoMitigate': true,
        'actions': [],
        'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00'
    }
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.MetricAlerts.GetAsync("rg1", "rule1");
            AreEqual(MetricAlertResourceExcept, result);
        }

        [Test]
        public async Task MetricAlertsListByResourceGroupTest()
        {
            var MetricAlertResourceList = new List<MetricAlertResource>() { GetMetricAlertResource() };
            var content = @"
{
'value':[
            {
                'id': 'Id1',
                'name': 'name1',
                'type': 'type1',
                'location': 'location1',
                'tags': { },
                'properties':{
                            'description': 'description',
                    'severity': 1,
                    'enabled': true,
                    'scopes': [],
                    'evaluationFrequency': 'PT0S',
                    'windowSize': 'PT0S',
                    'targetResourceType': 'tragetResourceType1',
                    'targetResourceRegion': 'targetResourceRegion1',
                    'criteria': {},
                    'autoMitigate': true,
                    'actions': [],
                    'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00'
                }
            }
        ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.MetricAlerts.ListByResourceGroupAsync("rg1").ToEnumerableAsync();
            AreEqual(MetricAlertResourceList, result);
        }

        [Test]
        public async Task MetricAlertsListBySubscriptionTest()
        {
            var MetricAlertResourceList = new List<MetricAlertResource>() { GetMetricAlertResource() };
            var content = @"
{
'value':[
            {
                'id': 'Id1',
                'name': 'name1',
                'type': 'type1',
                'location': 'location1',
                'tags': { },
                'properties':{
                            'description': 'description',
                    'severity': 1,
                    'enabled': true,
                    'scopes': [],
                    'evaluationFrequency': 'PT0S',
                    'windowSize': 'PT0S',
                    'targetResourceType': 'tragetResourceType1',
                    'targetResourceRegion': 'targetResourceRegion1',
                    'criteria': {},
                    'autoMitigate': true,
                    'actions': [],
                    'lastUpdatedTime': '2014-04-15T21:06:11.7882792+00:00'
                }
            }
        ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.MetricAlerts.ListBySubscriptionAsync().ToEnumerableAsync();
            AreEqual(MetricAlertResourceList, result);
        }

        private void AreEqual(List<MetricAlertResource> exp, List<MetricAlertResource> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        public MetricAlertResource GetMetricAlertResource()
        {
            return new MetricAlertResource("Id1", "name1", "type1", "location1", new Dictionary<string, string>(), "description", 1, true, new List<string>(), new TimeSpan(), new TimeSpan(),
                                                "tragetResourceType1", "targetResourceRegion1", new MetricAlertCriteria(), true, new List<MetricAlertAction>(), DateTime.Parse("2014-04-15T21:06:11.7882792Z"));
        }
    }
}
