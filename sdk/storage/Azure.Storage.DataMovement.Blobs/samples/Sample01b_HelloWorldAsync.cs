// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using NUnit.Framework;
using Azure.Core;
using Azure.Identity;
using System.Threading;
using System.Runtime.InteropServices;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Samples
{
    /// <summary>
    /// Basic Azure Blob Storage samples
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Use a connection string to connect to a Storage account and upload two single blobs.
        /// </summary>
        [Test]
        public async Task UploadSingle_ConnectionStringAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourceLocalPath = CreateTempFile(SampleFileContent);

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
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared key to access a Storage Account to download two single blobs
        /// </summary>
        [Test]
        public async Task DownloadSingle_SharedKeyAuthAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();
            string downloadPath2 = CreateTempPath();

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
                        DestinationConditions = new BlobRequestConditions(){ LeaseId = "xyz" }
                    }),
                    destinationResource: new LocalFileStorageResource(downloadPath2));
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared access signature to access  a Storage Account and upload a directory.
        ///
        /// A shared access signature (SAS) is a URI that grants restricted
        /// access rights to Azure Storage resources. You can provide a shared
        /// access signature to clients who should not be trusted with your
        /// storage account key but to whom you wish to delegate access to
        /// certain storage account resources. By distributing a shared access
        /// signature URI to these clients, you can grant them access to a
        /// resource for a specified period of time, with a specified set of
        /// permissions.
        /// </summary>
        [Test]
        public async Task UploadDirectory_SasAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourcePath = CreateSampleDirectoryTree();
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourcePath2 = CreateSampleDirectoryTree();

            // Create a service level SAS that only allows reading from service
            // level APIs
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

            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
            try
            {
                // Get a storage resource reference to a local directory
                StorageResourceContainer localDirectory = new LocalDirectoryStorageResourceContainer(sourcePath);
                // Get a storage resource to a destination blob directory
                StorageResourceContainer directoryDestination = new BlobDirectoryStorageResourceContainer(container, Randomize("sample-blob-directory"));

                // Create BlobtransferManager with event handler in Options bag
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared access signature to access  a Storage Account and upload a directory.
        ///
        /// A shared access signature (SAS) is a URI that grants restricted
        /// access rights to Azure Storage resources. You can provide a shared
        /// access signature to clients who should not be trusted with your
        /// storage account key but to whom you wish to delegate access to
        /// certain storage account resources. By distributing a shared access
        /// signature URI to these clients, you can grant them access to a
        /// resource for a specified period of time, with a specified set of
        /// permissions.
        /// </summary>
        [Test]
        public async Task UploadDirectory_CompletedEventHandler()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourcePath = CreateSampleDirectoryTree();
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourcePath2 = CreateSampleDirectoryTree();

            string logFile = Path.GetTempFileName();

            // Create a service level SAS that only allows reading from service
            // level APIs
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

            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
            try
            {
                // Create BlobtransferManager with event handler in Options bag
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared access signature to access  a Storage Account and upload a directory.
        ///
        /// A shared access signature (SAS) is a URI that grants restricted
        /// access rights to Azure Storage resources. You can provide a shared
        /// access signature to clients who should not be trusted with your
        /// storage account key but to whom you wish to delegate access to
        /// certain storage account resources. By distributing a shared access
        /// signature URI to these clients, you can grant them access to a
        /// resource for a specified period of time, with a specified set of
        /// permissions.
        /// </summary>
        [Test]
        public async Task UploadDirectory_EventHandler_SasAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourcePath = CreateSampleDirectoryTree();
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourcePath2 = CreateSampleDirectoryTree();

            string logFile = Path.GetTempFileName();

            // Create a service level SAS that only allows reading from service
            // level APIs
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

            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
            try
            {
                // Create BlobtransferManager with event handler in Options bag
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use an Active Directory token to access a Storage account to download a directory
        ///
        /// Azure Storage provides integration with Azure Active Directory
        /// (Azure AD) for identity-based authentication of requests to the
        /// Blob and Queue services. With Azure AD, you can use role-based
        /// access control (RBAC) to grant access to your Azure Storage
        /// resources to users, groups, or applications. You can grant
        /// permissions that are scoped to the level of an individual
        /// container or queue.
        ///
        /// To learn more about Azure AD integration in Azure Storage, see
        /// https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad
        /// </summary>
        [Test]
        public async Task DownloadDirectory_EventHandler_ActiveDirectoryAuthAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can download our contents to
            string downloadPath = CreateSampleDirectoryTree();
            string downloadPath2 = CreateSampleDirectoryTree();

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
            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
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

                // Create BlobtransferManager with event handler in Options bag
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a connection string to connect to a Storage account and upload two single blobs.
        /// </summary>
        [Test]
        public async Task CopySingle_ConnectionStringAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

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

            // Make a service request to verify we've successfully authenticated
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

                // Generous 10 second wait for our transfer to finish
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(10000);
                await transfer.AwaitCompletion(cancellationTokenSource.Token);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared key to access a Storage Account to download two single blobs
        /// </summary>
        [Test]
        public async Task CopyDirectory()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();
            string downloadPath2 = CreateTempPath();

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

            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// To get back file or directory handle and remove read only attributes on the folder
        /// then resume the directory transfer
        /// </summary>
        [Test]
        public async Task ErrorHandlingPermissions()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempDirectoryPath();
            string downloadPath2 = CreateTempDirectoryPath();

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

            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task PauseAndResumeAllJobs()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempDirectoryPath();
            string downloadPath2 = CreateTempDirectoryPath();

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

            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
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
                TransferManager transferManager = new TransferManager(options);

                CancellationTokenSource cts = new CancellationTokenSource();

                List<string> failedDirectories = new List<string>();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
                ContainerTransferOptions downloadOptions1 = new ContainerTransferOptions();
                ContainerTransferOptions downloadOptions2 = new ContainerTransferOptions();
                DataTransfer jobProps = await transferManager.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1,
                    downloadOptions);
                DataTransfer jobProps2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2,
                    downloadOptions2);

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                await transferManager.TryPauseAllTransfersAsync();

                //  When they decide to allow the transferManager to resume
                //await transferManager.ResumeAllTransferJobsAsync();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task PauseAndResumeOneJob()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);
            string checkpointerFolderPath = CreateTempDirectoryPath();

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempDirectoryPath();
            string downloadPath2 = CreateTempDirectoryPath();

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

            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
            try
            {
                string sourceDirectoryName = Randomize("sample-blob-directory");
                string sourceDirectoryName2 = Randomize("sample-blob-directory");
                string sourceDirectoryName3 = Randomize("sample-blob-directory");

                // Get a reference to a source blobs and upload sample content to download
                StorageResourceContainer sourceDirectory1 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName2);
                StorageResourceContainer sourceDirectory3 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName3);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = new LocalDirectoryStorageResourceContainer(downloadPath);
                StorageResourceContainer destinationDirectory2 = new LocalDirectoryStorageResourceContainer(downloadPath2);
                StorageResourceContainer destinationDirectory3 = new LocalDirectoryStorageResourceContainer(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName3}/tenth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName3}/eleventh", File.OpenRead(originalPath));

                // Set configurations to take in checkpointing information
                TransferManagerOptions options = new TransferManagerOptions()
                {
                    Checkpointer = new LocalTransferCheckpointer(checkpointerFolderPath)
                };

                // Create Blob Transfer Manager
                TransferManager transferManager = new TransferManager(options);

                // Create transfers
                DataTransfer transferInfo1 = await transferManager.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1);
                DataTransfer transferInfo2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2);
                DataTransfer transferInfo3 = await transferManager.StartTransferAsync(
                    sourceDirectory3,
                    destinationDirectory3);

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                await transferManager.TryPauseTransferAsync(transferInfo2.Id);

                // Create resume options
                ContainerTransferOptions resumeOptions = new ContainerTransferOptions()
                {
                    ResumeFromCheckpointId = transferInfo2.Id,
                };

                //  When they decide to allow the transferManager to resume
                // Resume the transfer by re-providing the storage resources (with the credentials)
                // (or updated credentials) and the options bag with the resume options.
                await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2,
                    resumeOptions);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task PauseAllJobsResumeOneJob()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempDirectoryPath();
            string downloadPath2 = CreateTempDirectoryPath();
            string downloadPath3 = CreateTempDirectoryPath();

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

            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
            try
            {
                string sourceDirectoryName = Randomize("sample-blob-directory");
                string sourceDirectoryName2 = Randomize("sample-blob-directory");
                string sourceDirectoryName3 = Randomize("sample-blob-directory");

                // Get a reference to a source blobs and upload sample content to download
                StorageResourceContainer sourceDirectory1 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName2);
                StorageResourceContainer sourceDirectory3 = new BlobDirectoryStorageResourceContainer(container, sourceDirectoryName3);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = new LocalDirectoryStorageResourceContainer(downloadPath);
                StorageResourceContainer destinationDirectory2 = new LocalDirectoryStorageResourceContainer(downloadPath2);
                StorageResourceContainer destinationDirectory3 = new LocalDirectoryStorageResourceContainer(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName3}/tenth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName3}/eleventh", File.OpenRead(originalPath));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                TransferManagerOptions options = new TransferManagerOptions()
                {
                    MaximumConcurrency = 4,
                };

                // Create Blob Transfer Manager
                TransferManager transferManager = new TransferManager(options);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
                DataTransfer dataTranferInfo = await transferManager.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1);
                DataTransfer dataTransferInfo2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2);
                DataTransfer dataTransferInfo3 = await transferManager.StartTransferAsync(
                    sourceDirectory3,
                    destinationDirectory3);

                // wait for all jobs to finish

                // Option 1: CX uses event handler or progress handler to keep track which job has failures
                //await transferManager.
                // See the CheckDirectoryCompletionProgress

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                if (await transferManager.TryPauseAllTransfersAsync().ConfigureAwait(false))
                {
                    //  When they decide to allow the transferManager to resume
                    ContainerTransferOptions resumeOptions = new ContainerTransferOptions()
                    {
                        // Specify job id to resume from.
                        ResumeFromCheckpointId = dataTransferInfo2.Id
                    };
                    // We need to reprovide the crendentials / resources
                    await transferManager.StartTransferAsync(
                        sourceDirectory2,
                        destinationDirectory2,
                        resumeOptions);
                }
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        public struct StoredCredentials
        {
            public StorageResourceContainer SourceContainer { get; set; }
            public StorageResourceContainer DestinationContainer { get; set; }

            public StoredCredentials(
                StorageResourceContainer sourceContainer,
                StorageResourceContainer destinationContainer)
            {
                SourceContainer = sourceContainer;
                DestinationContainer = destinationContainer;
            }
        }

        [Test]
        public async Task ResumeFromStoppedJobs()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempDirectoryPath();
            string downloadPath2 = CreateTempDirectoryPath();
            string checkpointerPath = CreateTempDirectoryPath();

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
            BlobContainerClient container1 = service.GetBlobContainerClient(Randomize("sample-container"));
            BlobContainerClient container2 = service.GetBlobContainerClient(Randomize("sample-container1"));
            BlobContainerClient container3 = service.GetBlobContainerClient(Randomize("sample-container2"));

            await container1.CreateIfNotExistsAsync();
            await container2.CreateIfNotExistsAsync();
            await container3.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
            try
            {
                string sourceDirectoryName = Randomize("sample-blob-directory");
                string sourceDirectoryName2 = Randomize("sample-blob-directory");
                string sourceDirectoryName3 = Randomize("sample-blob-directory");

                // Set configurations to grab the checkpointer from the designated place
                // in the environment where the checkpointer is stored.
                LocalTransferCheckpointer checkpointer = new LocalTransferCheckpointer(checkpointerPath);
                TransferManagerOptions options = new TransferManagerOptions()
                {
                    Checkpointer = checkpointer
                };

                // Create Blob Transfer Manager
                TransferManager transferManager = new TransferManager(options);

                // Get a reference to a source blobs and upload sample content to download
                StorageResourceContainer sourceDirectory1 = new BlobDirectoryStorageResourceContainer(container1, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = new BlobDirectoryStorageResourceContainer(container2, sourceDirectoryName2);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = new LocalDirectoryStorageResourceContainer(downloadPath);
                StorageResourceContainer destinationDirectory2 = new LocalDirectoryStorageResourceContainer(downloadPath2);

                Dictionary<string, StoredCredentials> storedCredentials = new Dictionary<string, StoredCredentials>();
                DataTransfer dataTransferInfo = await transferManager.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1);
                DataTransfer dataTransferInfo2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2);

                storedCredentials.Add(dataTransferInfo.Id, new StoredCredentials(sourceDirectory1, destinationDirectory1));
                storedCredentials.Add(dataTransferInfo2.Id, new StoredCredentials(sourceDirectory2, destinationDirectory2));

                //-----------------Someone trips over the plug!---------------------------

                // Set configurations to grab the checkpointer from the designated place
                // in the environment where the checkpointer is stored.
                LocalTransferCheckpointer localCheckpointer = new LocalTransferCheckpointer(checkpointerPath);
                TransferManagerOptions options2 = new TransferManagerOptions()
                {
                    Checkpointer = localCheckpointer
                };
                List<string> savedTransfers = await checkpointer.GetStoredTransfersAsync();

                // Create Blob Transfer Manager
                TransferManager transferManagerResume = new TransferManager(options2);

                for (int i = 0; i < savedTransfers.Count; i++)
                {
                    // If we have the credentials saved
                    if (storedCredentials.TryGetValue(savedTransfers[i], out StoredCredentials credentials))
                    {
                        ContainerTransferOptions resumeOptions = new ContainerTransferOptions()
                        {
                            // Specify job id to resume from.
                            ResumeFromCheckpointId = savedTransfers[i]
                        };
                        // We need to reprovide the crendentials / resources because we do not
                        // store the credentials for the customers. Customers should manage
                        // their storage credentials)
                        await transferManagerResume.StartTransferAsync(
                            credentials.SourceContainer,
                            credentials.DestinationContainer,
                            resumeOptions);
                    }
                }
            }
            finally
            {
                await container1.DeleteIfExistsAsync();
                await container2.DeleteIfExistsAsync();
            }
        }
    }
}
