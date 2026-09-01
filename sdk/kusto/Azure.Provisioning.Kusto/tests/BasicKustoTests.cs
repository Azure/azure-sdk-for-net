// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.CosmosDB;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.EventHubs;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
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
                KustoCluster kustoCluster = new("kustoCluster", KustoCluster.ResourceVersions.V2025_02_14)
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
                KustoReadWriteDatabase kustoDatabase = new("kustoDatabase", KustoDatabase.ResourceVersions.V2025_02_14)
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

            resource kustoCluster 'Microsoft.Kusto/clusters@2025-02-14' = {
              name: kustoClusterName
              location: location
              sku: {
                capacity: 2
                name: 'Standard_E8d_v4'
                tier: 'Standard'
              }
              tags: {
                'Created By': 'GitHub quickstart template'
              }
            }

            resource kustoDatabase 'Microsoft.Kusto/clusters/databases@2025-02-14' = {
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
                CosmosDBAccount cosmosDbAccount = new(nameof(cosmosDbAccount), CosmosDBAccount.ResourceVersions.V2024_08_15)
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
                CosmosDBSqlDatabase cosmosDbDatabase = new("cosmosDbDatabase", CosmosDBSqlDatabase.ResourceVersions.V2024_08_15)
                {
                    Name = cosmosDbDatabaseName,
                    Parent = cosmosDbAccount,
                    Resource = new CosmosDBSqlDatabaseResourceInfo
                    {
                        DatabaseName = cosmosDbDatabaseName
                    }
                };
                infra.Add(cosmosDbDatabase);
                CosmosDBSqlContainer cosmosDbContainer = new("cosmosDbContainer", CosmosDBSqlContainer.ResourceVersions.V2024_08_15)
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
                KustoCluster cluster = new(nameof(cluster), KustoCluster.ResourceVersions.V2025_02_14)
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
                CosmosDBSqlRoleAssignment cosmosDBSqlRoleAssignment = new("clusterCosmosDbDataAuthorization", CosmosDBSqlRoleAssignment.ResourceVersions.V2024_08_15)
                {
                    Parent = cosmosDbAccount,
                    PrincipalId = cluster.Identity.PrincipalId,
                    RoleDefinitionId = ((IBicepValue)BicepFunction.Interpolate($"/providers/Microsoft.DocumentDB/databaseAccounts/{cosmosDbAccountName}/sqlRoleDefinitions/{cosmosDataReader}")).Expression,
                    Scope = cosmosDbAccount.Id
                };
                infra.Add(cosmosDBSqlRoleAssignment);
                KustoDatabase kustoDb = new KustoReadWriteDatabase(nameof(kustoDb), KustoDatabase.ResourceVersions.V2025_02_14)
                {
                    Name = kustoDatabaseName,
                    Parent = cluster,
                };
                infra.Add(kustoDb);
                KustoScript kustoScript = new("kustoScript", KustoScript.ResourceVersions.V2025_02_14)
                {
                    Name = "db-script",
                    Parent = kustoDb,
                    ScriptContent = new FunctionCallExpression(new IdentifierExpression("loadTextContent"), new StringLiteralExpression("script.kql")),
                    ShouldContinueOnErrors = false
                };
                infra.Add(kustoScript);
                KustoDataConnection cosmosDbConnection = new KustoCosmosDBDataConnection("cosmosDbConnection", KustoDataConnection.ResourceVersions.V2025_02_14)
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

            resource cosmosDbAccount 'Microsoft.DocumentDB/databaseAccounts@2024-08-15' = {
              name: cosmosDbAccountName
              location: location
              kind: 'GlobalDocumentDB'
              properties: {
                databaseAccountOfferType: 'Standard'
                locations: [
                  {
                    failoverPriority: 0
                    locationName: location
                  }
                ]
              }
            }

            resource cosmosDbDatabase 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2024-08-15' = {
              name: cosmosDbDatabaseName
              location: location
              parent: cosmosDbAccount
              properties: {
                resource: {
                  id: cosmosDbDatabaseName
                }
              }
            }

            resource cosmosDbContainer 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2024-08-15' = {
              name: cosmosDbContainerName
              location: location
              parent: cosmosDbDatabase
              properties: {
                options: {
                  throughput: 400
                }
                resource: {
                  id: cosmosDbContainerName
                  partitionKey: {
                    kind: 'Hash'
                    paths: [
                      '/part'
                    ]
                  }
                }
              }
            }

            resource cluster 'Microsoft.Kusto/clusters@2025-02-14' = {
              name: clusterName
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              sku: {
                capacity: skuCapacity
                name: 'Standard_D12_v2'
                tier: 'Standard'
              }
            }

            resource clusterCosmosDbDataAuthorization 'Microsoft.DocumentDB/databaseAccounts/sqlRoleAssignments@2024-08-15' = {
              name: take('clustercosmosdbdataauthorization${uniqueString(resourceGroup().id)}', 24)
              parent: cosmosDbAccount
              properties: {
                principalId: cluster.identity.principalId
                roleDefinitionId: '/providers/Microsoft.DocumentDB/databaseAccounts/${cosmosDbAccountName}/sqlRoleDefinitions/${cosmosDataReader}'
                scope: cosmosDbAccount.id
              }
            }

            resource kustoDb 'Microsoft.Kusto/clusters/databases@2025-02-14' = {
              name: kustoDatabaseName
              location: location
              parent: cluster
              kind: 'ReadWrite'
            }

            resource kustoScript 'Microsoft.Kusto/clusters/databases/scripts@2025-02-14' = {
              name: 'db-script'
              parent: kustoDb
              properties: {
                continueOnErrors: false
                scriptContent: loadTextContent('script.kql')
              }
            }

            resource cosmosDbConnection 'Microsoft.Kusto/clusters/databases/dataConnections@2025-02-14' = {
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

    internal static Trycep CreateKustoEventGridTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KustoEventGrid
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

                ProvisioningParameter databaseName = new(nameof(databaseName), typeof(string))
                {
                    Description = "Name of the database",
                    Value = "kustodb"
                };
                infra.Add(databaseName);

                ProvisioningParameter storageAccountName = new(nameof(storageAccountName), typeof(string))
                {
                    Description = "Name of storage account",
                    Value = BicepFunction.Interpolate($"storage{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(storageAccountName);

                ProvisioningParameter storageContainerName = new(nameof(storageContainerName), typeof(string))
                {
                    Description = "Name of storage account",
                    Value = "landing"
                };
                infra.Add(storageContainerName);

                ProvisioningParameter eventGridTopicName = new(nameof(eventGridTopicName), typeof(string))
                {
                    Description = "Name of Event Grid topic",
                    Value = "main-topic"
                };
                infra.Add(eventGridTopicName);

                ProvisioningParameter eventHubNamespaceName = new(nameof(eventHubNamespaceName), typeof(string))
                {
                    Description = "Name of Event Hub's namespace",
                    Value = BicepFunction.Interpolate($"eventHub{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(eventHubNamespaceName);

                ProvisioningParameter eventHubName = new(nameof(eventHubName), typeof(string))
                {
                    Description = "Name of Event Hub",
                    Value = "storageHub"
                };
                infra.Add(eventHubName);

                ProvisioningParameter eventGridSubscriptionName = new(nameof(eventGridSubscriptionName), typeof(string))
                {
                    Description = "Name of Event Grid subscription",
                    Value = "toEventHub"
                };
                infra.Add(eventGridSubscriptionName);

                // Storage account + container
                StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
                {
                    Name = storageAccountName,
                    Location = location,
                    Sku = new StorageSku
                    {
                        Name = StorageSkuName.StandardLrs
                    },
                    Kind = StorageKind.StorageV2,
                    IsHnsEnabled = true
                };
                infra.Add(storage);

                BlobService blobServices = new("blobServices", BlobService.ResourceVersions.V2024_01_01)
                {
                    Parent = storage
                };
                infra.Add(blobServices);

                BlobContainer landingContainer = new("landingContainer", BlobContainer.ResourceVersions.V2024_01_01)
                {
                    Name = storageContainerName,
                    Parent = blobServices,
                    PublicAccess = StoragePublicAccessType.None
                };
                infra.Add(landingContainer);

                // Event hub receiving event grid notifications
                EventHubsNamespace eventHubNamespace = new("eventHubNamespace", EventHubsNamespace.ResourceVersions.V2024_01_01)
                {
                    Name = eventHubNamespaceName,
                    Location = location,
                    Sku = new EventHubsSku
                    {
                        Capacity = 1,
                        Name = EventHubsSkuName.Standard,
                        Tier = EventHubsSkuTier.Standard
                    }
                };
                infra.Add(eventHubNamespace);

                EventHub eventHub = new("eventHub", EventHub.ResourceVersions.V2024_01_01)
                {
                    Name = eventHubName,
                    Parent = eventHubNamespace,
                    RetentionDescription = new RetentionDescription
                    {
                        RetentionTimeInHours = 48  // 2 days * 24 hours
                    },
                    PartitionCount = 2
                };
                infra.Add(eventHub);

                EventHubsConsumerGroup kustoConsumerGroup = new("kustoConsumerGroup", EventHubsConsumerGroup.ResourceVersions.V2024_01_01)
                {
                    Name = "kustoConsumerGroup",
                    Parent = eventHub
                };
                infra.Add(kustoConsumerGroup);

                // Event grid topic on storage account
                SystemTopic blobTopic = new("blobTopic", SystemTopic.ResourceVersions.V2025_02_15)
                {
                    Name = eventGridTopicName,
                    Location = location,
                    Identity = new ManagedServiceIdentity
                    {
                        ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                    },
                    Source = storage.Id,
                    TopicType = "Microsoft.Storage.StorageAccounts"
                };
                infra.Add(blobTopic);

                // Event Grid subscription, pushing events to event hub
                SystemTopicEventSubscription newBlobSubscription = new("newBlobSubscription", SystemTopicEventSubscription.ResourceVersions.V2025_02_15)
                {
                    Name = eventGridSubscriptionName,
                    Parent = blobTopic,
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
                    {
                        Destination = new EventHubEventSubscriptionDestination
                        {
                            ResourceId = eventHub.Id
                        },
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.SystemAssigned
                        }
                    },
                    EventDeliverySchema = EventDeliverySchema.EventGridSchema,
                    Filter = new EventSubscriptionFilter
                    {
                        SubjectBeginsWith = BicepFunction.Interpolate($"/blobServices/default/containers/{storageContainerName}"),
                        IncludedEventTypes = { "Microsoft.Storage.BlobCreated" },
                        IsAdvancedFilteringOnArraysEnabled = true
                    },
                    RetryPolicy = new EventSubscriptionRetryPolicy
                    {
                        MaxDeliveryAttempts = 30,
                        EventTimeToLiveInMinutes = 1440
                    }
                };
                infra.Add(newBlobSubscription);

                // Kusto cluster
                KustoCluster cluster = new("cluster", KustoCluster.ResourceVersions.V2025_02_14)
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
                    },
                    IsStreamingIngestEnabled = true
                };
                infra.Add(cluster);

                KustoReadWriteDatabase kustoDb = new("kustoDb", KustoDatabase.ResourceVersions.V2025_02_14)
                {
                    Name = databaseName,
                    Parent = cluster,
                    Location = location
                };
                infra.Add(kustoDb);

                KustoScript kustoScript = new("kustoScript", KustoScript.ResourceVersions.V2025_02_14)
                {
                    Name = "db-script",
                    Parent = kustoDb,
                    ScriptContent = new FunctionCallExpression(new IdentifierExpression("loadTextContent"), new StringLiteralExpression("script.kql")),
                    ShouldContinueOnErrors = false
                };
                infra.Add(kustoScript);

                KustoEventGridDataConnection eventConnection = new("eventConnection", KustoDataConnection.ResourceVersions.V2025_02_14)
                {
                    Name = "eventConnection",
                    Parent = kustoDb,
                    Location = location,
                    DependsOn = { kustoScript },
                    BlobStorageEventType = BlobStorageEventType.MicrosoftStorageBlobCreated,
                    ConsumerGroup = kustoConsumerGroup.Name.ToBicepExpression(),
                    DataFormat = KustoEventGridDataFormat.Csv,
                    EventGridResourceId = newBlobSubscription.Id,
                    EventHubResourceId = eventHub.Id,
                    IsFirstRecordIgnored = true,
                    ManagedIdentityResourceId = cluster.Id,
                    StorageAccountResourceId = storage.Id,
                    TableName = "People"
                };
                infra.Add(eventConnection);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.kusto/kusto-eventgrid-eventhub/main.bicep")]
    public async Task KustoEventGrid()
    {
        await using Trycep test = CreateKustoEventGridTest();
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
            param databaseName string = 'kustodb'

            @description('Name of storage account')
            param storageAccountName string = 'storage${uniqueString(resourceGroup().id)}'

            @description('Name of storage account')
            param storageContainerName string = 'landing'

            @description('Name of Event Grid topic')
            param eventGridTopicName string = 'main-topic'

            @description('Name of Event Hub\'s namespace')
            param eventHubNamespaceName string = 'eventHub${uniqueString(resourceGroup().id)}'

            @description('Name of Event Hub')
            param eventHubName string = 'storageHub'

            @description('Name of Event Grid subscription')
            param eventGridSubscriptionName string = 'toEventHub'

            resource storage 'Microsoft.Storage/storageAccounts@2024-01-01' = {
              name: storageAccountName
              location: location
              kind: 'StorageV2'
              properties: {
                isHnsEnabled: true
              }
              sku: {
                name: 'Standard_LRS'
              }
            }

            resource blobServices 'Microsoft.Storage/storageAccounts/blobServices@2024-01-01' = {
              name: 'default'
              parent: storage
            }

            resource landingContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2024-01-01' = {
              name: storageContainerName
              parent: blobServices
              properties: {
                publicAccess: 'None'
              }
            }

            resource eventHubNamespace 'Microsoft.EventHub/namespaces@2024-01-01' = {
              name: eventHubNamespaceName
              location: location
              sku: {
                capacity: 1
                name: 'Standard'
                tier: 'Standard'
              }
            }

            resource eventHub 'Microsoft.EventHub/namespaces/eventhubs@2024-01-01' = {
              name: eventHubName
              parent: eventHubNamespace
              properties: {
                partitionCount: 2
                retentionDescription: {
                  retentionTimeInHours: 48
                }
              }
            }

            resource kustoConsumerGroup 'Microsoft.EventHub/namespaces/eventhubs/consumergroups@2024-01-01' = {
              name: 'kustoConsumerGroup'
              parent: eventHub
            }

            resource blobTopic 'Microsoft.EventGrid/systemTopics@2025-02-15' = {
              name: eventGridTopicName
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                source: storage.id
                topicType: 'Microsoft.Storage.StorageAccounts'
              }
            }

            resource newBlobSubscription 'Microsoft.EventGrid/systemTopics/eventSubscriptions@2025-02-15' = {
              name: eventGridSubscriptionName
              parent: blobTopic
              properties: {
                deliveryWithResourceIdentity: {
                  destination: {
                    endpointType: 'EventHub'
                    properties: {
                      resourceId: eventHub.id
                    }
                  }
                  identity: {
                    type: 'SystemAssigned'
                  }
                }
                eventDeliverySchema: 'EventGridSchema'
                filter: {
                  enableAdvancedFilteringOnArrays: true
                  includedEventTypes: [
                    'Microsoft.Storage.BlobCreated'
                  ]
                  subjectBeginsWith: '/blobServices/default/containers/${storageContainerName}'
                }
                retryPolicy: {
                  eventTimeToLiveInMinutes: 1440
                  maxDeliveryAttempts: 30
                }
              }
            }

            resource cluster 'Microsoft.Kusto/clusters@2025-02-14' = {
              name: clusterName
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                enableStreamingIngest: true
              }
              sku: {
                capacity: skuCapacity
                name: 'Standard_D12_v2'
                tier: 'Standard'
              }
            }

            resource kustoDb 'Microsoft.Kusto/clusters/databases@2025-02-14' = {
              name: databaseName
              location: location
              parent: cluster
              kind: 'ReadWrite'
            }

            resource kustoScript 'Microsoft.Kusto/clusters/databases/scripts@2025-02-14' = {
              name: 'db-script'
              parent: kustoDb
              properties: {
                continueOnErrors: false
                scriptContent: loadTextContent('script.kql')
              }
            }

            resource eventConnection 'Microsoft.Kusto/clusters/databases/dataConnections@2025-02-14' = {
              name: 'eventConnection'
              location: location
              parent: kustoDb
              kind: 'EventGrid'
              properties: {
                blobStorageEventType: 'Microsoft.Storage.BlobCreated'
                consumerGroup: kustoConsumerGroup.name
                dataFormat: 'CSV'
                eventGridResourceId: newBlobSubscription.id
                eventHubResourceId: eventHub.id
                ignoreFirstRecord: true
                managedIdentityResourceId: cluster.id
                storageAccountResourceId: storage.id
                tableName: 'People'
              }
              dependsOn: [
                kustoScript
              ]
            }
            """);
    }
}
