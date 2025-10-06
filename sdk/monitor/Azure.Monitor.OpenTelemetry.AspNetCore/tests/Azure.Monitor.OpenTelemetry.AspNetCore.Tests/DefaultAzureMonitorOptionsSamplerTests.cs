// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    [CollectionDefinition("AspNetCoreSamplerEnvVarTests", DisableParallelization = true)]
    public class DefaultAzureMonitorOptionsSamplerTests
    {
        [Fact]
        public void Configure_Sampler_From_IConfiguration_FixedPercentage()
        {
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage"),
                new("OTEL_TRACES_SAMPLER_ARG", "0.40"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var configurator = new DefaultAzureMonitorOptions(configuration);
            var options = new AzureMonitorOptions();

            configurator.Configure(options);

            Assert.Equal(0.40f, options.SamplingRatio);
            Assert.Null(options.TracesPerSecond);
        }

        [Fact]
        public void Configure_Sampler_From_IConfiguration_RateLimited()
        {
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.rate_limited"),
                new("OTEL_TRACES_SAMPLER_ARG", "15"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var configurator = new DefaultAzureMonitorOptions(configuration);
            var options = new AzureMonitorOptions();

            configurator.Configure(options);

            Assert.Equal(15d, options.TracesPerSecond);
            Assert.Equal(1.0f, options.SamplingRatio); // default unchanged
        }

        [Fact]
        public void Configure_Sampler_InvalidArgs_Ignored()
        {
            // invalid percentage > 1
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage"),
                new("OTEL_TRACES_SAMPLER_ARG", "1.5"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var configurator = new DefaultAzureMonitorOptions(configuration);
            var options = new AzureMonitorOptions();
            configurator.Configure(options);
            Assert.Equal(1.0f, options.SamplingRatio); // default
            Assert.Null(options.TracesPerSecond);

            // invalid negative rate
            configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.rate_limited"),
                new("OTEL_TRACES_SAMPLER_ARG", "-2"),
            };
            configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            configurator = new DefaultAzureMonitorOptions(configuration);
            options = new AzureMonitorOptions();
            configurator.Configure(options);
            Assert.Null(options.TracesPerSecond);
            Assert.Equal(1.0f, options.SamplingRatio);
        }

        [Fact]
        public void Configure_Sampler_EnvironmentVariable_Overrides_IConfiguration()
        {
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage"),
                new("OTEL_TRACES_SAMPLER_ARG", "0.20"),
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();
            var configurator = new DefaultAzureMonitorOptions(configuration);
            var options = new AzureMonitorOptions();

            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevSamplerArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.rate_limited");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "11");

                configurator.Configure(options);

                Assert.Equal(0.20f, options.SamplingRatio); // from config
                Assert.Equal(11d, options.TracesPerSecond); // from env
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevSamplerArg);
            }
        }

        [Fact]
        public void Configure_Sampler_EnvironmentVariable_Only_FixedPercentage()
        {
            string? prevSampler = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER");
            string? prevSamplerArg = Environment.GetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG");
            try
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage");
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "0.55");

                var configurator = new DefaultAzureMonitorOptions();
                var options = new AzureMonitorOptions();
                configurator.Configure(options);

                Assert.Equal(0.55f, options.SamplingRatio);
                Assert.Null(options.TracesPerSecond);
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", prevSampler);
                Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", prevSamplerArg);
            }
        }
    }
}
