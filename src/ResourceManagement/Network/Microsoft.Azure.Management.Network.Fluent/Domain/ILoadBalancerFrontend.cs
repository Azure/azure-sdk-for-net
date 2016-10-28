// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    /// <summary>
    /// An immutable client-side representation of a load balancer frontend.
    /// </summary>
    public interface ILoadBalancerFrontend  :
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.FrontendIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasLoadBalancingRules
    {
        /// <returns>true if the frontend is public, i.e. it has a public IP address associated with it</returns>
        bool IsPublic { get; }

        /// <returns>the inbound NAT pools on this load balancer that use this frontend, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.IInboundNatPool> InboundNatPools { get; }

        /// <returns>the inbound NAT rules on this load balancer that use this frontend, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.IInboundNatRule> InboundNatRules { get; }

    }
}