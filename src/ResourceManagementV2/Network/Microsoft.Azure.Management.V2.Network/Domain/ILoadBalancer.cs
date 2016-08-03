/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancer  :
        IGroupableResource,
        IRefreshable<ILoadBalancer>,
        IWrapper<LoadBalancerInner>,
        IUpdatable<IUpdate>
    {
        /// <returns>resource IDs of the public IP addresses assigned to the front end of this load balancer</returns>
        IList<string> PublicIpAddressIds { get; }

    }
}