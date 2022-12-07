# Azure Storage Common client library for .NET

> Server Version: 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2020-02-02

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant. Azure Storage
includes Azure Blobs (objects), Azure Data Lake Storage Gen2, Azure Files,
and Azure Queues.

The Azure.Storage.DataMovement.Blobs library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.Common` client library will be included:

```dotnetcli
dotnet add package Azure.Storage.Blobs
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
In order to interact with the Data Movement library you have to create an instance with the TransferManager class.

```C# Snippet:UploadSingle_ConnectionStringAsync
// Get a connection string to our Azure Storage account.  You can
// obtain your connection string from the Azure Portal (click
// Access Keys under Settings in the Portal Storage account blade)
// or using the Azure CLI with:
//
//     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
//
// And you can provide the connection string to your application
// using an environment variable.

string connectionString = ConnectionString;
string containerName = Randomize("sample-container");

// Create a client that can authenticate with a connection string
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
await container.CreateIfNotExistsAsync();
try
{
    // Get a reference to a source local file
    StorageResource sourceResource = new LocalFileStorageResource(sourceLocalPath);

    // Get a reference to a destination blobs
    BlockBlobClient destinationBlob = container.GetBlockBlobClient(Randomize("sample-blob"));
    StorageResource destinationResource = new BlockBlobStorageResource(destinationBlob);

    // Upload file data
    TransferManager transferManager = new TransferManager(new TransferManagerOptions());

    // Create simple transfer single blob upload job
    DataTransfer dataTransfer = await transferManager.StartTransferAsync(
        sourceResource: new LocalFileStorageResource(sourceLocalPath),
        destinationResource: new BlockBlobStorageResource(destinationBlob));
    await dataTransfer.AwaitCompletion();
}
```

```C# Snippet:DownloadSingle_SharedKeyAuthAsync
// Get a Storage account name, shared key, and endpoint Uri.
//
// You can obtain both from the Azure Portal by clicking Access
// Keys under Settings in the Portal Storage account blade.
//
// You can also get access to your account keys from the Azure CLI
// with:
//
//     az storage account keys list --account-name <account_name> --resource-group <resource_group>
//
string accountName = StorageAccountName;
string accountKey = StorageAccountKey;
Uri serviceUri = StorageAccountBlobUri;

// Create a SharedKeyCredential that we can use to authenticate
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

// Create a client that can authenticate with a SharedKeyCredential
BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
await container.CreateIfNotExistsAsync();

try
{
    // Get a reference to a source blobs and upload sample content to download
    BlockBlobClient sourceBlob = container.GetBlockBlobClient(Randomize("sample-blob"));
    BlockBlobClient sourceBlob2 = container.GetBlockBlobClient(Randomize("sample-blob"));

    using (FileStream stream = File.Open(originalPath, FileMode.Open))
    {
        await sourceBlob.UploadAsync(stream);
        stream.Position = 0;
        await sourceBlob2.UploadAsync(stream);
    }

    // Create Blob Data Controller to skip through all failures
    TransferManagerOptions options = new TransferManagerOptions()
    {
        ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
    };
    TransferManager transferManager = new TransferManager(options);

    // Simple Download Single Blob Job
    StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
    StorageResource destinationResource = new LocalFileStorageResource(downloadPath);
    await transferManager.StartTransferAsync(
        sourceResource,
        destinationResource);

    StorageResource sourceResource2 = new BlockBlobStorageResource(sourceBlob);
    StorageResource destinationResource2 = new LocalFileStorageResource(downloadPath2);

    await transferManager.StartTransferAsync(
        sourceResource: new BlockBlobStorageResource(sourceBlob, new BlockBlobStorageResourceOptions()
            {
                DownloadOptions = new BlobStorageResourceDownloadOptions()
                {
                    Conditions = new BlobRequestConditions(){ LeaseId = "xyz" }
                }
            }),
        destinationResource: new LocalFileStorageResource(downloadPath2));
}
```

```C# Snippet:UploadDirectory_SasAsync
// Create a service level SAS that only allows reading from service
// level APIs
AccountSasBuilder sas = new AccountSasBuilder
{
    // Allow access to blobs
    Services = AccountSasServices.Blobs,

    // Allow access to the container level APIs
    ResourceTypes = AccountSasResourceTypes.Container,

    // Access expires in 1 hour!
    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
};
// Allow read, write, and delete access
AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write | AccountSasPermissions.Delete;
sas.SetPermissions(permissions);

// Create a SharedKeyCredential that we can use to sign the SAS token
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

// Build a SAS URI
UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

// Create a client that can authenticate with the SAS URI
BlobServiceClient service = new BlobServiceClient(sasUri.Uri);

string connectionString = ConnectionString;
string containerName = Randomize("sample-container");

// Create a client that can authenticate with a connection string
BlobContainerClient container = service.GetBlobContainerClient(containerName);

// Make a service request to verify we've successfully authenticated
await container.CreateIfNotExistsAsync();

// Prepare for upload
try
{
    // Get a storage resource reference to a local directory
    StorageResourceContainer localDirectory = new LocalDirectoryStorageResourceContainer(sourcePath);
    // Get a storage resource to a destination blob directory
    StorageResourceContainer directoryDestination = new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory"));

    // Create BlobTransferManager with event handler in Options bag
    TransferManagerOptions transferManagerOptions = new TransferManagerOptions();
    ContainerTransferOptions options = new ContainerTransferOptions()
    {
        MaximumTransferChunkSize = 4 * Constants.MB,
        CreateMode = StorageResourceCreateMode.Overwrite,
    };
    TransferManager transferManager = new TransferManager(transferManagerOptions);

    // Create simple transfer directory upload job which uploads the directory and the contents of that directory
    DataTransfer dataTransfer = await transferManager.StartTransferAsync(
        sourceResource: new LocalDirectoryStorageResourceContainer(sourcePath),
        destinationResource: new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory")),
        transferOptions: options);
}
```

```C# Snippet:UploadDirectory_CompletedEventHandler
// Create a service level SAS that only allows reading from service
// level APIs
AccountSasBuilder sas = new AccountSasBuilder
{
    // Allow access to blobs
    Services = AccountSasServices.Blobs,

    // Allow access to the container level APIs
    ResourceTypes = AccountSasResourceTypes.Container,

    // Access expires in 1 hour!
    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
};
// Allow read, write, and delete access
AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write | AccountSasPermissions.Delete;
sas.SetPermissions(permissions);

// Create a SharedKeyCredential that we can use to sign the SAS token
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

// Build a SAS URI
UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

// Create a client that can authenticate with the SAS URI
BlobServiceClient service = new BlobServiceClient(sasUri.Uri);

string connectionString = ConnectionString;
string containerName = Randomize("sample-container");

// Create a client that can authenticate with a connection string
BlobContainerClient container = service.GetBlobContainerClient(containerName);

// Make a service request to verify we've successfully authenticated
await container.CreateIfNotExistsAsync();

// Prepare for upload
try
{
    // Create BlobTransferManager with event handler in Options bag
    TransferManagerOptions options = new TransferManagerOptions();
    ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
    containerTransferOptions.SingleTransferCompleted += (SingleTransferCompletedEventArgs args) =>
    {
        // Customers like logging their own exceptions in their production environments.
        using (StreamWriter logStream = File.AppendText(logFile))
        {
            logStream.WriteLine($"File Completed Transfer: {args.SourceResource.Path}");
        }
        return Task.CompletedTask;
    };
    TransferManager transferManager = new TransferManager(options);

    // Create simple transfer directory upload job which uploads the directory and the contents of that directory
    DataTransfer uploadDirectoryJobId = await transferManager.StartTransferAsync(
        new LocalDirectoryStorageResourceContainer(sourcePath),
        new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory")));
}
```

```C# Snippet:UploadDirectory_EventHandler_SasAsync
// Create a service level SAS that only allows reading from service
// level APIs
AccountSasBuilder sas = new AccountSasBuilder
{
    // Allow access to blobs
    Services = AccountSasServices.Blobs,

    // Allow access to the container level APIs
    ResourceTypes = AccountSasResourceTypes.Container,

    // Access expires in 1 hour!
    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
};
// Allow read, write, and delete access
AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write | AccountSasPermissions.Delete;
sas.SetPermissions(permissions);

// Create a SharedKeyCredential that we can use to sign the SAS token
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

// Build a SAS URI
UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

// Create a client that can authenticate with the SAS URI
BlobServiceClient service = new BlobServiceClient(sasUri.Uri);

string connectionString = ConnectionString;
string containerName = Randomize("sample-container");

// Create a client that can authenticate with a connection string
BlobContainerClient container = service.GetBlobContainerClient(containerName);

// Make a service request to verify we've successfully authenticated
await container.CreateIfNotExistsAsync();

// Prepare for upload
try
{
    // Create BlobTransferManager with event handler in Options bag
    TransferManagerOptions options = new TransferManagerOptions();
    ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
    containerTransferOptions.TransferStatus += (TransferStatusEventArgs args) =>
    {
        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
        {
            // Customers like logging their own exceptions in their production environments.
            using (StreamWriter logStream = File.AppendText(logFile))
            {
                logStream.WriteLine($"Our transfer has completed!");
            }
        }
        return Task.CompletedTask;
    };
    containerTransferOptions.TransferFailed += (TransferFailedEventArgs args) =>
    {
        // Customers like logging their own exceptions in their production environments.
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
    TransferManager transferManager = new TransferManager(options);

    // Create simple transfer directory upload job which uploads the directory and the contents of that directory
    DataTransfer uploadDirectoryJobId = await transferManager.StartTransferAsync(
        new LocalDirectoryStorageResourceContainer(sourcePath),
        new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory")));
}
```

```C# Snippet:DownloadDirectory_EventHandler_ActiveDirectoryAuthAsync
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
string containerName = Randomize("sample-container");

// Create a client that can authenticate with a connection string
BlobContainerClient container = service.GetBlobContainerClient(containerName);

// Make a service request to verify we've successfully authenticated
await container.CreateIfNotExistsAsync();

// Prepare to download
try
{
    // Get a reference to a source blobs and upload sample content to download
    StorageResourceContainer sourceDirectory = new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory"));
    StorageResourceContainer sourceDirectory2 = new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory"));
    StorageResourceContainer destinationDirectory = new LocalDirectoryStorageResourceContainer(downloadPath);
    StorageResourceContainer destinationDirectory2 = new LocalDirectoryStorageResourceContainer(downloadPath2);

    // Upload a couple of blobs so we have something to list
    await container.UploadBlobAsync("first", File.OpenRead(CreateTempFile()));
    await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
    await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
    await container.UploadBlobAsync("second", File.OpenRead(CreateTempFile()));
    await container.UploadBlobAsync("third", File.OpenRead(CreateTempFile()));

    // Create BlobTransferManager with event handler in Options bag
    TransferManagerOptions options = new TransferManagerOptions();
    ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
    downloadOptions.TransferFailed += async (TransferFailedEventArgs args) =>
    {
        // TODO: change the Exception if it's a RequestFailedException and then look at the exception.StatusCode
        if (args.Exception.Message.Contains("500"))
        {
            Console.WriteLine("We're getting throttled stop trying and lets try later");
        }
        else if (args.Exception.Message == "403")
        {
            Console.WriteLine("We're getting auth errors. Might be the entire container, consider stopping");
        }
        // Remove stub
        await Task.CompletedTask;
    };
    TransferManager transferManager = new TransferManager(options);

    // Simple Download Directory Job where we upload the directory and it's contents
    await transferManager.StartTransferAsync(
        sourceDirectory, destinationDirectory);

    // Create different download transfer
    DataTransfer downloadDirectoryJobId2 = await transferManager.StartTransferAsync(
        sourceDirectory2,
        destinationDirectory2);
}
```

```C# Snippet:CopySingle_ConnectionStringAsync
// Get a connection string to our Azure Storage account.  You can
// obtain your connection string from the Azure Portal (click
// Access Keys under Settings in the Portal Storage account blade)
// or using the Azure CLI with:
//
//     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
//
// And you can provide the connection string to your application
// using an environment variable.

string connectionString = ConnectionString;
string containerName = Randomize("sample-container");

// Create a client that can authenticate with a connection string
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

// Make a service request to verify we've successfully authenticated
await container.CreateIfNotExistsAsync();

// Prepare to copy
try
{
    // Get a reference to a destination blobs
    BlockBlobClient sourceBlob = container.GetBlockBlobClient(Randomize("sample-blob"));
    StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);

    BlockBlobClient destinationBlob = container.GetBlockBlobClient(Randomize("sample-blob2"));
    StorageResource destinationResource = new BlockBlobStorageResource(sourceBlob);

    // Upload file data
    TransferManager transferManager = new TransferManager(default);

    // Create simple transfer single blob upload job
    DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);
    await transfer.AwaitCompletion();

    // Generous 10 second wait for our transfer to finish
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(10000);
    await transfer.AwaitCompletion(cancellationTokenSource.Token);
}
```

```C# Snippet:CopyDirectory
            // Get a Storage account name, shared key, and endpoint Uri.
            //
            // You can obtain both from the Azure Portal by clicking Access
            // Keys under Settings in the Portal Storage account blade.
            //
            // You can also get access to your account keys from the Azure CLI
            // with:
            //
            //     az storage account keys list --account-name <account_name> --resource-group <resource_group>
            //
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a connection string
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();

            // Prepare to copy directory
            try
            {
                string sourceDirectoryName = Randomize("sample-blob-directory");
                string sourceDirectoryName2 = Randomize("sample-blob-directory");

                // Get a reference to a source blobs and upload sample content to download
                StorageResourceContainer sourceDirectory1 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName2);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = new LocalDirectoryStorageResourceContainer(downloadPath);
                StorageResourceContainer destinationDirectory2 = new LocalDirectoryStorageResourceContainer(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));

                // Create Blob Transfer Manager
                TransferManager transferManager = new TransferManager(default);
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                ContainerTransferOptions options = new ContainerTransferOptions();
                options.TransferFailed += async (TransferFailedEventArgs args) =>
                {
                    //await LogFailedFileAsync(args.SourceFileUri, args.DestinationFileClient.Uri, args.Exception.Message);
                };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

                await transferManager.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1);
            }
```

```C# Snippet:ErrorHandlingPermissions
// Get a Storage account name, shared key, and endpoint Uri.
//
// You can obtain both from the Azure Portal by clicking Access
// Keys under Settings in the Portal Storage account blade.
//
// You can also get access to your account keys from the Azure CLI
// with:
//
//     az storage account keys list --account-name <account_name> --resource-group <resource_group>
//
string accountName = StorageAccountName;
string accountKey = StorageAccountKey;
Uri serviceUri = StorageAccountBlobUri;

// Create a SharedKeyCredential that we can use to authenticate
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

// Create a client that can authenticate with a connection string
BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));

// Make a service request to verify we've successfully authenticated
await container.CreateIfNotExistsAsync();

// Prepare for download
try
{
    string sourceDirectoryName = Randomize("sample-blob-directory");
    string sourceDirectoryName2 = Randomize("sample-blob-directory");

    // Get a reference to a source blobs and upload sample content to download
    StorageResourceContainer sourceDirectory1 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName);
    StorageResourceContainer sourceDirectory2 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName2);

    // Create destination paths
    StorageResourceContainer destinationDirectory1 = new LocalDirectoryStorageResourceContainer(downloadPath);
    StorageResourceContainer destinationDirectory2 = new LocalDirectoryStorageResourceContainer(downloadPath2);

    // Upload a couple of blobs so we have something to list
    await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
    await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
    await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
    await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
    await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
    await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));

    // Set configurations up to continue to on storage failures
    // but not on local filesystem errors
    TransferManagerOptions options = new TransferManagerOptions()
    {
        MaximumConcurrency = 4
    };

    // Create Blob Transfer Manager
    TransferManager transferManager = new TransferManager(default);

    // Create transfer single blob upload job with transfer options concurrency specified
    // i.e. it's a bigger blob so it maybe need more help uploading fast
    ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
    downloadOptions.TransferFailed += async (TransferFailedEventArgs args) =>
    {
        if (args.Exception.Message == "Permissions Denied")
        {
            Console.WriteLine("Permissions denied, some users may either choose to do two things");
            // Option 1: Cancel the all transfers, resolve error and then resume job later by adding each directory manually
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                await transferManager.TryPauseAllTransfersAsync();
            }
            // Option 2: Cancel the job in question
            await transferManager.TryPauseTransferAsync(args.TransferId);
        }
        // Remove stub
        await Task.CompletedTask;
    };
    DataTransfer jobProperties = await transferManager.StartTransferAsync(
        sourceDirectory2,
        destinationDirectory2);
    jobProperties.EnsureCompleted();
}
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

## Troubleshooting

All Azure Storage services will throw a [RequestFailedException][RequestFailedException]
with helpful [`ErrorCode`s][error_codes].

## Next steps

Get started with our [Common samples][samples] and then continue on with our [Blobs][blobs_samples], [Queues][queues_samples], and [Files][files_samples] samples.

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
[auth_credentials]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/src/StorageSharedKeyCredential.cs
[blobs_examples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs/README.md#Examples
[files_examples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Files.Shares/README.md#Examples
[queues_examples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Queues/README.md#Examples
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/samples/
[blobs_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs/README.md#next-steps
[files_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Files.Shares/README.md#next-steps
[queues_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Queues/README.md#next-steps
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
