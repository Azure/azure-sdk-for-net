// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Tests.ResourceManager.Compute;

namespace Azure.Core.Perf.RequestContents.ModelContent
{
    public class SmallModel : ModelContentBenchmark<AvailabilitySetData>
    {
        protected override string JsonFileName => "AvailabilitySetData.json";
    }
}
