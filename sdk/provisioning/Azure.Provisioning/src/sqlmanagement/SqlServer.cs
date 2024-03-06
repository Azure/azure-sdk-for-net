// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a SQL Server.
    /// </summary>
    public class SqlServer : Resource<SqlServerData>
    {
        private const string ResourceTypeName = "Microsoft.Sql/servers";
        private static readonly Func<string, SqlServerData> Empty = (name) => ArmSqlModelFactory.SqlServerData();

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServer"/> class for mocking.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="adminLogin">The administrator login.</param>
        /// <param name="adminPassword">The administrator password.</param>
        /// <param name="administrator">The administrator when using Entra.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SqlServer(
            IConstruct scope,
            string name,
            ResourceGroup? parent = null,
            Parameter? adminLogin = default,
            Parameter? adminPassword = default,
            SqlServerAdministrator? administrator = default,
            string version = "2022-08-01-preview",
            AzureLocation? location = default)
            : this(scope, name, parent, adminLogin, adminPassword, administrator, version, location, false, (name) => ArmSqlModelFactory.SqlServerData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                resourceType: ResourceTypeName,
                version: "12.0",
                minTlsVersion: "1.2",
                publicNetworkAccess: ServerNetworkAccessFlag.Enabled,
                administrators: new ServerExternalAdministrator()))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
            if (adminLogin != null)
            {
                AssignProperty(data => data.AdministratorLogin, adminLogin.Value);
            }
            if (adminPassword != null)
            {
                AssignProperty(data => data.AdministratorLoginPassword, adminPassword.Value);
            }
            if (administrator != null)
            {
                AssignProperty(data => data.Administrators.Login, administrator.Value.LoginName);
                AssignProperty(data => data.Administrators.Sid, administrator.Value.ObjectId);
                AssignProperty(data => data.Administrators.AdministratorType, "'ActiveDirectory'");
                if (scope.Root.Properties.TenantId == Guid.Empty)
                {
                    AssignProperty(data => data.Administrators.TenantId, Tenant.TenantIdExpression);
                }
            }
        }

        private SqlServer(
            IConstruct scope,
            string name,
            ResourceGroup? parent = null,
            Parameter? adminLogin = default,
            Parameter? adminPassword = default,
            SqlServerAdministrator? administrator = default,
            string version = "2022-08-01-preview",
            AzureLocation? location = default,
            bool isExisting = false,
            Func<string, SqlServerData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SqlServer"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static SqlServer FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new SqlServer(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetOrAddResourceGroup();
            }
            return result;
        }

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
