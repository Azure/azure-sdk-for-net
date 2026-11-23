// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    [ModelReaderWriterBuildable(typeof(EntraIdConfig))]
    [ModelReaderWriterBuildable(typeof(EntraIdConfigPatch))]
    [ModelReaderWriterBuildable(typeof(EntraIdAkvConfig))]
    [ModelReaderWriterBuildable(typeof(EntraIdAkvConfigPatch))]
#pragma warning disable CS0618 // Keep model reader/writer support for the obsolete subvolume types.
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoData))]
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoPatch))]
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoResource))]
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeMetadata))]
#pragma warning restore CS0618
    [ModelReaderWriterBuildable(typeof(SubvolumeModelProperties))]
    [ModelReaderWriterBuildable(typeof(SubvolumePatchParams))]
    [ModelReaderWriterBuildable(typeof(SubvolumeProperties))]
    [ModelReaderWriterBuildable(typeof(SubvolumesList))]
    public partial class AzureResourceManagerNetAppContext
    {
    }
}
