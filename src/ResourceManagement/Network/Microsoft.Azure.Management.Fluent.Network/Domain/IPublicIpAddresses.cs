// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Network.PublicIpAddress.Definition;
    /// <summary>
    /// Entry point to public IP address management.
    /// </summary>
    public interface IPublicIpAddresses  :
        ISupportsListing<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress>,
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Network.PublicIpAddress.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress>,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress>
    {
    }
}