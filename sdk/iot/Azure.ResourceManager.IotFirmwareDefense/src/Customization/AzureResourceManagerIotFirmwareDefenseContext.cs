// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    // The compatibility SKU model is no longer in the TypeSpec model graph.
    [ModelReaderWriterBuildable(typeof(IotFirmwareDefenseSkuUpdate))]
    public partial class AzureResourceManagerIotFirmwareDefenseContext
    {
    }
}
