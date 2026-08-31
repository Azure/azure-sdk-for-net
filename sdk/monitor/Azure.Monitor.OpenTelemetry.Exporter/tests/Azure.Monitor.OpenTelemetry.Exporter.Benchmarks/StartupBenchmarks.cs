// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry;
using OpenTelemetry.Trace;

/*
Measures what a short-lived application pays to start up, which for a CLI is charged on every
invocation. Statsbeat is a parameter because it builds a second MeterProvider.

BenchmarkDotNet, .NET 8.0.30, X64 RyuJIT. RunStrategy=Monitoring, IterationCount=20.

| Method        | EnableStatsbeat | Mean     | Allocated |
|-------------- |---------------- |---------:|----------:|
| BuildProvider | False           | 1.804 ms | 203.77 KB |
| BuildProvider | True            | 3.025 ms | 558.67 KB |

Statsbeat roughly doubles both the time and the allocation, which is worth knowing for a CLI that
pays this on every invocation.
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, iterationCount: 20)]
    public class StartupBenchmarks
    {
        private const string SourceName = "Benchmark.Startup";

        private LocalIngestionServer? _server;
        private string? _storageDirectory;
        private string? _connectionString;
        private TracerProvider? _tracerProvider;

        [Params(false, true)]
        public bool EnableStatsbeat { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            // Each provider would otherwise schedule a drain that outlives the iteration and lands
            // in the middle of a later measurement.
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;

            _storageDirectory = Path.Combine(Path.GetTempPath(), "AzMonStartupBenchmarks", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_storageDirectory);

            _server = new LocalIngestionServer(TimeSpan.Zero);

            // A single connection string, because the transmitter is cached per connection string
            // and a fresh one per iteration would leave a timer and a blob provider behind every
            // time. Disposing the provider releases the last reference, so the next iteration
            // constructs one rather than measuring a cache hit.
            _connectionString = _server.BuildConnectionString();

            // Keeps Statsbeat on the loopback stub instead of reaching a live ingestion endpoint.
            Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_STATS_CONNECTION_STRING", _server.BuildConnectionString());
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_STATS_CONNECTION_STRING", null);
            _server?.Dispose();

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

        [IterationCleanup]
        public void IterationCleanup() => _tracerProvider?.Dispose();

        [Benchmark]
        public void BuildProvider()
        {
            _tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(SourceName)
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = _connectionString;
                    options.StorageDirectory = _storageDirectory;
                    options.EnableLiveMetrics = false;
                    options.EnableStandardMetrics = false;
                    options.EnablePerformanceCounters = false;
                    options.EnableStatsbeat = EnableStatsbeat;
                })
                .Build();
        }
    }
}
