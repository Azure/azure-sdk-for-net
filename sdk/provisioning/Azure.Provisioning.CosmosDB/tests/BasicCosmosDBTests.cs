// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CosmosDB.Tests;

public class BasicCosmosDBTests
{
    internal static Trycep CreateCosmosSqlDBTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CosmosDBBasic
                Infrastructure infra = new();

                ProvisioningParameter dbName = new(nameof(dbName), typeof(string)) { Value = "orders" };
                infra.Add(dbName);

                ProvisioningParameter containerName = new(nameof(containerName), typeof(string)) { Value = "products" };
                infra.Add(containerName);

                CosmosDBAccount cosmos =
                    new(nameof(cosmos), CosmosDBAccount.ResourceVersions.V2024_08_15)
                    {
                        DatabaseAccountOfferType = CosmosDBAccountOfferType.Standard,
                        ConsistencyPolicy = new ConsistencyPolicy
                        {
                            DefaultConsistencyLevel = DefaultConsistencyLevel.Session
                        },
                        Locations =
                        {
                            new CosmosDBAccountLocation { LocationName = BicepFunction.GetResourceGroup().Location }
                        }
                    };
                infra.Add(cosmos);

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
                infra.Add(db);

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
                infra.Add(container);

                infra.Add(new ProvisioningOutput("containerName", typeof(string)) { Value = container.Name });
                infra.Add(new ProvisioningOutput("containerId", typeof(string)) { Value = container.Id });
                #endregion

                return infra;
            });
    }
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.documentdb/cosmosdb-free/main.bicep")]
    public async Task CreateCosmosSqlDB()
    {
        await using Trycep test = CreateCosmosSqlDBTest();
        test.Compare(
            """
            param dbName string = 'orders'

            param containerName string = 'products'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource cosmos 'Microsoft.DocumentDB/databaseAccounts@2024-08-15' = {
              name: take('cosmos-${uniqueString(resourceGroup().id)}', 44)
              location: location
              properties: {
                locations: [
                  {
                    locationName: resourceGroup().location
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
              location: location
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
              location: location
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
            """);
    }
}
