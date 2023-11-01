// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Tests.Client.Models.ResourceManager.Resources;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    public class LargeModel : ModelJsonContentBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData.json";
    }
}
