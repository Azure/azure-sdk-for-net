// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.Provisioning.PostgreSql
{
    /// <summary>
    /// Represents a PostGreSql flexible database.
    /// </summary>
    public class PostgreSqlFlexibleServerDatabase : Resource<PostgreSqlFlexibleServerDatabaseData>
    {
        private const string ResourceTypeName = "Microsoft.DBforPostgreSQL/flexibleServers/databases";
        private static PostgreSqlFlexibleServerDatabaseData Empty(string name)
            => ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerDatabaseData();

                /// <summary>
        /// Creates a new instance of the <see cref="PostgreSqlFlexibleServer"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public PostgreSqlFlexibleServerDatabase(
            IConstruct scope,
            PostgreSqlFlexibleServer? parent = null,
            string name = "db",
            string version = PostgreSqlFlexibleServer.DefaultVersion)
        : this(scope, parent, name, version, false, (name) => ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerDatabaseData(name: name))
        {
        }

        private PostgreSqlFlexibleServerDatabase(
            IConstruct scope,
            PostgreSqlFlexibleServer? parent,
            string name,
            string version = PostgreSqlFlexibleServer.DefaultVersion,
            bool isExisting = false,
            Func<string, PostgreSqlFlexibleServerDatabaseData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PostgreSqlFlexibleServer"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static PostgreSqlFlexibleServerDatabase FromExisting(IConstruct scope, string name, PostgreSqlFlexibleServer? parent)
            => new PostgreSqlFlexibleServerDatabase(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<PostgreSqlFlexibleServer>() ?? throw new InvalidOperationException("A PostgreSQL server was not found in the construct.");
        }
    }
}
