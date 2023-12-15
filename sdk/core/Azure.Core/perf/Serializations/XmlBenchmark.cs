// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Azure.Core.Perf.Serializations
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public abstract class XmlBenchmark<T> where T : class, IModelSerializable<T>
    {
        private string _xml;
        protected T _model;
        protected Response _response;
        protected ModelSerializerOptions _options;
        private BinaryData _data;
        private XElement _element;

        protected abstract T Deserialize(XElement xmlElement);

        protected abstract void Serialize(XmlWriter writer);

        protected abstract RequestContent CastToRequestContent();

        protected abstract T CastFromResponse();

        protected abstract string XmlFileName { get; }

        [GlobalSetup]
        public void SetUp()
        {
            _xml = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", XmlFileName));
            _data = BinaryData.FromString(_xml);
            _model = ModelSerializer.Deserialize<T>(_data);
            _response = new MockResponse(200);
            _response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(_xml));
            _options = ModelSerializerOptions.DefaultWireOptions;
            _element = XElement.Parse(_xml);
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public void Serialize_Internal()
        {
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Serialize(writer);
            writer.Flush();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Serialize_ImplicitCast()
        {
            using var x = CastToRequestContent();
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public bool Serialize_ImplicitCastWithSerialize()
        {
            using var x = CastToRequestContent();
            return x.TryComputeLength(out var length);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public void Serialize_ImplicitCastWithUsage()
        {
            using var x = CastToRequestContent();
            x.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            x.WriteTo(stream, default);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public BinaryData Serialize_ModelSerializer()
        {
            return ModelSerializer.Serialize(_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public BinaryData Serialize_ModelSerializerNonGeneric()
        {
            return ModelSerializer.Serialize((object)_model, _options);
        }

        [Benchmark]
        [BenchmarkCategory("Internal")]
        public T Deserialize_Internal()
        {
            return Deserialize(_element);
        }

        [Benchmark]
        [BenchmarkCategory("Cast")]
        public T Deserialize_ExplicitCast()
        {
            T result = CastFromResponse();
            _response.ContentStream.Position = 0; //reset for reuse
            return result;
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public T Deserialize_ModelSerializerFromBinaryData()
        {
            return ModelSerializer.Deserialize<T>(_data, _options);
        }

        [Benchmark]
        [BenchmarkCategory("ModelSerializer")]
        public object Deserialize_ModelSerializerFromBinaryDataNonGeneric()
        {
            return ModelSerializer.Deserialize(_data, typeof(T), _options);
        }

        [Benchmark]
        [BenchmarkCategory("PublicInterface")]
        public T Deserialize_PublicInterfaceFromBinaryData()
        {
            return _model.Deserialize(_data, _options);
        }
    }
}
