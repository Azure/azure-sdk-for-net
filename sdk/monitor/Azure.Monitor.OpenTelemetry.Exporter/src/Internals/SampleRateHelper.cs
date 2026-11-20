// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Resolves the envelope sampleRate; ingestion derives itemCount as 100 / sampleRate.
    /// </summary>
    internal static class SampleRateHelper
    {
        internal const float FullSampleRate = 100f;

        internal static double FromSamplingRatio(float samplingRatio)
        {
            // Multiplied in single precision to match earlier releases (0.025F rounds to 2, not 3);
            // ratios below 0.5% stay unrounded so they don't collapse to zero.
            double percentage = samplingRatio * 100;
            double rounded = Math.Round(percentage);
            return rounded > 0 ? rounded : percentage;
        }

        // Used when a span or log has no valid microsoft.sample_rate; under rate-limited sampling the rate is unknown.
        internal static float GetFallbackSampleRate(AzureMonitorExporterOptions options)
            => options.TracesPerSecond == null ? (float)FromSamplingRatio(options.SamplingRatio) : FullSampleRate;

        internal static bool TryGetSampleRate(object? value, out float sampleRate)
        {
            double rate;
            switch (value)
            {
                case double d:
                    rate = d;
                    break;
                case float f:
                    rate = f;
                    break;
                case int i:
                    rate = i;
                    break;
                case long l:
                    rate = l;
                    break;
                case decimal m:
                    rate = (double)m;
                    break;
                case string s when double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsed):
                    rate = parsed;
                    break;
                default:
                    sampleRate = default;
                    return false;
            }

            if (double.IsNaN(rate) || rate <= 0 || rate > FullSampleRate)
            {
                sampleRate = default;
                return false;
            }

            sampleRate = (float)rate;
            return true;
        }

        internal static bool IsReportable(float sampleRate) => sampleRate > 0 && sampleRate < FullSampleRate;
    }
}
