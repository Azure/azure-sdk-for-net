// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;

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

            Assert.True(connectionVars.IsUnconfigured);
            Assert.Equal(string.Empty, connectionVars.InstrumentationKey);
        }

        /// <summary>
        /// The endpoint only seeds the REST client, which rewrites the URI for each routed group, so
        /// it has to be a usable absolute URI even though nothing is sent to it.
        /// </summary>
        [Fact]
        public void TheRoutingOnlyEndpointIsAUsableUri()
        {
            var connectionVars = ConnectionVars.CreateUnconfigured();

            Assert.True(Uri.TryCreate(connectionVars.IngestionEndpoint, UriKind.Absolute, out _));
            Assert.True(Uri.TryCreate(connectionVars.LiveEndpoint, UriKind.Absolute, out _));
        }

        /// <summary>A credential has no audience to scope to, so it must not silently be honoured.</summary>
        [Fact]
        public void TheRoutingOnlyVarsCarryNoAudience()
        {
            Assert.Null(ConnectionVars.CreateUnconfigured().AadAudience);
        }

        /// <summary>
        /// Warning, not Informational: the operator is running a process that can send nothing of its
        /// own, which is worth surfacing at the level most listeners actually subscribe to.
        /// </summary>
        [Fact]
        public void RoutingWithoutAConnectionStringIsAnnounced()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            AzureMonitorTransmitter.InitializeConnectionVars(
                new AzureMonitorExporterOptions(), new MockPlatform(), multiEndpointEnabled: true);

            var announcement = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutingWithoutConnectionString"));
            Assert.Equal(77, announcement.EventId);
            Assert.Equal(EventLevel.Warning, announcement.Level);
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
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { DisableOfflineStorage = true },
                new MockPlatform(),
                multiEndpointEnabled: true);

            Assert.Null(StatsbeatOf(transmitter));

            // Null alone would not prove the guard: statsbeat cannot map the placeholder endpoint to
            // a region, so removing the guard leaves it null anyway, by way of a caught exception.
            // Never attempting it is the behaviour under test.
            Assert.Empty(listener.Messages.Where(e => e.EventName == "ErrorInitializingStatsbeat"));
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

            Assert.False(connectionVars.IsUnconfigured);
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

            Assert.False(connectionVars.IsUnconfigured);
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

            Assert.True(connectionVars.IsUnconfigured);
        }

        // ---------- Storage directory ----------

        /// <summary>
        /// The seed changing would move every existing directory, orphaning backlogs that were
        /// persisted for delivery. The expectation is a literal rather than a second call to
        /// <see cref="HashHelper"/>, so that a change to the hash itself cannot satisfy it.
        /// </summary>
        [Fact]
        public void AConfiguredKeyProducesTheSameDirectoryAsBefore()
        {
            var directory = StorageHelper.GetStorageDirectory(MockPlatformForStorage(), configuredStorageDirectory: "C:\\root", instrumentationKey: "ikey-a");

            Assert.Equal(Path.Combine("C:\\root", "1468ec91488193bdf84d4390f553c2ded5fd4848881cbd77592d09d3aba09b2b"), directory);
        }

        /// <summary>
        /// A configured connection string can legitimately carry an empty key, and such a process
        /// already has a directory. The decision keys on the caller's mode, never on the value, so
        /// that backlog stays where it is.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AnEmptyKeyFromAConnectionStringKeepsItsExistingDirectory(string? instrumentationKey)
        {
            var directory = StorageHelper.GetStorageDirectory(MockPlatformForStorage(), "C:\\root", instrumentationKey!, omitInstrumentationKey: false);

            Assert.Equal(Path.Combine("C:\\root", "a4ca073d30fde56a69f4a3e48ef0bd598f7e4bf34a890a863f5d2b1850869498"), directory);
        }

        /// <summary>
        /// User, process and application directory already identify an application on a machine, so
        /// the segment is omitted rather than filled with a placeholder.
        /// </summary>
        [Fact]
        public void WithoutAConnectionStringTheSegmentIsOmittedRatherThanBlank()
        {
            var directory = StorageHelper.GetStorageDirectory(MockPlatformForStorage(), "C:\\root", string.Empty, omitInstrumentationKey: true);

            Assert.Equal(Path.Combine("C:\\root", "cb7b21eaaf0cc9844a28c90a35480fbefb3872f51620a5ddee5454470694ecfb"), directory);
            Assert.NotEqual(Path.Combine("C:\\root", "a4ca073d30fde56a69f4a3e48ef0bd598f7e4bf34a890a863f5d2b1850869498"), directory);
        }

        [Fact]
        public void TwoApplicationsWithoutKeysStillGetDifferentDirectories()
        {
            var first = StorageHelper.GetStorageDirectory(MockPlatformForStorage(processName: "first"), "C:\\root", string.Empty, omitInstrumentationKey: true);
            var second = StorageHelper.GetStorageDirectory(MockPlatformForStorage(processName: "second"), "C:\\root", string.Empty, omitInstrumentationKey: true);

            Assert.NotEqual(first, second);
        }

        // ---------- Nothing drains the backlog to a component that does not exist ----------

        /// <summary>
        /// Anything already on disk was addressed to a component this process no longer has, and the
        /// handler would send it to whichever host seeded the REST client. Not creating it, nor the
        /// provider that would feed it, makes that impossible rather than merely unused. Routed
        /// storage is the one path that must survive, so it is asserted in the same breath.
        /// </summary>
        [Fact]
        public void NothingDrainsStorageWithoutAConnectionString()
        {
            var root = StorageRoot();
            try
            {
                using var transmitter = new AzureMonitorTransmitter(
                    new AzureMonitorExporterOptions { StorageDirectory = root, EnableStatsbeat = false },
                    MockPlatformForStorage(),
                    multiEndpointEnabled: true);

                Assert.Null(DrainHandlerOf(transmitter));
                Assert.Null(FieldOf(transmitter, "_fileBlobProvider"));
                Assert.NotNull(FieldOf(transmitter, "_multiEndpointStorage"));
            }
            finally
            {
                DeleteStorageRoot(root);
            }
        }

        /// <summary>The same construction with a connection string must still drain, or this is a regression.</summary>
        [Fact]
        public void StorageStillDrainsWithAConnectionString()
        {
            var root = StorageRoot();
            try
            {
                using var transmitter = new AzureMonitorTransmitter(
                    new AzureMonitorExporterOptions { ConnectionString = "InstrumentationKey=configured", StorageDirectory = root, EnableStatsbeat = false },
                    MockPlatformForStorage(),
                    multiEndpointEnabled: true);

                Assert.NotNull(DrainHandlerOf(transmitter));
                Assert.NotNull(FieldOf(transmitter, "_fileBlobProvider"));
            }
            finally
            {
                DeleteStorageRoot(root);
            }
        }

        /// <summary>
        /// The unrouted send path addresses the configured endpoint under the configured key, both of
        /// which are placeholders here. Every caller is gated already; this is what keeps the send
        /// itself impossible when a new one is added.
        /// </summary>
        [Fact]
        public async Task UnroutedTelemetryIsRefusedRatherThanSentToThePlaceholder()
        {
            using var transmitter = new AzureMonitorTransmitter(
                new AzureMonitorExporterOptions { DisableOfflineStorage = true, EnableStatsbeat = false },
                MockPlatformForStorage(),
                multiEndpointEnabled: true);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            var result = await transmitter.TrackAsync(
                Array.Empty<TelemetryItem>(),
                new TelemetrySchemaTypeCounter(),
                TelemetryItemOrigin.AzureMonitorTraceExporter,
                async: true,
                CancellationToken.None);

            Assert.Equal(ExportResult.Failure, result);
            Assert.Single(listener.Messages.Where(e => e.EventName == "DroppedUnroutedTelemetryWithoutConnectionString"));
        }

        // ---------- Customer SDK statistics ----------

        /// <summary>
        /// These are addressed to the customer's own component. Without a connection string there is
        /// none, so the provider must not be built at all. The decision is asserted directly as well:
        /// running the registration for the positive case would leave an undisposable provider and a
        /// cached transmitter behind for the rest of the run.
        /// </summary>
        [Fact]
        public void NoCustomerSdkStatsWithoutAConnectionString()
        {
            Assert.False(CustomerSdkStatsRegistration.HasConnectionString(new AzureMonitorExporterOptions(), new MockPlatform()));
            Assert.False(CustomerSdkStatsRegistration.HasConnectionString(new AzureMonitorExporterOptions { ConnectionString = "   " }, new MockPlatform()));

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            CustomerSdkStatsRegistration.RegisterCustomerSdkStats(new AzureMonitorExporterOptions(), new MockPlatform());

            // Neither collected nor failed: it was never attempted.
            Assert.Empty(listener.Messages.Where(e => e.EventName == "CustomerSdkStatsEnabled"));
            Assert.Empty(listener.Messages.Where(e => e.EventName == "CustomerSdkStatsInitializationFailed"));
        }

        /// <summary>With a connection string the guard lets registration through, from either source.</summary>
        [Fact]
        public void CustomerSdkStatsStillAllowedWithAConnectionString()
        {
            Assert.True(CustomerSdkStatsHelper.IsEnabled(), "these stats are on by default; the guard under test is the connection string, not the switch");

            Assert.True(CustomerSdkStatsRegistration.HasConnectionString(
                new AzureMonitorExporterOptions { ConnectionString = "InstrumentationKey=configured" }, new MockPlatform()));

            var platform = new MockPlatform();
            platform.SetEnvironmentVariable(EnvironmentVariable, "InstrumentationKey=from-env");

            Assert.True(CustomerSdkStatsRegistration.HasConnectionString(new AzureMonitorExporterOptions(), platform));
        }

        private static MockPlatform MockPlatformForStorage(string processName = "process")
            => new()
            {
                UserName = "user",
                ProcessName = processName,
                ApplicationBaseDirectory = "appdir",
            };

        private static string StorageRoot()
        {
            var root = Path.Combine(Path.GetTempPath(), "otel-optional-cs", Guid.NewGuid().ToString("n"));
            Directory.CreateDirectory(root);
            return root;
        }

        private static void DeleteStorageRoot(string root)
        {
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
                // A maintenance timer may still hold a handle. Leaving the directory behind is not
                // worth failing a passing test over.
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        private static object? StatsbeatOf(AzureMonitorTransmitter transmitter)
            => FieldOf(transmitter, "_statsbeat");

        private static object? DrainHandlerOf(AzureMonitorTransmitter transmitter)
            => FieldOf(transmitter, "_transmitFromStorageHandler");

        private static object? FieldOf(AzureMonitorTransmitter transmitter, string name)
            => typeof(AzureMonitorTransmitter)
                .GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
                .GetValue(transmitter);
    }
}
