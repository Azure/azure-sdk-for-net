// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Dynamic;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Experimental.Perf.Benchmarks
{
    [MemoryDiagnoser]
    public class ParseAndReadLargePayloadBenchmark
    {
        [Benchmark(Baseline = true)]
        public string ReadJsonElement()
        {
            // This should return the string "neutral".
            var document = JsonDocument.Parse(JsonSamples.DocumentSentiment);
            return document.RootElement.GetProperty("documents")[0].GetProperty("sentences")[1].GetProperty("sentiment").GetString();
        }

        [Benchmark]
        public string ReadJsonData()
        {
            var json = JsonSamples.DocumentSentiment.ToDynamic();
            return json.documents[0].sentences[1].sentiment;
        }
    }
}
