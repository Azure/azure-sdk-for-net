// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An IP configuration in a network interface.
    /// </summary>
    public interface INicIPConfiguration  :
        INicIPConfigurationBase,
        IHasInner<Models.NetworkInterfaceIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IHasPrivateIPAddress,
        IHasPublicIPAddress,
        IHasSubnet
    {
    }
}