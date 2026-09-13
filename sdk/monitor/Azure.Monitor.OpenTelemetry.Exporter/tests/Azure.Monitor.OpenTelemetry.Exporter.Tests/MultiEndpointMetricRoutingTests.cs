// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;
using OpenTelemetry.Metrics;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// The metrics counterpart to <see cref="MultiEndpointRoutingTests"/>. Routing reads a
    /// <see cref="MetricPoint"/>'s dimensions, so the routing values are part of the aggregation
    /// key: points differing only by destination are separate series, and one instrument can feed
    /// several endpoints.
    /// </summary>
    public class MultiEndpointMetricRoutingTests
    {
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";

        private const string IkeyTag = SemanticConventions.AttributeMicrosoftInstrumentationKey;
        private const string EndpointTag = SemanticConventions.AttributeMicrosoftIngestionEndpoint;
        private const string CloudRoleTag = SemanticConventions.AttributeMicrosoftMultiEndpointCloudRole;

        [Fact]
        public void EachDestinationBecomesItsOwnGroup()
        {
            var routeBatch = Convert(
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(1, Ikey("ikey-b"), Endpoint(WestUs)));

            Assert.Equal(2, routeBatch.Count);
            Assert.Equal(
                new[] { EastUs, WestUs },
                Groups(routeBatch).Select(g => g.IngestionEndpoint).OrderBy(e => e, StringComparer.Ordinal));
        }

        /// <summary>
        /// Grouping is by endpoint alone, so two instrumentation keys aimed at one endpoint share a
        /// group and become a single POST.
        /// </summary>
        [Fact]
        public void MixedInstrumentationKeysOnOneEndpointCollapseToOneGroup()
        {
            var routeBatch = Convert(
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(1, Ikey("ikey-b"), Endpoint(EastUs)));

            var group = Assert.Single(Groups(routeBatch));
            Assert.Equal(EastUs, group.IngestionEndpoint);
            Assert.Equal(2, group.TelemetryItems.Count);
            Assert.Equal(
                new[] { "ikey-a", "ikey-b" },
                group.TelemetryItems.Select(i => i.InstrumentationKey).OrderBy(k => k, StringComparer.Ordinal));
        }

        [Theory]
        [InlineData(null, EastUs)]
        [InlineData("ikey-a", null)]
        [InlineData("ikey-a", "")]
        [InlineData("ikey-a", "not-a-uri")]
        [InlineData("ikey-a", "http://eastus-1.in.applicationinsights.azure.com/")]
        [InlineData("", EastUs)]
        public void AMeasurementWithoutAValidRouteIsDropped(string? instrumentationKey, string? ingestionEndpoint)
        {
            var tags = new List<KeyValuePair<string, object?>>();
            if (instrumentationKey != null)
            {
                tags.Add(Ikey(instrumentationKey));
            }

            if (ingestionEndpoint != null)
            {
                tags.Add(Endpoint(ingestionEndpoint));
            }

            var routeBatch = Convert(Measure(1, tags.ToArray()));

            Assert.Equal(0, routeBatch.Count);
        }

        /// <summary>
        /// Host-derived instruments never carry routing dimensions. Dropping them is the steady
        /// state under routing, not a failure.
        /// </summary>
        [Fact]
        public void AnUnstampedInstrumentIsDroppedRatherThanSentToTheExportersOwnEndpoint()
        {
            var routeBatch = Convert(Measure(1));

            Assert.Equal(0, routeBatch.Count);
        }

        /// <summary>
        /// The dimensions addressed the telemetry; re-emitting them would bill the customer for a
        /// dimension they only added for routing.
        /// </summary>
        [Fact]
        public void RoutingDimensionsAreConsumedAndNotEmittedAsProperties()
        {
            var routeBatch = Convert(Measure(1, Ikey("ikey-a"), Endpoint(EastUs), CloudRole("app-role"), Tag("customer.dimension", "kept")));

            var item = Assert.Single(Assert.Single(Groups(routeBatch)).TelemetryItems);
            var properties = ((MetricsData)item.Data.BaseData).Properties;

            Assert.False(properties.ContainsKey(IkeyTag));
            Assert.False(properties.ContainsKey(EndpointTag));
            Assert.False(properties.ContainsKey(CloudRoleTag));
            Assert.Equal("kept", properties["customer.dimension"]);
        }

        [Fact]
        public void CloudRoleDimensionBecomesTheRoleName()
        {
            var routeBatch = Convert(Measure(1, Ikey("ikey-a"), Endpoint(EastUs), CloudRole("app-role")));

            var item = Assert.Single(Assert.Single(Groups(routeBatch)).TelemetryItems);
            Assert.Equal("app-role", item.Tags[ContextTagKeys.AiCloudRole.ToString()]);
        }

        [Fact]
        public void AMissingCloudRoleFallsBackToUnknownService()
        {
            var routeBatch = Convert(Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));

            var item = Assert.Single(Assert.Single(Groups(routeBatch)).TelemetryItems);
            Assert.Equal("unknown_service", item.Tags[ContextTagKeys.AiCloudRole.ToString()]);
        }

        /// <summary>
        /// One instrument's points differ by dimension value, so a single instrument can address
        /// several endpoints within one collection.
        /// </summary>
        [Fact]
        public void OneInstrumentCanFeedSeveralEndpoints()
        {
            var routeBatch = Convert(
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(2, Ikey("ikey-a"), Endpoint(WestUs)),
                Measure(3, Ikey("ikey-a"), Endpoint(EastUs)));

            Assert.Equal(2, routeBatch.Count);
        }

        [Fact]
        public void GateOffKeepsTheSingleEndpointPath()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: false);

            Export(exporter, Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));

            var item = Assert.Single(transmitter.TelemetryItems);
            Assert.Equal(transmitter.InstrumentationKey, item.InstrumentationKey);

            // With the gate off the routing dimensions stay ordinary custom dimensions.
            Assert.Equal("ikey-a", ((MetricsData)item.Data.BaseData).Properties[IkeyTag]);
        }

        [Fact]
        public void GateOnRequiresAMultiEndpointTransmitter()
        {
            var transmitter = new SingleEndpointOnlyTransmitter();

            Assert.Throws<NotSupportedException>(() => new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true));
            Assert.True(transmitter.Disposed, "the exporter must release the shared transmitter it failed to accept");
        }

        [Fact]
        public void AnEmptyCollectionReportsSuccess()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            Assert.Equal(ExportResult.Success, exporter.Export(new Batch<Metric>(Array.Empty<Metric>(), 0)));
        }

        /// <summary>
        /// The sequence correlates one export's events. A batch that never begins an export would
        /// report every send under sequence zero.
        /// </summary>
        [Fact]
        public void EachMetricExportGetsItsOwnSequence()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);
            var routeBatchField = typeof(AzureMonitorMetricExporter).GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!;

            var sequences = new List<long>();
            for (int i = 0; i < 2; i++)
            {
                Export(exporter, Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));
                sequences.Add(((EndpointRouteBatch)routeBatchField.GetValue(exporter)!).Sequence);
            }

            Assert.DoesNotContain(0L, sequences);
            Assert.Equal(2, sequences.Distinct().Count());
        }

        /// <summary>
        /// A non-string dimension value stringifies unpredictably, so it must fail routing rather
        /// than become a destination of its own.
        /// </summary>
        [Fact]
        public void NonStringRoutingValueIsRejectedRatherThanStringified()
        {
            var routeBatch = Convert(Measure(1, Tag(IkeyTag, new[] { "ikey-a" }), Endpoint(EastUs)));

            Assert.Equal(0, routeBatch.Count);
        }

        [Fact]
        public void OneUnroutableMeasurementDoesNotDropTheRest()
        {
            var routeBatch = Convert(
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(1, Endpoint(WestUs)),
                Measure(1, Ikey("ikey-c"), Endpoint(WestUs)));

            Assert.Equal(2, routeBatch.Count);
            Assert.Equal(2, Groups(routeBatch).Sum(g => g.TelemetryItems.Count));
        }

        [Fact]
        public void InstrumentationKeyIsTrimmedSoSpacingDoesNotCreateADistinctRoute()
        {
            var routeBatch = Convert(Measure(1, Ikey("  ikey-a  "), Endpoint(EastUs)));

            var item = Assert.Single(Assert.Single(Groups(routeBatch)).TelemetryItems);
            Assert.Equal("ikey-a", item.InstrumentationKey);
        }

        [Fact]
        public void CloudRoleIsTrimmedAndFallsBackWhenBlank()
        {
            var trimmed = Convert(Measure(1, Ikey("ikey-a"), Endpoint(EastUs), CloudRole("  app-role  ")));
            var blank = Convert(Measure(1, Ikey("ikey-b"), Endpoint(EastUs), CloudRole("   ")));

            Assert.Equal("app-role", RoleOf(trimmed));
            Assert.Equal("unknown_service", RoleOf(blank));
        }

        /// <summary>
        /// Points sharing an endpoint group still carry their own role: the role travels per
        /// envelope, not per group.
        /// </summary>
        [Fact]
        public void CloudRoleIsResolvedPerPointWithinAnEndpointGroup()
        {
            var routeBatch = Convert(
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs), CloudRole("role-a")),
                Measure(1, Ikey("ikey-b"), Endpoint(EastUs), CloudRole("role-b")));

            var group = Assert.Single(Groups(routeBatch));
            Assert.Equal(
                new[] { "role-a", "role-b" },
                group.TelemetryItems.Select(i => i.Tags[ContextTagKeys.AiCloudRole.ToString()]).OrderBy(r => r, StringComparer.Ordinal));
        }

        /// <summary>With the gate off the multi-endpoint machinery must not even be allocated.</summary>
        [Fact]
        public void GateOffAllocatesNoRouteBatch()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: false);

            Export(exporter, Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));

            Assert.Null(typeof(AzureMonitorMetricExporter)
                .GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(exporter));
        }

        [Fact]
        public void RepeatedExportsLeaveTheCachedRouteBatchEmpty()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            Export(exporter, Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));
            Export(exporter, Measure(1, Ikey("ikey-b"), Endpoint(WestUs)));

            var routeBatch = (EndpointRouteBatch?)typeof(AzureMonitorMetricExporter)
                .GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(exporter);

            Assert.NotNull(routeBatch);
            Assert.Equal(0, routeBatch!.Count);
        }

        /// <summary>
        /// Routed telemetry must never reach the exporter's own connection string: that would bill
        /// the host for a customer's metrics.
        /// </summary>
        [Fact]
        public void GateOnNeverFallsBackToTheExportersOwnTransmitter()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            Export(exporter, Measure(1, Ikey("ikey-a"), Endpoint(EastUs)), Measure(1));

            Assert.Equal(0, transmitter.TrackAsyncCallCount);
            Assert.Empty(transmitter.TelemetryItems);
        }

        [Fact]
        public void GateDefaultsToOff()
        {
            Assert.False(MultiEndpointConfig.Enabled);
        }

        /// <summary>
        /// Apart from the routing dimensions the routed path must produce the same envelope the
        /// single-endpoint path would, so routing cannot silently change what a customer sees.
        /// </summary>
        [Fact]
        public void RoutedConversionProducesTheSameEnvelopeShapeAsSingleEndpoint()
        {
            var routed = Convert(Measure(7, Ikey("ikey-a"), Endpoint(EastUs), Tag("customer.dimension", "kept")));
            var routedData = (MetricsData)Assert.Single(Assert.Single(Groups(routed)).TelemetryItems).Data.BaseData;

            List<TelemetryItem> single = new();
            WithCollectedMetrics(
                new[] { Measure(7, Tag("customer.dimension", "kept")) },
                batch => single.AddRange(MetricHelper.OtelToAzureMonitorMetrics(batch, resource: null, "ikey-a").TelemetryItems));

            var singleData = (MetricsData)Assert.Single(single).Data.BaseData;

            Assert.Equal(singleData.Metrics[0].Name, routedData.Metrics[0].Name);
            Assert.Equal(singleData.Metrics[0].Value, routedData.Metrics[0].Value);
            Assert.Equal(singleData.Properties["customer.dimension"], routedData.Properties["customer.dimension"]);
            Assert.Equal(singleData.Properties.Count, routedData.Properties.Count);
        }

        [Theory]
        [InlineData(null, EastUs, "MissingInstrumentationKey")]
        [InlineData("ikey-a", null, "MissingIngestionEndpoint")]
        [InlineData("ikey-a", "not-a-uri", "IngestionEndpointMalformed")]
        [InlineData("ikey-a", "http://eastus-1.in.applicationinsights.azure.com/", "IngestionEndpointNotHttps")]
        [InlineData("ikey-a", "https://eastus-1.in.applicationinsights.azure.com/?a=b", "IngestionEndpointHasQueryOrFragment")]
        public void ADroppedMeasurementReportsWhyItCouldNotBeRouted(string? instrumentationKey, string? ingestionEndpoint, string expectedReason)
        {
            var tags = new List<KeyValuePair<string, object?>>();
            if (instrumentationKey != null)
            {
                tags.Add(Ikey(instrumentationKey));
            }

            if (ingestionEndpoint != null)
            {
                tags.Add(Endpoint(ingestionEndpoint));
            }

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            Assert.Equal(0, Convert(Measure(1, tags.ToArray())).Count);

            var rejected = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedMetricRejected"));
            Assert.Equal(expectedReason, rejected.Payload![1]);
            Assert.Equal("test.counter", rejected.Payload[3]);
        }

        /// <summary>
        /// The endpoint that caused a rejection may carry credentials, so the reason has to stand on
        /// its own without it.
        /// </summary>
        [Fact]
        public void ARejectionNeverRepeatsTheEndpointThatCausedIt()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            Convert(Measure(1, Ikey("ikey-a"), Endpoint("https://user:sekret@eastus-1.in.applicationinsights.azure.com/")));

            var rejected = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedMetricRejected"));
            Assert.DoesNotContain("sekret", string.Join("|", rejected.Payload!), StringComparison.Ordinal);
        }

        [Fact]
        public void CollectedTelemetryIsReportedWithItsDestinationAndInstrument()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            Convert(Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));

            var collected = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedMetricCollected"));
            Assert.Equal(EastUs, collected.Payload![1]);
            Assert.Equal("ikey-a", collected.Payload[2]);
            Assert.Equal("test.counter", collected.Payload[4]);
        }

        /// <summary>Per-item records are the Verbose tier; nothing below it should pay for them.</summary>
        [Fact]
        public void PerItemRecordsAreNotWrittenBelowVerbose()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            Convert(Measure(1, Ikey("ikey-a"), Endpoint(EastUs)), Measure(1, Endpoint(EastUs)));

            Assert.Empty(listener.Messages.Where(e => e.EventName == "RoutedMetricCollected" || e.EventName == "RoutedMetricRejected"));
        }

        [Fact]
        public void OneExportReportsItsTotalsUnderASingleSequence()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            var routeBatch = Convert(
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(1, Ikey("ikey-b"), Endpoint(WestUs)),
                Measure(1, Endpoint(EastUs)));

            var summary = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedExportSummary"));
            Assert.Equal(routeBatch.Sequence, summary.Payload![0]);
            Assert.Equal(2, summary.Payload[1]);
            Assert.Equal(2, summary.Payload[2]);
            Assert.Equal(1, summary.Payload[3]);
        }

        private static string RoleOf(EndpointRouteBatch batch)
            => Assert.Single(Assert.Single(Groups(batch)).TelemetryItems).Tags[ContextTagKeys.AiCloudRole.ToString()];

        [Fact]
        public void EachEndpointGroupIsSentToItsOwnEndpoint()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            Export(
                exporter,
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(1, Ikey("ikey-b"), Endpoint(WestUs)),
                Measure(1, Ikey("ikey-c"), Endpoint(EastUs)));

            Assert.Equal(2, transmitter.Sends.Count);

            var eastUs = transmitter.Sends.Single(send => send.IngestionEndpoint == EastUs);
            Assert.Equal(
                new[] { "ikey-a", "ikey-c" },
                eastUs.TelemetryItems.Select(item => item.InstrumentationKey).OrderBy(k => k, StringComparer.Ordinal));

            var westUs = transmitter.Sends.Single(send => send.IngestionEndpoint == WestUs);
            Assert.Equal(new[] { "ikey-b" }, westUs.TelemetryItems.Select(item => item.InstrumentationKey));
        }

        [Fact]
        public void ManyApplicationsInOneRegionBecomeOneSend()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            Export(
                exporter,
                Measure(1, Ikey("ikey-a"), Endpoint(EastUs)),
                Measure(1, Ikey("ikey-b"), Endpoint(EastUs)),
                Measure(1, Ikey("ikey-c"), Endpoint(EastUs)));

            Assert.Single(transmitter.Sends);
            Assert.Equal(3, transmitter.Sends[0].TelemetryItems.Length);
        }

        [Fact]
        public void TransmissionFailureIsReportedToTheProvider()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>()) { MultiEndpointResult = ExportResult.Failure };
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            var result = ExportCarryingMeasurements(exporter, Measure(1, Ikey("ikey-a"), Endpoint(EastUs)));

            Assert.Equal(ExportResult.Failure, result);
            Assert.Single(transmitter.Sends);
        }

        [Fact]
        public void GateOnWithNoRoutableMeasurementReportsSuccess()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorMetricExporter(transmitter, multiEndpointEnabled: true);

            var result = ExportCarryingMeasurements(exporter, Measure(1));

            Assert.Equal(ExportResult.Success, result);
            Assert.Equal(0, transmitter.TrackAsyncCallCount);
            Assert.Empty(transmitter.Sends);
        }

        private static IEnumerable<EndpointRouteBatch.Group> Groups(EndpointRouteBatch batch)
        {
            for (int i = 0; i < batch.Count; i++)
            {
                yield return batch[i];
            }
        }

        private static KeyValuePair<string, object?> Ikey(string value) => Tag(IkeyTag, value);

        private static KeyValuePair<string, object?> Endpoint(string value) => Tag(EndpointTag, value);

        private static KeyValuePair<string, object?> CloudRole(string value) => Tag(CloudRoleTag, value);

        private static KeyValuePair<string, object?> Tag(string key, object? value) => new(key, value);

        private static (long Value, KeyValuePair<string, object?>[] Tags) Measure(long value, params KeyValuePair<string, object?>[] tags)
            => (value, tags);

        private static EndpointRouteBatch Convert(params (long Value, KeyValuePair<string, object?>[] Tags)[] measurements)
        {
            var routeBatch = new EndpointRouteBatch();
            routeBatch.BeginExport();

            WithCollectedMetrics(measurements, batch => MetricHelper.OtelToAzureMonitorMetricsMultiEndpoint(batch, resource: null, routeBatch));

            return routeBatch;
        }

        private static void Export(AzureMonitorMetricExporter exporter, params (long Value, KeyValuePair<string, object?>[] Tags)[] measurements)
            => WithCollectedMetrics(measurements, batch => exporter.Export(batch));

        /// <summary>
        /// Returns the result of the collect that carried the measurements. Disposing the provider
        /// forces a second, empty collect, whose result says nothing about the export under test.
        /// </summary>
        private static ExportResult ExportCarryingMeasurements(AzureMonitorMetricExporter exporter, params (long Value, KeyValuePair<string, object?>[] Tags)[] measurements)
        {
            ExportResult? captured = null;

            WithCollectedMetrics(measurements, batch =>
            {
                var result = exporter.Export(batch);

                if (batch.Count > 0)
                {
                    captured ??= result;
                }
            });

            Assert.True(captured.HasValue, "no collect carried the measurements");

            return captured!.Value;
        }

        /// <summary>
        /// Metrics are only readable inside the reader's export callback, so every assertion runs
        /// against a live batch rather than against Metric references held past collection.
        /// </summary>
        private static void WithCollectedMetrics(
            (long Value, KeyValuePair<string, object?>[] Tags)[] measurements,
            Action<Batch<Metric>> consume)
        {
            var meterName = $"{nameof(MultiEndpointMetricRoutingTests)}.{Guid.NewGuid():N}";
            using var meter = new Meter(new MeterOptions(meterName));
            var counter = meter.CreateCounter<long>("test.counter");

            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddReader(new BaseExportingMetricReader(new DelegatingMetricExporter(consume))
                {
                    TemporalityPreference = MetricReaderTemporalityPreference.Delta
                })
                .Build();

            foreach (var measurement in measurements)
            {
                counter.Add(measurement.Value, measurement.Tags);
            }

            provider!.ForceFlush();
        }

        private sealed class DelegatingMetricExporter : BaseExporter<Metric>
        {
            private readonly Action<Batch<Metric>> _consume;

            internal DelegatingMetricExporter(Action<Batch<Metric>> consume) => _consume = consume;

            public override ExportResult Export(in Batch<Metric> batch)
            {
                _consume(batch);
                return ExportResult.Success;
            }
        }

        private sealed class SingleEndpointOnlyTransmitter : ITransmitter
        {
            public string InstrumentationKey => "single-endpoint-ikey";

            public bool Disposed { get; private set; }

            public ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
                => new(ExportResult.Success);

            public IDisposable BeginPersistOnlyScope() => new NoopScope();

            public void DrainStorage(int waitMilliseconds)
            {
            }

            public void Dispose() => Disposed = true;

            private sealed class NoopScope : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
}
