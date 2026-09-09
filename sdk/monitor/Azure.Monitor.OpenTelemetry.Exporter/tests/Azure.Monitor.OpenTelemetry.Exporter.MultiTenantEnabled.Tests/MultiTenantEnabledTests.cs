// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.MultiTenantEnabled.Tests
{
    /// <summary>
    /// Covers the one link the main test assembly cannot reach: that the AppContext switch is what
    /// turns routing on.
    /// </summary>
    /// <remarks>
    /// Every test over there passes the gate explicitly as a constructor argument, which keeps them
    /// from mutating process-wide state but means nothing exercises <see cref="MultiTenantConfig.Enabled"/>
    /// being true. It cannot: the value is captured by a static initializer the moment the type is
    /// first touched, and by then the other tests have touched it. This assembly runs in its own test
    /// host with the switch set by a module initializer, so the constructors that default the gate
    /// see it on.
    /// </remarks>
    public class MultiTenantEnabledTests
    {
        private const string HostInstrumentationKey = "00000000-0000-0000-0000-000000000000";
        private const string TenantInstrumentationKey = "ikey-tenant";
        private const string TenantEndpoint = "https://eastus-1.in.applicationinsights.azure.com/";

        static MultiTenantEnabledTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;
        }

        [Fact]
        public void SwitchIsRead()
        {
            Assert.True(MultiTenantConfig.Enabled);
        }

        /// <summary>
        /// The constructor that defaults the gate, rather than the one that takes it.
        /// </summary>
        [Fact]
        public void ExporterThatDefaultsTheGateRoutesByEndpoint()
        {
            var transmitter = new RecordingTransmitter();

            using var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), transmitter);

            var result = exporter.Export(CreateBatch(CreateRoutedActivity()));

            Assert.Equal(ExportResult.Success, result);

            var send = Assert.Single(transmitter.RoutedSends);
            Assert.Equal(TenantEndpoint, send.IngestionEndpoint);
            Assert.Equal(TenantInstrumentationKey, Assert.Single(send.TelemetryItems).InstrumentationKey);

            // Routed telemetry must not also travel the host's own path.
            Assert.Empty(transmitter.HostSends);
        }

        /// <summary>
        /// An Activity without the routing attributes has nowhere to go, and must not fall back to
        /// the host's resource.
        /// </summary>
        [Fact]
        public void ActivityWithoutRoutingAttributesIsDropped()
        {
            var transmitter = new RecordingTransmitter();

            using var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), transmitter);

            var activitySource = new ActivitySource(nameof(ActivityWithoutRoutingAttributesIsDropped));
            using var listener = CreateListener(activitySource.Name);

            var activity = activitySource.StartActivity("Unrouted", ActivityKind.Server);
            activity!.Stop();

            var result = exporter.Export(CreateBatch(activity));

            Assert.Equal(ExportResult.Success, result);
            Assert.Empty(transmitter.RoutedSends);
            Assert.Empty(transmitter.HostSends);
        }

        private static Activity CreateRoutedActivity()
        {
            var activitySource = new ActivitySource(nameof(CreateRoutedActivity));
            using var listener = CreateListener(activitySource.Name);

            var activity = activitySource.StartActivity(
                "Routed",
                ActivityKind.Server,
                parentContext: default,
                tags: new Dictionary<string, object?>
                {
                    [SemanticConventions.AttributeMicrosoftInstrumentationKey] = TenantInstrumentationKey,
                    [SemanticConventions.AttributeMicrosoftIngestionEndpoint] = TenantEndpoint,
                });

            activity!.Stop();

            return activity;
        }

        private static ActivityListener CreateListener(string sourceName)
        {
            var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == sourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            return listener;
        }

        private static Batch<Activity> CreateBatch(params Activity[] activities)
            => new(activities, activities.Length);

        /// <summary>
        /// Records which path telemetry took, so a test can tell routing from host delivery.
        /// </summary>
        private sealed class RecordingTransmitter : ITransmitter, IMultiTenantTransmitter
        {
            internal List<(string IngestionEndpoint, TelemetryItem[] TelemetryItems)> RoutedSends { get; } = new();

            internal List<TelemetryItem> HostSends { get; } = new();

            public string InstrumentationKey => HostInstrumentationKey;

            public bool IsAadEnabled => false;

            public ExportResult Track(EndpointRouteBatch routeBatch, TelemetryItemOrigin origin, CancellationToken cancellationToken)
            {
                for (int i = 0; i < routeBatch.Count; i++)
                {
                    var group = routeBatch[i];

                    RoutedSends.Add((group.IngestionEndpoint, group.TelemetryItems.ToArray()));
                }

                return ExportResult.Success;
            }

            public ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
            {
                HostSends.AddRange(telemetryItems);

                return new ValueTask<ExportResult>(ExportResult.Success);
            }

            public ValueTask TransmitFromStorage(long maxFileToTransmit, bool async, CancellationToken cancellationToken) => default;

            public IDisposable BeginPersistOnlyScope() => new NoopScope();

            public void DrainStorage(int waitMilliseconds)
            {
            }

            public void Dispose()
            {
            }

            private sealed class NoopScope : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
}
