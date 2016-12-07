// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using DnsZone.Definition;

    /// <summary>
    /// Entry point to Dns zone management API in Azure.
    /// </summary>
    public interface IDnsZones  :
        ISupportsCreating<DnsZone.Definition.IBlank>,
        ISupportsListing<IDnsZone>,
        ISupportsListingByGroup<IDnsZone>,
        ISupportsGettingByGroup<IDnsZone>,
        ISupportsGettingById<IDnsZone>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<IDnsZone>
    {
    }
}