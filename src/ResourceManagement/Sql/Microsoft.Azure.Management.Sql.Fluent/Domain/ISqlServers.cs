// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using SqlServer.Definition;

    /// <summary>
    /// Entry point to SQL Server management API.
    /// </summary>
    public interface ISqlServers  :
        ISupportsCreating<SqlServer.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsGettingById<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISupportsBatchDeletion,
        IHasManager<ISqlManager>,
        IHasInner<IServersOperations>
    {
    }
}