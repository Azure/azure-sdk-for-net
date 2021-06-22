# Query Tables

This sample demonstrates how to query the service for tables. To get started, you'll need access to either a Storage or Cosmos DB account.

## Create a `TableServiceClient`

A `TableServiceClient` performs account-level operations like creating and deleting tables. To create a `TableServiceClient`, you will need a SAS URI, an endpoint and `TableSharedKeyCredential`, or a connection string.

In the sample below, we will use a Storage account and authenticate with an endpoint and `TableSharedKeyCredential`, which requires an account name and an account key. You can set `accountName` and `storageAccountKey` with an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:TablesSample1CreateClient
// Construct a new "TableServiceClient using a TableSharedKeyCredential.

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    new TableSharedKeyCredential(accountName, storageAccountKey));
```

## Query tables

To get a collection of tables, call `GetTables` and optionally pass in an OData filter string. Passing no parameters will return all tables. The returned collection is of type `Pageable<TableItem>`, and each `TableItem` stores metadata of a given table.

```C# Snippet:TablesSample3QueryTables
// Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.

Pageable<TableItem> queryTableResults = serviceClient.Query(filter: $"TableName eq '{tableName}'");

Console.WriteLine("The following are the names of the tables in the query results:");

// Iterate the <see cref="Pageable"> in order to access queried tables.

foreach (TableItem table in queryTableResults)
{
    Console.WriteLine(table.Name);
}
```

---
To see the full example source files, see:
- [Synchronous Query Tables](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample3_QueryTables.cs)
- [Asynchronous Query Tables](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/tables/Azure.Data.Tables/tests/samples/Sample3_QueryTablesAsync.cs)
