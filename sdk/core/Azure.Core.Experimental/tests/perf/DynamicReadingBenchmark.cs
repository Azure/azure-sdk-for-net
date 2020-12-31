// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Dynamic;
using Azure.Core;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Azure.Data.AppConfiguration.Performance
{
    [MemoryDiagnoser]
    [InProcess]
    public class DynamicReadingBenchmark
    {
        private static string _json = "{\"a\":{\"b\":5}}";

        private static dynamic _expandoObject = new ExpandoObject();
        private static dynamic _dynamicJson = DynamicJson.Parse(_json);
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
        public int ReadDynamicJson()
        {
            return _dynamicJson.a.b;
        }
        [Benchmark]
        public int ReadNewtonsoftJson()
        {
            return _dynamicNewtonsoftJson.a.b;
        }
    }
}