// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Tests.ResourceManager.Compute;

namespace Azure.Core.Perf.RequestContents.ModelJsonContent
{
    public class SmallModel : ModelJsonContentBenchmark<AvailabilitySetData>
    {
        protected override string JsonFileName => "AvailabilitySetData.json";
    }
}
