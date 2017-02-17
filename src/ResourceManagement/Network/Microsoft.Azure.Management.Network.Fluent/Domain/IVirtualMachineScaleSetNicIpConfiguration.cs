// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An IP configuration in a network interface associated with a virtual machine
    /// scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetNicIpConfiguration  :
        INicIpConfigurationBase,
        IHasInner<Models.NetworkInterfaceIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>,
        IHasPrivateIpAddress,
        IHasSubnet
    {
    }
}