// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using SqlFirewallRule.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server FirewallRule.
    /// </summary>
    public interface ISqlFirewallRule  :
        IIndependentChild,
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        IUpdatable<SqlFirewallRule.Update.IUpdate>,
        IWrapper<Models.ServerFirewallRuleInner>
    {
        /// <return>The end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.</return>
        string EndIpAddress { get; }

        /// <return>Name of the SQL Server to which this firewall rule belongs.</return>
        string SqlServerName { get; }

        /// <return>Kind of SQL Server that contains this firewall rule.</return>
        string Kind { get; }

        /// <return>Region of SQL Server that contains this firewall rule.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }

        /// <return>The start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.</return>
        string StartIpAddress { get; }

        /// <summary>
        /// Deletes the firewall rule.
        /// </summary>
        void Delete();
    }
}