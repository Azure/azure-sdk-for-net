// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Tests.Client.ResourceManager.Resources;

namespace System.Net.ClientModel.Tests.Internal.Perf
{
    public class LargeJsonModel : ModelContentBenchmark<ResourceProviderData>
    {
        protected override string JsonFileName => "ResourceProviderData.json";
    }
}
