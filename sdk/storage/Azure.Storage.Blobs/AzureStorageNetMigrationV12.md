# Migration Guide: From Microsoft.Azure.Storage.Blob to Azure.Storage.Blobs

This guide intends to assist customers in migrating from legacy versions of the Azure Storage .NET library for Blobs to version 12.
While this guide is generally applicable to older versions of the SDK, it was written with v11 in mind as the starting point.
It will focus on side-by-side comparisons for similar operations between the v12 package, [`Azure.Storage.Blobs`](https://www.nuget.org/packages/Azure.Storage.Blobs) and v11 package, [`Microsoft.Azure.Storage.Blob`](https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/).

Familiarity with the legacy client library is assumed. For those new to the Azure Storage Blobs client library for .NET, please refer to the [Quickstart](https://learn.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-dotnet) for the v12 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Authentication](#authentication)
  - [Shared access policies](#shared-access-policies)
  - [Client structure](#client-structure)
    - [Migrating from CloudBlockBlob](#migrating-from-cloudblockblob)
    - [Migrating from CloudBlobDirectory](#migrating-from-cloudblobdirectory)
    - [Class Conversion Reference](#class-conversion-reference)
- [Migration samples](#migration-samples)
  - [Creating a Container](#creating-a-container)
  - [Uploading Blobs to a Container](#uploading-blobs-to-a-container)
  - [Downloading Blobs from a Container](#downloading-blobs-from-a-container)
  - [Listing Blobs in a Container](#listing-blobs-in-a-container)
  - [Managing Blob Metadata](#managing-blob-metadata)
  - [Generate a SAS](#generate-a-sas)
  - [Content Hashes](#content-hashes)
  - [Resiliency](#resiliency)
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

#### Azure Active Directory

v11

The legacy Storage SDK contained a `TokenCredential` class that could be used to populate a `StorageCredentials` instance. Constructors took a string token for HTTP authorization headers and an optional refresh mechanism for the library to invoke when the token expired. Users could then use Microsoft.IdentityModel.Clients.ActiveDirectory to get their own token for the TokenCredential, and to use in their own handwritten token refresh mechanism.

v12

A `TokenCredential` abstract class (different API surface than v11) exists in the Azure.Core package that all libraries of the new Azure SDK family depend on, and can be used to construct Storage clients. Implementations of this class can be found separately in the [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity) package. [`DefaultAzureCredential`](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#defaultazurecredential) is a good starting point, with code as simple as the following:

```C# Snippet:SampleSnippetsBlobMigration_TokenCredential
BlobServiceClient client = new BlobServiceClient(new Uri(serviceUri), new DefaultAzureCredential());
```

You can view more [Identity samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#examples) for how to authenticate with the Identity package.

#### SAS

This section regards authenticating a client with an existing SAS. For migration samples regarding SAS generation, go to [Generate a SAS](#generate-a-sas).

v11

In general, SAS tokens can be provided on their own to be applied as needed, or as a complete, self-authenticating URL. The legacy library allowed providing a SAS through `StorageCredentials` as well as constructing with a complete URL.

```csharp
string sasQueryString; // the provided SAS
Uri blobLocation; // URI to a blob the SAS grants access to
StorageCredentials credentials = new StorageCredentials(sasQueryString);
CloudBlob blob = new CloudBlob(blobLocation, credentials);
```

```csharp
CloudBlob blob = new CloudBlob(new Uri(blobLocationWithSAS));
```

v12

The new library only supports constructing a client with a fully constructed SAS URI. Note that since client URIs are immutable once created, a new client instance with a new SAS must be created in order to rotate a SAS.

```C# Snippet:SampleSnippetsBlobMigration_SasUri
BlobClient blob = new BlobClient(sasUri);
```

#### Connection string

The following code assumes you have acquired your connection string (you can do so from the Access Keys tab under Settings in your Portal Storage Account blade). It is recommended to store it in an environment variable. Below demonstrates how to parse the connection string in v11 vs v12.

Legacy (v11)
```csharp
// Create a client that can authenticate with a connection string, using a try pattern.
CloudStorageAccount storageAccount;
if (!CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
{
    // handle failure
}
CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
```

v12
```C# Snippet:SampleSnippetsBlobMigration_ConnectionString
BlobServiceClient service = new BlobServiceClient(connectionString);
```

You can also directly get a blob client with your connection string, instead of going through a service and container client to get to your desired blob. You just need to provide the container and blob names alongside the connection string.

```C# Snippet:SampleSnippetsBlobMigration_ConnectionStringDirectBlob
BlobClient blob = new BlobClient(connectionString, containerName, blobName);
```

Note that in v11, you could access the shared key storage credential on `CloudBlobClient` after creating the instance with a connection string. This would allow you to rotate the shared key on an existing instance. v12 does NOT provide that access. If your code rotates a shared key within a client, you must used shared key authentication directly, as described in the following section.

#### Shared Key

Shared key authentication requires the URI to the storage endpoint, the storage account name, and the shared key as a base64 string. The following code assumes you have acquired your shared key (you can do so from the Access Keys tab under Settings in your Portal Storage Account blade). It is recommended to store it in an environment variable.

Note that the URI to your storage account can generally be derived from the account name (though some exceptions exist), and so you can track only the account name and key. These examples will assume that is the case, though you can substitute your specific account URI if you do not follow this pattern.

Legacy (v11)
```csharp
StorageCredentials credentials = new StorageCredentials(accountName, accountKey);
CloudBlobClient blobClient = new CloudBlobClient(new Uri(blobServiceUri), credentials);
```

v12
```C# Snippet:SampleSnippetsBlobMigration_SharedKey
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);
BlobServiceClient service = new BlobServiceClient(new Uri(blobServiceUri), credential);
```

If you wish to rotate the key within your `BlobServiceClient` (and any derived clients), you must retain a reference to the `StorageSharedKeyCredential`, which has the instance method `SetAccountKey(string accountKey)`.

### Shared Access Policies

To learn more, visit our article [Create a Stored Access Policy with .NET](https://learn.microsoft.com/azure/storage/common/storage-stored-access-policy-define-dotnet) or take a look at the code comparison below.

v11
```csharp
// Create a new stored access policy and define its constraints.
// The access policy provides create, write, read, list, and delete permissions.
SharedAccessBlobPolicy sharedPolicy = new SharedAccessBlobPolicy()
{
    // When the start time for the SAS is omitted, the start time is assumed to be the time when Azure Storage receives the request.
    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List |
        SharedAccessBlobPermissions.Write
};

// Get the container's existing permissions.
BlobContainerPermissions permissions = await container.GetPermissionsAsync();

// Add the new policy to the container's permissions, and set the container's permissions.
permissions.SharedAccessPolicies.Add(policyName, sharedPolicy);
await container.SetPermissionsAsync(permissions);
```

v12
```C# Snippet:SampleSnippetsBlobMigration_SharedAccessPolicy
// Create one or more stored access policies.
List<BlobSignedIdentifier> signedIdentifiers = new List<BlobSignedIdentifier>
{
    new BlobSignedIdentifier
    {
        Id = "mysignedidentifier",
        AccessPolicy = new BlobAccessPolicy
        {
            StartsOn = DateTimeOffset.UtcNow.AddHours(-1),
            ExpiresOn = DateTimeOffset.UtcNow.AddDays(1),
            Permissions = "rw"
        }
    }
};
// Set the container's access policy.
await containerClient.SetAccessPolicyAsync(permissions: signedIdentifiers);
```

### Client Structure

**The legacy SDK used a stateful model.** There were container and blob objects that held state regarding service resources and required the user to manually call their update methods. But blob contents were not a part of this state and had to be uploaded/downloaded whenever they were to be interacted with. This became increasingly confusing over time, and increasingly susceptible to thread safety issues.

The modern SDK has taken a client-based approach. There are no objects designed to be representations of storage resources, but instead clients that act as your mechanism to interact with your storage resources in the cloud. **Clients hold no state of your resources.** This is most noticable when looking at [blob metadata](#managing-blob-metadata).

The hierarchical structure of Azure Blob Storage can be understood by the following diagram:  
![Blob Storage Hierarchy](https://learn.microsoft.com/en-us/azure/storage/blobs/media/storage-blobs-introduction/blob1.png)

In the interest of simplifying the API surface, v12 uses three top level clients to match this structure that can be used to interact with a majority of your resources: `BlobServiceClient`, `BlobContainerClient`, and `BlobClient`. Note that blob-type-specific operations can still be accessed by their specific clients, as in v11.

#### Migrating from CloudBlockBlob

We recommend `BlobClient` as a starting place when migrating code that used v11's `CloudBlockBlob`.

`BlobClient` doesn't have a true equivalent to any classes in v11. v12 contains `BlobBaseClient` as an analog for `CloudBlob` and `BlockBlobClient` as an analog for `CloudBlockBlob`. `BlobClient` is a new class to interact with blobs in Azure Storage. It trades off advanced functionality like partial blob updates for an easier to understand abstraction of blobs, where you do not need to worry about blob types or their implementation mechanisms. Blobs created through `BlobClient` are block blobs in Azure Storage, and you can later switch your code over to using `BlockBlobClient`s with no extra steps involving your already-stored data.

#### Migrating from CloudBlobDirectory

Note the absence of a v12 equivalent for v11's `CloudBlobDirectory`. Directories were an SDK-only concept that did not exist in Azure Blob Storage, and which were not brought forwards into the modern Storage SDK. As shown by the diagram in [Client Structure](#client-structure), containers only contain a flat list of blobs, but those blobs can be named and listed in ways that imply a folder-like structure. See our [Listing Blobs in a Container](#listing-blobs-in-a-container) migration samples later in this guide for more information.

For those whose workloads revolve around manipulating directories and heavily relied on the leagacy SDKs abstraction of this structure, consider the [pros and cons of enabling hierarchical namespace](https://learn.microsoft.com/azure/storage/blobs/data-lake-storage-namespace) on your storage account, which would allow switching to the [Data Lake gen 2 SDK](https://learn.microsoft.com/dotnet/api/overview/azure/storage.files.datalake-readme), whose migration is not covered in this document.

#### Class Conversion Reference

The following table lists v11 classes and their v12 equivalents for quick reference.

| v11 | v12 |
|-------|--------|
| `CloudBlobClient` | `BlobServiceClient` |
| `CloudBlobContainer`  | `BlobContainerClient` |
| `CloudBlobDirectory` | No equivalent |
| No equivalent | `BlobClient` |
| `CloudBlob` | `BlobBaseClient` |
| `CloudBlockBlob` | `BlockBlobClient` |
| `CloudPageBlob` | `PageBlobClient` |
| `CloudAppendBlob` | `AppendBlobClient` |

## Migration Samples

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

```C# Snippet:SampleSnippetsBlobMigration_CreateContainer
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
await containerClient.CreateAsync();
```

Or you can skip a step by using the `BlobServiceClient.CreateBlobContainerAsync()` method.

```C# Snippet:SampleSnippetsBlobMigration_CreateContainerShortcut
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
```


### Uploading Blobs to a Container

#### Uploading from a file

v11
```csharp
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
await cloudBlockBlob.UploadFromFileAsync(localFilePath);
```

v12
```C# Snippet:SampleSnippetsBlobMigration_UploadBlob
BlobClient blobClient = containerClient.GetBlobClient(blobName);
await blobClient.UploadAsync(localFilePath, overwrite: true);
```

#### Uploading from a stream

v11
```csharp
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
using Stream stream = File.OpenRead(localFilePath);
await cloudBlockBlob.UploadFromStreamAsync(stream);
```

v12
```C# Snippet:SampleSnippetsBlobMigration_UploadBlobFromStream
BlobClient blobClient = containerClient.GetBlobClient(blobName);
using Stream stream = File.OpenRead(localFilePath);
await blobClient.UploadAsync(stream, overwrite: true);
```

#### Uploading text

v11
```csharp
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
await blob.UploadTextAsync("content");
```

v12
```C# Snippet:SampleSnippetsBlobMigration_UploadBlobText
BlobClient blobClient = containerClient.GetBlobClient(blobName);
await blobClient.UploadAsync(BinaryData.FromString("hello world"), overwrite: true);
```

### Downloading Blobs from a Container

#### Downloading to a file

v11
```csharp
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
await cloudBlockBlob.DownloadToFileAsync(downloadFilePath, FileMode.Create);
```

v12
```C# Snippet:SampleSnippetsBlobMigration_DownloadBlob
BlobClient blobClient = containerClient.GetBlobClient(blobName);
await blobClient.DownloadToAsync(downloadFilePath);
```

#### Downloading to a stream

v11
```csharp
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
using Stream target = File.OpenWrite(downloadFilePath);
await blob.DownloadToStreamAsync(target);
```

v12
```C# Snippet:SampleSnippetsBlobMigration_DownloadBlobToStream
BlobClient blobClient = containerClient.GetBlobClient(blobName);
using (Stream target = File.OpenWrite(downloadFilePath))
{
    await blobClient.DownloadToAsync(target);
}
```

#### Downloading text

v11
```csharp
CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
string content = await blob.DownloadTextAsync();
```

v12
```C# Snippet:SampleSnippetsBlobMigration_DownloadBlobText
BlobClient blobClient = containerClient.GetBlobClient(blobName);
BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
string downloadedData = downloadResult.Content.ToString();
```


### Listing Blobs in a Container

#### Flat Listing

Azure Blob Storage lists blobs in a container as a paged response. Both the modern and legacy SDKs allow you to either
- receive an `IEnumerable` that lazily requests subsequent pages to present a single stream of results
- request individual pages and manually request any subsequent pages via continuation token (note that manual iteration is the only way to pick up a listing where you may have left off)

v11 lazy enumerable
```csharp
IEnumerable<IListBlobItem> results = cloudBlobContainer.ListBlobs();
foreach (IListBlobItem item in results)
{
    // process blob listing
}
```
Note there is no asynchronous overload of a lazy enumerator in v11. Users desiring async performance were required to use manual page iteration and asynchronously request each page.

v11 manual interation
```csharp
// set this to already existing continuation token to pick up where you previously left off
BlobContinuationToken blobContinuationToken = null;
do
{
    BlobResultSegment resultSegment = await cloudBlobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
    blobContinuationToken = resultSegment.ContinuationToken;
    foreach (IListBlobItem item in resultSegment.Results)
    {
        // process blob listing
    }
} while (blobContinuationToken != null); // Loop while the continuation token is not null.
```

v12 lazy enumerable
```C# Snippet:SampleSnippetsBlobMigration_ListBlobs
IAsyncEnumerable<BlobItem> results = containerClient.GetBlobsAsync();
await foreach (BlobItem item in results)
{
    MyConsumeBlobItemFunc(item);
}
```

v12 manual iteration

The result we declared an `IAsyncEnumerable<T>` in the previous example was actually an `AsyncPagable<T>`, an implementation provided by the Azure.Core package. This class contains the method `AsPages()`, which returns an `IAsyncEnumerable<Page<T>>`. This is how you can go page by page in the modern Storage SDK.

```C# Snippet:SampleSnippetsBlobMigration_ListBlobsManual
// set this to already existing continuation token to pick up where you previously left off
string initialContinuationToken = null;
AsyncPageable<BlobItem> results = containerClient.GetBlobsAsync();
IAsyncEnumerable<Page<BlobItem>> pages =  results.AsPages(initialContinuationToken);

// the foreach loop requests the next page of results every loop
// you do not need to explicitly access the continuation token just to get the next page
// to stop requesting new pages, break from the loop
// you also have access to the contination token returned with each page if needed
await foreach (Page<BlobItem> page in pages)
{
    // process page
    foreach (BlobItem item in page.Values)
    {
        MyConsumeBlobItemFunc(item);
    }

    // access continuation token if desired
    string continuationToken = page.ContinuationToken;
}
```

#### Hierarchical Listing

See the [list blobs documentation](https://learn.microsoft.com/azure/storage/blobs/storage-blobs-list?tabs=dotnet#flat-listing-versus-hierarchical-listing) for more information on what a hierarchical listing is.

While manual page iteration as described in the previous section is still applicable to a hierarchical listing, this section will only give examples using lazy enumerables.

v11

`ListBlobs()` and `ListBlobsSegmented()` that were used in a flat listing contain overloads with a string parameter `prefix`, which results in a flat listing when `null`. Provide a value to perform a hierarchical listing with that prefix.
```csharp
IEnumerable<IListBlobItem> results = cloudBlobContainer.ListBlobs(prefix: blobPrefix);
foreach (IListBlobItem item in results)
{
    // process blob listing
}
```

v12

v12 has explicit methods for listing by hierarchy.
```C# Snippet:SampleSnippetsBlobMigration_ListHierarchy
GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
{
    Prefix = blobPrefix,
    Delimiter = delimiter
};
IAsyncEnumerable<BlobHierarchyItem> results = containerClient.GetBlobsByHierarchyAsync(options);
await foreach (BlobHierarchyItem item in results)
{
    MyConsumeBlobItemFunc(item);
}
```

### Managing Blob Metadata

On the service, blob metadata is overwritten alongside blob data overwrites. If metadata is not provided on a blob content edit, that is interpreted as a metadata clear. Legacy versions of the SDK mitigated this by maintaining blob metadata internally and sending it for you on appropriate requests. This helped in simple cases, but could fall out of sync and required developers to defensively code against metadata changes in a multi-client scenario anyway.

V12 has abandoned this stateful approach, having users manage their own metadata. While this requires additional code for developers, it ensures you always know how your metadata is being managed and avoid silently corrupting metadata due to SDK caching.

v11 samples:

The legacy SDK maintained a metadata cache, allowing you to modify metadata on the CloudBlob and invoke Update(). Calling FetchAttributes beforehand refreshed the metadata cache to avoid undoing recent changes.

```csharp
cloudBlob.FetchAttributes();
cloudBlob.Metadata.Add("foo", "bar");
cloudBlob.SetMetadata(metadata);
```

The legacy SDK maintained internal state for blob content uploads. Calling FetchAttributes beforehand refreshed the metadata cache to avoid undoing recent changes.

```csharp
// download blob content. blob metadata is fetched and cached on download
cloudBlob.DownloadToByteArray(downloadBuffer, 0);

// modify blob content
string modifiedBlobContent = Encoding.UTF8.GetString(downloadBuffer) + "FizzBuzz";

// reupload modified blob content while preserving metadata
blobClient.UploadText(modifiedBlobContent);
```

v12 samples:

The modern SDK requires you to hold onto metadata and update it approprately before sending off. You cannot just add a new key-value pair, you must update the collection and send the collection.

```C# Snippet:SampleSnippetsBlobMigration_EditMetadata
IDictionary<string, string> metadata = blobClient.GetProperties().Value.Metadata;
metadata.Add("foo", "bar");
blobClient.SetMetadata(metadata);
```

Additionally with blob content edits, if your blobs have metadata you need to get the metadata and reupload with that metadata, telling the service what metadata goes with this new blob state.

```C# Snippet:SampleSnippetsBlobMigration_EditBlobWithMetadata
// download blob content and metadata
BlobDownloadResult blobData = blobClient.DownloadContent();

// modify blob content
string modifiedBlobContent = blobData.Content + "FizzBuzz";

// reupload modified blob content while preserving metadata
// not adding metadata is a metadata clear
blobClient.Upload(
    BinaryData.FromString(modifiedBlobContent),
    new BlobUploadOptions() { Metadata = blobData.Details.Metadata });
```

### Generate a SAS

 There are various SAS tokens that may be generated. Visit our documentation pages to learn more: [Create a User Delegation SAS](https://learn.microsoft.com/azure/storage/blobs/storage-blob-user-delegation-sas-create-dotnet), [Create a Service SAS](https://learn.microsoft.com/azure/storage/blobs/storage-blob-service-sas-create-dotnet), or [Create an Account SAS](https://learn.microsoft.com/azure/storage/common/storage-account-sas-create-dotnet?toc=/azure/storage/blobs/toc.json).

v11

The following example is for creating a SAS to a single blob in the legacy library, but this pattern is applicable to container SAS and service SAS as well.

```csharp
// blob to generate a SAS for, must be authenticated with shared key
CloudBlob blob;

// Create a new access policy and define its constraints.
SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
{
    // SAS will be valid immetiately until 24 hours from now
    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
    Permissions = SharedAccessBlobPermissions.Read |
        SharedAccessBlobPermissions.Write |
        SharedAccessBlobPermissions.Create
    // other optional parameters specified here
};

// Generate a SAS with the given policy, scoped to this blob
string sasBlobToken = blob.GetSharedAccessSignature(sasPolicy);

// optionally combine with URI for a full, self-authenticated URI to the blob
return blob.Uri + sasBlobToken;
```

You could also make a SAS using a predefined policy stored on the service, instead of defining it in code.

```csharp
sasBlobToken = blob.GetSharedAccessSignature(null, policyName);
```

v12

The modern SDK uses a builder pattern for constructing a SAS token. Similar to the pattern to create a SAS in v11, you can generate a SAS URI from the client. This is the preferred method in order to prevent passing the key to more than one place. It also is more convenient to generate from the client in the case of authenticating with a connection string, as you would not have to parse the connection string to grab the storage account name and key.

To create a simple SAS with any optional parameters, use the convenience overload of GenerateSas which only requires taking in permissions and the expiry time.

```C# Snippet:SampleSnippetsBlobMigration_GenerateSas
// Create a BlobClient with a shared key credential
BlobClient blobClient = new BlobClient(blobUri, sharedKeyCredential);

Uri sasUri;
// Ensure our client has the credentials required to generate a SAS
if (blobClient.CanGenerateSasUri)
{
    // Create full, self-authenticating URI to the resource from the BlobClient
    sasUri = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1));

    // Use newly made as SAS URI to download the blob
    await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
}
```

To create a more complex SAS pass the SAS builder to the GenerateSas method.

```C# Snippet:SampleSnippetsBlobMigration_GenerateSas_Builder
BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
{
    // Since we are generating from the client, the client will have the container and blob name
    // Specify any optional paremeters here
    StartsOn = DateTimeOffset.UtcNow.AddHours(-1)
};

// Create full, self-authenticating URI to the resource from the BlobClient
Uri sasUri = blobClient.GenerateSasUri(sasBuilder);
```

You can also generate a SAS without use of the client.

```C# Snippet:SampleSnippetsBlobMigration_SasBuilder
// Create BlobSasBuilder and specify parameters
BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
{
    // with no url in a client to read from, container and blob name must be provided if applicable
    BlobContainerName = containerName,
    BlobName = blobName
};

// Create full, self-authenticating URI to the resource
BlobUriBuilder uriBuilder = new BlobUriBuilder(StorageAccountBlobUri)
{
    BlobContainerName = containerName,
    BlobName = blobName,
    Sas = sasBuilder.ToSasQueryParameters(sharedKeyCredential)
};
Uri sasUri = uriBuilder.ToUri();
```

If using a stored access policy, construct your `BlobSasBuilder` from the example above as follows:

```C# Snippet:SampleSnippetsBlobMigration_SasBuilderIdentifier
// Create BlobSasBuilder and specify parameters
BlobSasBuilder sasBuilder = new BlobSasBuilder
{
    Identifier = "mysignedidentifier"
};
```

To create a simple User Delegation SAS with any optional parameters, use the convenience overload of GenerateUserDelegationSas which only requires taking in permissions and the expiry time.

```C# Snippet:SampleSnippetsBlobMigration_GenerateUserDelegationSas
// Create a BlobClient
BlobClient blobClient = new BlobClient(blobUri);

// Create full, self-authenticating URI to the resource from the BlobClient
Uri sasUri = blobClient.GenerateUserDelegationSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1), userDelegationKey);
```

To create a more complex User Delegation SAS, pass the SAS builder to the GenerateUserDelegationSas method.

```C# Snippet:SampleSnippetsBlobMigration_GenerateUserDelegationSas_Builder
// Create a BlobClient
BlobClient blobClient = new BlobClient(blobUri);
// Create BlobSasBuilder and specify parameters
BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
{
    // Since we are generating from the client, the client will have the container and blob name
    // Specify any optional paremeters here
    StartsOn = DateTimeOffset.UtcNow.AddHours(-1)
};

// Create full, self-authenticating URI to the resource from the BlobClient
Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);
```

You can also generate an User Delegation SAS without use of the client.

```C# Snippet:SampleSnippetsBlobMigration_UserDelegationSasBuilder
// Create BlobSasBuilder and specify parameters
BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
{
    // with no url in a client to read from, container and blob name must be provided if applicable
    BlobContainerName = containerName,
    BlobName = blobName
};

// Create full, self-authenticating URI to the resource
BlobUriBuilder uriBuilder = new BlobUriBuilder(StorageAccountBlobUri)
{
    BlobContainerName = containerName,
    BlobName = blobName,
    Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, accountName)
};
Uri sasUri = uriBuilder.ToUri();
```

### Content Hashes

#### Blob Content MD5

V11 calculated blob content MD5 for validation on download by default, assuming there was a stored MD5 in the blob properties. Calculation and storage on upload was opt-in. Note that this value is not generated or validated by the service, and is only retained for the client to validate against.

v11

```csharp
BlobRequestOptions options = new BlobRequestOptions
{
    ChecksumOptions = new ChecksumOptions()
    {
        DisableContentMD5Validation = false, // true to disable download content validation
        StoreContentMD5 = false // true to calculate content MD5 on upload and store property
    }
};
```

V12 does not have an automated mechanism for blob content validation. It must be done per-request by the user.

v12

```C# Snippet:SampleSnippetsBlobMigration_BlobContentMD5
// upload with blob content hash
await blobClient.UploadAsync(
    contentStream,
    new BlobUploadOptions()
    {
        HttpHeaders = new BlobHttpHeaders()
        {
            ContentHash = precalculatedContentHash
        }
    });

// download whole blob and validate against stored blob content hash
Response<BlobDownloadStreamingResult> response = await blobClient.DownloadStreamingAsync();

Stream downloadStream = response.Value.Content;
byte[] blobContentMD5 = response.Value.Details.BlobContentHash ?? response.Value.Details.ContentHash;
// validate stream against hash in your workflow
```

#### Transactional MD5 and CRC64

Transactional hashes are not stored and have a lifespan of the request they are calculated for. Transactional hashes are verified by the service on upload.

V11 provided transactional hashing on uploads and downloads through opt-in request options. MD5 and Storage's custom CRC64 were supported. The SDK calculated and validated these hashes automatically when enabled. The calculation worked on any upload or download method.

v11

```csharp
BlobRequestOptions options = new BlobRequestOptions
{
    ChecksumOptions = new ChecksumOptions()
    {
        // request fails if both are true
        UseTransactionalMD5 = false, // true to use MD5 on all blob content transactions
        UseTransactionalCRC64 = false // true to use CRC64 on all blob content transactions
    }
};
```

V12 does not currently provide this functionality. Users who manage their own individual upload and download HTTP requests can provide a precalculated MD5 on upload and access the MD5 in the response object. V12 currently offers no API to request a transactional CRC64.

```C# Snippet:SampleSnippetsBlobMigration_TransactionalMD5
// upload a block with transactional hash calculated by user
await blockBlobClient.StageBlockAsync(
    blockId,
    blockContentStream,
    new BlockBlobStageBlockOptions
    {
        TransferValidation = new UploadTransferValidationOptions
        {
            ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
            // a precalculated hash can be provided as follows,
            // the sdk will calculate one for you otherwise
            PrecalculatedChecksum = precalculatedBlockHash
        }
    });

// upload more blocks as needed

// commit block list
await blockBlobClient.CommitBlockListAsync(blockList);

// download any range of blob with transactional MD5 requested (maximum 4 MB for downloads)
Response<BlobDownloadStreamingResult> response = await blockBlobClient.DownloadStreamingAsync(
    new BlobDownloadOptions
    {
        // a range must be provided when requesting checksums; here we use transactional download max size
        Range = new HttpRange(length: 4 * Constants.MB),
        TransferValidation = new DownloadTransferValidationOptions
        {
            ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
            // SDK will validate against checksum for you
            // to disable this and check in your own workflow, uncomment the below
            //Validate = false,
        },
    });

Stream downloadStream = response.Value.Content;
// uncomment below to retrieve checksum for validating in your own workflow
//byte[] transactionalMD5 = response.Value.Details.ContentHash;
```

### Resiliency

#### Retry policy

V11

```csharp
Stream targetStream = new MemoryStream();
BlobRequestOptions options = new BlobRequestOptions()
{
    RetryPolicy = new ExponentialRetry(deltaBackoff: TimeSpan.FromSeconds(10), maxAttempts: 6)
};
await blockBlobClient.DownloadToStreamAsync(targetStream,accessCondition: null, options: options, operationContext: null);
```

V12

```C# Snippet:SampleSnippetsBlobMigration_RetryPolicy
BlobClientOptions blobClientOptions = new BlobClientOptions();
blobClientOptions.Retry.Mode = RetryMode.Exponential;
blobClientOptions.Retry.Delay = TimeSpan.FromSeconds(10);
blobClientOptions.Retry.MaxRetries = 6;
BlobServiceClient service = new BlobServiceClient(connectionString, blobClientOptions);
BlobClient blobClient = service.GetBlobContainerClient(containerName).GetBlobClient(blobName);
Stream targetStream = new MemoryStream();
await blobClient.DownloadToAsync(targetStream);
```

#### Maximum execution time

V11

```csharp
Stream targetStream = new MemoryStream();
BlobRequestOptions options = new BlobRequestOptions()
{
    MaximumExecutionTime = TimeSpan.FromSeconds(30)
};
await blockBlobClient.DownloadToStreamAsync(targetStream,accessCondition: null, options: options, operationContext: null);
```

V12

```C# Snippet:SampleSnippetsBlobMigration_MaximumExecutionTime
BlobClient blobClient = containerClient.GetBlobClient(blobName);
using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
Stream targetStream = new MemoryStream();
await blobClient.DownloadToAsync(targetStream, cancellationTokenSource.Token);
```


## Additional information

### Samples
More examples can be found at:
- [Azure Storage samples using v12 .NET Client Libraries](https://learn.microsoft.com/azure/storage/common/storage-samples-dotnet?toc=/azure/storage/blobs/toc.json)

### Links and references
- [Quickstart](https://learn.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-dotnet)
- [Samples](https://learn.microsoft.com/azure/storage/common/storage-samples-dotnet?toc=/azure/storage/blobs/toc.json)
- [.NET SDK reference](https://learn.microsoft.com/dotnet/api/azure.storage.blobs?view=azure-dotnet)
- [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) blog post
