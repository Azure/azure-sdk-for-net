// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ResourceManager.Compute;

namespace Azure.Core.Perf
{
    public class AvailabilitySetDataBenchmark : SerializationBenchmark<AvailabilitySetData>
    {
        protected override AvailabilitySetData Deserialize(JsonElement jsonElement)
        {
            return AvailabilitySetData.DeserializeAvailabilitySetData(jsonElement);
        }

        protected override AvailabilitySetData Deserialize(BinaryData binaryData)
        {
            return (AvailabilitySetData)((IModelSerializable)_model).Deserialize(binaryData, ModelSerializerOptions.AzureServiceDefault);
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
