// Copyright (c) Microsoft Corporation. All rights reserved.
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
            doubleCounter.Add(123.45, new("tag0", null), new("tag1", "value1"), new("tag2", new[] { 1, 2, 3 }), new("tag3", new object?[] { null, null }));
            provider.ForceFlush();

            var metricResource = new AzureMonitorResource(
                roleName: "testRoleName",
                roleInstance: "testRoleInstance",
                serviceVersion: null,
                monitorBaseData: null);
            (var telemetryItems, var telemetryCounter) = MetricHelper.OtelToAzureMonitorMetrics(new Batch<Metric>(metrics.ToArray(), 1), metricResource, "00000000-0000-0000-0000-000000000000");
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

            Assert.Equal(3, metricsData.Properties.Count);
            Assert.Contains(metricsData.Properties, kvp => kvp.Key == "tag1" && kvp.Value == "value1");
            Assert.Contains(metricsData.Properties, kvp => kvp.Key == "tag2" && kvp.Value == "1,2,3");
            Assert.Contains(metricsData.Properties, kvp => kvp.Key == "tag3" && kvp.Value == string.Empty);

            // Validate TelemetryCounter
            Assert.Equal(1, telemetryCounter._metricCount);
            Assert.Equal(0, telemetryCounter._requestCount);
            Assert.Equal(0, telemetryCounter._dependencyCount);
            Assert.Equal(0, telemetryCounter._exceptionCount);
            Assert.Equal(0, telemetryCounter._eventCount);
            Assert.Equal(0, telemetryCounter._traceCount);
        }
    }
}
