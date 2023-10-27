// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.ClientModel.Core;
using System.Reflection;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public abstract class JsonModelBenchmark<T> where T : class, IJsonModel<T>
    {
        private class MockPipelineResponse : PipelineResponse
        {
            public MockPipelineResponse(int status, BinaryData content)
            {
                Status = status;
                Content = MessageBody.CreateContent(content);
            }

            public override int Status { get; }

            public override string ReasonPhrase => throw new NotImplementedException();

            public override MessageHeaders Headers => throw new NotImplementedException();

            public override MessageBody Content { get; protected internal set; }

            public override void Dispose()
            {
                Content?.Dispose();
            }
        }

        private class MockResult : Result
        {
            private PipelineResponse _response;

            public MockResult(int status, BinaryData content)
            {
                _response = new MockPipelineResponse(status, content);
            }

            public override PipelineResponse GetRawResponse() => _response;
        }

        private string _json;
        protected T _model;
        protected Result _result;
        protected ModelReaderWriterOptions _options;
        private BinaryData _data;
        private JsonDocument _jsonDocument;
        private BinaryData _jsonSerializerResult;

        protected abstract T Read(JsonElement jsonElement);

        protected abstract void Write(Utf8JsonWriter writer);

        protected abstract MessageBody CastToPipelineContent();

        protected abstract T CastFromResponse();

        protected abstract string JsonFileName { get; }

        [GlobalSetup]
        public void SetUp()
        {
            _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", JsonFileName));
            _data = BinaryData.FromString(_json);
            _model = ModelReaderWriter.Read<T>(_data);
            _result = new MockResult(200, new BinaryData(Encoding.UTF8.GetBytes(_json)));
            _options = ModelReaderWriterOptions.DefaultWireOptions;
            _jsonDocument = JsonDocument.Parse(_json);
            _jsonSerializerResult = BinaryData.FromString(JsonSerializer.Serialize(_model));
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public void Write_Internal()
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            Write(writer);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Write_ImplicitCast()
        {
            using var x = CastToPipelineContent();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public bool Write_ImplicitCastWithSerialize()
        {
            using var x = CastToPipelineContent();
            return x.TryComputeLength(out var length);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Write_ImplicitCastWithUsage()
        {
            using var x = CastToPipelineContent();
            x.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            x.WriteTo(stream, default);
        }

        [Benchmark]
        [BenchmarkCategory("JsonSerializer")]
        public string Write_JsonSerializer()
        {
            return JsonSerializer.Serialize(_model);
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public string Write_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(ModelReaderWriterFormat.Wire));
            return JsonSerializer.Serialize(_model, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public BinaryData Write_ModelReaderWriter()
        {
            return ModelReaderWriter.Write(_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public BinaryData Write_ModelWriter()
        {
            using var writer = new ModelWriter(_model, _options);
            return writer.ToBinaryData();
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public BinaryData Write_ModelReaderWriterNonGeneric()
        {
            return ModelReaderWriter.Write((object)_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public void Write_PublicInterface()
        {
            using var stream = new MemoryStream(_data.ToMemory().Length);
            using var writer = new Utf8JsonWriter(stream);
            _model.Write(writer, _options);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public T Read_Internal()
        {
            return Read(_jsonDocument.RootElement);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public T Read_ExplicitCast()
        {
            T result = CastFromResponse();
            return result;
        }

        [Benchmark]
        [BenchmarkCategory("JsonSerializer")]
        public object Read_JsonSerializer()
        {
            using var stream = new MemoryStream();
            return JsonSerializer.Deserialize(_jsonSerializerResult, _model.GetType());
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public T Read_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(ModelReaderWriterFormat.Wire));
            return JsonSerializer.Deserialize<T>(_json, options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public T Read_ModelReaderWriterFromBinaryData()
        {
            return ModelReaderWriter.Read<T>(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public object Read_ModelReaderWriterFromBinaryDataNonGeneric()
        {
            return ModelReaderWriter.Read(_data, typeof(T), _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Read_PublicInterfaceFromBinaryData()
        {
            return _model.Read(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Read_Utf8JsonReaderFromBinaryData()
        {
            Utf8JsonReader reader = new Utf8JsonReader(_data);
            return _model.Read(ref reader, _options);
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
