// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.IO;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class AdditionalPropertiesBenchmarks
    {
        private AvailabilitySetData _model;
        private AvailabilitySetData _modelWithPatches;
        private BinaryData _data;
        private BinaryData _dataWithPatches;

        public AdditionalPropertiesBenchmarks()
        {
            var json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "AvailabilitySetData/AvailabilitySetData.json"));
            var data = BinaryData.FromString(json);
            _model = ModelReaderWriter.Read<AvailabilitySetData>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            _modelWithPatches = ModelReaderWriter.Read<AvailabilitySetData>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            _modelWithPatches.Patch.Set("$.sku.name"u8, "newSkuName");
            _modelWithPatches.Patch.Set("$.properties.virtualMachine[-]"u8, "{\"id\":\"vmId\"}"u8);
            _modelWithPatches.Patch.Set("$.foobar"u8, 5);
            _data = ModelReaderWriter.Write(_model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            _dataWithPatches = ModelReaderWriter.Write(_modelWithPatches, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
        }

        [Benchmark]
        public BinaryData ModelOnly_Write()
        {
            return ModelReaderWriter.Write(_model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
        }

        [Benchmark]
        public BinaryData ModelWithPatches_Write()
        {
            return ModelReaderWriter.Write(_modelWithPatches, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
        }

        [Benchmark]
        public AvailabilitySetData ModelOnly_Read()
        {
            return ModelReaderWriter.Read<AvailabilitySetData>(_data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
        }

        [Benchmark]
        public AvailabilitySetData ModelWithPatches_Read()
        {
            return ModelReaderWriter.Read<AvailabilitySetData>(_dataWithPatches, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
        }

        [Benchmark]
        public void Propagate_NoMatch()
        {
            _modelWithPatches.Patch.PropagateTo(ref _modelWithPatches.Sku.Patch, "$.nomatch"u8);
        }

        [Benchmark]
        public void Propagate_Match()
        {
            _modelWithPatches.Patch.PropagateTo(ref _modelWithPatches.Sku.Patch, "$.sku"u8);
        }
    }
}
