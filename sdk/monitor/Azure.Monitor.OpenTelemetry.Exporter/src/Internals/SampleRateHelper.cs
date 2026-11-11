// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Resolves the envelope sample rate, a percentage in (0, 100] from which ingestion derives
    /// itemCount as 100 / sampleRate.
    /// </summary>
    internal static class SampleRateHelper
    {
        internal const float FullSampleRate = 100f;

        /// <summary>
        /// Converts a fixed sampling ratio to the percentage the fixed-rate sampler stamps on spans.
        /// Whole percentages are kept so the value on the envelope is unchanged from earlier releases;
        /// a ratio below 0.5% is kept unrounded so it does not collapse to zero.
        /// </summary>
        internal static double FromSamplingRatio(float samplingRatio)
        {
            double percentage = samplingRatio * 100d;
            double rounded = Math.Round(percentage);
            return rounded > 0 ? rounded : percentage;
        }

        /// <summary>
        /// The rate used when a span or log carries no <c>microsoft.sample_rate</c> attribute, which
        /// happens only with a sampler other than ours. Fixed-rate configuration is assumed to describe
        /// such a sampler, as it did before the attribute was read; with rate-limited configuration the
        /// effective rate is unknown, so the item is reported as unsampled.
        /// </summary>
        internal static float GetFallbackSampleRate(AzureMonitorExporterOptions options)
            => options.TracesPerSecond == null ? (float)FromSamplingRatio(options.SamplingRatio) : FullSampleRate;

        /// <summary>
        /// Reads a <c>microsoft.sample_rate</c> attribute value. Anything other than a finite number in
        /// (0, 100] is rejected, since ingestion would otherwise derive a meaningless itemCount.
        /// </summary>
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

        /// <summary>
        /// Whether the rate should be written to the envelope. 100 is the service default and is
        /// omitted; a non-positive rate cannot describe an exported item.
        /// </summary>
        internal static bool IsReportable(float sampleRate) => sampleRate > 0 && sampleRate < FullSampleRate;
    }
}
