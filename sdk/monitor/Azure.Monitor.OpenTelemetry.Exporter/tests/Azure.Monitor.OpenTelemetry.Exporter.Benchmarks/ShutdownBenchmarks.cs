// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

using OpenTelemetry;
using OpenTelemetry.Trace;

/*
Measures what a short-lived application pays to shut down.

BenchmarkDotNet, .NET 8.0.30, X64 RyuJIT. RunStrategy=Monitoring, IterationCount=10.
DrainBudgetOverride of -1 means the default budget is left in place.

| Method          | BlockingShutdown | DrainBudgetOverride | IngestionDelayMs | Mean         | Allocated |
|---------------- |----------------- |-------------------- |----------------- |-------------:|----------:|
| DisposeProvider | False            | -1                  | 0                |     6.918 ms | 149.82 KB |
| DisposeProvider | False            | -1                  | 2000             | 2,011.802 ms | 148.02 KB |
| DisposeProvider | False            | 0                   | 0                |     2.614 ms |  36.88 KB |
| DisposeProvider | False            | 0                   | 2000             |     2.729 ms |  36.88 KB |
| DisposeProvider | True             | -1                  | 0                |     1.659 ms |  98.02 KB |
| DisposeProvider | True             | -1                  | 2000             | 2,010.282 ms |  98.23 KB |
| DisposeProvider | True             | 0                   | 0                |     1.719 ms |  97.58 KB |
| DisposeProvider | True             | 0                   | 2000             | 2,007.451 ms |  97.29 KB |

Dispose() passes a finite timeout, so by default the wait rule grants the background drain up to
DrainBudgetMilliseconds and blocks on it, and exit then tracks ingestion latency. Setting the budget
to zero makes exit cost the file write and nothing more, at 2.7 ms whatever ingestion is doing,
which is what a short-lived application wants. The default is retained so that a long-running
service keeps delivering its final batch within the window Dispose() allows.

The budget has no effect on the blocking path, which has no drain to wait for.
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, iterationCount: 10)]
    public class ShutdownBenchmarks
    {
        private const string SourceName = "Benchmark.Shutdown";
        private const int SpanCount = 10;

        private static readonly ActivitySource s_activitySource = new(SourceName);

        private LocalIngestionServer? _server;
        private string? _storageDirectory;
        private string? _connectionString;
        private TracerProvider? _tracerProvider;

        /// <summary>
        /// Selects the legacy behaviour, where shutdown transmits and waits for the response.
        /// </summary>
        [Params(false, true)]
        public bool BlockingShutdown { get; set; }

        /// <summary>
        /// -1 leaves the default budget in place; 0 is what a short-lived application would set.
        /// </summary>
        [Params(-1, 0)]
        public int DrainBudgetOverride { get; set; }

        [Params(0, 2000)]
        public int IngestionResponseDelayMilliseconds { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            ActivitySource.AddActivityListener(new ActivityListener
            {
                ShouldListenTo = source => source.Name == SourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            });

            // The eager drain would otherwise upload blobs left by earlier iterations while the next
            // one is being measured.
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;

            _storageDirectory = Path.Combine(Path.GetTempPath(), "AzMonShutdownBenchmarks", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_storageDirectory);

            _server = new LocalIngestionServer(TimeSpan.FromMilliseconds(IngestionResponseDelayMilliseconds));
            _connectionString = _server.BuildConnectionString();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _server?.Dispose();
            AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, false);
            SetDrainBudgetOverride(null);
            TryDeleteStorage();
        }

        /// <summary>
        /// .NET Framework has no AppContext.SetData, and AppContext reads from the AppDomain data
        /// store, so this is the portable way to drive the override.
        /// </summary>
        private static void SetDrainBudgetOverride(object? value)
            => AppDomain.CurrentDomain.SetData(PersistOnShutdownConfig.DrainBudgetOverrideName, value);

        [IterationSetup]
        public void IterationSetup()
        {
            AppContext.SetSwitch(PersistOnShutdownConfig.DisablePersistOnShutdownSwitchName, BlockingShutdown);
            SetDrainBudgetOverride(DrainBudgetOverride < 0 ? null : (object)DrainBudgetOverride);

            _tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(SourceName)
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = _connectionString;
                    options.StorageDirectory = _storageDirectory;
                    options.EnableLiveMetrics = false;
                    options.EnableStandardMetrics = false;
                    options.EnablePerformanceCounters = false;
                    options.EnableStatsbeat = false;
                })
                .Build();

            for (int i = 0; i < SpanCount; i++)
            {
                using var activity = s_activitySource.StartActivity("Work");
            }
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            _tracerProvider?.Dispose();

            // Blobs persisted by the iteration just measured must not be drained by the next one.
            TryDeleteStorage();
            Directory.CreateDirectory(_storageDirectory!);
        }

        /// <summary>
        /// What an application actually does. Dispose passes a 5 second timeout, so the drain is
        /// granted a budget.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void DisposeProvider() => _tracerProvider!.Dispose();

        /// <summary>
        /// Shutdown defaults to <see cref="System.Threading.Timeout.Infinite"/>, which the wait rule
        /// maps to "do not wait". Isolates the persist cost from the drain wait.
        /// </summary>
        [Benchmark]
        public void ShutdownProvider() => _tracerProvider!.Shutdown();

        private void TryDeleteStorage()
        {
            try
            {
                Directory.Delete(_storageDirectory!, recursive: true);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
