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
    public class MetricAlertsStatus : InsightsManagementClientMockedBase
    {
        public MetricAlertsStatus(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task MetricAlertsStatusListTest()
        {
            var MetricAlertsStatusList = new List<MetricAlertStatus>()
                                            { GetMetricAlertStatus() };
            var content = @"
{
    'value':[
                {
                    'name': 'name1',
                    'id': 'id1',
                    'type': 'Type1',
                    'properties': {
                'dimensions': { },
                        'status': 'status1',
                        'timestamp': '2014-04-15T21:06:11.7882792+00:00'
                    }
        }
    ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.MetricAlertsStatus.ListAsync("rg1", "rule1")).Value.Value;
            AreEqual(MetricAlertsStatusList, result);
        }

        private void AreEqual(List<MetricAlertStatus> exp, IReadOnlyList<MetricAlertStatus> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(MetricAlertStatus exp, MetricAlertStatus act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Type, act.Type);
            AreEqual(exp.Properties, act.Properties);
        }

        private void AreEqual(MetricAlertStatusProperties exp, MetricAlertStatusProperties act)
        {
            Assert.AreEqual(exp.Status, act.Status);
            Assert.AreEqual(exp.Timestamp, act.Timestamp);
        }

        [Test]
        public async Task MetricAlertsStatusListByNameTest()
        {
            var MetricAlertsStatusList = new List<MetricAlertStatus>()
                                            { GetMetricAlertStatus() };
            var content = @"
{
    'value':[
                {
                    'name': 'name1',
                    'id': 'id1',
                    'type': 'Type1',
                    'properties': {
                'dimensions': { },
                        'status': 'status1',
                        'timestamp': '2014-04-15T21:06:11.7882792+00:00'
                    }
        }
    ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.MetricAlertsStatus.ListByNameAsync("rg1","rule1","status1")).Value.Value;
            AreEqual(MetricAlertsStatusList, result);
        }

        private MetricAlertStatus GetMetricAlertStatus()
        {
            return new MetricAlertStatus("name1", "id1", "Type1",
                                               new MetricAlertStatusProperties(new Dictionary<string, string>(), "status1", DateTime.Parse("2014-04-15T21:06:11.7882792Z")));
        }
    }
}
