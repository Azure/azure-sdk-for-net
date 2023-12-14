// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Text.Json;

namespace ClientModel.Tests.Internal.Perf
{
    public class AvailabilitySetDataModel : JsonModelBenchmark<AvailabilitySetData>
    {
        protected override AvailabilitySetData Read(JsonElement jsonElement)
            => AvailabilitySetData.DeserializeAvailabilitySetData(jsonElement, _options);

        protected override string JsonFileName => "AvailabilitySetData/AvailabilitySetData.json";
    }
}
