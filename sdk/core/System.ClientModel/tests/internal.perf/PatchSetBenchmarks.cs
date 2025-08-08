// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class PatchSetBenchmarks
    {
        private BinaryData _data;

        private const int operationsPerInvoke = 100000;
        private List<AvailabilitySetData> _models = new(operationsPerInvoke);

        public PatchSetBenchmarks()
        {
            var json = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "AvailabilitySetData/AvailabilitySetData.json"));
            _data = BinaryData.FromString(json);
        }

        [IterationSetup]
        public void IterationSetup()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models.Add(ModelReaderWriter.Read<AvailabilitySetData>(_data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default));
                for (int j = 0; j < 20; j++)
                {
                    _models[i].VirtualMachines.Add(new WritableSubResource { Id = $"vmId{j}" });
                }
            }
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            _models.Clear();
        }

        [Benchmark(OperationsPerInvoke = operationsPerInvoke)]
        public void Patch_Set_Propagate_ExistingProperty()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models[i].Patch.Set("$.sku.name"u8, "newSkuName");
            }
        }

        [Benchmark(OperationsPerInvoke = operationsPerInvoke)]
        public void Patch_Set_Propagate_NewProperty()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models[i].Patch.Set("$.sku.foobar"u8, "value");
            }
        }

        [Benchmark(OperationsPerInvoke = operationsPerInvoke)]
        public void Patch_Set_Propagate_ArrayItem_ExistingProperty()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models[i].Patch.Set("$.properties.virtualMachines[0].id"u8, "newId");
            }
        }

        [Benchmark(OperationsPerInvoke = operationsPerInvoke)]
        public void Patch_Set_Propagate_ArrayItem_NewProperty()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models[i].Patch.Set("$.properties.virtualMachines[0].foobar"u8, "value");
            }
        }

        [Benchmark(OperationsPerInvoke = operationsPerInvoke)]
        public void Patch_Set_Propagate_DictionaryItem_ExistingProperty()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models[i].Patch.Set("$.tags.key"u8, "newValue");
            }
        }

        [Benchmark(OperationsPerInvoke = operationsPerInvoke)]
        public void Patch_Set_Propagate_DictionaryItem_NewProperty()
        {
            for (int i = 0; i < operationsPerInvoke; i++)
            {
                _models[i].Patch.Set("$.tags.foobar"u8, "value");
            }
        }
    }
}
