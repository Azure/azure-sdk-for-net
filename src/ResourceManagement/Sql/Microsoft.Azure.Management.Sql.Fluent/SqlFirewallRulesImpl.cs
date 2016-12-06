// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using SqlFirewallRules.SqlFirewallRulesCreatable;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQLElasticPools and its parent interfaces.
    /// </summary>
    internal partial class SqlFirewallRulesImpl :
        IndependentChildrenImpl<ISqlFirewallRule, SqlFirewallRuleImpl, ServerFirewallRuleInner, IServersOperations, SqlManager>,
        ISqlFirewallRules,
        ISupportsGettingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        ISupportsListingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        ISqlFirewallRulesCreatable
    {
        internal SqlFirewallRulesImpl(IServersOperations innerCollection, SqlManager manager)
            : base(innerCollection, manager)
        {
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return new List<ISqlFirewallRule>(this.ListByParent(resourceGroupName, sqlServerName));
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(IGroupableResource sqlServer)
        {
            return new List<ISqlFirewallRule>(this.ListByParent(sqlServer));
        }

        public override async Task<PagedList<ISqlFirewallRule>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapList(new PagedList<ServerFirewallRuleInner>(await this.innerCollection.ListFirewallRulesAsync(resourceGroupName, parentName, cancellationToken)));
        }

        public ISqlFirewallRule GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetByParent(resourceGroup, sqlServerName, name);
        }

        public ISqlFirewallRule GetBySqlServer(IGroupableResource sqlServer, string name)
        {
            return this.GetByParent(sqlServer, name);
        }

        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.DeleteFirewallRuleAsync(groupName, parentName, name, cancellationToken);
        }

        public ICreatable<ISqlFirewallRule> DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string firewallRuleName)
        {
            ServerFirewallRuleInner inner = new ServerFirewallRuleInner();

            return new SqlFirewallRuleImpl(
                firewallRuleName,
                inner,
                this.innerCollection).WithExistingParentResource(resourceGroupName, sqlServerName);
        }

        public override async Task<ISqlFirewallRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await this.innerCollection.GetFirewallRuleAsync(resourceGroup, parentName, name, cancellationToken));
        }

        protected override SqlFirewallRuleImpl WrapModel(string name)
        {
            throw new NotImplementedException("Should never hit this code, currently not exposed");
        }

        protected override ISqlFirewallRule WrapModel(ServerFirewallRuleInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new SqlFirewallRuleImpl(inner.Name, inner, this.innerCollection);
        }
    }
}