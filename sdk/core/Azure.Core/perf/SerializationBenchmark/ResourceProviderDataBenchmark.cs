// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Tests.Public.ResourceManager.Resources;

namespace Azure.Core.Perf
{
    public class ResourceProviderDataBenchmark : SerializationBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData.json";

        protected override void CastFromResponse()
        {
            var resourceProviderData = (ResourceProviderData)_response;
        }

        protected override RequestContent CastToRequestContent()
        {
            return _model;
        }

        protected override void Deserialize(JsonElement jsonElement)
        {
            ResourceProviderData.DeserializeResourceProviderData(jsonElement);
        }

        protected override void Serialize(Utf8JsonWriter writer)
        {
            _model.Serialize(writer);
        }
    }
}
