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
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.Storage.DataMovement.Blobs.Samples
{
    /// <summary>
    /// Basic Azure Blob Storage samples.
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        public Random _rand = new Random();

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
                BlockBlobClient destinationBlob = container.GetBlockBlobClient("sample-blob");
                StorageResource destinationResource = new BlockBlobStorageResource(destinationBlob);

                // Upload file data
                #region Snippet:CreateTransferManagerSimple
                TransferManager transferManager = new TransferManager(new TransferManagerOptions());
                #endregion

                // Create simple transfer single blob upload job
                #region Snippet:SimpleBlobUpload
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource: new LocalFileStorageResource(sourceLocalPath),
                    destinationResource: new BlockBlobStorageResource(destinationBlob));
                await dataTransfer.AwaitCompletion();
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared key to access a Storage Account to download two separate blobs.
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
            string containerName = Randomize("sample-container");

            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a SharedKeyCredential
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            try
            {
                // Get a reference to a source blobs and upload sample content to download
                BlockBlobClient sourceBlob = container.GetBlockBlobClient("sample-blob");
                BlockBlobClient sourceBlob2 = container.GetBlockBlobClient("sample-blob2");

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

                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource: new BlockBlobStorageResource(sourceBlob),
                    destinationResource: new LocalFileStorageResource(downloadPath));
                await dataTransfer.AwaitCompletion();

                StorageResource sourceResource2 = new BlockBlobStorageResource(sourceBlob);
                StorageResource destinationResource2 = new LocalFileStorageResource(downloadPath2);

                #region Snippet:BlockBlobDownloadOptions
                await transferManager.StartTransferAsync(
                    sourceResource: new BlockBlobStorageResource(sourceBlob, new BlockBlobStorageResourceOptions()
                    {
                        DestinationConditions = new BlobRequestConditions(){ LeaseId = "xyz" }
                    }),
                    destinationResource: new LocalFileStorageResource(downloadPath2));
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared access signature to access a Storage Account and upload a directory.
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
                StorageResourceContainer directoryDestination = new BlobStorageResourceContainer(
                    container,
                    new BlobStorageResourceContainerOptions() { DirectoryPrefix = "sample-directory" });

                #region Snippet:CreateTransferManagerWithOptions
                // Create BlobTransferManager with event handler in Options bag
                TransferManagerOptions transferManagerOptions = new TransferManagerOptions();
                TransferOptions options = new TransferOptions()
                {
                    MaximumTransferChunkSize = 4 * Constants.MB,
                    CreateMode = StorageResourceCreateMode.Overwrite,
                };
                TransferManager transferManager = new TransferManager(transferManagerOptions);
                #endregion

                #region Snippet:SimpleDirectoryUpload
                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource: new LocalDirectoryStorageResourceContainer(sourcePath),
                    destinationResource: new BlobStorageResourceContainer(
                        container,
                        new BlobStorageResourceContainerOptions() { DirectoryPrefix = "sample-directory2" }),
                    transferOptions: options);
                #endregion
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
                #region Snippet:SimpleLoggingSample
                // Create BlobTransferManager with event handler in Options bag
                TransferManagerOptions options = new TransferManagerOptions();
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.SingleTransferCompleted += (SingleTransferCompletedEventArgs args) =>
                {
                    using (StreamWriter logStream = File.AppendText(logFile))
                    {
                        logStream.WriteLine($"File Completed Transfer: {args.SourceResource.Path}");
                    }
                    return Task.CompletedTask;
                };
                #endregion
                TransferManager transferManager = new TransferManager(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                DataTransfer uploadDirectoryJobId = await transferManager.StartTransferAsync(
                    new LocalDirectoryStorageResourceContainer(sourcePath),
                    new BlobStorageResourceContainer(
                        container,
                        new BlobStorageResourceContainerOptions() { DirectoryPrefix = "sample-blob-directory" }));
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
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferStatus += (TransferStatusEventArgs args) =>
                {
                    if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                    {
                        using (StreamWriter logStream = File.AppendText(logFile))
                        {
                            logStream.WriteLine($"Our transfer has completed!");
                        }
                    }
                    return Task.CompletedTask;
                };
                #region Snippet:FailedEventDelegation
                transferOptions.TransferFailed += (TransferFailedEventArgs args) =>
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
                #endregion
                TransferManager transferManager = new TransferManager(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                DataTransfer uploadDirectoryJobId = await transferManager.StartTransferAsync(
                    new LocalDirectoryStorageResourceContainer(sourcePath),
                    new BlobStorageResourceContainer(
                        container,
                        new BlobStorageResourceContainerOptions() { DirectoryPrefix = "sample-blob-directory" }));
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

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();

            // Prepare to download
            try
            {
                // Get a reference to a source blobs and upload sample content to download
                StorageResourceContainer sourceDirectory = new BlobStorageResourceContainer(container,
                    new BlobStorageResourceContainerOptions() { DirectoryPrefix = "sample-blob-directory" });
                StorageResourceContainer sourceDirectory2 = new BlobStorageResourceContainer(container,
                    new BlobStorageResourceContainerOptions() { DirectoryPrefix = "sample-blob-directory2" });
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
                TransferOptions downloadOptions = new TransferOptions();
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
                #region Snippet:SimpleDirectoryDownload
                DataTransfer downloadDirectoryJobId2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2);
                #endregion
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

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();

            // Prepare to copy
            try
            {
                // Get a reference to a destination blobs
                BlockBlobClient sourceBlob = container.GetBlockBlobClient("sample-blob");
                StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);

                BlockBlobClient destinationBlob = container.GetBlockBlobClient("sample-blob2");
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
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use a shared key to access a Storage Account to download two single directories.
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
            string containerName = Randomize("sample-container");

            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a connection string
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();

            // Prepare to copy directory
            try
            {
                string sourceDirectoryName = "sample-blob-directory";
                string sourceDirectoryName2 = "sample-blob-directory2";

                // Get a reference to a source blobs and upload sample content to download
                StorageResourceContainer sourceDirectory1 = new BlobStorageResourceContainer(container,
                    new BlobStorageResourceContainerOptions() { DirectoryPrefix = sourceDirectoryName });
                StorageResourceContainer sourceDirectory2 = new BlobStorageResourceContainer(container,
                    new BlobStorageResourceContainerOptions() { DirectoryPrefix = sourceDirectoryName2 });

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
                TransferOptions options = new TransferOptions();
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
        /// Test to show pause and resume tests
        /// </summary>
        [Test]
        public async Task PauseAndResumeAsync_ManagerDataTransfer()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateIfNotExistsAsync();
            try
            {
                string downloadPath = CreateTempPath();
                // Get a temporary path on disk where we can download the file
                //@@ string downloadPath = "hello.jpg";

                // Download the public blob at https://aka.ms/bloburl
                BlockBlobClient sourceBlob = new BlockBlobClient(new Uri("https://aka.ms/bloburl"));
                await sourceBlob.DownloadToAsync(downloadPath);

                // Create transfer manager
                TransferManager transferManager = new TransferManager(new TransferManagerOptions());

                // Create source and destination resource
                StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
                StorageResource destinationResource = new LocalFileStorageResource(downloadPath);

                // Create simple transfer single blob download job
                #region Snippet:TransferManagerTryPause_Async
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);

                // Pause from the Transfer Manager using the DataTransfer object
                await transferManager.PauseTransferIfRunningAsync(dataTransfer);
                #endregion Snippet:TransferManagerTryPause_Async

                #region Snippet:TransferManagerResume_Async
                // Resume from checkpoint id
                TransferOptions optionsWithResumeTransferId = new TransferOptions()
                {
                    ResumeFromCheckpointId = dataTransfer.Id
                };

                DataTransfer resumedTransfer = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
                    transferOptions: optionsWithResumeTransferId);
                #endregion Snippet:TransferManagerResume_Async

                // Wait for download to finish
                await resumedTransfer.AwaitCompletion();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Test to show pause and resume tests
        /// </summary>
        [Test]
        public async Task PauseAndResumeAsync_ManagerId()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateIfNotExistsAsync();
            try
            {
                string downloadPath = CreateTempPath();
                // Get a temporary path on disk where we can download the file
                //@@ string downloadPath = "hello.jpg";

                // Download the public blob at https://aka.ms/bloburl
                BlockBlobClient sourceBlob = new BlockBlobClient(new Uri("https://aka.ms/bloburl"));
                await sourceBlob.DownloadToAsync(downloadPath);

                // Create transfer manager
                TransferManager transferManager = new TransferManager(new TransferManagerOptions());

                // Create source and destination resource
                StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
                StorageResource destinationResource = new LocalFileStorageResource(downloadPath);

                // Create simple transfer single blob download job
                #region Snippet:TransferManagerTryPauseId_Async
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);
                string transferId = dataTransfer.Id;

                // Pause from the Transfer Manager using the Transfer Id
                await transferManager.PauseTransferIfRunningAsync(transferId);
                #endregion Snippet:TransferManagerTryPauseId_Async

                // Resume from checkpoint id
                TransferOptions optionsWithResumeTransferId = new TransferOptions()
                {
                    ResumeFromCheckpointId = dataTransfer.Id
                };

                DataTransfer resumedTransfer = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
                    transferOptions: optionsWithResumeTransferId);

                // Wait for download to finish
                await resumedTransfer.AwaitCompletion();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Test to show pause and resume tests
        /// </summary>
        [Test]
        public async Task PauseAndResumeAsync_DataTransferPause()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateIfNotExistsAsync();
            try
            {
                string downloadPath = CreateTempPath();
                // Get a temporary path on disk where we can download the file
                //@@ string downloadPath = "hello.jpg";

                // Download the public blob at https://aka.ms/bloburl
                BlockBlobClient sourceBlob = new BlockBlobClient(new Uri("https://aka.ms/bloburl"));
                await sourceBlob.DownloadToAsync(downloadPath);

                // Create transfer manager
                TransferManager transferManager = new TransferManager(new TransferManagerOptions());

                // Create source and destination resource
                StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
                StorageResource destinationResource = new LocalFileStorageResource(downloadPath);

                // Create simple transfer single blob download job
                #region Snippet:DataTransferTryPause_Async
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);

                // Pause from the DataTransfer object
                await dataTransfer.PauseIfRunningAsync();
                #endregion Snippet:DataTransferTryPause_Async

                // Resume from checkpoint id
                TransferOptions optionsWithResumeTransferId = new TransferOptions()
                {
                    ResumeFromCheckpointId = dataTransfer.Id
                };

                DataTransfer resumedTransfer = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
                    transferOptions: optionsWithResumeTransferId);

                // Wait for download to finish
                await resumedTransfer.AwaitCompletion();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use the <see cref="BlobContainerClient.UploadDirectory"/> extention method to upload an entire directory.
        /// </summary>
        [Test]
        public async Task UploadDirectory()
        {
            string localPath = CreateSampleDirectoryTree();

            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            string containerName = Randomize("sample-container");
            string blobDirectoryPrefix = Path.GetDirectoryName(localPath);
            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            #region Snippet:ExtensionMethodCreateContainerClient
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);

            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            #endregion

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();

            try
            {
                {
                    // upload files to the root of the container
                    #region Snippet:ExtensionMethodSimpleUploadToRoot
                    DataTransfer transfer = await container.StartUploadDirectoryAsync(localPath);

                    await transfer.AwaitCompletion();
                    #endregion
                }
                {
                    // upload files with to a specific directory prefix
                    #region Snippet:ExtensionMethodSimpleUploadToDirectoryPrefix
                    DataTransfer transfer = await container.StartUploadDirectoryAsync(localPath, blobDirectoryPrefix);

                    await transfer.AwaitCompletion();
                    #endregion
                }
                {
                    #region Snippet:ExtensionMethodSimpleUploadWithOptions
                    BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
                    {
                        BlobContainerOptions = new BlobStorageResourceContainerOptions
                        {
                            DirectoryPrefix = blobDirectoryPrefix
                        },
                        TransferOptions = new TransferOptions()
                        {
                            CreateMode = StorageResourceCreateMode.Overwrite,
                        }
                    };

                    DataTransfer transfer = await container.StartUploadDirectoryAsync(localPath, options);

                    await transfer.AwaitCompletion();
                    #endregion
                }
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use the <see cref="BlobContainerClient.UploadDirectory"/> extention method to upload an entire directory.
        /// </summary>
        [Test]
        public async Task DownloadDirectory()
        {
            string localDirectoryPath = CreateTempDirectoryPath();
            string localDirectoryPath2 = CreateTempDirectoryPath();
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            string containerName = Randomize("sample-container");

            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a connection string
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);

            await container.CreateIfNotExistsAsync();

            await CreateBlobTestFiles(container, count: 5);

            string blobDirectoryPrefix = await CreateBlobContainerTestDirectory(container);

            try
            {
                {
                    // download the entire container to the local directory
                    #region Snippet:ExtensionMethodSimpleDownloadContainer
                    DataTransfer transfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath);

                    await transfer.AwaitCompletion();
                    #endregion
                }
                {
                    // download a virtual directory, with a specific prefix, within the container
                    #region Snippet:ExtensionMethodSimpleDownloadContainerDirectory
                    DataTransfer tranfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath2, blobDirectoryPrefix);

                    await tranfer.AwaitCompletion();
                    #endregion
                }
                {
                    #region Snippet:ExtensionMethodSimpleDownloadContainerDirectoryWithOptions
                    BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
                    {
                        BlobContainerOptions = new BlobStorageResourceContainerOptions
                        {
                            DirectoryPrefix = blobDirectoryPrefix
                        },
                        TransferOptions = new TransferOptions()
                        {
                            CreateMode = StorageResourceCreateMode.Overwrite,
                        }
                    };

                    DataTransfer tranfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath2, options);

                    await tranfer.AwaitCompletion();
                    #endregion
                }
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        public async Task<string> CreateBlobContainerTestDirectory(BlobContainerClient client, int depth = 0, string basePath = default)
        {
            basePath = basePath ?? Path.GetTempFileName();

            var dirPath = string.IsNullOrEmpty(basePath) ? Path.GetTempFileName() : $"{basePath}/{Path.GetTempFileName()}";

            await CreateBlobTestFiles(client, dirPath, 5);

            if (depth > 0)
            {
                await CreateBlobContainerTestDirectory(client, --depth, dirPath);
            }

            return dirPath;
        }

        public async Task CreateBlobTestFiles(BlobContainerClient client, string dirPath = default, int count = 1)
        {
            var buff = new byte[1000];

            for (int i = 0; i < count; i++)
            {
                var blobPath = string.IsNullOrEmpty(dirPath) ? $"{Path.GetTempFileName()}.txt" : $"{dirPath}/{Path.GetTempFileName()}.txt";

                _rand.NextBytes(buff);

                await client.UploadBlobAsync(blobPath, new MemoryStream(buff));
            }
        }

        public string CreateLocalTestDirectory(int depth = 0, string basePath = default)
        {
            basePath = basePath ?? Path.GetTempPath();

            var dirPath = Path.Combine(basePath, Path.GetTempFileName());

            Directory.CreateDirectory(dirPath);

            CreateLocalTestFiles(dirPath, 5);

            if (depth > 0)
            {
                CreateLocalTestDirectory(--depth, dirPath);
            }

            return dirPath;
        }

        public void CreateLocalTestFiles(string dirPath, int count = 1)
        {
            var buff = new byte[1000];

            for (int i = 0; i < count; i++)
            {
                var filePath = Path.Combine(dirPath, Path.GetTempFileName() + ".txt");

                _rand.NextBytes(buff);

                File.WriteAllText(filePath, Convert.ToBase64String(buff));
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
    }
}
