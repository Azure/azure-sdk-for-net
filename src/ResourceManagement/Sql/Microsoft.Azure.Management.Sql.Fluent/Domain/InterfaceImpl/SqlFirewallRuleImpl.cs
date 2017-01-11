// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using SqlFirewallRule.Definition;
    using SqlFirewallRule.Update;
    using Models;

    internal partial class SqlFirewallRuleImpl 
    {
        /// <summary>
        /// Gets kind of SQL Server that contains this firewall rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this firewall rule belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.EndIpAddress
        {
            get
            {
                return this.EndIpAddress();
            }
        }

        /// <summary>
        /// Gets region of SQL Server that contains this firewall rule.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.StartIpAddress
        {
            get
            {
                return this.StartIpAddress();
            }
        }

        /// <summary>
        /// Deletes the firewall rule.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIpAddress">Start IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        SqlFirewallRule.Update.IUpdate SqlFirewallRule.Update.IWithStartIpAddress.WithStartIpAddress(string startIpAddress)
        {
            return this.WithStartIpAddress(startIpAddress) as SqlFirewallRule.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule;
        }

        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="endIpAddress">End IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        SqlFirewallRule.Update.IUpdate SqlFirewallRule.Update.IWithEndIpAddress.WithEndIpAddress(string endIpAddress)
        {
            return this.WithEndIpAddress(endIpAddress) as SqlFirewallRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIpAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIpAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRule.Definition.IWithCreate SqlFirewallRule.Definition.IWithIpAddressRange.WithIpAddressRange(string startIpAddress, string endIpAddress)
        {
            return this.WithIpAddressRange(startIpAddress, endIpAddress) as SqlFirewallRule.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRule.Definition.IWithCreate SqlFirewallRule.Definition.IWithIpAddress.WithIpAddress(string ipAddress)
        {
            return this.WithIpAddress(ipAddress) as SqlFirewallRule.Definition.IWithCreate;
        }
    }
}