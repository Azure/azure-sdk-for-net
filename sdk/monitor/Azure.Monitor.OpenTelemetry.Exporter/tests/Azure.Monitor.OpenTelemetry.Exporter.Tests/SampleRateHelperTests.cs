// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class SampleRateHelperTests
    {
        [Theory]
        [InlineData(1F, 100.0)]
        [InlineData(0.5F, 50.0)]
        [InlineData(0.3F, 30.0)]
        [InlineData(0.333F, 33.0)]
        [InlineData(0F, 0.0)]
        public void FromSamplingRatioRoundsToWholePercentage(float samplingRatio, double expected)
        {
            Assert.Equal(expected, SampleRateHelper.FromSamplingRatio(samplingRatio));
        }

        [Fact]
        public void FromSamplingRatioKeepsSubPercentRatesAboveZero()
        {
            Assert.Equal(0.1, SampleRateHelper.FromSamplingRatio(0.001F), precision: 5);
        }

        [Theory]
        [InlineData(0.025F, 2.0)]
        [InlineData(0.045F, 4.0)]
        public void FromSamplingRatioRoundsInSinglePrecision(float samplingRatio, double expected)
        {
            Assert.Equal(expected, SampleRateHelper.FromSamplingRatio(samplingRatio));
        }

        /// <summary>
        /// Fixed-ratio users must see the envelope sampleRate earlier releases sent, which was
        /// <c>(float)Math.Round(SamplingRatio * 100)</c>, for every ratio that did not round to zero.
        /// </summary>
        [Fact]
        public void FromSamplingRatioMatchesEarlierReleases()
        {
            for (int i = 1; i <= 1000; i++)
            {
                float samplingRatio = i / 1000F;
                float previous = (float)Math.Round(samplingRatio * 100);
                if (previous > 0)
                {
                    Assert.True(previous == (float)SampleRateHelper.FromSamplingRatio(samplingRatio), $"Ratio {samplingRatio:R}: expected {previous}, got {SampleRateHelper.FromSamplingRatio(samplingRatio)}");
                }
            }
        }

        [Fact]
        public void FallbackUsesSamplingRatioOnlyWithoutTracesPerSecond()
        {
            Assert.Equal(50f, SampleRateHelper.GetFallbackSampleRate(new AzureMonitorExporterOptions { SamplingRatio = 0.5F, TracesPerSecond = null }));
            Assert.Equal(100f, SampleRateHelper.GetFallbackSampleRate(new AzureMonitorExporterOptions { SamplingRatio = 0.5F, TracesPerSecond = 5 }));
        }

        [Theory]
        [InlineData(100f, false)]
        [InlineData(50f, true)]
        [InlineData(0.1f, true)]
        [InlineData(0f, false)]
        public void IsReportableExcludesFullAndNonPositiveRates(float sampleRate, bool expected)
        {
            Assert.Equal(expected, SampleRateHelper.IsReportable(sampleRate));
        }

        [Fact]
        public void TryGetSampleRateRejectsNull()
        {
            Assert.False(SampleRateHelper.TryGetSampleRate(null, out _));
        }

        [Fact]
        public void TryGetSampleRateAcceptsDecimal()
        {
            Assert.True(SampleRateHelper.TryGetSampleRate(12.5m, out var sampleRate));
            Assert.Equal(12.5f, sampleRate);
        }
    }
}
