// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Text.Json;

namespace System.ClientModel.Tests.Internal.Perf
{
    [Config(typeof(BenchmarkConfig))]
    public class ResourceProviderDataModel : JsonModelBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData/ResourceProviderData.json";

        protected override ResourceProviderData Read(JsonElement jsonElement)
            => ResourceProviderData.DeserializeResourceProviderData(jsonElement, _options);
    }
}
