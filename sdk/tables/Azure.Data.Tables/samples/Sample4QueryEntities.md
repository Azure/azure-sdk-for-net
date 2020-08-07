# Query Entities
This sample demonstrates how to query a table for entities. To get started, you'll need access to either a Storage or Cosmos DB account.

## Create a `TableClient`
A `TableClient` is needed to perform table-level operations like inserting and deleting entities within the table. There are two ways to get a `TableClient`:
- Call `GetTableClient` from the `TableServiceClient` with the table name.
- Create a `TableClient` with a SAS URI, an endpoint and `TableSharedKeyCredential`, or a connection string.

If the table has not been created in the service, call `Create`.

```C# Snippet:TablesSample2CreateTableWithTableClient
// Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
var client = new TableClient(
    tableName,
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));

// Create the table in the service.
client.Create();
```

## Query entities with `filter`
To query entities that satisfy a specified filter, call `Query`, specify the desired entity return type, and pass in a filter in the form of either an OData formatted string or a LINQ expression.

### OData formatted string
Here is a query returning a collection of `TableEntity` objects that possess the specified partition key.

```C# Snippet:TablesSample4QueryEntitiesFilter
Pageable<TableEntity> queryResultsFilter = client.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");

// Iterate the <see cref="Pageable"> to access all queried entities.
foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");
```

### LINQ expression
Here is a query returning a collection of the strongly-typed `OfficeSupplyEntity` objects that cost at least $6.00.

```C# Snippet:TablesSample4QueryEntitiesExpression
// Use the <see cref="TableClient"> to query the table using a filter expression.
double priceCutOff = 6.00;
Pageable<OfficeSupplyEntity> queryResultsLINQ = client.Query<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);
```

## Query entities with `select`
To query entities and obtain specific properties, call `Query`, specify the desired entity return type, and pass in an `IEnumerable` populated with the names of properties you would like to retrieve.

```C# Snippet:TablesSample4QueryEntitiesSelect
Pageable<TableEntity> queryResultsSelect = client.Query<TableEntity>(select: new List<string>() { "Product", "Price"});
```

## Query entities with `maxPerPage`
To query entities by page, call `Query`, specify the desired entity return type, and pass in the desired maximum number of entities per page.

// TODO: `maxPerPage` may be removed. Might only need to show page-by-page iteration?

```C# Snippet:TablesSample4QueryEntitiesMaxPerPage
Pageable<TableEntity> queryResultsMaxPerPage = client.Query<TableEntity>(maxPerPage: 10);

// Iterate the <see cref="Pageable"> by page.
foreach (Page<TableEntity> page in queryResultsMaxPerPage.AsPages())
{
    Console.WriteLine("This is a new page!");
    foreach (TableEntity qEntity in page.Values)
    {
        Console.WriteLine($"# of {qEntity.GetString("Product")} inventoried: {qEntity.GetInt32("Quantity")}");
    }
}
```
---
To see the full example source files, see:
- [Synchronous QueryEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample4_QueryEntities.cs)
- [Asynchronous QueryEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample4_QueryEntitiesAsync.cs)