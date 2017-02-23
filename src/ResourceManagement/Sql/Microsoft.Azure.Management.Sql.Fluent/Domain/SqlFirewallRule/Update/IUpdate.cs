// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL Firewall Rule definition to set the starting IP Address for the server.
    /// </summary>
    public interface IWithStartIPAddress 
    {
        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIPAddress">Start IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update.IUpdate WithStartIPAddress(string startIPAddress);
    }

    /// <summary>
    /// The SQL Firewall Rule definition to set the starting IP Address for the server.
    /// </summary>
    public interface IWithEndIPAddress 
    {
        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="endIPAddress">End IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update.IUpdate WithEndIPAddress(string endIPAddress);
    }

    /// <summary>
    /// The template for a SqlFirewallRule update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IWithEndIPAddress,
        IWithStartIPAddress,
        IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>
    {
    }
}