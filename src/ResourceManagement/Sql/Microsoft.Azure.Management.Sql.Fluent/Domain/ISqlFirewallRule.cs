// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server FirewallRule.
    /// </summary>
    public interface ISqlFirewallRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChild<Microsoft.Azure.Management.Sql.Fluent.ISqlManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlFirewallRule.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ServerFirewallRuleInner>
    {
        /// <summary>
        /// Gets name of the SQL Server to which this firewall rule belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets kind of SQL Server that contains this firewall rule.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets the start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string StartIPAddress { get; }

        /// <summary>
        /// Gets region of SQL Server that contains this firewall rule.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Deletes the firewall rule.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string EndIPAddress { get; }
    }
}