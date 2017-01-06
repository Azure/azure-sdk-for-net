// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using SqlElasticPool.Definition;
    using SqlElasticPools.SqlElasticPoolsCreatable;
    using Models;
    using System.Collections.Generic;

    internal partial class SqlElasticPoolsImpl 
    {
        /// <summary>
        /// Gets the SQLElasticPool based on the resource group name, SQLServer name and SQLElasticPool name.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <param name="name">The name of SQLElasticPool.</param>
        /// <return>An immutable representation of the SQLElasticPool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPools.GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroup, sqlServerName, name) as Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool;
        }

        /// <summary>
        /// Gets the SQLElasticPool based on the SQLServer instance and SQLElasticPool name.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <param name="name">The name of SQLElasticPool.</param>
        /// <return>An immutable representation of the SQLElasticPool.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPools.GetBySqlServer(IGroupableResource sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name) as Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group and SQLServer.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <return>The list of SQLElasticPools in a SQLServer.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPools.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName) as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>;
        }

        /// <summary>
        /// Gets the SQLElasticPool based on the SQLServer.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <return>The list of SQLElasticPools in a SQLServer.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPools.ListBySqlServer(IGroupableResource sqlServer)
        {
            return this.ListBySqlServer(sqlServer) as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>;
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is Creatable.create().
        /// Note that the Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        SqlElasticPool.Definition.IBlank Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsCreating<SqlElasticPool.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as SqlElasticPool.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <return>The list of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.ListByParent(string resourceGroupName, string parentName)
        {
            return this.ListByParent(resourceGroupName, parentName) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <param name="name">The name of resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsGettingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>.GetByParent(string resourceGroup, string parentName, string name)
        {
            return this.GetByParent(resourceGroup, parentName, name) as Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool;
        }

        SqlElasticPool.Definition.IBlank SqlElasticPools.SqlElasticPoolsCreatable.ISqlElasticPoolsCreatable.DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string elasticPoolName, Region region)
        {
            return this.DefinedWithSqlServer(resourceGroupName, sqlServerName, elasticPoolName, region) as SqlElasticPool.Definition.IBlank;
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">The group the resource is part of.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>An observable to the request.</return>
        async Task Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsDeletingByParent.DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByParentAsync(groupName, parentName, name, cancellationToken);
        }
    }
}