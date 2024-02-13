// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a connection string.
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// Gets the value of the connection string.
        /// </summary>
        public string Value { get; }

        internal SqlDatabase Database { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionString"/>.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="password">The password.</param>
        /// <param name="userName">The user name.</param>
        public ConnectionString(SqlDatabase database, Parameter password, string userName)
        {
            Database = database;
            Value = $"Server=${{{database.Parent!.Name}.properties.fullyQualifiedDomainName}}; Database=${{{database.Name}.name}}; User={userName}; Password=${{{password.Name}}}";
        }
    }
}
