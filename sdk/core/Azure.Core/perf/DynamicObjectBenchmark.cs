// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarks.Local;
using Benchmarks.Nuget;

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.Net80)]
    [MemoryDiagnoser]
    public class DynamicObjectBenchmark
    {
        private static readonly string FileName = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "TestData",
            "JsonFormattedString.json");

        private Benchmarks.Local.DynamicObjectScenario _localScenario;
        private Benchmarks.Nuget.DynamicObjectScenario _nugetScenario;

        [GlobalSetup]
        public void SetUp()
        {
            _localScenario = new Benchmarks.Local.DynamicObjectScenario(FileName);
            _nugetScenario = new Benchmarks.Nuget.DynamicObjectScenario(FileName);
        }

        [Benchmark]
        public void Local_DeserializeWithObject()
        {
            _localScenario.DeserializeWithObject();
        }

        [Benchmark]
        public void Nuget_DeserializeWithObject()
        {
            _nugetScenario.DeserializeWithObject();
        }

        [Benchmark]
        public void Local_DeserializeWithObjectAndAccess()
        {
            _localScenario.DeserializeWithObjectAndAccess();
        }

        [Benchmark]
        public void Nuget_DeserializeWithObjectAndAccess()
        {
            _nugetScenario.DeserializeWithObjectAndAccess();
        }

        [Benchmark]
        public void Local_SerializeWithObject()
        {
            _localScenario.SerializeWithObject();
        }

        [Benchmark]
        public void Nuget_SerializeWithObject()
        {
            _nugetScenario.SerializeWithObject();
        }

        [Benchmark]
        public void Local_DeserializeWithBinaryData()
        {
            _localScenario.DeserializeWithBinaryData();
        }

        [Benchmark]
        public void Nuget_DeserializeWithBinaryData()
        {
            _nugetScenario.DeserializeWithBinaryData();
        }

        [Benchmark]
        public void Local_DeserializeWithBinaryDataAndAccess()
        {
            _localScenario.DeserializeWithBinaryDataAndAccess();
        }

        [Benchmark]
        public void Nuget_DeserializeWithBinaryDataAndAccess()
        {
            _nugetScenario.DeserializeWithBinaryDataAndAccess();
        }

        [Benchmark]
        public void Local_SerializeWithBinaryData()
        {
            _localScenario.SerializeWithBinaryData();
        }

        [Benchmark]
        public void Nuget_SerializeWithBinaryData()
        {
            _nugetScenario.SerializeWithBinaryData();
        }
        [GlobalCleanup]
        public void CleanUp()
        {
            _localScenario.Dispose();
            _nugetScenario.Dispose();
        }
    }
}
