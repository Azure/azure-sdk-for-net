// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CosmosDB.Tests;

public class BasicCosmosDBTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.documentdb/cosmosdb-free/main.bicep")]
    public async Task CreateCosmosSqlDB()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "DB location.";

                BicepParameter dbName = BicepParameter.Create<string>(nameof(dbName), "orders");
                BicepParameter containerName = BicepParameter.Create<string>(nameof(containerName), "products");

                CosmosDBAccount cosmos =
                    new(nameof(cosmos))
                    {
                        Location = location,
                        DatabaseAccountOfferType = CosmosDBAccountOfferType.Standard,
                        ConsistencyPolicy = new ConsistencyPolicy
                        {
                            DefaultConsistencyLevel = DefaultConsistencyLevel.Session
                        },
                        Locations =
                        {
                            new CosmosDBAccountLocation { LocationName = location }
                        }
                    };

                CosmosDBSqlDatabase db =
                    new(nameof(db), CosmosDBAccount.ResourceVersions.V2023_11_15)
                    {
                        Parent = cosmos,
                        Name = dbName,
                        Resource = new CosmosDBSqlDatabaseResourceInfo
                        {
                            DatabaseName = dbName
                        },
                        Options = new CosmosDBCreateUpdateConfig
                        {
                            Throughput = 400
                        }
                    };

                CosmosDBSqlContainer container =
                    new(nameof(container), CosmosDBAccount.ResourceVersions.V2023_11_15)
                    {
                        Parent = db,
                        Name = containerName,
                        Resource = new CosmosDBSqlContainerResourceInfo
                        {
                            ContainerName = containerName,
                            PartitionKey = new CosmosDBContainerPartitionKey
                            {
                                Paths = { "/myPartitionKey" }
                            }
                        },
                    };

                BicepOutput.Create<string>("containerName", container.Name);
                BicepOutput.Create<string>("containerId", container.Id);
            })
        .Compare(
            """
            @description('DB location.')
            param location string = resourceGroup().location

            param dbName string = 'orders'

            param containerName string = 'products'

            resource cosmos 'Microsoft.DocumentDB/databaseAccounts@2024-05-15-preview' = {
                name: take('cosmos-${uniqueString(resourceGroup().id)}', 44)
                location: location
                properties: {
                    locations: [
                        {
                            locationName: location
                        }
                    ]
                    consistencyPolicy: {
                        defaultConsistencyLevel: 'Session'
                    }
                    databaseAccountOfferType: 'Standard'
                }
            }

            resource db 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2023-11-15' = {
                name: dbName
                location: resourceGroup().location
                properties: {
                    resource: {
                        id: dbName
                    }
                    options: {
                        throughput: 400
                    }
                }
                parent: cosmos
            }

            resource container 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2023-11-15' = {
                name: containerName
                location: resourceGroup().location
                properties: {
                    resource: {
                        id: containerName
                        partitionKey: {
                            paths: [
                                '/myPartitionKey'
                            ]
                        }
                    }
                }
                parent: db
            }

            output containerName string = containerName

            output containerId string = container.id
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
