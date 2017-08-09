// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of a private frontend of an internal load balancer.
    /// </summary>
    public interface ILoadBalancerPrivateFrontend  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend,
        Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet
    {
        /// <return>
        /// Associated subnet
        /// Note this makes a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();
    }
}