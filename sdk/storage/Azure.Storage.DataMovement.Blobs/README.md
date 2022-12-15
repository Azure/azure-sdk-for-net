# Azure Storage Data Movement Blobs client library for .NET

> Server Version: 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2020-02-02

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant. Azure Storage
includes Azure Blobs (objects), Azure Data Lake Storage Gen2, Azure Files,
and Azure Queues.

The Azure Storage Data Movement library is optimized for uploading, downloading and
copying customer data.

The Azure.Storage.DataMovement.Blobs library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.DataMovement.Blobs` client library will be included:

```dotnetcli
dotnet add package Azure.Storage.DataMovement --prerelease
dotnet add package Azure.Storage.DataMovement.Blobs --prerelease
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
In order to interact with the Data Movement library you have to create an instance with the TransferManager class.

### Create Instance of TransferManager
```C# Snippet:CreateTransferManagerSimple
TransferManager transferManager = new TransferManager(new TransferManagerOptions());
```

### Create Instance of TransferManager with Options
```C# Snippet:CreateTransferManagerWithOptions
// Create BlobTransferManager with event handler in Options bag
TransferManagerOptions transferManagerOptions = new TransferManagerOptions();
ContainerTransferOptions options = new ContainerTransferOptions()
{
    MaximumTransferChunkSize = 4 * Constants.MB,
    CreateMode = StorageResourceCreateMode.Overwrite,
};
TransferManager transferManager = new TransferManager(transferManagerOptions);
```

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
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

Please see the examples for [Blobs][blobs_examples].

### Start Upload from Local File to Block Blob
```C# Snippet:SimpleBlobUpload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new LocalFileStorageResource(sourceLocalPath),
    destinationResource: new BlockBlobStorageResource(destinationBlob));
await dataTransfer.AwaitCompletion();
```

### Apply Options to Block Blob Download
```C# Snippet:BlockBlobDownloadOptions
await transferManager.StartTransferAsync(
    sourceResource: new BlockBlobStorageResource(sourceBlob, new BlockBlobStorageResourceOptions()
    {
        DestinationConditions = new BlobRequestConditions(){ LeaseId = "xyz" }
    }),
    destinationResource: new LocalFileStorageResource(downloadPath2));
```

### Start Directory Upload
```C# Snippet:SimpleDirectoryUpload
// Create simple transfer directory upload job which uploads the directory and the contents of that directory
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new LocalDirectoryStorageResourceContainer(sourcePath),
    destinationResource: new BlobDirectoryStorageResourceContainer(container, "sample-directory2"),
    transferOptions: options);
```

### Start Directory Download
```C# Snippet:SimpleDirectoryDownload
DataTransfer downloadDirectoryJobId2 = await transferManager.StartTransferAsync(
    sourceDirectory2,
    destinationDirectory2);
```

### Simple Logger Sample for Transfer Manager Options
```C# Snippet:SimpleLoggingSample
// Create BlobTransferManager with event handler in Options bag
TransferManagerOptions options = new TransferManagerOptions();
ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
containerTransferOptions.SingleTransferCompleted += (SingleTransferCompletedEventArgs args) =>
{
    using (StreamWriter logStream = File.AppendText(logFile))
    {
        logStream.WriteLine($"File Completed Transfer: {args.SourceResource.Path}");
    }
    return Task.CompletedTask;
};
```

### Simple Failed Event Delegation for Container Transfer Options
```C# Snippet:FailedEventDelegation
containerTransferOptions.TransferFailed += (TransferFailedEventArgs args) =>
{
    using (StreamWriter logStream = File.AppendText(logFile))
    {
        // Specifying specific resources that failed, since its a directory transfer
        // maybe only one file failed out of many
        logStream.WriteLine($"Exception occured with TransferId: {args.TransferId}," +
            $"Source Resource: {args.SourceResource.Path}, +" +
            $"Destination Resource: {args.DestinationResource.Path}," +
            $"Exception Message: {args.Exception.Message}");
    }
    return Task.CompletedTask;
};
```

## Troubleshooting

All Azure Storage services will throw a [RequestFailedException][RequestFailedException]
with helpful [`ErrorCode`s][error_codes].

## Next steps

Get started with our [Blob DataMovement samples][samples].

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
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs/samples
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
