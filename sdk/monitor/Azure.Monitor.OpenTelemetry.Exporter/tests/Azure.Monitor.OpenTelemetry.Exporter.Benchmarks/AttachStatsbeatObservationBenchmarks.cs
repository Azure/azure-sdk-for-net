// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using BenchmarkDotNet.Attributes;

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class AttachStatsbeatObservationBenchmarks
    {
        private const int BatchSize = 512;
        private const int ExporterCount = 3;
        private const int ConcurrentBatches = 192;
        private MultiEndpointStatsbeat _stats = null!;
        private EndpointRouteBatch[] _batches = null!;

        [Params(1, 3)]
        public int EndpointCount { get; set; }

        [Params(1, BatchSize)]
        public int CustomerCount { get; set; }

        [Params(false, true)]
        public bool DistinctKeyInstances { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            string[] endpoints =
            {
                "https://eastus-1.in.applicationinsights.azure.com/",
                "https://westeurope-5.in.applicationinsights.azure.com/",
                "https://westus-0.in.applicationinsights.azure.com/"
            };
            var keys = new string[CustomerCount];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = "key-" + i;
            }

            // Each exporter owns its batch, just as it does on the export path.
            _batches = new EndpointRouteBatch[ExporterCount];
            for (int exporter = 0; exporter < ExporterCount; exporter++)
            {
                var batch = _batches[exporter] = new EndpointRouteBatch();
                for (int i = 0; i < BatchSize; i++)
                {
                    var key = keys[i % CustomerCount];
                    batch.GetOrAdd(endpoints[i % EndpointCount]).TelemetryItems.Add(
                        new TelemetryItem(DateTime.UtcNow, resource: null,
                            DistinctKeyInstances ? new string(key.ToCharArray()) : key));
                }
            }

            // Observe can run before configuration completes; no transmitters or network are needed.
            _stats = new MultiEndpointStatsbeat(
                null, endpoints[0], null, TimeSpan.FromHours(24), _ => new Measurement<int>(1));
            foreach (var batch in _batches)
            {
                _stats.Observe(batch, 1);
            }
            _stats.Registry.Collect(1, long.MaxValue);
            _stats.Registry.CompleteCollection();
        }

        [Benchmark]
        public void Observe() => _stats.Observe(_batches[0], 1);

        [Benchmark(OperationsPerInvoke = ConcurrentBatches)]
        public void ObserveConcurrent() => Parallel.For(0, ExporterCount, ObserveExporter);

        [Benchmark(OperationsPerInvoke = ConcurrentBatches)]
        public void ObserveDuringCollection()
        {
            Parallel.For(0, ExporterCount + 1, worker =>
            {
                if (worker < ExporterCount)
                {
                    ObserveExporter(worker);
                    return;
                }

                // Deliberately collect frequently to exercise contention, not the production cadence.
                for (int i = 0; i < ConcurrentBatches / ExporterCount; i++)
                {
                    _stats.Registry.Collect(1, long.MaxValue);
                    _stats.Registry.CompleteCollection();
                }
            });
        }

        private void ObserveExporter(int exporter)
        {
            for (int i = 0; i < ConcurrentBatches / ExporterCount; i++)
            {
                _stats.Observe(_batches[exporter], 1);
            }
        }

        [GlobalCleanup]
        public void Cleanup() => _stats.Dispose();
    }
}
