// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Network;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Resource.Fluent.Core;

    internal partial class VirtualMachineScaleSetNicIpConfigurationImpl :
        NicIpConfigurationBaseImpl<VirtualMachineScaleSetNetworkInterfaceImpl, IVirtualMachineScaleSetNetworkInterface>,
        IVirtualMachineScaleSetNicIpConfiguration
    {
        internal VirtualMachineScaleSetNicIpConfigurationImpl(NetworkInterfaceIPConfigurationInner inner,
            VirtualMachineScaleSetNetworkInterfaceImpl parent,
            INetworkManager networkManager) : base(inner, parent, networkManager)
        {
        }

        // Note: The inner ipConfig contains a property with name 'publicIPAddress'
        // which is valid only when the inner is explicitly created i.e. the one
        // associated with normal virtual machines. In VMSS case the inner ipConfig
        // is implicitly created for the scale set vm instances and 'publicIPAddress'
        // property is null.
        //
    }
}
