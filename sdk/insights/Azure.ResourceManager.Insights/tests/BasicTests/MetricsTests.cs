// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class MetricsTests : InsightsManagementClientMockedBase
    {
        public MetricsTests(bool isAsync)
            : base(isAsync)
        { }

        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        [Test]
        public async Task GetMetricDefinitionsTest()
        {
            IList<MetricDefinition> expectedMetricDefinitionCollection = GetMetricDefinitionCollection(ResourceUri);
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
{
   'value':
    [
        {
            'isDimensionRequired': true,
            'resourceId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm',
            'namespace': null,
            'name': {
                    'value': 'CpuPercentage',
                'localizedValue': 'CPU Percentage'
            },
            'unit': 'Bytes',
            'primaryAggregationType': 'Average',
            'supportedAggregationTypes': [],
            'metricAvailabilities': [
                {
                    'timeGrain': 'PT10M',
                    'retention': 'P30D'
                }
            ],
            'id': null,
            'dimensions': []
        }
    ]
}
".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualMetricDefinitions = await insightsClient.MetricDefinitions.ListAsync(resourceUri: ResourceUri, cancellationToken: new CancellationToken()).ToEnumerableAsync();
            AreEqual(expectedMetricDefinitionCollection, actualMetricDefinitions);
        }

        [Test]
        public async Task GetMetricsTest()
        {
            IList<Metric> expectedMetricCollection = GetMetricCollection(ResourceUri);
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(string.Concat("{ \"value\":", expectedMetricCollection.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualMetrics = (await insightsClient.Metrics.ListAsync(resourceUri: ResourceUri,cancellationToken: CancellationToken.None)).Value.Value;

            AreEqual(expectedMetricCollection, actualMetrics.ToList<Metric>());
        }

        private void AreEqual(IList<Metric> exp, IList<Metric> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(Metric exp, Metric act)
        {
            if (exp != null)
            {
                AreEqual(exp.Name, act.Name);
                Assert.AreEqual(exp.Unit, act.Unit);
            }
        }

        private IList<Metric> GetMetricCollection(string resourceId)
        {
            return new List<Metric>
            {
                new Metric(null,null,
                           new LocalizableString("CpuPercentage","CPU Percentage"),
                           Unit.Percent,
                           new List<TimeSeriesElement>
                           {
                                new TimeSeriesElement(new List<MetadataValue>(),
                                                      new List<MetricValue>{
                                                                                new MetricValue(
                                                                                               DateTime.Parse("2014-08-20T12:15:23.00Z"),10.0,10.0,10.0,10.0,1)})})
            };
        }

        private IList<MetricDefinition> GetMetricDefinitionCollection(string resourceUri)
        {
            var metriAvailabilities = new List<MetricAvailability>()
            {
                new MetricAvailability(timeGrain: TimeSpan.FromMinutes(10), retention: TimeSpan.FromDays(30))
            };

            MetricDefinition[] metricDefinitions = new MetricDefinition[1];
            metricDefinitions[0] = new MetricDefinition(true, resourceUri, null, new LocalizableString("CpuPercentage", "CPU Percentage"), Unit.Bytes, AggregationType.Average, new List<AggregationType>(),
            metriAvailabilities, null, new List<LocalizableString>());
            return metricDefinitions;
        }

        private static void AreEqual(IList<MetricDefinition> exp, IList<MetricDefinition> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(MetricDefinition exp, MetricDefinition act)
        {
            if (exp != null)
            {
                AreEqual(exp.Name, act.Name);
                Assert.AreEqual(exp.ResourceId, act.ResourceId);
                Assert.AreEqual(exp.Unit, act.Unit);
                Assert.AreEqual(exp.PrimaryAggregationType, act.PrimaryAggregationType);

                if (exp.MetricAvailabilities != null)
                {
                    for (int i = 0; i < exp.MetricAvailabilities.Count; i++)
                    {
                        AreEqual(exp.MetricAvailabilities[i], act.MetricAvailabilities[i]);
                    }
                }
            }
        }

        private static void AreEqual(MetricAvailability exp, MetricAvailability act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Retention, act.Retention);
                Assert.AreEqual(exp.TimeGrain, act.TimeGrain);
            }
        }
    }
}
