// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using SqlFirewallRule.Definition;
    using SqlFirewallRules.SqlFirewallRulesCreatable;
    using SqlServer.FirewallRules;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of SqlServer.FirewallRules, which enables the creating the firewall rules from the SQLServer directly.
    /// </summary>
    internal partial class FirewallRulesImpl :
        IFirewallRules
    {
        private string resourceGroupName;
        private string sqlServerName;
        private ISqlFirewallRulesCreatable sqlFirewallRules;

        internal FirewallRulesImpl(IServersOperations innerCollection, SqlManager manager, string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlFirewallRules = new SqlFirewallRulesImpl(innerCollection, manager);
        }

        internal ISqlFirewallRules SqlFirewallRules()
        {
            return this.sqlFirewallRules;
        }

        public ISqlFirewallRule Get(string firewallRuleName)
        {
            return this.sqlFirewallRules.GetBySqlServer(this.resourceGroupName, this.sqlServerName, firewallRuleName);
        }

        public IBlank Define(string firewallRuleName)
        {
            return this.sqlFirewallRules.DefinedWithSqlServer(this.resourceGroupName, this.sqlServerName, firewallRuleName);
        }

        public async Task DeleteAsync(string firewallRuleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlFirewallRules.DeleteByParentAsync(this.resourceGroupName, this.sqlServerName, firewallRuleName, cancellationToken);
        }

        public IList<ISqlFirewallRule> List()
        {
            return this.sqlFirewallRules.ListBySqlServer(this.resourceGroupName, this.sqlServerName);
        }

        public void Delete(string firewallRuleName)
        {
            this.sqlFirewallRules.DeleteByParent(this.resourceGroupName, this.sqlServerName, firewallRuleName);
        }
    }
}