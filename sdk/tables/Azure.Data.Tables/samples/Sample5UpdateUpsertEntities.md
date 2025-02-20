# Updating and Upserting Table Entities

This sample demonstrates how to query a table for entities. You will need to have previously [created a table](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tables/Azure.Data.Tables/samples/Sample1CreateDeleteTables.md) in the service in order to query entities from it. To get started, you'll need access to either a Storage or Cosmos DB account.

## Create a `TableClient`

A `TableClient` is needed to perform table-level operations like inserting and deleting entities within the table, so it is ideal for dealing with only a specific table. There are two ways to get a `TableClient`:
- Call `GetTableClient` from the `TableServiceClient` with the table name.

```C# Snippet:TablesSample1GetTableClient
var tableClient2 = serviceClient.GetTableClient(tableName);
```

- Create a `TableClient` with a SAS URI, an endpoint and `TableSharedKeyCredential`, or a connection string.

```C# Snippet:TablesSample1CreateTableClient
var tableClient3 = new TableClient(
    new Uri(storageUri),
    tableName,
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

If you are not familiar with creating tables, refer to the sample on [creating and deleting tables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tables/Azure.Data.Tables/samples/Sample1CreateDeleteTables.md).

## Upsert an entity

The upsert operation combines the capabilities of insert and update unconditionally.

```C# Snippet:TablesSample5UpsertEntityAsync
var entity = new TableEntity(partitionKey, rowKey)
{
    {"Product", "Markers" },
    {"Price", 5.00 },
    {"Brand", "myCompany" }
};

// Entity doesn't exist in table, so invoking UpsertEntity will simply insert the entity.
await tableClient.UpsertEntityAsync(entity);
```

```C# Snippet:TablesSample5UpsertWithReplaceAsync
// Delete an entity property.
entity.Remove("Brand");

// Entity does exist in the table, so invoking UpsertEntity will update using the given UpdateMode, which defaults to Merge if not given.
// Since UpdateMode.Replace was passed, the existing entity will be replaced and delete the "Brand" property.
await tableClient.UpsertEntityAsync(entity, TableUpdateMode.Replace);
```

## Update an entity

The update operation adds conditions to support optimistic concurrency.

```C# Snippet:TablesSample5UpdateEntityAsync
// Get the entity to update.
TableEntity qEntity = await tableClient.GetEntityAsync<TableEntity>(partitionKey, rowKey);
qEntity["Price"] = 7.00;

// Since no UpdateMode was passed, the request will default to Merge.
await tableClient.UpdateEntityAsync(qEntity, qEntity.ETag);

TableEntity updatedEntity = await tableClient.GetEntityAsync<TableEntity>(partitionKey, rowKey);
Console.WriteLine($"'Price' before updating: ${entity.GetDouble("Price")}");
Console.WriteLine($"'Price' after updating: ${updatedEntity.GetDouble("Price")}");
```
