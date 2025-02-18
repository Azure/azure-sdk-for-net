# Azure Storage Data Movement Common client library for .NET

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant.

The Azure Storage Data Movement library is optimized for uploading, downloading and
copying customer data.

Currently this version of the Data Movement library only supports Blobs and File Shares.

[Source code][source] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.DataMovement` client library will be included:

```dotnetcli
dotnet add package Azure.Storage.DataMovement
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

Authentication is specific to the targeted storage service. Please see documentation for the individual services:
- [Blob](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs/README.md#authenticate-the-client)
- [File Share](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Files.Shares/README.md#authenticate-the-client)

### Permissions

Data Movement must have appropriate permissions to the storage resources.
Permissions are specific to the type of storage Data Movement is connected to.

- [Blob storage permissions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement.Blobs/README.md#permissions)
- [File share permissions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement.Files.Shares/README.md#permissions)

## Key concepts

The Azure Storage DataMovement client library contains shared infrastructure like
[TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet), [TransferManager](#setup-the-transfermanager) and [RequestFailedException][RequestFailedException].

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

This section demonstrates usage of Data Movement regardless of extension package. Package-specific information and usage samples can be found in that package's documentation. These examples will use local disk and Azure Blob Storage when specific resources are needed for demonstration purposes, but the topics here will apply to other packages.

### Setup the `TransferManager`

Singleton usage of `TransferManager` is recommended. Providing `TransferManagerOptions` is optional.

```C# Snippet:CreateTransferManagerSimple_BasePackage
TransferManager transferManager = new TransferManager(new TransferManagerOptions());
```

### Starting New Transfers

Transfers are defined by a source and destination `StorageResource`. There are two kinds of `StorageResource`: `StorageResourceSingle` and `StorageResourceContainer`. Source and destination of a given transfer must be of the same kind.

`StorageResource` instances are obtained from `StorageResourceProvider` instances. See [Initializing Local File StorageResource(s)](#initializing-local-file-storageresource) for more information on the resource provider for local files and directories. See the [Next Steps](#next-steps) for our DataMovement extension packages for more info on their respective `StorageResourceProvider` types.

The sample below demonstrates `StorageResourceProvider` use to start transfers by uploading a file to Azure Blob Storage, using the Azure.Storage.DataMovement.Blobs package. It uses an Azure.Core `TokenCredential` generated from Azure.Identity `DefaultAzureCredential()` with permission to write to the blob.

```C# Snippet:SimpleBlobUpload_BasePackage
TokenCredential defaultTokenCredential = new DefaultAzureCredential();
BlobsStorageResourceProvider blobs = new BlobsStorageResourceProvider(defaultTokenCredential);

// Create simple transfer single blob upload job
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalPath),
    destinationResource: await blobs.FromBlobAsync(destinationBlobUri));
await transferOperation.WaitForCompletionAsync();
```

The sample below demonstrates `StorageResourceProvider` use to start transfers by uploading a file to Azure Share File Storage, using the Azure.Storage.DataMovement.Files.Shares package. It uses an Azure.Core `TokenCredential` generated from Azure.Identity `DefaultAzureCredential()` with permission to write to the blob.

```C# Snippet:SimplefileUpload_Shares
TokenCredential tokenCredential = new DefaultAzureCredential();
ShareFilesStorageResourceProvider shares = new(tokenCredential);
TransferManager transferManager = new TransferManager(new TransferManagerOptions());
TransferOperation fileTransfer = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalFile),
    destinationResource: await shares.FromFileAsync(destinationFileUri));
await fileTransfer.WaitForCompletionAsync();
```

See more examples of starting a transfer respective to each storage service:
- [Blob](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs#upload)
- [Share Files](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Files.Shares#upload)

### Initializing Local File or Directory `StorageResource`

Local filesystem resources are provided by `LocalFilesStorageResourceProvider`. This provider requires no setup to produce storage resources.

```csharp
LocalFilesStorageResourceProvider files = new();
StorageResource fileResource = files.FromFile("C:/path/to/file.txt");
StorageResource directoryResource = files.FromDirectory("C:/path/to/dir");
```

## Troubleshooting

See [Handling Failed Transfers](#handling-failed-transfers) and [Enabling Logging](https://learn.microsoft.com/dotnet/azure/sdk/logging) to assist with any troubleshooting.

See [Known Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/KnownIssues.md) for detailed information.

## Next steps

Get started with our [Blob DataMovement samples][blob_samples].

Get started with our [Share File DataMovement samples][share_samples].

For advanced scenarios regarding the `TransferManager` see [TransferManager Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/samples/TransferManager.md).

For advanced scenarios regarding the `TransferManager.StartTransfer()` operation, see [Start Transfer Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/samples/StartTransfer.md).

For advanced scenarios and information regarding Resume, Pause and/or checkpointing see [Pause and Resume, Checkpointing Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/samples/PauseResumeCheckpointing.md).

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

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement/src
[docs]: https://learn.microsoft.com/dotnet/api/azure.storage
[rest_docs]: https://learn.microsoft.com/rest/api/storageservices/
[product_docs]: https://learn.microsoft.com/azure/storage/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[auth_credentials]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/src/StorageSharedKeyCredential.cs
[blobs_examples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs#examples
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[blob_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs/samples
[share_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Files.Shares/samples
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
