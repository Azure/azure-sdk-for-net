// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using PublicIpAddress.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to public IP address management.
    /// </summary>
    public interface IPublicIpAddresses  :
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsCreating<PublicIpAddress.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>
    {
    }
}