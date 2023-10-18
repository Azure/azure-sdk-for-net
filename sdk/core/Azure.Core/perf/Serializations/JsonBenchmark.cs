// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Azure.Core.Perf.Serializations
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public abstract class JsonBenchmark<T> where T : class, IModelJsonSerializable<T>
    {
        private string _json;
        protected T _model;
        protected Response _response;
        protected ModelSerializerOptions _options;
        private BinaryData _data;
        private JsonDocument _jsonDocument;

        protected abstract T Deserialize(JsonElement jsonElement);

        protected abstract void Serialize(Utf8JsonWriter writer);

        protected abstract RequestContent CastToRequestContent();

        protected abstract T CastFromResponse();

        protected abstract string JsonFileName { get; }

        [GlobalSetup]
        public void SetUp()
        {
            _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", JsonFileName));
            _data = BinaryData.FromString(_json);
            _model = ModelSerializer.Deserialize<T>(_data);
            _response = new MockResponse(200);
            _response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(_json));
            _options = ModelSerializerOptions.DefaultWireOptions;
            _jsonDocument = JsonDocument.Parse(_json);
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public void Serialize_Internal()
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            Serialize(writer);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Serialize_ImplicitCast()
        {
            using var x = CastToRequestContent();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public bool Serialize_ImplicitCastWithSerialize()
        {
            using var x = CastToRequestContent();
            return x.TryComputeLength(out var length);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Serialize_ImplicitCastWithUsage()
        {
            using var x = CastToRequestContent();
            x.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            x.WriteTo(stream, default);
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public string Serialize_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(ModelSerializerFormat.Wire));
            return JsonSerializer.Serialize(_model, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public BinaryData Serialize_ModelSerializer()
        {
            return ModelSerializer.Serialize(_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public BinaryData Serialize_ModelWriter()
        {
            using var writer = new ModelWriter(_model, _options);
            return writer.ToBinaryData();
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public BinaryData Serialize_ModelSerializerNonGeneric()
        {
            return ModelSerializer.Serialize((object)_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public void Serialize_PublicInterface()
        {
            using var stream = new MemoryStream(_data.ToMemory().Length);
            using var writer = new Utf8JsonWriter(stream);
            _model.Serialize(writer, _options);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public T Deserialize_Internal()
        {
            return Deserialize(_jsonDocument.RootElement);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public T Deserialize_ExplicitCast()
        {
            T result = CastFromResponse();
            _response.ContentStream.Position = 0; //reset for reuse
            return result;
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public T Deserialize_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(ModelSerializerFormat.Wire));
            return JsonSerializer.Deserialize<T>(_json, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public T Deserialize_ModelSerializerFromBinaryData()
        {
            return ModelSerializer.Deserialize<T>(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public object Deserialize_ModelSerializerFromBinaryDataNonGeneric()
        {
            return ModelSerializer.Deserialize(_data, typeof(T), _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Deserialize_PublicInterfaceFromBinaryData()
        {
            return _model.Deserialize(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Deserialize_Utf8JsonReaderFromBinaryData()
        {
            Utf8JsonReader reader = new Utf8JsonReader(_data);
            return _model.Deserialize(ref reader, _options);
        }

        [Benchmark]
        [BenchmarkCategory("JsonDocument")]
        public void JsonDocumentFromReader()
        {
            Utf8JsonReader reader = new Utf8JsonReader(_data);
            using var doc = JsonDocument.ParseValue(ref reader);
        }

        [Benchmark]
        [BenchmarkCategory("JsonDocument")]
        public void JsonDocumentFromBinaryData()
        {
            using var doc = JsonDocument.Parse(_data);
        }
    }
}
