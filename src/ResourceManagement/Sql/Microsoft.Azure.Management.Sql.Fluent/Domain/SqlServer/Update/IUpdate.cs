// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The template for a SQLServer update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IWithAdministratorPassword,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IWithElasticPool,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IWithDatabase,
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IWithFirewallRule
    {
    }

    /// <summary>
    /// A SQL Server definition for specifying the firewall rule.
    /// </summary>
    public interface IWithFirewallRule 
    {
        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IP address for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewFirewallRule(string ipAddress);

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">IP address for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewFirewallRule(string startIPAddress, string endIPAddress);

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIPAddress">Start IP address for the firewall rule.</param>
        /// <param name="endIPAddress">End IP address for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewFirewallRule(string startIPAddress, string endIPAddress, string firewallRuleName);

        /// <summary>
        /// Removes firewall rule from the SQL Server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithoutFirewallRule(string firewallRuleName);
    }

    /// <summary>
    /// A SQL Server definition for specifying the databases.
    /// </summary>
    public interface IWithDatabase 
    {
        /// <summary>
        /// Create new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithNewDatabase(string databaseName);

        /// <summary>
        /// Remove database from the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate WithoutDatabase(string databaseName);
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