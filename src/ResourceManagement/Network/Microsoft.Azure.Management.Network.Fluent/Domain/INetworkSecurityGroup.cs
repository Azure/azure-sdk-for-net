// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkSecurityGroup.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Network security group.
    /// </summary>
    public interface INetworkSecurityGroup :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        IWrapper<Models.NetworkSecurityGroupInner>,
        IUpdatable<NetworkSecurityGroup.Update.IUpdate>,
        IHasAssociatedSubnets
    {
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> DefaultSecurityRules { get; }

        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule> SecurityRules { get; }

        System.Collections.Generic.IList<string> NetworkInterfaceIds { get; }
    }
}