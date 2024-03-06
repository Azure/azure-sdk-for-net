// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.CosmosDB;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.Provisioning.CosmosDB
{
    /// <summary>
    ///
    /// </summary>
    public class CosmosDBSqlDatabase : Resource<CosmosDBSqlDatabaseData>
    {
        private const string ResourceTypeName = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases";

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
            string version = "2022-05-15",
            AzureLocation? location = default)
            : base(scope, parent, name, ResourceTypeName, version, (name) => ArmCosmosDBModelFactory.CosmosDBSqlDatabaseData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                resource: databaseResourceInfo ?? new ExtendedCosmosDBSqlDatabaseResourceInfo(name),
                options: propertiesConfig ?? new CosmosDBSqlDatabasePropertiesConfig()))
        {
        }
    }
}
