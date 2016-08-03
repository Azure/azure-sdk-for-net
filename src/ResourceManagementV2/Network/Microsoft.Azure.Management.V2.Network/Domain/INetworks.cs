/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network.Network.Definition;
    /// <summary>
    /// Entry point to virtual network management API in Azure.
    /// </summary>
    public interface INetworks  :
        ISupportsCreating<IBlank>,
        ISupportsListing<INetwork>,
        ISupportsListingByGroup<INetwork>,
        ISupportsGettingByGroup<INetwork>,
        ISupportsGettingById<INetwork>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}