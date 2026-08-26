// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;

using Azure.Core.TestFramework;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
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

        /// <summary>
        /// Stands in for an endpoint that will not answer. Held on a thread pool thread, so it is
        /// kept only long enough to outlast the drain budget rather than tying a thread up for the
        /// tests that follow.
        /// </summary>
        private static readonly TimeSpan UnresponsiveIngestion = TimeSpan.FromSeconds(5);

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
            // Shutdown starts the drain without waiting for it, so tests asserting on what was
            // persisted would otherwise race it. Tests that are about the drain turn this back on.
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = true;

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
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = false;

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
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = false;

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
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = false;

            var tracerProvider = BuildTracerProvider(
                out _,
                out _,
                _ =>
                {
                    // Stands in for an unreachable or wedged ingestion endpoint.
                    System.Threading.Thread.Sleep(UnresponsiveIngestion);
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

        [Fact]
        public void DisposeDoesNotWaitWhenTheDrainBudgetIsZero()
        {
            // The drain has to actually run, or this would pass no matter what the budget resolved to.
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = false;
            SetDrainBudgetOverride(0);

            try
            {
                var tracerProvider = BuildTracerProvider(
                    out _,
                    out _,
                    _ =>
                    {
                        System.Threading.Thread.Sleep(UnresponsiveIngestion);
                        return new MockResponse(200);
                    });

                EmitActivity();

                var stopwatch = Stopwatch.StartNew();
                tracerProvider.Dispose();
                stopwatch.Stop();

                // What a short-lived application configures: Dispose passes a finite timeout, and a
                // zero budget stops that window being spent waiting on the drain.
                Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(1), $"Dispose took {stopwatch.Elapsed}.");
                Assert.Equal(1, CountStoredPayloads());
            }
            finally
            {
                SetDrainBudgetOverride(null);
            }
        }

        [Fact]
        public void LogShutdownPersistsPendingTelemetryWithoutTransmitting()
        {
            var options = BuildOptions(out _, out var transport);

            using var serviceProvider = BuildLoggerServices(options);

            serviceProvider.GetRequiredService<ILoggerFactory>()
                .CreateLogger<PersistOnShutdownProviderTests>()
                .LogInformation("Persist me.");

            // Logs run through a separate processor from traces, so the trace tests say nothing
            // about this path.
            serviceProvider.GetRequiredService<LoggerProvider>().Shutdown();

            Assert.Empty(transport.Requests);
            Assert.Equal(1, CountStoredPayloads());
        }

        [Fact]
        public void LogForceFlushPersistsWhenSwitchIsEnabled()
        {
            AppContext.SetSwitch(PersistOnShutdownConfig.PersistOnForceFlushSwitchName, true);

            try
            {
                var options = BuildOptions(out _, out var transport);

                using var serviceProvider = BuildLoggerServices(options);

                serviceProvider.GetRequiredService<ILoggerFactory>()
                    .CreateLogger<PersistOnShutdownProviderTests>()
                    .LogInformation("Persist me.");

                serviceProvider.GetRequiredService<LoggerProvider>().ForceFlush();

                Assert.Empty(transport.Requests);
                Assert.Equal(1, CountStoredPayloads());
            }
            finally
            {
                AppContext.SetSwitch(PersistOnShutdownConfig.PersistOnForceFlushSwitchName, false);
            }
        }

        [Fact]
        public void MetricShutdownPersistsPendingTelemetryWithoutTransmitting()
        {
            var options = BuildOptions(out var transmitter, out var transport);

            var meterName = $"OTel.PersistProvider.{Guid.NewGuid():N}";
            using var meter = new Meter(meterName);

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddReader(new AzureMonitorPeriodicExportingMetricReader(new AzureMonitorMetricExporter(options)))
                .Build()!;

            meter.CreateCounter<long>("TestCounter").Add(1);

            meterProvider.Shutdown();

            Assert.Empty(transport.Requests);
            Assert.Equal(1, CountStoredPayloads());
        }

        [Fact]
        public void LogForceFlushTransmitsByDefault()
        {
            var options = BuildOptions(out var transmitter, out var transport);

            using var serviceProvider = BuildLoggerServices(options);

            serviceProvider.GetRequiredService<ILoggerFactory>()
                .CreateLogger<PersistOnShutdownProviderTests>()
                .LogInformation("Deliver me.");

            serviceProvider.GetRequiredService<LoggerProvider>().ForceFlush();

            Assert.Single(transport.Requests);
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void LogShutdownTransmitsWhenPersistenceIsDisabled()
        {
            AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, true);

            try
            {
                var options = BuildOptions(out var transmitter, out var transport);

                using var serviceProvider = BuildLoggerServices(options);

                serviceProvider.GetRequiredService<ILoggerFactory>()
                    .CreateLogger<PersistOnShutdownProviderTests>()
                    .LogInformation("Deliver me.");

                serviceProvider.GetRequiredService<LoggerProvider>().Shutdown();

                Assert.Single(transport.Requests);
                Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
            }
            finally
            {
                AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, false);
            }
        }

        [Fact]
        public void MetricShutdownTransmitsWhenPersistenceIsDisabled()
        {
            AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, true);

            try
            {
                var options = BuildOptions(out var transmitter, out var transport);

                var meterName = $"OTel.PersistProvider.{Guid.NewGuid():N}";
                using var meter = new Meter(meterName);

                using var meterProvider = Sdk.CreateMeterProviderBuilder()
                    .AddMeter(meterName)
                    .AddReader(new AzureMonitorPeriodicExportingMetricReader(new AzureMonitorMetricExporter(options)))
                    .Build()!;

                meter.CreateCounter<long>("TestCounter").Add(1);

                meterProvider.Shutdown();

                Assert.Single(transport.Requests);
                Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
            }
            finally
            {
                AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, false);
            }
        }

        [Fact]
        public void MetricDisposeDrainsPersistedTelemetryWithinTheBudget()
        {
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = false;

            var options = BuildOptions(out var transmitter, out var transport);

            var meterName = $"OTel.PersistProvider.{Guid.NewGuid():N}";
            using var meter = new Meter(meterName);

            var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddReader(new AzureMonitorPeriodicExportingMetricReader(new AzureMonitorMetricExporter(options)))
                .Build()!;

            meter.CreateCounter<long>("TestCounter").Add(1);

            // Dispose passes a finite 5000 ms rather than Timeout.Infinite, so unlike Shutdown the
            // drain gets a budget: the collection is persisted first and then uploaded from storage.
            meterProvider.Dispose();

            Assert.Single(transport.Requests);
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
        }

        [Fact]
        public void MetricDisposeDoesNotWaitWhenTheDrainBudgetIsZero()
        {
            // The drain has to actually run, or this would pass no matter what the budget resolved to.
            TransmitFromStorageHandler.DisableShutdownDrainForTesting = false;
            SetDrainBudgetOverride(0);

            try
            {
                // An endpoint that never answers keeps the drain from deleting what was persisted,
                // so the count below is not racing it.
                var options = BuildOptions(
                    out _,
                    out _,
                    _ =>
                    {
                        System.Threading.Thread.Sleep(UnresponsiveIngestion);
                        return new MockResponse(200);
                    });

                var meterName = $"OTel.PersistProvider.{Guid.NewGuid():N}";
                using var meter = new Meter(meterName);

                var meterProvider = Sdk.CreateMeterProviderBuilder()
                    .AddMeter(meterName)
                    .AddReader(new AzureMonitorPeriodicExportingMetricReader(new AzureMonitorMetricExporter(options)))
                    .Build()!;

                meter.CreateCounter<long>("TestCounter").Add(1);

                var stopwatch = Stopwatch.StartNew();
                meterProvider.Dispose();
                stopwatch.Stop();

                // The default budget would spend up to two seconds of Dispose's window waiting on a
                // drain that cannot finish.
                Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(1), $"Dispose took {stopwatch.Elapsed}.");
                Assert.Equal(1, CountStoredPayloads());
            }
            finally
            {
                SetDrainBudgetOverride(null);
            }
        }

        [Fact]
        public void MetricForceFlushTransmits()
        {
            var options = BuildOptions(out var transmitter, out var transport);

            var meterName = $"OTel.PersistProvider.{Guid.NewGuid():N}";
            using var meter = new Meter(meterName);

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddReader(new AzureMonitorPeriodicExportingMetricReader(new AzureMonitorMetricExporter(options)))
                .Build()!;

            meter.CreateCounter<long>("TestCounter").Add(1);

            meterProvider.ForceFlush();

            // Pins the documented limitation: MetricReader.OnCollect cannot tell a caller-initiated
            // flush from the periodic collection, so the flush is never redirected to storage.
            Assert.Single(transport.Requests);
            Assert.Empty(transmitter._fileBlobProvider!.GetBlobs());
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

        /// <summary>
        /// .NET Framework has no AppContext.SetData, and AppDomain.SetData is what AppContext reads
        /// from, so this is the portable way to drive the override.
        /// </summary>
        private static void SetDrainBudgetOverride(object? value)
            => AppDomain.CurrentDomain.SetData(PersistOnShutdownConfig.DrainBudgetOverrideName, value);

        private static ServiceProvider BuildLoggerServices(AzureMonitorExporterOptions options)
        {
            var services = new ServiceCollection();

            services.AddLogging(logging => logging.AddOpenTelemetry());
            services.AddOpenTelemetry().WithLogging(builder =>
                builder.AddProcessor(new AzureMonitorBatchLogRecordExportProcessor(new AzureMonitorLogExporter(options))));

            return services.BuildServiceProvider();
        }

        private AzureMonitorExporterOptions BuildOptions(out AzureMonitorTransmitter transmitter, out MockTransport transport, Func<MockRequest, MockResponse>? responseFactory = null)
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

            return options;
        }

        private TracerProvider BuildTracerProvider(out AzureMonitorTransmitter transmitter, out MockTransport transport, Func<MockRequest, MockResponse>? responseFactory = null)
        {
            var options = BuildOptions(out transmitter, out transport, responseFactory);

            return Sdk.CreateTracerProviderBuilder()
                .AddSource(_sourceName)
                .AddProcessor(new AzureMonitorBatchActivityExportProcessor(new AzureMonitorTraceExporter(options)))
                .Build()!;
        }
    }
}
