// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using LoadBalancer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancers  :
        ISupportsCreating<LoadBalancer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasManager<INetworkManager>,
        IHasInner<ILoadBalancersOperations>
    {
    }
}