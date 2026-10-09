// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Provisioning.Network;

/// <summary> The connection monitor endpoint type. </summary>
public enum ConnectionMonitorEndpointType
{
    /// <summary> Azure virtual machine. </summary>
    [DataMember(Name = "AzureVM")]
    AzureVm = 0,

    /// <summary> Azure virtual network. </summary>
    AzureVNet = 1,

    /// <summary> Azure subnet. </summary>
    AzureSubnet = 2,

    /// <summary> External address. </summary>
    ExternalAddress = 3,

    /// <summary> Microsoft Monitoring Agent workspace machine. </summary>
    MMAWorkspaceMachine = 4,

    /// <summary> Microsoft Monitoring Agent workspace network. </summary>
    MMAWorkspaceNetwork = 5,

    /// <summary> Azure Arc virtual machine. </summary>
    [DataMember(Name = "AzureArcVM")]
    AzureArcVm = 6,

    /// <summary> Azure virtual machine scale set. </summary>
    [DataMember(Name = "AzureVMSS")]
    AzureVmss = 7,

    /// <summary> Azure Arc network. </summary>
    AzureArcNetwork = 8,
}
