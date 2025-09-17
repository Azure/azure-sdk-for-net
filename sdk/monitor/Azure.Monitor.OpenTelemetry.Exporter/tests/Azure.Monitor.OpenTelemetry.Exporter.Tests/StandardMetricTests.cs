// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using OpenTelemetry.Resources;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StandardMetricTests
    {
        [Fact]
        public void ValidateRequestDurationMetric()
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateRequestDurationMetric));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            var traceServiceName = new KeyValuePair<string, object>("service.name", "trace.service");
            var resourceAttributes = new KeyValuePair<string, object>[] { traceServiceName };

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes))
                .AddSource(nameof(StandardMetricTests.ValidateRequestDurationMetric))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Server))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpStatusCode, 200);
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            Assert.Single(metricTelemetryItems);

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
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out var cloudRoleName));
            Assert.Equal("trace.service", cloudRoleName);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.RequestDurationMetricIdValue, metricId);
        }

        [Fact]
        public void ValidateRequestDurationMetricNew()
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateRequestDurationMetric));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            var traceServiceName = new KeyValuePair<string, object>("service.name", "trace.service");
            var resourceAttributes = new KeyValuePair<string, object>[] { traceServiceName };

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes))
                .AddSource(nameof(StandardMetricTests.ValidateRequestDurationMetric))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Server))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, 200);
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            Assert.Single(metricTelemetryItems);

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
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out var cloudRoleName));
            Assert.Equal("trace.service", cloudRoleName);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.RequestDurationMetricIdValue, metricId);
        }

        [Fact]
        public void ValidateRequestDurationMetricConsumerKind()
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateRequestDurationMetricConsumerKind));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            var traceServiceName = new KeyValuePair<string, object>("service.name", "trace.service");
            var resourceAttributes = new KeyValuePair<string, object>[] { traceServiceName };

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes))
                .AddSource(nameof(StandardMetricTests.ValidateRequestDurationMetricConsumerKind))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Consumer))
            {
                activity?.SetTag(SemanticConventions.AttributeMessagingSystem, "messagingsystem");
                activity?.SetTag(SemanticConventions.AttributeServerAddress, "localhost");
                activity?.SetTag(SemanticConventions.AttributeMessagingDestinationName, "destination");
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            Assert.Single(metricTelemetryItems);

            var metricTelemetry = metricTelemetryItems.Last()!;
            Assert.Equal("MetricData", metricTelemetry.Data.BaseType);
            var metricData = (MetricsData)metricTelemetry.Data.BaseData;
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.RequestSuccessKey, out var isSuccess));
            Assert.Equal("True", isSuccess);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.RequestResultCodeKey, out var resultCode));
            Assert.Equal("0", resultCode);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.IsAutoCollectedKey, out var isAutoCollectedFlag));
            Assert.Equal("True", isAutoCollectedFlag);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleInstanceKey, out _));
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out var cloudRoleName));
            Assert.Equal("trace.service", cloudRoleName);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.RequestDurationMetricIdValue, metricId);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidateDependencyDurationMetric(bool isAzureSDK)
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateDependencyDurationMetric));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            var traceServiceName = new KeyValuePair<string, object>("service.name", "trace.service");
            var resourceAttributes = new KeyValuePair<string, object>[] { traceServiceName };

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes))
                .AddSource(nameof(StandardMetricTests.ValidateDependencyDurationMetric))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Client))
            {
                if (isAzureSDK)
                {
                    activity?.SetTag(SemanticConventions.AttributeAzureNameSpace, "aznamespace");
                }
                activity?.SetTag(SemanticConventions.AttributeHttpStatusCode, 200);
                activity?.SetTag(SemanticConventions.AttributeHttpMethod, "Get");
                activity?.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.com");
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            Assert.Single(metricTelemetryItems);

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
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out var cloudRoleName));
            Assert.Equal("trace.service", cloudRoleName);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.DependencyDurationMetricIdValue, metricId);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTypeKey, out var dependencyType));
            if (isAzureSDK)
            {
                Assert.Equal("aznamespace", dependencyType);
            }
            else
            {
                Assert.Equal("Http", dependencyType);
            }

            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTargetKey, out var dependencyTarget));
            Assert.Equal("www.foo.com", dependencyTarget);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidateDependencyDurationMetricForProducerKind(bool isAzureSDKSpan)
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateDependencyDurationMetricForProducerKind));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            var traceServiceName = new KeyValuePair<string, object>("service.name", "trace.service");
            var resourceAttributes = new KeyValuePair<string, object>[] { traceServiceName };

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes))
                .AddSource(nameof(StandardMetricTests.ValidateDependencyDurationMetricForProducerKind))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Producer))
            {
                if (isAzureSDKSpan)
                {
                    activity?.SetTag(SemanticConventions.AttributeAzureNameSpace, "aznamespace");
                }
                activity?.SetTag(SemanticConventions.AttributeMessagingSystem, "messagingsystem");
                activity?.SetTag(SemanticConventions.AttributeServerAddress, "localhost");
                activity?.SetTag(SemanticConventions.AttributeMessagingDestinationName, "destination");
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            Assert.Single(metricTelemetryItems);

            var metricTelemetry = metricTelemetryItems.Last()!;
            Assert.Equal("MetricData", metricTelemetry.Data.BaseType);
            var metricData = (MetricsData)metricTelemetry.Data.BaseData;
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencySuccessKey, out var isSuccess));
            Assert.Equal("True", isSuccess);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyResultCodeKey, out var resultCode));
            Assert.Equal("0", resultCode);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.IsAutoCollectedKey, out var isAutoCollectedFlag));
            Assert.Equal("True", isAutoCollectedFlag);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleInstanceKey, out _));
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out var cloudRoleName));
            Assert.Equal("trace.service", cloudRoleName);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.DependencyDurationMetricIdValue, metricId);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTypeKey, out var dependencyType));
            if (isAzureSDKSpan)
            {
                Assert.Equal("Queue Message | aznamespace", dependencyType);
            }
            else
            {
                Assert.Equal("messagingsystem", dependencyType);
            }
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTargetKey, out var dependencyTarget));
            Assert.Equal("localhost/destination", dependencyTarget);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidateDependencyDurationMetricNew(bool isAzureSDK)
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateDependencyDurationMetric));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            var traceServiceName = new KeyValuePair<string, object>("service.name", "trace.service");
            var resourceAttributes = new KeyValuePair<string, object>[] { traceServiceName };

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes))
                .AddSource(nameof(StandardMetricTests.ValidateDependencyDurationMetric))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Client))
            {
                if (isAzureSDK)
                {
                    activity?.SetTag(SemanticConventions.AttributeAzureNameSpace, "aznamespace");
                }
                activity?.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, 200);
                activity?.SetTag(SemanticConventions.AttributeHttpRequestMethod, "Get");
                activity?.SetTag(SemanticConventions.AttributeServerAddress, "foo.com");
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            Assert.Single(metricTelemetryItems);

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
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.CloudRoleNameKey, out var cloudRoleName));
            Assert.Equal("trace.service", cloudRoleName);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.MetricIdKey, out var metricId));
            Assert.Equal(StandardMetricConstants.DependencyDurationMetricIdValue, metricId);
            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTypeKey, out var dependencyType));
            if (isAzureSDK)
            {
                Assert.Equal("aznamespace", dependencyType);
            }
            else
            {
                Assert.Equal("Http", dependencyType);
            }

            Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyTargetKey, out var dependencyTarget));
            Assert.Equal("foo.com", dependencyTarget);
        }

        [Theory]
        [InlineData(ActivityKind.Server)]
        [InlineData(ActivityKind.Client)]
        public void ValidateNullStatusCode(ActivityKind kind)
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateNullStatusCode));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(nameof(StandardMetricTests.ValidateNullStatusCode))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", kind))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpMethod, "Get");
                activity?.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.com");
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            // Standard Metrics + Resource Metrics.
            Assert.Single(metricTelemetryItems);
            var metricTelemetry = metricTelemetryItems.Last()!;
            Assert.Equal("MetricData", metricTelemetry.Data.BaseType);
            var metricData = (MetricsData)metricTelemetry.Data.BaseData;

            if (kind == ActivityKind.Client)
            {
                Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyResultCodeKey, out var resultCode));
                Assert.Equal("0", resultCode);
            }
            else
            {
                Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.RequestResultCodeKey, out var resultCode));
                Assert.Equal("0", resultCode);
            }
        }

        [Theory]
        [InlineData(ActivityKind.Server)]
        [InlineData(ActivityKind.Client)]
        public void ValidateNullStatusCodeNew(ActivityKind kind)
        {
            var activitySource = new ActivitySource(nameof(StandardMetricTests.ValidateNullStatusCode));
            var traceTelemetryItems = new List<TelemetryItem>();
            var metricTelemetryItems = new List<TelemetryItem>();

            var standardMetricCustomProcessor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(new MockTransmitter(metricTelemetryItems)), new PerfCounterItemCounts());

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(nameof(StandardMetricTests.ValidateNullStatusCode))
                .AddProcessor(standardMetricCustomProcessor)
                .AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), new MockTransmitter(traceTelemetryItems))))
                .Build();

            using (var activity = activitySource.StartActivity("Test", kind))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpRequestMethod, "Get");
                activity?.SetTag(SemanticConventions.AttributeUrlFull, "https://www.foo.com");
            }

            tracerProvider?.ForceFlush();

            WaitForActivityExport(traceTelemetryItems);

            standardMetricCustomProcessor._meterProvider?.ForceFlush();

            // Standard Metrics + Resource Metrics.
            Assert.Single(metricTelemetryItems);
            var metricTelemetry = metricTelemetryItems.Last()!;
            Assert.Equal("MetricData", metricTelemetry.Data.BaseType);
            var metricData = (MetricsData)metricTelemetry.Data.BaseData;

            if (kind == ActivityKind.Client)
            {
                Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.DependencyResultCodeKey, out var resultCode));
                Assert.Equal("0", resultCode);
            }
            else
            {
                Assert.True(metricData.Properties.TryGetValue(StandardMetricConstants.RequestResultCodeKey, out var resultCode));
                Assert.Equal("0", resultCode);
            }
        }

        private void WaitForActivityExport(List<TelemetryItem> traceTelemetryItems)
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
