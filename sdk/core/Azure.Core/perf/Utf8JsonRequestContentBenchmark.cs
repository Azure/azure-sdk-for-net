// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    /// <summary>
    /// Benchmarks comparing <see cref="Utf8JsonRequestContent"/> (using <see cref="System.Buffers.IBufferWriter{T}"/>)
    /// with the legacy MemoryStream-based approach.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net80)]
    [MemoryDiagnoser]
    public class Utf8JsonRequestContentBenchmark
    {
        private static readonly Stream _nullStream = Stream.Null;

        [Params(10, 100)]
        public int PropertyCount { get; set; }

        [Benchmark(Baseline = true, Description = "Legacy (MemoryStream)")]
        public void LegacyMemoryStream()
        {
            using var content = new Utf8JsonRequestContentOld();
            WriteProperties(content.JsonWriter, PropertyCount);
            content.WriteTo(_nullStream, default);
        }

        [Benchmark(Description = "New (IBufferWriter)")]
        public void NewBufferWriter()
        {
            using var content = new Utf8JsonRequestContent();
            WriteProperties(content.JsonWriter, PropertyCount);
            content.WriteTo(_nullStream, default);
        }

        [Benchmark(Description = "New (IBufferWriter) TryComputeLength")]
        public void NewBufferWriterWithLength()
        {
            using var content = new Utf8JsonRequestContent();
            WriteProperties(content.JsonWriter, PropertyCount);
            content.TryComputeLength(out _);
            content.WriteTo(_nullStream, default);
        }

        private static void WriteProperties(Utf8JsonWriter writer, int count)
        {
            writer.WriteStartObject();
            for (int i = 0; i < count; i++)
            {
                writer.WriteString($"property{i}", $"value{i}");
            }
            writer.WriteEndObject();
        }
    }
}
