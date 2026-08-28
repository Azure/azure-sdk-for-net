// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Azure.Core.TestFramework;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Exercises the real provider pipeline rather than the transmitter in isolation, because the
    /// persist-only scope has to be opened by the processor: BaseExportProcessor exports the
    /// remaining batch before it shuts the exporter down.
    /// </summary>
    [Collection(nameof(PersistOnShutdownSwitchCollection))]
    public class PersistOnShutdownProviderTests : IDisposable
    {
        private const string TestEndpoint = "http://localhost:5050";

        private readonly string _storageRoot;
        private readonly string _sourceName;
        private readonly ActivitySource _activitySource;
        private readonly ActivityListener _listener;

        static PersistOnShutdownProviderTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;
        }

        public PersistOnShutdownProviderTests()
        {
            _storageRoot = Path.Combine(Path.GetTempPath(), "AzMonPersistProviderTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_storageRoot);

            _sourceName = $"OTel.PersistProvider.{Guid.NewGuid():N}";
            _activitySource = new ActivitySource(_sourceName);
            _listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == _sourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            };
            ActivitySource.AddActivityListener(_listener);
        }

        public void Dispose()
        {
            _listener.Dispose();
            _activitySource.Dispose();

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
        public void ShutdownPersistsPendingTelemetryWithoutTransmitting()
        {
            var tracerProvider = BuildTracerProvider(out var transmitter, out var transport);

            EmitActivity();

            tracerProvider.Shutdown();

            // The whole point: process exit costs a file write, not an ingestion round trip.
            Assert.Empty(transport.Requests);
            Assert.Single(transmitter._fileBlobProvider!.GetBlobs());

            tracerProvider.Dispose();
        }

        [Fact]
        public void DisposeDoesNotLoseTelemetryWhenIngestionIsUnavailable()
        {
            var tracerProvider = BuildTracerProvider(out _, out _, _ => new MockResponse(503).SetContent("Service Unavailable"));

            EmitActivity();

            // Dispose calls Shutdown(5000), so unlike Shutdown() the drain does get a budget and a
            // request may be attempted. What matters is that a failed upload leaves the telemetry
            // on disk for the next run rather than dropping it.
            tracerProvider.Dispose();

            Assert.Equal(1, CountStoredPayloads());
        }

        [Fact]
        public void ForceFlushTransmitsByDefault()
        {
            var tracerProvider = BuildTracerProvider(out var transmitter, out var transport);

            EmitActivity();

            tracerProvider.ForceFlush();

            // Callers that flush per invocation expect delivery, not durability.
            Assert.Single(transport.Requests);
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());

            tracerProvider.Dispose();
        }

        [Fact]
        public void ForceFlushPersistsWhenSwitchIsEnabled()
        {
            AppContext.SetSwitch(PersistOnShutdownConfig.PersistOnForceFlushSwitchName, true);

            try
            {
                var tracerProvider = BuildTracerProvider(out var transmitter, out var transport);

                EmitActivity();

                tracerProvider.ForceFlush();

                Assert.Empty(transport.Requests);
                Assert.Single(transmitter._fileBlobProvider!.GetBlobs());

                tracerProvider.Dispose();
            }
            finally
            {
                AppContext.SetSwitch(PersistOnShutdownConfig.PersistOnForceFlushSwitchName, false);
            }
        }

        [Fact]
        public void DisableSwitchRestoresBlockingTransmissionOnShutdown()
        {
            AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, true);

            try
            {
                var tracerProvider = BuildTracerProvider(out var transmitter, out var transport);

                EmitActivity();

                tracerProvider.Shutdown();

                Assert.Single(transport.Requests);
                Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());

                tracerProvider.Dispose();
            }
            finally
            {
                AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, false);
            }
        }

        [Fact]
        public void ShutdownDoesNotBlockOnAHangingEndpoint()
        {
            var tracerProvider = BuildTracerProvider(
                out _,
                out _,
                _ =>
                {
                    // Stands in for an unreachable or wedged ingestion endpoint.
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
                    return new MockResponse(200);
                });

            EmitActivity();

            var stopwatch = Stopwatch.StartNew();
            tracerProvider.Dispose();
            stopwatch.Stop();

            // Previously this inherited the pipeline's 100 second network timeout.
            Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(15), $"Shutdown took {stopwatch.Elapsed}.");
            Assert.Equal(1, CountStoredPayloads());
        }

        /// <summary>
        /// Counts telemetry still on disk. A drain that failed or was cut short leaves the blob
        /// leased rather than deleted, and a leased blob is renamed to ".lock".
        /// </summary>
        private int CountStoredPayloads()
            => Directory.GetFiles(_storageRoot, "*.blob", SearchOption.AllDirectories).Length
                + Directory.GetFiles(_storageRoot, "*.lock", SearchOption.AllDirectories).Length;

        private void EmitActivity()
        {
            using var activity = _activitySource.StartActivity("TestActivity", ActivityKind.Client);
            Assert.NotNull(activity);
        }

        private TracerProvider BuildTracerProvider(out AzureMonitorTransmitter transmitter, out MockTransport transport, Func<MockRequest, MockResponse>? responseFactory = null)
        {
            var connectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={TestEndpoint}";

            transport = new MockTransport(responseFactory ?? (_ => new MockResponse(200).SetContent("{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}")));

            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = connectionString,
                StorageDirectory = _storageRoot,
                Transport = transport,
                EnableStatsbeat = false,
            };

            // The exporter resolves its transmitter from the factory cache, so seeding the cache is
            // what lets this test supply a mock platform and a scratch storage directory.
            transmitter = new AzureMonitorTransmitter(options, new MockPlatform());
            TransmitterFactory.Instance.Set(connectionString, transmitter);

            return Sdk.CreateTracerProviderBuilder()
                .AddSource(_sourceName)
                .AddProcessor(new AzureMonitorBatchActivityExportProcessor(new AzureMonitorTraceExporter(options)))
                .Build()!;
        }
    }
}
