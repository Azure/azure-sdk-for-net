// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using SqlServer.Definition;

    /// <summary>
    /// Entry point to SQL Server management API.
    /// </summary>
    public interface ISqlServers  :
        ISupportsCreating<SqlServer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsGettingById<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>
    {
    }
}