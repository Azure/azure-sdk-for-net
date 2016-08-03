/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// Network security group.
    /// </summary>
    public interface INetworkSecurityGroup  :
        IGroupableResource,
        IRefreshable<INetworkSecurityGroup>,
        IWrapper<NetworkSecurityGroupInner>,
        IUpdatable<IUpdate>
    {
        /// <returns>list of security rules associated with this network security group</returns>
        IList<INetworkSecurityRule> SecurityRules { get; }

        /// <returns>list of default security rules associated with this network security group</returns>
        IList<INetworkSecurityRule> DefaultSecurityRules { get; }

        /// <returns>list of the ids of the network interfaces associated with this network security group</returns>
        IList<string> NetworkInterfaceIds { get; }

    }
}