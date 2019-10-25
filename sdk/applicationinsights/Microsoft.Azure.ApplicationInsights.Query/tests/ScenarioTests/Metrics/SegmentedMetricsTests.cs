using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;


namespace Data.ApplicationInsights.Tests.Metrics
{
    public class SegmentedMetricsTests : MetricsTestBase
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetSegmentedMetrics()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var aggregation = new List<string> { MetricsAggregation.Avg };
                var segments = new[] { "request/resultCode" };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetSegmentedMetricAsync(DefaultAppId, metricId, timespan, aggregation, segments);

                Assert.True(metric.Segments.Count > 0);

                foreach (var segment in metric.Segments)
                {
                    Assert.Equal(typeof(MetricsSegmentedData), segment.GetType());
                    var seg = segment as MetricsSegmentedData;
                    Assert.NotNull(seg);
                    Assert.Equal(segments[0], seg.SegmentId);
                    Assert.NotNull(seg.SegmentValue);
                    AssertMetrics(seg, true, false, false, false, false);
                }
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetSegmentedMetrics_AllAggregations()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var aggregation = new List<string> {
                    MetricsAggregation.Avg,
                    MetricsAggregation.Count,
                    MetricsAggregation.Min,
                    MetricsAggregation.Max,
                    MetricsAggregation.Sum
                };
                var segments = new[] { "request/resultCode" };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetSegmentedMetricAsync(DefaultAppId, metricId, timespan, aggregation, segments);

                Assert.True(metric.Segments.Count > 0);

                foreach (var segment in metric.Segments)
                {
                    Assert.Equal(typeof(MetricsSegmentedData), segment.GetType());
                    var seg = segment as MetricsSegmentedData;
                    Assert.NotNull(seg);
                    Assert.Equal(segments[0], seg.SegmentId);
                    Assert.NotNull(seg.SegmentValue);
                    AssertMetrics(seg, true, true, true, true, true);
                }
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetMultiSegmentedMetrics()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var aggregation = new List<string> { MetricsAggregation.Avg };
                var segments = new[] { "request/name", "request/resultCode" };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetSegmentedMetricAsync(DefaultAppId, metricId, timespan, aggregation, segments);

                Assert.True(metric.Segments.Count > 0);

                foreach (var segment in metric.Segments)
                {
                    Assert.Equal(typeof(MetricsNestedSegment), segment.GetType());
                    var seg = segment as MetricsNestedSegment;
                    Assert.NotNull(seg);
                    Assert.Equal(segments[0], seg.SegmentId);
                    Assert.NotNull(seg.SegmentValue);

                    foreach (var segment2 in seg.Segments)
                    {
                        Assert.Equal(typeof(MetricsSegmentedData), segment2.GetType());
                        var seg2 = segment2 as MetricsSegmentedData;
                        Assert.NotNull(seg2);
                        Assert.Equal(segments[1], seg2.SegmentId);
                        Assert.NotNull(seg2.SegmentValue);
                        AssertMetrics(seg2, true, false, false, false, false);
                    }
                }
            }
        }

        [Fact(Skip = "true")] // This API call is failing with a 500 for some reason
        public async Task GetMultiSegmentedMetrics_AllAggregations()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var aggregation = new List<string> {
                    MetricsAggregation.Avg,
                    MetricsAggregation.Count,
                    MetricsAggregation.Min,
                    MetricsAggregation.Max,
                    MetricsAggregation.Sum
                };
                var segments = new[] { "request/name", "request/resultCode" };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetSegmentedMetricAsync(DefaultAppId, metricId, timespan, aggregation, segments);

                Assert.True(metric.Segments.Count > 0);

                foreach (var segment in metric.Segments)
                {
                    Assert.Equal(typeof(MetricsNestedSegment), segment.GetType());
                    var seg = segment as MetricsNestedSegment;
                    Assert.NotNull(seg);
                    Assert.Equal(segments[0], seg.SegmentId);
                    Assert.NotNull(seg.SegmentValue);

                    foreach (var segment2 in seg.Segments)
                    {
                        Assert.Equal(typeof(MetricsSegmentedData), segment2.GetType());
                        var seg2 = segment2 as MetricsSegmentedData;
                        Assert.NotNull(seg2);
                        Assert.Equal(segments[1], seg2.SegmentId);
                        Assert.NotNull(seg2.SegmentValue);
                        AssertMetrics(seg2, true, true, true, true, true);
                    }
                }
            }
        }
    }
}
