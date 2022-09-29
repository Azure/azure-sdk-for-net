// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="MeterProvider"/> and <see cref="Meter"/>.
    /// </summary>
    public class MetricsTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyCounter(bool asView)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var meterName = $"meterName{uniqueTestId}";
            using var meter = new Meter(meterName, "1.0");

            var meterProviderBulider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems);

            if (asView)
            {
                meterProviderBulider
                    // Rename an instrument to new name.
                    .AddView(instrumentName: "MyCounter", name: "MyCounterRenamed");
            }

            var meterProvider = meterProviderBulider.Build();

            // ACT
            var counter = meter.CreateCounter<long>("MyCounter");
            for (int i = 0; i < 20000; i++)
            {
                counter.Add(1, new("tag1", "value1"), new("tag2", "value2"));
            }

            // CLEANUP
            meterProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertCounter_As_MetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricsName: asView ? "MyCounterRenamed" : "MyCounter",
                expectedMetricsNamespace: meterName,
                expectedMetricsValue: 20000,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyHistogram(bool asView)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var meterName = $"meterName{uniqueTestId}";
            using var meter = new Meter(meterName, "1.0");

            var meterProviderBulider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems);

            if (asView)
            {
                meterProviderBulider
                // Change Histogram boundaries
                .AddView(instrumentName: "MyHistogram", new ExplicitBucketHistogramConfiguration() { Boundaries = new double[] { 10, 20 } });
            }

            var meterProvider = meterProviderBulider.Build();

            // ACT
            var histogram = meter.CreateHistogram<long>("MyHistogram");
            var random = new Random();
            int loop = 20000, sum = 0;
            for (int i = 0; i < loop; i++)
            {
                var value = random.Next(1, 1000);
                sum += value;
                histogram.Record(value, new("tag1", "value1"), new("tag2", "value2"));
            }

            // CLEANUP
            meterProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertHistogram_As_MetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricsName: "MyHistogram",
                expectedMetricsNamespace: meterName,
                expectedMetricsCount: loop,
                expectedMetricsValue: sum,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });
        }
    }
}
