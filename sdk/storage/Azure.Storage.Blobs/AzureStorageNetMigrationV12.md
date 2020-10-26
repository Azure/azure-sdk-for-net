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

#### Azure Active Directory

v11

TODO

v12

```csharp
public async Task ActiveDirectoryAuthAsync()
{
    // Create a token credential that can use our Azure Active
    // Directory application to authenticate with Azure Storage
    TokenCredential credential =
        new ClientSecretCredential(
            ActiveDirectoryTenantId,
            ActiveDirectoryApplicationId,
            ActiveDirectoryApplicationSecret,
            new TokenCredentialOptions() { AuthorityHost = ActiveDirectoryAuthEndpoint });

    // Create a client that can authenticate using our token credential
    BlobServiceClient service = new BlobServiceClient(ActiveDirectoryBlobUri, credential);

    // Make a service request to verify we've successfully authenticated
    await service.GetPropertiesAsync();
}
```

#### SAS

There are various SAS tokens that may be generated. Visit our documentation pages to learn how to [Create a User Delegation SAS](https://docs.microsoft.com/azure/storage/blobs/storage-blob-user-delegation-sas-create-dotnet), [Create a Service SAS](https://docs.microsoft.com/azure/storage/blobs/storage-blob-service-sas-create-dotnet), or [Create an Account SAS](https://docs.microsoft.com/azure/storage/common/storage-account-sas-create-dotnet?toc=/azure/storage/blobs/toc.json).

v11
```csharp
string sasBlobToken;

// Get a reference to a blob within the container.
// Note that the blob may not exist yet, but a SAS can still be created for it.
CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

if (policyName == null)
{
   // Create a new access policy and define its constraints.
   // Note that the SharedAccessBlobPolicy class is used both to define the parameters of an ad hoc SAS, and
   // to construct a shared access policy that is saved to the container's shared access policies.
   SharedAccessBlobPolicy adHocSAS = new SharedAccessBlobPolicy()
   {
       // When the start time for the SAS is omitted, the start time is assumed to be the time when the storage service receives the request.
       // Omitting the start time for a SAS that is effective immediately helps to avoid clock skew.
       SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
       Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
   };

   // Generate the shared access signature on the blob, setting the constraints directly on the signature.
   sasBlobToken = blob.GetSharedAccessSignature(adHocSAS);

   Console.WriteLine("SAS for blob (ad hoc): {0}", sasBlobToken);
   Console.WriteLine();
}
else
{
   // Generate the shared access signature on the blob. In this case, all of the constraints for the
   // shared access signature are specified on the container's stored access policy.
   sasBlobToken = blob.GetSharedAccessSignature(null, policyName);

   Console.WriteLine("SAS for blob (stored access policy): {0}", sasBlobToken);
   Console.WriteLine();
}

// Return the URI string for the container, including the SAS token.
return blob.Uri + sasBlobToken;
```

v12
```csharp
// Create BlobSasBuilder and specify parameters
BlobSasBuilder sasBuilder = new BlobSasBuilder()
{
    BlobContainerName = containerName,
    BlobName = blobName,
    ExpiresOn = new DateTimeOffset
    IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None)
};
// Set Permissions
sasBuilder.SetPermissions(BlobSasPermissions.Read);

// Create SasQueryParameters
BlobSasQueryParameters parameters = sasBuilder.ToSasQueryParameters(sharedKeyCredential);

// Create Uri with SasToken
BlobUriBuilder uriBuilder = new BlobUriBuilder(blobUri)
{
    Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
};
Uri sasUri = uriBuilder.ToUri()
```

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

To learn more, visit our article [Create a Stored Access Policy with .NET](https://docs.microsoft.com/azure/storage/common/storage-stored-access-policy-define-dotnet) or take a look at the code comparison below.

v11
```csharp
private static async Task CreateStoredAccessPolicyAsync(CloudBlobContainer container, string policyName)
{
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
}
```

v12
```csharp
async static Task CreateStoredAccessPolicyAsync(string containerName)
{
    string connectionString = "";

    // Use the connection string to authorize the operation to create the access policy.
    // Azure AD does not support the Set Container ACL operation that creates the policy.
    BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);

    try
    {
        await containerClient.CreateIfNotExistsAsync();

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
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine(e.ErrorCode);
        Console.WriteLine(e.Message);
    }
    finally
    {
        await containerClient.DeleteAsync();
    }
}
```

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
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("yourcontainer");
await containerClient.CreateAsync()
```

Or you can skip a step by using the `BlobServiceClient.CreateBlobContainerAsync()` method.

```csharp
// Create a BlobServiceClient object which will be used to create a container client
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync("yourcontainer");
```


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
