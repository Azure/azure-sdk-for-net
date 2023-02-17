// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core.Json;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Experimental.Perf.Benchmarks
{
    [MemoryDiagnoser]
    public class MutableJsonDataBenchmark
    {
        [Benchmark(Baseline = true)]
        public void DocumentSentiment_WriteTo_JsonDocument()
        {
            var document = JsonDocument.Parse(JsonSamples.DocumentSentiment);

            MemoryStream stream = new();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            document.WriteTo(writer);
        }

        [Benchmark]
        public void DocumentSentiment_WriteTo_JsonData_NoChanges()
        {
            MutableJsonDocument jsonData = MutableJsonDocument.Parse(JsonSamples.DocumentSentiment);

            MemoryStream stream = new();
            jsonData.WriteTo(stream);
        }

        [Benchmark]
        public void DocumentSentiment_WriteTo_JsonData_ChangeValue()
        {
            MutableJsonDocument jsonData = MutableJsonDocument.Parse(JsonSamples.DocumentSentiment);

            // Make a small change
            jsonData.RootElement.GetProperty("documents").GetIndexElement(0).GetProperty("sentences").GetIndexElement(1).GetProperty("sentiment").Set("positive");

            MemoryStream stream = new();
            jsonData.WriteTo(stream);
        }

        [Benchmark]
        public void DocumentSentiment_WriteTo_JsonData_ChangeStructure()
        {
            MutableJsonDocument jsonData = MutableJsonDocument.Parse(JsonSamples.DocumentSentiment);

            // Make a small change
            jsonData.RootElement.GetProperty("documents").GetIndexElement(0).GetProperty("sentences").GetIndexElement(1).GetProperty("sentiment").Set("positive");

            MemoryStream stream = new();
            jsonData.WriteTo(stream);
        }
    }
}
