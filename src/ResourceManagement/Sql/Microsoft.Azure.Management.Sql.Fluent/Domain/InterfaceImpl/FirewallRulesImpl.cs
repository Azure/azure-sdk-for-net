// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using SqlFirewallRule.Definition;
    using SqlFirewallRules.SqlFirewallRulesCreatable;
    using SqlServer.FirewallRules;
    using Models;
    using System.Collections.Generic;

    internal partial class FirewallRulesImpl 
    {
        /// <summary>
        /// Gets a particular firewall rule.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to get.</param>
        /// <return>Returns the SqlFirewall rule with in the SQL Server.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule SqlServer.FirewallRules.IFirewallRules.Get(string firewallRuleName)
        {
            return this.Get(firewallRuleName) as Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule;
        }

        /// <summary>
        /// Delete specified firewall rule in the server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to delete.</param>
        /// <return>Observable for the delete operation.</return>
        async Task SqlServer.FirewallRules.IFirewallRules.DeleteAsync(string firewallRuleName, CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(firewallRuleName, cancellationToken);
        }

        /// <summary>
        /// Returns all the firewall rules for the server.
        /// </summary>
        /// <return>List of firewall rules for the server.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> SqlServer.FirewallRules.IFirewallRules.List()
        {
            return this.List() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        /// <summary>
        /// Delete specified firewall rule in the server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to delete.</param>
        void SqlServer.FirewallRules.IFirewallRules.Delete(string firewallRuleName)
        {
 
            this.Delete(firewallRuleName);
        }

        /// <summary>
        /// Creates a new firewall rule in SQL Server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to be created.</param>
        /// <return>Returns a stage to specify arguments of the firewall rule.</return>
        SqlFirewallRule.Definition.IBlank SqlServer.FirewallRules.IFirewallRules.Define(string firewallRuleName)
        {
            return this.Define(firewallRuleName) as SqlFirewallRule.Definition.IBlank;
        }
    }
}