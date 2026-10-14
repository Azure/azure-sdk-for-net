// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkInterfaceResource
    {
        // MPG treats this resource-level list action as the canonical generated GetAll/GetAllAsync pair.
        // The GA SDK shipped the operation-id based GetNetworkInterfaceLoadBalancers/GetNetworkInterfaceLoadBalancersAsync
        // names, so keep those APIs as forwarding shims while reusing the generated pageable implementation.
        /// <summary> List all load balancers in a network interface. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LoadBalancerResource"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<LoadBalancerResource> GetNetworkInterfaceLoadBalancersAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<LoadBalancerData, LoadBalancerResource>(new NetworkInterfaceLoadBalancersGetAllAsyncCollectionResultOfT(
                _networkInterfaceLoadBalancersRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                context,
                "NetworkInterfaceResource.GetNetworkInterfaceLoadBalancers"), data => new LoadBalancerResource(Client, data));
        }

        /// <summary> List all load balancers in a network interface. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LoadBalancerResource"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<LoadBalancerResource> GetNetworkInterfaceLoadBalancers(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<LoadBalancerData, LoadBalancerResource>(new NetworkInterfaceLoadBalancersGetAllCollectionResultOfT(
                _networkInterfaceLoadBalancersRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                context,
                "NetworkInterfaceResource.GetNetworkInterfaceLoadBalancers"), data => new LoadBalancerResource(Client, data));
        }
    }
}
