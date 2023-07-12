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

namespace Azure.Core.Perf
{
    [MemoryDiagnoser]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [Config(typeof(SerializationBenchmarkConfig))]
    public abstract class SerializationBenchmark<T> where T : class, IJsonModelSerializable
    {
        private string _json;
        protected T _model;
        protected Response _response;
        private ModelSerializerOptions _options;
        private BinaryData _data;

        protected abstract void Deserialize(JsonElement jsonElement);

        protected abstract void Serialize(Utf8JsonWriter writer);

        protected abstract RequestContent CastToRequestContent();

        protected abstract void CastFromResponse();

        protected abstract string JsonFileName { get; }

        public SerializationBenchmark()
        {
            _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "SerializationBenchmark", "TestData", JsonFileName));
            _data = BinaryData.FromString(_json);
            _model = ModelSerializer.Deserialize<T>(_data);
            MockResponse response = new MockResponse(200);
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(_json));
            _response = response;
            _options = ModelSerializerOptions.AzureSerivceDefault;
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
        public void Serialize_ImplicitCastWithSerialize()
        {
            using var x = CastToRequestContent();
            x.TryComputeLength(out var length);
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
        public void Serialize_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.Converters.Add(new ModelJsonConverter(true));
            JsonSerializer.Serialize(_model, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public void Serialize_ModelSerializer()
        {
            ModelSerializer.Serialize(_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public void Serialize_PublicInterface()
        {
            using var content = new MultiBufferRequestContent();
            using var writer = new Utf8JsonWriter(content);
            _model.Serialize(writer, _options);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public void Deserialize_Internal()
        {
            using JsonDocument doc = JsonDocument.Parse(_json);
            Deserialize(doc.RootElement);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Deserialize_ExplicitCast()
        {
            CastFromResponse();
            _response.ContentStream.Position = 0; //reset for reuse
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public void Deserialize_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.Converters.Add(new ModelJsonConverter(true));
            JsonSerializer.Deserialize<T>(_json, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public void Deserialize_ModelSerializer()
        {
            ModelSerializer.Deserialize<T>(BinaryData.FromString(_json), _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public void Deserialize_ModelSerializerWithPreload()
        {
            ModelSerializer.Deserialize<T>(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public void Deserialize_PublicInterface()
        {
            _model.Deserialize(BinaryData.FromString(_json), _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public void Deserialize_PublicInterfaceWithPreload()
        {
            _model.Deserialize(_data, _options);
        }
    }
}
