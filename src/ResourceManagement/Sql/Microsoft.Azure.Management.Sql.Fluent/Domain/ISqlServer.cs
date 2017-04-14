// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Databases;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.ElasticPools;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.FirewallRules;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server.
    /// </summary>
    public interface ISqlServer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Sql.Fluent.ISqlManager,Models.ServerInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlServer.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Sql.Fluent.ISqlManager>
    {
        /// <summary>
        /// Gets returns entry point to manage ElasticPools in SqlServer.
        /// </summary>
        SqlServer.ElasticPools.IElasticPools ElasticPools { get; }

        /// <summary>
        /// Returns all the recommended elastic pools for the server.
        /// </summary>
        /// <return>List of recommended elastic pools for the server.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> ListRecommendedElasticPools();

        /// <return>Returns the list of usages (ServerMetric) of Azure SQL Server.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> ListUsages();

        /// <return>The list of information on all service objectives.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> ListServiceObjectives();

        /// <summary>
        /// Gets entry point to manage Databases in SqlServer.
        /// </summary>
        SqlServer.Databases.IDatabases Databases { get; }

        /// <summary>
        /// Gets the administrator login user name for the SQL Server.
        /// </summary>
        string AdministratorLogin { get; }

        /// <summary>
        /// Gets the information on a particular Sql Server Service Objective.
        /// </summary>
        /// <param name="serviceObjectiveName">Name of the service objective to be fetched.</param>
        /// <return>Information of the service objective.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceObjective GetServiceObjective(string serviceObjectiveName);

        /// <summary>
        /// Gets fully qualified name of the SQL Server.
        /// </summary>
        string FullyQualifiedDomainName { get; }

        /// <summary>
        /// Gets returns entry point to manage FirewallRules in SqlServer.
        /// </summary>
        SqlServer.FirewallRules.IFirewallRules FirewallRules { get; }

        /// <summary>
        /// Gets the version of the SQL Server.
        /// </summary>
        string Version { get; }
    }
}