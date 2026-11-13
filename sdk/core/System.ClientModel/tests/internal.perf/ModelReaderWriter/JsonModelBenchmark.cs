// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.IO;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Text.Json;
using System.ClientModel.Internal;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.ClientModel.Tests.Client.Models;

namespace System.ClientModel.Tests.Internal.Perf
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public abstract class JsonModelBenchmark<T>
        where T : class, IJsonModel<T>
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");
        private string _json;
        protected T _model;
        protected ModelReaderWriterOptions _options;
        private BinaryData _data;
        private BinaryData _jsonSerializerResult;
        private ModelReaderWriterContext _context = new TestClientModelReaderWriterContext();

        protected abstract T Read(JsonElement jsonElement);

        protected abstract string JsonFileName { get; }

        [GlobalSetup]
        public void SetUp()
        {
            _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", JsonFileName));
            _data = BinaryData.FromString(_json);
            _model = ModelReaderWriter.Read<T>(_data);
            _options = _wireOptions;
            _jsonSerializerResult = BinaryData.FromString(JsonSerializer.Serialize(_model));
        }

        [Benchmark]
        [BenchmarkCategory("JsonSerializer")]
        public string Write_JsonSerializer()
        {
            return JsonSerializer.Serialize(_model);
        }

        [Benchmark]
        [BenchmarkCategory("JsonSerializer")]
        public string Write_JsonSerializer_SourceGenerated()
        {
#if NET6_0_OR_GREATER
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            return JsonSerializer.Serialize(_model, _model.GetType(), SourceGenerationContext.Default);
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#else
            return Write_JsonSerializer();
#endif
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public string Write_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new JsonModelConverter(_wireOptions));
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
        public BinaryData Write_ModelReaderWriter_WithContext()
        {
            return ModelReaderWriter.Write(_model, _options, _context);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public void Write_ModelWriter()
        {
            using var reader = new ModelWriter(_model, _options).ExtractReader();
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public BinaryData Write_ModelReaderWriterNonGeneric()
        {
            return ModelReaderWriter.Write((object)_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public BinaryData Write_ModelReaderWriterNonGeneric_WithContext()
        {
            return ModelReaderWriter.Write((object)_model, _options, _context);
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
        [BenchmarkCategory("JsonSerializer")]
        public object Read_JsonSerializer_SourceGeneration()
        {
#if NET6_0_OR_GREATER
            using var stream = new MemoryStream();
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            return JsonSerializer.Deserialize(_jsonSerializerResult, _model.GetType(), SourceGenerationContext.Default);
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#else
            return Read_JsonSerializer();
#endif
        }

        [Benchmark]
        [BenchmarkCategory("ModelJsonConverter")]
        public T Read_ModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new JsonModelConverter(_wireOptions));
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
        public T Read_ModelReaderWriterFromBinaryData_WithContext()
        {
            return ModelReaderWriter.Read<T>(_data, _options, _context);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public object Read_ModelReaderWriterFromBinaryDataNonGeneric()
        {
            return ModelReaderWriter.Read(_data, typeof(T), _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelReaderWriter")]
        public object Read_ModelReaderWriterFromBinaryDataNonGeneric_WithContext()
        {
            return ModelReaderWriter.Read(_data, typeof(T), _options, _context);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Read_PublicInterfaceFromBinaryData()
        {
            return _model.Create(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Read_Utf8JsonReaderFromBinaryData()
        {
            Utf8JsonReader reader = new Utf8JsonReader(_data);
            return _model.Create(ref reader, _options);
        }
    }
}
