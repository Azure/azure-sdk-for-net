// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using SqlFirewallRules.SqlFirewallRulesCreatable;
    using Models;
    using System.Collections.Generic;

    internal partial class SqlFirewallRulesImpl 
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <return>The list of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>.ListByParent(string resourceGroupName, string parentName)
        {
            return this.ListByParent(resourceGroupName, parentName) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <param name="name">The name of resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsGettingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>.GetByParent(string resourceGroup, string parentName, string name)
        {
            return this.GetByParent(resourceGroup, parentName, name) as Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule;
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

        /// <summary>
        /// Gets the SQLDatabase based on the resource group name, SQLServer name and FirewallRule name.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <param name="name">The name of SQLDatabase.</param>
        /// <return>An immutable representation of the SQLDatabase.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRules.GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetBySqlServer(resourceGroup, sqlServerName, name) as Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule;
        }

        /// <summary>
        /// Gets the SQLDatabase based on the SQLServer instance and FirewallRule name.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <param name="name">The name of SQLDatabase.</param>
        /// <return>An immutable representation of the SQLDatabase.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRules.GetBySqlServer(IGroupableResource sqlServer, string name)
        {
            return this.GetBySqlServer(sqlServer, name) as Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group and SQLServer.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of SQLServer.</param>
        /// <return>The list of SQLDatabases in a SQLServer.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRules.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName) as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        /// <summary>
        /// Gets the SQLDatabase based on the SQLServer.
        /// </summary>
        /// <param name="sqlServer">The instance of SQLServer.</param>
        /// <return>The list of SQLDatabases in a SQLServer.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRules.ListBySqlServer(IGroupableResource sqlServer)
        {
            return this.ListBySqlServer(sqlServer) as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        SqlFirewallRule.Definition.IBlank SqlFirewallRules.SqlFirewallRulesCreatable.ISqlFirewallRulesCreatable.DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string firewallRuleName)
        {
            return this.DefinedWithSqlServer(resourceGroupName, sqlServerName, firewallRuleName) as SqlFirewallRule.Definition.IBlank;
        }
    }
}