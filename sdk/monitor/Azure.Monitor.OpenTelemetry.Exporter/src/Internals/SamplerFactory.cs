// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class SamplerFactory
    {
        /// <summary>
        /// Chooses the sampler for a tracer provider.
        /// </summary>
        /// <remarks>
        /// Rate-limited sampling counts traces per process. A multi-endpoint process carries traffic
        /// for many destinations, so one limit would be divided between them by nothing more than
        /// arrival order: a busy destination would consume the allowance and quiet ones would lose
        /// telemetry they never generated enough of to be sampled out of. Fixed-rate sampling
        /// applies the same proportion to every destination, so it is used instead.
        /// </remarks>
        internal static Sampler Create(AzureMonitorExporterOptions options, bool multiEndpointEnabled)
        {
            if (options.TracesPerSecond == null)
            {
                return new ApplicationInsightsSampler(options.SamplingRatio);
            }

            if (multiEndpointEnabled)
            {
                AzureMonitorExporterEventSource.Log.RateLimitedSamplingIgnoredForMultiEndpointRouting(options.TracesPerSecond.Value, options.SamplingRatio);

                return new ApplicationInsightsSampler(options.SamplingRatio);
            }

            return new RateLimitedSampler(options.TracesPerSecond.Value);
        }
    }
}
