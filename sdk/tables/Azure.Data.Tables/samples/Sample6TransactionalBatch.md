# Transactional Batches

This sample demonstrates how to create and submit transactional batches for table entities.
The Table service supports batch transactions on entities that are in the same table and belong to the same partition group.\
Multiple Add, Update, Upsert, and Delete operations are supported within a single transaction.

You will need to have previously [created a table](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/samples/Sample1CreateDeleteTables.md) in the service in order to submit a transactional batch request.
To get started, you'll need access to either a Storage or Cosmos DB account.

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

## Adding entities with a transactional batch

A common use case for batch operations is to add many entities to a table in bulk.

```C# Snippet:BatchAdd
// Create a list of 5 entities with the same partition key.
string partitionKey = "BatchInsertSample";
List<TableEntity> entityList = new List<TableEntity>
{
    new TableEntity(partitionKey, "01")
    {
        { "Product", "Marker" },
        { "Price", 5.00 },
        { "Brand", "Premium" }
    },
    new TableEntity(partitionKey, "02")
    {
        { "Product", "Pen" },
        { "Price", 3.00 },
        { "Brand", "Premium" }
    },
    new TableEntity(partitionKey, "03")
    {
        { "Product", "Paper" },
        { "Price", 0.10 },
        { "Brand", "Premium" }
    },
    new TableEntity(partitionKey, "04")
    {
        { "Product", "Glue" },
        { "Price", 1.00 },
        { "Brand", "Generic" }
    },
};

// Create the batch.
List<TableTransactionAction> addEntitiesBatch = new List<TableTransactionAction>();

// Add the entities to be added to the batch.
addEntitiesBatch.AddRange(entityList.Select(e => new TableTransactionAction(TableTransactionActionType.Add, e)));

// Submit the batch.
Response<IReadOnlyList<Response>> response = await client.SubmitTransactionAsync(addEntitiesBatch).ConfigureAwait(false);

for (int i = 0; i < entityList.Count; i++)
{
    Console.WriteLine($"The ETag for the entity with RowKey: '{entityList[i].RowKey}' is {response.Value[i].Headers.ETag}");
}
```

## Mixed operations

Many different types of operations can be executed within a single batch. Below is an example demonstrating the combination of delete, merge, and update within a single transactional batch operations.
This example assumes we already have added the entities from the previous add entities example.

```C# Snippet:BatchMixed
// Create a new batch.
List<TableTransactionAction> mixedBatch = new List<TableTransactionAction>();

// Add an entity for deletion to the batch.
mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.Delete, entityList[0]));

// Remove this entity from our list so that we can track that it will no longer be in the table.
entityList.RemoveAt(0);

// Change only the price of the entity with a RoyKey equal to "02".
TableEntity mergeEntity = new TableEntity(partitionKey, "02") { { "Price", 3.50 }, };

// Add a merge operation to the batch.
// We specify an ETag value of ETag.All to indicate that this merge should be unconditional.
mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.UpdateMerge, mergeEntity, ETag.All));

// Update a property on an entity.
TableEntity updateEntity = entityList[2];
updateEntity["Brand"] = "Generic";

// Add an upsert operation to the batch.
// Using the UpsertEntity method allows us to implicitly ignore the ETag value.
mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.UpsertReplace, updateEntity));

// Submit the batch.
await client.SubmitTransactionAsync(mixedBatch).ConfigureAwait(false);
```

## Deleting entities with a transactional batch

Let's clean up the rest of the entities remaining in the table with a batch delete.

```C# Snippet:BatchDelete
// Create a new batch.
List<TableTransactionAction> deleteEntitiesBatch = new List<TableTransactionAction>();

// Add the entities for deletion to the batch.
foreach (TableEntity entityToDelete in entityList)
{
    deleteEntitiesBatch.Add(new TableTransactionAction(TableTransactionActionType.Delete, entityToDelete));
}

// Submit the batch.
await client.SubmitTransactionAsync(deleteEntitiesBatch).ConfigureAwait(false);
```

---
To see the full example source files, see:
- [Transactional batches](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample6_TransactionalBatchAsync.cs)
