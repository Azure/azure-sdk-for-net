// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.Redis;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.Provisioning.PostgreSql
{
    /// <summary>
    /// Represents a PostGreSql server.
    /// </summary>
    public class PostgreSqlFlexibleServer : Resource<PostgreSqlFlexibleServerData>
    {
        // https://learn.microsoft.com/en-us/azure/templates/microsoft.dbforpostgresql/2023-03-01-preview/flexibleservers?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.DBforPostgreSQL/flexibleServers";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/postgresql/Azure.ResourceManager.PostgreSql/src/PostgreSqlFlexibleServers/Generated/RestOperations/ServersRestOperations.cs#L37
        internal const string DefaultVersion = "2023-03-01-preview";

        private static PostgreSqlFlexibleServerData Empty(string name) => ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerData();

        /// <summary>
        /// Creates a new instance of the <see cref="PostgreSqlFlexibleServer"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="administratorLogin">The administrator login.</param>
        /// <param name="administratorPassword">The administrator password.</param>
        /// <param name="sku">The Sku.</param>
        /// <param name="serverVersion">The version.</param>
        /// <param name="highAvailability">The high availability.</param>
        /// <param name="storage">The storage.</param>
        /// <param name="encryption"></param>
        /// <param name="backup">The backup.</param>
        /// <param name="network">The network.</param>
        /// <param name="availabilityZone">The availability zone.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public PostgreSqlFlexibleServer(
            IConstruct scope,
            Parameter administratorLogin,
            Parameter administratorPassword,
            PostgreSqlFlexibleServerSku? sku = default,
            PostgreSqlFlexibleServerVersion? serverVersion = default,
            PostgreSqlFlexibleServerHighAvailability? highAvailability = default,
            PostgreSqlFlexibleServerStorage? storage = default,
            PostgreSqlFlexibleServerDataEncryption? encryption = default,
            PostgreSqlFlexibleServerBackupProperties? backup = default,
            PostgreSqlFlexibleServerNetwork? network = default,
            string? availabilityZone = default,
            ResourceGroup? parent = default,
            string name = "postgres",
            string version = DefaultVersion,
            AzureLocation? location = default)
        : this(scope, parent, name, version, false, (name) => ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerData(
                name: name,
                // create new instances so the properties can be overriden by user if needed
                version: serverVersion ?? new PostgreSqlFlexibleServerVersion(),
                highAvailability: highAvailability ?? new PostgreSqlFlexibleServerHighAvailability(),
                storage: storage ?? new PostgreSqlFlexibleServerStorage(),
                backup: backup ?? new PostgreSqlFlexibleServerBackupProperties(),
                network: network ?? new PostgreSqlFlexibleServerNetwork(),
                sku: sku ?? new PostgreSqlFlexibleServerSku("Standard_D4s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                dataEncryption: encryption ?? new PostgreSqlFlexibleServerDataEncryption(),
                availabilityZone: availabilityZone,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
            AssignProperty(data => data.AdministratorLogin, administratorLogin);
            AssignProperty(data => data.AdministratorLoginPassword, administratorPassword);
        }

        private PostgreSqlFlexibleServer(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            bool isExisting = false,
            Func<string, PostgreSqlFlexibleServerData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PostgreSqlFlexibleServer"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static PostgreSqlFlexibleServer FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new PostgreSqlFlexibleServer(scope, parent: parent, name: name, isExisting: true);

        /// <summary>
        /// Gets the connection string for the <see cref="RedisCache"/>.
        /// </summary>
        public PostgreSqlConnectionString GetConnectionString(Parameter administratorLogin, Parameter administratorPassword)
            => new PostgreSqlConnectionString(this, administratorLogin, administratorPassword);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
