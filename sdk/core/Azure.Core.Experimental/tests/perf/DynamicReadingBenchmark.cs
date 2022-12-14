// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Dynamic;
using Azure.Core.Dynamic;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Azure.Core.Experimental.Perf.Benchmarks
{
    [MemoryDiagnoser]
    [InProcess]
    public class DynamicReadingBenchmark
    {
        private static string _json = "{\"a\":{\"b\":5}}";
        private static BinaryData _binaryData = new BinaryData(_json);

        private static dynamic _expandoObject = new ExpandoObject();
        private static dynamic _jsonData = _binaryData.ToDynamic();
        private static dynamic _dynamicNewtonsoftJson = JObject.Parse(_json);

        static DynamicReadingBenchmark()
        {
            _expandoObject.a = new ExpandoObject();
            _expandoObject.a.b = 5;
        }

        [Benchmark(Baseline = true)]
        public int ReadExpandoObject()
        {
            return _expandoObject.a.b;
        }

        [Benchmark]
        public int ReadJsonData()
        {
            return _jsonData.a.b;
        }

        [Benchmark]
        public int ReadNewtonsoftJson()
        {
            return _dynamicNewtonsoftJson.a.b;
        }
    }
}
