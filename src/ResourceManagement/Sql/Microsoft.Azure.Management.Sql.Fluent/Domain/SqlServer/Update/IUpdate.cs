// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The template for a SQLServer update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        IWithAdministratorPassword,
        IWithElasticPool,
        IWithDatabase,
        IWithFirewallRule
    {
    }

    /// <summary>
    /// A SQL Server definition for specifying the firewall rule.
    /// </summary>
    public interface IWithFirewallRule 
    {
        /// <summary>
        /// Removes firewall rule from the SQL Server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithoutFirewallRule(string firewallRuleName);

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewFirewallRule(string ipAddress);

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIpAddress">Start ipAddress for the firewall rule.</param>
        /// <param name="endIpAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewFirewallRule(string startIpAddress, string endIpAddress);

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIpAddress">Start ipAddress for the firewall rule.</param>
        /// <param name="endIpAddress">End ipAddress for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewFirewallRule(string startIpAddress, string endIpAddress, string firewallRuleName);
    }

    /// <summary>
    /// A SQL Server definition for specifying the databases.
    /// </summary>
    public interface IWithDatabase 
    {
        /// <summary>
        /// Remove database from the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithoutDatabase(string databaseName);

        /// <summary>
        /// Create new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewDatabase(string databaseName);
    }

    /// <summary>
    /// A SQL Server definition for specifying elastic pool.
    /// </summary>
    public interface IWithElasticPool 
    {
        /// <summary>
        /// Removes elastic pool from the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithoutElasticPool(string elasticPoolName);

        /// <summary>
        /// Create new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <param name="databaseNames">Names of the database to be included in the elastic pool.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewElasticPool(string elasticPoolName, string elasticPoolEdition, params string[] databaseNames);

        /// <summary>
        /// Create new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewElasticPool(string elasticPoolName, string elasticPoolEdition);
    }

    /// <summary>
    /// A SQL Server definition setting admin user password.
    /// </summary>
    public interface IWithAdministratorPassword 
    {
        /// <summary>
        /// Sets the administrator login password.
        /// </summary>
        /// <param name="administratorLoginPassword">Password for administrator login.</param>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithAdministratorPassword(string administratorLoginPassword);
    }
}