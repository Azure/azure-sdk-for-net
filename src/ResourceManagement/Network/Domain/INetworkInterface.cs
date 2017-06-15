// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Network interface.
    /// </summary>
    public interface INetworkInterface  :
        Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager,Models.NetworkInterfaceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<NetworkInterface.Update.IUpdate>
    {
        /// <summary>
        /// Gets the IP configurations of this network interface, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration> IPConfigurations { get; }

        /// <summary>
        /// Gets the primary IP configuration of this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration PrimaryIPConfiguration { get; }
    }
}