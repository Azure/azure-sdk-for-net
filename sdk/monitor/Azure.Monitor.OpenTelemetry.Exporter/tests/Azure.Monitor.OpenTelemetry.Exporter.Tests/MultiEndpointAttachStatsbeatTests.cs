// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;
using TestEventListener = Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework.TestEventListener;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class MultiEndpointAttachStatsbeatTests
    {
        private const string CustomerKey = "11111111-2222-3333-4444-555555555555";
        private const string CustomerConnectionString = "InstrumentationKey=" + CustomerKey + ";IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/";
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestEurope = "https://westeurope-5.in.applicationinsights.azure.com/";

        [Theory]
        [InlineData(false, CustomerKey)]
        [InlineData(true, "routed-key")]
        public void AttachUsesTheAppropriateCustomerIdentity(bool multiEndpointEnabled, string expectedCustomerKey)
        {
            using var scope = new AttachTestScope(multiEndpointEnabled, configured: true);
            scope.Observe(("routed-key", EastUs));

            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            var attach = Assert.Single(scope.AttachMeasurements());
            Assert.Equal(1, Assert.Single(attach.Metrics).Value);
            Assert.Equal(expectedCustomerKey, attach.Properties["cikey"]);
            Assert.Equal("appsvc", attach.Properties["rp"]);
            Assert.Equal(scope.ResourceProviderId, attach.Properties["rpId"]);
            Assert.NotNull(scope.Statsbeat.NetworkSdkStatsManager);
            Assert.Contains(scope.Statsbeat.NetworkSdkStatsManager.BuildBaseTags("westeurope-5"),
                tag => tag.Key == "cikey" && (string?)tag.Value == CustomerKey);
        }

        [Fact]
        public void RoutingOnlyAttachReportsObservedKeysWithoutEnablingNetworkStats()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            scope.Observe(("first-key", EastUs), ("second-key", WestEurope));

            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            Assert.Equal(new[] { "first-key", "second-key" },
                scope.AttachMeasurements().Select(data => data.Properties["cikey"]).OrderBy(key => key));
            Assert.All(scope.AttachMeasurements(), data => Assert.Equal(scope.ResourceProviderId, data.Properties["rpId"]));
            Assert.Null(scope.Statsbeat.NetworkSdkStatsManager);
            Assert.Equal(scope.StatsConnectionString, scope.Statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public void NoObservedCustomerDoesNotProduceAnAttach()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Empty(scope.AttachMeasurements());
        }

        [Fact]
        public void AnUnrecognizedConfiguredRegionDoesNotNewlyEnableNetworkStats()
        {
            using var scope = new MockStatsbeatScope();
            using var statsbeat = new AzureMonitorStatsbeat(
                Internals.ConnectionString.ConnectionStringParser.GetValues(
                    "InstrumentationKey=host;IngestionEndpoint=https://unknown.example.invalid/"),
                scope.Platform,
                multiEndpointEnabled: true);
            statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(("observed", EastUs)));

            Assert.Null(statsbeat.NetworkSdkStatsManager);
            Assert.True(statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Equal("observed", ((MetricsData)Assert.Single(scope.TelemetryItems).Data.BaseData).Properties["cikey"]);
        }

        [Fact]
        public void MixedRegionsUseTheirOwnInternalInstrumentationKeys()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false, useOverride: false);
            scope.Observe(("us-key", EastUs), ("eu-key", WestEurope));
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            Assert.Contains(scope.Items(), item => item.InstrumentationKey == StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU
                && ((MetricsData)item.Data.BaseData).Properties["cikey"] == "us-key");
            Assert.Contains(scope.Items(), item => item.InstrumentationKey == StatsbeatConstants.Statsbeat_InstrumentationKey_EU
                && ((MetricsData)item.Data.BaseData).Properties["cikey"] == "eu-key");
        }

        [Fact]
        public void FourResourcesUseTheExistingExportersRegionalGroups()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false, useOverride: false);
            scope.Observe(("us-1", EastUs), ("us-2", EastUs), ("eu-1", WestEurope), ("eu-2", WestEurope));
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            var transmitter = Assert.IsType<MockTransmitter>(
                TransmitterFactory.Instance._transmitters[StatsbeatConstants.Statsbeat_ConnectionString_NonEU]);
            Assert.Equal(0, transmitter.TrackAsyncCallCount);
            Assert.Equal(2, transmitter.Sends.Count);
            Assert.All(transmitter.Sends, send => Assert.Equal(2, send.TelemetryItems.Length));
            Assert.Equal(new[] { "eu-1", "eu-2", "us-1", "us-2" },
                scope.AttachMeasurements().Select(data => data.Properties["cikey"]).OrderBy(key => key));
            Assert.All(scope.AttachMeasurements(), data =>
            {
                Assert.Equal(1, Assert.Single(data.Metrics).Value);
                Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftInstrumentationKey, data.Properties.Keys);
                Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftIngestionEndpoint, data.Properties.Keys);
                Assert.Equal(scope.ResourceProviderId, data.Properties["rpId"]);
            });
            Assert.All(transmitter.Sends, send => Assert.All(send.TelemetryItems, item =>
                Assert.Equal(send.IngestionEndpoint.Contains("westeurope")
                    ? StatsbeatConstants.Statsbeat_InstrumentationKey_EU
                    : StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU, item.InstrumentationKey)));
        }

        [Fact]
        public void AnOverrideAppliesToBothRegions()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            scope.Observe(("us-key", EastUs), ("eu-key", WestEurope));
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            var key = Internals.ConnectionString.ConnectionStringParser.GetValues(scope.StatsConnectionString).InstrumentationKey;
            Assert.Equal(2, scope.Items().Length);
            Assert.All(scope.Items(), item => Assert.Equal(key, item.InstrumentationKey));
        }

        [Fact]
        public void OneRegionsSendFailureDoesNotPreventTheOtherRegion()
        {
            using var scope = new MockStatsbeatScope();
            var sends = new List<(string Host, string Content)>();
            var options = AzureMonitorStatsbeat.CreateExporterOptions(StatsbeatConstants.Statsbeat_ConnectionString_NonEU);
            options.Transport = new MockTransport(request =>
            {
                Assert.True(HttpPipelineHelper.TryGetRequestContent(request.Content, out var content));
                var host = Assert.IsType<string>(request.Uri.Host);
                sends.Add((host, System.Text.Encoding.UTF8.GetString(content!)));
                return new MockResponse(host.StartsWith("westus", StringComparison.Ordinal) ? 500 : 200);
            });
            using var transmitter = new AzureMonitorTransmitter(options, scope.Platform);
            TransmitterFactory.Instance.Set(StatsbeatConstants.Statsbeat_ConnectionString_NonEU, transmitter);
            using var statsbeat = new AzureMonitorStatsbeat(
                Internals.ConnectionString.ConnectionVars.CreateUnconfigured(), scope.Platform, multiEndpointEnabled: true);
            using var provider = statsbeat._statsbeatMeterProvider!;
            statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(("us", EastUs), ("eu", WestEurope)));

            Assert.False(provider.ForceFlush());
            Assert.Equal(2, sends.Count);
            Assert.Contains(sends, send => send.Host.StartsWith("westus", StringComparison.Ordinal));
            var eu = Assert.Single(sends.Where(send => send.Host.StartsWith("westeurope", StringComparison.Ordinal)));
            Assert.Contains(StatsbeatConstants.Statsbeat_InstrumentationKey_EU, eu.Content);
            Assert.Contains("\"cikey\":\"eu\"", eu.Content);
        }

        [Fact]
        public void LateKeysDoNotWaitForTheEarlierKeysLongInterval()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            scope.Observe(("early", EastUs));
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            scope.Observe(("early", EastUs), ("late", EastUs));
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            Assert.Equal(new[] { "early", "late" },
                scope.AttachMeasurements().Select(data => data.Properties["cikey"]).OrderBy(key => key));
        }

        [Fact]
        public void TheCapIsSilentAndDoesNotChangeCustomerDelivery()
        {
            int customerItems = 0;
            var transport = new MockTransport(request =>
            {
                Assert.True(HttpPipelineHelper.TryGetRequestContent(request.Content, out var content));
                customerItems += System.Text.Encoding.UTF8.GetString(content!).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                return new MockResponse(200);
            });
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false, transport: transport);
            var batch = MockStatsbeatScope.CreateRouteBatch(
                Enumerable.Range(0, AttachStatsbeatRegistry.Capacity + 1).Select(i => ($"key-{i}", EastUs)).ToArray());
            using (var listener = new TestEventListener())
            {
                listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);
                scope.Statsbeat.ObserveAttach(batch);
                Assert.Empty(listener.Messages);
            }

            Assert.Equal(ExportResult.Success,
                scope.Transmitter.Track(batch, TelemetryItemOrigin.AzureMonitorTraceExporter, CancellationToken.None));
            Assert.Equal(AttachStatsbeatRegistry.Capacity + 1, customerItems);
            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Equal(AttachStatsbeatRegistry.Capacity, scope.AttachMeasurements().Length);
        }

        [Fact]
        public void DuplicateKeysAcrossSignalsAreReportedOnce()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            foreach (var origin in new[] { TelemetryItemOrigin.AzureMonitorTraceExporter, TelemetryItemOrigin.AzureMonitorLogExporter, TelemetryItemOrigin.AzureMonitorMetricExporter })
            {
                Assert.Equal(ExportResult.Success, scope.Transmitter.Track(
                    MockStatsbeatScope.CreateRouteBatch(("shared", EastUs)), origin, CancellationToken.None));
            }

            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Equal("shared", Assert.Single(scope.AttachMeasurements()).Properties["cikey"]);
        }

        [Theory]
        [InlineData(false, StatsbeatConstants.Statsbeat_ConnectionString_NonEU)]
        [InlineData(true, StatsbeatConstants.Statsbeat_ConnectionString_EU)]
        public void DefaultDestinationPreservesConfiguredRegionOrUsesNonEu(bool configured, string expectedConnectionString)
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured, useOverride: false);

            Assert.Equal(expectedConnectionString, scope.Statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public void RoutingOnlyCollectorDoesNotEnableOtherSdkStats()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            scope.Observe(("key", EastUs));
            using var featureMeter = new Meter(StatsbeatConstants.DistroFeatureSdkStatsMeterName);
            using var networkMeter = new Meter(StatsbeatConstants.DistroNetworkSdkStatsMeterName);
            featureMeter.CreateObservableGauge("AttachTestFeature", () => 1);
            networkMeter.CreateObservableGauge("AttachTestNetwork", () => 1);

            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            Assert.Single(scope.AttachMeasurements());
            Assert.DoesNotContain(scope.Measurements(), data => data.Metrics.Any(metric => metric.Name == "AttachTestFeature"));
            Assert.DoesNotContain(scope.Measurements(), data => data.Metrics.Any(metric => metric.Name == "AttachTestNetwork"));
        }

        [Fact]
        public void RepeatedCollectionsDoNotRepeatAttachBeforeTheLongInterval()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            scope.Observe(("key", EastUs));
            var provider = scope.Statsbeat._statsbeatMeterProvider!;

            Assert.True(provider.ForceFlush());
            Assert.Single(scope.AttachMeasurements());
            Assert.True(provider.ForceFlush());
            Assert.Single(scope.AttachMeasurements());
            Assert.Same(provider, scope.Statsbeat._statsbeatMeterProvider);
            Assert.Equal(TimeSpan.FromHours(24), scope.Statsbeat._attachEmissionInterval);
            Assert.Equal(900000, scope.Statsbeat._networkExportIntervalMilliseconds);
        }

        [Fact]
        public void SeparateStatsOwnersDoNotConsumeEachOthersAttach()
        {
            using var first = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            using var second = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            first.Observe(("first", EastUs));
            second.Observe(("second", EastUs));

            Assert.True(first.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Single(first.AttachMeasurements());
            Assert.Empty(second.AttachMeasurements());

            Assert.True(second.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Single(second.AttachMeasurements());
        }

        [Fact]
        public void SignalExportersShareTheExistingAttachCollector()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);
            scope.Observe(("key", EastUs));
            var factory = new TransmitterFactory();
            factory.Set(string.Empty, scope.Transmitter);
            var options = new AzureMonitorExporterOptions();

            using var traces = new AzureMonitorTraceExporter(options, factory.Get(options, scope.Platform), multiEndpointEnabled: true);
            using var logs = new AzureMonitorLogExporter(factory.Get(options, scope.Platform), multiEndpointEnabled: true);
            using var metrics = new AzureMonitorMetricExporter(factory.Get(options, scope.Platform), multiEndpointEnabled: true);

            Assert.Same(scope.Transmitter, traces.Transmitter);
            Assert.Same(scope.Transmitter, logs.Transmitter);
            Assert.Same(scope.Transmitter, metrics.Transmitter);
            Assert.Single(factory._transmitters);

            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Single(scope.AttachMeasurements());
        }

        [Theory]
        [InlineData(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATSBEAT_DISABLED)]
        [InlineData(EnvironmentVariableConstants.APPLICATIONINSIGHTS_SDKSTATS_DISABLED_ALL)]
        public void RoutingOnlyAttachHonorsInternalStatsOptOuts(string environmentVariable)
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(environmentVariable, "true");
            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { DisableOfflineStorage = true },
                platform,
                multiEndpointEnabled: true);

            Assert.Null(transmitter._statsbeat);
        }

        [Fact]
        public void InternalTelemetryDoesNotRecursivelyCreateAttach()
        {
            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { DisableOfflineStorage = true, EnableStatsbeat = false },
                new MockPlatform(),
                multiEndpointEnabled: true);

            Assert.Null(transmitter._statsbeat);
        }

        private sealed class AttachTestScope : IDisposable
        {
            private readonly MockStatsbeatScope _stats = new();

            internal AttachTestScope(bool multiEndpointEnabled, bool configured, bool useOverride = true, MockTransport? transport = null)
            {
                ResourceProviderId = _stats.ResourceProviderId;
                Platform = _stats.Platform;

                StatsConnectionString = useOverride
                    ? $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint=https://stats.example.invalid/"
                    : configured ? StatsbeatConstants.Statsbeat_ConnectionString_EU : StatsbeatConstants.Statsbeat_ConnectionString_NonEU;
                if (useOverride)
                {
                    Platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING, StatsConnectionString);
                }

                _stats.Add(StatsConnectionString);

                Transmitter = new AzureMonitorTransmitter(
                    new AzureMonitorExporterOptions
                    {
                        ConnectionString = configured ? CustomerConnectionString : null,
                        DisableOfflineStorage = true,
                        Transport = transport ?? new MockTransport(_ => new MockResponse(200)),
                    },
                    Platform,
                    multiEndpointEnabled);
                Transmitter.AddReference();
            }

            internal string ResourceProviderId { get; }
            internal string StatsConnectionString { get; }
            internal MockPlatform Platform { get; }
            internal AzureMonitorTransmitter Transmitter { get; }
            internal AzureMonitorStatsbeat Statsbeat => Assert.IsType<AzureMonitorStatsbeat>(Transmitter._statsbeat);

            internal void Observe(params (string Key, string Endpoint)[] destinations)
                => Statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(destinations));

            internal TelemetryItem[] Items()
            {
                lock (_stats.TelemetryItems)
                {
                    return _stats.TelemetryItems.ToArray();
                }
            }

            internal MetricsData[] AttachMeasurements() => Measurements()
                .Where(data => data.Metrics.Any(metric => metric.Name == "Attach")
                    && data.Properties.TryGetValue("rpId", out var rpId) && rpId == ResourceProviderId)
                .ToArray();

            internal MetricsData[] Measurements()
            {
                lock (_stats.TelemetryItems)
                {
                    return _stats.TelemetryItems
                        .Select(item => item.Data.BaseData)
                        .OfType<MetricsData>()
                        .ToArray();
                }
            }

            public void Dispose()
            {
                // Complete the final collection before another test publishes an Attach callback.
                Transmitter._statsbeat?._statsbeatMeterProvider?.Dispose();
                Transmitter.Dispose();
                _stats.Dispose();
            }
        }
    }
}
