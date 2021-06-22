# Migration guide from Microsoft.Azure.Cosmos.Table to Azure.Data.Tables

This guide is intended to assist in the migration to the `Azure.Data.Tables` package from the legacy `Microsoft.Azure.CosmosDB.Table` package focusing on
side-by-side comparisons for similar operations between the to versions.

Familiarity with the `Microsoft.Azure.CosmosDB.Table` package is assumed. If you are new to the Azure Tables client library for .NET, please refer to the
[README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/README.md) and
[samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/tables/Azure.Data.Tables/samples) rather than this guide.

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and
been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to
understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for
different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning
curve was difficult, and the APIs did not offer a good, approachable, and consistent on-boarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Tables, a set of uniform
[design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent
experience with established API patterns for all services. A set of
[.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic
feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Azure Tables library, `Azure.Data.Tables`, provides the ability to share in some of the cross-service improvements made to the Azure development experience.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Services]` where the
legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using
the modern or legacy clients.

In the case of Tables, the modern client library is named `Azure.Data.Tables` and was released beginning with version 12. The legacy client libraries have packages
and namespaces that begin with `Microsoft.Azure.CosmosDB` or `Microsoft.Azure.Storage` and a version of 2.x.x or below and 9.x.x or below respectively.

### Constructing the clients

Previously in `Microsoft.Azure.Comsmos.Table`, you would create a `CloudStorageAccount` which can be used to get an instance of the `CloudTableClient` in order to
perform service level operations.

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
// Construct a new "TableServiceClient using a TableSharedKeyCredential.

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

### Creating a table

Previously in `Microsoft.Azure.Comsmos.Table`, we'd use a `CloudTable` instance to create a table, which is returned from the `CloudTableClient` method on
`CloudTableClient`.

```C#
// Create a table client and create the table if it doesn't already exist.
string tableName = "OfficeSupplies1p1";
CloudTable cloudTable = tableClient.GetTableReference(tableName);
cloudTable.CreateIfNotExists()
```

With `Azure.Data.Tables` we have access to all table level operations directly from the `TableServiceClient`. Because the table service client is not affinitized to
any one table, it is ideal for scenarios where you need to create, delete, or list more than one table.

```C# Snippet:TablesSample1CreateTable
// Create a new table. The TableItem class stores properties of the created table.
string tableName = "OfficeSupplies1p1";
TableItem table = serviceClient.CreateTableIfNotExists(tableName);
Console.WriteLine($"The created table's name is {table.Name}.");
```

If your intention is to work only in the context of a single table, it's also possible to create a table from the `TableClient`.
```C# Snippet:TablesMigrationCreateTableWithClient
// Get a reference to the TableClient from the service client instance.
var tableClient = serviceClient.GetTableClient(tableName);

// Create the table if it doesn't exist.
tableClient.CreateIfNotExists();
```

### Adding data to the table

Let's define an office supply entity so that we can add it to the table. To do so, we'll first need to define our custom entity types.

Previously in `Microsoft.Azure.Comsmos.Table`, our entity would inherit from the `TableEntity` base class and look like this:

```c#
public class OfficeSupplyOld : Microsoft.Azure.Cosmos.Table.TableEntity
{
	public string Product { get; set; }
	public double Price { get; set; }
	public int Quantity { get; set; }
}
```

Now in `Azure.Data.Tables`, we will implement the `ITableEntity` interface to define our entity.

```C# Snippet:TablesSample2DefineStronglyTypedEntity
// Define a strongly typed entity by implementing the ITableEntity interface.
public class OfficeSupplyEntity : ITableEntity
{
    public string Product { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}
```

Now let's populate an entity to add to the table for each version of the client.

For `Microsoft.Azure.Cosmos.Table.TableEntity`:

```c#
string partitionKey = "Stationery";
string rowKey = "A1";

// Create an instance of the strongly-typed entity and set their properties.
var entity = new OfficeSupplyOld
{
    PartitionKey = partitionKey,
    RowKey = rowKey,
    Product = "Marker Set",
    Price = 5.00,
    Quantity = 21
};
```

For `ITableEntity`:

```C# Snippet:TablesMigrationCreateEntity
// Create an instance of the strongly-typed entity and set their properties.
var entity = new OfficeSupplyEntity
{
    PartitionKey = partitionKey,
    RowKey = rowKey,
    Product = "Marker Set",
    Price = 5.00,
    Quantity = 21
};
```

Previously in `Microsoft.Azure.Comsmos.Table`, we would create a `TableOperation` and execute it with the table client.
The result of the operation must be casted back to the entity type.

```c#
// Create the InsertOrReplace table operation
TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

// Execute the operation.
TableResult result = cloudTable.Execute(insertOrMergeOperation);

// Cast the result.
OfficeSupplyOld insertedCustomer = result.Result as OfficeSupplyOld;
```

Now in `Azure.Data.Tables`, using the `TableClient`, we can simply pass our entity to the `UpsertEntity` method which will create or update the entity depending on whether
or not it already exists.

```C# Snippet:TablesMigrationUpsertEntity
// Upsert the newly created entity.
tableClient.UpsertEntity(entity);
```

### Fetching a single entity from the table

Both clients allow for fetching a single entity from the table if the `PartitionKey` and `RowKey` are known.

Previously in `Microsoft.Azure.Comsmos.Table`, we created an operation and then executed it, similar to when we added the item to the cloudTable.

```c#
// Create the operation.
TableOperation retrieveOperation = TableOperation.Retrieve<OfficeSupplyOld>(partitionKey, rowKey);

// Execute the operation.
TableResult queryResult = cloudTable.Execute(retrieveOperation);

// Cast the result.
OfficeSupplyOld marker = queryResult.Result as OfficeSupplyOld;

// Display the values.
Console.WriteLine($"{marker.PartitionKey}, {marker.RowKey}, {marker.Product}, {marker.Price}, {marker.Quantity}");
}
```

Now in `Azure.Data.Tables`, the generic GetEntity method is a one-liner.
```C# Snippet:MigrationGetEntity
// Get the entity.
OfficeSupplyEntity marker = tableClient.GetEntity<OfficeSupplyEntity>(partitionKey, rowKey);

// Display the values.
Console.WriteLine($"{marker.PartitionKey}, {marker.RowKey}, {marker.Product}, {marker.Price}, {marker.Quantity}");
```

### Querying data from the table

Previously in `Microsoft.Azure.Comsmos.Table`, creating an executing a query looked as follows.

```c#
// Create the query.
var query = cloudTable.CreateQuery<OfficeSupplyOld>().Where(e => e.PartitionKey == "Markers" && e.RowKey == "A1");

// Execute the query.
var queryResults = query.ToList();

// Diesplay the results.
foreach (var item in queryResults)
{
    Console.WriteLine($"{item.PartitionKey}, {item.RowKey}, {item.Product}, {item.Price}, {item.Quantity}");
}
```

Now in `Azure.Data.Tables`, we query with a single line of code and return the results as a `Pagageable<T>`. You'll find the `Pageable` type used consistently
throughout all the new Azure SDK clients when an operation returns a paged result.

Another difference you may notice with the new client is that rather than implementing a full `IQueryable` LINQ provider, we've only implemented support for a filter
expression. This approach helps to prevent accidentally writing LINQ expressions that return every item from the table to run a filter on the result locally.

```C# Snippet:TablesMigrationQuery
// Execute the query.
Pageable<OfficeSupplyEntity> queryResults = tableClient.Query<OfficeSupplyEntity>(e => e.PartitionKey == partitionKey && e.RowKey == rowKey);

// Display the results
foreach (var item in queryResults.ToList())
{
    Console.WriteLine($"{item.PartitionKey}, {item.RowKey}, {item.Product}, {item.Price}, {item.Quantity}");
}
```

### Delete table entities

Previously with `Microsoft.Azure.Cosmos.Table`, deleting a table entity was accomplished with the following code.

```c#
TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
TableResult result = cloudTable.Execute(deleteOperation);
```

Now in `Azure.Data.Tables`, deleting an entity requires just the `ParitionKey` and `RowKey` values.

```C# Snippet:TablesSample2DeleteEntity
// Delete the entity given the partition and row key.
tableClient.DeleteEntity(partitionKey, rowKey);
```

### Batch transactions

Previously with `Microsoft.Azure.Cosmos.Table`, creating and executing a transactional batch operation involved creating a `TableBatchOperation` which contained the
`TableOperation`(s) to be executed. The result from `ExecuteBatch` was a `TableBatchResult` which is essentially a collection of `TableResult`s.

```c#
// Create a TableBatchOperation and populate it with our TableOperations.
TableBatchOperation batch = new TableBatchOperation()
{
    TableOperation.InsertOrMerge(entity)
};

// Execute the transaction.
TableBatchResult batchResult = cloudTable.ExecuteBatch(batch);

// Display the ETags for each item in the result.
foreach (TableResult result in batchResult)
{
    OfficeSupplyOld item = result.Result as OfficeSupplyOld;
    Console.WriteLine($"The ETag for the entity with RowKey: '{item.RowKey}' is {item.ETag}");
}
```

Now in `Azure.Data.Tables`, there is no longer a stand alone type to represent a transactional batch collection, rather you build an enumerable of
`TableTransactionAction`s. Executing the transaction is accomplished by passing this collection to the `SubmitTransaction` method on the `TableClient`. The result
from `SubmitTransaction` is the standard `Response<T>` returned by most service operations found in the new Azure SDK client libraries, with the `T` being an
`IReadonlyList<Response>`. This list of responses represent the response for each operation executed within the transaction.

```C# Snippet:MigrationBatchAdd
// Create a collection of TableTransactionActions and populate it with the actions for each entity.
List<TableTransactionAction> batch = new List<TableTransactionAction>
{
    new TableTransactionAction(TableTransactionActionType.UpdateMerge, entity)
};

// Execute the transaction.
Response<IReadOnlyList<Response>> batchResult = tableClient.SubmitTransaction(batch);

// Display the ETags for each item in the result.
// Note that the ordering between the entties in the batch and the responses in the batch responses will always be conssitent.
for (int i = 0; i < batch.Count; i++)
{
    Console.WriteLine($"The ETag for the entity with RowKey: '{batch[i].Entity.RowKey}' is {batchResult.Value[i].Headers.ETag}");
}
```

## Additional Samples
Additional samples can be found [here](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/tables/Azure.Data.Tables/samples).
