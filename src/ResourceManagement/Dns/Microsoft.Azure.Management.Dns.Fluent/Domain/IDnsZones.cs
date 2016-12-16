// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using DnsZone.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to Dns zone management API in Azure.
    /// </summary>
    public interface IDnsZones  :
        ISupportsCreating<DnsZone.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        ISupportsGettingById<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>
    {
    }
}