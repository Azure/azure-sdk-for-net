// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.Serialization;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf.RequestContents
{
    public abstract class RequestContentBenchmark<T> where T : class
    {
        protected abstract string JsonFileName { get; }
        protected abstract RequestContent CreateRequestContent();

        protected T _model;
        private RequestContent _serializedContent;
        private MemoryStream _stream;

        [GlobalSetup]
        public void GlobalSetup()
        {
            string json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", JsonFileName));
            Type modelType = typeof(T).GetGenericArguments()[0];
            _model = ModelSerializer.Deserialize(BinaryData.FromString(json), modelType) as T;
            _serializedContent = CreateRequestContent();
            _serializedContent.TryComputeLength(out long length);
            _stream = new MemoryStream((int)length);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _serializedContent.Dispose();
            _serializedContent = null;
        }

        [Benchmark]
        public void Construct()
        {
            using RequestContent content = CreateRequestContent();
        }

        [Benchmark]
        public long TryComputeLength()
        {
            using RequestContent content = CreateRequestContent();
            content.TryComputeLength(out long length);
            return length;
        }

        [Benchmark]
        public void WriteTo()
        {
            _serializedContent.WriteTo(_stream, default);
            _stream.Position = 0;
        }
    }
}
