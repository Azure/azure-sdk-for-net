// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using BenchmarkDotNet.Attributes;

namespace Azure.Data.AppConfiguration.Performance
{
    [MemoryDiagnoser]
    public class FirstReadBenchmark
    {
        private static string _json = "{\"a\":{\"b\":5}}";

        [Benchmark(Baseline = true)]
        public int ReadJsonElement()
        {
            return JsonDocument.Parse(_json).RootElement.GetProperty("a").GetProperty("b").GetInt32();
        }

        [Benchmark]
        public int ReadDynamicJson()
        {
            return (int)DynamicJson.Parse(_json)["a"]["b"];
        }
    }
}