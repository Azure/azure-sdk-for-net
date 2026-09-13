// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Standard metrics and performance counters are derived from the host process and carry no
    /// routing dimensions, so under multi-endpoint routing they could only ever be dropped at
    /// conversion. They are suppressed at the source instead, and the suppression is announced so
    /// nobody has to guess where their standard metrics went.
    /// </summary>
    public class StandardMetricsMultiEndpointTests
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void RoutingSuppressesHostDerivedMetrics(bool enableStandardMetrics, bool enablePerformanceCounters)
        {
            var processor = CreateProcessor(enableStandardMetrics, enablePerformanceCounters, multiEndpointEnabled: true);

            Assert.False(FlagOf(processor, "_enableStandardMetrics"));
            Assert.False(FlagOf(processor, "_enablePerformanceCounters"));
        }

        [Fact]
        public void WithoutRoutingHostDerivedMetricsAreUntouched()
        {
            var processor = CreateProcessor(enableStandardMetrics: true, enablePerformanceCounters: true, multiEndpointEnabled: false);

            Assert.True(FlagOf(processor, "_enableStandardMetrics"));
            Assert.True(FlagOf(processor, "_enablePerformanceCounters"));
        }

        [Fact]
        public void SuppressionIsAnnouncedRatherThanSilent()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            CreateProcessor(enableStandardMetrics: true, enablePerformanceCounters: false, multiEndpointEnabled: true);

            Assert.Single(listener.Messages.Where(e => e.EventName == "StandardMetricsDisabledForMultiEndpointRouting"));
        }

        /// <summary>Nothing was suppressed, so there is nothing to report.</summary>
        [Fact]
        public void NothingIsAnnouncedWhenBothWereAlreadyOff()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            CreateProcessor(enableStandardMetrics: false, enablePerformanceCounters: false, multiEndpointEnabled: true);

            Assert.Empty(listener.Messages.Where(e => e.EventName == "StandardMetricsDisabledForMultiEndpointRouting"));
        }

        private static StandardMetricsExtractionProcessor CreateProcessor(bool enableStandardMetrics, bool enablePerformanceCounters, bool multiEndpointEnabled)
        {
            var options = new AzureMonitorExporterOptions
            {
                EnableStandardMetrics = enableStandardMetrics,
                EnablePerformanceCounters = enablePerformanceCounters,
            };

            var exporter = new AzureMonitorMetricExporter(new MockTransmitter(new List<TelemetryItem>()), multiEndpointEnabled: false);

            return new StandardMetricsExtractionProcessor(exporter, options, multiEndpointEnabled);
        }

        private static bool FlagOf(StandardMetricsExtractionProcessor processor, string fieldName)
            => (bool)typeof(StandardMetricsExtractionProcessor)
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(processor)!;
    }
}
