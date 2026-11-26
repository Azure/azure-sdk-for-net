// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.ResourceGraph.Models;

namespace Azure.ResourceManager.ResourceGraph
{
    // Keep the released context able to deserialize the legacy request.
#pragma warning disable CS0618
    [ModelReaderWriterBuildable(typeof(ResourcesHistoryRequest))]
#pragma warning restore CS0618
    public partial class AzureResourceManagerResourceGraphContext
    {
    }
}
