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
    public class SerializationToStringBenchmark
    {
        private SerializationBenchmark _benchMark;
        private string _expected;

        public SerializationToStringBenchmark()
        {
            _benchMark = new SerializationBenchmark();
            _expected = "{\"kind\":\"X\",\"name\":\"Test\"}";
        }

        [Benchmark]
        public void Serialize_UseInternalSerialization_WithToString()
        {
            CompareString(_benchMark.Serialize_UseInternalSerialization());
        }

        [Benchmark]
        public void Serialize_UseImplicitCast_WithToString()
        {
            CompareString(_benchMark.Serialize_UseImplicitCast());
        }

        [Benchmark]
        public void Serialize_UseModelJsonConverter_WithToString()
        {
            CompareString(_benchMark.Serialize_UseModelJsonConverter());
        }

        [Benchmark]
        public void Serialize_UseModelSerializer_WithToString()
        {
            CompareString(_benchMark.Serialize_UseModelSerializer());
        }

        [Benchmark]
        public void Serialize_UsePublicInterface_WithToString()
        {
            CompareString(_benchMark.Serialize_UsePublicInterface());
        }

        private void CompareString(Stream stream)
        {
            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream);
            CompareString(reader.ReadToEnd());
        }

        private void CompareString(RequestContent content)
        {
            MemoryStream stream = new MemoryStream();
            content.WriteTo(stream, default);
            CompareString(stream);
        }

        private void CompareString(BinaryData data) => CompareString(data.ToString());

        private void CompareString(string actual)
        {
            if (!actual.Equals(_expected))
                throw new Exception($"Expected {_expected} but got {actual}");
        }
    }
}
