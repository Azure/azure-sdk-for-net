// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkInterface.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Network interface.
    /// </summary>
    public interface INetworkInterface  :
        INetworkInterfaceBase,
        IGroupableResource<INetworkManager>,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IWrapper<Models.NetworkInterfaceInner>,
        IUpdatable<NetworkInterface.Update.IUpdate>
    {
        /// <summary>
        /// Gets the IP configurations of this network interface, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration> IpConfigurations { get; }

        /// <summary>
        /// Gets the primary IP configuration of this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration PrimaryIpConfiguration { get; }
    }
}