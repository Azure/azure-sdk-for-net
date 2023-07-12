// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Tests.Public.ResourceManager.Compute;

namespace Azure.Core.Perf
{
    public class AvailabilitySetDataBenchmark : SerializationBenchmark<AvailabilitySetData>
    {
        protected override void Deserialize(JsonElement jsonElement)
        {
            AvailabilitySetData.DeserializeAvailabilitySetData(jsonElement);
        }

        protected override void Serialize(Utf8JsonWriter writer)
        {
            _model.Serialize(writer);
        }

        protected override RequestContent CastToRequestContent()
        {
            return _model;
        }

        protected override void CastFromResponse()
        {
            var aset = (AvailabilitySetData)_response;
        }

        protected override string JsonFileName => "AvailabilitySetData.json";
    }
}
