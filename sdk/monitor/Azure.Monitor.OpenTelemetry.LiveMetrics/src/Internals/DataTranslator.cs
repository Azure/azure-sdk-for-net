// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal static class DataTranslator
    {
        public static bool TryConvertOTelToAzure(Metric metric, MetricPoint metricPoint, [NotNullWhen(true)] out Models.MetricPoint? azureMetricPoint)
        {
            //Debug.WriteLine(LiveMetricConstants.Mappings[metric.Name]);

            switch (metric.MetricType)
            {
                case MetricType.LongSum:
                    azureMetricPoint = new Models.MetricPoint
                    {
                        Name = LiveMetricConstants.InstrumentNameToMetricId[metric.Name],
                        // potential for minor precision loss implicitly going from long->double
                        // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
                        Value = metricPoint.GetSumLong(),
                        Weight = 1
                    };
                    return true;

                case MetricType.Histogram:
                    long histogramCount = metricPoint.GetHistogramCount();

                    azureMetricPoint = new Models.MetricPoint
                    {
                        Name = LiveMetricConstants.InstrumentNameToMetricId[metric.Name],
                        // When you convert double to float, the double value is rounded to the nearest float value.
                        // If the double value is too small or too large to fit into the float type, the result is zero or infinity.
                        // see: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions
                        Value = (float)(metricPoint.GetHistogramSum() / histogramCount),
                        Weight = histogramCount <= int.MaxValue ? (int?)histogramCount : null // TODO: POSSIBLE OVERFLOW EXCEPTION (long -> int)
                    };
                    return true;
                case MetricType.DoubleGauge:
                    azureMetricPoint = new Models.MetricPoint
                    {
                        Name = LiveMetricConstants.InstrumentNameToMetricId[metric.Name],
                        Value = (float)metricPoint.GetGaugeLastValueDouble(),
                        Weight = 1
                    };
                    return true;
                default:
                    Debug.WriteLine($"Unsupported Metric Type {metric.MetricType} {metric.Name}");
                    azureMetricPoint = null;
                    return false;
            }
        }
    }
}
