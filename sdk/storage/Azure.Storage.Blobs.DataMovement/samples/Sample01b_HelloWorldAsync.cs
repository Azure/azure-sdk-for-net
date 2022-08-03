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
                StorageTransferManagerOptions options = new StorageTransferManagerOptions();
                {
                }
                BlobTransferManager transferManager = new BlobTransferManager(default);

                // Create simple transfer single blob upload job
                BlobTransferJobProperties jobId = await transferManager.ScheduleUploadAsync(originalPath, destinationBlob);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast

                // Also I want to specify the progress handler
                Progress<long> blob2Progress = new Progress<long>();
                await transferManager.ScheduleUploadAsync(
                    originalPath,
                    destinationBlob2,
                    uploadOptions: new BlobSingleUploadOptions()
                    {
                        ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions()
                        {
                            MaximumConcurrency = 4
                        }
                    }).ConfigureAwait(false);
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
                BlobClient sourceBlob = container.GetBlobClient(Randomize("sample-blob"));
                BlobClient sourceBlob2 = container.GetBlobClient(Randomize("sample-blob"));

                await sourceBlob.UploadAsync(originalPath);
                await sourceBlob2.UploadAsync(originalPath);

                // Create Blob Transfer Manager
                BlobTransferManager transferManager = new BlobTransferManager(default);

                // Simple Download Single Blob Job
                await transferManager.ScheduleDownloadAsync(sourceBlob, downloadPath).ConfigureAwait(false);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                Progress<long> blob2Progress = new Progress<long>();
                await transferManager.ScheduleDownloadAsync(
                    sourceBlob2,
                    downloadPath2,
                    options: new BlobSingleDownloadOptions()
                    {
                        ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions
                        {
                            MaximumConcurrency = 4
                        }
                    }).ConfigureAwait(false);
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
                BlobFolderClient destinationBlob = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient destinationBlob2 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Create BlobTransferManager with event handler in Options bag
                StorageTransferManagerOptions options = new StorageTransferManagerOptions();
                BlobFolderUploadOptions uploadOptions = new BlobFolderUploadOptions()
                {
                    AccessTier = AccessTier.Cool,
                };
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                uploadOptions.UploadFailedEventHandler += async (BlobUploadFailedEventArgs args) =>
                {

                    //await LogFailedFileAsync(args.SourcePath, args.DestinationBlobClient.Uri, args.Exception.Message);
                };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
                BlobTransferManager transferManager = new BlobTransferManager(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                BlobTransferJobProperties uploadDirectoryJobId = await transferManager.ScheduleFolderUploadAsync(sourcePath, destinationBlob).ConfigureAwait(false);

                // Create simple transfer directory upload job which the contents of that directory
                BlobTransferJobProperties uploadDirectoryJobId2 = await transferManager.ScheduleFolderUploadAsync(
                    sourcePath2,
                    destinationBlob,
                    options: uploadOptions).ConfigureAwait(false);

                // Create transfer directory upload job where we specify a progress handler and concurrency
                BlobTransferJobProperties uploadDirectoryJobId3 = await transferManager.ScheduleFolderUploadAsync(
                    sourcePath,
                    destinationBlob2,
                    options: uploadOptions).ConfigureAwait(false);
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
                BlobFolderClient sourceBlobDirectory = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceBlobDirectory2 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("third", File.OpenRead(CreateTempFile()));

                // Create BlobTransferManager with event handler in Options bag
                StorageTransferManagerOptions options = new StorageTransferManagerOptions();
                BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
                downloadOptions.DownloadFailedEventHandler += async (BlobDownloadFailedEventArgs args) =>
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
                BlobTransferManager transferManager = new BlobTransferManager(options);

                // Simple Download Directory Job where we upload the directory and it's contents
                await transferManager.ScheduleFolderDownloadAsync(sourceBlobDirectory, downloadPath).ConfigureAwait(false);

                // Create simple transfer directory download job which the contents of that directory
                BlobTransferJobProperties downloadDirectoryJobId = await transferManager.ScheduleFolderDownloadAsync(
                    sourceBlobDirectory,
                    downloadPath).ConfigureAwait(false);

                // Create transfer directory upload job where we specify a progress handler and concurrency
                BlobTransferJobProperties downloadDirectoryJobId2 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceBlobDirectory2,
                    downloadPath2,
                    options: new BlobFolderDownloadOptions()
                    {
                        // This is where the progress handler would live if we provided more grandularity
                        //ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions
                        {
                            MaximumConcurrency = 4
                        }
                    }).ConfigureAwait(false);
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
                BlockBlobClient destinationBlob = container.GetBlockBlobClient(Randomize("sample-blob2"));

                // Upload file data
                BlobTransferManager transferManager = new BlobTransferManager(default);

                // Create simple transfer single blob upload job
                BlobTransferJobProperties job = await transferManager.ScheduleUploadAsync(originalPath, sourceBlob).ConfigureAwait(false);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast

                // Also I want to specify the progress handler
                Progress<long> blob2Progress = new Progress<long>();
                await transferManager.ScheduleCopyAsync(
                    sourceBlob.Uri,
                    destinationBlob,
                    copyMethod: BlobCopyMethod.Copy,
                    copyOptions: new BlobCopyFromUriOptions()
                    {
                        AccessTier = AccessTier.Hot
                    }).ConfigureAwait(false);
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
                // Get a reference to a source blobs and upload sample content to download
                BlobFolderClient sourceBlobDirectory = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient destinationBlobDirectory = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/sixth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("third", File.OpenRead(CreateTempFile()));

                // Create Blob Transfer Manager
                BlobTransferManager transferManager = new BlobTransferManager(default);
                BlobFolderCopyFromUriOptions copyOptions = new BlobFolderCopyFromUriOptions()
                {
                    AccessTier = AccessTier.Cool,
                };
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                copyOptions.CopyFailedEventHandler += async (BlobSingleCopyFailedEventArgs args) =>
                {
                    //await LogFailedFileAsync(args.SourceFileUri, args.DestinationFileClient.Uri, args.Exception.Message);
                };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

                await transferManager.ScheduleFolderCopyAsync(
                    sourceBlobDirectory,
                    destinationBlobDirectory,
                    BlobCopyMethod.SyncCopy,
                    copyOptions: copyOptions).ConfigureAwait(false);
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
                BlobFolderClient sourceDirectoryBlob = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob2 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/sixth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/sixth", File.OpenRead(CreateTempFile()));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                StorageTransferManagerOptions options = new StorageTransferManagerOptions()
                {
                    MaximumConcurrency = 4
                };

                // Create Blob Transfer Manager
                BlobTransferManager transferManager = new BlobTransferManager(default);

                CancellationTokenSource cts = new CancellationTokenSource();

                List<string> failedDirectories = new List<string>();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
                downloadOptions.DownloadFailedEventHandler+= async (BlobDownloadFailedEventArgs args) =>
                {
                    if (args.Exception.Message == "Permissions Denied")
                    {
                        Console.WriteLine("Permissions denied, some users may either choose to do two things");
                        // Option 1: Cancel the entire job, resolve error and then resume job later by adding each directory manually
                        cts.Cancel();
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            /*
                            DirectoryInfo skippedDirectory = new DirectoryInfo(args.Exception.Source);
                            DirectorySecurity rights = skippedDirectory.GetAccessControl();
                            rights.AddAccessRule(new FileSystemAccessRule("userIdentity", FileSystemRights.FullControl, AccessControlType.Allow));
                            skippedDirectory.SetAccessControl(rights);
                            failedDirectories.Add(args.Exception.Source);

                            // Option 2: Resolve the exception.
                            await transferManager.PauseTransferJobAsync(args.JobId);
                            rights.AddAccessRule(new FileSystemAccessRule("userIdentity", FileSystemRights.FullControl, AccessControlType.Allow));
                            skippedDirectory.SetAccessControl(rights);
                            await transferManager.ResumeTransferJobAsync(args.JobId, new ResumeTransferCredentials(default,default));
                            */
                        }
                    }
                    // Remove stub
                    await Task.CompletedTask;
                };
                downloadOptions.TransferOptions = new StorageTransferOptions { MaximumConcurrency = 4 };
                BlobTransferJobProperties jobProperties = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob2,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);
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
                BlobFolderClient sourceDirectoryBlob = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob2 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/sixth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/seventh", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/eight", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/ninth", File.OpenRead(CreateTempFile()));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                StorageTransferManagerOptions options = new StorageTransferManagerOptions()
                {
                    MaximumConcurrency = 4
                };

                // Create Blob Transfer Manager
                BlobTransferManager transferManager = new BlobTransferManager(options);

                CancellationTokenSource cts = new CancellationTokenSource();

                List<string> failedDirectories = new List<string>();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
                BlobFolderDownloadOptions downloadOptions1 = new BlobFolderDownloadOptions();
                BlobFolderDownloadOptions downloadOptions2 = new BlobFolderDownloadOptions();
                downloadOptions.TransferOptions = new StorageTransferOptions { MaximumConcurrency = 4 };
                BlobTransferJobProperties jobProps = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob2,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);
                BlobTransferJobProperties jobProps2 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob2,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);
                BlobTransferJobProperties jobProp3 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob2,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                await transferManager.PauseAllTransferJobsAsync();

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
                BlobFolderClient sourceDirectoryBlob = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob2 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob3 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob4 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/sixth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/seventh", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/eight", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/ninth", File.OpenRead(CreateTempFile()));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                StorageTransferManagerOptions options = new StorageTransferManagerOptions()
                {
                    MaximumConcurrency = 4,
                };

                // Create Blob Transfer Manager
                BlobTransferManager transferManager = new BlobTransferManager(options);

                CancellationTokenSource cts = new CancellationTokenSource();

                List<string> failedDirectories = new List<string>();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
                downloadOptions.TransferOptions = new StorageTransferOptions { MaximumConcurrency = 4 };
                BlobTransferJobProperties jobProperties = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);
                BlobTransferJobProperties jobProperties2 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob2,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);
                BlobTransferJobProperties jobProperties3 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob3,
                    downloadPath2,
                    options: downloadOptions).ConfigureAwait(false);

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                await transferManager.PauseTransferJobAsync(jobProperties2.TransferId);

                //  When they decide to allow the transferManager to resume
                await transferManager.ResumeTransferJobAsync(
                    jobProperties2.TransferId,
                    sourceCredentials: default,
                    destinationCredentials: default);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        public class CheckDirectoryFailureProgress : IProgress<BlobFolderDownloadProgress>
        {
            public void Report(BlobFolderDownloadProgress response)
            {
                if (response.TransferStatus == StorageTransferStatus.Completed)
                {
                    Console.WriteLine("Completed without errors!");
                    // Ideally customers would have an event arguement that would trigger here when their job finishes
                }
                else if (response.TotalDownloadsFailed > 0)
                {
                    // Ideally customers would be tracking with the event handler on why there was a failure..
                }
            }
        };

        public class CheckDirectoryCompletionProgress : IProgress<BlobFolderDownloadProgress>
        {
            public void Report(BlobFolderDownloadProgress response)
            {
                if (response.TransferStatus == StorageTransferStatus.Completed)
                {
                    Console.WriteLine("Completed!");
                    // Ideally customers would have an event argument that would trigger here when their job finishes
                    //BlobContainerClient containerClient = new BlobContainerClient(new Uri("http://accountname.blob.core.windows.net/containername"), containerName);
                    // readjust ACL to not allow any more reads after downloading
                    //await containerClient.SetAccessPolicyAsync(PublicAccessType.None);
                }
            }
        };

        [Test]
        public async Task PauseAndResumeFailedJobs()
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
                BlobFolderClient sourceDirectoryBlob = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob2 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob3 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));
                BlobFolderClient sourceDirectoryBlob4 = container.GetBlobFolderClient(Randomize("sample-blob-directory"));

                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("first/sixth", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/seventh", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/eight", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second/ninth", File.OpenRead(CreateTempFile()));

                // Set configurations up to continue to on storage failures
                // but not on local filesystem errors
                StorageTransferManagerOptions options = new StorageTransferManagerOptions()
                {
                    MaximumConcurrency = 4,
                };

                // Create Blob Transfer Manager
                BlobTransferManager transferManager = new BlobTransferManager(options);

                CancellationTokenSource cts = new CancellationTokenSource();

                List<string> failedDirectories = new List<string>();
                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();

                CheckDirectoryCompletionProgress progress1 = new CheckDirectoryCompletionProgress();
                BlobFolderDownloadOptions downloadProgressOptions1 = new BlobFolderDownloadOptions()
                {
                    ProgressHandler = progress1
                };
                CheckDirectoryCompletionProgress progress2 = new CheckDirectoryCompletionProgress();
                BlobFolderDownloadOptions downloadProgressOptions2 = new BlobFolderDownloadOptions()
                {
                    ProgressHandler = progress2
                };
                CheckDirectoryCompletionProgress progress3 = new CheckDirectoryCompletionProgress();
                BlobFolderDownloadOptions downloadProgressOptions3 = new BlobFolderDownloadOptions()
                {
                    ProgressHandler = progress3
                };
                downloadOptions.TransferOptions = new StorageTransferOptions { MaximumConcurrency = 4 };
                BlobTransferJobProperties jobProperties = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob,
                    downloadPath2,
                    options: downloadProgressOptions1).ConfigureAwait(false);
                BlobTransferJobProperties jobProperties2 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob2,
                    downloadPath2,
                    options: downloadProgressOptions2).ConfigureAwait(false);
                BlobTransferJobProperties jobProperties3 = await transferManager.ScheduleFolderDownloadAsync(
                    sourceDirectoryBlob3,
                    downloadPath2,
                    options: downloadProgressOptions3).ConfigureAwait(false);

                // wait for all jobs to finish

                // Option 1: CX uses event handler or progress handler to keep track which job has failures
                //await transferManager.
                // See the CheckDirectoryCompletionProgress

                // Option 2: CX wants transfer manager to just rerun all failed jobs
                // cons: how would the customer know how to resolve all the failed jobs without looking at
                // the event handler
                //await transferManager.ResumeTransferJobStatusAsync(StorageJobTransferStatus.CompletedWithErrors);

                // Something else happens in the CX which causes them to pause all jobs the CX is using
                // like an interrupt or something
                await transferManager.PauseTransferJobAsync(jobProperties2.TransferId);

                //  When they decide to allow the transferManager to resume
                await transferManager.ResumeTransferJobAsync(
                    jobProperties2.TransferId,
                    sourceCredentials: default,
                    destinationCredentials: default);
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }
    }
}
