// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Dynamic;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Experimental.Perf.Benchmarks
{
    [MemoryDiagnoser]
    public class FirstReadBenchmark
    {
        private static string _json = "{\"a\":{\"b\":5}}";
        private static BinaryData _binaryData = new BinaryData(_json);

        [Benchmark(Baseline = true)]
        public int ReadJsonElement()
        {
            return JsonDocument.Parse(_json).RootElement.GetProperty("a").GetProperty("b").GetInt32();
        }

        [Benchmark]
        public int ReadJsonData()
        {
            return (int)_binaryData.ToDynamic()["a"]["b"];
        }
    }
}
