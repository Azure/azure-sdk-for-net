# Azure Tables client library for .NET

Azure Table storage is a service that stores large amounts of structured NoSQL data in the cloud, providing 
a key/attribute store with a schema-less design. 

Azure Cosmos DB provides a Table API for applications that are written for Azure Table storage and that need premium capabilities like:

- Turnkey global distribution.
- Dedicated throughput worldwide.
- Single-digit millisecond latencies at the 99th percentile.
- Guaranteed high availability.
- Automatic secondary indexing.

The Azure Tables client library can seamlessly target either Azure table storage or Azure Cosmos DB table service endpoints with no code changes.

## Getting started

### Install the package
Install the Azure Tables client library for .NET with [NuGet][nuget]:

```
dotnet add package Azure.Data.Tables --version 3.0.0-beta.1
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure storage account or Azure Cosmos DB database with Azure Table API specified.

If you need to create either of these, you can use the [Azure CLI][azure_cli].

#### Creating a storage account

Create a storage account `mystorageaccount` in resource group `MyResourceGroup` 
in the subscription `MySubscription` in the West US region.
```
az storage account create -n mystorageaccount -g MyResourceGroup -l westus --subscription MySubscription
```

#### Creating a Cosmos DB

Create a Cosmos DB account `MyCosmosDBDatabaseAccount` in resource group `MyResourceGroup` 
in the subscription `MySubscription` and a table named `MyTableName` in the account.

```
az cosmosdb create --name MyCosmosDBDatabaseAccount --resource-group MyResourceGroup --subscription MySubscription

az cosmosdb table create --name MyTableName --resource-group MyResourceGroup --account-name MyCosmosDBDatabaseAccount
```

## Key concepts

Common uses of the Table service include:

- Storing TBs of structured data capable of serving web scale applications
- Storing datasets that don't require complex joins, foreign keys, or stored procedures and can be de-normalized for fast access
- Quickly querying data using a clustered index
- Accessing data using the OData protocol and LINQ filter expressions

Learn more about options for authentication _(including Connection Strings, Shared Key, and Shared Key Signatures)_ [in our samples.](samples/Sample0Auth.md)

## Examples

### Create, Get, and Delete an Azure table

First, we need to construct a `TableServiceClient`.

```C# Snippet:TablesSample1CreateClient
// Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

Next, we can create a new table.

```C# Snippet:TablesSample1CreateTable
// Create a new table. The <see cref="TableItem" /> class stores properties of the created table.

TableItem table = serviceClient.CreateTable(tableName);
Console.WriteLine($"The created table's name is {table.TableName}.");
```

The set of existing Azure tables can be queries using an OData filter.

```C# Snippet:TablesSample3QueryTables
// Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.

Pageable<TableItem> queryTableResults = serviceClient.GetTables(filter: $"TableName eq '{tableName}'");

Console.WriteLine("The following are the names of the tables in the query results:");

// Iterate the <see cref="Pageable"> in order to access queried tables.

foreach (TableItem table in queryTableResults)
{
    Console.WriteLine(table.TableName);
}
```

Individual tables can be deleted from the service.

```C# Snippet:TablesSample1DeleteTable
// Deletes the table made previously.

serviceClient.DeleteTable(tableName);
```

### Add, Query, and Delete table entities

To interact with table entities, we must first construct a `TableClient`.

```C# Snippet:TablesSample2CreateTableWithTableClient
// Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.

var tableClient = new TableClient(
    new Uri(storageUri),
    tableName,
    new TableSharedKeyCredential(accountName, storageAccountKey));

// Create the table in the service.
tableClient.Create();
```

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

## Next steps

Get started with our [Table samples](samples/README.MD):


## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact 
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[tables_rest]: https://docs.microsoft.com/en-us/rest/api/storageservices/table-service-rest-api
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[contrib]: ./CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftables%2FAzure.Data.Tables%2FREADME.png)
