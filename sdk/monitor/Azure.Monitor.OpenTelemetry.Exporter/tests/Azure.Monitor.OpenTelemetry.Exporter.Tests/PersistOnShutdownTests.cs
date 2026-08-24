// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using OpenTelemetry.PersistentStorage.FileSystem;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
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
            // would let disposal proceed underneath it.
            transmitter.DrainStorage(0);
            Assert.Same(started, transmitter.InFlightDrain);

            gate.Set();
            started.Wait(TimeSpan.FromSeconds(10));
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
        public void InternalTelemetryExportersCannotStallProcessExit()
        {
            // Both meter providers export once more as they are disposed, which happens on the exit
            // path. The pipeline default of 100 seconds would let an unreachable endpoint stall it.
            var statsbeat = AzureMonitorStatsbeat.CreateExporterOptions($"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}");
            var customerStats = CustomerSdkStatsRegistration.CreateCustomerSdkStatsOptions(new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}",
            });

            Assert.Equal(PersistOnShutdownConfig.InternalTelemetryNetworkTimeout, statsbeat.Retry.NetworkTimeout);
            Assert.Equal(PersistOnShutdownConfig.InternalTelemetryNetworkTimeout, customerStats.Retry.NetworkTimeout);
            Assert.True(PersistOnShutdownConfig.InternalTelemetryNetworkTimeout < TimeSpan.FromSeconds(30));
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
