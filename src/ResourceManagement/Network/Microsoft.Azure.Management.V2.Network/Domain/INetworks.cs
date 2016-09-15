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
        ISupportsCreating<Microsoft.Azure.Management.V2.Network.Network.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.V2.Network.INetwork>,
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Network.INetwork>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Network.INetwork>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Network.INetwork>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}