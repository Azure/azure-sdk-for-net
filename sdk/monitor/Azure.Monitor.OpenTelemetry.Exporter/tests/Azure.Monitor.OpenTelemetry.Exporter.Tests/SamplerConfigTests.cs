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
        public void DefaultToApplicationInsightsSampler()
        {
            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

            var sampler = SamplerConfig.CreateSampler(options);

            Assert.IsType<ApplicationInsightsSampler>(sampler);
        }

        [Fact]
        public void EnvVarHasPrecedenceOverCodeConfig()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, "microsoft.rate_limited");
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, "10");

            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            options.SamplingRatio = 0.5F; // This should be ignored due to env var precedence

            var sampler = SamplerConfig.CreateSampler(options);
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
            var sampler = SamplerConfig.CreateSampler(options);
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
            var sampler = SamplerConfig.CreateSampler(options);
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
            var sampler = SamplerConfig.CreateSampler(options);
            Assert.IsType<ApplicationInsightsSampler>(sampler);

            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER, null);
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG, null);
        }

        [Fact]
        public void IfBothOptionsSetViaCodeUseRateLimitedSampler()
        {
            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            options.TracesPerSecond = 10;
            options.SamplingRatio = 0.5F;
            var sampler = SamplerConfig.CreateSampler(options);
            Assert.IsType<RateLimitedSampler>(sampler);
        }

        [Fact]
        public void IfOnlySamplingRatioSetUseApplicationInsightsSampler()
        {
            var options = new AzureMonitorExporterOptions();
            options.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            options.SamplingRatio = 0.5F;
            var sampler = SamplerConfig.CreateSampler(options);
            Assert.IsType<ApplicationInsightsSampler>(sampler);
        }
    }
}