// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [CollectionDefinition("ExporterEnvVarTests", DisableParallelization = true)]
    public class DefaultAzureMonitorExporterOptionsTests
    {
        [Fact]
        public void Configure_Sampler_From_IConfiguration_FixedPercentage()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage"),
                new("OTEL_TRACES_SAMPLER_ARG", "0.25"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var defaultConfigurator = new DefaultAzureMonitorExporterOptions(configuration);
            var options = new AzureMonitorExporterOptions();

            // Act
            defaultConfigurator.Configure(options);

            // Assert
            Assert.Equal(0.25f, options.SamplingRatio);
            Assert.Null(options.TracesPerSecond); // Not set for fixed percentage
        }

        [Fact]
        public void Configure_Sampler_From_IConfiguration_RateLimited()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.rate_limited"),
                new("OTEL_TRACES_SAMPLER_ARG", "5"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var defaultConfigurator = new DefaultAzureMonitorExporterOptions(configuration);
            var options = new AzureMonitorExporterOptions();

            // Act
            defaultConfigurator.Configure(options);

            // Assert
            Assert.Equal(5d, options.TracesPerSecond);
            Assert.Equal(1.0f, options.SamplingRatio); // untouched
        }

        [Fact]
        public void Configure_Sampler_InvalidArgs_Ignored()
        {
            // Arrange invalid fixed percentage (>1)
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage"),
                new("OTEL_TRACES_SAMPLER_ARG", "1.5"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var defaultConfigurator = new DefaultAzureMonitorExporterOptions(configuration);
            var options = new AzureMonitorExporterOptions();

            // Act
            defaultConfigurator.Configure(options);

            // Assert - defaults unchanged
            Assert.Equal(1.0f, options.SamplingRatio);
            Assert.Null(options.TracesPerSecond);

            // Now test invalid negative rate_limited
            configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.rate_limited"),
                new("OTEL_TRACES_SAMPLER_ARG", "-2"),
            };
            configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            defaultConfigurator = new DefaultAzureMonitorExporterOptions(configuration);
            options = new AzureMonitorExporterOptions();

            // Act
            defaultConfigurator.Configure(options);

            // Assert
            Assert.Null(options.TracesPerSecond);
            Assert.Equal(1.0f, options.SamplingRatio);
        }

        [Fact]
        public void Configure_Sampler_EnvironmentVariable_Only_FixedPercentage()
        {
            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevSamplerArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "0.30");

                var defaultConfigurator = new DefaultAzureMonitorExporterOptions();
                var options = new AzureMonitorExporterOptions();

                // Act
                defaultConfigurator.Configure(options);

                // Assert
                Assert.Equal(0.30f, options.SamplingRatio);
                Assert.Null(options.TracesPerSecond);
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevSamplerArg);
            }
        }

        [Fact]
        public void Configure_Sampler_EnvironmentVariable_Overrides_IConfiguration()
        {
            // Arrange - configuration provides fixed percentage
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage"),
                new("OTEL_TRACES_SAMPLER_ARG", "0.50"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var defaultConfigurator = new DefaultAzureMonitorExporterOptions(configuration);
            var options = new AzureMonitorExporterOptions();

            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevSamplerArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                // Environment overrides to rate_limited 10
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.rate_limited");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "10");

                // Act
                defaultConfigurator.Configure(options);

                // Assert
                Assert.Equal(0.50f, options.SamplingRatio); // value from config still present
                Assert.Equal(10d, options.TracesPerSecond); // overridden by env var
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevSamplerArg);
            }
        }
    }
}
