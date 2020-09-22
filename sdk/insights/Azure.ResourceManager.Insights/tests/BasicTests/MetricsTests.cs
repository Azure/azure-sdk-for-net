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
            mockResponse.SetContent(string.Concat("{ \"value\":", expectedMetricDefinitionCollection.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualMetricDefinitions = await insightsClient.MetricDefinitions.ListAsync(resourceUri: ResourceUri, cancellationToken: new CancellationToken()).ToEnumerableAsync();
            Assert.AreEqual(expectedMetricDefinitionCollection, actualMetricDefinitions.ToList<MetricDefinition>());
        }

        [Test]
        public async Task GetMetricsTest()
        {
            IList<Metric> expectedMetricCollection = GetMetricCollection(ResourceUri);
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(string.Concat("{ \"value\":", expectedMetricCollection.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            //var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<Metric>("timeGrain eq duration'PT1M' and startTime eq 2014-01-01T06:00:00Z and endTime eq 2014-01-10T06:00:00Z");
            var actualMetrics = (await insightsClient.Metrics.ListAsync(resourceUri: ResourceUri,cancellationToken: CancellationToken.None)).Value;

            //need to do
            //Assert.AreEqual(expectedMetricCollection, actualMetrics.ToList<Metric>());
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
                                new TimeSeriesElement(null,
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
            metricDefinitions[0] = new MetricDefinition(null, resourceUri, null, new LocalizableString("CpuPercentage", "CPU Percentage"), Unit.Bytes, AggregationType.Average, null,
            metriAvailabilities, null, null);
            return metricDefinitions;
        }
    }
}
