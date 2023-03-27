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
                TestEnvironment.MetricsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new MetricsQueryClientOptions())
            ));
        }

        [SetUp]
        public async Task SetUp()
        {
            _testData = new MetricsTestData(TestEnvironment, Recording.UtcNow);
            await _testData.InitializeAsync();
        }

        [RecordedTest]
        public async Task CanListMetrics()
        {
            TestContext.Progress.WriteLine("CanListMetrics");
            var client = CreateClient();

            var results = await client.GetMetricDefinitionsAsync(TestEnvironment.MetricsResource, TestEnvironment.MetricsNamespace).ToEnumerableAsync();

            CollectionAssert.IsNotEmpty(results);
        }

        [RecordedTest]
        public async Task CanQueryMetrics()
        {
            TestContext.Progress.WriteLine("CanQueryMetrics");
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

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.AreEqual(duration.Minutes, timeSeriesData.Count);
            // Average is queried by default
            Assert.True(timeSeriesData.All(d=> d.Average != null));
            Assert.AreEqual(new QueryTimeRange(_testData.StartTime, _testData.StartTime + duration), results.Value.TimeSpan);

            Assert.Null(results.Value.Metrics[0].Error);
        }

        [RecordedTest]
        public async Task CanQueryMetricsAllAggregations()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsAllAggregations");
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

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.AreEqual(_testData.Duration.Minutes, timeSeriesData.Count);
            // Average is queried by default
            Assert.True(timeSeriesData.All(d=>
                d.Average != null &&
                d.Count != null &&
                d.Maximum != null &&
                d.Minimum != null &&
                d.Total != null));
        }

        [RecordedTest]
        public async Task CanQueryMetricsStartEnd()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsStartEnd");
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.EndTime),
                });

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.AreEqual(_testData.Duration.Minutes, timeSeriesData.Count);
            Assert.True(timeSeriesData.All(d=>
                d.TimeStamp >= _testData.StartTime && d.TimeStamp <= _testData.EndTime));
        }

        [RecordedTest]
        public async Task CanQueryMetricsStartDuration()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsStartDuration");
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.StartTime, _testData.Duration)
                });

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.AreEqual(_testData.Duration.Minutes, timeSeriesData.Count);
            Assert.True(timeSeriesData.All(d=>
                d.TimeStamp >= _testData.StartTime && d.TimeStamp <= _testData.EndTime));
        }

        [RecordedTest]
        public async Task CanQueryMetricsDurationEnd()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsDurationEnd");
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace,
                    TimeRange = new QueryTimeRange(_testData.Duration, _testData.EndTime)
                });

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.AreEqual(_testData.Duration.Minutes, timeSeriesData.Count);
            Assert.True(timeSeriesData.All(d=>
                d.TimeStamp >= _testData.StartTime && d.TimeStamp <= _testData.EndTime));
        }

        [RecordedTest]
        public async Task CanQueryMetricsNoTimespan()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsNoTimespan");
            var client = CreateClient();

            var results = await client.QueryResourceAsync(
                TestEnvironment.MetricsResource,
                new[]{ _testData.MetricName },
                new MetricsQueryOptions
                {
                    MetricNamespace = _testData.MetricNamespace
                });

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.Greater(timeSeriesData.Count, 0);
        }

        [RecordedTest]
        public async Task CanQueryMetricsStartEndInterval()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsStartEndInterval");
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

            var timeSeriesData = results.Value.Metrics[0].TimeSeries[0].Values;
            Assert.AreEqual(_testData.Duration.Minutes / 5, timeSeriesData.Count);
            Assert.True(timeSeriesData.All(d=>
                d.TimeStamp >= _testData.StartTime && d.TimeStamp <= _testData.EndTime));
        }

        [RecordedTest]
        public async Task CanQueryMetricsFilter()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsFilter");
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

            var timeSeries = results.Value.Metrics[0].TimeSeries[0];

            Assert.AreEqual(_testData.Name1, timeSeries.Metadata["name"]);
        }
        [RecordedTest]
        public async Task CanQueryMetricsFilterTop()
        {
            TestContext.Progress.WriteLine("CanQueryMetricsFilterTop");
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

            Assert.AreEqual(1, results.Value.Metrics[0].TimeSeries.Count);
        }

        [RecordedTest]
        public async Task CanListNamespacesMetrics()
        {
            TestContext.Progress.WriteLine("CanListNamspacesMetrics");
            var client = CreateClient();

            var results = await client.GetMetricNamespacesAsync(
                TestEnvironment.MetricsResource).ToEnumerableAsync();

            Assert.True(results.Any(ns =>
                ns.Name == "Cows" &&
                ns.Type == "Microsoft.Insights/metricNamespaces" &&
                ns.FullyQualifiedName == "Cows"));

            Assert.True(results.Any(ns =>
                ns.Name == "microsoft.operationalinsights-workspaces" &&
                ns.Type == "Microsoft.Insights/metricNamespaces" &&
                ns.FullyQualifiedName == "microsoft.operationalinsights/workspaces"));
        }

        [RecordedTest]
        public async Task CanGetMetricByNameNull()
        {
            TestContext.Progress.WriteLine("CanGetMetricByNameNull");
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
            TestContext.Progress.WriteLine("CanGetMetricByName");
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
            TestContext.Progress.WriteLine("CanGetMetricByNameInvalid");
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
