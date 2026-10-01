// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class SamplerFactoryTests
    {
        [Fact]
        public void RateLimitedSamplingIsUsedWhenConfiguredAndMultiEndpointIsOff()
        {
            var options = new AzureMonitorExporterOptions { TracesPerSecond = 5.0 };

            Assert.IsType<RateLimitedSampler>(SamplerFactory.Create(options, multiEndpointEnabled: false));
        }

        /// <summary>
        /// The rate limit counts traces per process, so one limit would be shared across every
        /// destination the process carries and split between them by arrival order alone.
        /// </summary>
        [Fact]
        public void RateLimitedSamplingIsReplacedByFixedRateWhenMultiEndpointIsOn()
        {
            var options = new AzureMonitorExporterOptions { TracesPerSecond = 5.0 };

            Assert.IsType<ApplicationInsightsSampler>(SamplerFactory.Create(options, multiEndpointEnabled: true));
        }

        /// <summary>
        /// The default is fixed-rate at 100%, because <see cref="AzureMonitorExporterOptions.SamplingRatio"/>
        /// defaults to 1.0.
        /// </summary>
        [Fact]
        public void MultiEndpointDefaultsToFullFixedRateSampling()
        {
            var sampler = SamplerFactory.Create(new AzureMonitorExporterOptions(), multiEndpointEnabled: true);

            Assert.Equal("ApplicationInsightsSampler{1}", sampler.Description);
        }

        /// <summary>
        /// An explicit ratio is still honoured; only the rate limit is overridden.
        /// </summary>
        [Fact]
        public void MultiEndpointHonoursAnExplicitSamplingRatio()
        {
            var options = new AzureMonitorExporterOptions { SamplingRatio = 0.5F };

            var sampler = SamplerFactory.Create(options, multiEndpointEnabled: true);

            Assert.Equal("ApplicationInsightsSampler{0.5}", sampler.Description);
        }

        [Fact]
        public void FixedRateIsUsedWhenNoRateLimitIsConfigured()
        {
            var options = new AzureMonitorExporterOptions { TracesPerSecond = null };

            Assert.IsType<ApplicationInsightsSampler>(SamplerFactory.Create(options, multiEndpointEnabled: false));
        }
    }
}
