// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Tests.Client.ResourceManager.Compute;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    public class SmallJsonModel : ModelContentBenchmark<AvailabilitySetData>
    {
        protected override string JsonFileName => "AvailabilitySetData.json";
    }
}
