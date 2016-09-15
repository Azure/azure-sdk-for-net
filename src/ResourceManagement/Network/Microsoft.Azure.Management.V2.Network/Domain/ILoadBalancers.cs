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
        ISupportsCreating<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}