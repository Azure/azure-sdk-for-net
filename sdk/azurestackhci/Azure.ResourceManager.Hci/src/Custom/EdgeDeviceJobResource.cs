// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/57613 is fixed
    // (generator emits `new EdgeDeviceJobData()` but EdgeDeviceJobData is abstract)
    [CodeGenSuppress("DataDeserializationInstance")]
    [CodeGenSuppress("s_dataDeserializationInstance")]
    public partial class EdgeDeviceJobResource
    {
        private static IJsonModel<EdgeDeviceJobData> s_dataDeserializationInstance;
        private static IJsonModel<EdgeDeviceJobData> DataDeserializationInstance => s_dataDeserializationInstance ??= new HciEdgeDeviceJob();
    }
}
