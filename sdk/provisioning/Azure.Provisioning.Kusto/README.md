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
