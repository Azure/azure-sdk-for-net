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
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SqlServer(IConstruct scope, string name, string version = "2022-08-01-preview", AzureLocation? location = default)
            : base(scope, null, name, ResourceTypeName, version, (name) => ArmSqlModelFactory.SqlServerData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                resourceType: ResourceTypeName,
                version: "12.0",
                minTlsVersion: "1.2",
                publicNetworkAccess: ServerNetworkAccessFlag.Enabled,
                administratorLogin: "sqladmin",
                administratorLoginPassword: Guid.Empty.ToString()))
        {
        }

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetResourceGroup();
            }
            return result;
        }
    }
}
