// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to load balancer management API in Azure.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ILoadBalancers  :
        ISupportsCreating<LoadBalancer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        ISupportsBatchDeletion,
        IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IHasInner<Microsoft.Azure.Management.Network.Fluent.ILoadBalancersOperations>
    {
    }
}