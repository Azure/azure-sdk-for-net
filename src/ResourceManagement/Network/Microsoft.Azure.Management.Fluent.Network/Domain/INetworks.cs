// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Network.Network.Definition;
    /// <summary>
    /// Entry point to virtual network management API in Azure.
    /// </summary>
    public interface INetworks  :
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Network.Network.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Network.INetwork>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Network.INetwork>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Network.INetwork>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Network.INetwork>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Network.INetwork>
    {
    }
}