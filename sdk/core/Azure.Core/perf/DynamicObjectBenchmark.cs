// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Azure.Core.Tests;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net462)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class DynamicObjectBenchmark
    {
        private static string _fileName = Path.Combine(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "JsonFormattedString.json"));
        private JsonDocument _jsonDocument;
        private ModelWithBinaryData _modelWithBinaryData;
        private ModelWithObject _modelWithObject;

        [GlobalSetup]
        public void SetUp()
        {
            using var fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            _jsonDocument = JsonDocument.Parse(fs);

            var anon = new
            {
                a = "properties.a.value",
                innerProperties = new
                {
                    a = "properties.innerProperties.a.value"
                }
            };

            _modelWithBinaryData = new ModelWithBinaryData();
            _modelWithBinaryData.A = "a.value";
            _modelWithBinaryData.Properties = BinaryData.FromObjectAsJson(anon);

            _modelWithObject = new ModelWithObject();
            _modelWithObject.A = "a.value";
            _modelWithObject.Properties = new Dictionary<string, object>()
            {
                { "a", "a.value" },
                { "innerProperties", new Dictionary<string, object>()
                    {
                        {"a", "properties.innerProperties.a.value" }
                    }
                }
            };
        }

        [Benchmark]
        public void DeserializeWithObject()
        {
            var model = ModelWithObject.DeserializeModelWithObject(_jsonDocument.RootElement);
        }

        [Benchmark]
        public void DeserializeWithObjectAndAccess()
        {
            var model = ModelWithObject.DeserializeModelWithObject(_jsonDocument.RootElement);
            var properties = model.Properties as Dictionary<string, object>;
            var innerProperties = properties["innerProperties"] as Dictionary<string, object>;
            var innerA = innerProperties["a"] as string;
        }

        [Benchmark]
        public void SerializeWithObject()
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            _modelWithObject.Write(writer);
        }

        [Benchmark]
        public void DeserializeWithBinaryData()
        {
            var model = ModelWithBinaryData.DeserializeModelWithBinaryData(_jsonDocument.RootElement);
        }

        [Benchmark]
        public void DeserializeWithBinaryDataAndAccess()
        {
            var model = ModelWithBinaryData.DeserializeModelWithBinaryData(_jsonDocument.RootElement);
            var properties = model.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var innerProperties = properties["innerProperties"] as Dictionary<string, object>;
            var innerA = innerProperties["a"] as string;
        }

        [Benchmark]
        public void SerializeWithBinaryData()
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            _modelWithBinaryData.Write(writer);
        }
    }
}
