/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    /// <summary>
    /// Entry point to load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancers  :
        ISupportsCreating<IBlank>,
        ISupportsListing<ILoadBalancer>,
        ISupportsListingByGroup<ILoadBalancer>,
        ISupportsGettingByGroup<ILoadBalancer>,
        ISupportsGettingById<ILoadBalancer>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}