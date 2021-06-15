# Migration guide from Microsoft.Azure.Cosmos.Table to Azure.Data.Tables

This guide is intended to assist in the migration to the Azure.Data.Tables client package from the legacy Microsoft.Azure.CosmosDB.Table package focusing on side-by-side comparisons for similar operations between the to versions.

Familiarity with the Microsoft.Azure.CosmosDB.Table package is assumed. If you are new to the Azure Tables client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/README.md) and table client [samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/tables/Azure.Data.Tables/samples) rather than this guide.

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Tables, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Azure Tables library `Azure.Data.Tables` provides the ability to share in some of the cross-service improvements made to the Azure development experience.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Services]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Tables, the modern client library is named `Azure.Data.Tables` and was released beginning with version 12. The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.CosmosDB` or `Microsoft.Azure.Storage` and a version of 2.x.x or below and 9.x.x or below respectively.



### Constructing the clients

Previously in `Microsoft.Azure.Comsmos.Table`, you would create a `CloudStorageAccount` in order to get an instance of the `CloudTableClient` in order to perform service level operations.

```C#
// Create the CloudStorageAccount using StorageCredentials.
CloudStorageAccount storageAccount = new CloudStorageAccount(
    new StorageCredentials(accountName, storageAccountKey),
    storageUri);
 
 // Get a reference to the cloud table client.
 CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
```

Now, in `Azure.Data.Tables`, we only need a `TableServiceClient` for service level operations.

```C# Snippet:TablesSample1CreateClient
// Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

### Creating a table

In `Microsoft.Azure.Comsmos.Table` need a `CloudTable` instance to create a table, which is returned from the `CloudTableClient`.

```C#
// Create a table client and create the table if it doesn't already exist.
string tableName = "OfficeSupplies1p1";
CloudTable table = tableClient.GetTableReference(tableName);
table.CreateIfNotExists()
```

With `Azure.Data.Tables` we can complete all table level operations directly from the `TableServiceClient`.

```C# Snippet:TablesSample1CreateTable
// Create a new table. The <see cref="TableItem" /> class stores properties of the created table.
string tableName = "OfficeSupplies1p1";
TableItem table = serviceClient.CreateTable(tableName);
Console.WriteLine($"The created table's name is {table.Name}.");
```

It's also possible to create a table from the `TableClient`.
```Snippet:TablesMigrationCreateTableWithClient

```

### Adding data to the table

Let's define a new `TableEntity` so that we can add it to the table.

```C# Snippet:TablesSample2CreateDictionaryEntity
// Make a dictionary entity by defining a <see cref="TableEntity">.

var entity = new TableEntity(partitionKey, rowKey)
{
    { "Product", "Marker Set" },
    { "Price", 5.00 },
    { "Quantity", 21 }
};

Console.WriteLine($"{entity.RowKey}: {entity["Product"]} costs ${entity.GetDouble("Price")}.");
```

Using the `TableClient` we can now add our new entity to the table.

```C# Snippet:TablesSample2AddEntity
// Add the newly created entity.

tableClient.AddEntity(entity);
```

### Query table entities

To inspect the set of existing table entities, we can query the table using an OData filter.

```C# Snippet:TablesSample4QueryEntitiesFilter
Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");

// Iterate the <see cref="Pageable"> to access all queried entities.

foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");
```

If you prefer LINQ style query expressions, we can query the table using that syntax as well.

```C# Snippet:TablesSample4QueryEntitiesExpression
// Use the <see cref="TableClient"> to query the table using a filter expression.

double priceCutOff = 6.00;
Pageable<OfficeSupplyEntity> queryResultsLINQ = tableClient.Query<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);
```

### Delete table entities

If we no longer need our new table entity, it can be deleted.

```C# Snippet:TablesSample2DeleteEntity
// Delete the entity given the partition and row key.

tableClient.DeleteEntity(partitionKey, rowKey);
```

## Troubleshooting

When you interact with the Azure table library using the .NET SDK, errors returned by the service correspond to the same HTTP
status codes returned for [REST API][tables_rest] requests.

For example, if you try to create a table that already exists, a `409` error is returned, indicating "Conflict".

```C# Snippet:CreateDuplicateTable
// Construct a new TableClient using a connection string.

var client = new TableClient(
    connectionString,
    tableName);

// Create the table if it doesn't already exist.

client.CreateIfNotExists();

// Now attempt to create the same table unconditionally.

try
{
    client.Create();
}
catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
{
    Console.WriteLine(ex.ToString());
}
```
