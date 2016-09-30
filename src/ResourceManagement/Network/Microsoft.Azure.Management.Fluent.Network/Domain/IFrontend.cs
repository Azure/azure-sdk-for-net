// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// An immutable client-side representation of a load balancer frontend.
    /// </summary>
    public interface IFrontend  :
        IWrapper<Microsoft.Azure.Management.Network.Models.FrontendIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        IHasLoadBalancingRules
    {
        /// <returns>true if the frontend is public, i.e. it has a public IP address associated with it</returns>
        bool IsPublic { get; }

        /// <returns>the inbound NAT pools on this load balancer that use this frontend, indexed by their names</returns>
        IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatPool> InboundNatPools ();

        /// <returns>the inbound NAT rules on this load balancer that use this frontend, indexed by their names</returns>
        IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatRule> InboundNatRules ();

    }
}