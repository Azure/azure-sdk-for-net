// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    /// <summary>
    /// A self-contained no-proxy baseline that exercises the exact ModelReaderWriter read/write path
    /// a customer hits when they register no proxies. It deliberately references ONLY APIs that exist
    /// on both the proxy branch and main (no AddProxy / ConditionalModelProxy), so the identical file
    /// can be dropped onto main and run there to prove the proxy feature adds no measurable overhead
    /// to the no-proxy path.
    ///
    /// This directly answers Michael's benchmark ask: "No proxies on my code, and whatever's on main.
    /// These should be identical." The deterministic Allocated column is the primary, run-to-run
    /// stable signal; timings are directional on a non-isolated machine.
    ///
    /// Keep this file free of any proxy APIs so it stays droppable onto main unchanged.
    /// </summary>
    [MemoryDiagnoser]
    public class ProxyResolutionBaselineBenchmark
    {
        private BaselineModel _model;
        private BinaryData _data;
        private BinaryData _collectionData;
        private ModelReaderWriterOptions _options;

        [GlobalSetup]
        public void Setup()
        {
            _model = new BaselineModel { Value = "hello" };
            _data = BinaryData.FromString("{\"value\":\"hello\"}");
            _options = new ModelReaderWriterOptions("J");

            var collectionJson = new System.Text.StringBuilder("[");
            for (int i = 0; i < 10; i++)
            {
                if (i > 0)
                {
                    collectionJson.Append(',');
                }
                collectionJson.Append("{\"value\":\"hello\"}");
            }
            collectionJson.Append(']');
            _collectionData = BinaryData.FromString(collectionJson.ToString());
        }

        [Benchmark]
        public BinaryData Write_NoProxy()
        {
            return ModelReaderWriter.Write(_model, _options);
        }

        [Benchmark]
        public BaselineModel Read_NoProxy()
        {
            return ModelReaderWriter.Read<BaselineModel>(_data, _options);
        }

        [Benchmark]
        public List<BaselineModel> ReadCollection_NoProxy()
        {
            return ModelReaderWriter.Read<List<BaselineModel>>(_collectionData, _options)!;
        }

        // Minimal model that mirrors the shape used by ProxyResolutionBenchmark so the numbers line up.
        public class BaselineModel : IJsonModel<BaselineModel>
        {
            public string Value { get; set; } = string.Empty;

            void IJsonModel<BaselineModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(Value);
                writer.WriteEndObject();
            }

            BaselineModel IJsonModel<BaselineModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                string val = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString()! : "";
                return new BaselineModel { Value = val };
            }

            BinaryData IPersistableModel<BaselineModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            BaselineModel IPersistableModel<BaselineModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.Parse(data);
                string val = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString()! : "";
                return new BaselineModel { Value = val };
            }

            string IPersistableModel<BaselineModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}
