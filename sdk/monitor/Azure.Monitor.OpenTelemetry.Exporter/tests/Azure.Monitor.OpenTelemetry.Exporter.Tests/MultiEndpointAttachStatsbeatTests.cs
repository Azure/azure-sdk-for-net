// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class MultiEndpointAttachStatsbeatTests
    {
        private const string CustomerKey = "11111111-2222-3333-4444-555555555555";
        private const string CustomerConnectionString = "InstrumentationKey=" + CustomerKey + ";IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/";

        [Theory]
        [InlineData(false, CustomerKey)]
        [InlineData(true, "N/A")]
        public void AttachUsesTheAppropriateCustomerIdentity(bool multiEndpointEnabled, string expectedCustomerKey)
        {
            using var scope = new AttachTestScope(multiEndpointEnabled, configured: true);

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
        public void RoutingOnlyAttachUsesNAWithoutEnablingNetworkStats()
        {
            using var scope = new AttachTestScope(multiEndpointEnabled: true, configured: false);

            Assert.True(scope.Statsbeat._statsbeatMeterProvider!.ForceFlush());

            var attach = Assert.Single(scope.AttachMeasurements());
            Assert.Equal("N/A", attach.Properties["cikey"]);
            Assert.Null(scope.Statsbeat.NetworkSdkStatsManager);
            Assert.Equal(scope.StatsConnectionString, scope.Statsbeat._statsbeat_ConnectionString);
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

            internal AttachTestScope(bool multiEndpointEnabled, bool configured, bool useOverride = true)
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
