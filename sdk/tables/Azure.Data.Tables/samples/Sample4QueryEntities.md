# Query Entities

This sample demonstrates how to query a table for entities. You will need to have previously [created a table](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/samples/Sample1CreateDeleteTables.md) in the service in order to query entities from it. To get started, you'll need access to either a Storage or Cosmos DB account.

## Create a `TableClient`

A `TableClient` is needed to perform table-level operations like inserting and deleting entities within the table, so it is ideal for dealing with only a specific table. There are two ways to get a `TableClient`:
- Call `GetTableClient` from the `TableServiceClient` with the table name.

```C# Snippet:TablesSample1GetTableClient
string tableName = "OfficeSupplies1p2";
var tableClient = serviceClient.GetTableClient(tableName);
```

- Create a `TableClient` with a SAS URI, an endpoint and `TableSharedKeyCredential`, or a connection string.

```C# Snippet:TablesSample1CreateTableClient
var tableClient = new TableClient(
    new Uri(storageUri),
    tableName,
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

If you are not familiar with creating tables, refer to the sample on [creating and deleting tables](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/samples/Sample1CreateDeleteTables.md).

## Query entities with `filter`

To query entities that satisfy a specified filter, call `Query`, specify the desired entity return type, and pass in a filter in the form of either an OData formatted string or a LINQ expression.

### OData formatted string

Here is a query returning a collection of dictionary `TableEntity` objects that possess the specified partition key.

```C# Snippet:TablesSample4QueryEntitiesFilter
Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");

// Iterate the <see cref="Pageable"> to access all queried entities.
foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");
```

Hand formatting OData query filters can be tricky, so there is a helper class called `QueryFilter` to help make it easier.
For example, OData filters require that strings be single quoted, and DateTime values be single quoted and prefixed with `datetime`.
The `QueryFilter` class handles all the type escaping for you.

```C# Snippet:TablesSample4QueryEntitiesFilterWithQueryFilter
// The CreateQueryFilter method is also available to assist with properly formatting and escaping OData queries.
Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: TableClient.CreateQueryFilter($"PartitionKey eq {partitionKey}"));
// Iterate the <see cref="Pageable"> to access all queried entities.
foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");
```

### LINQ expression

Here is a query returning a collection of the strongly-typed `OfficeSupplyEntity` objects that cost at least $6.00.

To define the strongly-typed class, refer to the sample on [creating classes](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/samples/Sample2CreateDeleteEntities.md).

```C# Snippet:TablesSample4QueryEntitiesExpression
double priceCutOff = 6.00;
Pageable<OfficeSupplyEntity> queryResultsLINQ = tableClient.Query<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);
```

## Query entities with `select`

To query entities and obtain specific properties, call `Query`, specify the desired entity return type, and pass in an `IEnumerable` populated with the names of properties you would like to retrieve.

```C# Snippet:TablesSample4QueryEntitiesSelect
Pageable<TableEntity> queryResultsSelect = tableClient.Query<TableEntity>(select: new List<string>() { "Product", "Price" });
```

## Query entities with `maxPerPage`

To query entities by page, call `Query`, specify the desired entity return type, and pass in the desired maximum number of entities per page.

// TODO: `maxPerPage` may be removed. Might only need to show page-by-page iteration?

```C# Snippet:TablesSample4QueryEntitiesMaxPerPage
Pageable<TableEntity> queryResultsMaxPerPage = tableClient.Query<TableEntity>(maxPerPage: 10);

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
- [Synchronous Query Entities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample4_QueryEntities.cs)
- [Asynchronous Query Entities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample4_QueryEntitiesAsync.cs)
