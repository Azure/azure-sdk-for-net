using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;

namespace Data.ApplicationInsights.Tests.Metrics
{
    public class IntervaledMetricsTests : MetricsTestBase
    {
        [Fact]
        public async Task GetIntervaledMetrics()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                var metricId = "requests/duration";
                var timespan = new TimeSpan(12, 0, 0);
                var interval = new TimeSpan(1, 0, 0);
                var aggregation = new[] { "avg" };

                var client = GetClient(ctx);
                var metric = await client.GetIntervaledMetricAsync(metricId, timespan, interval, aggregation);

                Assert.Equal(interval, metric.Interval);
                Assert.Equal(13, metric.Intervals.Count); // Actually 13 because of time rounding, I suppose

                foreach (var inter in metric.Intervals)
                {
                    AssertMetrics(inter, true, false, false, false, false);
                }
            }
        }

        [Fact]
        public async Task GetIntervaledMetrics_AllAggregations()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                var metricId = "requests/duration";
                var timespan = new TimeSpan(12, 0, 0);
                var interval = new TimeSpan(1, 0, 0);
                var aggregation = new[] { "avg", "count", "max", "min", "sum" };

                var client = GetClient(ctx);
                var metric = await client.GetIntervaledMetricAsync(metricId, timespan, interval, aggregation);

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
