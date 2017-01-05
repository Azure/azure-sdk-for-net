// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using SqlDatabase.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to SQL Database management API.
    /// </summary>
    public interface ISqlDatabases  :
        ISupportsCreating<SqlDatabase.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsGettingById<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        ISupportsBatchCreation<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        ISupportsDeletingByParent
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group and SQLServer.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <return>The list of SQLDatabases in a SQLServer.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListBySqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Gets the SQLDatabase based on the SQLServer.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <return>The list of SQLDatabases in a SQLServer.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListBySqlServer(IGroupableResource sqlServer);

        /// <summary>
        /// Gets the SQLDatabase based on the resource group name, SQLServer name and SQLDatabase name.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <param name="name">The name of SQLDatabase.</param>
        /// <return>An immutable representation of the SQLDatabase.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase GetBySqlServer(string resourceGroup, string sqlServerName, string name);

        /// <summary>
        /// Gets the SQLDatabase based on the SQLServer instance and SQLDatabase name.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <param name="name">The name of SQLDatabase.</param>
        /// <return>An immutable representation of the SQLDatabase.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase GetBySqlServer(IGroupableResource sqlServer, string name);
    }
}