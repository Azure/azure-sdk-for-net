// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading.Tasks;
    using Models;
    using SqlServer.Definition;
    using SqlFirewallRule.Definition;
    using System.Collections.Generic;
    using SqlServer.ElasticPools;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using SqlServer.Databases;
    using System.Threading;
    using SqlServer.Update;
    using SqlServer.FirewallRules;
    
    using SqlDatabase.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using SqlElasticPool.Definition;

    internal partial class SqlServerImpl 
    {
        /// <summary>
        /// Creates new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithDatabase.WithNewDatabase(string databaseName)
        {
            return this.WithNewDatabase(databaseName) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Remove database from the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithDatabase.WithoutDatabase(string databaseName)
        {
            return this.WithoutDatabase(databaseName) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Create new database in the SQL Server.
        /// </summary>
        /// <param name="databaseName">Name of the database to be created.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithDatabase.WithNewDatabase(string databaseName)
        {
            return this.WithNewDatabase(databaseName) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServer Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.ISqlServer;
        }

        /// <summary>
        /// Sets the administrator login password.
        /// </summary>
        /// <param name="administratorLoginPassword">Password for administrator login.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithAdministratorPassword.WithAdministratorPassword(string administratorLoginPassword)
        {
            return this.WithAdministratorPassword(administratorLoginPassword) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the administrator login password.
        /// </summary>
        /// <param name="administratorLoginPassword">Password for administrator login.</param>
        /// <return>Next stage of the update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithAdministratorPassword.WithAdministratorPassword(string administratorLoginPassword)
        {
            return this.WithAdministratorPassword(administratorLoginPassword) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Creates new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <param name="databaseNames">Names of the database to be included in the elastic pool.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithElasticPool.WithNewElasticPool(string elasticPoolName, string elasticPoolEdition, params string[] databaseNames)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition, databaseNames) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithElasticPool.WithNewElasticPool(string elasticPoolName, string elasticPoolEdition)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes elastic pool from the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithElasticPool.WithoutElasticPool(string elasticPoolName)
        {
            return this.WithoutElasticPool(elasticPoolName) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Create new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <param name="databaseNames">Names of the database to be included in the elastic pool.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithElasticPool.WithNewElasticPool(string elasticPoolName, string elasticPoolEdition, params string[] databaseNames)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition, databaseNames) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Create new elastic pool in the SQL Server.
        /// </summary>
        /// <param name="elasticPoolName">Name of the elastic pool to be created.</param>
        /// <param name="elasticPoolEdition">Edition of the elastic pool.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithElasticPool.WithNewElasticPool(string elasticPoolName, string elasticPoolEdition)
        {
            return this.WithNewElasticPool(elasticPoolName, elasticPoolEdition) as SqlServer.Update.IUpdate;
        }

        /// <return>Fully qualified name of the SQL Server.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.FullyQualifiedDomainName
        {
            get
            {
                return this.FullyQualifiedDomainName() as string;
            }
        }

        /// <summary>
        /// Gets the information on a particular Sql Server Service Objective.
        /// </summary>
        /// <param name="serviceObjectiveName">Name of the service objective to be fetched.</param>
        /// <return>Information of the service objective.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceObjective Microsoft.Azure.Management.Sql.Fluent.ISqlServer.GetServiceObjective(string serviceObjectiveName)
        {
            return this.GetServiceObjective(serviceObjectiveName) as Microsoft.Azure.Management.Sql.Fluent.IServiceObjective;
        }

        /// <return>The version of the SQL Server.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.Version
        {
            get
            {
                return this.Version() as string;
            }
        }

        /// <return>Returns entry point to manage ElasticPools in SqlServer.</return>
        SqlServer.ElasticPools.IElasticPools Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ElasticPools
        {
            get
            {
                return this.ElasticPools() as SqlServer.ElasticPools.IElasticPools;
            }
        }

        /// <return>The list of information on all service objectives.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListServiceObjectives()
        {
            return this.ListServiceObjectives() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective>;
        }

        /// <return>Returns the list of usages (ServerMetric) of Azure SQL Server.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListUsages()
        {
            return this.ListUsages() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric>;
        }

        /// <summary>
        /// Returns all the recommended elastic pools for the server.
        /// </summary>
        /// <return>List of recommended elastic pools for the server.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> Microsoft.Azure.Management.Sql.Fluent.ISqlServer.ListRecommendedElasticPools()
        {
            return this.ListRecommendedElasticPools() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool>;
        }

        /// <return>The administrator login user name for the SQL Server.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServer.AdministratorLogin
        {
            get
            {
                return this.AdministratorLogin() as string;
            }
        }

        /// <return>Entry point to manage Databases in SqlServer.</return>
        SqlServer.Databases.IDatabases Microsoft.Azure.Management.Sql.Fluent.ISqlServer.Databases
        {
            get
            {
                return this.Databases() as SqlServer.Databases.IDatabases;
            }
        }

        /// <return>Returns entry point to manage FirewallRules in SqlServer.</return>
        SqlServer.FirewallRules.IFirewallRules Microsoft.Azure.Management.Sql.Fluent.ISqlServer.FirewallRules
        {
            get
            {
                return this.FirewallRules() as SqlServer.FirewallRules.IFirewallRules;
            }
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRule.WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIpAddress">Start ipAddress for the firewall rule.</param>
        /// <param name="endIpAddress">End ipAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRule.WithNewFirewallRule(string startIpAddress, string endIpAddress)
        {
            return this.WithNewFirewallRule(startIpAddress, endIpAddress) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIpAddress">Start ipAddress for the firewall rule.</param>
        /// <param name="endIpAddress">End ipAddress for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithCreate SqlServer.Definition.IWithFirewallRule.WithNewFirewallRule(string startIpAddress, string endIpAddress, string firewallRuleName)
        {
            return this.WithNewFirewallRule(startIpAddress, endIpAddress, firewallRuleName) as SqlServer.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes firewall rule from the SQL Server.
        /// </summary>
        /// <param name="firewallRuleName">Name of the firewall rule to be removed.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithoutFirewallRule(string firewallRuleName)
        {
            return this.WithoutFirewallRule(firewallRuleName) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="ipAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Create new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIpAddress">Start ipAddress for the firewall rule.</param>
        /// <param name="endIpAddress">IpAddress for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithNewFirewallRule(string startIpAddress, string endIpAddress)
        {
            return this.WithNewFirewallRule(startIpAddress, endIpAddress) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Creates new firewall rule in the SQL Server.
        /// </summary>
        /// <param name="startIpAddress">Start ipAddress for the firewall rule.</param>
        /// <param name="endIpAddress">End ipAddress for the firewall rule.</param>
        /// <param name="firewallRuleName">Name for the firewall rule.</param>
        /// <return>Next stage of the SQL Server update.</return>
        SqlServer.Update.IUpdate SqlServer.Update.IWithFirewallRule.WithNewFirewallRule(string startIpAddress, string endIpAddress, string firewallRuleName)
        {
            return this.WithNewFirewallRule(startIpAddress, endIpAddress, firewallRuleName) as SqlServer.Update.IUpdate;
        }

        /// <summary>
        /// Sets the administrator login user name.
        /// </summary>
        /// <param name="administratorLogin">Administrator login user name.</param>
        /// <return>Next stage of the SQL Server definition.</return>
        SqlServer.Definition.IWithAdministratorPassword SqlServer.Definition.IWithAdministratorLogin.WithAdministratorLogin(string administratorLogin)
        {
            return this.WithAdministratorLogin(administratorLogin) as SqlServer.Definition.IWithAdministratorPassword;
        }
    }
}