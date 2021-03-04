# Authentication

Every request made against an Azure table must be authorized using a connection string, 
shared key credential, or shared access signature. The samples below demonstrate the usage 
of these methods.

## Connection string

A connection string includes the authentication information required for your application to 
access data in an Azure table at runtime using Shared Key authorization.

You can obtain your connection string from the Azure Portal (click **Access Keys** under Settings 
in the Portal Storage account blade or **Connection String** under Settings in the Portal Cosmos DB 
account blade) or using the Azure CLI with:

```
az storage account show-connection-string --name <account_name> --resource-group <resource_group>
```
or
```
 az cosmosdb list-connection-strings --name <account_name> --resource-group <resource_group>
```

```C# Snippet:TablesAuthConnString
// Construct a new TableClient using a connection string.

var client = new TableClient(
    connectionString,
    tableName);

// Create the table if it doesn't already exist to verify we've successfully authenticated.

await client.CreateIfNotExistsAsync();
```

## Shared Key Credential

Shared Key authorization relies on your account access keys and other parameters to produce 
an encrypted signature string that is passed on the request in the Authorization header.

You'll need a Storage or Cosmos DB **account name**, **primary key**, and **endpoint** Uri.
You can obtain both from the Azure Portal by clicking **Access Keys** under Settings in the 
Portal Storage account blade or **Connection String** under Settings in the Portal Cosmos DB 
account blade.

You can also get access to your account keys from the Azure CLI with:

```
az storage account keys list --account-name <account_name> --resource-group <resource_group>
```

or

```
az cosmosdb list-keys --name <account_name> --resource-group <resource_group>
```

```C# Snippet:TablesAuthSharedKey
// Construct a new TableClient using a TableSharedKeyCredential.

var client = new TableClient(
    new Uri(storageUri),
    tableName,
    new TableSharedKeyCredential(accountName, accountKey));

// Create the table if it doesn't already exist to verify we've successfully authenticated.

await client.CreateIfNotExistsAsync();
```

## Shared Access Signature (SAS)

A shared access signature allows administrators to delegate granular access to an Azure table 
without sharing the access key directly. You can control what resources the client may access, 
what permissions they have on those resources, and how long the SAS is valid, among other parameters. 
It relies on your account access keys and other parameters to produce an encrypted signature string 
that is passed on the request in the query string.

To generate a new SAS, you must first start with a Storage or Cosmos DB **account name**, **primary key**, and **endpoint** Uri.
You can obtain both from the Azure Portal by clicking **Access Keys** under Settings in the 
Portal Storage account blade or **Connection String** under Settings in the Portal Cosmos DB 
account blade.

```C# Snippet:TablesAuthSas
// Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.

var credential = new TableSharedKeyCredential(accountName, accountKey);

var serviceClient = new TableServiceClient(
    new Uri(storageUri),
    credential);

// Build a shared access signature with the Write and Delete permissions and access to all service resource types.

TableAccountSasBuilder sasWriteDelete = serviceClient.GetSasBuilder(TableAccountSasPermissions.Write | TableAccountSasPermissions.Delete, TableAccountSasResourceTypes.All, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
string tokenWriteDelete = sasWriteDelete.Sign(credential);

// Create the TableServiceClients using the SAS URIs.

var serviceClientWithSas = new TableServiceClient(new Uri(storageUri), new AzureSasCredential(tokenWriteDelete));

// Validate that we are able to create a table using the SAS URI with Write and Delete permissions.

await serviceClientWithSas.CreateTableIfNotExistsAsync(tableName);

// Validate that we are able to delete a table using the SAS URI with Write and Delete permissions.

await serviceClientWithSas.DeleteTableAsync(tableName);
```
