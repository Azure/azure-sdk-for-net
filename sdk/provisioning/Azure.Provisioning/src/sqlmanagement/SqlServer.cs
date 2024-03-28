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
        // https://learn.microsoft.com/azure/templates/microsoft.sql/2020-11-01-preview/servers?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.Sql/servers";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/sqlmanagement/Azure.ResourceManager.Sql/src/Generated/RestOperations/ServerRestOperations.cs#L36
        internal const string DefaultVersion = "2020-11-01-preview";

        private static SqlServerData Empty(string name) => ArmSqlModelFactory.SqlServerData();

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServer"/> class for mocking.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="administratorLogin">The administrator login.</param>
        /// <param name="administratorPassword">The administrator password.</param>
        /// <param name="administrator">The administrator when using Entra.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SqlServer(IConstruct scope,
            string name,
            Parameter? administratorLogin = default,
            Parameter? administratorPassword = default,
            SqlServerAdministrator? administrator = default,
            ResourceGroup? parent = null,
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, name, parent, version, (name) => ArmSqlModelFactory.SqlServerData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                resourceType: ResourceTypeName,
                version: "12.0",
                publicNetworkAccess: ServerNetworkAccessFlag.Enabled,
                administrators: new ServerExternalAdministrator()))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
            if (administratorLogin != null)
            {
                AssignProperty(data => data.AdministratorLogin, administratorLogin.Value);
            }
            if (administratorPassword != null)
            {
                AssignProperty(data => data.AdministratorLoginPassword, administratorPassword.Value);
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
            ResourceGroup? parent,
            string version = DefaultVersion,
            Func<string, SqlServerData>? creator = null,
            bool isExisting = false)
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
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
