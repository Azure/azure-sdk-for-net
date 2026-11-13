// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Peering.Models;

namespace Azure.ResourceManager.Peering
{
    [ModelReaderWriterBuildable(typeof(PeeringServicePatch))]
    [ModelReaderWriterBuildable(typeof(PeeringPatch))]
    public partial class AzureResourceManagerPeeringContext
    {
    }
}
