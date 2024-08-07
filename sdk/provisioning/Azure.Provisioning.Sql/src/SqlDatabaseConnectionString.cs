// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a connection string.
    /// </summary>
    public class SqlDatabaseConnectionString : ConnectionString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabaseConnectionString"/>.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="password">The password.</param>
        /// <param name="userName">The user name.</param>
        internal SqlDatabaseConnectionString(SqlDatabase database, Parameter password, string userName)
            : base($"Server=${{{database.Parent!.Name}.properties.fullyQualifiedDomainName}}; Database=${{{database.Name}.name}}; User={userName}; Password=${{{(password.IsFromOutput ? password.Value : password.Name)}}}")
        {
        }
    }
}
