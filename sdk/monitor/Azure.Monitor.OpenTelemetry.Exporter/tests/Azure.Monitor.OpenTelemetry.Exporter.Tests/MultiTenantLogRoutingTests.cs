// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// The logs counterpart to <see cref="MultiTenantRoutingTests"/>: routing reads
    /// <see cref="LogRecord.Attributes"/> instead of Activity tags, but the grouping, dropping, and
    /// exporter gate behave the same. Because the SDK pools and recycles <see cref="LogRecord"/>
    /// instances, every conversion runs inside a batch export where the records are simultaneously
    /// alive rather than by holding record references across calls.
    /// </summary>
    public class MultiTenantLogRoutingTests
    {
        private const string SourceName = nameof(MultiTenantLogRoutingTests);
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";

        private const string CustomEventAttributeName = "microsoft.custom_event.name";
        private const string AvailabilityIdAttributeName = "microsoft.availability.id";
        private const string AvailabilityNameAttributeName = "microsoft.availability.name";
        private const string AvailabilityDurationAttributeName = "microsoft.availability.duration";
        private const string AvailabilitySuccessAttributeName = "microsoft.availability.success";

        private static KeyValuePair<string, object?>[] AvailabilityMarkers() => new[]
        {
            new KeyValuePair<string, object?>(AvailabilityIdAttributeName, "availability-id"),
            new KeyValuePair<string, object?>(AvailabilityNameAttributeName, "MyTest"),
            new KeyValuePair<string, object?>(AvailabilityDurationAttributeName, "00:00:01"),
            new KeyValuePair<string, object?>(AvailabilitySuccessAttributeName, "true"),
        };

        [Fact]
        public void MixedInstrumentationKeysOnOneEndpointCollapseToOneGroup()
        {
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("ikey-b"), Endpoint(EastUs)),
                Emit(Ikey("ikey-c"), Endpoint(EastUs)));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(EastUs, routeBatch[0].IngestionEndpoint);
            Assert.Equal(3, routeBatch[0].TelemetryItems.Count);
        }

        [Fact]
        public void DistinctEndpointsBecomeDistinctGroups()
        {
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("ikey-a"), Endpoint(WestUs)),
                Emit(Ikey("ikey-b"), Endpoint(EastUs)));

            Assert.Equal(2, routeBatch.Count);
            Assert.Equal(2, routeBatch[0].TelemetryItems.Count);
            Assert.Single(routeBatch[1].TelemetryItems);
        }

        [Fact]
        public void EachItemCarriesItsOwnInstrumentationKey()
        {
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("ikey-b"), Endpoint(EastUs)));

            Assert.Equal(
                new[] { "ikey-a", "ikey-b" },
                routeBatch[0].TelemetryItems.Select(item => item.InstrumentationKey));
        }

        /// <summary>
        /// On the routed path they are consumed, so they must not also appear as dimensions.
        /// </summary>
        [Fact]
        public void RoutedTelemetryDoesNotCarryTheRoutingTagsAsCustomDimensions()
        {
            var routeBatch = Convert(Emit(Ikey("ikey-a"), Endpoint(EastUs), CloudRole("tenant-role")));

            var properties = ((MessageData)routeBatch[0].TelemetryItems.Single().Data!.BaseData).Properties;
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftInstrumentationKey, properties.Keys);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftIngestionEndpoint, properties.Keys);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftMultiEndpointCloudRole, properties.Keys);
        }

        [Theory]
        [InlineData(null, EastUs)]
        [InlineData("", EastUs)]
        [InlineData("   ", EastUs)]
        [InlineData("ikey-a", null)]
        [InlineData("ikey-a", "")]
        [InlineData("ikey-a", "not-a-uri")]
        [InlineData("ikey-a", "/relative/path")]
        [InlineData("ikey-a", "ftp://example.com/")]
        public void LogWithoutAValidRouteIsDropped(string? instrumentationKey, string? ingestionEndpoint)
        {
            var attributes = new List<KeyValuePair<string, object?>>();
            if (instrumentationKey != null)
            {
                attributes.Add(Ikey(instrumentationKey));
            }

            if (ingestionEndpoint != null)
            {
                attributes.Add(Endpoint(ingestionEndpoint));
            }

            Assert.Equal(0, Convert(Emit(attributes.ToArray())).Count);
        }

        /// <summary>
        /// A non-string value stringifies unpredictably, so it is dropped rather than routed, exactly
        /// as the trace path rejects an array-valued tag.
        /// </summary>
        [Fact]
        public void NonStringRoutingValueIsRejectedRatherThanStringified()
        {
            var routeBatch = Convert(Emit(
                new KeyValuePair<string, object?>(SemanticConventions.AttributeMicrosoftInstrumentationKey, new[] { "ikey-a", "ikey-b" }),
                Endpoint(EastUs)));

            Assert.Equal(0, routeBatch.Count);
        }

        /// <summary>
        /// First occurrence of each routing key wins, matching how the trace path fills an AzMonList.
        /// </summary>
        [Fact]
        public void FirstOccurrenceOfARepeatedRoutingKeyWins()
        {
            var routeBatch = Convert(Emit(
                Ikey("ikey-a"),
                Endpoint(EastUs),
                Ikey("ikey-b"),
                Endpoint(WestUs)));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(EastUs, routeBatch[0].IngestionEndpoint);
            Assert.Equal("ikey-a", routeBatch[0].TelemetryItems.Single().InstrumentationKey);
        }

        [Fact]
        public void InstrumentationKeyIsTrimmedSoSpacingDoesNotCreateATenant()
        {
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("  ikey-a  "), Endpoint(EastUs)));

            Assert.Equal(1, routeBatch.Count);
            Assert.All(routeBatch[0].TelemetryItems, item => Assert.Equal("ikey-a", item.InstrumentationKey));
        }

        [Fact]
        public void OneUnroutableLogDoesNotDropTheRestOfTheBatch()
        {
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(),
                Emit(Ikey("ikey-b"), Endpoint(EastUs)));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(2, routeBatch[0].TelemetryItems.Count);
        }

        [Fact]
        public void RoutedLogCarriesTenantCloudRoleAndHostRoleInstance()
        {
            var routeBatch = Convert(
                CreateResource(),
                Emit(Ikey("ikey-a"), Endpoint(EastUs), CloudRole("tenant-role")));

            var telemetryItem = routeBatch[0].TelemetryItems.Single();
            Assert.Equal("tenant-role", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal("relay-instance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(42)]
        public void InvalidTenantCloudRoleUsesUnknownService(object? tenantCloudRole)
        {
            var routeBatch = Convert(
                CreateResource(),
                Emit(Ikey("ikey-a"), Endpoint(EastUs), CloudRole(tenantCloudRole)));

            Assert.Equal(
                "unknown_service",
                routeBatch[0].TelemetryItems.Single().Tags[ContextTagKeys.AiCloudRole.ToString()]);
        }

        [Fact]
        public void TenantCloudRoleIsTrimmedAndTruncated()
        {
            var tenantCloudRole = new string('a', SchemaConstants.Tags_AiCloudRole_MaxLength + 1);
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs), CloudRole($" {tenantCloudRole} ")));

            Assert.Equal(
                tenantCloudRole.Substring(0, SchemaConstants.Tags_AiCloudRole_MaxLength),
                routeBatch[0].TelemetryItems.Single().Tags[ContextTagKeys.AiCloudRole.ToString()]);
        }

        [Fact]
        public void TenantCloudRoleIsResolvedPerLogWithinAnEndpointGroup()
        {
            var routeBatch = Convert(
                Emit(Ikey("ikey-a"), Endpoint(EastUs), CloudRole("tenant-a")),
                Emit(Ikey("ikey-b"), Endpoint(EastUs), CloudRole("tenant-b")));

            Assert.Equal(
                new[] { "tenant-a", "tenant-b" },
                routeBatch[0].TelemetryItems.Select(item => item.Tags[ContextTagKeys.AiCloudRole.ToString()]));
        }

        [Fact]
        public void FirstTenantCloudRoleAttributeWins()
        {
            var routeBatch = Convert(
                Emit(
                    Ikey("ikey-a"),
                    Endpoint(EastUs),
                    CloudRole("tenant-a"),
                    CloudRole("tenant-b")));

            Assert.Equal(
                "tenant-a",
                routeBatch[0].TelemetryItems.Single().Tags[ContextTagKeys.AiCloudRole.ToString()]);
        }

        [Fact]
        public void EveryLogTelemetryTypeCarriesTenantCloudRoleAndHostRoleInstance()
        {
            var route = new[] { Ikey("ikey-a"), Endpoint(EastUs), CloudRole("tenant-role") };
            var routeBatch = Convert(
                CreateResource(),
                Emit(route),
                Emit("failed body", new InvalidOperationException("boom"), route),
                Emit(route.Concat(new[] { new KeyValuePair<string, object?>(CustomEventAttributeName, "tenant-event") }).ToArray()),
                Emit(route.Concat(AvailabilityMarkers()).ToArray()));

            Assert.Equal(
                new[] { "MessageData", "ExceptionData", "EventData", "AvailabilityData" },
                routeBatch[0].TelemetryItems.Select(item => item.Data!.BaseType));
            Assert.All(
                routeBatch[0].TelemetryItems,
                item =>
                {
                    Assert.Equal("tenant-role", item.Tags[ContextTagKeys.AiCloudRole.ToString()]);
                    Assert.Equal("relay-instance", item.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
                });
        }

        /// <summary>
        /// The availability marker makes the property loop break early, so routing must be detected in
        /// its own pass: a route stamped after the marker must still be found, and neither routing tag
        /// may leak into the availability envelope's properties.
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AvailabilityLogRoutesRegardlessOfWhereTheRoutingTagsSit(bool routingTagsBeforeMarker)
        {
            var routingTags = new[] { Ikey("ikey-a"), Endpoint(EastUs), CloudRole("tenant-role") };
            var attributes = routingTagsBeforeMarker
                ? routingTags.Concat(AvailabilityMarkers()).ToArray()
                : AvailabilityMarkers().Concat(routingTags).ToArray();

            var routeBatch = Convert(Emit(attributes));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(EastUs, routeBatch[0].IngestionEndpoint);

            var telemetryItem = routeBatch[0].TelemetryItems.Single();
            Assert.Equal("AvailabilityData", telemetryItem.Data!.BaseType);
            Assert.Equal("ikey-a", telemetryItem.InstrumentationKey);
            Assert.Equal("tenant-role", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);

            var properties = ((AvailabilityData)telemetryItem.Data!.BaseData).Properties;
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftInstrumentationKey, properties.Keys);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftIngestionEndpoint, properties.Keys);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftMultiEndpointCloudRole, properties.Keys);
        }

        /// <summary>
        /// Nothing consumes the routing attributes outside the multi-tenant conversion, so on the
        /// single-tenant path they must survive as ordinary custom dimensions rather than be dropped.
        /// </summary>
        [Fact]
        public void SingleTenantPathDoesNotApplyTenantCloudRole()
        {
            var telemetryItems = ConvertSingleTenant(
                "exporter-ikey",
                CreateResource(),
                Emit(Ikey("ikey-a"), Endpoint(EastUs), CloudRole("tenant-role")));

            var telemetryItem = telemetryItems.Single();
            Assert.Equal("exporter-ikey", telemetryItem.InstrumentationKey);
            Assert.Equal("relay-host", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal("relay-instance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);

            var properties = ((MessageData)telemetryItem.Data!.BaseData).Properties;
            Assert.Equal("ikey-a", properties[SemanticConventions.AttributeMicrosoftInstrumentationKey]);
            Assert.Equal(EastUs, properties[SemanticConventions.AttributeMicrosoftIngestionEndpoint]);
            Assert.Equal("tenant-role", properties[SemanticConventions.AttributeMicrosoftMultiEndpointCloudRole]);
        }

        /// <summary>
        /// Routing changes where an envelope goes and nothing about how it is built. Both sides use the
        /// same instrumentation key, so this compares the conversion itself across every log shape.
        /// </summary>
        [Fact]
        public void RoutedConversionProducesTheSameEnvelopesAsSingleTenant()
        {
            var sharedException = new InvalidOperationException("boom");
            var resource = new AzureMonitorResource(
                roleName: "unknown_service",
                roleInstance: null,
                serviceVersion: null,
                monitorBaseData: null);

            var corpus = new (string Message, Exception? Exception, KeyValuePair<string, object?>[] Markers)[]
            {
                ("message body", null, Array.Empty<KeyValuePair<string, object?>>()),
                ("failed body", sharedException, Array.Empty<KeyValuePair<string, object?>>()),
                ("event body", null, new[] { new KeyValuePair<string, object?>(CustomEventAttributeName, "my-event") }),
                ("availability body", null, AvailabilityMarkers()),
            };

            // Without the routing tags the two paths see identical input, so any remaining difference
            // is the conversion itself rather than the tags one path consumes.
            var singleTenantItems = ConvertSingleTenant(
                "ikey-a",
                resource,
                corpus.Select(entry => Emit(entry.Message, entry.Exception, entry.Markers)).ToArray());

            var routeBatch = Convert(
                resource,
                corpus.Select(entry => Emit(entry.Message, entry.Exception, entry.Markers.Concat(new[] { Ikey("ikey-a"), Endpoint(EastUs) }).ToArray())).ToArray());

            var singleTenant = Encoding.UTF8.GetString(HttpPipelineHelper.GetSerializedContent(singleTenantItems));
            var multiTenant = Encoding.UTF8.GetString(HttpPipelineHelper.GetSerializedContent(routeBatch[0].TelemetryItems));

            Assert.Equal(Normalize(singleTenant), Normalize(multiTenant));
        }

        [Fact]
        public void GateOffKeepsTheSingleTenantPath()
        {
            var run = RunExporter(multiTenantEnabled: false, Emit(Ikey("ikey-a"), Endpoint(EastUs)));

            Assert.Equal(ExportResult.Success, run.Result);
            Assert.Equal(1, run.Transmitter.TrackAsyncCallCount);
            Assert.Equal(run.Transmitter.InstrumentationKey, run.Transmitter.TelemetryItems.Single().InstrumentationKey);
        }

        /// <summary>
        /// The data-boundary contract: routed telemetry must never reach the exporter's own
        /// connection string.
        /// </summary>
        [Fact]
        public void GateOnNeverFallsBackToTheExportersOwnTransmitter()
        {
            var run = RunExporter(
                multiTenantEnabled: true,
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("ikey-b"), Endpoint(WestUs)));

            Assert.Equal(ExportResult.Success, run.Result);
            Assert.Equal(0, run.Transmitter.TrackAsyncCallCount);
            Assert.Empty(run.Transmitter.TelemetryItems);
        }

        [Fact]
        public void EachEndpointGroupIsSentToItsOwnEndpoint()
        {
            var run = RunExporter(
                multiTenantEnabled: true,
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("ikey-b"), Endpoint(WestUs)),
                Emit(Ikey("ikey-c"), Endpoint(EastUs)));

            Assert.Equal(2, run.Transmitter.Sends.Count);

            var eastUs = run.Transmitter.Sends.Single(send => send.IngestionEndpoint == EastUs);
            Assert.Equal(new[] { "ikey-a", "ikey-c" }, eastUs.TelemetryItems.Select(item => item.InstrumentationKey));

            var westUs = run.Transmitter.Sends.Single(send => send.IngestionEndpoint == WestUs);
            Assert.Equal(new[] { "ikey-b" }, westUs.TelemetryItems.Select(item => item.InstrumentationKey));
        }

        [Fact]
        public void ManyTenantsInOneRegionBecomeOneSend()
        {
            var run = RunExporter(
                multiTenantEnabled: true,
                Emit(Ikey("ikey-a"), Endpoint(EastUs)),
                Emit(Ikey("ikey-b"), Endpoint(EastUs)),
                Emit(Ikey("ikey-c"), Endpoint(EastUs)));

            Assert.Single(run.Transmitter.Sends);
            Assert.Equal(3, run.Transmitter.Sends[0].TelemetryItems.Length);
        }

        [Fact]
        public void TransmissionFailureIsReportedToTheProvider()
        {
            var run = RunExporter(
                configure: transmitter => transmitter.MultiTenantResult = ExportResult.Failure,
                createExporter: transmitter => new AzureMonitorLogExporter(transmitter, multiTenantEnabled: true),
                Emit(Ikey("ikey-a"), Endpoint(EastUs)));

            Assert.Equal(ExportResult.Failure, run.Result);
            Assert.Single(run.Transmitter.Sends);
        }

        [Fact]
        public void GateOnWithNoRoutableLogReportsSuccess()
        {
            var run = RunExporter(multiTenantEnabled: true, Emit());

            Assert.Equal(ExportResult.Success, run.Result);
            Assert.Equal(0, run.Transmitter.TrackAsyncCallCount);
            Assert.Empty(run.Transmitter.Sends);
        }

        [Fact]
        public void GateOnWithAnEmptyBatchReportsSuccess()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorLogExporter(transmitter, multiTenantEnabled: true);

            Assert.Equal(ExportResult.Success, exporter.Export(new Batch<LogRecord>(Array.Empty<LogRecord>(), 0)));
        }

        [Fact]
        public void RepeatedExportsLeaveTheCachedRouteBatchEmpty()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorLogExporter(transmitter, multiTenantEnabled: true);

            WithLiveBatch(batch => exporter.Export(batch), Emit(Ikey("ikey-a"), Endpoint(EastUs)), Emit(Ikey("ikey-b"), Endpoint(EastUs)));
            WithLiveBatch(batch => exporter.Export(batch), Emit(Ikey("ikey-c"), Endpoint(WestUs)));

            var routeBatch = (EndpointRouteBatch?)typeof(AzureMonitorLogExporter)
                .GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(exporter);

            Assert.NotNull(routeBatch);
            Assert.Equal(0, routeBatch!.Count);
        }

        /// <summary>
        /// With the gate off the multi-tenant machinery must not even be allocated.
        /// </summary>
        [Fact]
        public void GateOffAllocatesNoRouteBatch()
        {
            var run = RunExporter(multiTenantEnabled: false, Emit(Ikey("ikey-a"), Endpoint(EastUs)));

            var routeBatch = typeof(AzureMonitorLogExporter)
                .GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(run.Exporter);

            Assert.Null(routeBatch);
        }

        [Fact]
        public void MultiTenantExportRequiresAMultiTenantTransmitter()
        {
            var transmitter = new SingleTenantOnlyTransmitter();

            Assert.Throws<NotSupportedException>(
                () => new AzureMonitorLogExporter(transmitter, multiTenantEnabled: true));

            Assert.True(transmitter.Disposed);
        }

        [Fact]
        public void GateDefaultsToOff()
        {
            Assert.False(MultiTenantConfig.Enabled);

            var run = RunExporter(
                configure: null,
                createExporter: transmitter => new AzureMonitorLogExporter(transmitter),
                Emit(Ikey("ikey-a"), Endpoint(EastUs)));

            Assert.Equal(ExportResult.Success, run.Result);
            Assert.Equal(1, run.Transmitter.TrackAsyncCallCount);
        }

        /// <summary>
        /// Trace-based logs sampling runs in the OTel pipeline before the exporter, so a routed log
        /// tied to an unsampled parent span never reaches the routing path, while a sampled or
        /// trace-less routed log does.
        /// </summary>
        [Fact]
        public void TraceBasedFilteringDropsUnsampledRoutedLogsBeforeRouting()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorLogExporter(transmitter, multiTenantEnabled: true);

            using (var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
                    options.AddProcessor(new LogFilteringProcessor(exporter));
                });
                builder.AddFilter(SourceName, LogLevel.Trace);
            }))
            {
                var logger = loggerFactory.CreateLogger(SourceName);

                using (var unsampled = new Activity("unsampled"))
                {
                    unsampled.ActivityTraceFlags = ActivityTraceFlags.None;
                    unsampled.Start();
                    Emit(Ikey("ikey-dropped"), Endpoint(EastUs))(logger);
                }

                using (var sampled = new Activity("sampled"))
                {
                    sampled.ActivityTraceFlags = ActivityTraceFlags.Recorded;
                    sampled.Start();
                    Emit(Ikey("ikey-sampled"), Endpoint(EastUs))(logger);
                }

                // No parent span at all: reaches routing.
                Emit(Ikey("ikey-traceless"), Endpoint(WestUs))(logger);
            }

            var routed = transmitter.Sends
                .SelectMany(send => send.TelemetryItems.Select(item => item.InstrumentationKey))
                .ToList();

            Assert.DoesNotContain("ikey-dropped", routed);
            Assert.Contains("ikey-sampled", routed);
            Assert.Contains("ikey-traceless", routed);
        }

        /// <summary>
        /// On a persist-only shutdown a routed log still goes through the multi-tenant
        /// <see cref="IMultiTenantTransmitter.Track"/> path (not <c>TrackAsync</c>), exercising the
        /// log-exporter-specific <see cref="AzureMonitorBatchLogRecordExportProcessor"/> wiring.
        /// </summary>
        [Fact]
        public void RoutedLogUsesTheMultiTenantTrackPathDuringPersistOnlyShutdown()
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorLogExporter(transmitter, multiTenantEnabled: true);

            using (var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
                    options.AddProcessor(new AzureMonitorBatchLogRecordExportProcessor(exporter));
                });
                builder.AddFilter(SourceName, LogLevel.Trace);
            }))
            {
                var logger = loggerFactory.CreateLogger(SourceName);
                Emit(Ikey("ikey-a"), Endpoint(EastUs))(logger);

                // Disposal shuts the processor down; persist-on-shutdown is on by default.
            }

            Assert.True(transmitter.PersistOnlyScopeCount >= 1);
            Assert.Equal(0, transmitter.TrackAsyncCallCount);
            Assert.Single(transmitter.Sends);
            Assert.Equal(EastUs, transmitter.Sends[0].IngestionEndpoint);
            Assert.Equal(new[] { "ikey-a" }, transmitter.Sends[0].TelemetryItems.Select(item => item.InstrumentationKey));
        }

        private EndpointRouteBatch Convert(params Action<ILogger>[] emits)
            => Convert(resource: null, emits);

        private EndpointRouteBatch Convert(AzureMonitorResource? resource, params Action<ILogger>[] emits)
        {
            var routeBatch = new EndpointRouteBatch();
            WithLiveBatch(batch => LogsHelper.OtelToAzureMonitorLogsMultiTenant(batch, resource, routeBatch), emits);
            return routeBatch;
        }

        private List<TelemetryItem> ConvertSingleTenant(string instrumentationKey, params Action<ILogger>[] emits)
            => ConvertSingleTenant(instrumentationKey, resource: null, emits);

        private List<TelemetryItem> ConvertSingleTenant(string instrumentationKey, AzureMonitorResource? resource, params Action<ILogger>[] emits)
        {
            List<TelemetryItem> telemetryItems = new();
            WithLiveBatch(batch => telemetryItems = LogsHelper.OtelToAzureMonitorLogs(batch, resource, instrumentationKey).TelemetryItems, emits);
            return telemetryItems;
        }

        private ExporterRun RunExporter(bool multiTenantEnabled, params Action<ILogger>[] emits)
            => RunExporter(configure: null, createExporter: transmitter => new AzureMonitorLogExporter(transmitter, multiTenantEnabled), emits);

        private ExporterRun RunExporter(Action<MockTransmitter>? configure, Func<MockTransmitter, AzureMonitorLogExporter> createExporter, params Action<ILogger>[] emits)
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            configure?.Invoke(transmitter);

            var exporter = createExporter(transmitter);
            var run = new ExporterRun { Transmitter = transmitter, Exporter = exporter, Result = ExportResult.Success };

            WithLiveBatch(batch => run.Result = exporter.Export(batch), emits);

            return run;
        }

        /// <summary>
        /// Emits the records through a batch processor and hands the live <see cref="Batch{T}"/> to
        /// <paramref name="use"/> during a single forced flush, so the pooled records are all valid at
        /// once and are never referenced after they return to the pool.
        /// </summary>
        private void WithLiveBatch(Action<Batch<LogRecord>> use, params Action<ILogger>[] emits)
        {
            var exporter = new CaptureExporter(use);
            var processor = new BatchLogRecordExportProcessor(
                exporter,
                maxQueueSize: 4096,
                scheduledDelayMilliseconds: 60000,
                exporterTimeoutMilliseconds: 30000,
                maxExportBatchSize: 4096);

            using (var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
                    options.AddProcessor(processor);
                });
                builder.AddFilter(SourceName, LogLevel.Trace);
            }))
            {
                var logger = loggerFactory.CreateLogger(SourceName);
                foreach (var emit in emits)
                {
                    emit(logger);
                }

                processor.ForceFlush();
            }
        }

        private static KeyValuePair<string, object?> Ikey(object? value)
            => new(SemanticConventions.AttributeMicrosoftInstrumentationKey, value);

        private static KeyValuePair<string, object?> Endpoint(object? value)
            => new(SemanticConventions.AttributeMicrosoftIngestionEndpoint, value);

        private static KeyValuePair<string, object?> CloudRole(object? value)
            => new(SemanticConventions.AttributeMicrosoftMultiEndpointCloudRole, value);

        private static AzureMonitorResource CreateResource()
            => ResourceBuilder.CreateDefault()
                .AddAttributes(new Dictionary<string, object>
                {
                    { "service.name", "relay-host" },
                    { "service.instance.id", "relay-instance" },
                })
                .Build()
                .CreateAzureMonitorResource("exporter-ikey")!;

        private static Action<ILogger> Emit(params KeyValuePair<string, object?>[] attributes)
            => Emit("Test log message", null, attributes);

        private static Action<ILogger> Emit(string message, Exception? exception, params KeyValuePair<string, object?>[] attributes)
        {
            // A list state is surfaced verbatim as LogRecord.Attributes, which lets a test place the
            // routing tags at any position (including after an availability marker) and use non-string
            // values without going through structured message formatting.
            var state = attributes.ToList();
            return logger => logger.Log(LogLevel.Information, new EventId(0), state, exception, (_, _) => message);
        }

        /// <summary>
        /// Timestamps differ between two emissions of the same corpus; nothing else may.
        /// </summary>
        private static string Normalize(string payload) => Regex.Replace(
            payload,
            "\"(time)\":\"[^\"]*\"",
            "\"$1\":\"\"");

        private sealed class ExporterRun
        {
            public ExportResult Result { get; set; }

            public MockTransmitter Transmitter { get; set; } = null!;

            public AzureMonitorLogExporter Exporter { get; set; } = null!;
        }

        private sealed class CaptureExporter : BaseExporter<LogRecord>
        {
            private readonly Action<Batch<LogRecord>> _onExport;

            public CaptureExporter(Action<Batch<LogRecord>> onExport) => _onExport = onExport;

            public override ExportResult Export(in Batch<LogRecord> batch)
            {
                _onExport(batch);
                return ExportResult.Success;
            }
        }

        private sealed class SingleTenantOnlyTransmitter : ITransmitter
        {
            public string InstrumentationKey => "single-tenant-ikey";

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
