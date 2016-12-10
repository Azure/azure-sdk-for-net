// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a private frontend of an internal load balancer.
    /// </summary>
    public interface ILoadBalancerPrivateFrontend  :
        ILoadBalancerFrontend,
        IHasPrivateIpAddress,
        IHasSubnet
    {
        /// <return>
        /// Associated subnet
        /// Note this makes a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();
    }
}