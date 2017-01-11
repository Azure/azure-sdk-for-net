// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServer.FirewallRules
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to access FirewallRules from the SQL Server.
    /// </summary>
    public interface IFirewallRules 
    {
        /// <summary>
        /// Gets a particular firewall rule.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to get.</param>
        /// <return>Returns the SqlFirewall rule with in the SQL Server.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule Get(string firewallRuleName);

        /// <summary>
        /// Creates a new firewall rule in SQL Server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to be created.</param>
        /// <return>Returns a stage to specify arguments of the firewall rule.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IBlank Define(string firewallRuleName);

        /// <summary>
        /// Delete specified firewall rule in the server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to delete.</param>
        /// <return>Observable for the delete operation.</return>
        Task DeleteAsync(string firewallRuleName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns all the firewall rules for the server.
        /// </summary>
        /// <return>List of firewall rules for the server.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> List();

        /// <summary>
        /// Delete specified firewall rule in the server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to delete.</param>
        void Delete(string firewallRuleName);
    }
}