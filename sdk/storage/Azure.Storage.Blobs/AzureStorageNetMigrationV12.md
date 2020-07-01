# Guide for migrating to Azure.Storage.Blobs from Microsoft.Azure.Storage.Blob

This guide intends to assist customers in migrating from version 11 of the Azure Storage .NET library for Blobs to version 12.
It will focus on side-by-side comparisons for similar operations between the v12 package, [`Azure.Storage.Blobs`](https://www.nuget.org/packages/Azure.Storage.Blobs) and v11 package, [`Microsoft.Azure.Storage.Blob`](https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/).

Familiarity with the v11 client library is assumed. For those new to the Azure Storage Blobs client library for .NET, please refer to the [Quickstart](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet) for the v12 library rather than this guide.

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
- [Additional samples](#additional-samples)

## Migration benefits

To understand why we created our version 12 client libraries, you may refer to the Tech Community blog post, [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394).

In summary, the v12 client libraries for Azure Storage were created in order to address a number of areas of feedback. One of the most important being that Azure services have not been consistent in organization, naming, and API structure. Azure Storage has aligned with a set of common guidelines in order to focus on quick delivery of service features and to optimize the learning curve that comes with using the libraries. They are idiomatic, approachable, and consistent. The version 12 client libraries are also thread safe, offer both synchronous and asynchronous APIs, and have improved performance over previous versions. We have reached feature parity for major scenarios and have updated documentation featuring the v12 [Quickstart](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet), [Samples](https://docs.microsoft.com/en-us/azure/storage/common/storage-samples-dotnet?toc=/azure/storage/blobs/toc.json), and [Reference](https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs?view=azure-dotnet) pages (for .NET Azure Storage Blob Library).

Note: The blog post linked above announces deprecation for previous versions of the library.

## General changes

### Package and namespaces

Package names and the namespaces root for version 12 Azure client libraries follow the pattern `Azure.[Area].[Service]` where the legacy libraries followed the pattern `Microsoft.Azure.[Area].[Service]`.

In this case, to install the legacy v11 package with Nuget:
```
dotnet add package Azure.Storage.Blobs
```

It is now the following for v12:
```
dotnet add package Microsoft.Azure.Storage.Blob
```

### Authentication

#### Managed Identity

Legacy (v11)

v12

#### SAS

There are various SAS tokens that may be generated. Visit our documentation pages to learn how to [Create a User Delegation SAS](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-user-delegation-sas-create-dotnet), [Create a Service SAS](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-service-sas-create-dotnet), or [Create an Account SAS](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-sas-create-dotnet?toc=/azure/storage/blobs/toc.json).

Legacy (v11)
```c

```

v12
```c
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

The following code assumes you have acquired your connection string (you can do so from the Access Keys tab under Settings in your Portal Storage Account blade). It is recommended to store it in an environment variable.

Parsing the connection string in v11 vs v12.....

Legacy (v11)
```c
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
```c
string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

// Create a client that can authenticate with a connection string
BlobServiceClient service = new BlobServiceClient(connectionString);

// Make a service request to verify we've successfully authenticated
await service.GetPropertiesAsync();
```

### Shared Access Policies

TBD

### Client hierarchy

In the interest of simplifying the API surface we've made a three top level clients that can be used to interact with a majority of your resources: `BlobServiceClient`, `BlobContainerClient`, and `BlobClient`.

[//]: # (Blob Metadata, properties, and attributes...)

### Client constructors

| In v11 | In v12 |
|-------|--------|
| `CloudStorageAccount` | `BlobServiceClient` |
| `CloudBlobContainer`  | `BlobContainerClient` |
| `CloudBlobClient` | `BlobClient` |
| `CloudBlockBlob` | `BlockBlobClient` |

### Creating a Container

v11
```c
// Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

CloudBlobContainer cloudBlobContainer =
    cloudBlobClient.GetContainerReference("yourcontainer");
await cloudBlobContainer.CreateAsync();
```

v12
```c
// Create a BlobServiceClient object which will be used to create a container client
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

// Create a unique name for the container
string containerName = "yourcontainer";

// Create the container and return a container client object
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
```

Summary: In version 11, you would have to use the storage account endpoint to create the `CloudBlobClient`. Then you can get the container reference by calling the `GetContainerReference` method and create it by calling `CreateAsync()` on it. In version 12, you will use the `BlobServiceClient` object to then create `BlobContainerClient`.


### Uploading Blobs to a Container

v11
```c
// Assumes cloudBlobContainer already contains a reference to the container.
// filename is the intended blob name as a string
// localFilePath should be the path to the local file you want to upload

// Get a reference to the blob address, then upload the file to the blob.
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
await cloudBlockBlob.UploadFromFileAsync(localFilePath);
```

v12
```c
// Assumes containerClient already contains a reference to the container.
// filename is the intended blob name as a string
// localFilePath should be the path to the local file you want to upload

// Get a reference to a blob
BlobClient blobClient = containerClient.GetBlobClient(filename);

// Open the file and upload its data
using FileStream uploadFileStream = File.OpenRead(localFilePath);
await blobClient.UploadAsync(uploadFileStream, true);
uploadFileStream.Close();
```

Summary: In v11, you would get the `CloudBlockBlob` reference by calling the `GetBlockBlobReference` method on the container name. Calling `UploadFromFileAsync` would then create the blob if it doesn't exist or overwrite the existing one. In v12, you will get the reference to the `BlobClient` object  by calling the `GetBlobClient` method on the container and then upload the blob using the `UploadAsync` method.


### Downloading Blobs from a Container

Legacy (v11)
```c
// Assumes you have already created a reference to the blob via blobClient
// downloadFilePath should be the path to the intended file to download the blob to
await cloudBlockBlob.DownloadToFileAsync(downloadFilePath, FileMode.Create);
```

v12
```c
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

Legacy (v11)
```c
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
```c
// Get a reference to the container
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

// List all blobs in the container
await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine("\t" + blobItem.Name);
}
```

### Other

## Additional samples

More examples can be found at:
- [Azure Storage samples using v12 .NET Client Libraries](https://docs.microsoft.com/en-us/azure/storage/common/storage-samples-dotnet?toc=/azure/storage/blobs/toc.json)
