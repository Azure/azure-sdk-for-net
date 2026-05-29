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
        public void DistroSwitchOn_EuCustomer_RoutesToDistroEuEndpoint(string euEndpoint)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetStatsbeatConnectionString(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStats_ConnectionString_Distro_EU, result);
        }

        [Theory]
        [MemberData(nameof(StatsbeatTests.NonEuEndpoints), MemberType = typeof(StatsbeatTests))]
        public void DistroSwitchOn_NonEuCustomer_RoutesToDistroNonEuEndpoint(string nonEuEndpoint)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEuEndpoint}.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetStatsbeatConnectionString(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStats_ConnectionString_Distro_NonEU, result);
        }

        [Fact]
        public void DistroSwitchOn_UnknownRegion_FallsBackToDistroNonEuEndpoint()
        {
            // Without the distro switch this same input returns null and Statsbeat throws.
            // With the switch on we default to the non-EU distro endpoint so the inert
            // exporter pin used by the distro can still initialize Statsbeat.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetStatsbeatConnectionString(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStats_ConnectionString_Distro_NonEU, result);
        }

        [Fact]
        public void DistroSwitchOn_StatsbeatInitializes_ForUnknownRegion()
        {
            // Counterpart to the existing StatsbeatIsNotInitializedForUnknownRegions test:
            // with the distro switch on, the constructor must succeed (no throw) because
            // the distro relies on this for OTLP/Console/Agent365-only deployments where
            // the placeholder customer connection string has no known region.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customerCs);

            using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            Assert.Equal(StatsbeatConstants.SdkStats_ConnectionString_Distro_NonEU, statsBeatInstance._statsbeat_ConnectionString);
        }
    }
}
