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
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public class JsonPatchUsageBenchmarks
    {
        private AvailabilitySetData _model;
        private AvailabilitySetData _modelWithPatches;
        private BinaryData _data;
        private BinaryData _dataWithPatches;

        public JsonPatchUsageBenchmarks()
        {
            var json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "AvailabilitySetData/AvailabilitySetData.json"));
            var data = BinaryData.FromString(json);
            _model = ModelReaderWriter.Read<AvailabilitySetData>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            _modelWithPatches = ModelReaderWriter.Read<AvailabilitySetData>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            _modelWithPatches.Patch.Set("$.sku.name"u8, "newSkuName");
            _modelWithPatches.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vmId\"}"u8);
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
    }
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
