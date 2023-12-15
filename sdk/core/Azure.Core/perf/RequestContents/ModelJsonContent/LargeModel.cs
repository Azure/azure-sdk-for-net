// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Tests.ResourceManager.Resources;

namespace Azure.Core.Perf.RequestContents.ModelJsonContent
{
    public class LargeModel : ModelJsonContentBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData.json";
    }
}
