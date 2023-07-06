// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using System.Text.Json;
using System.IO;
using Azure.Core.Serialization;
using System;
using System.Reflection;
using BenchmarkDotNet.Configs;
using Azure.Core.TestFramework;
using System.Text;
using Microsoft.Extensions.Options;
using Azure.Core.Tests.Public.ResourceManager.Resources;

namespace Azure.Core.Perf
{
    [MemoryDiagnoser]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class LargeSerializationBenchmark
    {
        private string _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "SerializationBenchmark", "TestData", "ResourceProviderData.json"));
        private ResourceProviderData _model;
        private Response _response;
        private ModelSerializerOptions _options;
        private BinaryData _data;

        public LargeSerializationBenchmark()
        {
            _data = BinaryData.FromString(_json);
            _model = ModelSerializer.Deserialize<ResourceProviderData>(_data);
            MockResponse response = new MockResponse(200);
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(_json));
            _response = response;
            _options = new ModelSerializerOptions();
            _options.IgnoreReadOnlyProperties = true;
            _options.IgnoreAdditionalProperties = true;
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public void Serialize_UseInternal()
        {
            using var stream = new MemoryStream();
            var writer = new Utf8JsonWriter(stream);
            _model.Serialize(writer);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public RequestContent Serialize_UseImplicitCast()
        {
            RequestContent content = _model;
            return content;
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public string Serialize_UseModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.Converters.Add(new ModelJsonConverter(true));
            return JsonSerializer.Serialize(_model, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public BinaryData Serialize_UseModelSerializer()
        {
            return ModelSerializer.Serialize(_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public BinaryData Serialize_UsePublicInterface()
        {
            return ((IModelSerializable)_model).Serialize(_options);
        }

        [Benchmark]
        [BenchmarkCategory("Buffer")]
        public void Serialize_UseBuffer()//bool callWriteTo)
        {
            using var multiBufferRequestContent = new MultiBufferRequestContent();
            var writer = new Utf8JsonWriter(multiBufferRequestContent);
            _model.Serialize(writer);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public void Deserialize_UseInternal()
        {
            using JsonDocument doc = JsonDocument.Parse(_json);
            ResourceProviderData.DeserializeResourceProviderData(doc.RootElement);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Deserialize_UseExplicitCast()
        {
            var aset = (ResourceProviderData)_response;
            _response.ContentStream.Position = 0; //reset for reuse
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public void Deserialize_UseModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.Converters.Add(new ModelJsonConverter(true));
            JsonSerializer.Deserialize<ResourceProviderData>(_json, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public void Deserialize_UseModelSerializer()
        {
            ModelSerializer.Deserialize<ResourceProviderData>(BinaryData.FromString(_json), _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public void Deserialize_UsePublicInterface()
        {
            ((IModelSerializable)_model).Deserialize(BinaryData.FromString(_json), _options);
        }
    }
}
