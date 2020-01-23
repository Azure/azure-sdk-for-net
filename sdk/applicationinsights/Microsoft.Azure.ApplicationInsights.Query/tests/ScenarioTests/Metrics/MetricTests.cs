using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Runtime.Serialization;
using System;

namespace Data.ApplicationInsights.Tests.Metrics
{
    public class MetricTests : MetricsTestBase
    {
        [Theory(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        [MemberData(nameof(AggregatedMetric))]
        [MemberData(nameof(AggregatedIntervalMetric))]
        [MemberData(nameof(AggregatedSegmentMetric))]
        [MemberData(nameof(AggregatedIntervalSegmentMetric))]
        [MemberData(nameof(AggregatedIntervalMultiSegmentMetric))]
        public async Task GetMetrics(MetricsPostBodySchema metric, bool hasInterval, bool isSegmented)
        {
            using (var ctx = MockContext.Start(this.GetType(), $"GetMetrics.{metric.Id}"))
            {
                var metricRequest = new List<MetricsPostBodySchema>
                {
                    metric
                };

                var client = GetClient(ctx);
                var metrics = await client.Metrics.GetMultipleAsync(DefaultAppId, metricRequest);

                Assert.NotNull(metrics);
                Assert.Equal(1, metrics.Count);

                VerifyMetric(metric, metrics[0], hasInterval, isSegmented);
            }
        }

        private void VerifyMetric(MetricsPostBodySchema expected, MetricsResultsItem actual, bool hasInterval = false, bool isSegmented = false)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(200, actual.Status);

            string metricId = null;
            Dictionary<string, float> metricValues = null;

            var segmentInfo = new List<KeyValuePair<string, string>>();

            metricId = actual.Body.Value.MetricId;
            metricValues = actual.Body.Value.MetricValues;

            MetricsSegmentInfo info = actual.Body.Value.Segments != null ? actual.Body.Value.Segments[0] : null;
            while (info != null)
            {
                metricId = info.MetricId;
                metricValues = info.MetricValues;

                if (info.SegmentId != null)
                {
                    segmentInfo.Add(new KeyValuePair<string, string>(info.SegmentId, info.SegmentValue));
                }

                info = info.Segments != null ? info.Segments[0] : null;
            }

            // Check that the interval field is set appropriately
            if (hasInterval)
            {
                Assert.NotNull(actual.Body.Value.Interval);
            }
            else
            {
                Assert.Null(actual.Body.Value.Interval);
            }

            // Check that the segmentation fields are set appropriately
            if (!isSegmented)
            {
                Assert.Empty(segmentInfo);
            }
            else
            {
                for (var i = 0; i < expected.Parameters.Segment.Count; i++)
                {
                    var segmentName = expected.Parameters.Segment[i];
                    Assert.Equal(segmentName, segmentInfo[i].Key);
                    Assert.NotNull(segmentInfo[i].Value);
                }
            }

            // Check that the metric fields are set appropriately
            Assert.Equal(expected.Parameters.MetricId, metricId);
            Assert.Equal(expected.Parameters.Aggregation.Count, metricValues.Count);
            foreach (var aggregation in expected.Parameters.Aggregation)
            {
                Assert.True(metricValues.ContainsKey(aggregation));
                Assert.NotEqual(float.MinValue, metricValues[aggregation]);
            }
        }
    }
}
