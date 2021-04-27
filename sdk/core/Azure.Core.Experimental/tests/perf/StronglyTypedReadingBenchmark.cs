// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using BenchmarkDotNet.Attributes;

namespace Azure.Data.AppConfiguration.Performance
{
    [MemoryDiagnoser]
    public class StronglyTypedReadingBenchmark
    {
        private static string _json = "{\"a\":{\"b\":5}}";

        private static JsonElement _element = JsonDocument.Parse(_json).RootElement;
        private static JsonData _jsonData = JsonData.FromString(_json);

        [Benchmark(Baseline = true)]
        public int ReadJsonElement()
        {
            return _element.GetProperty("a").GetProperty("b").GetInt32();
        }

        [Benchmark]
        public int ReadJsonData()
        {
            return (int)_jsonData["a"]["b"];
        }
    }
}
