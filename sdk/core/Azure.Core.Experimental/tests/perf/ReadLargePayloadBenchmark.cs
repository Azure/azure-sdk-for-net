// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Experimental.Perf.Benchmarks
{
    [MemoryDiagnoser]
    public class ReadLargePayloadBenchmark
    {
        private dynamic _json = JsonSamples.DocumentSentiment.ToDynamicFromJson();
        private JsonDocument _document = JsonDocument.Parse(JsonSamples.DocumentSentiment);

        [Benchmark(Baseline = true)]
        public string ReadJsonElement()
        {
            // This should return the string "neutral".
            return _document.RootElement.GetProperty("documents")[0].GetProperty("sentences")[1].GetProperty("sentiment").GetString();
        }

        [Benchmark]
        public string ReadJsonData()
        {
            return _json.documents[0].sentences[1].sentiment;
        }
    }
}
