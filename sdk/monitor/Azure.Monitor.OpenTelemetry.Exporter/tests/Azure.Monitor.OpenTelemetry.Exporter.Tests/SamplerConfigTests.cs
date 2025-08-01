// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class SamplerConfigTests
    {
        [Fact]
        public void TraceExporterSupportsRateLimitedSampler()
        {
            var builder = Sdk.CreateTracerProviderBuilder()
            .AddAzureMonitorTraceExporter(options =>
            {
                options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
                options.TracesPerSecond = 10;
            });

            var sampler = builder.GetType().GetField("Sampler", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(sampler);
            Assert.IsType<RateLimitedSampler>(sampler);
        }

        [Fact]
        public void AzureMonitorExporterSupportsRateLimitedSampler()
        {
            var builder = Sdk.CreateTracerProviderBuilder()
            .UseAzureMonitorExporter(options =>
            {
                options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
                options.TracesPerSecond = 10;
            });

            var sampler = builder.GetType().GetField("Sampler", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(sampler);
            Assert.IsType<RateLimitedSampler>(sampler);
        }

        [Fact]
        public void DefaultToApplicationInsightsSampler()
        {
            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

            var sampler = SamplerFactory.CreateSampler(options);

            Assert.IsType<ApplicationInsightsSampler>(sampler);
        }

        public void EnvVarHasPrecedenceOverCodeConfig()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, "microsoft.rate_limited");
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, "10");

            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            options.SamplingRatio = 0.5F; // This should be ignored due to env var precedence

            var sampler = SamplerFactory.CreateSampler(options);
            Assert.IsType<RateLimitedSampler>(sampler);

            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, null);
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, null);
        }

        [Fact]
        public void EnvVarWithUnsupportedSamplerFallsBackToDefaultIfNoOptionSet()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, "AlwaysOn");


            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            var sampler = SamplerFactory.CreateSampler(options);
            Assert.IsType<ApplicationInsightsSampler>(sampler);

            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, null);
        }

        [Fact]
        public void EnvVarWithUnsupportedSamplerFallsBackToOptionIfSet()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, "AlwaysOn");

            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            options.TracesPerSecond = 10; // This should be used instead of the env var
            var sampler = SamplerFactory.CreateSampler(options);
            Assert.IsType<RateLimitedSampler>(sampler);

            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, null);
        }

        [Fact]
        public void EnvVarWithInvalidSamplerArgFallsBackToDefaultIfNoOptionSet()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, "microsoft.rate_limited");
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, "blah");

            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            var sampler = SamplerFactory.CreateSampler(options);
            Assert.IsType<ApplicationInsightsSampler>(sampler);

            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, null);
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, null);
        }
        
        

    }

}