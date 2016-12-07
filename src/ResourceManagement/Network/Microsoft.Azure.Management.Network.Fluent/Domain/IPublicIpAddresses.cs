// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Network.Fluent.PublicIpAddress.Definition;
    /// <summary>
    /// Entry point to public IP address management.
    /// </summary>
    public interface IPublicIpAddresses  :
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsCreating<Microsoft.Azure.Management.Network.Fluent.PublicIpAddress.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>
    {
    }
}