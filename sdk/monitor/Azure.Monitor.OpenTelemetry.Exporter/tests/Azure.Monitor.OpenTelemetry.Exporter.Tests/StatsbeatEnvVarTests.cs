// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Verifies the internal SDKStats environment-variable configuration surface
    /// (spec: disabledAll / shortInterval / longInterval / connectionString) and the
    /// VM "os" dimension fallback.
    /// </summary>
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class StatsbeatEnvVarTests
    {
        private const string NonEuConnectionString =
            "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://eastus.in.applicationinsights.azure.com/";

        [Theory]
        // Concrete IMDS osType wins and is lower-cased.
        [InlineData("Windows", "linux", "windows")]
        [InlineData("Linux", "windows", "linux")]
        [InlineData("linux", "linux", "linux")]
        // null / empty / literal "Unknown" fall back to the running process OS.
        [InlineData(null, "linux", "linux")]
        [InlineData("", "windows", "windows")]
        [InlineData("Unknown", "osx", "osx")]
        [InlineData("unknown", "windows", "windows")]
        public void ResolveOperatingSystem_FallsBackToProcessOsWhenUnknownOrNull(string? vmOsType, string processOs, string expected)
        {
            Assert.Equal(expected, AzureMonitorStatsbeat.ResolveOperatingSystem(vmOsType, processOs));
        }

        [Fact]
        public void ShortExportInterval_DefaultsToNetworkStatsbeatInterval()
        {
            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), new MockPlatform());

            Assert.Equal(StatsbeatConstants.NetworkStatsbeatInterval, statsbeat._networkExportIntervalMilliseconds);
        }

        [Fact]
        public void ShortExportInterval_OverriddenFromEnvVarInSeconds()
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_SHORT_EXPORT_INTERVAL, "30");

            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), platform);

            Assert.Equal(30_000, statsbeat._networkExportIntervalMilliseconds);
        }

        [Theory]
        [InlineData("not-a-number")]
        [InlineData("0")]
        [InlineData("-5")]
        [InlineData("2147484")] // seconds * 1000 would overflow int; must fall back to default.
        public void ShortExportInterval_InvalidValueFallsBackToDefault(string value)
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_SHORT_EXPORT_INTERVAL, value);

            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), platform);

            Assert.Equal(StatsbeatConstants.NetworkStatsbeatInterval, statsbeat._networkExportIntervalMilliseconds);
        }

        [Fact]
        public void LongExportInterval_DefaultsToAttachEmissionInterval()
        {
            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), new MockPlatform());

            Assert.Equal(StatsbeatConstants.AttachEmissionInterval, statsbeat._attachEmissionInterval);
        }

        [Fact]
        public void LongExportInterval_OverriddenFromEnvVarInSeconds()
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_LONG_EXPORT_INTERVAL, "3600");

            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), platform);

            Assert.Equal(TimeSpan.FromSeconds(3600), statsbeat._attachEmissionInterval);
        }

        [Fact]
        public void ConnectionStringOverride_TakesPrecedenceOverRegionEndpoint()
        {
            var platform = new MockPlatform();
            var overrideConnectionString =
                "InstrumentationKey=11111111-1111-1111-1111-111111111111;IngestionEndpoint=https://sdkstats.test.example.com/";
            platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING, overrideConnectionString);

            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), platform);

            Assert.Equal(overrideConnectionString, statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public void ConnectionStringOverride_BypassesUnknownRegionThrow()
        {
            // An unknown region normally throws in the legacy path; the override must short-circuit
            // that resolution so SDKStats still initialize against the override destination.
            var platform = new MockPlatform();
            var overrideConnectionString =
                "InstrumentationKey=11111111-1111-1111-1111-111111111111;IngestionEndpoint=https://sdkstats.test.example.com/";
            platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING, overrideConnectionString);

            var unknownRegion = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(unknownRegion), platform);

            Assert.Equal(overrideConnectionString, statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public void ConnectionStringOverride_TakesPrecedenceOverDistroRoutedEndpoint()
        {
            // With the distro routing switch enabled, resolution would normally take the
            // background config-fetch path. The override must win synchronously and bypass it.
            var switchName = StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName;
            var previous = AppContext.TryGetSwitch(switchName, out var enabled) && enabled;
            AppContext.SetSwitch(switchName, true);
            try
            {
                var platform = new MockPlatform();
                var overrideConnectionString =
                    "InstrumentationKey=11111111-1111-1111-1111-111111111111;IngestionEndpoint=https://sdkstats.test.example.com/";
                platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING, overrideConnectionString);

                using var statsbeat = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(NonEuConnectionString), platform);

                // Set synchronously by the override branch (no background config fetch task).
                Assert.Equal(overrideConnectionString, statsbeat._statsbeat_ConnectionString);
                Assert.Null(statsbeat._configInitializationTask);
            }
            finally
            {
                AppContext.SetSwitch(switchName, previous);
            }
        }

        [Fact]
        public void DisabledAll_KillSwitch_PreventsStatsbeatInitialization()
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_SDKSTATS_DISABLED_ALL, "true");

            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { ConnectionString = NonEuConnectionString }, platform);

            Assert.Null(transmitter._statsbeat);
        }

        [Fact]
        public void DisabledAll_UnsetByDefault_StatsbeatIsInitialized()
        {
            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { ConnectionString = NonEuConnectionString }, new MockPlatform());

            Assert.NotNull(transmitter._statsbeat);
        }
    }
}
