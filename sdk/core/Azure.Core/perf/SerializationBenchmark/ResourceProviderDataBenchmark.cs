// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Tests.Public.ResourceManager.Resources;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    [Config(typeof(SerializationBenchmarkConfig))]
    public class ResourceProviderDataBenchmark : SerializationBenchmark<ResourceProviderData>
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
            return ResourceProviderData.DeserializeResourceProviderData(jsonElement);
        }

        protected override void Serialize(Utf8JsonWriter writer)
        {
            _model.Serialize(writer);
        }
    }
}
