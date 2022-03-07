// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class BinaryDataBenchmark
    {
        private static string _fileName = Path.Combine(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "JsonFormattedString.json"));
        private JsonDocument _jsonDocument;

        [GlobalSetup]
        public void SetUp()
        {
            using var fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            _jsonDocument = JsonDocument.Parse(fs);
        }

        private ModelWithObject DeserializeModelWithObject()
        {
            return ModelWithObject.DeserializeModelWithObject(_jsonDocument.RootElement);
        }

        private ModelWithBinaryData DeserializeModelWithBinaryData()
        {
            return ModelWithBinaryData.DeserializeModelWithBinaryData(_jsonDocument.RootElement);
        }

        [Benchmark]
        public void DeserializeWithObject()
        {
            var model = DeserializeModelWithObject();
        }

        [Benchmark]
        public void DeserializeWithObjectAndAccessOuter()
        {
            var model = DeserializeModelWithObject();
            var properties = model.Properties as Dictionary<string, object>;
            var propA = properties["a"] as string;
        }

        [Benchmark]
        public void DeserializeWithObjectAndAccessInner()
        {
            var model = DeserializeModelWithObject();
            var properties = model.Properties as Dictionary<string, object>;
            var innerProperties = properties["innerProperties"] as Dictionary<string, object>;
            var innerA = innerProperties["a"] as string;
        }

        [Benchmark]
        public void DeserializeWithBinaryData()
        {
            var model = DeserializeModelWithBinaryData();
        }

        [Benchmark]
        public void DeserializeWithBinaryDataAndAccessOuter()
        {
            var model = DeserializeModelWithBinaryData();
            var properties = model.Properties.ToDictionaryFromJson();
            var propA = properties["a"] as string;
        }

        [Benchmark]
        public void DeserializeWithBinaryDataAndAccessInner()
        {
            var model = DeserializeModelWithBinaryData();
            var properties = model.Properties.ToDictionaryFromJson();
            var innerProperties = properties["innerProperties"] as Dictionary<string, object>;
            var innerA = innerProperties["a"] as string;
        }

        [Benchmark]
        public void DeserializeWithBinaryDataAndAccessOuter2()
        {
            var model = DeserializeModelWithBinaryData();
            var properties = model.Properties.ToDictionaryFromJson2();
            var propA = properties["a"] as string;
        }

        [Benchmark]
        public void DeserializeWithBinaryDataAndAccessInner2()
        {
            var model = DeserializeModelWithBinaryData();
            var properties = model.Properties.ToDictionaryFromJson2();
            var innerProperties = properties["innerProperties"] as Dictionary<string, object>;
            var innerA = innerProperties["a"] as string;
        }
    }
}
