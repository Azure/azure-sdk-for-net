# Create and Delete Tables
This sample demonstrates how to create and delete a table. You can use either a `TableServiceClient` or a `TableClient` to create a table based on your needs. To get started, you'll need access to either a Storage or Cosmos DB account.

## Create a `TableServiceClient`
A `TableServiceClient` performs account-level operations like creating and deleting tables, so it is ideal for dealing with multiple tables. To create a `TableServiceClient`, you will need a SAS URI, an endpoint and `TableSharedKeyCredential`, or a connection string.

In the sample below, we will use a Storage account and authenticate with an endpoint and `TableSharedKeyCredential`, which requires an account name and an account key. You can set `accountName` and `storageAccountKey` with an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:TablesSample1CreateClient
// Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```
## Create a `TableClient`
A `TableClient` is needed to perform table-level operations like inserting and deleting entities within the table, so it is ideal for dealing with only a specific table. There are two ways to get a `TableClient`:
- Call `GetTableClient` from the `TableServiceClient` with the table name.

```C# Snippet:TablesSample1GetTableClient
tableName = "OfficeSupplies1p2";
var tableClient = serviceClient.GetTableClient(tableName);
```

- Create a `TableClient` with a SAS URI, an endpoint and `TableSharedKeyCredential`, or a connection string.

```C# Snippet:TablesSample1CreateTableClient
tableClient = new TableClient(
    new Uri(storageUri),
    tableName,
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

## Create a table
A table requires a [unique table name](https://docs.microsoft.com/rest/api/storageservices/understanding-the-table-service-data-model#table-names)

### Using `TableServiceClient`
To create a table, invoke `CreateTable` with the table name.

```C# Snippet:TablesSample1CreateTable
// Create a new table. The <see cref="TableItem" /> class stores properties of the created table.

TableItem table = serviceClient.CreateTable(tableName);
Console.WriteLine($"The created table's name is {table.TableName}.");
```
### Using `TableClient`
To create a table, invoke `Create` with the table name.

```C# Snippet:TablesSample1TableClientCreateTable
tableClient.Create();
```

## Delete a table
### Using `TableServiceClient`
To delete the table, invoke `DeleteTable` with the table name.

```C# Snippet:TablesSample1DeleteTable
// Deletes the table made previously.

serviceClient.DeleteTable(tableName);
```

### Using `TableClient`
To delete the table, invoke `Delete` with the table name.

```C# Snippet:TablesSample1TableClientDeleteTable
tableClient.Delete();
```

## Handle errors
To get more information from a thrown exception when creating and deleting tables, use a try/catch statement to print out the exception.

```C# Snippet:TablesSample1CreateExistingTable
try
{
    // Creates a table.
    serviceClient.CreateTable(tableName);

    // Second attempt to create table with the same name should throw exception.
    serviceClient.CreateTable(tableName);
}
catch (RequestFailedException e)
{
    Console.WriteLine("Create existing table throws the following exception:");
    Console.WriteLine(e.Message);
}
```
---
To see the full example source files, see:
- [Synchronous CreateDeleteTable](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample1_CreateDeleteTable.cs)
- [Asynchronous CreateDeleteTable](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample1_CreateDeleteTableAsync.cs)
- [CreateDeleteTableErrors](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample1_CreateDeleteTableErrors.cs)
