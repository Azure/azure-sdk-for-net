// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition;
    /// <summary>
    /// Entry point to load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancers  :
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>
    {
    }
}