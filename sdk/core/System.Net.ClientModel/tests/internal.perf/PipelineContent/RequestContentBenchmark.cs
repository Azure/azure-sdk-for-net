// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using System.IO;
using System.Net.ClientModel.Core;
using System.Reflection;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    public abstract class RequestContentBenchmark<T> where T : class
    {
        protected abstract string JsonFileName { get; }
        protected abstract PipelineContent CreatePipelineContent();

        protected T _model;
        private PipelineContent _writtenContent;
        private MemoryStream _stream;

        [GlobalSetup]
        public void GlobalSetup()
        {
            string json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", JsonFileName));
            Type modelType = typeof(T).GetGenericArguments()[0];
            _model = ModelReaderWriter.Read(BinaryData.FromString(json), modelType) as T;
            _writtenContent = CreatePipelineContent();
            _writtenContent.TryComputeLength(out long length);
            _stream = new MemoryStream((int)length);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _writtenContent.Dispose();
            _writtenContent = null;
        }

        [Benchmark]
        public void Construct()
        {
            using PipelineContent content = CreatePipelineContent();
        }

        [Benchmark]
        public long TryComputeLength()
        {
            using PipelineContent content = CreatePipelineContent();
            content.TryComputeLength(out long length);
            return length;
        }

        [Benchmark]
        public void WriteTo()
        {
            _writtenContent.WriteTo(_stream, default);
            _stream.Position = 0;
        }
    }
}
