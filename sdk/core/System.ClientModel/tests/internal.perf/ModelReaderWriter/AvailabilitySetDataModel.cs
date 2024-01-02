// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class AvailabilitySetDataModel : JsonModelBenchmark<AvailabilitySetData>
    {
        protected override AvailabilitySetData Read(JsonElement jsonElement)
            => AvailabilitySetData.DeserializeAvailabilitySetData(jsonElement, _options);

        protected override string JsonFileName => "AvailabilitySetData/AvailabilitySetData.json";
    }
}
