// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class StatsbeatTests
    {
        public static TheoryData<string> EuEndpoints
        {
            get
            {
                var data = new TheoryData<string>();
                foreach (var e in StatsbeatConstants.s_EU_Endpoints.AsEnumerable())
                {
                    data.Add(e);
                }
                return data;
            }
        }

        public static TheoryData<string> NonEuEndpoints
        {
            get
            {
                var data = new TheoryData<string>();
                foreach (var e in StatsbeatConstants.s_non_EU_Endpoints.AsEnumerable())
                {
                    data.Add(e);
                }
                return data;
            }
        }

        [Theory]
        [MemberData(nameof(EuEndpoints))]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInEU(string euEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            Assert.Equal(StatsbeatConstants.Statsbeat_ConnectionString_EU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Theory]
        [MemberData(nameof(NonEuEndpoints))]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInNonEU(string nonEUEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEUEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            Assert.Equal(StatsbeatConstants.Statsbeat_ConnectionString_NonEU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Fact]
        public void StatsbeatIsNotInitializedForUnknownRegions()
        {
            var customer_ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform()));
        }

        [Fact]
        public void ConstructingAzureMonitorMetricExporter_TriggersStatsbeatSideEffect()
        {
            // CANARY TEST. The opentelemetry-distro-dotnet relies on the fact that simply
            // constructing AzureMonitorMetricExporter(options) is enough to spin up a
            // Statsbeat MeterProvider for that connection string — even when the exporter
            // is never attached to any reader. This is how the distro lights up Feature
            // SDKStats for OTLP-only / Console-only / Agent365-only deployments.
            //
            // If this test ever fails, the side effect has been removed or deferred and the
            // distro's RegisterDistroFeatureSdkStats / TryCreateStatsbeatPin code must be
            // rewritten (likely against a new public exporter API).

            // Use a unique connection string so TransmitterFactory's per-CS cache doesn't
            // return a previously-constructed transmitter from another test.
            var uniqueGuid = Guid.NewGuid().ToString();
            var connectionString = $"InstrumentationKey={uniqueGuid};IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/";

            // Attach a MeterListener BEFORE construction so we observe instrument-published
            // events from the side-effect-created Statsbeat Meter.
            var observedMeters = new HashSet<string>();
            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, _) => observedMeters.Add(instrument.Meter.Name),
            };
            listener.Start();

            // Construct the exporter and immediately dispose. The ctor invokes
            // TransmitterFactory.Get -> new AzureMonitorTransmitter -> InitializeStatsbeat,
            // which creates the Meter("AttachStatsbeatMeter") inside AzureMonitorStatsbeat.
            using var exporter = new AzureMonitorMetricExporter(
                new AzureMonitorExporterOptions { ConnectionString = connectionString });

            Assert.Contains(StatsbeatConstants.AttachStatsbeatMeterName, observedMeters);
        }

        public static TheoryData<string> DistroSdkStatsMeterNames => new()
        {
            StatsbeatConstants.DistroFeatureSdkStatsMeterName,
            StatsbeatConstants.DistroNetworkSdkStatsMeterName,
        };

        [Theory]
        [MemberData(nameof(DistroSdkStatsMeterNames))]
        public void StatsbeatMeterProvider_SubscribesToDistroSdkStatsMeters(string distroMeterName)
        {
            // SENTINEL TEST. The Microsoft.OpenTelemetry distro emits distro-owned Feature and
            // Network SDKStats on dedicated meters (e.g. when running with a non-Azure-Monitor
            // exporter). The Statsbeat MeterProvider must subscribe to those meters via
            // .AddMeter(...) so the measurements flow through the existing Statsbeat cadence.
            //
            // If this test fails, an .AddMeter(StatsbeatConstants.Distro*SdkStatsMeterName) entry
            // in AzureMonitorStatsbeat.BuildMeterProvider was removed or the meter constant was
            // renamed, silently dropping distro-emitted SDKStats.

            var connectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://eastus.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(connectionString);

            using var statsbeat = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());
            Assert.NotNull(statsbeat._statsbeatMeterProvider);

            // Publish an observable instrument on the distro meter. If the Statsbeat
            // MeterProvider subscribed to this meter, ForceFlush collects the instrument and
            // invokes the callback; otherwise the callback never runs.
            using var distroMeter = new Meter(distroMeterName);
            var callbackInvoked = false;
            distroMeter.CreateObservableGauge("test.sentinel", () =>
            {
                callbackInvoked = true;
                return new Measurement<long>(1);
            });

            statsbeat._statsbeatMeterProvider!.ForceFlush();

            Assert.True(callbackInvoked, $"Statsbeat MeterProvider did not subscribe to '{distroMeterName}'.");
        }
    }
}
