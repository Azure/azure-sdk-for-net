// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    // Justification: needed because EdgeOrderResourceIdentity's customized deserialization
    // hook (DeserializeUserAssignedIdentities) calls ModelReaderWriter.Read<UserAssignedIdentity>(..., context).
    // The generator no longer adds this entry to the context once the generated read path is replaced
    // by the hook, so register it explicitly here.
    [ModelReaderWriterBuildable(typeof(UserAssignedIdentity))]
    public partial class AzureResourceManagerEdgeOrderContext
    {
    }
}
