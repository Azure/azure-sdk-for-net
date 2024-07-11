// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.CosmosDB;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.Provisioning.CosmosDB
{
    /// <summary>
    /// Represents a CosmosDBSqlDatabase.
    /// </summary>
    public class CosmosDBSqlDatabase : Resource<CosmosDBSqlDatabaseData>
    {
        private const string ResourceTypeName = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases";
        private static CosmosDBSqlDatabaseData Empty(string name) => ArmCosmosDBModelFactory.CosmosDBSqlDatabaseData();

        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosDBSqlDatabase"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="databaseResourceInfo">The database info.</param>
        /// <param name="propertiesConfig">The properties config.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public CosmosDBSqlDatabase(
            IConstruct scope,
            CosmosDBAccount? parent = null,
            ExtendedCosmosDBSqlDatabaseResourceInfo? databaseResourceInfo = null,
            CosmosDBSqlDatabasePropertiesConfig? propertiesConfig = default,
            string name = "db",
            string version = CosmosDBAccount.DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmCosmosDBModelFactory.CosmosDBSqlDatabaseData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                resource: databaseResourceInfo ?? new ExtendedCosmosDBSqlDatabaseResourceInfo(name),
                options: propertiesConfig ?? new CosmosDBSqlDatabasePropertiesConfig()))
        {
        }

        private CosmosDBSqlDatabase(
            IConstruct scope,
            CosmosDBAccount? parent,
            string name,
            string version = CosmosDBAccount.DefaultVersion,
            bool isExisting = false,
            Func<string, CosmosDBSqlDatabaseData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CosmosDBAccount"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static CosmosDBSqlDatabase FromExisting(IConstruct scope, string name, CosmosDBAccount parent)
            => new CosmosDBSqlDatabase(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<CosmosDBAccount>() ?? new CosmosDBAccount(scope);
        }
    }
}
