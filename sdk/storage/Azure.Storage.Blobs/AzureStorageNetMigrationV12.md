# Migration Guide: From Microsoft.Azure.Storage.Blob to Azure.Storage.Blobs

This guide intends to assist customers in migrating from the legacy version 11 of the Azure Storage .NET library for Blobs to version 12.
It will focus on side-by-side comparisons for similar operations between the v12 package, [`Azure.Storage.Blobs`](https://www.nuget.org/packages/Azure.Storage.Blobs) and v11 package, [`Microsoft.Azure.Storage.Blob`](https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/).

Familiarity with the v11 client library is assumed. For those new to the Azure Storage Blobs client library for .NET, please refer to the [Quickstart](https://docs.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-dotnet) for the v12 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Authentication](#authentication)
  - [Package and namespaces](#package-and-namespaces)
  - [Client hierarchy](#client-hierarchy)
  - [Client constructors](#client-constructors)
- [Migration samples](#migration-samples)
  - [Creating a Container](#creating-a-container)
  - [Uploading Blobs to a Container](#uploading-blobs-to-a-container)
  - [Downloading Blobs from a Container](#downloading-blobs-from-a-container)
  - [Listing Blobs in a Container](#listing-blobs-in-a-container)
  - [Other](#other)
- [Additional information](#additional-information)

## Migration benefits

To understand why we created our version 12 client libraries, you may refer to the Tech Community blog post, [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) or refer to our video [Introducing the New Azure SDKs](https://aka.ms/azsdk/intro).

Included are the following:
- Thread-safe synchronous and asynchronous APIs
- Improved performance
- Consistent and idiomatic code organization, naming, and API structure, aligned with a set of common guidelines
- The learning curve associated with the libraries was reduced

Note: The blog post linked above announces deprecation for previous versions of the library.

## General changes

### Package and namespaces

Package names and the namespaces root for version 12 Azure client libraries follow the pattern `Azure.[Area].[Service]` where the legacy libraries followed the pattern `Microsoft.Azure.[Area].[Service]`.

In this case, to install the legacy v11 package with Nuget:
```
dotnet add package Microsoft.Azure.Storage.Blob
```

It is now the following for v12:
```
dotnet add package Azure.Storage.Blobs
```

### Authentication

#### Managed Identity

v11

TODO

v12

TODO

#### SAS

There are various SAS tokens that may be generated. Visit our documentation pages to learn how to [Create a User Delegation SAS](https://docs.microsoft.com/azure/storage/blobs/storage-blob-user-delegation-sas-create-dotnet), [Create a Service SAS](https://docs.microsoft.com/azure/storage/blobs/storage-blob-service-sas-create-dotnet), or [Create an Account SAS](https://docs.microsoft.com/azure/storage/common/storage-account-sas-create-dotnet?toc=/azure/storage/blobs/toc.json).

v11
```csharp
TODO
```

v12
```csharp
// This code snippet creates a service level SAS that only allows reading
// from service level APIs
AccountSasBuilder sas = new AccountSasBuilder
{
    // Allow access to blobs
    Services = AccountSasServices.Blobs,
    // Allow access to the service level APIs
    ResourceTypes = AccountSasResourceTypes.Service,
    // Access expires in 1 hour!
    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
};
// Allow read access
sas.SetPermissions(AccountSasPermissions.Read);
// Create a SharedKeyCredential that we can use to sign the SAS token
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);
// Build a SAS URI
UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
sasUri.Query = sas.ToSasQueryParameters(credential).ToString();
// Create a client that can authenticate with the SAS URI
BlobServiceClient service = new BlobServiceClient(sasUri.Uri);
// Make a service request to verify we've successfully authenticated
await service.GetPropertiesAsync();
```

Summary:

#### Connection string

The following code assumes you have acquired your connection string (you can do so from the Access Keys tab under Settings in your Portal Storage Account blade). It is recommended to store it in an environment variable. Below demonstrates how to parse the connection string in v11 vs v12.

Legacy (v11)
```csharp
string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
// Check whether the connection string can be parsed.
CloudStorageAccount storageAccount;
if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
{
    // If the connection string is valid, proceed with operations against Blob
    // storage here.
}
else
{
    // Otherwise, user needs to define the environment variable.
}
```

v12
```csharp
string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
// Create a client that can authenticate with a connection string
BlobServiceClient service = new BlobServiceClient(connectionString);
// Make a service request to verify we've successfully authenticated
await service.GetPropertiesAsync();
```

### Shared Access Policies

TODO

### Client hierarchy

In the interest of simplifying the API surface we've made a three top level clients that can be used to interact with a majority of your resources: `BlobServiceClient`, `BlobContainerClient`, and `BlobClient`.

[//]: # (Blob Metadata, properties, and attributes...)

### Client constructors

| v11 | v12 |
|-------|--------|
| `CloudStorageAccount` | `BlobServiceClient` |
| `CloudBlobContainer`  | `BlobContainerClient` |
| `CloudBlobDirectory` | Not supported |
| `CloudBlob` | `BlobBaseClient` |
| `CloudBlockBlob` | `BlockBlobClient` |
| `CloudPageBlob` | `PageBlobClient` |
| `CloudAppendBlob` | `AppendBlobClient` |

### Creating a Container

v11
```csharp
// Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
CloudBlobContainer cloudBlobContainer =
    cloudBlobClient.GetContainerReference("yourcontainer");
await cloudBlobContainer.CreateAsync();
```

v12
```csharp
// Create a BlobServiceClient object which will be used to create a container client
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
// Create a unique name for the container
string containerName = "yourcontainer";
// Create the container and return a container client object
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
```

Summary: In v11, a `CloudBlobClient` was required to get a reference to the desired blob container. In v12, the intermediate step `cloudBlobClient.GetContainerReference("yourcontainer")` was removed.


### Uploading Blobs to a Container

v11
```csharp
// Assumes cloudBlobContainer already contains a reference to the container.
// filename is the intended blob name as a string
// localFilePath should be the path to the local file you want to upload
// Get a reference to the blob address, then upload the file to the blob.
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
await cloudBlockBlob.UploadFromFileAsync(localFilePath);
```

v12
```csharp
// Assumes container already exists on the service.
// blobName is desired name of new blob in the service
// localFilePath should be the path to the local file you want to upload
// Get a reference to a blob
BlobClient blobClient = containerClient.GetBlobClient(blobName);
// choose the file to upload
await blobClient.UploadAsync(localFilePath, overwrite: true);
```

Summary: In v11, a file path was used to upload a blob. In v12, `Stream` is used to upload a blob's content.


### Downloading Blobs from a Container

v11
```csharp
// Assumes you have already created a reference to the blob via blobClient
// downloadFilePath should be the path to the intended file to download the blob to
await cloudBlockBlob.DownloadToFileAsync(downloadFilePath, FileMode.Create);
```

v12
```csharp
// Assumes you have already created a reference to the blob via blobClient
// downloadFilePath should be the path to the intended file to download the blob to
BlobDownloadInfo download = await blobClient.DownloadAsync();
using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
{
    await download.Content.CopyToAsync(downloadFileStream);
    downloadFileStream.Close();
}
```

### Listing Blobs in a Container

v11
```csharp
// List the blobs in the container.
// Assumes a reference to the container via `cloudBlobContainer`
BlobContinuationToken blobContinuationToken = null;
do
{
    var results = await cloudBlobContainer.ListBlobsSegmentedAsync(null, blobContinuationToken);
    // Get the value of the continuation token returned by the listing call.
    blobContinuationToken = results.ContinuationToken;
    foreach (IListBlobItem item in results.Results)
    {
        Console.WriteLine(item.Uri);
    }
} while (blobContinuationToken != null); // Loop while the continuation token is not null.
```

v12
```csharp
// Get a reference to the container
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
// List all blobs in the container
await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine("\t" + blobItem.Name);
}
```

### Other

## Additional information

### Samples
More examples can be found at:
- [Azure Storage samples using v12 .NET Client Libraries](https://docs.microsoft.com/azure/storage/common/storage-samples-dotnet?toc=/azure/storage/blobs/toc.json)

### Links and references
- [Quickstart](https://docs.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-dotnet)
- [Samples](https://docs.microsoft.com/azure/storage/common/storage-samples-dotnet?toc=/azure/storage/blobs/toc.json)
- [.NET SDK reference](https://docs.microsoft.com/dotnet/api/azure.storage.blobs?view=azure-dotnet)
- [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) blog post
