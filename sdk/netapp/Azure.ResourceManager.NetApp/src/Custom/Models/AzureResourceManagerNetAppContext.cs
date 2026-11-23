// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    [ModelReaderWriterBuildable(typeof(SubvolumeModelProperties))]
    [ModelReaderWriterBuildable(typeof(SubvolumePatchParams))]
    [ModelReaderWriterBuildable(typeof(SubvolumeProperties))]
#pragma warning disable CS0618 // Keep serialization support for these legacy models without deprecating the shared context.
    [ModelReaderWriterBuildable(typeof(EntraIdConfig)), ModelReaderWriterBuildable(typeof(EntraIdConfigPatch)), ModelReaderWriterBuildable(typeof(EntraIdAkvConfig)), ModelReaderWriterBuildable(typeof(EntraIdAkvConfigPatch))]
#pragma warning restore CS0618
#pragma warning disable CS0618
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoData)), ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoPatch)), ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoResource)), ModelReaderWriterBuildable(typeof(NetAppSubvolumeMetadata)), ModelReaderWriterBuildable(typeof(SubvolumesList))]
#pragma warning restore CS0618
    public partial class AzureResourceManagerNetAppContext
    {
    }
}
