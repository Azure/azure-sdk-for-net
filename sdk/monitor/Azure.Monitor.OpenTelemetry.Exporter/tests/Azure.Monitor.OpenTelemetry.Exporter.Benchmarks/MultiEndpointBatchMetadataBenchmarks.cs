// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using BenchmarkDotNet.Attributes;

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class MultiEndpointBatchMetadataBenchmarks
    {
        private readonly List<TelemetryItem> _items = new();
        private readonly EndpointRouteBatch.Group _group = new();
        private TelemetryItem[] _input = null!;

        [Params(512, 8192)]
        public int BatchSize { get; set; }

        [Params(1, 32, 512)]
        public int CustomerCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _input = new TelemetryItem[BatchSize];
            for (int i = 0; i < _input.Length; i++)
            {
                // Equal keys need not share a string instance in real telemetry.
                _input[i] = new TelemetryItem(DateTime.UtcNow, resource: null, $"customer-{i % CustomerCount:D4}");
            }

            ListOnly();
            WithCustomerCounts();
        }

        [Benchmark(Baseline = true)]
        public int ListOnly()
        {
            _items.Clear();
            foreach (var item in _input)
            {
                _items.Add(item);
            }
            return _items.Count;
        }

        [Benchmark]
        public int WithCustomerCounts()
        {
            _group.Close();
            foreach (var item in _input)
            {
                _group.Add(item);
            }
            return _group.TelemetryItems.Count;
        }
    }
}
