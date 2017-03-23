// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithIPAddress,
        IWithIPAddressRange,
        IWithCreate
    {
    }

    /// <summary>
    /// The first stage of the SQL Server definition.
    /// </summary>
    public interface IBlank  :
        IWithIPAddressRange,
        IWithIPAddress
    {
    }

    /// <summary>
    /// The SQL Firewall Rule definition to set the starting IP Address for the server.
    /// </summary>
    public interface IWithIPAddressRange 
    {
        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIPAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIPAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithCreate WithIPAddressRange(string startIPAddress, string endIPAddress);
    }

    /// <summary>
    /// The SQL Firewall Rule definition to set the starting IP Address for the server.
    /// </summary>
    public interface IWithIPAddress 
    {
        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithCreate WithIPAddress(string ipAddress);
    }

    /// <summary>
    /// A SQL Server definition with sufficient inputs to create a new
    /// SQL Server in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>
    {
    }
}