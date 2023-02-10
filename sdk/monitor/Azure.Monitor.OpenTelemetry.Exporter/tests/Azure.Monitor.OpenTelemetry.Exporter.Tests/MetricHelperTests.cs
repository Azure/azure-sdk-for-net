﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Metrics;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MetricHelperTests
    {
        [Fact]
        public void ValidateMetricTelemetryItem()
        {
            var metrics = new List<Metric>();

            using var meter = new Meter(nameof(ValidateMetricTelemetryItem));
            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meter.Name)
                .AddInMemoryExporter(metrics)
                .Build();

            var doubleCounter = meter.CreateCounter<double>("TestDoubleCounter");
            doubleCounter.Add(123.45);
            provider.ForceFlush();

            var metricResource = new AzureMonitorResource()
            {
                RoleName = "testRoleName",
                RoleInstance = "testRoleInstance"
            };
            var telemetryItems = MetricHelper.OtelToAzureMonitorMetrics(new Batch<Metric>(metrics.ToArray(), 1), metricResource, "00000000-0000-0000-0000-000000000000");
            Assert.Single(telemetryItems);
            Assert.Equal("MetricData", telemetryItems[0].Data.BaseType);
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItems[0].InstrumentationKey);
            Assert.Equal(metricResource.RoleName, telemetryItems[0].Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal(metricResource.RoleInstance, telemetryItems[0].Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);

            var metricsData = (MetricsData)telemetryItems[0].Data.BaseData;
            Assert.Equal(2, metricsData.Version);
            Assert.Equal("TestDoubleCounter", metricsData.Metrics.First().Name);
            Assert.Equal(123.45, metricsData.Metrics.First().Value);
            Assert.Null(metricsData.Metrics.First().DataPointType);
        }
    }
}
