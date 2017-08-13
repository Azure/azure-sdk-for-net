// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancerBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets public (Internet-facing) frontends.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend> PublicFrontends { get; }

        /// <summary>
        /// Gets private (internal) frontends.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPrivateFrontend> PrivateFrontends { get; }

        /// <summary>
        /// Searches for the public frontend that is associated with the provided public IP address, if one exists.
        /// </summary>
        /// <param name="publicIPAddress">A public IP address to search by.</param>
        /// <return>A public frontend associated with the provided public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend FindFrontendByPublicIPAddress(IPublicIPAddress publicIPAddress);

        /// <summary>
        /// Searches for the public frontend that is associated with the provided public IP address, if one exists.
        /// </summary>
        /// <param name="publicIPAddressId">The resource ID of a public IP address to search by.</param>
        /// <return>A public frontend associated with the provided public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend FindFrontendByPublicIPAddress(string publicIPAddressId);
    }
}