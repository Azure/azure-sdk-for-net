// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Target type of the resource provided. </summary>
    public enum PacketCaptureTargetType
    {
        /// <summary> AzureVM. </summary>
        AzureVm,
        /// <summary> AzureVMSS. </summary>
        AzureVmss,
        // The generated enum member names normalize all-uppercase wire values to AzureVm/AzureVmss,
        // but the shipped SDK also exposed AzureVM/AzureVMSS. Keep aliases for source compatibility.
        /// <summary> AzureVM. </summary>
        AzureVM = AzureVm,
        /// <summary> AzureVMSS. </summary>
        AzureVMSS = AzureVmss
    }
}
