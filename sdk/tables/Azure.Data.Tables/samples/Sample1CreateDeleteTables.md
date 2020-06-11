# Creating and Deleting Tables
This sample demonstrates how to create and delete a table. To get started, you'll need either a Storage or Cosmos DB account.

## Creating a `TableServiceClient`
A `TableServiceClient` performs account-level operations like creating and deleting tables. Authentication will be taken care of by creating a `TableSharedKeyCredential` which requires the account name as well as the account key.

You can set `accountName` and `storageAccountKey` based on an environment variable, configuration setting, or any way that works for your application.

For the purpose of this test, we are going to use a Storage Resource.

```C# Snippet:TablesSample1CreateClient
// Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.
var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

## Creating a Table
To create a table, create a `TableClient` by invoking `CreateTable` from the `TableServiceClient`. A `TableClient` represents a single table and performs table-level operations like inserting and deleting entities within that table. `tableName` can be replaced with any string to be the name of the table. Tables must have unique names.

```C# Snippet:TablesSample1CreateTable
// Create a new table. The <see cref="TableItem" /> class stores properties of the created table.
TableItem table = serviceClient.CreateTable(tableName);
Console.WriteLine($"The created table's name is {table.TableName}.");
```

## Deleting a Table
To delete the table, invoke `DeleteTable` from the service client with the table name.

```C# Snippet:TablesSample1DeleteTable
// Deletes the table made previously.
serviceClient.DeleteTable(tableName);
```

## Handling Errors
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