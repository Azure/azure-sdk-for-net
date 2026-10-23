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
        private const int ConcurrentBatches = 128;
        private MultiEndpointStatsbeat _stats = null!;
        private EndpointRouteBatch _batch = null!;

        [Params(1, 3)]
        public int EndpointCount { get; set; }

        [Params(1, BatchSize)]
        public int CustomerCount { get; set; }

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

            _batch = new EndpointRouteBatch();
            for (int i = 0; i < BatchSize; i++)
            {
                _batch.GetOrAdd(endpoints[i % EndpointCount]).TelemetryItems.Add(
                    new TelemetryItem(DateTime.UtcNow, resource: null, keys[i % CustomerCount]));
            }

            // Observe can run before configuration completes; no transmitters or network are needed.
            _stats = new MultiEndpointStatsbeat(
                null, endpoints[0], null, TimeSpan.FromHours(24), _ => new Measurement<int>(1));
            _stats.Observe(_batch, 1);
        }

        [Benchmark]
        public void Observe() => _stats.Observe(_batch, 1);

        [Benchmark(OperationsPerInvoke = ConcurrentBatches)]
        public void ObserveConcurrent()
        {
            Parallel.For(0, 4, _ =>
            {
                for (int i = 0; i < ConcurrentBatches / 4; i++)
                {
                    _stats.Observe(_batch, 1);
                }
            });
        }

        [GlobalCleanup]
        public void Cleanup() => _stats.Dispose();
    }
}
