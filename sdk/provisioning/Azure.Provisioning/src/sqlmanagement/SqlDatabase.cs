// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a SQL database.
    /// </summary>
    public class SqlDatabase : Resource<SqlDatabaseData>
    {
        private const string ResourceTypeName = "Microsoft.Sql/servers/databases";
        private static SqlDatabaseData Empty(string name) => ArmSqlModelFactory.SqlDatabaseData();

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabase"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SqlDatabase(IConstruct scope, SqlServer? parent = null, string name = "db", string version = SqlServer.DefaultVersion, AzureLocation? location = default)
            : this(scope, parent, name, version, location, (name) => ArmSqlModelFactory.SqlDatabaseData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        private SqlDatabase(IConstruct scope,
            SqlServer? parent,
            string name,
            string version = SqlServer.DefaultVersion,
            AzureLocation? location = default,
            Func<string, SqlDatabaseData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Gets the connection string for the <see cref="SqlDatabase"/>.
        /// </summary>
        /// <param name="passwordSecret">The password.</param>
        /// <param name="userName">The user name.</param>
        /// <returns></returns>
        public SqlDatabaseConnectionString GetConnectionString(Parameter passwordSecret, string userName = "appUser")
            => new SqlDatabaseConnectionString(this, passwordSecret, userName);

        /// <summary>
        /// Creates a new instance of the <see cref="SqlDatabase"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static SqlDatabase FromExisting(IConstruct scope, string name, SqlServer parent)
            => new SqlDatabase(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<SqlServer>() ?? throw new InvalidOperationException("A SQL server was not found in the construct.");
        }
    }
}
