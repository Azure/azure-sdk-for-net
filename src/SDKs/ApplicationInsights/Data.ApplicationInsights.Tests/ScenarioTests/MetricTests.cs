using Microsoft.Azure.ApplicationInsights;
using Microsoft.Azure.ApplicationInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Data.ApplicationInsights.Tests
{
    public class MetricTests : DataPlaneTestBase
    {
        static object[] AggregatedMetricData = new object[] {
            new MetricsPostBodySchema {
                Id = nameof(AggregatedMetric),
                Parameters = new MetricsPostBodySchemaParameters
                {
                    MetricId = "requests/duration",
                    Aggregation = new[] { "avg" },
                    Timespan = "PT12H"
                }
            },
            false,
            false
        };

        static object[] AggregatedIntervalMetricData = new object[] {
            new MetricsPostBodySchema
            {
                Id = nameof(AggregatedIntervalMetric),
                Parameters = new MetricsPostBodySchemaParameters
                {
                    MetricId = "requests/duration",
                    Aggregation = new[] { "avg" },
                    Timespan = "PT12H",
                    Interval = "PT3H"
                }
            },
            true,
            false
        };

        static object[] AggregatedSegmentMetricData = new object[] {
            new MetricsPostBodySchema
            {
                Id = nameof(AggregatedSegmentMetric),
                Parameters = new MetricsPostBodySchemaParameters
                {
                    MetricId = "requests/duration",
                    Aggregation = new[] { "avg" },
                    Timespan = "PT12H",
                    Segment = new[] { "request/name" }
                }
            },
            false,
            true
        };

        static object[] AggregatedIntervalSegmentMetricData = new object[] {
            new MetricsPostBodySchema
            {
                Id = nameof(AggregatedIntervalSegmentMetric),
                Parameters = new MetricsPostBodySchemaParameters
                {
                    MetricId = "requests/duration",
                    Aggregation = new[] { "avg" },
                    Timespan = "PT12H",
                    Interval = "PT3H",
                    Segment = new[] { "request/name" }
                }
            },
            true,
            true
        };

        static object[] AggregatedIntervalMultiSegmentMetricData = new object[] {
            new MetricsPostBodySchema
            {
                Id = nameof(AggregatedIntervalMultiSegmentMetric),
                Parameters = new MetricsPostBodySchemaParameters
                {
                    MetricId = "requests/duration",
                    Aggregation = new[] { "avg" },
                    Timespan = "PT12H",
                    Interval = "PT3H",
                    Segment = new[] { "request/name", "request/success" }
                }
            },
            true,
            true
        };

        public static IEnumerable<object[]> AggregatedMetric
        {
            get {
                yield return AggregatedMetricData;
            }
        }

        public static IEnumerable<object[]> AggregatedIntervalMetric
        {
            get
            {
                yield return AggregatedIntervalMetricData;
            }
        }

        public static IEnumerable<object[]> AggregatedSegmentMetric
        {
            get
            {
                yield return AggregatedSegmentMetricData;
            }
        }

        public static IEnumerable<object[]> AggregatedIntervalSegmentMetric
        {
            get
            {
                yield return AggregatedIntervalSegmentMetricData;
            }
        }

        public static IEnumerable<object[]> AggregatedIntervalMultiSegmentMetric
        {
            get
            {
                yield return AggregatedIntervalMultiSegmentMetricData;
            }
        }

        [Theory]
        [MemberData(nameof(AggregatedMetric))]
        [MemberData(nameof(AggregatedIntervalMetric))]
        [MemberData(nameof(AggregatedSegmentMetric))]
        [MemberData(nameof(AggregatedIntervalSegmentMetric))]
        [MemberData(nameof(AggregatedIntervalMultiSegmentMetric))]
        public async Task GetMetrics(MetricsPostBodySchema metric, bool hasInterval, bool isSegmented)
        {
            using (var ctx = MockContext.Start(GetType().FullName, $"GetMetrics.{metric.Id}"))
            {
                var metricRequest = new List<MetricsPostBodySchema>
                {
                    metric
                };

                var client = GetClient(ctx);
                var metrics = await client.GetMetricsAsync(metricRequest);

                Assert.NotNull(metrics);
                Assert.Equal(1, metrics.Count);

                VerifyMetric(metric, metrics[0], hasInterval, isSegmented);
            }
        }

        delegate void GetMetricAndSegmentValuesDelegate(MetricsResultInfo info);

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
                Assert.Equal(0, segmentInfo.Count);
            }
            else
            {
                for (var i=0; i<expected.Parameters.Segment.Count; i++)
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
