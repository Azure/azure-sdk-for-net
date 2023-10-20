// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Tests.Client.ResourceManager.Resources;
using System.Text.Json;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    [Config(typeof(BenchmarkConfig))]
    public class ResourceProviderDataModel : JsonModelBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData/ResourceProviderData.json";

        protected override ResourceProviderData CastFromResponse() => (ResourceProviderData)_result;

        protected override PipelineContent CastToPipelineContent() => _model;

        protected override ResourceProviderData Read(JsonElement jsonElement)
            => ResourceProviderData.DeserializeResourceProviderData(jsonElement, _options);

        protected override void Write(Utf8JsonWriter writer) => _model.Serialize(writer);
    }
}
