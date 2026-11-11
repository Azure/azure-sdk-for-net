// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    // Warm recording cost with real OpenTelemetry aggregation. Excludes HTTP, serialization,
    // response parsing, and metric export. EndpointOnly matches the previous unkeyed recording.
    [MemoryDiagnoser]
    [CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class MultiEndpointNetworkStatsBenchmarks
    {
        private const int BatchSize = 512;
        private const int ErrorCount = 32;
        private const string Host = "eastus-8.in.applicationinsights.azure.com";
        private NetworkSdkStatsManager _manager = null!;
        private MeterProvider _provider = null!;
        private EndpointRouteBatch.Group _group = null!;
        private TrackResult _partialResponse = null!;

        [Params(1, 32, 512)]
        public int CustomerCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _manager = new NetworkSdkStatsManager(ConnectionVars.CreateUnconfigured(), DefaultPlatform.Instance, multiEndpointEnabled: true);
            _provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StatsbeatConstants.NetworkSdkStatsMeterName)
                .AddView(instrument => _manager.Owns(instrument) ? null : MetricStreamConfiguration.Drop)
                .AddReader(new BaseExportingMetricReader(new DiscardingExporter())
                {
                    TemporalityPreference = MetricReaderTemporalityPreference.Delta
                })
                .Build();
            _manager.BuildBaseTags("eastus-8");

            var keys = new string[CustomerCount];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = $"00000000-0000-0000-0000-{i:D12}";
            }
            _group = new EndpointRouteBatch.Group();
            for (int i = 0; i < BatchSize; i++)
            {
                _group.Add(new TelemetryItem(DateTime.UtcNow, resource: null, keys[i % CustomerCount]));
            }

            var errors = new List<TelemetryErrorDetails>(ErrorCount);
            for (int i = 0; i < ErrorCount; i++)
            {
                errors.Add(new TelemetryErrorDetails(i, 503, "retry", null));
            }
            _partialResponse = new TrackResult(BatchSize, BatchSize - ErrorCount, errors, null);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Request")]
        public void EndpointOnlyRequest()
        {
            _manager.TrackDuration(Host, 10);
            _manager.TrackSuccess(Host);
        }

        [Benchmark]
        [BenchmarkCategory("Request")]
        public void PerCustomerRequest() => _manager.TrackRequest(Host, 200, 10, _group);

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Partial")]
        public void EndpointOnlyPartial()
        {
            _manager.TrackPartialSuccessAccepted(Host, BatchSize - ErrorCount);
            foreach (var error in _partialResponse.Errors)
            {
                _manager.TrackRetry(Host, error.StatusCode!.Value);
            }
        }

        [Benchmark]
        [BenchmarkCategory("Partial")]
        public void PerCustomerPartial() => _manager.TrackPartialSuccess(Host, _partialResponse, _group);

        [GlobalCleanup]
        public void Cleanup()
        {
            _provider.Dispose();
            _manager.Dispose();
        }

        private sealed class DiscardingExporter : BaseExporter<Metric>
        {
            public override ExportResult Export(in Batch<Metric> batch) => ExportResult.Success;
        }
    }
}
