// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.CosmosDB;
using Azure.ResourceManager.CosmosDB.Models;
namespace Azure.Provisioning.CosmosDB
{
    /// <summary>
    /// Represents a RedisCache.
    /// </summary>
    public class CosmosDBAccount : Resource<CosmosDBAccountData>
    {
        private const string ResourceTypeName = "Microsoft.DocumentDB/databaseAccounts";

        /// <summary>
        /// Creates a new instance of the <see cref="CosmosDBAccount"/> class.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="kind"></param>
        /// <param name="consistencyPolicy"></param>
        /// <param name="accountOfferType"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="location"></param>
        public CosmosDBAccount(
            IConstruct scope,
            CosmosDBAccountKind? kind = default,
            ConsistencyPolicy? consistencyPolicy = default,
            CosmosDBAccountOfferType? accountOfferType = default,
            ResourceGroup? parent = default,
            string name = "cosmosDB",
            string version = "2023-04-15",
            AzureLocation? location = default)
            : base(scope, parent, name, ResourceTypeName, version, (name) => ArmCosmosDBModelFactory.CosmosDBAccountData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                kind: kind ?? CosmosDBAccountKind.GlobalDocumentDB,
                consistencyPolicy: consistencyPolicy ?? new ConsistencyPolicy(DefaultConsistencyLevel.Session),
                locations: new CosmosDBAccountLocation[]
                {
                    ArmCosmosDBModelFactory.CosmosDBAccountLocation(location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS)
                },
                databaseAccountOfferType: accountOfferType ?? "Standard"))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        /// <summary>
        /// Gets the connection string for the <see cref="CosmosDBAccount"/>.
        /// </summary>
        public CosmosDBAccountConnectionString GetConnectionString(CosmosDBKey? key = default)
            => new CosmosDBAccountConnectionString(this, key ?? CosmosDBKey.PrimaryKey);

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
