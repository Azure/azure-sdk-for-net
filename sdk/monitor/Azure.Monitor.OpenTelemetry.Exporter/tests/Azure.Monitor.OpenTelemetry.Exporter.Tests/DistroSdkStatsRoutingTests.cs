// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Tests for the distro SDK statistics routing AppContext switch. Isolated into its own
    /// class + collection because the switch is process-wide; concurrent execution with the
    /// routing-off tests in <see cref="StatsbeatTests"/> would race.
    /// </summary>
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class DistroSdkStatsRoutingTests : IDisposable
    {
        private readonly bool _previousSwitchValue;
        private readonly bool _hadSwitch;

        public DistroSdkStatsRoutingTests()
        {
            _hadSwitch = AppContext.TryGetSwitch(
                StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, out _previousSwitchValue);
            AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, true);
        }

        public void Dispose()
        {
            if (_hadSwitch)
            {
                AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, _previousSwitchValue);
            }
            else
            {
                // No clean "unset" API; the typical pattern is to leave it false.
                AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, false);
            }
        }

        [Theory]
        [MemberData(nameof(StatsbeatTests.EuEndpoints), MemberType = typeof(StatsbeatTests))]
        public void GetSdkStatsConfigUrl_EuCustomer_ReturnsEuConfigUrl(string euEndpoint)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetSdkStatsConfigUrl(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_EU, result);
        }

        [Theory]
        [MemberData(nameof(StatsbeatTests.NonEuEndpoints), MemberType = typeof(StatsbeatTests))]
        public void GetSdkStatsConfigUrl_NonEuCustomer_ReturnsNonEuConfigUrl(string nonEuEndpoint)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEuEndpoint}.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetSdkStatsConfigUrl(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, result);
        }

        [Fact]
        public void GetSdkStatsConfigUrl_UnknownRegion_FallsBackToNonEu()
        {
            // Unknown region defaults to the non-EU config endpoint so the distro can
            // still attempt to fetch configuration for OTLP/Console/Agent365-only
            // deployments that supply the placeholder iKey + an unrecognized region.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetSdkStatsConfigUrl(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, result);
        }

        [Fact]
        public void DistroSwitchOn_ConstructorDoesNotThrow_ForUnknownRegion()
        {
            // Counterpart to StatsbeatIsNotInitializedForUnknownRegions: when the distro
            // switch is on the constructor must complete without throwing even if the
            // customer connection string maps to an unknown region. SDK statistics
            // initialization is deferred to a background task (which fetches the remote
            // configuration); the constructor itself only kicks that task off.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customerCs);

            // No throw == passing assertion for this case. The Statsbeat MeterProvider
            // will only build later (and only if the remote config returns enabled=true
            // and a valid url); we cannot synchronously assert on that here without
            // standing up an in-process HTTP stub.
            using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            // _statsbeat_ConnectionString stays null until the background fetch completes
            // and returns a non-null, enabled config — neither expected during this test.
            Assert.Null(statsBeatInstance._statsbeat_ConnectionString);
        }
    }
}
