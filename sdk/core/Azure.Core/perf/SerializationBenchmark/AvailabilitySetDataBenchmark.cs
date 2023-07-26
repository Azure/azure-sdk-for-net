﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Tests.Public.ResourceManager.Compute;

namespace Azure.Core.Perf
{
    public class AvailabilitySetDataBenchmark : JsonSerializationBenchmark<AvailabilitySetData>
    {
        protected override AvailabilitySetData Deserialize(JsonElement jsonElement)
        {
            return AvailabilitySetData.DeserializeAvailabilitySetData(jsonElement, _options);
        }

        protected override void Serialize(Utf8JsonWriter writer)
        {
            _model.Serialize(writer);
        }

        protected override RequestContent CastToRequestContent()
        {
            return _model;
        }

        protected override AvailabilitySetData CastFromResponse()
        {
            return (AvailabilitySetData)_response;
        }

        protected override string JsonFileName => "AvailabilitySetData.json";
    }
}
