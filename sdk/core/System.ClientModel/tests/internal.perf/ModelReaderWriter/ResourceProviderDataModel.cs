// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

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
