// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.Serialization;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    [MemoryDiagnoser]
    [InProcess]
    public class BimodalRepro
    {
        private ModelSerializerOptions _options;
        private BinaryData _data;

        [GlobalSetup]
        public void SetUp()
        {
            string json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "SerializationBenchmark", "TestData", "AvailabilitySetData.json"));
            _data = BinaryData.FromString(json);
            _options = ModelSerializerOptions.AzureServiceDefault;
        }

        [Benchmark]
        public void Bimodal()
        {
            using var content = new MultiBufferRequestContent();
        }
    }
}
