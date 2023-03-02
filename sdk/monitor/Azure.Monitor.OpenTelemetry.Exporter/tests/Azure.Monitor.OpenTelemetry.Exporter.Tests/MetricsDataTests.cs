// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MetricsDataTests
    {
        private const int Version = 2;

        [InlineData(MetricType.DoubleSum)]
        [InlineData(MetricType.DoubleGauge)]
        [Theory]
        public void ValidateZeroDimension(MetricType metricType)
        {
            var metrics = new List<Metric>();

            using var meter = new Meter(nameof(ValidateZeroDimension));
            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meter.Name)
                .AddInMemoryExporter(metrics)
                .Build();

            var dataPointType = DataPointType.Aggregation;
            string? name = null;
            if (metricType == MetricType.DoubleSum)
            {
                name = "TestDoubleCounter";
                var doubleCounter = meter.CreateCounter<double>(name);
                doubleCounter.Add(123.45);
            }
            else if (metricType == MetricType.DoubleGauge)
            {
                name = "TestGauge";
                meter.CreateObservableGauge(name, () => 123.45);
            }

            provider.ForceFlush();

            var enumerator = metrics[0].GetMetricPoints().GetEnumerator();
            enumerator.MoveNext();
            var metricPoint = enumerator.Current;

            var metricData = new MetricsData(Version, metrics[0], metricPoint);
            Assert.Equal(2, metricData.Version);
            Assert.Equal(name, metricData.Metrics.First().Name);
            Assert.Equal(nameof(ValidateZeroDimension), metricData.Metrics.First().Namespace);
            Assert.Equal(123.45, metricData.Metrics.First().Value);
            Assert.Null(metricData.Metrics.First().DataPointType);
        }

        [InlineData(MetricType.DoubleSum)]
        [InlineData(MetricType.DoubleGauge)]
        [Theory]
        public void ValidateOneDimension(MetricType metricType)
        {
            var metrics = new List<Metric>();

            using var meter = new Meter(nameof(ValidateOneDimension));
            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meter.Name)
                .AddInMemoryExporter(metrics)
                .Build();

            var dataPointType = DataPointType.Aggregation;
            string? name = null;
            if (metricType == MetricType.DoubleSum)
            {
                name = "TestDoubleCounter";
                var doubleCounter = meter.CreateCounter<double>(name);
                doubleCounter.Add(123.45, new KeyValuePair<string, object?>("tag", "value"));
            }
            else if (metricType == MetricType.DoubleGauge)
            {
                name = "TestGauge";
                meter.CreateObservableGauge(
                    name,
                    () => new List<Measurement<double>>()
                    {
                    new(123.45, new KeyValuePair<string, object?>("tag", "value")),
                    });
            }

            provider.ForceFlush();

            var enumerator = metrics[0].GetMetricPoints().GetEnumerator();
            enumerator.MoveNext();
            var metricPoint = enumerator.Current;

            var metricData = new MetricsData(Version, metrics[0], metricPoint);
            Assert.Equal(2, metricData.Version);
            Assert.Equal(name, metricData.Metrics.First().Name);
            Assert.Equal(nameof(ValidateOneDimension), metricData.Metrics.First().Namespace);
            Assert.Equal(123.45, metricData.Metrics.First().Value);
            Assert.Null(metricData.Metrics.First().DataPointType);
            Assert.Equal("value", metricData.Properties["tag"]);
        }

        [Fact]
        public void ValidateSumDoubles()
        {
            var metrics = new List<Metric>();

            using var meter = new Meter(nameof(ValidateSumDoubles));
            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meter.Name)
                .AddInMemoryExporter(metrics)
                .Build();

            var doubleCounter = meter.CreateCounter<double>("TestDoubleCounter");
            doubleCounter.Add(double.MaxValue);
            doubleCounter.Add(double.MaxValue);

            provider.ForceFlush();

            var enumerator = metrics[0].GetMetricPoints().GetEnumerator();
            enumerator.MoveNext();
            var metricPoint = enumerator.Current;

            var metricData = new MetricsData(Version, metrics[0], metricPoint);
            Assert.Equal(nameof(ValidateSumDoubles), metricData.Metrics.First().Namespace);
            Assert.Equal(double.PositiveInfinity, metricData.Metrics.First().Value);
            Assert.Null(metricData.Metrics.First().DataPointType);
        }

        [Fact]
        public void ValidateLimits()
        {
            var metrics = new List<Metric>();

            using var meter = new Meter(nameof(ValidateLimits));
            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meter.Name)
                .AddInMemoryExporter(metrics)
                .Build();

            var doubleCounter1 = meter.CreateCounter<double>("TestDoubleCounter1");
            doubleCounter1.Add(double.PositiveInfinity);

            var doubleCounter2 = meter.CreateCounter<double>("TestDoubleCounter2");
            doubleCounter2.Add(double.NegativeInfinity);

            var doubleCounter3 = meter.CreateCounter<double>("TestDoubleCounter3");
            doubleCounter3.Add(double.NaN);

            provider.ForceFlush();

            // Validate PositiveInfinity
            var enumerator = metrics[0].GetMetricPoints().GetEnumerator();
            enumerator.MoveNext();
            var metricPoint = enumerator.Current;
            var metricData = new MetricsData(Version, metrics[0], metricPoint);
            Assert.Equal(double.PositiveInfinity, metricData.Metrics.First().Value);

            // Validate NegativeInfinity
            enumerator = metrics[1].GetMetricPoints().GetEnumerator();
            enumerator.MoveNext();
            metricPoint = enumerator.Current;
            metricData = new MetricsData(Version, metrics[1], metricPoint);
            Assert.Equal(double.NegativeInfinity, metricData.Metrics.First().Value);

            // Validate NaN
            enumerator = metrics[2].GetMetricPoints().GetEnumerator();
            enumerator.MoveNext();
            metricPoint = enumerator.Current;
            metricData = new MetricsData(Version, metrics[2], metricPoint);
            Assert.Equal(nameof(ValidateLimits), metricData.Metrics.First().Namespace);
            Assert.Equal(double.NaN, metricData.Metrics.First().Value);
        }

        [Fact]
        public void ThrowsIfMetricIsNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var metricPoint = new MetricPoint();
            Assert.Throws<ArgumentNullException>(() => new MetricsData(Version, null, metricPoint));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
