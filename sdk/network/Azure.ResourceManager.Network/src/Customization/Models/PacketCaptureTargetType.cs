// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Target type of the resource provided. </summary>
    [CodeGenType("PacketCaptureTargetType")]
    public enum PacketCaptureTargetType
    {
        /// <summary> AzureVM. </summary>
        AzureVm,
        /// <summary> AzureVMSS. </summary>
        AzureVmss,
        /// <summary> AzureVM. </summary>
        AzureVM = AzureVm,
        /// <summary> AzureVMSS. </summary>
        AzureVMSS = AzureVmss
    }
}
