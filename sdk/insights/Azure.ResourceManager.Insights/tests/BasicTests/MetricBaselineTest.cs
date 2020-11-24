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
    public class MetricBaselineTest : InsightsManagementClientMockedBase
    {
        public MetricBaselineTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task MetricAlertsStatusListTest()
        {
            var BaselineResponseExcept = GetBaselineResponse();
            var content = @"
{
    'id': 'id1',
    'type': 'type1',
    'name': {
                'value': 'value',
        'localizedValue': null
    },
    'properties':{
        'timespan': 'timespan1',
        'interval': 'PT0S',
        'aggregation': 'aggregation',
        'timestamps': [
            '2014-04-15T21:06:11.7882792+00:00'
        ],
        'baseline': [],
        'metadata': []
    }
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.MetricBaseline.GetAsync("resrui1", "metricname1")).Value;
            AreEqual(BaselineResponseExcept, result);
        }

        private void AreEqual(BaselineResponse exp, BaselineResponse act)
        {
            Assert.AreEqual(exp.Aggregation, act.Aggregation);
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.Interval, act.Interval);
            Assert.AreEqual(exp.Timespan, act.Timespan);
            Assert.AreEqual(exp.Type, act.Type);
            AreEqual(exp.Name, act.Name);
            AreEqual(exp.Timestamps, act.Timestamps);
        }

        private void AreEqual(IReadOnlyList<DateTimeOffset> exp, IReadOnlyList<DateTimeOffset> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(DateTimeOffset exp, DateTimeOffset act)
        {
            Assert.AreEqual(exp, act);
        }

        [Test]
        public async Task CalculateBaselineTest()
        {
            var CalculateBaselineResponseExcept = GetCalculateBaselineResponse();
            var content = @"
{
    'type': 'type',
    'timestamps': [],
    'baseline': [
        {
            'sensitivity': 'High',
            'lowThresholds': [
                2.13
            ],
            'highThresholds': [
                2.14
            ]
        }
    ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.MetricBaseline.CalculateBaselineAsync("rg1", new TimeSeriesInformation(new List<string>(), new List<double>()))).Value;
            AreEqual(CalculateBaselineResponseExcept, result);
        }

        private void AreEqual(CalculateBaselineResponse exp, CalculateBaselineResponse act)
        {
            AreEqual(exp.Baseline, act.Baseline);
            Assert.AreEqual(exp.Type, act.Type);
        }

        private void AreEqual(IReadOnlyList<Baseline> exp, IReadOnlyList<Baseline> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(Baseline exp, Baseline act)
        {
            AreEqual(exp.HighThresholds, act.HighThresholds);
            AreEqual(exp.LowThresholds,act.LowThresholds);
        }

        private void AreEqual(IReadOnlyList<double> exp, IReadOnlyList<double> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                Assert.AreEqual(exp[i], act[i]);
            }
        }

        private BaselineResponse GetBaselineResponse()
        {
            return new BaselineResponse("id1", "type1", new LocalizableString("value"), "timespan1", new TimeSpan(), "aggregation",
                                                    new List<DateTimeOffset>() { DateTime.Parse("2014-04-15T21:06:11.7882792Z") }, new List<Baseline>(), new List<BaselineMetadataValue>());
        }

        private CalculateBaselineResponse GetCalculateBaselineResponse()
        {
            return new CalculateBaselineResponse("type",
                    new List<Baseline>() { new Baseline(Sensitivity.High, new List<double>() { 2.13 }, new List<double>() { 2.14 }) });
        }
    }
}
