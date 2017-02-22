// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Network;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldE5pY0lwQ29uZmlndXJhdGlvbkltcGw=
    internal partial class VirtualMachineScaleSetNicIPConfigurationImpl :
        NicIPConfigurationBaseImpl<VirtualMachineScaleSetNetworkInterfaceImpl, IVirtualMachineScaleSetNetworkInterface>,
        IVirtualMachineScaleSetNicIPConfiguration
    {
        ///GENMHASH:7BFCE86155E2F16ACE271E0FA19BB7FC:5EEEAB2F8988D6716EFD5040E545E7F4
        internal VirtualMachineScaleSetNicIPConfigurationImpl(NetworkInterfaceIPConfigurationInner inner,
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
