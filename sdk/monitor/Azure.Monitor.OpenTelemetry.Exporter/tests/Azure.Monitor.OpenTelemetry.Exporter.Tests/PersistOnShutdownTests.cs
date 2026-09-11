// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;
using OpenTelemetry.PersistentStorage.FileSystem;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [Collection(nameof(PersistOnShutdownSwitchCollection))]
    public class PersistOnShutdownTests : IDisposable
    {
        private const string TestIkey = "test_ikey";
        private const string TestEndpoint = "http://localhost:5050";

        private readonly string _storageRoot;

        static PersistOnShutdownTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            ActivitySource.AddActivityListener(new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            });

            // These tests assert on exact storage contents, which a background drain would race.
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;
        }

        public PersistOnShutdownTests()
        {
            _storageRoot = Path.Combine(Path.GetTempPath(), "AzMonPersistTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_storageRoot);
        }

        public void Dispose()
        {
            try
            {
                Directory.Delete(_storageRoot, recursive: true);
            }
            catch (IOException)
            {
                // Leftover temp files are not worth failing a test over.
            }

            GC.SuppressFinalize(this);
        }

        [Fact]
        public void PersistOnlyScopeWritesToStorageWithoutTransmitting()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport);

            using (transmitter.BeginPersistOnlyScope())
            {
                Track(transmitter);
            }

            Assert.Empty(transport.Requests);
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void PersistOnlyScopeIsScopedToTheUsingBlock()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport);

            using (transmitter.BeginPersistOnlyScope())
            {
                Track(transmitter);
            }

            Track(transmitter);

            // The second export happened outside the scope, so it went over the wire.
            Assert.Single(transport.Requests);
            Assert.Single(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void PersistOnlyScopeTransmitsWhenOfflineStorageIsDisabled()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport, disableOfflineStorage: true);

            using (transmitter.BeginPersistOnlyScope())
            {
                Track(transmitter);
            }

            // Without storage the request is the only durability, so it must still be attempted.
            Assert.Single(transport.Requests);
            Assert.Null(transmitter._fileBlobProvider);
        }

        [Fact]
        public void DrainCoalescesStoredBlobsIntoASingleRequest()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":3,\"itemsAccepted\":3,\"errors\":[]}"), out var transport);

            SeedBlobs(transmitter, count: 3);
            Assert.Equal(3, transmitter._fileBlobProvider!.GetBlobs().Count());

            transmitter._transmitFromStorageHandler!.Drain();

            Assert.Single(transport.Requests);
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void DrainIsolatesConstituentsWhenCoalescedBatchIsRejected()
        {
            var requestCount = 0;
            using var transmitter = CreateTransmitter(
                _ =>
                {
                    // The coalesced payload is rejected outright; the individual retries succeed.
                    requestCount++;
                    return requestCount == 1
                        ? new MockResponse(400).SetContent("Bad Request")
                        : new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}");
                },
                out var transport);

            SeedBlobs(transmitter, count: 3);

            transmitter._transmitFromStorageHandler!.Drain();

            Assert.Equal(4, transport.Requests.Count);
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void DrainDeletesABlobIngestionWillNeverAccept()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(400).SetContent("Bad Request"), out _);

            SeedBlobs(transmitter, count: 1);

            transmitter._transmitFromStorageHandler!.Drain();

            // A payload that deterministically fails would otherwise wedge the backlog forever.
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void DrainKeepsBlobsWhenIngestionFailureIsRetriable()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(503).SetContent("Service Unavailable"), out _);

            SeedBlobs(transmitter, count: 1);

            transmitter._transmitFromStorageHandler!.Drain();

            // Leased rather than deleted: the lease expires and a later pass reclaims it.
            Assert.Equal(1, CountFiles("*.lock"));
        }

        [Fact]
        public void DrainReclaimsAnExpiredLeaseLeftByAKilledProcess()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out var transport);

            SeedBlobs(transmitter, count: 1);

            // A lease whose expiry has already passed is what a process killed mid-upload leaves
            // behind. It matches neither the provider's blob enumeration nor its retention sweep.
            var blobFile = Directory.GetFiles(_storageRoot, "*.blob", SearchOption.AllDirectories).Single();
            var expiredLease = $"{blobFile}@{DateTime.UtcNow.AddMinutes(-5):yyyy-MM-ddTHHmmss.fffffffZ}.lock";
            File.Move(blobFile, expiredLease);

            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());

            transmitter._transmitFromStorageHandler!.Drain();

            Assert.Single(transport.Requests);
            Assert.Equal(0, CountFiles("*.lock"));
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void DrainLeavesAnUnexpiredLeaseAlone()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport);

            SeedBlobs(transmitter, count: 1);

            var blobFile = Directory.GetFiles(_storageRoot, "*.blob", SearchOption.AllDirectories).Single();
            var activeLease = $"{blobFile}@{DateTime.UtcNow.AddMinutes(5):yyyy-MM-ddTHHmmss.fffffffZ}.lock";
            File.Move(blobFile, activeLease);

            transmitter._transmitFromStorageHandler!.Drain();

            // Another process may be uploading it right now.
            Assert.Empty(transport.Requests);
            Assert.Equal(1, CountFiles("*.lock"));
        }

        [Fact]
        public void SaveEvictsOldestTelemetryWhenStorageIsFull()
        {
            // The storage provider refuses new telemetry once the directory hits its cap and never
            // evicts, so a stale backlog would otherwise permanently starve current telemetry.
            var directory = Path.Combine(_storageRoot, "full");
            using var provider = new FileBlobProvider(directory, maxSizeInBytes: 2048);

            var accepted = FillToCapacity(provider);
            var storedBeforeEviction = provider.GetBlobs().Count();

            Assert.Equal(ExportResult.Success, provider.SaveTelemetryWithEviction(new byte[512], directory, maxSizeInBytes: 2048));
            Assert.True(provider.GetBlobs().Count() <= storedBeforeEviction);
            Assert.InRange(accepted, 1, 99);
        }

        [Fact]
        public void SaveDoesNotEvictWhenTheFailureIsNotCapacity()
        {
            var directory = Path.Combine(_storageRoot, "notfull");
            using var provider = new FileBlobProvider(directory, maxSizeInBytes: 2048);

            FillToCapacity(provider);
            var storedBeforeSave = provider.GetBlobs().Count();

            // Points the capacity check at an empty directory, standing in for a write that failed
            // for a reason eviction cannot fix - permissions, a full disk, a locked file.
            var elsewhere = Path.Combine(_storageRoot, "empty");
            Directory.CreateDirectory(elsewhere);

            Assert.Equal(ExportResult.Failure, provider.SaveTelemetryWithEviction(new byte[512], elsewhere, maxSizeInBytes: 2048));
            Assert.Equal(storedBeforeSave, provider.GetBlobs().Count());
        }

        private static int FillToCapacity(FileBlobProvider provider)
        {
            var payload = new byte[512];
            var accepted = 0;
            while (accepted < 100 && provider.SaveTelemetry(payload) == ExportResult.Success)
            {
                accepted++;
            }

            return accepted;
        }

        [Fact]
        public void DrainRePersistsOnlyTheRetryableSubsetOfAPartialSuccess()
        {
            // Index 1 is retryable, index 2 is not; index 0 was accepted.
            const string PartialSuccess = "{\"itemsReceived\":3,\"itemsAccepted\":1,\"errors\":["
                + "{\"index\":1,\"statusCode\":500,\"message\":\"Internal Server Error\"},"
                + "{\"index\":2,\"statusCode\":400,\"message\":\"Invalid instrumentation key\"}]}";

            using var transmitter = CreateTransmitter(_ => new MockResponse(206).SetContent(PartialSuccess), out var transport);

            SeedBlobs(transmitter, count: 3);

            transmitter._transmitFromStorageHandler!.Drain();

            // The three originals are superseded by a single blob holding just the retryable item.
            Assert.Single(transport.Requests);
            Assert.Single(transmitter._fileBlobProvider!.GetBlobs());
            Assert.Equal(0, CountFiles("*.lock"));
        }

        [Fact]
        public void DrainKeepsTheBatchWhenAPartialSuccessCannotBeRead()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(206), out _);

            SeedBlobs(transmitter, count: 3);

            transmitter._transmitFromStorageHandler!.Drain();

            // Without a readable response there is no way to know what was accepted, so discarding
            // the batch would lose telemetry that ingestion never confirmed.
            Assert.Equal(3, CountFiles("*.lock"));
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void SharedTransmitterSurvivesUntilEveryExporterIsDisposed()
        {
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}",
                StorageDirectory = _storageRoot,
                Transport = new MockTransport(_ => new MockResponse(200).SetContent("Ok")),
                EnableStatsbeat = false,
            };

            var platform = new MockPlatform();
            var first = (AzureMonitorTransmitter)TransmitterFactory.Instance.Get(options, platform);
            var second = (AzureMonitorTransmitter)TransmitterFactory.Instance.Get(options, platform);

            Assert.Same(first, second);

            // Every signal shares one transmitter, so the first provider to shut down must not take
            // storage draining away from the others.
            first.Dispose();
            Assert.False(first._disposed);

            second.Dispose();
            Assert.True(first._disposed);
        }

        [Fact]
        public void ConcurrentShutdownsShareASingleInFlightDrain()
        {
            using var gate = new ManualResetEventSlim(false);
            using var transmitter = CreateTransmitter(
                _ =>
                {
                    gate.Wait(TimeSpan.FromSeconds(10));
                    return new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}");
                },
                out _);

            SeedBlobs(transmitter, count: 1);

            transmitter.DrainStorage(0);
            var started = transmitter.InFlightDrain;
            Assert.NotNull(started);
            Assert.False(started!.IsCompleted);

            // A second signal shutting down must not replace the running drain with a no-op that
            // would let disposal proceed underneath it. The composite is rebuilt each call so that
            // storage partitions created by the later signal are included, so this asserts that the
            // new composite still tracks the running work rather than that it is the same instance.
            transmitter.DrainStorage(0);
            var second = transmitter.InFlightDrain;
            Assert.NotNull(second);
            Assert.False(second!.IsCompleted);

            gate.Set();
            started.Wait(TimeSpan.FromSeconds(10));
            second.Wait(TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void StandardMetricsProcessorReleasesTheTransmitterWhenItsMeterProviderIsNeverBuilt()
        {
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}",
                StorageDirectory = _storageRoot,
                Transport = new MockTransport(_ => new MockResponse(200).SetContent("Ok")),
                EnableStandardMetrics = false,
                EnablePerformanceCounters = false,
                EnableStatsbeat = false,
            };

            var transmitter = new AzureMonitorTransmitter(options, new MockPlatform());
            TransmitterFactory.Instance.Set(options.ConnectionString, transmitter);

            // The exporter is built eagerly and only reaches a meter provider if one is ever
            // created, which for a process that records no spans never happens.
            var processor = new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(options), options);
            Assert.False(transmitter._disposed);

            processor.Dispose();

            // A retained reference would leave the storage timers running past provider disposal.
            Assert.True(transmitter._disposed);
        }

        [Fact]
        public void LeasePeriodOutlastsASingleDrainRequest()
        {
            // A lease that can expire while its blob is still uploading lets another process reclaim
            // and resend it, turning rare kill-window duplicates into routine ones.
            Assert.True(
                TransmitFromStorageHandler.LeasePeriodMilliseconds > TransmitFromStorageHandler.DrainPostBudgetMilliseconds * 2,
                $"Lease {TransmitFromStorageHandler.LeasePeriodMilliseconds} ms leaves too little margin over a {TransmitFromStorageHandler.DrainPostBudgetMilliseconds} ms request.");
        }

        [Fact]
        public void FactoryReplacesATransmitterWhoseLastReferenceWasReleased()
        {
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}",
                StorageDirectory = _storageRoot,
                Transport = new MockTransport(_ => new MockResponse(200).SetContent("Ok")),
                EnableStatsbeat = false,
            };

            var platform = new MockPlatform();

            var first = (AzureMonitorTransmitter)TransmitterFactory.Instance.Get(options, platform);
            first.Dispose();
            Assert.True(first._disposed);

            // A provider recreated in the same process must not be handed the torn-down instance,
            // whose storage handler and timers are already gone.
            var second = (AzureMonitorTransmitter)TransmitterFactory.Instance.Get(options, platform);

            Assert.NotSame(first, second);
            Assert.False(second._disposed);

            second.Dispose();
        }

        [Fact]
        public void StatsbeatCannotStallProcessExit()
        {
            // Statsbeat has its own connection string, so it gets its own transmitter and this
            // timeout reaches it. The pipeline default of 100 seconds would let an unreachable
            // endpoint stall the final export it does as it is disposed.
            var statsbeat = AzureMonitorStatsbeat.CreateExporterOptions($"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}");

            Assert.Equal(PersistOnShutdownConfig.InternalTelemetryNetworkTimeout, statsbeat.Retry.NetworkTimeout);
            Assert.True(PersistOnShutdownConfig.InternalTelemetryNetworkTimeout < TimeSpan.FromSeconds(30));
        }

        [Fact]
        public void CustomerSdkStatsLeaveTheCustomersNetworkTimeoutAlone()
        {
            // These stats reuse the customer's connection string, and transmitters are cached per
            // connection string, so a timeout set here would either be discarded or - if this ran
            // first - impose five seconds on the customer's own telemetry.
            var original = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}",
            };

            var customerStats = CustomerSdkStatsRegistration.CreateCustomerSdkStatsOptions(original);

            Assert.Equal(original.Retry.NetworkTimeout, customerStats.Retry.NetworkTimeout);
        }

        [Fact]
        public void DrainBudgetDefaultsToTheGracefulShutdownWindow()
        {
            // Unchanged by default so that a long-running service keeps delivering its final batch
            // within the window Dispose() allows.
            Assert.Equal(PersistOnShutdownConfig.DrainBudgetMilliseconds, PersistOnShutdownConfig.GetDrainBudgetMilliseconds());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(250, 250)]
        [InlineData(30000, 30000)]
        public void DrainBudgetCanBeOverriddenWithAnInteger(int configured, int expected)
        {
            using var scope = new DrainBudgetOverride(configured);

            Assert.Equal(expected, PersistOnShutdownConfig.GetDrainBudgetMilliseconds());

            // Zero is what a short-lived application wants: exit costs the file write and nothing more.
            Assert.Equal(expected == 0 ? 0 : Math.Min(5000, expected), PersistOnShutdownConfig.ResolveDrainWait(5000));
        }

        [Fact]
        public void DrainBudgetCanBeOverriddenWithARuntimeConfigString()
        {
            // runtimeconfig.json configProperties arrive as strings.
            using var scope = new DrainBudgetOverride("0");

            Assert.Equal(0, PersistOnShutdownConfig.GetDrainBudgetMilliseconds());
            Assert.Equal(0, PersistOnShutdownConfig.ResolveDrainWait(5000));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData("not-a-number")]
        [InlineData(null)]
        public void DrainBudgetIgnoresUnusableOverrides(object? configured)
        {
            using var scope = new DrainBudgetOverride(configured);

            Assert.Equal(PersistOnShutdownConfig.DrainBudgetMilliseconds, PersistOnShutdownConfig.GetDrainBudgetMilliseconds());
        }

        private sealed class DrainBudgetOverride : IDisposable
        {
            internal DrainBudgetOverride(object? value)
                => AppDomain.CurrentDomain.SetData(PersistOnShutdownConfig.DrainBudgetOverrideName, value);

            public void Dispose()
                => AppDomain.CurrentDomain.SetData(PersistOnShutdownConfig.DrainBudgetOverrideName, null);
        }

        [Theory]
        [InlineData(Timeout.Infinite, 0)]
        [InlineData(-5, 0)]
        [InlineData(0, 0)]
        [InlineData(500, 500)]
        [InlineData(int.MaxValue, PersistOnShutdownConfig.DrainBudgetMilliseconds)]
        public void ResolveDrainWaitNeverBlocksIndefinitely(int remainingMilliseconds, int expected)
        {
            // Dispose() passes Timeout.Infinite, so treating it as "wait forever" would reintroduce
            // the unbounded shutdown this design exists to remove.
            Assert.Equal(expected, PersistOnShutdownConfig.ResolveDrainWait(remainingMilliseconds));
        }

        [Fact]
        public void FallbackPostBudgetIsIndependentOfTheDrainBudget()
        {
            // The fallback transmission is the only path where the request itself is the
            // durability, so it must never inherit a zero budget.
            Assert.True(PersistOnShutdownConfig.FallbackPostBudgetMilliseconds > 0);
            Assert.Equal(0, PersistOnShutdownConfig.ResolveDrainWait(Timeout.Infinite));
        }

        [Fact]
        public void SaveDoesNotEvictWhenTheStorageDirectoryIsUnknown()
        {
            var blob = new StubBlob(canDelete: true);
            var provider = new StubBlobProvider(new[] { blob });

            Assert.Equal(ExportResult.Failure, provider.SaveTelemetryWithEviction(new byte[8], storageDirectory: null, maxSizeInBytes: 1));

            Assert.False(blob.DeleteAttempted);
            Assert.Equal(1, provider.SaveAttempts);
        }

        [Fact]
        public void SaveDoesNotEvictWhenCapacityCannotBeDetermined()
        {
            var blob = new StubBlob(canDelete: true);
            var provider = new StubBlobProvider(new[] { blob });

            // Enumerating a directory that is not there throws, and capacity that cannot be proven
            // must not license deleting the backlog.
            var missing = Path.Combine(_storageRoot, "missing");

            Assert.Equal(ExportResult.Failure, provider.SaveTelemetryWithEviction(new byte[8], missing, maxSizeInBytes: 1));

            Assert.False(blob.DeleteAttempted);
            Assert.Equal(1, provider.SaveAttempts);
        }

        [Fact]
        public void SaveStopsEvictingWhenBlobsCannotBeDeleted()
        {
            var blobs = Enumerable.Range(0, 3).Select(_ => new StubBlob(canDelete: false)).ToArray();
            var provider = new StubBlobProvider(blobs);
            var directory = CreateDirectoryAtCapacity("undeletable", 64);

            Assert.Equal(ExportResult.Failure, provider.SaveTelemetryWithEviction(new byte[8], directory, maxSizeInBytes: 64));

            Assert.All(blobs, blob => Assert.True(blob.DeleteAttempted));

            // A blob that refused to delete freed nothing, so there is no point retrying the save.
            Assert.Equal(1, provider.SaveAttempts);
        }

        [Fact]
        public void SaveEvictsNoMoreThanTheBlobLimit()
        {
            var blobs = Enumerable.Range(0, 40).Select(_ => new StubBlob(canDelete: true)).ToArray();
            var provider = new StubBlobProvider(blobs);
            var directory = CreateDirectoryAtCapacity("overfull", 64);

            Assert.Equal(ExportResult.Failure, provider.SaveTelemetryWithEviction(new byte[8], directory, maxSizeInBytes: 64));

            // Storage that can never accept a write must not turn into an unbounded delete loop:
            // 32 evictions, each followed by a retry, plus the initial save.
            Assert.Equal(32, blobs.Count(blob => blob.DeleteAttempted));
            Assert.Equal(33, provider.SaveAttempts);
        }

        [Fact]
        public void DrainSkipsBlobsItCannotLease()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport);

            var blob = new StubBlob(canLease: false, data: SerializedTelemetry());
            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => new PersistentBlob[] { blob });

            handler.Drain();

            // The lease belongs to another pass, and taking it would duplicate the telemetry.
            Assert.Empty(transport.Requests);
            Assert.False(blob.DeleteAttempted);
        }

        [Fact]
        public void DrainKeepsBlobsItCannotRead()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport);

            var blob = new StubBlob(canRead: false, data: SerializedTelemetry());
            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => new PersistentBlob[] { blob });

            handler.Drain();

            // A read can fail transiently, so the blob is left for a later pass rather than deleted.
            Assert.Empty(transport.Requests);
            Assert.False(blob.DeleteAttempted);
        }

        [Fact]
        public void DrainDiscardsBlobsWithNothingToSend()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out var transport);

            var empty = new StubBlob(data: Array.Empty<byte>());
            var blankLines = new StubBlob(data: Encoding.UTF8.GetBytes("\n\r\n"));
            var real = new StubBlob(data: SerializedTelemetry());

            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => new PersistentBlob[] { empty, blankLines, real });

            handler.Drain();

            Assert.True(empty.DeleteAttempted);

            // Newlines alone would become a blank record that ingestion rejects, so they contribute
            // nothing to the coalesced payload.
            Assert.Single(transport.Requests);
        }

        [Fact]
        public void DrainIgnoresAPassThatIsAlreadyRunning()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out _);

            var handler = transmitter._transmitFromStorageHandler!;
            var passes = 0;

            handler._blobProvider = new ScriptedBlobProvider(() =>
            {
                passes++;

                // Stands in for the maintenance timer firing while a shutdown drain is mid-flight.
                // Without the in-progress guard this recurses until the stack gives out.
                handler.Drain();

                return Array.Empty<PersistentBlob>();
            });

            handler.Drain();

            Assert.Equal(1, passes);
        }

        [Fact]
        public void DrainSurvivesStorageTornDownMidPass()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out _);

            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => FailsPartWayThrough(new ObjectDisposedException("storage")));

            // Teardown racing a drain is expected, and the blobs are still on disk.
            handler.Drain();
        }

        [Fact]
        public void DrainSurvivesAnUnexpectedStorageFailure()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out _);

            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => FailsPartWayThrough(new InvalidOperationException("storage is unwell")));

            // A drain runs on a background thread; letting it throw would take the process down.
            handler.Drain();
        }

        [Fact]
        public void DrainSplitsABacklogThatExceedsTheBlobsPerBatchLimit()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out var transport);

            var telemetry = SerializedTelemetry();
            var blobs = Enumerable.Range(0, 51).Select(_ => (PersistentBlob)new StubBlob(data: telemetry)).ToArray();

            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => blobs);

            handler.Drain();

            // 50 blobs to a request, so one past the limit has to become a second request.
            Assert.Equal(2, transport.Requests.Count);
        }

        [Fact]
        public void DrainSplitsABacklogThatExceedsTheBatchSizeLimit()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out var transport);

            // Two blobs fit under the 50 per batch limit, so only the 2 MB payload ceiling can
            // split them.
            var oversized = Encoding.UTF8.GetBytes(new string('a', 1536 * 1024));
            var blobs = Enumerable.Range(0, 2).Select(_ => (PersistentBlob)new StubBlob(data: oversized)).ToArray();

            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => blobs);

            handler.Drain();

            Assert.Equal(2, transport.Requests.Count);
        }

        [Fact]
        public void DrainReportsBlobsItCannotDelete()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out var transport);

            var blob = new StubBlob(canDelete: false, data: SerializedTelemetry());
            var handler = transmitter._transmitFromStorageHandler!;
            handler._blobProvider = new ScriptedBlobProvider(() => new PersistentBlob[] { blob });

            handler.Drain();

            // The upload succeeded but the blob survived, so a later pass will send it again.
            Assert.Single(transport.Requests);
            Assert.True(blob.DeleteAttempted);
        }

        [Fact]
        public void DrainIgnoresLockFilesItCannotInterpret()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out _);

            SeedBlobs(transmitter, count: 1);

            var directory = Path.GetDirectoryName(Directory.GetFiles(_storageRoot, "*.blob", SearchOption.AllDirectories).Single())!;
            var foreign = Path.Combine(directory, "unrelated.lock");
            File.WriteAllText(foreign, "not a lease");

            transmitter._transmitFromStorageHandler!.Drain();

            // Nothing this exporter wrote, so there is no expiry in the name to act on.
            Assert.True(File.Exists(foreign));
        }

        [Fact]
        public void DrainLeavesALeaseItCannotReclaim()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out _);

            SeedBlobs(transmitter, count: 1);

            // Reclaiming renames the lease back to the blob name, which cannot succeed while a blob
            // of that name is already there: the collision two processes racing a reclaim would hit.
            var blobFile = Directory.GetFiles(_storageRoot, "*.blob", SearchOption.AllDirectories).Single();
            var expiredLease = $"{blobFile}@{DateTime.UtcNow.AddMinutes(-5):yyyy-MM-ddTHHmmss.fffffffZ}.lock";
            File.Copy(blobFile, expiredLease);

            transmitter._transmitFromStorageHandler!.Drain();

            Assert.True(File.Exists(expiredLease));
        }

        [Fact]
        public void DrainSkipsLeaseReclamationWhenStorageIsGone()
        {
            using var transmitter = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out var transport);

            SeedBlobs(transmitter, count: 1);

            // Storage can be removed underneath a running process.
            Directory.Delete(_storageRoot, recursive: true);

            transmitter._transmitFromStorageHandler!.Drain();

            Assert.Empty(transport.Requests);
        }

        /// <summary>
        /// Yields a blob and then throws, standing in for storage that goes away while a drain is
        /// walking it. Throwing from the provider itself would be swallowed by the storage
        /// abstraction and never reach the drain.
        /// </summary>
        private static IEnumerable<PersistentBlob> FailsPartWayThrough(Exception error)
        {
            yield return new StubBlob(data: SerializedTelemetry());

            throw error;
        }

        [Fact]
        public void EagerDrainUploadsTelemetryLeftByAPreviousRun()
        {
            using (var previousRun = CreateTransmitter(_ => new MockResponse(200).SetContent("Ok"), out _))
            {
                SeedBlobs(previousRun, count: 1);
            }

            TransmitFromStorageHandler.DisableEagerDrainForTesting = false;

            try
            {
                // A short-lived process exits long before the maintenance timer, so the backlog has
                // to be picked up near startup instead.
                using var currentRun = CreateTransmitter(_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}"), out var transport);

                var deadline = Stopwatch.StartNew();
                while (transport.Requests.Count == 0 && deadline.Elapsed < TimeSpan.FromSeconds(10))
                {
                    Thread.Sleep(25);
                }

                Assert.Single(transport.Requests);
            }
            finally
            {
                TransmitFromStorageHandler.DisableEagerDrainForTesting = true;
            }
        }

        private static byte[] SerializedTelemetry() => HttpPipelineHelper.GetSerializedContent(CreateTelemetryItems());

        private string CreateDirectoryAtCapacity(string name, int sizeInBytes)
        {
            var directory = Path.Combine(_storageRoot, name);
            Directory.CreateDirectory(directory);
            File.WriteAllBytes(Path.Combine(directory, "occupied.blob"), new byte[sizeInBytes]);

            return directory;
        }

        /// <summary>
        /// Always refuses the save, so every call reaches the eviction path.
        /// </summary>
        private sealed class StubBlobProvider : PersistentBlobProvider
        {
            private readonly List<PersistentBlob> _blobs;

            public StubBlobProvider(IEnumerable<PersistentBlob> blobs) => _blobs = new List<PersistentBlob>(blobs);

            public int SaveAttempts { get; private set; }

            protected override IEnumerable<PersistentBlob> OnGetBlobs() => _blobs;

            protected override bool OnTryCreateBlob(byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob blob)
                => RefuseSave(out blob);

            protected override bool OnTryCreateBlob(byte[] buffer, out PersistentBlob blob) => RefuseSave(out blob);

            protected override bool OnTryGetBlob(out PersistentBlob blob)
            {
                blob = null!;
                return false;
            }

            private bool RefuseSave(out PersistentBlob blob)
            {
                SaveAttempts++;
                blob = null!;
                return false;
            }
        }

        private sealed class StubBlob : PersistentBlob
        {
            private readonly bool _canDelete;
            private readonly bool _canLease;
            private readonly bool _canRead;
            private readonly byte[] _data;

            public StubBlob(bool canDelete = true, bool canLease = true, bool canRead = true, byte[]? data = null)
            {
                _canDelete = canDelete;
                _canLease = canLease;
                _canRead = canRead;
                _data = data ?? Array.Empty<byte>();
            }

            public bool DeleteAttempted { get; private set; }

            protected override bool OnTryRead(out byte[] buffer)
            {
                buffer = _data;
                return _canRead;
            }

            protected override bool OnTryWrite(byte[] buffer, int leasePeriodMilliseconds = 0) => true;

            protected override bool OnTryLease(int leasePeriodMilliseconds) => _canLease;

            protected override bool OnTryDelete()
            {
                DeleteAttempted = true;
                return _canDelete;
            }
        }

        /// <summary>
        /// Supplies whatever blobs a drain test needs, including throwing instead of yielding any.
        /// </summary>
        private sealed class ScriptedBlobProvider : PersistentBlobProvider
        {
            private readonly Func<IEnumerable<PersistentBlob>> _getBlobs;

            public ScriptedBlobProvider(Func<IEnumerable<PersistentBlob>> getBlobs) => _getBlobs = getBlobs;

            protected override IEnumerable<PersistentBlob> OnGetBlobs() => _getBlobs();

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
        }

        private int CountFiles(string pattern)
            => Directory.GetFiles(_storageRoot, pattern, SearchOption.AllDirectories).Length;

        private static void SeedBlobs(AzureMonitorTransmitter transmitter, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var content = HttpPipelineHelper.GetSerializedContent(CreateTelemetryItems());
                Assert.Equal(ExportResult.Success, transmitter._fileBlobProvider!.SaveTelemetry(content));
            }
        }

        private static void Track(AzureMonitorTransmitter transmitter)
            => transmitter.TrackAsync(CreateTelemetryItems(), new TelemetrySchemaTypeCounter(), TelemetryItemOrigin.UnitTest, false, CancellationToken.None).EnsureCompleted();

        private static List<TelemetryItem> CreateTelemetryItems()
        {
            using var activitySource = new ActivitySource("OTel.PersistOnShutdown");
            using var activity = activitySource.StartActivity("TestActivity", ActivityKind.Client, parentContext: default, startTime: DateTime.UtcNow);
            Assert.NotNull(activity);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity!);
            return new List<TelemetryItem> { new TelemetryItem(activity!, ref activityTagsProcessor, null, string.Empty, 1.0f) };
        }

        private AzureMonitorTransmitter CreateTransmitter(Func<MockRequest, MockResponse> responseFactory, out MockTransport transport, bool disableOfflineStorage = false)
        {
            transport = new MockTransport(responseFactory);

            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={TestIkey};IngestionEndpoint={TestEndpoint}",
                StorageDirectory = _storageRoot,
                DisableOfflineStorage = disableOfflineStorage,
                Transport = transport,
                EnableStatsbeat = false,
            };

            return new AzureMonitorTransmitter(options, new MockPlatform());
        }
    }
}
