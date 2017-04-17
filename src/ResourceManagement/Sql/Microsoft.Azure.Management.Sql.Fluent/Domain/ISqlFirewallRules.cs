// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to SQL FirewallRule management API.
    /// </summary>
    public interface ISqlFirewallRules  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByParent,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Sql.Fluent.ISqlManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Sql.Fluent.IServersOperations>
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group and SQLServer.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <return>The list of SQLDatabases in a SQLServer.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Gets the SQLDatabase based on the SQLServer.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <return>The list of SQLDatabases in a SQLServer.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(ISqlServer sqlServer);

        /// <summary>
        /// Gets the SQLDatabase based on the resource group name, SQLServer name and FirewallRule name.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <param name="name">The name of SQLDatabase.</param>
        /// <return>An immutable representation of the SQLDatabase.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule GetBySqlServer(string resourceGroup, string sqlServerName, string name);

        /// <summary>
        /// Gets the SQLDatabase based on the SQLServer instance and FirewallRule name.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <param name="name">The name of SQLDatabase.</param>
        /// <return>An immutable representation of the SQLDatabase.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule GetBySqlServer(ISqlServer sqlServer, string name);
    }
}