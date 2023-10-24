// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.IO;
using System.Net.ClientModel.Core;
using System.Reflection;
using System.Text.Json;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public abstract class JsonModelBenchmark<T> where T : class, IJsonModel<T>
    {
        private string _json;
        protected T _model;
        protected ModelReaderWriterOptions _options;
        private BinaryData _data;
        private BinaryData _jsonSerializerResult;

        protected abstract T Read(JsonElement jsonElement);

        protected abstract string JsonFileName { get; }

        [GlobalSetup]
        public void SetUp()
        {
            _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", JsonFileName));
            _data = BinaryData.FromString(_json);
            _model = ModelReaderWriter.Read<T>(_data);
            _options = ModelReaderWriterOptions.DefaultWireOptions;
            _jsonSerializerResult = BinaryData.FromString(JsonSerializer.Serialize(_model));
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
    }
}
