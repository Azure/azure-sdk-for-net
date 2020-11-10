# Azure Tables client library for .NET

Azure Table storage is a service that stores large amounts of structured NoSQL data in the cloud, providing 
a key/attribute store with a schema-less design. 

Azure Cosmos DB provides a Table API for applications that are written for Azure Table storage that need premium capabilities like:

- Turnkey global distribution.
- Dedicated throughput worldwide.
- Single-digit millisecond latencies at the 99th percentile.
- Guaranteed high availability.
- Automatic secondary indexing.

The Azure Tables client library can seamlessly target either Azure Table storage or Azure Cosmos DB table service endpoints with no code changes.

[Source code][table_client_src] | [Package (NuGet)][table_client_nuget_package] | [API reference documentation][api_reference] | [Samples][table_client_samples]

## Getting started

### Install the package
Install the Azure Tables client library for .NET with [NuGet][table_client_nuget_package]:

```
dotnet add package Azure.Data.Tables --version 3.0.0-beta.3
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
az cosmosdb create --name MyCosmosDBDatabaseAccount --capabilities EnableTable --resource-group MyResourceGroup --subscription MySubscription

az cosmosdb table create --name MyTableName --resource-group MyResourceGroup --account-name MyCosmosDBDatabaseAccount
```

### Authenticate the Client

Learn more about options for authentication _(including Connection Strings, Shared Key, and Shared Key Signatures)_ [in our samples.](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/samples/Sample0Auth.md)

## Key concepts

- `TableServiceClient` - Client that provides methods to interact at the Table Service level such as creating, listing, and deleting tables
- `TableClient` - Client that provides methods to interact at an table entity level such as creating, querying, and deleting entities within a table.
- `Table` - Tables store data as collections of entities.
- `Entity` - Entities are similar to rows. An entity has a primary key and a set of properties. A property is a name value pair, similar to a column.

Common uses of the Table service include:

- Storing TBs of structured data capable of serving web scale applications
- Storing datasets that don't require complex joins, foreign keys, or stored procedures and can be de-normalized for fast access
- Quickly querying data using a clustered index
- Accessing data using the OData protocol and LINQ filter expressions


## Examples
- [Create the Table service client](#create-the-table-service-client)
    - [Create an Azure table](#create-an-azure-table)
    - [Get an Azure table](#get-an-azure-table)
    - [Delete an Azure table](#delete-an-azure-table)
- [Create the Table client](#create-the-table-client)
    - [Add table entities](#add-table-entities)
    - [Query table entities ](#query-table-entities)
    - [Delete table entities](#delete-table-entities)

### Create the Table service client

First, we need to construct a `TableServiceClient`.

```C# Snippet:TablesSample1CreateClient
// Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

### Create an Azure table
Next, we can create a new table.

```C# Snippet:TablesSample1CreateTable
// Create a new table. The <see cref="TableItem" /> class stores properties of the created table.

TableItem table = serviceClient.CreateTable(tableName);
Console.WriteLine($"The created table's name is {table.TableName}.");
```

### Get an Azure table
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

### Delete an Azure table

Individual tables can be deleted from the service.

```C# Snippet:TablesSample1DeleteTable
// Deletes the table made previously.

serviceClient.DeleteTable(tableName);
```

### Create the Table client

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

### Add table entities

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

### Setting up console logging

The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Get started with our [Table samples][table_client_samples].

## Known Issues

A list of currently known issues relating to Cosmos DB table endpoints can be found [here](https://aka.ms/tablesknownissues).

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact 
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[tables_rest]: https://docs.microsoft.com/rest/api/storageservices/table-service-rest-api
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[table_client_nuget_package]: https://www.nuget.org/packages?q=Azure.Data.Tables
[table_client_samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/samples
[table_client_src]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/src
[api_reference]: https://docs.microsoft.com/dotnet/api/overview/azure/data.tables-readme-pre?view=azure-dotnet-preview
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftables%2FAzure.Data.Tables%2FREADME.png)
