// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class SamplerConfigTests
    {
        [Fact]
        public void TraceExporterSupportsOtelSamplingEnvVars()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, "microsoft.rate_limited");
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, "10");

            var builder = Sdk.CreateTracerProviderBuilder()
            .AddAzureMonitorTraceExporter(options =>
            {
                options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            });

            var sampler = builder.GetType().GetField("Sampler", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(sampler);
            Assert.IsType<RateLimitedSampler>(sampler);
        }

        [Fact]
    }
}