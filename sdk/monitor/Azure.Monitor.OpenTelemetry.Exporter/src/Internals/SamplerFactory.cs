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
        /// Rate-limited sampling counts traces per process. A multi-tenant process carries traffic
        /// for many tenants, so one limit would be divided between them by nothing more than
        /// arrival order: a busy tenant would consume the allowance and quiet tenants would lose
        /// telemetry they never generated enough of to be sampled out of. Fixed-rate sampling
        /// applies the same proportion to every tenant, so it is used instead.
        /// </remarks>
        internal static Sampler Create(AzureMonitorExporterOptions options, bool multiTenantEnabled)
        {
            if (options.TracesPerSecond == null)
            {
                return new ApplicationInsightsSampler(options.SamplingRatio);
            }

            if (multiTenantEnabled)
            {
                AzureMonitorExporterEventSource.Log.RateLimitedSamplingIgnoredForMultiTenantExport(options.TracesPerSecond.Value, options.SamplingRatio);

                return new ApplicationInsightsSampler(options.SamplingRatio);
            }

            return new RateLimitedSampler(options.TracesPerSecond.Value);
        }
    }
}
