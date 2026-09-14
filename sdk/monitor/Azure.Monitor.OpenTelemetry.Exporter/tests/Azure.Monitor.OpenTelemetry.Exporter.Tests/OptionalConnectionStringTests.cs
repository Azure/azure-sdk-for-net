// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Multi-endpoint routing takes every destination from the telemetry itself, so a process that
    /// only routes has no component of its own. Requiring a connection string forced callers to
    /// nominate one that receives nothing, yet whose key was stamped on SDK statistics as though it
    /// owned the traffic.
    /// </summary>
    public class OptionalConnectionStringTests
    {
        private const string EnvironmentVariable = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        // ---------- Routing on, nothing configured: the new behaviour ----------

        [Fact]
        public void RoutingWithoutAConnectionStringIsAllowed()
        {
            var connectionVars = AzureMonitorTransmitter.InitializeConnectionVars(
                new AzureMonitorExporterOptions(), new MockPlatform(), multiEndpointEnabled: true);

            Assert.True(connectionVars.IsRoutingOnly);
            Assert.Equal(string.Empty, connectionVars.InstrumentationKey);
        }

        /// <summary>
        /// The endpoint only seeds the REST client, which rewrites the URI for each routed group, so
        /// it has to be a usable absolute URI even though nothing is sent to it.
        /// </summary>
        [Fact]
        public void TheRoutingOnlyEndpointIsAUsableUri()
        {
            var connectionVars = ConnectionVars.CreateRoutingOnly();

            Assert.True(Uri.TryCreate(connectionVars.IngestionEndpoint, UriKind.Absolute, out _));
            Assert.True(Uri.TryCreate(connectionVars.LiveEndpoint, UriKind.Absolute, out _));
        }

        /// <summary>A credential has no audience to scope to, so it must not silently be honoured.</summary>
        [Fact]
        public void TheRoutingOnlyVarsCarryNoAudience()
        {
            Assert.Null(ConnectionVars.CreateRoutingOnly().AadAudience);
        }

        [Fact]
        public void RoutingWithoutAConnectionStringIsAnnounced()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            AzureMonitorTransmitter.InitializeConnectionVars(
                new AzureMonitorExporterOptions(), new MockPlatform(), multiEndpointEnabled: true);

            Assert.Single(listener.Messages.Where(e => e.EventName == "RoutingWithoutConnectionString"));
        }

        /// <summary>
        /// A transmitter is the thing that actually had to be constructible; the vars alone prove
        /// nothing about the storage, REST client and back-off state built from them.
        /// </summary>
        [Fact]
        public void ATransmitterCanBeBuiltWithoutAConnectionString()
        {
            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { DisableOfflineStorage = true },
                new MockPlatform(),
                multiEndpointEnabled: true);

            Assert.Equal(string.Empty, transmitter.InstrumentationKey);
        }

        /// <summary>
        /// Statistics identify a component by key and pick their region from its endpoint. Without a
        /// connection string there is neither, and a routed destination cannot supply them because it
        /// is chosen per item, long after construction.
        /// </summary>
        [Fact]
        public void NoSdkStatisticsAreCollectedWithoutAConnectionString()
        {
            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { DisableOfflineStorage = true },
                new MockPlatform(),
                multiEndpointEnabled: true);

            Assert.Null(StatsbeatOf(transmitter));
        }

        // ---------- Routing off: unchanged ----------

        [Fact]
        public void WithoutRoutingAMissingConnectionStringStillThrows()
        {
            var exception = Assert.Throws<InvalidOperationException>(
                () => AzureMonitorTransmitter.InitializeConnectionVars(
                    new AzureMonitorExporterOptions(), new MockPlatform(), multiEndpointEnabled: false));

            Assert.Equal("A connection string was not found. Please set your connection string.", exception.Message);
        }

        /// <summary>The overload every existing caller uses must keep throwing.</summary>
        [Fact]
        public void TheLegacyOverloadStillThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => AzureMonitorTransmitter.InitializeConnectionVars(new AzureMonitorExporterOptions(), new MockPlatform()));
        }

        [Fact]
        public void WithoutRoutingATransmitterStillThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => new AzureMonitorTransmitter(new AzureMonitorExporterOptions(), new MockPlatform()));
        }

        // ---------- A configured connection string wins in both modes ----------

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AConfiguredConnectionStringIsUsedRegardlessOfRouting(bool multiEndpointEnabled)
        {
            var connectionVars = AzureMonitorTransmitter.InitializeConnectionVars(
                new AzureMonitorExporterOptions { ConnectionString = "InstrumentationKey=configured" },
                new MockPlatform(),
                multiEndpointEnabled);

            Assert.False(connectionVars.IsRoutingOnly);
            Assert.Equal("configured", connectionVars.InstrumentationKey);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TheEnvironmentVariableIsStillHonouredRegardlessOfRouting(bool multiEndpointEnabled)
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariable, "InstrumentationKey=from-env");

            var connectionVars = AzureMonitorTransmitter.InitializeConnectionVars(
                new AzureMonitorExporterOptions(), platform, multiEndpointEnabled);

            Assert.False(connectionVars.IsRoutingOnly);
            Assert.Equal("from-env", connectionVars.InstrumentationKey);
        }

        /// <summary>A malformed value is still an error; routing is not a fallback for a typo.</summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AnInvalidConnectionStringStillThrowsRegardlessOfRouting(bool multiEndpointEnabled)
        {
            Assert.Throws<InvalidOperationException>(
                () => AzureMonitorTransmitter.InitializeConnectionVars(
                    new AzureMonitorExporterOptions { ConnectionString = "IngestionEndpoint=https://example.com/" },
                    new MockPlatform(),
                    multiEndpointEnabled));
        }

        /// <summary>Whitespace is not a connection string, so routing should treat it as absent.</summary>
        [Fact]
        public void AWhitespaceEnvironmentVariableFallsBackToRoutingOnly()
        {
            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariable, "   ");

            var connectionVars = AzureMonitorTransmitter.InitializeConnectionVars(
                new AzureMonitorExporterOptions(), platform, multiEndpointEnabled: true);

            Assert.True(connectionVars.IsRoutingOnly);
        }

        // ---------- Storage directory ----------

        /// <summary>
        /// The seed changing would move every existing directory, orphaning backlogs that were
        /// persisted for delivery.
        /// </summary>
        [Fact]
        public void AConfiguredKeyProducesTheSameDirectoryAsBefore()
        {
            var platform = MockPlatformForStorage();

            var directory = StorageHelper.GetStorageDirectory(platform, configuredStorageDirectory: "C:\\root", instrumentationKey: "ikey-a");
            var expected = Path.Combine("C:\\root", HashHelper.GetSHA256Hash("ikey-a;user;process;appdir"));

            Assert.Equal(expected, directory);
        }

        /// <summary>
        /// User, process and application directory already identify an application on a machine, so
        /// the segment is omitted rather than filled with a placeholder.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WithoutAKeyTheSegmentIsOmittedRatherThanBlank(string? instrumentationKey)
        {
            var platform = MockPlatformForStorage();

            var directory = StorageHelper.GetStorageDirectory(platform, configuredStorageDirectory: "C:\\root", instrumentationKey: instrumentationKey);
            var expected = Path.Combine("C:\\root", HashHelper.GetSHA256Hash("user;process;appdir"));

            Assert.Equal(expected, directory);
            Assert.NotEqual(Path.Combine("C:\\root", HashHelper.GetSHA256Hash(";user;process;appdir")), directory);
        }

        [Fact]
        public void TwoApplicationsWithoutKeysStillGetDifferentDirectories()
        {
            var first = StorageHelper.GetStorageDirectory(MockPlatformForStorage(processName: "first"), "C:\\root", instrumentationKey: null);
            var second = StorageHelper.GetStorageDirectory(MockPlatformForStorage(processName: "second"), "C:\\root", instrumentationKey: null);

            Assert.NotEqual(first, second);
        }

        private static MockPlatform MockPlatformForStorage(string processName = "process")
            => new()
            {
                UserName = "user",
                ProcessName = processName,
                ApplicationBaseDirectory = "appdir",
            };

        private static object? StatsbeatOf(AzureMonitorTransmitter transmitter)
            => typeof(AzureMonitorTransmitter)
                .GetField("_statsbeat", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
                .GetValue(transmitter);
    }
}
