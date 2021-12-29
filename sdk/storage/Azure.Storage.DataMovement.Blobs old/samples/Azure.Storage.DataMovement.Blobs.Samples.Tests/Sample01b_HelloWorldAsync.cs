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
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.Sas;
using NUnit.Framework;
using Azure.Storage.DataMovement;
using Azure.Core;
using Azure.Identity;

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
                BlobClient destinationBlob = container.GetBlobClient(Randomize("sample-blob"));
                BlobClient destinationBlob2 = container.GetBlobClient(Randomize("sample-blob"));

                // Upload file data
                BlobTransferManager transferManager = new BlobTransferManager();

                // Create simple transfer single blob upload job
                string jobId = transferManager.ScheduleUpload(originalPath, destinationBlob);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast

                // Also I want to specify the progress handler
                Progress<long> blob2Progress = new Progress<long>();
                transferManager.ScheduleUpload(
                    originalPath,
                    destinationBlob2,
                    uploadOptions: new BlobUploadOptions()
                    {
                        ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions()
                        {
                            MaximumConcurrency = 4
                        }
                    });
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
                BlobTransferManager transferManager = new BlobTransferManager();

                // Simple Download Single Blob Job
                transferManager.ScheduleDownload(sourceBlob, downloadPath);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                Progress<long> blob2Progress = new Progress<long>();
                transferManager.ScheduleDownload(
                    sourceBlob2,
                    downloadPath2,
                    options: new BlobDownloadToOptions()
                    {
                        ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions
                        {
                            MaximumConcurrency = 4
                        }
                    });
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
                BlobVirtualDirectoryClient destinationBlob = container.GetBlobVirtualDirectoryClient(Randomize("sample-blob-directory"));
                BlobVirtualDirectoryClient destinationBlob2 = container.GetBlobVirtualDirectoryClient(Randomize("sample-blob-directory"));

                // Create BlobTransferManager with event handler in Options bag
                StorageTransferManagerOptions options = new StorageTransferManagerOptions();
                options.TransferStatus.FilesFailedTransferred += async (PathTransferFailedEventArgs args) =>
                {
                    if (args.Exception.ErrorCode == "500")
                    {
                        Console.WriteLine("We're getting throttled stop trying and lets try later");
                    }
                    else if (args.Exception.ErrorCode == "403")
                    {
                        Console.WriteLine("We're getting auth errors. Might be the entire container, consider stopping");
                    }
                    // Remove stub
                    await Task.CompletedTask;
                };
                BlobTransferManager transferManager = new BlobTransferManager(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                string uploadDirectoryJobId = transferManager.ScheduleUploadDirectory(sourcePath, destinationBlob);

                // Create simple transfer directory upload job which the contents of that directory
                string uploadDirectoryJobId2 = transferManager.ScheduleUploadDirectory(
                    sourcePath2,
                    destinationBlob,
                    options: new BlobDirectoryUploadOptions()
                    {
                        ContentsOnly = true
                    });

                // Create transfer directory upload job where we specify a progress handler and concurrency
                Progress<StorageTransferStatus> blob2Progress = new Progress<StorageTransferStatus>();
                string uploadDirectoryJobId3 = transferManager.ScheduleUploadDirectory(
                    sourcePath,
                    destinationBlob2,
                    options: new BlobDirectoryUploadOptions()
                    {
                        //This is where we would put the progress handler if we wanted to provide a more grandular control
                        //ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions()
                        {
                            MaximumConcurrency = 4
                        }
                    });
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
            string originalPath = CreateSampleDirectoryTree();
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
                BlobVirtualDirectoryClient sourceBlobDirectory = container.GetBlobVirtualDirectoryClient(Randomize("sample-blob-directory"));
                BlobVirtualDirectoryClient sourceBlobDirectory2 = container.GetBlobVirtualDirectoryClient(Randomize("sample-blob-directory"));

                await sourceBlobDirectory.UploadAsync(originalPath);
                await sourceBlobDirectory2.UploadAsync(originalPath);

                // Create BlobTransferManager with event handler in Options bag
                StorageTransferManagerOptions options = new StorageTransferManagerOptions();
                options.TransferStatus.FilesFailedTransferred += async (PathTransferFailedEventArgs args) =>
                {
                    if (args.Exception.ErrorCode == "500")
                    {
                        Console.WriteLine("We're getting throttled stop trying and lets try later");
                    }
                    else if (args.Exception.ErrorCode == "403")
                    {
                        Console.WriteLine("We're getting auth errors. Might be the entire container, consider stopping");
                    }
                    // Remove stub
                    await Task.CompletedTask;
                };
                BlobTransferManager transferManager = new BlobTransferManager(options);

                // Simple Download Directory Job where we upload the directory and it's contents
                transferManager.ScheduleDownloadDirectory(sourceBlobDirectory, downloadPath);

                // Create simple transfer directory download job which the contents of that directory
                string downloadDirectoryJobId = transferManager.ScheduleDownloadDirectory(
                    sourceBlobDirectory2,
                    downloadPath,
                    options: new BlobDirectoryDownloadOptions()
                    {
                        ContentsOnly = true
                    });

                // Create transfer directory upload job where we specify a progress handler and concurrency
                Progress<StorageTransferStatus> blob2Progress = new Progress<StorageTransferStatus>();
                string downloadDirectoryJobId2 = transferManager.ScheduleDownloadDirectory(
                    sourceBlobDirectory2,
                    downloadPath2,
                    options: new BlobDirectoryDownloadOptions()
                    {
                        // This is where the progress handler would live if we provided more grandularity
                        //ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions
                        {
                            MaximumConcurrency = 4
                        }
                    });
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        // Management of Jobs
        [Test]
        public void TransferMangerJobManagement()
        {
            // Setup
            string planFile = CreateTempPath();
            string sourcePath = CreateSampleDirectoryTree();
            string downloadPath = CreateSampleDirectoryTree();
            // Possible someone could have gotten a list of directories from a list call
            BlobVirtualDirectoryClient sourceBlobDirectory = new BlobVirtualDirectoryClient("", "", "", new BlobClientOptions());
            BlobVirtualDirectoryClient sourceBlobDirectory2 = new BlobVirtualDirectoryClient("", "", "", new BlobClientOptions());
            BlobVirtualDirectoryClient sourceBlobDirectory3 = new BlobVirtualDirectoryClient("", "", "", new BlobClientOptions());
            BlobVirtualDirectoryClient sourceBlobDirectory4 = new BlobVirtualDirectoryClient("", "", "", new BlobClientOptions());
            BlobVirtualDirectoryClient sourceBlobDirectory5 = new BlobVirtualDirectoryClient("", "", "", new BlobClientOptions());
            BlobVirtualDirectoryClient destinationBlob = new BlobVirtualDirectoryClient("", "", "", new BlobClientOptions());

            // Set plan file or the directory where you would like the transfer state directory path
            StorageTransferManagerOptions transferManagerOptions = new StorageTransferManagerOptions()
            {
                TransferStateDirectoryPath = planFile
            };
            transferManagerOptions.TransferStatus.FilesFailedTransferred += async (PathTransferFailedEventArgs args) =>
            {
                if (args.Exception.ErrorCode == "500")
                {
                    Console.WriteLine("We're getting throttled stop trying and lets try later");
                    // Trigger cancellation token cancel
                }
                else if (args.Exception.ErrorCode == "403")
                {
                    Console.WriteLine("We're getting auth errors. Might be the entire container, consider stopping");
                }
                // Remove stub
                await Task.CompletedTask;
            };

            BlobTransferManager blobTransferManager = new BlobTransferManager(transferManagerOptions);

            string uploadDirectoryJobId = blobTransferManager.ScheduleUploadDirectory(sourcePath, destinationBlob);
            string downloadDirectoryJobId = blobTransferManager.ScheduleDownloadDirectory(sourceBlobDirectory, downloadPath);
            string downloadDirectoryJobId2 = blobTransferManager.ScheduleDownloadDirectory(sourceBlobDirectory2, downloadPath);
            string downloadDirectoryJobId3 = blobTransferManager.ScheduleDownloadDirectory(sourceBlobDirectory3, downloadPath);
            string downloadDirectoryJobId4 = blobTransferManager.ScheduleDownloadDirectory(sourceBlobDirectory4, downloadPath);
            string downloadDirectoryJobId5 = blobTransferManager.ScheduleDownloadDirectory(sourceBlobDirectory5, downloadPath);

            //List all jobs
            IList<string> list = blobTransferManager.ListJobs();

            // Get Job information with using Job Id
            StorageTransferJob job = blobTransferManager.GetJob(downloadDirectoryJobId3);
            // Get Job information using job id from list
            StorageTransferJob job2 = blobTransferManager.GetJob(list[1]);

            // Pause transfers
            blobTransferManager.PauseTransfers();

            blobTransferManager.Clean();
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
                BlobClient destinationBlob = container.GetBlobClient(Randomize("sample-blob"));
                BlobClient destinationBlob2 = container.GetBlobClient(Randomize("sample-blob"));

                // Upload file data
                BlobTransferManager transferManager = new BlobTransferManager();

                // Create simple transfer single blob upload job
                string jobId = transferManager.ScheduleUpload(originalPath, destinationBlob);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast

                // Also I want to specify the progress handler
                Progress<long> blob2Progress = new Progress<long>();
                transferManager.ScheduleUpload(
                    originalPath,
                    destinationBlob2,
                    uploadOptions: new BlobUploadOptions()
                    {
                        ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions()
                        {
                            MaximumConcurrency = 4
                        }
                    });
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
        public async Task CopySingle_SharedKeyAuthAsync()
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
                BlobTransferManager transferManager = new BlobTransferManager();

                // Simple Download Single Blob Job
                transferManager.ScheduleDownload(sourceBlob, downloadPath);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                Progress<long> blob2Progress = new Progress<long>();
                transferManager.ScheduleDownload(
                    sourceBlob2,
                    downloadPath2,
                    options: new BlobDownloadToOptions()
                    {
                        ProgressHandler = blob2Progress,
                        TransferOptions = new StorageTransferOptions
                        {
                            MaximumConcurrency = 4
                        }
                    });
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        //TODO: scenario. To get back file or directory handle and remove read only attributes on the folder
        // then resume the directory transfer
    }
}
