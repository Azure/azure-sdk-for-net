// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [CollectionDefinition("TraceExporterEnvVarTests", DisableParallelization = true)]
    public class AddAzureMonitorTraceExporterSamplerTests
    {
        private const string ConnStr = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        [Fact]
        public void EnvVar_RateLimitedSampler_Applied()
        {
            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.rate_limited");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "7");

                using var provider = Sdk.CreateTracerProviderBuilder()
                    .AddAzureMonitorTraceExporter(o => o.ConnectionString = ConnStr)
                    .Build();

                var sampler = GetSampler(provider);
                Assert.Equal("Azure.Monitor.OpenTelemetry.Exporter.Internals.RateLimitedSampler", sampler.GetType().FullName);
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevArg);
            }
        }

        [Fact]
        public void EnvVar_FixedPercentageSampler_Applied()
        {
            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "0.25");

                using var provider = Sdk.CreateTracerProviderBuilder()
                    .AddAzureMonitorTraceExporter(o => o.ConnectionString = ConnStr)
                    .Build();

                var sampler = GetSampler(provider);
                Assert.Equal("Azure.Monitor.OpenTelemetry.Exporter.Internals.ApplicationInsightsSampler", sampler.GetType().FullName);
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevArg);
            }
        }

        [Fact]
        public void ConfigureDelegate_OverridesEnvVar()
        {
            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "0.10");

                using var provider = Sdk.CreateTracerProviderBuilder()
                    .AddAzureMonitorTraceExporter(o => { o.ConnectionString = ConnStr; o.TracesPerSecond = 5; })
                    .Build();

                var sampler = GetSampler(provider);
                Assert.Equal("Azure.Monitor.OpenTelemetry.Exporter.Internals.RateLimitedSampler", sampler.GetType().FullName);
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevArg);
            }
        }

        private static Sampler GetSampler(TracerProvider provider)
        {
            // The concrete TracerProvider implementation is internal to OTel SDK; retrieve via reflection.
            var samplerProperty = provider.GetType().GetProperty("Sampler", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.NotNull(samplerProperty);
            var sampler = samplerProperty!.GetValue(provider) as Sampler;
            Assert.NotNull(sampler);
            return sampler!;
        }
    }
}
