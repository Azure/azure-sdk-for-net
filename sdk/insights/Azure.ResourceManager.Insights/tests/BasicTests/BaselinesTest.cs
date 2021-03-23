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
    public class BaselinesTest : InsightsManagementClientMockedBase
    {
        public BaselinesTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task BaselinesDeleteTest()
        {
            var SingleMetricBaselineList = new List<SingleMetricBaseline>() { new SingleMetricBaseline("Id1","type","name1","Timespan",new TimeSpan(),
                                                                                new List<TimeSeriesBaseline>(){
                                                                                    new TimeSeriesBaseline("aggregation",new List<DateTimeOffset>(),
                                                                                    new List<SingleBaseline>())}) };
            var content = @"
{
    'value':
[
    {
        'id': 'Id1',
        'type': 'type',
        'name': 'name1',
        'properties': 
            {
                'timespan': 'Timespan',
                'interval': 'PT0S',
                'namespace': null,
                'baselines': [
                    {
                        'aggregation': 'aggregation',
                        'dimensions': [],
                        'timestamps': [],
                        'data': [],
                        'metadata': []
    }
                ]
            }
    }
]
}
".Replace("'","\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.Baselines.ListAsync("resourceUri1").ToEnumerableAsync();
            AreEqual(SingleMetricBaselineList, result);
        }

        private void AreEqual(List<SingleMetricBaseline> exp ,List<SingleMetricBaseline> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(SingleMetricBaseline exp, SingleMetricBaseline act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Namespace, act.Namespace);
            Assert.AreEqual(exp.Timespan, act.Timespan);
            AreEqual(exp.Baselines, act.Baselines);
        }

        private void AreEqual(IReadOnlyList<TimeSeriesBaseline> exp, IReadOnlyList<TimeSeriesBaseline> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(TimeSeriesBaseline exp, TimeSeriesBaseline act)
        {
            Assert.AreEqual(exp.Aggregation,act.Aggregation);
        }
    }
}
