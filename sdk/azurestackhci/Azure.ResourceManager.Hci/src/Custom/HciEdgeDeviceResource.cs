// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/57613 is fixed
    // (generator emits `new HciEdgeDeviceData()` but HciEdgeDeviceData is abstract)
    [CodeGenSuppress("DataDeserializationInstance")]
    [CodeGenSuppress("s_dataDeserializationInstance")]
    public partial class HciEdgeDeviceResource
    {
        private static IJsonModel<HciEdgeDeviceData> s_dataDeserializationInstance;
        private static IJsonModel<HciEdgeDeviceData> DataDeserializationInstance => s_dataDeserializationInstance ??= new HciArcEnabledEdgeDevice();
    }
}
