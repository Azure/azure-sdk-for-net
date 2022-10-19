// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="MeterProvider"/> and <see cref="Meter"/>.
    /// </summary>
    public class MetricsTests
    {
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        public MetricsTests(ITestOutputHelper output)
        {
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

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
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyCounterRenamed" : "MyCounter",
                expectedMetricDataPointNamespace: meterName,
                expectedMetricDataPointValue: 20000,
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
                .AddView(instrumentName: "MyHistogram", name: "MyHistogramRenamed");
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
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyHistogramRenamed" : "MyHistogram",
                expectedMetricDataPointNamespace: meterName,
                expectedMetricDataPointValue: sum,
                expectedMetricDataPointCount: loop,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyGuage(bool asView)
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
                    .AddView(instrumentName: "MyGuage", name: "MyGuageRenamed");
            }

            var meterProvider = meterProviderBulider.Build();

            // ACT
            var myObservableGauge = meter.CreateObservableGauge("MyGuage", () =>
                new Measurement<double>(
                    value: 123.45,
                    tags: new KeyValuePair<string, object>("tag1", "value1")));

            // CLEANUP
            meterProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyGuageRenamed" : "MyGuage",
                expectedMetricDataPointNamespace: meterName,
                expectedMetricDataPointValue: 123.45,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" } });
        }
    }
}
