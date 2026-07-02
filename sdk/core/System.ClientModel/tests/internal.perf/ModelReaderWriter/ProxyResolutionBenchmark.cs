// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    /// <summary>
    /// Benchmarks that measure the overhead of proxy resolution on read/write paths.
    /// Compares: no proxy vs a proxy that hits vs proxies that miss (decline) so the model
    /// does the work, across 1 and 10 registered proxies and a collection element scenario.
    /// The model is intentionally simple so the benchmark isolates proxy lookup cost.
    /// </summary>
    [MemoryDiagnoser]
    public class ProxyResolutionBenchmark
    {
        private BenchmarkModel _model;
        private BinaryData _data;
        private BinaryData _collectionData;

        private ModelReaderWriterOptions _noProxyOptions;
        private ModelReaderWriterOptions _oneProxyOptions;
        private ModelReaderWriterOptions _oneProxyMissOptions;
        private ModelReaderWriterOptions _tenProxiesLastWinsOptions;
        private ModelReaderWriterOptions _tenProxiesAllDeclineOptions;

        [GlobalSetup]
        public void Setup()
        {
            _model = new BenchmarkModel { Value = "hello" };
            _data = BinaryData.FromString("{\"value\":\"hello\"}");

            // No proxies
            _noProxyOptions = new ModelReaderWriterOptions("J");

            // 1 proxy that always handles
            _oneProxyOptions = new ModelReaderWriterOptions("J");
            _oneProxyOptions.AddProxy<BenchmarkModel>(new BenchmarkProxy(canHandle: true));

            // 10 proxies where only the last one handles (worst case chain walk)
            _tenProxiesLastWinsOptions = new ModelReaderWriterOptions("J");
            for (int i = 0; i < 9; i++)
            {
                _tenProxiesLastWinsOptions.AddProxy<BenchmarkModel>(new BenchmarkProxy(canHandle: false));
            }
            _tenProxiesLastWinsOptions.AddProxy<BenchmarkModel>(new BenchmarkProxy(canHandle: true));

            // 1 conditional proxy that declines — the model does the work (pure miss overhead)
            _oneProxyMissOptions = new ModelReaderWriterOptions("J");
            _oneProxyMissOptions.AddProxy<BenchmarkModel>(new BenchmarkProxy(canHandle: false));

            // 10 conditional proxies that all decline — full chain walk, then the model handles
            _tenProxiesAllDeclineOptions = new ModelReaderWriterOptions("J");
            for (int i = 0; i < 10; i++)
            {
                _tenProxiesAllDeclineOptions.AddProxy<BenchmarkModel>(new BenchmarkProxy(canHandle: false));
            }

            // A 10-element array to measure per-element chain overhead on collection reads
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

            // STJ options for Utf8JsonReader snapshot path benchmarks
            _jsonString = "{\"value\":\"hello\"}";

            _stjNoProxy = new JsonSerializerOptions();
            _stjNoProxy.Converters.Add(new JsonModelConverter(_noProxyOptions));

            _stjOneProxy = new JsonSerializerOptions();
            _stjOneProxy.Converters.Add(new JsonModelConverter(_oneProxyOptions));

            _stjTenProxiesLastWins = new JsonSerializerOptions();
            _stjTenProxiesLastWins.Converters.Add(new JsonModelConverter(_tenProxiesLastWinsOptions));

            // All proxies decline → model handles via snapshot reader (worst case for snapshot cost)
            var allDeclineOptions = new ModelReaderWriterOptions("J");
            for (int i = 0; i < 10; i++)
            {
                allDeclineOptions.AddProxy<BenchmarkModel>(new BenchmarkProxy(canHandle: false));
            }
            _stjAllDecline = new JsonSerializerOptions();
            _stjAllDecline.Converters.Add(new JsonModelConverter(allDeclineOptions));
        }

        // ── Write benchmarks ──

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Write")]
        public BinaryData Write_NoProxy()
        {
            return ModelReaderWriter.Write(_model, _noProxyOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_OneProxy()
        {
            return ModelReaderWriter.Write(_model, _oneProxyOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_TenProxies_LastWins()
        {
            return ModelReaderWriter.Write(_model, _tenProxiesLastWinsOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_OneProxy_Miss()
        {
            return ModelReaderWriter.Write(_model, _oneProxyMissOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_TenProxies_AllDecline()
        {
            return ModelReaderWriter.Write(_model, _tenProxiesAllDeclineOptions);
        }

        // ── Read benchmarks ──

        [Benchmark]
        [BenchmarkCategory("Read")]
        public BenchmarkModel Read_NoProxy()
        {
            return ModelReaderWriter.Read<BenchmarkModel>(_data, _noProxyOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Read")]
        public BenchmarkModel Read_OneProxy()
        {
            return ModelReaderWriter.Read<BenchmarkModel>(_data, _oneProxyOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Read")]
        public BenchmarkModel Read_TenProxies_LastWins()
        {
            return ModelReaderWriter.Read<BenchmarkModel>(_data, _tenProxiesLastWinsOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Read")]
        public BenchmarkModel Read_OneProxy_Miss()
        {
            return ModelReaderWriter.Read<BenchmarkModel>(_data, _oneProxyMissOptions);
        }

        [Benchmark]
        [BenchmarkCategory("Read")]
        public BenchmarkModel Read_TenProxies_AllDecline()
        {
            return ModelReaderWriter.Read<BenchmarkModel>(_data, _tenProxiesAllDeclineOptions);
        }

        // ── Collection read benchmarks (chain evaluated per element) ──

        [Benchmark]
        [BenchmarkCategory("Collection")]
        public List<BenchmarkModel> ReadCollection_NoProxy()
        {
            return ModelReaderWriter.Read<List<BenchmarkModel>>(_collectionData, _noProxyOptions)!;
        }

        [Benchmark]
        [BenchmarkCategory("Collection")]
        public List<BenchmarkModel> ReadCollection_OneProxy_Hit()
        {
            return ModelReaderWriter.Read<List<BenchmarkModel>>(_collectionData, _oneProxyOptions)!;
        }

        [Benchmark]
        [BenchmarkCategory("Collection")]
        public List<BenchmarkModel> ReadCollection_TenProxies_AllDecline()
        {
            return ModelReaderWriter.Read<List<BenchmarkModel>>(_collectionData, _tenProxiesAllDeclineOptions)!;
        }

        // ── Minimal model for benchmarking ──

        public class BenchmarkModel : IJsonModel<BenchmarkModel>
        {
            public string Value { get; set; } = string.Empty;

            void IJsonModel<BenchmarkModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(Value);
                writer.WriteEndObject();
            }

            BenchmarkModel IJsonModel<BenchmarkModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                string val = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString()! : "";
                return new BenchmarkModel { Value = val };
            }

            BinaryData IPersistableModel<BenchmarkModel>.Write(ModelReaderWriterOptions options)
                => ModelReaderWriter.Write(this, options);

            BenchmarkModel IPersistableModel<BenchmarkModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using var doc = JsonDocument.Parse(data);
                string val = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString()! : "";
                return new BenchmarkModel { Value = val };
            }

            string IPersistableModel<BenchmarkModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        // ── Proxy that can be configured to handle or decline ──

        private class BenchmarkProxy : ConditionalModelProxy<BenchmarkModel>
        {
            private readonly bool _canHandle;

            public BenchmarkProxy(bool canHandle) : base(new BenchmarkProxyModel())
            {
                _canHandle = canHandle;
            }

            public override bool CanHandle(BenchmarkModel model) => _canHandle;
            public override bool CanHandle(ReadOnlyMemory<byte> data) => _canHandle;
            public override bool CanHandle(ref Utf8JsonReader reader) => _canHandle;

            private class BenchmarkProxyModel : IJsonModel<BenchmarkModel>
            {
                void IJsonModel<BenchmarkModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                {
                    var model = (BenchmarkModel)options.ProxiedModel!;
                    writer.WriteStartObject();
                    writer.WritePropertyName("value"u8);
                    writer.WriteStringValue(model.Value);
                    writer.WritePropertyName("proxied"u8);
                    writer.WriteBooleanValue(true);
                    writer.WriteEndObject();
                }

                BenchmarkModel IJsonModel<BenchmarkModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                {
                    using var doc = JsonDocument.ParseValue(ref reader);
                    string val = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString()! : "";
                    return new BenchmarkModel { Value = val };
                }

                BenchmarkModel IPersistableModel<BenchmarkModel>.Create(BinaryData data, ModelReaderWriterOptions options)
                {
                    using var doc = JsonDocument.Parse(data);
                    string val = doc.RootElement.TryGetProperty("value", out var v) ? v.GetString()! : "";
                    return new BenchmarkModel { Value = val };
                }

                BinaryData IPersistableModel<BenchmarkModel>.Write(ModelReaderWriterOptions options)
                {
                    var model = (BenchmarkModel)options.ProxiedModel!;
                    using var stream = new System.IO.MemoryStream();
                    using var writer = new Utf8JsonWriter(stream);
                    writer.WriteStartObject();
                    writer.WritePropertyName("value"u8);
                    writer.WriteStringValue(model.Value);
                    writer.WritePropertyName("proxied"u8);
                    writer.WriteBooleanValue(true);
                    writer.WriteEndObject();
                    writer.Flush();
                    return BinaryData.FromBytes(stream.ToArray());
                }

                string IPersistableModel<BenchmarkModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
            }
        }

        // ── STJ Read benchmarks (Utf8JsonReader snapshot path) ──

        private JsonSerializerOptions _stjNoProxy;
        private JsonSerializerOptions _stjOneProxy;
        private JsonSerializerOptions _stjTenProxiesLastWins;
        private JsonSerializerOptions _stjAllDecline;
        private string _jsonString;

        [Benchmark]
        [BenchmarkCategory("STJ_Read")]
        public BenchmarkModel StjRead_NoProxy()
        {
            return JsonSerializer.Deserialize<BenchmarkModel>(_jsonString, _stjNoProxy)!;
        }

        [Benchmark]
        [BenchmarkCategory("STJ_Read")]
        public BenchmarkModel StjRead_OneProxy()
        {
            return JsonSerializer.Deserialize<BenchmarkModel>(_jsonString, _stjOneProxy)!;
        }

        [Benchmark]
        [BenchmarkCategory("STJ_Read")]
        public BenchmarkModel StjRead_TenProxies_LastWins()
        {
            return JsonSerializer.Deserialize<BenchmarkModel>(_jsonString, _stjTenProxiesLastWins)!;
        }

        [Benchmark]
        [BenchmarkCategory("STJ_Read")]
        public BenchmarkModel StjRead_AllDecline_ModelFallback()
        {
            return JsonSerializer.Deserialize<BenchmarkModel>(_jsonString, _stjAllDecline)!;
        }
    }
}
