// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using System.Text.Json;
using System.IO;
using Azure.Core.Serialization;
using System;

namespace Azure.Core.Perf
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
    {
        private ModelX _model;

        public SerializationBenchmark()
        {
            _model = new ModelX();
            _model.Name = "Test";
        }

        [Benchmark]
        public Stream Serialize_UseInternalSerialization()
        {
            var model = new ModelX();
            model.Name = "Test";
            var stream = new MemoryStream();
            var writer = new Utf8JsonWriter(stream);
            model.Serialize(writer);
            writer.Flush();
            return stream;
        }

        [Benchmark]
        public RequestContent Serialize_UseImplicitCast()
        {
            var model = new ModelX();
            model.Name = "Test";
            RequestContent content = model;
            return content;
        }

        [Benchmark]
        public string Serialize_UseModelJsonConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.Converters.Add(new ModelJsonConverter(true));
            var model = new ModelX();
            model.Name = "Test";
            return JsonSerializer.Serialize(model, options);
        }

        [Benchmark]
        public BinaryData Serialize_UseModelSerializer()
        {
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.IgnoreAdditionalProperties = true;
            var model = new ModelX();
            model.Name = "Test";
            return ModelSerializer.Serialize(model, options);
        }

        [Benchmark]
        public BinaryData Serialize_UsePublicInterface()
        {
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.IgnoreReadOnlyProperties = true;
            options.IgnoreAdditionalProperties = true;
            var model = new ModelX();
            model.Name = "Test";
            return ((IModelSerializable)model).Serialize(options);
        }
    }
}
