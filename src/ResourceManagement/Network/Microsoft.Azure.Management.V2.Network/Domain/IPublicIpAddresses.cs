/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition;
    /// <summary>
    /// Entry point to public IP address management.
    /// </summary>
    public interface IPublicIpAddresses  :
        ISupportsListing<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>,
        ISupportsCreating<Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>,
        ISupportsDeletingByGroup
    {
    }
}