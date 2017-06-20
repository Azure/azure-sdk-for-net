// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to SQL Elastic Pool management API.
    /// </summary>
    public interface ISqlElasticPools  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<SqlElasticPool.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByParent,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Sql.Fluent.ISqlManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolsOperations>
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group and SQLServer.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <return>The list of SQLElasticPools in a SQLServer.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> ListBySqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Gets the SQLElasticPool based on the SQLServer.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <return>The list of SQLElasticPools in a SQLServer.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> ListBySqlServer(ISqlServer sqlServer);

        /// <summary>
        /// Gets the SQLElasticPool based on the resource group name, SQLServer name and SQLElasticPool name.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <param name="name">The name of SQLElasticPool.</param>
        /// <return>An immutable representation of the SQLElasticPool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool GetBySqlServer(string resourceGroup, string sqlServerName, string name);

        /// <summary>
        /// Gets the SQLElasticPool based on the SQLServer instance and SQLElasticPool name.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <param name="name">The name of SQLElasticPool.</param>
        /// <return>An immutable representation of the SQLElasticPool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool GetBySqlServer(ISqlServer sqlServer, string name);
    }
}