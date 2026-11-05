// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Components of one logical application, such as the .NET SDK's managed and AOT entry points,
    /// can report different process names or base directories. The override lets them share one
    /// storage directory while user and instrumentation key keep isolating everything else.
    /// </summary>
    [Collection(nameof(PersistOnShutdownSwitchCollection))]
    public class StorageSubDirectoryOverrideTests : IDisposable
    {
        private const string Root = "C:\\root";

        public void Dispose() => SetOverride(null);

        [Fact]
        public void ComponentsWithDifferentIdentitiesShareADirectory()
        {
            var managed = StorageHelper.GetStorageDirectory(Platform(processName: "dotnet", baseDirectory: "sdk"), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "shared");
            var aot = StorageHelper.GetStorageDirectory(Platform(processName: "dotnet-aot", baseDirectory: "sdk/aot"), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "shared");

            Assert.Equal(managed, aot);

            // Literal rather than a second call to HashHelper, so a change to the seed or the hash
            // cannot satisfy it and silently move directories that already hold a backlog.
            Assert.Equal(Path.Combine(Root, "353c6715b1328859a2584a08b7c15b135914e2c740d30b2bbc728104d5297e82"), managed);
        }

        [Fact]
        public void WithoutAConnectionStringTheKeySegmentIsStillOmitted()
        {
            var directory = StorageHelper.GetStorageDirectory(Platform(), Root, string.Empty, omitInstrumentationKey: true, subDirectoryOverride: "shared");

            Assert.Equal(Path.Combine(Root, "771d9f90f36fe5c42e65f84cdc15c5aa0294ffb2322aeccd2c0a5343a8484979"), directory);
        }

        [Fact]
        public void DifferentInstrumentationKeysStayIsolated()
        {
            var first = StorageHelper.GetStorageDirectory(Platform(), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "shared");
            var second = StorageHelper.GetStorageDirectory(Platform(), Root, "ikey-b", omitInstrumentationKey: false, subDirectoryOverride: "shared");

            Assert.NotEqual(first, second);
        }

        [Fact]
        public void DifferentUsersStayIsolated()
        {
            var first = StorageHelper.GetStorageDirectory(Platform(userName: "alice"), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "shared");
            var second = StorageHelper.GetStorageDirectory(Platform(userName: "bob"), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "shared");

            Assert.NotEqual(first, second);
        }

        [Fact]
        public void DifferentOverridesStayIsolated()
        {
            var first = StorageHelper.GetStorageDirectory(Platform(), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "first");
            var second = StorageHelper.GetStorageDirectory(Platform(), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: "second");

            Assert.NotEqual(first, second);
        }

        /// <summary>Without an override, existing directories must not move.</summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void NoOverrideKeepsTheExistingDirectory(string? subDirectoryOverride)
        {
            var directory = StorageHelper.GetStorageDirectory(Platform(), Root, "ikey-a", omitInstrumentationKey: false, subDirectoryOverride: subDirectoryOverride);

            Assert.Equal(Path.Combine(Root, "1468ec91488193bdf84d4390f553c2ded5fd4848881cbd77592d09d3aba09b2b"), directory);
        }

        [Fact]
        public void UnsetReadsAsNoOverride()
        {
            SetOverride(null);

            Assert.Null(StorageConfig.GetSubDirectoryOverride());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void BlankReadsAsNoOverride(string value)
        {
            SetOverride(value);

            Assert.Null(StorageConfig.GetSubDirectoryOverride());
        }

        [Fact]
        public void AStringIsReadAndTrimmed()
        {
            SetOverride("  shared  ");

            Assert.Equal("shared", StorageConfig.GetSubDirectoryOverride());
        }

        [Fact]
        public void ANonStringValueIsIgnoredAndReported()
        {
            SetOverride(42);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

            Assert.Null(StorageConfig.GetSubDirectoryOverride());
            Assert.Single(listener.Messages.Where(e => e.EventName == nameof(AzureMonitorExporterEventSource.StorageSubDirectoryOverrideIgnored)));
        }

        [Fact]
        public void TheTransmitterAppliesTheOverride()
        {
            var root = Path.Combine(Path.GetTempPath(), "otel-storage-subdir", Guid.NewGuid().ToString("n"));
            Directory.CreateDirectory(root);
            try
            {
                SetOverride("shared");

                using var listener = new TestEventListener();
                listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Verbose, EventKeywords.All);

                var options = new AzureMonitorExporterOptions { ConnectionString = "InstrumentationKey=ikey-a", StorageDirectory = root, EnableStatsbeat = false };

                using (new AzureMonitorTransmitter(options, Platform(processName: "dotnet", baseDirectory: "sdk")))
                using (new AzureMonitorTransmitter(options, Platform(processName: "dotnet-aot", baseDirectory: "sdk/aot")))
                {
                }

                var applied = listener.Messages
                    .Where(e => e.EventName == nameof(AzureMonitorExporterEventSource.StorageSubDirectoryOverrideApplied))
                    .Select(e => (string)e.Payload![2]!)
                    .ToList();

                Assert.Equal(2, applied.Count);
                Assert.All(applied, directory => Assert.Equal(Path.Combine(root, "353c6715b1328859a2584a08b7c15b135914e2c740d30b2bbc728104d5297e82"), directory));
            }
            finally
            {
                SetOverride(null);
                try
                {
                    Directory.Delete(root, recursive: true);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// .NET Framework has no AppContext.SetData, and AppDomain.SetData is what AppContext reads
        /// from, so this is the portable way to drive the override.
        /// </summary>
        private static void SetOverride(object? value)
            => AppDomain.CurrentDomain.SetData(StorageConfig.SubDirectoryOverrideName, value);

        private static MockPlatform Platform(string userName = "user", string processName = "process", string baseDirectory = "appdir")
            => new()
            {
                UserName = userName,
                ProcessName = processName,
                ApplicationBaseDirectory = baseDirectory,
            };
    }
}
