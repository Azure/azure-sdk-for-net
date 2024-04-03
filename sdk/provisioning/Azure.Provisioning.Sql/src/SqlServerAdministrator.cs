// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a SQL Server administrator.
    /// </summary>
    public class SqlServerAdministrator : Resource<SqlServerAzureADAdministratorData>
    {
        // https://learn.microsoft.com/en-us/azure/templates/microsoft.sql/2020-11-01-preview/servers/administrators?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.Sql/servers/administrators";

        private static SqlServerAzureADAdministratorData Empty(string name) => ArmSqlModelFactory.SqlServerAzureADAdministratorData();

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerAdministrator"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public SqlServerAdministrator(IConstruct scope, SqlServer? parent = null, string name = "admin", string version = SqlServer.DefaultVersion)
            : this(scope, parent, name, version, (name) => ArmSqlModelFactory.SqlServerAzureADAdministratorData(
                name: name,
                resourceType: ResourceTypeName))
        {
        }

        private SqlServerAdministrator(IConstruct scope,
            SqlServer? parent,
            string name,
            string version = SqlServer.DefaultVersion,
            Func<string, SqlServerAzureADAdministratorData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SqlServerAdministrator"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static SqlServerAdministrator FromExisting(IConstruct scope, string name, SqlServer parent)
            => new SqlServerAdministrator(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<SqlServer>() ?? throw new InvalidOperationException("A SQL server was not found in the construct.");
        }

        internal ServerExternalAdministrator ToServerExternalAdministrator()
        {
            return new ServerExternalAdministrator
            {
                AdministratorType = SqlAdministratorType.ActiveDirectory,
                Login = Properties.Login,
                Sid = Properties.Sid,
                TenantId = Properties.TenantId,
                IsAzureADOnlyAuthenticationEnabled = Properties.IsAzureADOnlyAuthenticationEnabled
            };
        }
    }
}
