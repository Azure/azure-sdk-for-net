// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
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

        internal readonly Dictionary<string, object> testResourceAttributes = new()
        {
            { "service.instance.id", "testInstance" },
            { "service.name", "testName" },
            { "service.namespace", "testNamespace" },
            { "service.version", "testVersion" },
        };

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

            var meterProviderBuilder = Sdk.CreateMeterProviderBuilder()
                .ConfigureResource(x => x.AddAttributes(testResourceAttributes))
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out List<TelemetryItem> telemetryItems);

            if (asView)
            {
                meterProviderBuilder
                    // Rename an instrument to new name.
                    .AddView(instrumentName: "MyCounter", name: "MyCounterRenamed");
            }

            var meterProvider = meterProviderBuilder.Build();

            // ACT
            var counter = meter.CreateCounter<long>("MyCounter");
            for (int i = 0; i < 20000; i++)
            {
                counter.Add(1, new("tag1", "value1"), new("tag2", "value2"));
            }

            // CLEANUP
            meterProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Last()!;

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyCounterRenamed" : "MyCounter",
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

            var meterProviderBuilder = Sdk.CreateMeterProviderBuilder()
                .ConfigureResource(x => x.AddAttributes(testResourceAttributes))
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out List<TelemetryItem> telemetryItems);

            if (asView)
            {
                meterProviderBuilder
                // Change Histogram boundaries
                .AddView(instrumentName: "MyHistogram", name: "MyHistogramRenamed");
            }

            var meterProvider = meterProviderBuilder.Build();

            // ACT
            var histogram = meter.CreateHistogram<long>("MyHistogram");
            var random = new Random();
            int loop = 20000, sum = 0;
            double min = double.MaxValue, max = double.MinValue;
            for (int i = 0; i < loop; i++)
            {
                var value = random.Next(1, 1000);
                sum += value;
                min = Math.Min(min, value);
                max = Math.Max(max, value);
                histogram.Record(value, new("tag1", "value1"), new("tag2", "value2"));
            }

            // CLEANUP
            meterProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Last()!;

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyHistogramRenamed" : "MyHistogram",
                expectedMetricDataPointValue: sum,
                expectedMetricDataPointCount: loop,
                expectedMetricDataPointMax:max,
                expectedMetricDataPointMin:min,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyGauge(bool asView)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var meterName = $"meterName{uniqueTestId}";
            using var meter = new Meter(meterName, "1.0");

            var meterProviderBuilder = Sdk.CreateMeterProviderBuilder()
                .ConfigureResource(x => x.AddAttributes(testResourceAttributes))
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out List<TelemetryItem> telemetryItems);

            if (asView)
            {
                meterProviderBuilder
                    .AddView(instrumentName: "MyGauge", name: "MyGaugeRenamed");
            }

            var meterProvider = meterProviderBuilder?.Build();

            // ACT
            var myObservableGauge = meter.CreateObservableGauge("MyGauge", () =>
                new Measurement<double>(
                    value: 123.45,
                    tags: new KeyValuePair<string, object?>("tag1", "value1")));

            // CLEANUP
            meterProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Last()!;

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyGaugeRenamed" : "MyGauge",
                expectedMetricDataPointValue: 123.45,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" } });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyUpDownCounter(bool asView)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var meterName = $"meterName{uniqueTestId}";
            using var meter = new Meter(meterName, "1.0");

            var meterProviderBuilder = Sdk.CreateMeterProviderBuilder()
                .ConfigureResource(x => x.AddAttributes(testResourceAttributes))
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out List<TelemetryItem> telemetryItems);

            if (asView)
            {
                meterProviderBuilder
                .AddView(instrumentName: "MyUpDownCounter", name: "MyUpDownCounterRenamed");
            }

            var meterProvider = meterProviderBuilder.Build();

            // ACT
            var upDownCounter = meter.CreateUpDownCounter<long>("MyUpDownCounter");

            upDownCounter.Add(1, new("tag1", "value1"), new("tag2", "value2"));
            upDownCounter.Add(-2, new("tag1", "value1"), new("tag2", "value2"));
            upDownCounter.Add(3, new("tag1", "value1"), new("tag2", "value2"));
            upDownCounter.Add(-4, new("tag1", "value1"), new("tag2", "value2"));

            // CLEANUP
            meterProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Last()!;

            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem,
                expectedMetricDataPointName: asView ? "MyUpDownCounterRenamed" : "MyUpDownCounter",
                expectedMetricDataPointValue: -2,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyObservableUpDownCounter(bool asView)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var meterName = $"meterName{uniqueTestId}";
            using var meter = new Meter(meterName, "1.0");

            var meterProviderBuilder = Sdk.CreateMeterProviderBuilder()
                .ConfigureResource(x => x.AddAttributes(testResourceAttributes))
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporterForTest(out List<TelemetryItem> telemetryItems, out MetricReader metricReader);

            if (asView)
            {
                meterProviderBuilder
                .AddView(instrumentName: "MyUpDownCounter", name: "MyUpDownCounterRenamed");
            }

            using var meterProvider = meterProviderBuilder.Build();

            // ACT
            var value = 1;
            var upDownCounter = meter.CreateObservableUpDownCounter<long>("MyUpDownCounter", () =>
            {
                value = value * -2;
                return new Measurement<long>(value, new("tag1", "value1"), new("tag2", "value2"));
            });

            // ASSERT
            metricReader.Collect();
            Assert.True(telemetryItems.Count == 1);
            var telemetryItem = telemetryItems.Last()!;
            this.telemetryOutput.Write(telemetryItem);
            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem!,
                expectedMetricDataPointName: asView ? "MyUpDownCounterRenamed" : "MyUpDownCounter",
                expectedMetricDataPointValue: -2,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });

            // Clear the telemetryItems.
            telemetryItems.Clear();

            metricReader.Collect();
            Assert.True(telemetryItems.Count == 1);
            telemetryItem = telemetryItems.Last()!;
            this.telemetryOutput.Write(telemetryItem!);
            TelemetryItemValidationHelper.AssertMetricTelemetry(
                telemetryItem: telemetryItem!,
                expectedMetricDataPointName: asView ? "MyUpDownCounterRenamed" : "MyUpDownCounter",
                expectedMetricDataPointValue: 4,
                expectedMetricsProperties: new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" } });
        }
    }
}
