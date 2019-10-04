using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;

namespace Data.ApplicationInsights.Tests.Metrics
{
    public class IntervaledMetricsTests : MetricsTestBase
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetIntervaledMetrics()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var interval = new TimeSpan(1, 0, 0);
                var aggregation = new List<string> { MetricsAggregation.Avg };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetIntervaledMetricAsync(DefaultAppId, metricId, timespan, interval, aggregation);

                Assert.Equal(interval, metric.Interval);
                Assert.Equal(13, metric.Intervals.Count); // Actually 13 because of time rounding, I suppose

                foreach (var inter in metric.Intervals)
                {
                    AssertMetrics(inter, true, false, false, false, false);
                }
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetIntervaledMetrics_AllAggregations()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var interval = new TimeSpan(1, 0, 0);
                var aggregation = new List<string> {
                    MetricsAggregation.Avg,
                    MetricsAggregation.Count,
                    MetricsAggregation.Min,
                    MetricsAggregation.Max,
                    MetricsAggregation.Sum
                };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetIntervaledMetricAsync(DefaultAppId, metricId, timespan, interval, aggregation);

                Assert.Equal(interval, metric.Interval);
                Assert.Equal(13, metric.Intervals.Count); // Actually 13 because of time rounding, I suppose

                foreach (var inter in metric.Intervals)
                {
                    AssertMetrics(inter, true, true, true, true, true);
                }
            }
        }
    }
}
