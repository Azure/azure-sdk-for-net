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
using Azure.Storage.Sas;
using NUnit.Framework;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.Samples
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
                StorageTransferResults results = await transferManager.ScheduleUploadAsync(originalPath, destinationBlob);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast

                // Also I want to specify the progress handler
                Progress<long> blob2Progress = new Progress<long>();
                await transferManager.ScheduleUploadAsync(
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
                await transferManager.ScheduleDownloadAsync(sourceBlob, downloadPath);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast
                Progress<long> blob2Progress = new Progress<long>();
                await transferManager.ScheduleDownloadAsync(
                    sourceBlob2,
                    downloadPath2,
                    options: new BlobDownloadOptions()
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
        public async Task UploadDirectory_SasAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

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

                // Upload file data
                BlobTransferManager transferManager = new BlobTransferManager();

                // Create simple transfer single blob upload job
                StorageTransferResults results = await transferManager.ScheduleUploadDirectoryAsync(originalPath, destinationBlob);

                // Create transfer single blob upload job with transfer options concurrency specified
                // i.e. it's a bigger blob so it maybe need more help uploading fast

                // Also I want to specify the progress handler
                Progress<long> blob2Progress = new Progress<long>();
                await transferManager.ScheduleUploadDirectoryAsync(
                    originalPath,
                    destinationBlob2,
                    uploadOptions: new BlobDirectoryUploadOptions()
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
        /// Use an Active Directory token to access a Storage account.
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
        /// <summary>
        /// Upload a file to a blob.
        /// </summary>
        [Test]
        public async Task UploadAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string path = CreateTempFile(SampleFileContent);

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

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Get a reference to a blob
                BlobClient blob = container.GetBlobClient(Randomize("sample-file"));

                // Upload file data
                await blob.UploadAsync(path);

                // Verify we uploaded some content
                BlobProperties properties = await blob.GetPropertiesAsync();
                Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Download a blob to a file.
        /// </summary>
        [Test]
        public async Task DownloadAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Get a reference to a blob named "sample-file"
                BlobClient blob = container.GetBlobClient(Randomize("sample-file"));

                // First upload something the blob so we have something to download
                await blob.UploadAsync(File.OpenRead(originalPath));

                // Download the blob's contents and save it to a file
                await blob.DownloadToAsync(downloadPath);

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Download our sample image.
        /// </summary>
        [Test]
        public async Task DownloadImageAsync()
        {
            string downloadPath = CreateTempPath();
            #region Snippet:SampleSnippetsBlob_Async
            // Get a temporary path on disk where we can download the file
            //@@ string downloadPath = "hello.jpg";

            // Download the public blob at https://aka.ms/bloburl
            await new BlobClient(new Uri("https://aka.ms/bloburl")).DownloadToAsync(downloadPath);
            #endregion

            Assert.IsTrue(File.ReadAllBytes(downloadPath).Length > 0);
            File.Delete("hello.jpg");
        }

        /// <summary>
        /// List all the blobs in a container.
        /// </summary>
        [Test]
        public async Task ListAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Upload a couple of blobs so we have something to list
                await container.UploadBlobAsync("first", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("second", File.OpenRead(CreateTempFile()));
                await container.UploadBlobAsync("third", File.OpenRead(CreateTempFile()));

                // List all the blobs
                List<string> names = new List<string>();
                await foreach (BlobItem blob in container.GetBlobsAsync())
                {
                    names.Add(blob.Name);
                }

                Assert.AreEqual(3, names.Count);
                Assert.Contains("first", names);
                Assert.Contains("second", names);
                Assert.Contains("third", names);
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public async Task ErrorsAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            await container.CreateAsync();

            try
            {
                // Try to create the container again
                await container.CreateAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.ContainerAlreadyExists)
            {
                // Ignore any errors if the container already exists
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            // Clean up after the test when we're finished
            await container.DeleteAsync();
        }
    }
}
