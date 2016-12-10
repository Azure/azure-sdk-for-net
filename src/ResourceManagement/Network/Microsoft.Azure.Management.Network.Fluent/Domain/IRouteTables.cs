// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using RouteTable.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to route table management.
    /// </summary>
    public interface IRouteTables :
        ISupportsCreating<RouteTable.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IRouteTable>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IRouteTable>
    {
    }
}