using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Data.ApplicationInsights.Tests.Metrics
{
    public class SummaryMetricsTests : MetricsTestBase
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetSummaryMetric()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var metricId = "requests/duration";
                var timespan = "PT12H";
                var aggregation = new List<string> { MetricsAggregation.Avg };

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetMetricSummaryAsync(DefaultAppId, metricId, timespan, aggregation);

                AssertMetrics(metric, true, false, false, false, false);
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetSummaryMetric_AllAggregations()
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

                var client = GetClient(ctx);
                var metric = await client.Metrics.GetMetricSummaryAsync(DefaultAppId, metricId, timespan, aggregation);

                AssertMetrics(metric, true, true, true, true, true);
            }
        }
    }
}
