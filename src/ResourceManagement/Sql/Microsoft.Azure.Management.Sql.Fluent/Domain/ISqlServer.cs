// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using SqlServer.FirewallRules;
    using System.Collections.Generic;
    using Models;
    using SqlServer.Update;
    using SqlServer.ElasticPools;
    using SqlServer.Databases;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server.
    /// </summary>
    public interface ISqlServer  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        IUpdatable<SqlServer.Update.IUpdate>,
        IHasManager<Microsoft.Azure.Management.Sql.Fluent.SqlManager>,
        IWrapper<Models.ServerInner>
    {
        /// <return>The administrator login user name for the SQL Server.</return>
        string AdministratorLogin { get; }

        /// <return>Entry point to manage Databases in SqlServer.</return>
        SqlServer.Databases.IDatabases Databases { get; }

        /// <summary>
        /// Gets the information on a particular Sql Server Service Objective.
        /// </summary>
        /// <param name="serviceObjectiveName">Name of the service objective to be fetched.</param>
        /// <return>Information of the service objective.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceObjective GetServiceObjective(string serviceObjectiveName);

        /// <return>Returns the list of usages (ServerMetric) of Azure SQL Server.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> ListUsages();

        /// <return>Fully qualified name of the SQL Server.</return>
        string FullyQualifiedDomainName { get; }

        /// <return>Returns entry point to manage ElasticPools in SqlServer.</return>
        SqlServer.ElasticPools.IElasticPools ElasticPools { get; }

        /// <summary>
        /// Returns all the recommended elastic pools for the server.
        /// </summary>
        /// <return>List of recommended elastic pools for the server.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> ListRecommendedElasticPools();

        /// <return>The list of information on all service objectives.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> ListServiceObjectives();

        /// <return>The version of the SQL Server.</return>
        string Version { get; }

        /// <return>Returns entry point to manage FirewallRules in SqlServer.</return>
        SqlServer.FirewallRules.IFirewallRules FirewallRules { get; }
    }
}