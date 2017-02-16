// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a load balancer frontend.
    /// </summary>
    public interface ILoadBalancerFrontend  :
        IHasInner<Models.FrontendIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasLoadBalancingRules
    {
        /// <summary>
        /// Gets the inbound NAT pools on this load balancer that use this frontend, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> InboundNatPools { get; }

        /// <summary>
        /// Gets the inbound NAT rules on this load balancer that use this frontend, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> InboundNatRules { get; }

        /// <summary>
        /// Gets true if the frontend is public, i.e. it has a public IP address associated with it.
        /// </summary>
        bool IsPublic { get; }
    }
}