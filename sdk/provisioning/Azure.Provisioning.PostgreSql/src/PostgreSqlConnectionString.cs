// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql
{
    /// <summary>
    /// Represents a connection string.
    /// </summary>
    public class PostgreSqlConnectionString : ConnectionString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlConnectionString"/>.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="userName">The username.</param>
        /// <param name="password">The password.</param>
        internal PostgreSqlConnectionString(PostgreSqlFlexibleServer server, Parameter userName, Parameter password)
            : base($"Host=${{{server.Name}.properties.fullyQualifiedDomainName}};Username=${{{GetParameterValue(userName)}}};Password=${{{GetParameterValue(password)}}}")
        {
        }

        private static string GetParameterValue(Parameter parameter) => parameter.IsFromOutput ? parameter.Value! : parameter.Name;
    }
}
