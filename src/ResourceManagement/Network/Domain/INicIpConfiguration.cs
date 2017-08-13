// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An IP configuration in a network interface.
    /// </summary>
    public interface INicIPConfiguration  :
        Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.NetworkInterfaceIPConfigurationInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress
    {
    }
}