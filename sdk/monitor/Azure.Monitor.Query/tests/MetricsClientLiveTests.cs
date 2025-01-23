// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsClientLiveTests : RecordedTestBase<MonitorQueryTestEnvironment>
    {
        private MetricsTestData _testData;

        public MetricsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MetricsClient CreateMetricsClient()
        {
            return InstrumentClient(new MetricsClient(
                new Uri(TestEnvironment.ConstructMetricsClientUri()),
                TestEnvironment.Credential,
                InstrumentClientOptions(new MetricsClientOptions()
                {
                    Audience = TestEnvironment.GetMetricsClientAudience()
                })
            ));
        }

        [SetUp]
        public void SetUp()
        {
            _testData = new MetricsTestData(TestEnvironment, Recording.UtcNow);
        }

        [RecordedTest]
        public async Task MetricsQueryResourcesAsync()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts").ConfigureAwait(false);

            Assert.AreEqual(200, metricsResultsResponse.GetRawResponse().Status);
            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            Assert.AreEqual(1, metricsQueryResults.Values.Count);
            Assert.AreEqual(TestEnvironment.StorageAccountId + "/providers/Microsoft.Insights/metrics/Ingress", metricsQueryResults.Values[0].Metrics[0].Id);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", metricsQueryResults.Values[0].Namespace);
            for (int i = 0; i < metricsQueryResults.Values.Count; i++)
            {
                foreach (MetricResult value in metricsQueryResults.Values[i].Metrics)
                {
                    for (int j = 0; j < value.TimeSeries.Count; j++)
                    {
                        Assert.GreaterOrEqual(value.TimeSeries[j].Values[i].Total, 0);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task MetricsQueryResourcesWithStartEndTimeRangeAsync()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            var timeRange = new QueryTimeRange(
                start: Recording.UtcNow.Subtract(TimeSpan.FromHours(4)),
                end: Recording.UtcNow
            );

            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { TimeRange = timeRange} ).ConfigureAwait(false);

            Assert.AreEqual(200, metricsResultsResponse.GetRawResponse().Status);
            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            Assert.AreEqual(1, metricsQueryResults.Values.Count);
            Assert.AreEqual(TestEnvironment.StorageAccountId + "/providers/Microsoft.Insights/metrics/Ingress", metricsQueryResults.Values[0].Metrics[0].Id);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", metricsQueryResults.Values[0].Namespace);
        }

        [RecordedTest]
        public async Task MetricsQueryResourcesWithStartDurationTimeRangeAsync()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            var timeRange = new QueryTimeRange(
                start: Recording.UtcNow.Subtract(TimeSpan.FromHours(4)),
                duration: TimeSpan.FromHours(4)
            );

            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { TimeRange = timeRange }).ConfigureAwait(false);

            Assert.AreEqual(200, metricsResultsResponse.GetRawResponse().Status);
            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            Assert.AreEqual(1, metricsQueryResults.Values.Count);
            Assert.AreEqual(TestEnvironment.StorageAccountId + "/providers/Microsoft.Insights/metrics/Ingress", metricsQueryResults.Values[0].Metrics[0].Id);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", metricsQueryResults.Values[0].Namespace);
        }

        [RecordedTest]
        [SyncOnly]
        public void MetricsQueryResourcesWithEndDurationTimeRange()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            var timeRange = new QueryTimeRange(
                end: Recording.UtcNow,
                duration: TimeSpan.FromHours(4)
            );

            Assert.Throws<AggregateException>(() =>
                client.QueryResources(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { TimeRange = timeRange }));
        }

        [RecordedTest]
        public async Task MetricsQueryResourcesWithDurationTimeRangeAsync()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            var timeRange = new QueryTimeRange(
                duration: TimeSpan.FromHours(4)
            );

            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { TimeRange = timeRange }).ConfigureAwait(false);

            Assert.AreEqual(200, metricsResultsResponse.GetRawResponse().Status);
            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            Assert.AreEqual(1, metricsQueryResults.Values.Count);
            Assert.AreEqual(TestEnvironment.StorageAccountId + "/providers/Microsoft.Insights/metrics/Ingress", metricsQueryResults.Values[0].Metrics[0].Id);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", metricsQueryResults.Values[0].Namespace);
        }

        [Test]
        [SyncOnly]
        public void MetricsQueryResourcesInvalid()
        {
            MetricsClient client = CreateMetricsClient();

            Assert.Throws<ArgumentException>(() =>
                client.QueryResources(
                resourceIds: new List<ResourceIdentifier>(),
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts"));
        }

        [RecordedTest]
        public async Task MetricsQueryResourcesWithStartTimeRangeAsync()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;
            // If only starttime is specified, then endtime defaults to the current time.
            DateTimeOffset start = Recording.UtcNow.Subtract(TimeSpan.FromHours(4));

            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { StartTime = start }).ConfigureAwait(false);

            Assert.AreEqual(200, metricsResultsResponse.GetRawResponse().Status);
            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            Assert.AreEqual(1, metricsQueryResults.Values.Count);
            Assert.AreEqual(TestEnvironment.StorageAccountId + "/providers/Microsoft.Insights/metrics/Ingress", metricsQueryResults.Values[0].Metrics[0].Id);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", metricsQueryResults.Values[0].Namespace);
        }

        [RecordedTest]
        public async Task MetricsQueryResourcesWithStartTimeEndTimeRangeAsync()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            DateTimeOffset start = Recording.UtcNow.Subtract(TimeSpan.FromHours(4));
            DateTimeOffset end = Recording.UtcNow;

            Response<MetricsQueryResourcesResult> metricsResultsResponse = await client.QueryResourcesAsync(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { StartTime = start, EndTime = end }).ConfigureAwait(false);

            Assert.AreEqual(200, metricsResultsResponse.GetRawResponse().Status);
            MetricsQueryResourcesResult metricsQueryResults = metricsResultsResponse.Value;
            Assert.AreEqual(1, metricsQueryResults.Values.Count);
            Assert.AreEqual(TestEnvironment.StorageAccountId + "/providers/Microsoft.Insights/metrics/Ingress", metricsQueryResults.Values[0].Metrics[0].Id);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", metricsQueryResults.Values[0].Namespace);
        }

        [Test]
        [SyncOnly]
        public void MetricsQueryResourcesWithEndTimeRange()
        {
            MetricsClient client = CreateMetricsClient();

            var resourceId = TestEnvironment.StorageAccountId;

            // If only the endtime parameter is given, then the starttime parameter is required.
            DateTimeOffset end = new DateTimeOffset(TestStartTime).Subtract(TimeSpan.FromHours(4));

            Assert.Throws<AggregateException>(() =>
                client.QueryResources(
                resourceIds: new List<ResourceIdentifier> { new ResourceIdentifier(resourceId) },
                metricNames: new List<string> { "Ingress" },
                metricNamespace: "Microsoft.Storage/storageAccounts",
                options: new MetricsQueryResourcesOptions { EndTime = end }));
        }
    }
}
