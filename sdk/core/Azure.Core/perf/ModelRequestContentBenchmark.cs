// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Reflection;
using System.Threading;
using Azure.Core.Tests.Models.ResourceManager.Compute;
using Azure.Core.Tests.Models.ResourceManager.Resources;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class ModelRequestContentBenchmark
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");
        private string _json;
        private string _smallJson;
        private ResourceProviderData _model;
        private AvailabilitySetData _smallModel;
        private ModelReaderWriterOptions _options;
        private BinaryData _data;
        private BinaryData _smallData;

        [GlobalSetup]
        public void SetUp()
        {
            // Large Model
            _json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "ResourceProviderData/ResourceProviderData.json"));
            _data = BinaryData.FromString(_json);
            _model = ModelReaderWriter.Read<ResourceProviderData>(_data);

            // Small Model
            _smallJson = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "AvailabilitySetData/AvailabilitySetData.json"));
            _smallData = BinaryData.FromString(_smallJson);
            _smallModel = ModelReaderWriter.Read<AvailabilitySetData>(_smallData);

            _options = _wireOptions;
        }

        [Benchmark]
        [BenchmarkCategory("LargeJsonModel")]
        public void ModelRequestContentLargeJson()
        {
            var content = RequestContent.Create(_model, _options);

            using var stream = new MemoryStream(_data.ToMemory().Length);
            content.WriteTo(stream, CancellationToken.None);
        }

        [Benchmark]
        [BenchmarkCategory("LargeJsonModel")]
        public void ModelRequestContentLargeJsonBinaryData()
        {
            var content = RequestContent.Create(ModelReaderWriter.Write(_model, _options));

            using var stream = new MemoryStream(_data.ToMemory().Length);
            content.WriteTo(stream, CancellationToken.None);
        }

        [Benchmark]
        [BenchmarkCategory("SmallJsonModel")]
        public void CreateModelRequestContentSmallJson()
        {
            var content = RequestContent.Create(_smallModel, _options);

            using var stream = new MemoryStream(_smallData.ToMemory().Length);
            content.WriteTo(stream, CancellationToken.None);
        }

        [Benchmark]
        [BenchmarkCategory("SmallJsonModel")]
        public void CreateModelRequestContentSmallJsonBinaryData()
        {
            var content = RequestContent.Create(ModelReaderWriter.Write(_smallModel, _options));

            using var stream = new MemoryStream(_smallData.ToMemory().Length);
            content.WriteTo(stream, CancellationToken.None);
        }
    }
}
