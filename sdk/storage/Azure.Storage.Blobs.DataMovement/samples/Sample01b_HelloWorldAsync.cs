// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Sas;
using NUnit.Framework;

using Azure.Core;
using Azure.Identity;
using System.Linq;
using System.Threading;
using Microsoft;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement.Samples
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
                BlockBlobClient destinationBlob = container.GetBlockBlobClient(Randomize("sample-blob"));
                BlockBlobClient destinationBlob2 = container.GetBlockBlobClient(Randomize("sample-blob"));

                // Upload file data
                DataControllerOptions options = new DataControllerOptions();
                BlobDataController dataController = new BlobDataController(default);

                // Create simple transfer single blob upload job
                StorageResource sourceResource = LocalStorageResourceFactory.GetFile(originalPath);
                StorageResource destinationResource = BlobStorageResourceFactory.GetBlockBlob(destinationBlob);
                DataTransfer jobId = await dataController.StartTransferAsync(sourceResource, destinationResource).ConfigureAwait(false);

                // Add another transfer job.
                StorageResource destinationResource2 = BlobStorageResourceFactory.GetBlockBlob(destinationBlob2);

                Progress<long> blob2Progress = new Progress<long>();
                await dataController.StartTransferAsync(
                    sourceResource,
                    destinationResource2).ConfigureAwait(false);
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

            // Create a client that can authenticate with a connection string
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));

            await container.CreateIfNotExistsAsync();

            // Make a service request to verify we've successfully authenticated
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

                // Create Blob Data Controller with concurrency limited to 4
                DataControllerOptions options = new DataControllerOptions()
                {
                    MaximumConcurrency = 4
                };
                BlobDataController dataController = new BlobDataController(options);

                // Simple Download Single Blob Job
                StorageResource sourceResource = BlobStorageResourceFactory.GetBlockBlob(sourceBlob);
                StorageResource destinationResource = LocalStorageResourceFactory.GetFile(downloadPath);
                await dataController.StartTransferAsync(sourceResource, destinationResource).ConfigureAwait(false);

                StorageResource sourceResource2 = BlobStorageResourceFactory.GetBlockBlob(sourceBlob);
                StorageResource destinationResource2 = LocalStorageResourceFactory.GetFile(downloadPath2);

                await dataController.StartTransferAsync(
                    sourceResource2,
                    destinationResource2).ConfigureAwait(false);
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
                // Get a reference to a destination blobs
                StorageResourceContainer directoryDestination = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, Randomize("sample-blob-directory"));
                StorageResourceContainer directoryDestination2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, Randomize("sample-blob-directory"));

                // Create BlobDataController with event handler in Options bag
                DataControllerOptions options = new DataControllerOptions();
                ContainerTransferOptions uploadOptions = new ContainerTransferOptions();
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                uploadOptions.TransferFailedEventHandler += async (TransferFailedEventArgs args) =>
                {
                    //await LogFailedFileAsync(args.SourcePath, args.DestinationBlobClient.Uri, args.Exception.Message);
                };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
                BlobDataController transferManager = new BlobDataController(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                DataTransfer uploadDirectoryJobId = await transferManager.StartTransferAsync(
                    LocalStorageResourceFactory.GetDirectory(sourcePath),
                    directoryDestination).ConfigureAwait(false);

                // Create simple transfer directory upload job which the contents of that directory
                DataTransfer uploadDirectoryJobId2 = await transferManager.StartTransferAsync(
                    LocalStorageResourceFactory.GetDirectory(sourcePath2),
                    directoryDestination,
                    uploadOptions).ConfigureAwait(false);

                // Create transfer directory upload job where we specify a progress handler and concurrency
                DataTransfer uploadDirectoryJobId3 = await transferManager.StartTransferAsync(
                    LocalStorageResourceFactory.GetDirectory(sourcePath2),
                    directoryDestination2,
                    uploadOptions).ConfigureAwait(false);
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
                StorageResourceContainer sourceDirectory = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, Randomize("sample-blob-directory"));
                StorageResourceContainer sourceDirectory2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, Randomize("sample-blob-directory"));
                StorageResourceContainer destinationDirectory = LocalStorageResourceFactory.GetDirectory(downloadPath);
                StorageResourceContainer destinationDirectory2 = LocalStorageResourceFactory.GetDirectory(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("third", File.OpenRead(CreateTempFile()));

                // Create BlobDataController with event handler in Options bag
                DataControllerOptions options = new DataControllerOptions();
                ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
                downloadOptions.TransferFailedEventHandler += async (TransferFailedEventArgs args) =>
                {
                    if (args.Exception.Message == "500")
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
                BlobDataController transferManager = new BlobDataController(options);

                // Simple Download Directory Job where we upload the directory and it's contents
                await transferManager.StartTransferAsync(
                    sourceDirectory, destinationDirectory).ConfigureAwait(false);

                // Create different download transfer
                DataTransfer downloadDirectoryJobId2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2).ConfigureAwait(false);
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
                StorageResource sourceResource = BlobStorageResourceFactory.GetBlockBlob(sourceBlob);

                BlockBlobClient destinationBlob = container.GetBlockBlobClient(Randomize("sample-blob2"));
                StorageResource destinationResource = BlobStorageResourceFactory.GetBlockBlob(sourceBlob);

                // Upload file data
                BlobDataController transferManager = new BlobDataController(default);

                // Create simple transfer single blob upload job
                DataTransfer job = await transferManager.StartTransferAsync(sourceResource, destinationResource).ConfigureAwait(false);
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
                StorageResourceContainer sourceDirectory1 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName2);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = LocalStorageResourceFactory.GetDirectory(downloadPath);
                StorageResourceContainer destinationDirectory2 = LocalStorageResourceFactory.GetDirectory(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));

                // Create Blob Transfer Manager
                BlobDataController dataController = new BlobDataController(default);
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                ContainerTransferOptions options = new ContainerTransferOptions();
                options.TransferFailedEventHandler += async (TransferFailedEventArgs args) =>
                {
                    //await LogFailedFileAsync(args.SourceFileUri, args.DestinationFileClient.Uri, args.Exception.Message);
                };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

                await dataController.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1).ConfigureAwait(false);
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
                StorageResourceContainer sourceDirectory1 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName2);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = LocalStorageResourceFactory.GetDirectory(downloadPath);
                StorageResourceContainer destinationDirectory2 = LocalStorageResourceFactory.GetDirectory(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                DataControllerOptions options = new DataControllerOptions()
                {
                    MaximumConcurrency = 4
                };

                // Create Blob Transfer Manager
                BlobDataController transferManager = new BlobDataController(default);

                CancellationTokenSource cts = new CancellationTokenSource();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
                downloadOptions.TransferFailedEventHandler += async (TransferFailedEventArgs args) =>
                {
                    if (args.Exception.Message == "Permissions Denied")
                    {
                        Console.WriteLine("Permissions denied, some users may either choose to do two things");
                        // Option 1: Cancel the entire job, resolve error and then resume job later by adding each directory manually
                        cts.Cancel();
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            await transferManager.TryPauseAllTransfersAsync();
                        }
                    }
                    // Remove stub
                    await Task.CompletedTask;
                };
                DataTransfer jobProperties = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2).ConfigureAwait(false);
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
                StorageResourceContainer sourceDirectory1 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName2);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = LocalStorageResourceFactory.GetDirectory(downloadPath);
                StorageResourceContainer destinationDirectory2 = LocalStorageResourceFactory.GetDirectory(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync($"{sourceDirectoryName}/fourth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/fifth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName}/sixth", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/seventh", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/eight", File.OpenRead(originalPath));
                await container.UploadBlobAsync($"{sourceDirectoryName2}/ninth", File.OpenRead(originalPath));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                DataControllerOptions options = new DataControllerOptions()
                {
                    MaximumConcurrency = 4
                };

                // Create Blob Transfer Manager
                BlobDataController transferManager = new BlobDataController(options);

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
                    downloadOptions).ConfigureAwait(false);
                DataTransfer jobProps2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2,
                    downloadOptions2).ConfigureAwait(false);

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
                StorageResourceContainer sourceDirectory1 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName2);
                StorageResourceContainer sourceDirectory3 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName3);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = LocalStorageResourceFactory.GetDirectory(downloadPath);
                StorageResourceContainer destinationDirectory2 = LocalStorageResourceFactory.GetDirectory(downloadPath2);
                StorageResourceContainer destinationDirectory3 = LocalStorageResourceFactory.GetDirectory(downloadPath2);

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
                DataControllerOptions options = new DataControllerOptions()
                {
                    MaximumConcurrency = 4,
                };

                // Create Blob Transfer Manager
                BlobDataController transferManager = new BlobDataController(options);

                CancellationTokenSource cts = new CancellationTokenSource();

                List<string> failedDirectories = new List<string>();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
                DataTransfer dataTransfer1 = await transferManager.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1,
                    downloadOptions).ConfigureAwait(false);
                DataTransfer jobProperties2 = await transferManager.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2,
                    downloadOptions).ConfigureAwait(false);
                DataTransfer jobProperties3 = await transferManager.StartTransferAsync(
                    sourceDirectory3,
                    destinationDirectory3,
                    downloadOptions).ConfigureAwait(false);

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                await transferManager.TryPauseTransferAsync(jobProperties2.Id);

                ContainerTransferOptions resumeOptions = new ContainerTransferOptions()
                {
                    CheckpointTransferId = jobProperties2.Id,
                };

                //  When they decide to allow the transferManager to resume
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
        public async Task PauseAndResumeFailedJobs()
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
                StorageResourceContainer sourceDirectory1 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName);
                StorageResourceContainer sourceDirectory2 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName2);
                StorageResourceContainer sourceDirectory3 = BlobStorageResourceFactory.GetBlobVirtualDirectory(container, sourceDirectoryName3);

                // Create destination paths
                StorageResourceContainer destinationDirectory1 = LocalStorageResourceFactory.GetDirectory(downloadPath);
                StorageResourceContainer destinationDirectory2 = LocalStorageResourceFactory.GetDirectory(downloadPath2);
                StorageResourceContainer destinationDirectory3 = LocalStorageResourceFactory.GetDirectory(downloadPath2);

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
                DataControllerOptions options = new DataControllerOptions()
                {
                    MaximumConcurrency = 4,
                };

                // Create Blob Transfer Manager
                BlobDataController dataController = new BlobDataController(options);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                ContainerTransferOptions downloadOptions = new ContainerTransferOptions();
                DataTransfer dataTranferInfo = await dataController.StartTransferAsync(
                    sourceDirectory1,
                    destinationDirectory1).ConfigureAwait(false);
                DataTransfer dataTransferInfo2 = await dataController.StartTransferAsync(
                    sourceDirectory2,
                    destinationDirectory2).ConfigureAwait(false);
                DataTransfer dataTransferInfo3 = await dataController.StartTransferAsync(
                    sourceDirectory3,
                    destinationDirectory3).ConfigureAwait(false);

                // wait for all jobs to finish

                // Option 1: CX uses event handler or progress handler to keep track which job has failures
                //await transferManager.
                // See the CheckDirectoryCompletionProgress

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                if (await dataController.TryPauseAllTransfersAsync().ConfigureAwait(false))
                {
                    //  When they decide to allow the transferManager to resume
                    ContainerTransferOptions resumeOptions = new ContainerTransferOptions()
                    {
                        // Specify job id to resume from.
                        CheckpointTransferId = dataTransferInfo2.Id
                    };
                    // We need to reprovide the crendentials / resources
                    await dataController.StartTransferAsync(
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
    }
}
