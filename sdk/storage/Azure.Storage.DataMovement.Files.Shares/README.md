# Azure Storage Data Movement File Shares client library for .NET

> Server Version: 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2020-02-02

## Project Status: Beta

This product is in beta. Some features will be missing or have significant bugs. Please see [Known Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/KnownIssues.md) for detailed information.

---

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant. Azure Storage
includes Azure Blobs (objects), Azure Data Lake Storage Gen2, Azure Files,
and Azure Queues.

The Azure Storage Data Movement library is optimized for uploading, downloading and
copying customer data.

The Azure.Storage.DataMovement.Files.Shares library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.DataMovement.Files.Shares` client library will be included:

```dotnetcli
dotnet add package Azure.Storage.DataMovement --prerelease
dotnet add package Azure.Storage.DataMovement.Files.Shares --prerelease
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

### Authenticate the client
The Azure.Storage.DataMovement.Files.Shares library uses clients from the Azure.Storage.Files.Shares package to communicate with the Azure File Storage service. For more information see the Azure.Storage.Files.Shares [authentication documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Files.Shares#authenticate-the-client).

## Key concepts

The Azure Storage Common client library contains shared infrastructure like
[authentication credentials][auth_credentials] and [RequestFailedException][RequestFailedException].

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

This section demonstrates usage of Data Movement for interacting with file shares.

### Initializing File Share `StorageResource`

Azure.Storage.DataMovement.Files.Shares exposes `ShareFilesStorageResourceProvider` to create `StorageResource` instances for files and directories. The resource provider should be initialized with a credential to properly authenticate the storage resources. The following demonstrates this using an `Azure.Core` token credential.

```C# Snippet:MakeProvider_TokenCredential_Shares
ShareFilesStorageResourceProvider shares = new(tokenCredential);
```

To create a share `StorageResource`, use the methods `FromFile` or `FromDirectory`.

```C# Snippet:ResourceConstruction_Shares
StorageResource directory = shares.FromDirectory(
    "http://myaccount.files.core.windows.net/share/path/to/directory");
StorageResource rootDirectory = shares.FromDirectory(
    "http://myaccount.files.core.windows.net/share");
StorageResource file = shares.FromFile(
    "http://myaccount.files.core.windows.net/share/path/to/file.txt");
```

Storage resources can also be initialized with the appropriate client object from Azure.Storage.Files.Shares. Since these resources will use the credential already present in the client object, no credential is required in the provider when using `FromClient()`. **However**, a `ShareFilesStorageResourceProvider` must still have a credential if it is to be used in `TransferManagerOptions` for resuming a transfer.

```C# Snippet:ResourceConstruction_FromClients_Shares
ShareFilesStorageResourceProvider shares = new();
StorageResource shareDirectoryResource = shares.FromClient(directoryClient);
StorageResource shareFileResource = shares.FromClient(fileClient);
```

### Upload

An upload takes place between a local file `StorageResource` as source and file share `StorageResource` as destination.

Upload a file.

```C# Snippet:SimplefileUpload_Shares
DataTransfer fileTransfer = await transferManager.StartTransferAsync(
    sourceResource: files.FromFile(sourceLocalFile),
    destinationResource: shares.FromFile(destinationFileUri));
await fileTransfer.WaitForCompletionAsync();
```

Upload a directory.

```C# Snippet:SimpleDirectoryUpload_Shares
DataTransfer folderTransfer = await transferManager.StartTransferAsync(
    sourceResource: files.FromFile(sourceLocalDirectory),
    destinationResource: shares.FromDirectory(destinationFolderUri));
await folderTransfer.WaitForCompletionAsync();
```

### Download

A download takes place between a file share `StorageResource` as source and local file `StorageResource` as destination.

Download a file.

```C# Snippet:SimpleFileDownload_Shares
DataTransfer fileTransfer = await transferManager.StartTransferAsync(
    sourceResource: shares.FromFile(sourceFileUri),
    destinationResource: files.FromFile(destinationLocalFile));
await fileTransfer.WaitForCompletionAsync();
```

Download a Directory.

```C# Snippet:SimpleDirectoryDownload_Shares
DataTransfer directoryTransfer = await transferManager.StartTransferAsync(
    sourceResource: shares.FromDirectory(sourceDirectoryUri),
    destinationResource: files.FromDirectory(destinationLocalDirectory));
await directoryTransfer.WaitForCompletionAsync();
```

### File Copy

A copy takes place between two share `StorageResource` instances. Copying between two files or directories uses PUT from URL REST APIs, which do not transfer data through the machine running DataMovement.

Copy a single file.

```C# Snippet:s2sCopyFile_Shares
DataTransfer fileTransfer = await transferManager.StartTransferAsync(
    sourceResource: shares.FromFile(sourceFileUri),
    destinationResource: shares.FromFile(destinationFileUri));
await fileTransfer.WaitForCompletionAsync();
```

Copy a directory.

```C# Snippet:s2sCopyDirectory_Shares
DataTransfer directoryTransfer = await transferManager.StartTransferAsync(
    sourceResource: shares.FromDirectory(sourceDirectoryUri),
    destinationResource: shares.FromDirectory(destinationDirectoryUri));
await directoryTransfer.WaitForCompletionAsync();
```

## Troubleshooting

***TODO***

## Next steps

***TODO***

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to these libraries.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Common%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Common/src
[package]: https://www.nuget.org/packages/Azure.Storage.Common/
[docs]: https://docs.microsoft.com/dotnet/api/azure.storage
[rest_docs]: https://docs.microsoft.com/rest/api/storageservices/
[product_docs]: https://docs.microsoft.com/azure/storage/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Files.Shares/samples
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
