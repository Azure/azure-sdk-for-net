# Azure Provisioning Kusto client library for .NET

Azure.Provisioning.Kusto simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Kusto
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a cluster and a database

This template allows you to create a cluster and a database.

```C# Snippet:KustoClusterDatabase
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
KustoCluster kustoCluster = new("kustoCluster", KustoCluster.ResourceVersions.V2024_04_13)
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
KustoReadWriteDatabase kustoDatabase = new("kustoDatabase", KustoDatabase.ResourceVersions.V2024_04_13)
{
    Name = kustoDBName,
    Parent = kustoCluster,
    SoftDeletePeriod = TimeSpan.FromDays(365),
    HotCachePeriod = TimeSpan.FromDays(31)
};
infra.Add(kustoDatabase);
```

### Deploy Azure Data Explorer DB with Cosmos DB connection

This template allows you to deploy an Azure Data Explorer cluster with System Assigned Identity, a database, an Azure Cosmos DB account (NoSQL), an Azure Cosmos DB database, an Azure Cosmos DB container and a data connection between the Cosmos DB container and the Kusto database (using the system assigned identity).

```C# Snippet:KustoCosmosDB
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
KustoCluster cluster = new(nameof(cluster), KustoCluster.ResourceVersions.V2024_04_13)
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
KustoDatabase kustoDb = new KustoReadWriteDatabase(nameof(kustoDb), KustoDatabase.ResourceVersions.V2024_04_13)
{
    Name = kustoDatabaseName,
    Parent = cluster,
};
infra.Add(kustoDb);
KustoScript kustoScript = new("kustoScript", KustoScript.ResourceVersions.V2024_04_13)
{
    Name = "db-script",
    Parent = kustoDb,
    ScriptContent = new FunctionCallExpression(new IdentifierExpression("loadTextContent"), new StringLiteralExpression("script.kql")),
    ShouldContinueOnErrors = false
};
infra.Add(kustoScript);
KustoDataConnection cosmosDbConnection = new KustoCosmosDBDataConnection("cosmosDbConnection", KustoDataConnection.ResourceVersions.V2024_04_13)
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
```

### Deploy Azure Data Explorer db with Event Grid connection

This template allows you deploy a cluster with System Assigned Identity, a database, an Azure Storage Account, an Event hub, an Event Grid notification publishing notifications to Event Hubs and a data connection between the Azure Storage and the database (using the system assigned identity).

```C# Snippet:KustoEventGrid
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
KustoCluster cluster = new("cluster", KustoCluster.ResourceVersions.V2024_04_13)
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

KustoReadWriteDatabase kustoDb = new("kustoDb", KustoDatabase.ResourceVersions.V2024_04_13)
{
    Name = databaseName,
    Parent = cluster,
    Location = location
};
infra.Add(kustoDb);

KustoScript kustoScript = new("kustoScript", KustoScript.ResourceVersions.V2024_04_13)
{
    Name = "db-script",
    Parent = kustoDb,
    ScriptContent = new FunctionCallExpression(new IdentifierExpression("loadTextContent"), new StringLiteralExpression("script.kql")),
    ShouldContinueOnErrors = false
};
infra.Add(kustoScript);

KustoEventGridDataConnection eventConnection = new("eventConnection", KustoDataConnection.ResourceVersions.V2024_04_13)
{
    Name = "eventConnection",
    Parent = kustoDb,
    Location = location,
    DependsOn = { kustoScript },
    BlobStorageEventType = BlobStorageEventType.MicrosoftStorageBlobCreated,
    ConsumerGroup = kustoConsumerGroup.Name,
    DataFormat = KustoEventGridDataFormat.Csv,
    EventGridResourceId = newBlobSubscription.Id,
    EventHubResourceId = eventHub.Id,
    IsFirstRecordIgnored = true,
    ManagedIdentityResourceId = cluster.Id,
    StorageAccountResourceId = storage.Id,
    TableName = "People"
};
infra.Add(eventConnection);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
