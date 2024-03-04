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

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabase"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SqlDatabase(IConstruct scope, SqlServer? parent = null, string name = "db", string version = "2022-08-01-preview", AzureLocation? location = default)
            : base(scope, parent, name, ResourceTypeName, version, (name) => ArmSqlModelFactory.SqlDatabaseData(
                name: name,
                resourceType: ResourceTypeName))
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

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetSingleResource<SqlServer>() ?? new SqlServer(scope, "sql");
            }
            return result;
        }
    }
}
