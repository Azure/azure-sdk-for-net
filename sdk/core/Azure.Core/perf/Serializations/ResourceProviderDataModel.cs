// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Tests.ResourceManager.Resources;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf.Serializations
{
    [Config(typeof(BenchmarkConfig))]
    public class ResourceProviderDataModel : JsonBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData.json";

        protected override ResourceProviderData CastFromResponse()
        {
            return (ResourceProviderData)_response;
        }

        protected override RequestContent CastToRequestContent()
        {
            return _model;
        }

        protected override ResourceProviderData Deserialize(JsonElement jsonElement)
        {
            return ResourceProviderData.DeserializeResourceProviderData(jsonElement, _options);
        }

        protected override void Serialize(Utf8JsonWriter writer)
        {
            _model.Serialize(writer);
        }
    }
}
