// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsQueryClientLiveTests : RecordedTestBase<MonitorQueryTestEnvironment>
    {
        private MetricsTestData _testData;

        public MetricsQueryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MetricsQueryClient CreateClient()
        {
            return InstrumentClient(new MetricsQueryClient(
                new Uri(TestEnvironment.GetMetricsAudience()),
                TestEnvironment.Credential,
                InstrumentClientOptions(new MetricsQueryClientOptions()
                {
                    Audience = TestEnvironment.GetMetricsAudience()
                })
            ));
        }

        [SetUp]
        public void SetUp()
        {
            _testData = new MetricsTestData(TestEnvironment, Recording.UtcNow);
            // await _testData.InitializeAsync();
        }

        [RecordedTest]
        public async Task CanListMetrics()
        {
            var client = CreateClient();

            var results = await client.GetMetricDefinitionsAsync(TestEnvironment.MetricsResource, TestEnvironment.MetricsNamespace).ToEnumerableAsync();

            CollectionAssert.IsNotEmpty(results);
        }

        [RecordedTest]
        public async Task CanQueryMetrics()
        {
            var client = CreateClient();

            var duration = TimeSpan.FromMinutes(3);
            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions()
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, duration)
                });

            Assert.AreEqual("CowsHappiness", results.Value.Metrics[0].Name);
            Assert.AreEqual(new QueryTimeRange(_testData.StartTime, _testData.StartTime + duration), results.Value.TimeSpan);

            Assert.Null(results.Value.Metrics[0].Error);
        }

        [RecordedTest]
        public async Task CanQueryMetricsAllAggregations()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.StartTime.Add(_testData.Duration)),
                    Aggregations =
                    {
                        MetricAggregationType.Average,
                        MetricAggregationType.Count,
                        MetricAggregationType.Maximum,
                        MetricAggregationType.Minimum,
                        MetricAggregationType.Total
                    }
                });

            Assert.AreEqual(_testData.MetricName, results.Value.Metrics[0].Name);
            Assert.AreEqual(new QueryTimeRange(_testData.StartTime, _testData.StartTime.Add(_testData.Duration)), results.Value.TimeSpan);
        }

        [RecordedTest]
        public async Task CanQueryMetricsStartEnd()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                });

            Assert.Greater(results.Value.Cost, 0);
            var timeSeriesData = results.Value.Metrics[0].TimeSeries;
            Assert.AreEqual(0, timeSeriesData.Count);
        }

        [RecordedTest]
        public async Task CanQueryMetricsStartDuration()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.Duration)
                });

            Assert.AreEqual(_testData.MetricName, results.Value.Metrics[0].Name);
            Assert.AreEqual(new QueryTimeRange(_testData.StartTime, _testData.StartTime.Add(_testData.Duration)), results.Value.TimeSpan);
        }

        [RecordedTest]
        public async Task CanQueryMetricsDurationEnd()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.Duration, _testData.EndTime)
                });

            Assert.Greater(results.Value.Cost, 0);
            var timeSeriesData = results.Value.Metrics[0].TimeSeries;
            Assert.AreEqual(0, timeSeriesData.Count);
        }

        [RecordedTest]
        public async Task CanQueryMetricsNoTimespan()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace
                });

            Assert.Greater(results.Value.Metrics.Count, 0);
            Assert.AreEqual(_testData.MetricName, results.Value.Metrics[0].Name);
            Assert.AreEqual(_testData.MetricNamespace, results.Value.Namespace);
            Assert.AreEqual(1, results.Value.Metrics.Count);
        }

        [RecordedTest]
        public async Task CanQueryMetricsStartEndInterval()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                    Granularity = TimeSpan.FromMinutes(5)
                });

            Assert.Greater(results.Value.Cost, 0);
            var timeSeriesData = results.Value.Metrics[0].TimeSeries;
            Assert.AreEqual(0, timeSeriesData.Count);
        }

        [RecordedTest]
        public async Task CanQueryMetricsFilter()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[] {_testData.MetricName},
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                    Filter = $"Name eq '{_testData.Name1}'",
                    Aggregations =
                    {
                        MetricAggregationType.Count
                    }
                });

            Assert.AreEqual(TimeSpan.FromMinutes(1), results.Value.Granularity);
            Assert.Greater(results.Value.Cost, 0);
        }

        [RecordedTest]
        public async Task CanQueryMetricsFilterTop()
        {
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[] {_testData.MetricName},
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                    Filter = $"Name eq '*'",
                    Size = 1,
                    Aggregations =
                    {
                        MetricAggregationType.Count
                    }
                });

            Assert.AreEqual(1, results.Value.Metrics.Count);
            Assert.Greater(results.Value.Cost, 0);
            Assert.AreEqual(new QueryTimeRange(_testData.StartTime, _testData.StartTime.Add(_testData.Duration)), results.Value.TimeSpan);
        }

        [RecordedTest]
        public async Task CanListNamespacesMetrics()
        {
            var client = CreateClient();

            var results = await client.GetMetricNamespacesAsync(
                TestEnvironment.MetricsResource).ToEnumerableAsync();

            Assert.True(results.Any(ns =>
                ns.Name.Equals("microsoft.operationalinsights-workspaces", StringComparison.OrdinalIgnoreCase) &&
                ns.Type.Equals("Microsoft.Insights/metricNamespaces", StringComparison.OrdinalIgnoreCase) &&
                ns.FullyQualifiedName.Equals("microsoft.operationalinsights/workspaces", StringComparison.OrdinalIgnoreCase)));
        }

        [RecordedTest]
        public async Task CanGetMetricByNameNull()
        {
            MetricsQueryClient client = CreateClient();
            Response<MetricsQueryResult> results = await client.QueryResourceAsync(
              TestEnvironment.MetricsResource,
              new[] { _testData.MetricName },
              new MetricsQueryOptions
              {
                  MetricNamespace = _testData.MetricNamespace,
                  TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                  Filter = $"Name eq '{_testData.Name1}'",
                  Aggregations =
                  {
                        MetricAggregationType.Count
                  }
              });
            Assert.Throws<ArgumentNullException>(() => { results.Value.GetMetricByName(null); });
        }

        [RecordedTest]
        public async Task CanGetMetricByName()
        {
            MetricsQueryClient client = CreateClient();
            Response<MetricsQueryResult> results = await client.QueryResourceAsync(
              TestEnvironment.MetricsResource,
              new[] { _testData.MetricName },
              new MetricsQueryOptions
              {
                  MetricNamespace = _testData.MetricNamespace,
                  TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                  Aggregations =
                  {
                        MetricAggregationType.Count
                  }
              });

            var result = results.Value.GetMetricByName(_testData.MetricName);
            Assert.AreEqual(result.Name, _testData.MetricName);
        }

        [RecordedTest]
        public async Task CanGetMetricByNameInvalid()
        {
            MetricsQueryClient client = CreateClient();
            Response<MetricsQueryResult> results = await client.QueryResourceAsync(
              TestEnvironment.MetricsResource,
              new[] { _testData.MetricName },
              new MetricsQueryOptions
              {
                  MetricNamespace = _testData.MetricNamespace,
                  TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                  Aggregations =
                  {
                        MetricAggregationType.Count
                  }
              });

            Assert.Throws<KeyNotFoundException>(() => { results.Value.GetMetricByName("Guinness"); });
        }
    }
}
