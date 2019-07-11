using System;
using System.Collections.Generic;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Xunit;

namespace Data.ApplicationInsights.Tests.Metrics
{
    public class MetricsTestBase : DataPlaneTestBase
    {
        static object[] AggregatedMetricData = new object[] {
            new MetricsPostBodySchema {
                Id = nameof(AggregatedMetric),
                Parameters = new MetricsPostBodySchemaParameters
                {
                    MetricId = "requests/duration",
                    Aggregation = new List<string> { MetricsAggregation.Avg },
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
                    Aggregation = new List<string> { MetricsAggregation.Avg },
                    Timespan = "PT12H",
                    Interval = new TimeSpan(3, 0, 0)
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
                    Aggregation = new List<string> { MetricsAggregation.Avg },
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
                    Aggregation = new List<string> { MetricsAggregation.Avg },
                    Timespan = "PT12H",
                    Interval = new TimeSpan(3, 0, 0),
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
                    Aggregation = new List<string> { MetricsAggregation.Avg },
                    Timespan = "PT12H",
                    Interval = new TimeSpan(3, 0, 0),
                    Segment = new[] { "request/name", "request/success" }
                }
            },
            true,
            true
        };

        public static IEnumerable<object[]> AggregatedMetric
        {
            get
            {
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

        protected void AssertMetrics(IMetricData metric, bool hasAverage, bool hasCount, bool hasMax, bool hasMin, bool hasSum)
        {
            Assert.Equal(hasAverage, metric.Average.HasValue);
            Assert.Equal(hasCount, metric.Count.HasValue);
            Assert.Equal(hasMax, metric.Max.HasValue);
            Assert.Equal(hasMin, metric.Min.HasValue);
            Assert.Equal(hasSum, metric.Sum.HasValue);
        }
    }
}
