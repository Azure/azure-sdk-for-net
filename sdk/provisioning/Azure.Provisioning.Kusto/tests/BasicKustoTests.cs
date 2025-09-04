// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.CosmosDB;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Kusto.Tests;

public class BasicKustoTests
{
    internal static Trycep CreateKustoClusterDatabaseTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KustoClusterDatabase
                Infrastructure infra = new();
                // Create parameters for cluster name, database name, and location
                ProvisioningParameter kustoClusterName = new(nameof(kustoClusterName), typeof(string))
                {
                    Description = "Name of the cluster to create",
                    Value = BicepFunction.Interpolate($"kusto{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(kustoClusterName);
                ProvisioningParameter kustoDBName = new(nameof(kustoDBName), typeof(string))
                {
                    Description = "Name of the database to create",
                    Value = "kustodb"
                };
                infra.Add(kustoDBName);
                // Create Kusto cluster
                KustoCluster kustoCluster = new("kustoCluster")
                {
                    Name = kustoClusterName,
                    Sku = new KustoSku
                    {
                        // Note: Standard_D8_v3 is not available in the enum, using StandardE8dV4 as a similar alternative
                        Name = KustoSkuName.StandardE8dV4,
                        Tier = KustoSkuTier.Standard,
                        Capacity = 2
                    },
                    Tags =
                    {
                        ["Created By"] = "GitHub quickstart template"
                    }
                };
                infra.Add(kustoCluster);
                // Create Kusto database
                KustoReadWriteDatabase kustoDatabase = new("kustoDatabase")
                {
                    Name = kustoDBName,
                    Parent = kustoCluster,
                    SoftDeletePeriod = TimeSpan.FromDays(365),
                    HotCachePeriod = TimeSpan.FromDays(31)
                };
                infra.Add(kustoDatabase);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/d56737b22db0280fc1967a59d7c01a6762ccbedd/quickstarts/microsoft.kusto/kusto-cluster-database/azuredeploy.json")]
    public async Task KustoClusterDatabase()
    {
        await using Trycep test = CreateKustoClusterDatabaseTest();
        test.Compare(
            """
            @description('Name of the cluster to create')
            param kustoClusterName string = 'kusto${uniqueString(resourceGroup().id)}'

            @description('Name of the database to create')
            param kustoDBName string = 'kustodb'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource kustoCluster 'Microsoft.Kusto/clusters@2024-04-13' = {
              name: kustoClusterName
              location: location
              sku: {
                name: 'Standard_E8d_v4'
                capacity: 2
                tier: 'Standard'
              }
              tags: {
                'Created By': 'GitHub quickstart template'
              }
            }

            resource kustoDatabase 'Microsoft.Kusto/clusters/databases@2024-04-13' = {
              name: kustoDBName
              location: location
              parent: kustoCluster
              kind: 'ReadWrite'
              properties: {
                hotCachePeriod: 'P31D'
                softDeletePeriod: 'P365D'
              }
            }
            """);
    }

    internal static Trycep CreateKustoCosmosDBTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KustoCosmosDB
                Infrastructure infra = new();

                ProvisioningParameter location = new(nameof(location), typeof(string))
                {
                    Description = "Location for all resources",
                    Value = BicepFunction.GetResourceGroup().Location
                };
                infra.Add(location);
                ProvisioningParameter clusterName = new(nameof(clusterName), typeof(string))
                {
                    Description = "Name of the cluster",
                    Value = BicepFunction.Interpolate($"kusto{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(clusterName);
                ProvisioningParameter skuName = new(nameof(skuName), typeof(string))
                {
                    Description = "Name of the sku",
                    Value = "Standard_D12_v2"
                };
                infra.Add(skuName);
                ProvisioningParameter skuCapacity = new(nameof(skuCapacity), typeof(int))
                {
                    Description = "# of nodes",
                    Value = 2
                };
                infra.Add(skuCapacity);
                ProvisioningParameter kustoDatabaseName = new(nameof(kustoDatabaseName), typeof(string))
                {
                    Description = "Name of the database",
                    Value = "kustodb"
                };
                infra.Add(kustoDatabaseName);
                ProvisioningParameter cosmosDbAccountName = new(nameof(cosmosDbAccountName), typeof(string))
                {
                    Description = "Name of Cosmos DB account",
                    Value = BicepFunction.Interpolate($"cosmosdb{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(cosmosDbAccountName);
                ProvisioningParameter cosmosDbDatabaseName = new(nameof(cosmosDbDatabaseName), typeof(string))
                {
                    Description = "Name of Cosmos DB database",
                    Value = "mydb"
                };
                infra.Add(cosmosDbDatabaseName);
                ProvisioningParameter cosmosDbContainerName = new(nameof(cosmosDbContainerName), typeof(string))
                {
                    Description = "Name of Cosmos DB container",
                    Value = "mycontainer"
                };
                infra.Add(cosmosDbContainerName);
                ProvisioningVariable cosmosDataReader = new(nameof(cosmosDataReader), typeof(string))
                {
                    Value = "00000000-0000-0000-0000-000000000001"
                };
                infra.Add(cosmosDataReader);
                CosmosDBAccount cosmosDbAccount = new(nameof(cosmosDbAccount), CosmosDBAccount.ResourceVersions.V2022_08_15)
                {
                    Name = cosmosDbAccountName,
                    Kind = CosmosDBAccountKind.GlobalDocumentDB,
                    Locations =
                    [
                        new CosmosDBAccountLocation
                        {
                            LocationName = location,
                            FailoverPriority = 0
                        }
                    ],
                    DatabaseAccountOfferType = CosmosDBAccountOfferType.Standard
                };
                infra.Add(cosmosDbAccount);
                CosmosDBSqlDatabase cosmosDbDatabase = new("cosmosDbDatabase")
                {
                    Name = cosmosDbDatabaseName,
                    Parent = cosmosDbAccount,
                    Resource = new CosmosDBSqlDatabaseResourceInfo
                    {
                        DatabaseName = cosmosDbDatabaseName
                    }
                };
                infra.Add(cosmosDbDatabase);
                CosmosDBSqlContainer cosmosDbContainer = new("cosmosDbContainer")
                {
                    Name = cosmosDbContainerName,
                    Parent = cosmosDbDatabase,
                    Options = new CosmosDBCreateUpdateConfig
                    {
                        Throughput = 400
                    },
                    Resource = new CosmosDBSqlContainerResourceInfo
                    {
                        ContainerName = cosmosDbContainerName,
                        PartitionKey = new CosmosDBContainerPartitionKey
                        {
                            Kind = CosmosDBPartitionKind.Hash,
                            Paths = ["/part"]
                        }
                    }
                };
                infra.Add(cosmosDbContainer);
                KustoCluster cluster = new(nameof(cluster))
                {
                    Name = clusterName,
                    Location = location,
                    Sku = new KustoSku
                    {
                        Name = KustoSkuName.StandardD12V2,
                        Tier = KustoSkuTier.Standard,
                        Capacity = skuCapacity
                    },
                    Identity = new ManagedServiceIdentity
                    {
                        ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                    }
                };
                infra.Add(cluster);
                CosmosDBSqlRoleAssignment cosmosDBSqlRoleAssignment = new("clusterCosmosDbDataAuthorization")
                {
                    Parent = cosmosDbAccount,
                    PrincipalId = cluster.Identity.PrincipalId,
                    RoleDefinitionId = ((IBicepValue)BicepFunction.Interpolate($"/providers/Microsoft.DocumentDB/databaseAccounts/{cosmosDbAccountName}/sqlRoleDefinitions/{cosmosDataReader}")).Expression,
                    Scope = cosmosDbAccount.Id
                };
                infra.Add(cosmosDBSqlRoleAssignment);
                KustoDatabase kustoDb = new KustoReadWriteDatabase(nameof(kustoDb))
                {
                    Name = kustoDatabaseName,
                    Parent = cluster,
                };
                infra.Add(kustoDb);
                KustoScript kustoScript = new("kustoScript")
                {
                    Name = "db-script",
                    Parent = kustoDb,
                    ScriptContent = new FunctionCallExpression(new IdentifierExpression("loadTextContent"), new StringLiteralExpression("script.kql")),
                    ShouldContinueOnErrors = false
                };
                infra.Add(kustoScript);
                KustoDataConnection cosmosDbConnection = new KustoCosmosDBDataConnection("cosmosDbConnection")
                {
                    Name = "cosmosDbConnection",
                    Parent = kustoDb,
                    Location = location,
                    DependsOn =
                    {
                        kustoScript,
                        cosmosDBSqlRoleAssignment
                    },
                    TableName = "TestTable",
                    MappingRuleName = "DocumentMapping",
                    ManagedIdentityResourceId = cluster.Id,
                    CosmosDBAccountResourceId = cosmosDbAccount.Id,
                    CosmosDBDatabase = cosmosDbDatabaseName,
                    CosmosDBContainer = cosmosDbContainerName
                };
                infra.Add(cosmosDbConnection);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.kusto/kusto-cosmos-db/main.bicep")]
    public async Task KustoCosmosDB()
    {
        await using Trycep test = CreateKustoCosmosDBTest();
        test.Compare(
            """
            @description('Location for all resources')
            param location string = resourceGroup().location

            @description('Name of the cluster')
            param clusterName string = 'kusto${uniqueString(resourceGroup().id)}'

            @description('Name of the sku')
            param skuName string = 'Standard_D12_v2'

            @description('# of nodes')
            param skuCapacity int = 2

            @description('Name of the database')
            param kustoDatabaseName string = 'kustodb'

            @description('Name of Cosmos DB account')
            param cosmosDbAccountName string = 'cosmosdb${uniqueString(resourceGroup().id)}'

            @description('Name of Cosmos DB database')
            param cosmosDbDatabaseName string = 'mydb'

            @description('Name of Cosmos DB container')
            param cosmosDbContainerName string = 'mycontainer'

            var cosmosDataReader = '00000000-0000-0000-0000-000000000001'

            resource cosmosDbAccount 'Microsoft.DocumentDB/databaseAccounts@2022-08-15' = {
              name: cosmosDbAccountName
              location: location
              properties: {
                locations: [
                  {
                    locationName: location
                    failoverPriority: 0
                  }
                ]
                databaseAccountOfferType: 'Standard'
              }
              kind: 'GlobalDocumentDB'
            }

            resource cosmosDbDatabase 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2024-08-15' = {
              name: cosmosDbDatabaseName
              location: location
              properties: {
                resource: {
                  id: cosmosDbDatabaseName
                }
              }
              parent: cosmosDbAccount
            }

            resource cosmosDbContainer 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2024-08-15' = {
              name: cosmosDbContainerName
              location: location
              properties: {
                resource: {
                  id: cosmosDbContainerName
                  partitionKey: {
                    paths: [
                      '/part'
                    ]
                    kind: 'Hash'
                  }
                }
                options: {
                  throughput: 400
                }
              }
              parent: cosmosDbDatabase
            }

            resource cluster 'Microsoft.Kusto/clusters@2024-04-13' = {
              name: clusterName
              location: location
              sku: {
                name: 'Standard_D12_v2'
                capacity: skuCapacity
                tier: 'Standard'
              }
              identity: {
                type: 'SystemAssigned'
              }
            }

            resource clusterCosmosDbDataAuthorization 'Microsoft.DocumentDB/databaseAccounts/sqlRoleAssignments@2024-08-15' = {
              properties: {
                principalId: cluster.identity.principalId
                roleDefinitionId: '/providers/Microsoft.DocumentDB/databaseAccounts/${cosmosDbAccountName}/sqlRoleDefinitions/${cosmosDataReader}'
                scope: cosmosDbAccount.id
              }
              parent: cosmosDbAccount
            }

            resource kustoDb 'Microsoft.Kusto/clusters/databases@2024-04-13' = {
              name: kustoDatabaseName
              location: location
              parent: cluster
              kind: 'ReadWrite'
            }

            resource kustoScript 'Microsoft.Kusto/clusters/databases/scripts@2024-04-13' = {
              name: 'db-script'
              properties: {
                scriptContent: loadTextContent('script.kql')
                continueOnErrors: false
              }
              parent: kustoDb
            }

            resource cosmosDbConnection 'Microsoft.Kusto/clusters/databases/dataConnections@2024-04-13' = {
              name: 'cosmosDbConnection'
              location: location
              parent: kustoDb
              kind: 'CosmosDb'
              properties: {
                cosmosDbAccountResourceId: cosmosDbAccount.id
                cosmosDbContainer: cosmosDbContainerName
                cosmosDbDatabase: cosmosDbDatabaseName
                managedIdentityResourceId: cluster.id
                mappingRuleName: 'DocumentMapping'
                tableName: 'TestTable'
              }
              dependsOn: [
                kustoScript
                clusterCosmosDbDataAuthorization
              ]
            }
            """);
    }
}
