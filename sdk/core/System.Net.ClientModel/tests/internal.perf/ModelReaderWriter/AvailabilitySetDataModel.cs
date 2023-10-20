// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Net.ClientModel.Tests.Client.ResourceManager.Compute;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    public class AvailabilitySetDataModel : JsonModelBenchmark<AvailabilitySetData>
    {
        protected override AvailabilitySetData Read(JsonElement jsonElement)
            => AvailabilitySetData.DeserializeAvailabilitySetData(jsonElement, _options);

        protected override void Write(Utf8JsonWriter writer) => _model.Serialize(writer);

        protected override PipelineContent CastToPipelineContent() => _model;

        protected override AvailabilitySetData CastFromResponse() => (AvailabilitySetData)_result;

        protected override string JsonFileName => "AvailabilitySetData/AvailabilitySetData.json";
    }
}
