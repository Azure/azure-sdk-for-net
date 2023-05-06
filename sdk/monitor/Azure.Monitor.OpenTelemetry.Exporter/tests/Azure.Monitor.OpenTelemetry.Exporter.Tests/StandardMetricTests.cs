﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Metrics;
using OpenTelemetry;
using Xunit;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry.Trace;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StandardMetricTests
    {
        [Fact]
        public void ValidateRequestDurationMetric()
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateRequestDurationMetric));
            var traceTelemetryItems = new ConcurrentBag<TelemetryItem>();
            var metricTelemetryItems = new ConcurrentBag<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor();

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(nameof(StandardMetricTests.ValidateRequestDurationMetric))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new MockTransmitter(traceTelemetryItems))))
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                 .AddMeter(StandardMetricConstants.StandardMetricMeterName)
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)))
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Server))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpStatusCode, 200);
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            meterProvider?.ForceFlush();

            // Standard Metrics + Resource Metrics.
            Assert.Equal(2, metricTelemetryItems.Count);

            var metricTelemetry = metricTelemetryItems.Last()!;
            Assert.Equal("MetricData", metricTelemetry.Data.BaseType);
            var metricData = (MetricsData)metricTelemetry.Data.BaseData;
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.RequestSuccessKey, out var isSuccess));
            Assert.Equal("True", isSuccess);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.RequestResultCodeKey, out var resultCode));
            Assert.Equal("200", resultCode);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.IsAutoCollectedKey, out var isAutoCollectedFlag));
            Assert.Equal("True", isAutoCollectedFlag);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleInstanceKey, out _));
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out _));
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.RequestDurationMetricIdValue, metricId);
        }

        [Fact]
        public void ValidateDependencyDurationMetric()
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateDependencyDurationMetric));
            var traceTelemetryItems = new ConcurrentBag<TelemetryItem>();
            var metricTelemetryItems = new ConcurrentBag<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor();

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(nameof(StandardMetricTests.ValidateDependencyDurationMetric))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new MockTransmitter(traceTelemetryItems))))
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                 .AddMeter(StandardMetricConstants.StandardMetricMeterName)
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)))
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Client))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpStatusCode, 200);
                activity?.SetTag(SemanticConventions.AttributeHttpMethod, "Get");
                activity?.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.com");
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            meterProvider?.ForceFlush();

            // Standard Metrics + Resource Metrics.
            Assert.Equal(2, metricTelemetryItems.Count);

            var metricTelemetry = metricTelemetryItems.Last()!;
            Assert.Equal("MetricData", metricTelemetry.Data.BaseType);
            var metricData = (MetricsData)metricTelemetry.Data.BaseData;
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencySuccessKey, out var isSuccess));
            Assert.Equal("True", isSuccess);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyResultCodeKey, out var resultCode));
            Assert.Equal("200", resultCode);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.IsAutoCollectedKey, out var isAutoCollectedFlag));
            Assert.Equal("True", isAutoCollectedFlag);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleInstanceKey, out _));
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out _));
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.DependencyDurationMetricIdValue, metricId);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTypeKey, out var dependencyType));
            Assert.Equal("Http", dependencyType);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTargetKey, out var dependencyTarget));
            Assert.Equal("www.foo.com", dependencyTarget);
        }

        private void WaitForActivityExport(ConcurrentBag<TelemetryItem> traceTelemetryItems)
        {
            var result = SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return traceTelemetryItems.Any();
                },
                timeout: TimeSpan.FromSeconds(10));

            Assert.True(result, $"{nameof(WaitForActivityExport)} failed.");
        }
    }
}
