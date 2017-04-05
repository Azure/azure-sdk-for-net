// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Network.Definition;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to virtual network management API in Azure.
    /// </summary>
    public interface INetworks  :
        ISupportsCreating<Network.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetwork>,
        IHasManager<INetworkManager>,
        IHasInner<IVirtualNetworksOperations>
    {
    }
}