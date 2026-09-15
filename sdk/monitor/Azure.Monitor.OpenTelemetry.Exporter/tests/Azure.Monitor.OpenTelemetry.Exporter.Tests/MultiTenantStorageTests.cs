// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;
using OpenTelemetry.PersistentStorage.FileSystem;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MultiTenantStorageTests : IDisposable
    {
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";

        private readonly string _rootDirectory = Path.Combine(Path.GetTempPath(), $"mt-storage-{Guid.NewGuid():N}");
        private readonly bool _eagerDrainWasDisabled = TransmitFromStorageHandler.DisableEagerDrainForTesting;

        public MultiTenantStorageTests()
        {
            // A partition starts draining 50 ms after it opens, which would lease and delete the very
            // blobs these tests count.
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;
        }

        [Fact]
        public void EachEndpointGetsItsOwnPartition()
        {
            using var storage = CreateStorage();

            var eastUs = storage.TryGet(EastUs);
            var westUs = storage.TryGet(WestUs);

            Assert.NotNull(eastUs);
            Assert.NotNull(westUs);
            Assert.NotEqual(eastUs!.Directory, westUs!.Directory);
            Assert.StartsWith(_rootDirectory, eastUs.Directory, StringComparison.Ordinal);
            Assert.StartsWith(_rootDirectory, westUs.Directory, StringComparison.Ordinal);
        }

        [Fact]
        public void TheSameEndpointReusesItsPartition()
        {
            using var storage = CreateStorage();

            Assert.Same(storage.TryGet(EastUs), storage.TryGet(EastUs));
        }

        /// <summary>
        /// The directory has to be derivable from the endpoint alone, because that is all a later
        /// process has to work out where a leftover blob should be posted.
        /// </summary>
        [Fact]
        public void PartitionDirectoryIsDerivedFromTheEndpoint()
        {
            using var storage = CreateStorage();

            var expected = Path.Combine(_rootDirectory, HashHelper.GetSHA256Hash(EastUs));

            Assert.Equal(expected, storage.TryGet(EastUs)!.Directory);
        }

        /// <summary>
        /// Each partition owns a directory, a drain timer, and a blob provider, so the count is
        /// capped rather than following the caller's endpoint count.
        /// </summary>
        [Fact]
        public void PartitionsAreBounded()
        {
            using var storage = CreateStorage();

            for (int i = 0; i < MultiTenantStorage.MaxEndpointPartitions; i++)
            {
                Assert.NotNull(storage.TryGet($"https://region-{i}.in.applicationinsights.azure.com/"));
            }

            Assert.Null(storage.TryGet("https://one-too-many.in.applicationinsights.azure.com/"));

            // An endpoint already holding a partition keeps working past the bound.
            Assert.NotNull(storage.TryGet("https://region-0.in.applicationinsights.azure.com/"));
        }

        [Fact]
        public void DisposeTearsDownEveryPartition()
        {
            var storage = CreateStorage();

            storage.TryGet(EastUs);
            storage.TryGet(WestUs);
            Assert.Equal(2, storage.Partitions.Count());

            storage.Dispose();

            Assert.Empty(storage.Partitions);
            Assert.Null(storage.TryGet(EastUs));
        }

        /// <summary>
        /// A partition drain that fails before issuing a request must be attributed to the endpoint
        /// it drains. <c>TrackException</c> falls back to the exporter's own ingestion host when given
        /// none, which would blame the wrong region.
        /// </summary>
        [Theory]
        [InlineData(true, "eastus-1")]
        [InlineData(false, "westus-2")]
        public void DrainExceptionIsAttributedToTheEndpointBeingDrained(bool routed, string expectedHost)
        {
            var wasDisabled = TransmitFromStorageHandler.DisableEagerDrainForTesting;
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;

            try
            {
                // The exporter's own connection string points at West US, so a routed partition that
                // reported no host would be recorded there.
                var connectionVars = ConnectionStringParser.GetValues(
                    $"InstrumentationKey=00000000-0000-0000-0000-000000000004;IngestionEndpoint={WestUs}");

                var options = new AzureMonitorExporterOptions();
                var restClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), WestUs);
                var statsManager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

                string? observedHost = null;
                using var listener = new MeterListener
                {
                    InstrumentPublished = (instrument, l) =>
                    {
                        if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                            && instrument.Name == "Exception_Count")
                        {
                            l.EnableMeasurementEvents(instrument);
                        }
                    },
                };

                listener.SetMeasurementEventCallback<long>((_, _, tags, _) =>
                {
                    foreach (var tag in tags)
                    {
                        if (tag.Key == "host")
                        {
                            observedHost = tag.Value as string;
                        }
                    }
                });

                listener.Start();

                using var handler = new TransmitFromStorageHandler(
                    restClient,
                    new ThrowingBlobProvider(),
                    new TransmissionStateManager(),
                    connectionVars,
                    isAadEnabled: false,
                    statsManager,
                    storageDirectory: _rootDirectory,
                    trackUri: routed ? ApplicationInsightsRestClient.CreateTrackUri(EastUs) : null);

                handler.Drain();

                Assert.Equal(expectedHost, observedHost);
            }
            finally
            {
                TransmitFromStorageHandler.DisableEagerDrainForTesting = wasDisabled;
            }
        }

        /// <summary>
        /// One budget covers every tenant, so a busy endpoint is held back by what the others have
        /// already written rather than getting a private allowance.
        /// </summary>
        [Fact]
        public void TheStorageBudgetIsSharedAcrossPartitions()
        {
            const long Budget = 16384;

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;
            var westUs = storage.TryGet(WestUs)!;

            var payload = new byte[4096];

            for (int i = 0; i < 4; i++)
            {
                storage.SaveTelemetry(eastUs, payload);
            }

            for (int i = 0; i < 4; i++)
            {
                storage.SaveTelemetry(westUs, payload);
            }

            var totalBytes = Directory
                .EnumerateFiles(_rootDirectory, "*", SearchOption.AllDirectories)
                .Sum(file => new FileInfo(file).Length);

            Assert.True(totalBytes <= Budget, $"total {totalBytes} bytes exceeded the shared budget of {Budget}");

            // Both partitions were written to, so the cap was met by evicting rather than by
            // refusing the second endpoint outright.
            Assert.NotEmpty(Directory.GetFiles(westUs.Directory, "*.blob"));

            // Eviction must free the provider's own quota, not just disk. Deleting the file behind
            // its back leaves the tracker full and this write is refused.
            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, payload));
            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(westUs, payload));
        }

        /// <summary>
        /// A directory left by a previous run counts against the budget, so eviction has to be able
        /// to reach it. When it could not, the only blobs it was allowed to delete were the ones the
        /// current run had just written, and the stale backlog it was trying to make room for stayed
        /// exactly where it was.
        /// </summary>
        [Fact]
        public void TelemetryFromAPreviousRunIsEvictedBeforeTelemetryFromThisRun()
        {
            const long Budget = 16384;

            // No partition is ever opened for this endpoint, so nothing in this process owns it.
            var abandoned = Path.Combine(_rootDirectory, HashHelper.GetSHA256Hash("https://gone-away.in.applicationinsights.azure.com/"));
            var stale = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                stale.Add(WriteBlobFile(abandoned, DateTime.UtcNow.AddHours(-1).AddSeconds(i), 4096));
            }

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;
            var payload = new byte[4096];

            // 12288 of the 16384 budget is already spoken for, so this one still fits.
            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, payload));
            var current = Directory.GetFiles(eastUs.Directory, "*.blob").Single();

            // Now full. The next write has to evict, and the oldest blobs are the abandoned ones.
            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, payload));

            Assert.False(File.Exists(stale[0]), "the oldest blob of the previous run should be evicted first");
            Assert.True(File.Exists(current), "telemetry written by this run must survive while older blobs remain");
        }

        /// <summary>
        /// Eviction used to run a fixed number of rounds and then write regardless, so a root full of
        /// blobs smaller than the incoming batch lost that many blobs and either overshot the budget
        /// or dropped the payload anyway.
        /// </summary>
        [Fact]
        public void AFullRootKeepsEvictingUntilTheWriteFits()
        {
            const long Budget = 16384;

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;

            // Small enough that freeing a fixed number of them cannot cover the batch below.
            for (int i = 0; i < 128; i++)
            {
                Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, new byte[128]));
            }

            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, new byte[8192]));

            var totalBytes = Directory
                .EnumerateFiles(_rootDirectory, "*.blob", SearchOption.AllDirectories)
                .Sum(file => new FileInfo(file).Length);

            Assert.True(totalBytes <= Budget, $"total {totalBytes} bytes exceeded the shared budget of {Budget}");
        }

        /// <summary>
        /// The write costs no more than it has to: one blob out for one blob in.
        /// </summary>
        [Fact]
        public void AFullRootEvictsOnlyWhatTheIncomingWriteNeeds()
        {
            const long Budget = 16384;

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;
            var payload = new byte[4096];

            for (int i = 0; i < 4; i++)
            {
                Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, payload));
            }

            Assert.Equal(4, Directory.GetFiles(eastUs.Directory, "*.blob").Length);

            // One more write costs exactly one blob, not the eviction cap.
            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, payload));
            Assert.Equal(4, Directory.GetFiles(eastUs.Directory, "*.blob").Length);
        }

        /// <summary>
        /// The retriable-response path persists through whatever provider it was handed rather than
        /// through <see cref="MultiTenantStorage"/>, so handing out the underlying provider left the
        /// budget enforced per partition and the real cap multiplied by the partition count.
        /// </summary>
        [Fact]
        public void PersistingThroughAPartitionProviderStillHonoursTheSharedBudget()
        {
            const long Budget = 16384;

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;
            var westUs = storage.TryGet(WestUs)!;

            Assert.IsType<BudgetedBlobProvider>(eastUs.BlobProvider);

            var payload = new byte[4096];

            for (int i = 0; i < 4; i++)
            {
                Assert.Equal(ExportResult.Success, eastUs.BlobProvider.SaveTelemetry(payload));
                Assert.Equal(ExportResult.Success, westUs.BlobProvider.SaveTelemetry(payload));
            }

            var totalBytes = Directory
                .EnumerateFiles(_rootDirectory, "*.blob", SearchOption.AllDirectories)
                .Sum(file => new FileInfo(file).Length);

            Assert.True(totalBytes <= Budget, $"total {totalBytes} bytes exceeded the shared budget of {Budget}");
        }

        /// <summary>
        /// A write can fail for reasons eviction cannot fix - a removed directory, a full disk, a
        /// denied ACL. Evicting for those destroys other tenants' telemetry and still does not land
        /// the batch, so the budget must not be the thing blamed when it was not in the way.
        /// </summary>
        [Fact]
        public void AWriteThatFailsWithRoomToSpareEvictsNothing()
        {
            const long Budget = 1024 * 1024;

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;
            var westUs = storage.TryGet(WestUs)!;

            Assert.Equal(ExportResult.Success, westUs.BlobProvider.SaveTelemetry(new byte[4096]));
            var backlog = Directory.GetFiles(westUs.Directory, "*.blob");
            Assert.Single(backlog);

            // Well inside the budget, but the partition cannot be written to.
            Directory.Delete(eastUs.Directory, recursive: true);

            Assert.Equal(ExportResult.Failure, eastUs.BlobProvider.SaveTelemetry(new byte[4096]));
            Assert.True(File.Exists(backlog[0]), "a failure the budget did not cause must not cost another tenant its telemetry");
        }

        /// <summary>
        /// Nothing can make room for a payload larger than the whole budget, so nothing should be
        /// deleted trying.
        /// </summary>
        [Fact]
        public void APayloadLargerThanTheBudgetEvictsNothing()
        {
            const long Budget = 16384;

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;

            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(eastUs, new byte[4096]));
            var existing = Directory.GetFiles(eastUs.Directory, "*.blob").Single();

            Assert.Equal(ExportResult.Failure, storage.SaveTelemetry(eastUs, new byte[Budget + 1]));
            Assert.True(File.Exists(existing), "an impossible write must not cost the backlog");
        }

        /// <summary>
        /// When the candidates on offer cannot cover the shortfall the write is refused anyway, so
        /// deleting them buys nothing and costs the oldest telemetry in the process.
        /// </summary>
        [Fact]
        public void AWriteThatEvictionCannotSatisfyEvictsNothing()
        {
            const int BlobSize = 8;
            const int BlobCount = 400;
            const long Budget = BlobSize * BlobCount;

            // Seeded before the store opens so the budget counts them. Far more blobs than one write
            // may consider, and each far smaller than the batch below, so the candidates it can
            // reach do not add up to the shortfall.
            var directory = Path.Combine(_rootDirectory, HashHelper.GetSHA256Hash(EastUs));
            for (int i = 0; i < BlobCount; i++)
            {
                WriteBlobFile(directory, DateTime.UtcNow.AddMinutes(-BlobCount + i), BlobSize);
            }

            using var storage = CreateStorage(Budget);

            var eastUs = storage.TryGet(EastUs)!;

            Assert.Equal(ExportResult.Failure, storage.SaveTelemetry(eastUs, new byte[Budget - BlobSize]));
            Assert.Equal(BlobCount, Directory.GetFiles(eastUs.Directory, "*.blob").Length);
        }

        /// <summary>
        /// The budget holds when writers run concurrently rather than one at a time, which is the
        /// only way the rest of this class is exercised.
        /// </summary>
        /// <remarks>
        /// This does not reliably reproduce the check-then-act race that <c>TryReserve</c>'s
        /// compare-and-swap exists to prevent: replacing the CAS with a plain read-then-add still
        /// passes, because the window is a few instructions wide and every writer that finds the
        /// budget full queues behind the eviction lock. Treat it as a smoke test for the invariant,
        /// not as a regression test for the reservation.
        /// </remarks>
        [Fact]
        public void ConcurrentWritersDoNotExceedTheSharedBudget()
        {
            const int PayloadSize = 4096;
            const int Writers = 24;
            const long Budget = PayloadSize * 8;

            using var storage = CreateStorage(Budget);

            var partitions = new[]
            {
                storage.TryGet(EastUs)!,
                storage.TryGet(WestUs)!,
                storage.TryGet("https://westeurope-1.in.applicationinsights.azure.com/")!,
            };

            var start = new ManualResetEventSlim();
            var threads = new List<Thread>();

            for (int i = 0; i < Writers; i++)
            {
                var partition = partitions[i % partitions.Length];

                var thread = new Thread(() =>
                {
                    start.Wait();
                    storage.SaveTelemetry(partition, new byte[PayloadSize]);
                });

                threads.Add(thread);
                thread.Start();
            }

            start.Set();

            foreach (var thread in threads)
            {
                Assert.True(thread.Join(TimeSpan.FromSeconds(30)), "a writer did not finish");
            }

            var totalBytes = Directory
                .EnumerateFiles(_rootDirectory, "*.blob", SearchOption.AllDirectories)
                .Sum(file => new FileInfo(file).Length);

            Assert.True(totalBytes <= Budget, $"total {totalBytes} bytes exceeded the shared budget of {Budget}");
        }

        /// <summary>
        /// Partitions are keyed by ingestion endpoint, not by tenant, so tenants in the same region
        /// share one directory and their telemetry ends up in the same blob.
        /// </summary>
        [Fact]
        public void TenantsSharingAnEndpointShareOnePartition()
        {
            using var storage = CreateStorage();

            var first = storage.TryGet(EastUs)!;
            var second = storage.TryGet(EastUs)!;

            Assert.Same(first, second);
            Assert.Single(storage.Partitions);

            // A group is serialized as one payload, so both tenants' envelopes land in one blob.
            var payload = Encoding.UTF8.GetBytes("{\"iKey\":\"ikey-a\"}\n{\"iKey\":\"ikey-b\"}");
            Assert.Equal(ExportResult.Success, storage.SaveTelemetry(first, payload));

            var blob = Directory.GetFiles(first.Directory, "*.blob").Single();
            var content = Encoding.UTF8.GetString(File.ReadAllBytes(blob));

            Assert.Contains("ikey-a", content, StringComparison.Ordinal);
            Assert.Contains("ikey-b", content, StringComparison.Ordinal);
        }

        /// <summary>
        /// Ingestion endpoints are regional and the directory name is a hash of the endpoint, so a
        /// directory written by a previous run is picked up again the next time that region is
        /// routed. That is what makes a manifest unnecessary to recover the backlog.
        /// </summary>
        [Fact]
        public void ADirectoryFromAPreviousRunIsReopenedForTheSameEndpoint()
        {
            var wasDisabled = TransmitFromStorageHandler.DisableEagerDrainForTesting;
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;

            try
            {
                var directory = Path.Combine(_rootDirectory, HashHelper.GetSHA256Hash(EastUs));
                var leftover = WriteBlobFile(directory, DateTime.UtcNow.AddMinutes(-5), 128);

                using var storage = CreateStorage();

                var eastUs = storage.TryGet(EastUs)!;

                Assert.Equal(directory, eastUs.Directory);
                Assert.Contains(eastUs.BlobProvider.GetBlobs(), blob => (blob as FileBlob)?.FullPath == leftover);
            }
            finally
            {
                TransmitFromStorageHandler.DisableEagerDrainForTesting = wasDisabled;
            }
        }

        /// <summary>
        /// Mirrors the provider's own naming, which is what orders blobs by age across directories.
        /// </summary>
        private static string WriteBlobFile(string directory, DateTime timestampUtc, int length)        {
            Directory.CreateDirectory(directory);

            var path = Path.Combine(
                directory,
                $"{timestampUtc.ToString("yyyy-MM-ddTHHmmss.fffffffZ", CultureInfo.InvariantCulture)}-{Guid.NewGuid():N}.blob");

            File.WriteAllBytes(path, new byte[length]);

            return path;
        }

        public void Dispose()
        {
            TransmitFromStorageHandler.DisableEagerDrainForTesting = _eagerDrainWasDisabled;

            try
            {
                if (Directory.Exists(_rootDirectory))
                {
                    Directory.Delete(_rootDirectory, recursive: true);
                }
            }
            catch (IOException)
            {
                // A drain timer may still hold a handle; the temp directory ages out either way.
            }

            GC.SuppressFinalize(this);
        }

        private MultiTenantStorage CreateStorage(long maxSizeBytes = 1024 * 1024)
        {
            var options = new AzureMonitorExporterOptions();
            var restClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), EastUs);
            var connectionVars = new ConnectionVars("ikey", EastUs, EastUs, aadAudience: null);

            return new MultiTenantStorage(restClient, connectionVars, isAadEnabled: false, _rootDirectory, maxSizeBytes, networkSdkStatsManager: null);
        }

        /// <summary>Fails the drain before any request is issued.</summary>
        private sealed class ThrowingBlobProvider : PersistentBlobProvider
        {
            // Thrown on enumeration, because PersistentBlobProvider.GetBlobs swallows exceptions
            // raised by the call itself.
            protected override IEnumerable<PersistentBlob> OnGetBlobs() => new ThrowingEnumerable();

            protected override bool OnTryCreateBlob(byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob blob)
            {
                blob = null!;
                return false;
            }

            protected override bool OnTryCreateBlob(byte[] buffer, out PersistentBlob blob)
            {
                blob = null!;
                return false;
            }

            protected override bool OnTryGetBlob(out PersistentBlob blob)
            {
                blob = null!;
                return false;
            }

            private sealed class ThrowingEnumerable : IEnumerable<PersistentBlob>
            {
                public IEnumerator<PersistentBlob> GetEnumerator() => throw new InvalidOperationException("storage unavailable");

                IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            }
        }
    }
}
