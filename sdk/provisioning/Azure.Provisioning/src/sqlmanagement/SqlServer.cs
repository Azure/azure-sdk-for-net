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

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServer"/> class for mocking.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="adminLogin">The administrator login.</param>
        /// <param name="adminPassword">The administrator password.</param>
        /// <param name="administrator">The administrator when using Entra.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SqlServer(
            IConstruct scope,
            string name,
            Parameter? adminLogin = default,
            Parameter? adminPassword = default,
            SqlServerAdministrator? administrator = default,
            string version = "2022-08-01-preview",
            AzureLocation? location = default)
            : base(scope, null, name, ResourceTypeName, version, (name) => ArmSqlModelFactory.SqlServerData(
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
                AssignParameter(data => data.AdministratorLogin, adminLogin.Value);
            }
            if (adminPassword != null)
            {
                AssignParameter(data => data.AdministratorLoginPassword, adminPassword.Value);
            }
            if (administrator != null)
            {
                AssignParameter(data => data.Administrators.Login, administrator.Value.LoginName);
                AssignParameter(data => data.Administrators.Sid, administrator.Value.ObjectId);
                AssignProperty(data => data.Administrators.AdministratorType, "'ActiveDirectory'");
                if (scope.Root.Properties.TenantId == Guid.Empty)
                {
                    AssignProperty(data => data.Administrators.TenantId, Tenant.TenantIdExpression);
                }
            }
        }

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
        protected override string GetAzureName(IConstruct scope, string resourceName)
        {
            return $"toLower(take(concat('{resourceName}', uniqueString(resourceGroup().id)), 24))";
        }
    }
}
