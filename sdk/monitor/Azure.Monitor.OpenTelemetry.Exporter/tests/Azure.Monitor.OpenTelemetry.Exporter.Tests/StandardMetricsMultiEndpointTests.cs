// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Routed destinations are not sent standard metrics, and a process-scoped performance counter
    /// has no single owner among the destinations a routed process carries. Both are therefore not
    /// collected while routing is on, and the suppression is announced so nobody has to guess where
    /// their standard metrics went.
    /// </summary>
    public class StandardMetricsMultiEndpointTests
    {
        [Fact]
        public void RoutingEmitsNoStandardMetrics()
        {
            var metrics = RunRequestThrough(multiEndpointEnabled: true);

            Assert.Empty(metrics);
        }

        [Fact]
        public void WithoutRoutingStandardMetricsAreStillEmitted()
        {
            var metrics = RunRequestThrough(multiEndpointEnabled: false);

            Assert.Contains(
                metrics,
                item => ((MetricsData)item.Data.BaseData).Metrics.Any(m => m.Name == StandardMetricConstants.RequestDurationMetricIdValue));
        }

        [Fact]
        public void SuppressionIsAnnouncedRatherThanSilent()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            CreateProcessor(enableStandardMetrics: true, enablePerformanceCounters: false, multiEndpointEnabled: true, new List<TelemetryItem>());

            Assert.Single(listener.Messages.Where(e => e.EventName == "StandardMetricsDisabledForMultiEndpointRouting"));
        }

        /// <summary>Nothing was suppressed, so there is nothing to report.</summary>
        [Fact]
        public void NothingIsAnnouncedWhenBothWereAlreadyOff()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            CreateProcessor(enableStandardMetrics: false, enablePerformanceCounters: false, multiEndpointEnabled: true, new List<TelemetryItem>());

            Assert.Empty(listener.Messages.Where(e => e.EventName == "StandardMetricsDisabledForMultiEndpointRouting"));
        }

        /// <summary>
        /// Drives a request Activity through the processor and returns whatever metric telemetry
        /// reached the transmitter, so the assertion is on emitted telemetry rather than on private
        /// configuration flags.
        /// </summary>
        private static List<TelemetryItem> RunRequestThrough(bool multiEndpointEnabled)
        {
            var sourceName = $"{nameof(StandardMetricsMultiEndpointTests)}.{multiEndpointEnabled}";
            var metrics = new List<TelemetryItem>();

            var processor = CreateProcessor(enableStandardMetrics: true, enablePerformanceCounters: false, multiEndpointEnabled, metrics);

            using var activitySource = new ActivitySource(new ActivitySourceOptions(sourceName));
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(sourceName)
                .AddProcessor(processor)
                .Build();

            using (var activity = activitySource.StartActivity("Test", ActivityKind.Server))
            {
                activity?.SetTag(SemanticConventions.AttributeHttpStatusCode, 200);
            }

            tracerProvider?.ForceFlush();
            processor._meterProvider?.Value?.ForceFlush();

            return metrics;
        }

        private static StandardMetricsExtractionProcessor CreateProcessor(bool enableStandardMetrics, bool enablePerformanceCounters, bool multiEndpointEnabled, IList<TelemetryItem> metrics)
        {
            var options = new AzureMonitorExporterOptions
            {
                EnableStandardMetrics = enableStandardMetrics,
                EnablePerformanceCounters = enablePerformanceCounters,
            };

            var exporter = new AzureMonitorMetricExporter(new MockTransmitter(metrics), multiEndpointEnabled: false);

            return new StandardMetricsExtractionProcessor(exporter, options, multiEndpointEnabled);
        }
    }
}
