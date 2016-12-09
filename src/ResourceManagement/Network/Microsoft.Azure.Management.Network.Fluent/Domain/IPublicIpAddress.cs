// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using PublicIpAddress.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// Public IP address.
    /// </summary>
    public interface IPublicIpAddress :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        IWrapper<Models.PublicIPAddressInner>,
        IUpdatable<PublicIpAddress.Update.IUpdate>
    {
        string ReverseFqdn { get; }

        string Fqdn { get; }

        bool HasAssignedNetworkInterface { get; }

        string IpAddress { get; }

        string IpAllocationMethod { get; }

        int IdleTimeoutInMinutes { get; }

        string LeafDomainLabel { get; }

        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration();

        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend GetAssignedLoadBalancerFrontend();

        string Version { get; }

        bool HasAssignedLoadBalancer { get; }
    }
}