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
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoData))]
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoPatch))]
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeInfoResource))]
    [ModelReaderWriterBuildable(typeof(NetAppSubvolumeMetadata))]
    [ModelReaderWriterBuildable(typeof(SubvolumeModelProperties))]
    [ModelReaderWriterBuildable(typeof(SubvolumePatchParams))]
    [ModelReaderWriterBuildable(typeof(SubvolumeProperties))]
    [ModelReaderWriterBuildable(typeof(SubvolumesList))]
    public partial class AzureResourceManagerNetAppContext
    {
    }
}
