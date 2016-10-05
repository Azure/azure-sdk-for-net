// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    /// <summary>
    /// Entry point to load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancers  :
        ISupportsCreating<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>
    {
    }
}