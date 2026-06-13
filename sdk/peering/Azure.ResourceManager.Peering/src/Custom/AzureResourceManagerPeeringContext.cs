// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Peering.Models;
using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Peering
{
    [ModelReaderWriterBuildable(typeof(PeeringServicePatch))]
    [ModelReaderWriterBuildable(typeof(PeeringPatch))]
    public partial class AzureResourceManagerPeeringContext
    {
    }
}
