// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using BenchmarkDotNet.Attributes;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    [MemoryDiagnoser]
    public class ModelReaderWriterBenchmarks
    {
        private const string ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1";
        private static readonly ResourceIdentifier s_resourceId = new(ResourceId);
        private static readonly ResourceType s_resourceType = new("Microsoft.Compute/availabilitySets");
        private static readonly BinaryData s_wireJson = BinaryData.FromString("{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1\",\"name\":\"as1\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"eastus\",\"properties\":{\"platformFaultDomainCount\":2}}");

        [Benchmark(Baseline = true)]
        public AvailabilitySetData WireJson()
            => ModelReaderWriter.Read<AvailabilitySetData>(s_wireJson, ModelReaderWriterOptions.Json, AzureResourceManagerComputeContext.Default)!;

        [Benchmark]
        public AvailabilitySetData ModelJsonBuilder()
        {
            ModelJsonBuilder json = new();
            json.Set("$.id"u8, ResourceId);
            json.Set("$.name"u8, "as1");
            json.Set("$.type"u8, "Microsoft.Compute/availabilitySets");
            json.Set("$.location"u8, "eastus");
            json.Set("$.properties.platformFaultDomainCount"u8, 2);
            return ModelReaderWriter.Read<AvailabilitySetData>(json.ToBinaryData(), ModelReaderWriterOptions.Json, AzureResourceManagerComputeContext.Default)!;
        }

        [Benchmark]
        public AvailabilitySetData TypedBuilder()
            => ArmModelBuilder<AvailabilitySetData>.For(AvailabilitySetDataPaths)
                .Set(data => data.Id, s_resourceId)
                .Set(data => data.Name, "as1")
                .Set(data => data.ResourceType, s_resourceType)
                .Set(data => data.Location, AzureLocation.EastUS)
                .Set(data => data.PlatformFaultDomainCount, 2)
                .Build(AzureResourceManagerComputeContext.Default);

        [Benchmark]
        public AvailabilitySetData FactoryStyleBuilder()
            => ArmModelBuilder<AvailabilitySetData>.For(new AvailabilitySetData(AzureLocation.EastUS), AvailabilitySetDataPaths)
                .Set(data => data.Id, s_resourceId)
                .Set(data => data.Name, "as1")
                .Set(data => data.ResourceType, s_resourceType)
                .Set(data => data.PlatformFaultDomainCount, 2)
                .Build(AzureResourceManagerComputeContext.Default);

        private static readonly IReadOnlyDictionary<string, string> AvailabilitySetDataPaths = new Dictionary<string, string>
        {
            [nameof(AvailabilitySetData.Id)] = "$.id",
            [nameof(AvailabilitySetData.Name)] = "$.name",
            [nameof(AvailabilitySetData.ResourceType)] = "$.type",
            [nameof(AvailabilitySetData.Location)] = "$.location",
            [nameof(AvailabilitySetData.PlatformFaultDomainCount)] = "$.properties.platformFaultDomainCount",
        };
    }
}
