﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class MetricDataPoint
    {
        public MetricDataPoint(Metric metric, MetricPoint metricPoint)
        {
            Name = metric.Name;
            Namespace = metric.MeterName;

            switch (metric.MetricType)
            {
                case MetricType.DoubleSum:
                    Value = metricPoint.GetSumDouble();

                    break;
                case MetricType.DoubleGauge:
                    Value = metricPoint.GetGaugeLastValueDouble();

                    break;
                case MetricType.LongSum:
                    // potential for minor precision loss implicitly going from long->double
                    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
                    Value = metricPoint.GetSumLong();

                    break;
                case MetricType.LongGauge:
                    // potential for minor precision loss implicitly going from long->double
                    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
                    Value = metricPoint.GetGaugeLastValueLong();

                    break;
                case MetricType.Histogram:
                    Value = metricPoint.GetHistogramSum();
                    long histogramCount = metricPoint.GetHistogramCount();
                    // Current schema only supports int values for count
                    // if the value is within integer range we will use it otherwise ignore it.
                    Count = (histogramCount <= int.MaxValue && histogramCount >= int.MinValue) ? (int?)histogramCount : null;

                    break;
            }
        }
    }
}
