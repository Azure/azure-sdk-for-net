// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
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
        public void StatsbeatMeterProviderSubscribesToDistroFeatureSdkStatsMeter()
        {
            // Verifies the Statsbeat MeterProvider subscribes to the distro-owned
            // Feature SDKStats meter so the opentelemetry-distro-dotnet producer
            // can publish through this exporter without further wiring.
            var customer_ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://westus.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);

            using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            // Emit a sentinel measurement on the distro meter and confirm a MeterListener
            // attached to the same meter name receives it. This proves the Meter name
            // wires up; the Statsbeat MeterProvider uses the same string in .AddMeter(...).
            using var sentinelMeter = new Meter(StatsbeatConstants.DistroFeatureSdkStatsMeterName, "1.0");
            var observed = new List<long>();
            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.DistroFeatureSdkStatsMeterName)
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, _, _) => observed.Add(value));
            listener.Start();

            var gauge = sentinelMeter.CreateObservableGauge<long>("Feature", () => 42L);
            listener.RecordObservableInstruments();

            Assert.Contains(42L, observed);
            Assert.Equal(StatsbeatConstants.DistroFeatureSdkStatsMeterName, "MicrosoftOpenTelemetryFeatureSdkStatsMeter");
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
    }
}
