// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.CosmosDB;
using Azure.ResourceManager.CosmosDB.Models;
namespace Azure.Provisioning.CosmosDB
{
    /// <summary>
    /// Represents a CosmosDB account.
    /// </summary>
    public class CosmosDBAccount : Resource<CosmosDBAccountData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.documentdb/2023-04-15/databaseaccounts?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.DocumentDB/databaseAccounts";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.ResourceManager.CosmosDB/src/Generated/RestOperations/DatabaseAccountsRestOperations.cs#L36
        // TODO the version used in ARM library doesn't exist in docs, so we are using the latest documented version
        internal const string DefaultVersion = "2023-04-15";

        private static CosmosDBAccountData Empty(string name) => ArmCosmosDBModelFactory.CosmosDBAccountData();

        /// <summary>
        /// Creates a new instance of the <see cref="CosmosDBAccount"/> class.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="kind"></param>
        /// <param name="consistencyPolicy"></param>
        /// <param name="accountOfferType"></param>
        /// <param name="accountLocations"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="location"></param>
        public CosmosDBAccount(
            IConstruct scope,
            CosmosDBAccountKind? kind = default,
            ConsistencyPolicy? consistencyPolicy = default,
            CosmosDBAccountOfferType? accountOfferType = default,
            IEnumerable<CosmosDBAccountLocation>? accountLocations = default,
            ResourceGroup? parent = default,
            string name = "cosmosDB",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, location, false, (name) => ArmCosmosDBModelFactory.CosmosDBAccountData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                kind: kind ?? CosmosDBAccountKind.GlobalDocumentDB,
                consistencyPolicy: consistencyPolicy ?? new ConsistencyPolicy(DefaultConsistencyLevel.Session),
                locations: accountLocations ?? new CosmosDBAccountLocation[]
                {
                    ArmCosmosDBModelFactory.CosmosDBAccountLocation(locationName: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS)
                },
                databaseAccountOfferType: accountOfferType ?? "Standard"))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private CosmosDBAccount(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            AzureLocation? location = default,
            bool isExisting = false,
            Func<string, CosmosDBAccountData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CosmosDBAccount"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The CosmosDBAccount instance.</returns>
        public static CosmosDBAccount FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new CosmosDBAccount(scope, parent: parent, name: name, isExisting: true);

        /// <summary>
        /// Gets the connection string for the <see cref="CosmosDBAccount"/>.
        /// </summary>
        public CosmosDBAccountConnectionString GetConnectionString(CosmosDBKey? key = default)
            => new CosmosDBAccountConnectionString(this, key ?? CosmosDBKey.PrimaryKey);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
