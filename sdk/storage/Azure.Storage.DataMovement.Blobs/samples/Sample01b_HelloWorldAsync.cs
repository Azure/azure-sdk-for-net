// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using NUnit.Framework;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Azure.Storage.DataMovement.Blobs.Samples
{
    /// <summary>
    /// Basic Azure Blob Storage samples.
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        public Random _rand = new Random();

        [Test]
        public async Task ResourceConstructionDemonstration()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourceLocalPath = CreateTempFile(SampleFileContent);
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            try
            {
                {
                    TokenCredential tokenCredential = new DefaultAzureCredential();

                    TransferManager transferManager = new TransferManager();

                    // Get blobs provider with credential
                    #region Snippet:MakeProvider_TokenCredential
                    BlobsStorageResourceProvider blobs = new(tokenCredential);
                    #endregion

                    // Get a reference to a destination blobs
                    BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient("sample-blob-block");
                    PageBlobClient pageBlobClient = blobContainerClient.GetPageBlobClient("sample-blob-page");
                    AppendBlobClient appendBlobClient = blobContainerClient.GetAppendBlobClient("sample-blob-append");

                    // Construct simple blob resources for data movement
                    #region Snippet:ResourceConstruction_Blobs
                    StorageResource container = await blobs.FromContainerAsync(
                        new Uri("https://myaccount.blob.core.windows.net/container"));

                    // Block blobs are the default if no options are specified
                    StorageResource blockBlob = await blobs.FromBlobAsync(
                        new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-block"),
                        new BlockBlobStorageResourceOptions());
                    StorageResource pageBlob = await blobs.FromBlobAsync(
                        new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-page"),
                        new PageBlobStorageResourceOptions());
                    StorageResource appendBlob = await blobs.FromBlobAsync(
                        new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-append"),
                        new AppendBlobStorageResourceOptions());
                    #endregion
                }
                {
                    StorageSharedKeyCredential sharedKeyCredential = new(StorageAccountName, StorageAccountKey);
                    // Get blobs provider with credential
                    ValueTask<AzureSasCredential> GenerateSas(Uri uri, CancellationToken cancellationToken)
                    {
                        // Construct your SAS according to your needs
                        BlobUriBuilder blobUri = new(uri);
                        BlobSasBuilder sas = new(BlobSasPermissions.All, DateTimeOffset.Now.AddHours(1))
                        {
                            BlobContainerName = blobUri.BlobContainerName,
                            BlobName = blobUri.BlobName,
                        };
                        return new ValueTask<AzureSasCredential>(new AzureSasCredential(sas.ToSasQueryParameters(sharedKeyCredential).ToString()));
                    }
                    BlobsStorageResourceProvider blobs = new(GenerateSas);
                }
            }
            finally
            {
                await blobContainerClient.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Various ways of constructing blob resources.
        /// </summary>
        [Test]
        public async Task ConstructFromClientsDemonstration()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string sourceLocalPath = CreateTempFile(SampleFileContent);
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            try
            {
                TransferManager transferManager = new TransferManager();

                // Get a reference to a source local file
                StorageResource sourceResource = LocalFilesStorageResourceProvider.FromFile(sourceLocalPath);

                // Get a reference to a destination blobs
                BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient("sample-blob-block");
                PageBlobClient pageBlobClient = blobContainerClient.GetPageBlobClient("sample-blob-page");
                AppendBlobClient appendBlobClient = blobContainerClient.GetAppendBlobClient("sample-blob-append");

                await pageBlobClient.CreateAsync(Constants.KB);
                await appendBlobClient.CreateAsync();

                // Construct simple blob resources for data movement
                #region Snippet:ResourceConstruction_FromClients_Blobs
                StorageResource containerResource = BlobsStorageResourceProvider.FromClient(blobContainerClient);
                StorageResource blockBlobResource = BlobsStorageResourceProvider.FromClient(blockBlobClient);
                StorageResource pageBlobResource = BlobsStorageResourceProvider.FromClient(pageBlobClient);
                StorageResource appendBlobResource = BlobsStorageResourceProvider.FromClient(appendBlobClient);
                #endregion

                // Construct a blob container resource that is scoped to a blob prefix (virtual directory).
                #region Snippet:ResourceConstruction_Blobs_WithOptions_VirtualDirectory
                BlobStorageResourceContainerOptions virtualDirectoryOptions = new()
                {
                    BlobPrefix = "blob/directory/prefix"
                };

                StorageResource virtualDirectoryResource = BlobsStorageResourceProvider.FromClient(
                    blobContainerClient,
                    virtualDirectoryOptions);
                #endregion

                // Construct a blob resource with given metadata
                #region Snippet:ResourceConstruction_Blobs_WithOptions_BlockBlob
                BlockBlobStorageResourceOptions resourceOptions = new()
                {
                    Metadata = new Dictionary<string, string>
                        {
                            { "key", "value" }
                        }
                };
                StorageResource leasedBlockBlobResource = BlobsStorageResourceProvider.FromClient(
                    blockBlobClient,
                    resourceOptions);
                #endregion
            }
            finally
            {
                await blobContainerClient.DeleteIfExistsAsync();
            }
        }

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

            TokenCredential tokenCredential = new DefaultAzureCredential();
            string containerName = Randomize("sample-container");

            BlobServiceClient serviceClient = new BlobServiceClient(ActiveDirectoryBlobUri, tokenCredential);
            BlobContainerClient container = serviceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();
            try
            {
                #region Snippet:CreateTransferManagerSimple_BasePackage
                TransferManager transferManager = new TransferManager(new TransferManagerOptions());
                #endregion

                // Get a reference to a destination blobs
                Uri destinationBlobUri = container.GetBlockBlobClient("sample-blob").Uri;

                // Should be the same token credential as above, but for demonstration/sample purposes
                // we include how we would get the token credential.
                #region Snippet:SimpleBlobUpload_BasePackage
                TokenCredential defaultTokenCredential = new DefaultAzureCredential();
                BlobsStorageResourceProvider blobs = new BlobsStorageResourceProvider(defaultTokenCredential);

                // Create simple transfer single blob upload job
                #region Snippet:SimpleBlobUpload
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalPath),
                    destinationResource: await blobs.FromBlobAsync(destinationBlobUri));
                await transferOperation.WaitForCompletionAsync();
                #endregion
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
            TokenCredential tokenCredential = new DefaultAzureCredential();
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a SharedKeyCredential
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            try
            {
                // Get a reference to a source blobs and upload sample content to download
                BlockBlobClient sourceBlobClient = container.GetBlockBlobClient("sample-blob");
                Uri sourceBlobUri = sourceBlobClient.Uri;
                BlockBlobClient sourceBlob2 = container.GetBlockBlobClient("sample-blob2");

                using (FileStream stream = File.Open(originalPath, FileMode.Open))
                {
                    await sourceBlobClient.UploadAsync(stream);
                    stream.Position = 0;
                    await sourceBlob2.UploadAsync(stream);
                }

                // Create Blob Data Controller to skip through all failures
                TransferManagerOptions options = new TransferManagerOptions()
                {
                    ErrorMode = TransferErrorMode.ContinueOnFailure
                };
                TransferManager transferManager = new TransferManager(options);
                BlobsStorageResourceProvider blobs = new(tokenCredential);

                // Simple Download Single Blob Job
                #region Snippet:SimpleBlockBlobDownload
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: await blobs.FromBlobAsync(sourceBlobUri),
                    destinationResource: LocalFilesStorageResourceProvider.FromFile(downloadPath));
                await transferOperation.WaitForCompletionAsync();
                #endregion

                StorageResource sourceResource2 = BlobsStorageResourceProvider.FromClient(sourceBlobClient);
                StorageResource destinationResource2 = LocalFilesStorageResourceProvider.FromFile(downloadPath2);

                await transferManager.StartTransferAsync(
                    sourceResource: BlobsStorageResourceProvider.FromClient(sourceBlobClient, new BlockBlobStorageResourceOptions()
                    {
                        DestinationConditions = new BlobRequestConditions(){ LeaseId = "xyz" }
                    }),
                    destinationResource: LocalFilesStorageResourceProvider.FromFile(downloadPath2));
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
            BlobContainerClient blobContainerClient = service.GetBlobContainerClient(containerName);

            // Make a service request to verify we've successfully authenticated
            await blobContainerClient.CreateIfNotExistsAsync();
            Uri blobContainerUri = blobContainerClient.Uri;

            // Prepare for upload
            try
            {
                BlobsStorageResourceProvider blobs = new(new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey));

                // Create BlobTransferManager with event handler in Options bag
                TransferManagerOptions transferManagerOptions = new TransferManagerOptions();
                TransferOptions options = new TransferOptions()
                {
                    MaximumTransferChunkSize = 4 * Constants.MB,
                    CreationMode = StorageResourceCreationMode.OverwriteIfExists,
                };
                TransferManager transferManager = new TransferManager(transferManagerOptions);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                string optionalDestinationPrefix = "sample-directory2";
                #region Snippet:SimpleDirectoryUpload
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: LocalFilesStorageResourceProvider.FromDirectory(sourcePath),
                    destinationResource: await blobs.FromContainerAsync(
                        blobContainerUri,
                        new BlobStorageResourceContainerOptions()
                        {
                            // Block blobs are the default if not specified
                            BlobType = BlobType.Block,
                            BlobPrefix = optionalDestinationPrefix,
                        }));
                #endregion
            }
            finally
            {
                await blobContainerClient.DeleteIfExistsAsync();
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
                // Create BlobTransferManager with event handler in Options bag
                TransferManagerOptions options = new TransferManagerOptions();
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.ItemTransferCompleted += (TransferItemCompletedEventArgs args) =>
                {
                    using (StreamWriter logStream = File.AppendText(logFile))
                    {
                        logStream.WriteLine($"File Completed Transfer: {args.Source.Uri.AbsoluteUri}");
                    }
                    return Task.CompletedTask;
                };
                TransferManager transferManager = new TransferManager(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                TransferOperation uploadDirectoryJobId = await transferManager.StartTransferAsync(
                    LocalFilesStorageResourceProvider.FromDirectory(sourcePath),
                    BlobsStorageResourceProvider.FromClient(
                        container,
                        new BlobStorageResourceContainerOptions() { BlobPrefix = "sample-blob-directory" }));
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
                transferOptions.TransferStatusChanged += (TransferStatusEventArgs args) =>
                {
                    if (args.TransferStatus.HasCompletedSuccessfully)
                    {
                        using (StreamWriter logStream = File.AppendText(logFile))
                        {
                            logStream.WriteLine($"Our transfer has completed!");
                        }
                    }
                    return Task.CompletedTask;
                };
                #region Snippet:LogIndividualTransferFailures
                transferOptions.ItemTransferFailed += (TransferItemFailedEventArgs args) =>
                {
                    using (StreamWriter logStream = File.AppendText(logFile))
                    {
                        // Specifying specific resources that failed, since its a directory transfer
                        // maybe only one file failed out of many
                        logStream.WriteLine($"Exception occurred with TransferId: {args.TransferId}," +
                            $"Source Resource: {args.Source.Uri.AbsoluteUri}, +" +
                            $"Destination Resource: {args.Destination.Uri.AbsoluteUri}," +
                            $"Exception Message: {args.Exception.Message}");
                    }
                    return Task.CompletedTask;
                };
                #endregion
                TransferManager transferManager = new TransferManager(options);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                TransferOperation uploadDirectoryJobId = await transferManager.StartTransferAsync(
                    LocalFilesStorageResourceProvider.FromDirectory(sourcePath),
                    BlobsStorageResourceProvider.FromClient(
                        container,
                        new BlobStorageResourceContainerOptions() { BlobPrefix = "sample-blob-directory" }));
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
            TokenCredential tokenCredential = new DefaultAzureCredential();

            // Create a client that can authenticate using our token credential
            BlobServiceClient service = new BlobServiceClient(ActiveDirectoryBlobUri, tokenCredential);
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient blobContainerClient = service.GetBlobContainerClient(containerName);
            Uri blobContainerUri = blobContainerClient.Uri;

            // Make a service request to verify we've successfully authenticated
            await blobContainerClient.CreateIfNotExistsAsync();

            // Prepare to download
            try
            {
                // Get a reference to a source blobs and upload sample content to download
                StorageResource sourceDirectory = BlobsStorageResourceProvider.FromClient(blobContainerClient,
                    new BlobStorageResourceContainerOptions() { BlobPrefix = "sample-blob-directory" });
                StorageResource sourceDirectory2 = BlobsStorageResourceProvider.FromClient(blobContainerClient,
                    new BlobStorageResourceContainerOptions() { BlobPrefix = "sample-blob-directory2" });
                StorageResource destinationDirectory = LocalFilesStorageResourceProvider.FromDirectory(downloadPath);
                StorageResource destinationDirectory2 = LocalFilesStorageResourceProvider.FromDirectory(downloadPath2);

                // Upload a couple of blobs so we have something to list
                await blobContainerClient.UploadBlobAsync("first", File.OpenRead(CreateTempFile()));
                await blobContainerClient.UploadBlobAsync("first/fourth", File.OpenRead(CreateTempFile()));
                await blobContainerClient.UploadBlobAsync("first/fifth", File.OpenRead(CreateTempFile()));
                await blobContainerClient.UploadBlobAsync("second", File.OpenRead(CreateTempFile()));
                await blobContainerClient.UploadBlobAsync("third", File.OpenRead(CreateTempFile()));

                // Create BlobTransferManager with event handler in Options bag
                TransferManagerOptions options = new TransferManagerOptions();
                TransferOptions downloadOptions = new TransferOptions();
                downloadOptions.ItemTransferFailed += async (TransferItemFailedEventArgs args) =>
                {
                    // Log Exception Message
                    Console.WriteLine(args.Exception.Message);
                    // Remove stub
                    await Task.CompletedTask;
                };
                TransferManager transferManager = new TransferManager(options);

                // Simple Download Directory Job where we upload the directory and it's contents
                await transferManager.StartTransferAsync(
                    sourceDirectory, destinationDirectory);

                // Create different download transfer
                string optionalSourcePrefix = "sample-blob-directory2";
                BlobsStorageResourceProvider blobs = new(tokenCredential);
                #region Snippet:SimpleDirectoryDownload_Blob
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: await blobs.FromContainerAsync(
                        blobContainerUri,
                        new BlobStorageResourceContainerOptions()
                        {
                            BlobPrefix = optionalSourcePrefix
                        }),
                    destinationResource: LocalFilesStorageResourceProvider.FromDirectory(downloadPath));
                await transferOperation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await blobContainerClient.DeleteIfExistsAsync();
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
            TokenCredential tokenCredential = new DefaultAzureCredential();

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();
            await container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            // Prepare to copy
            try
            {
                // Get a reference to a destination blobs
                BlockBlobClient sourceBlockBlobClient = container.GetBlockBlobClient("sample-blob");
                Uri sourceBlobUri = sourceBlockBlobClient.Uri;

                using (FileStream stream = File.Open(originalPath, FileMode.Open))
                {
                    await sourceBlockBlobClient.UploadAsync(stream);
                    stream.Position = 0;
                }

                AppendBlobClient destinationAppendBlobClient = container.GetAppendBlobClient("sample-blob2");
                Uri destinationBlobUri = destinationAppendBlobClient.Uri;

                // Upload file data
                TransferManager transferManager = new TransferManager(default);
                BlobsStorageResourceProvider blobs = new(tokenCredential);

                // Create simple transfer single blob upload job
                #region Snippet:s2sCopyBlob
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: await blobs.FromBlobAsync(sourceBlobUri),
                    destinationResource: await blobs.FromBlobAsync(destinationBlobUri, new AppendBlobStorageResourceOptions()));
                await transferOperation.WaitForCompletionAsync();
                #endregion

                Assert.IsTrue(await destinationAppendBlobClient.ExistsAsync());
                Assert.AreEqual(TransferState.Completed, transferOperation.Status.State);
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
            TokenCredential tokenCredential = new DefaultAzureCredential();

            // Create a client that can authenticate with a connection string
            BlobServiceClient service = new BlobServiceClient(serviceUri, tokenCredential);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            Uri sourceContainerUri = container.Uri;
            Uri destinationContainerUri = container.Uri;

            // Make a service request to verify we've successfully authenticated
            await container.CreateIfNotExistsAsync();

            // Prepare to copy directory
            try
            {
                string sourceDirectoryName = "sample-blob-directory";
                string sourceDirectoryName2 = "sample-blob-directory2";

                // Get a reference to a source blobs and upload sample content to download
                StorageResource sourceDirectory1 = BlobsStorageResourceProvider.FromClient(container,
                    new BlobStorageResourceContainerOptions() { BlobPrefix = sourceDirectoryName });
                StorageResource sourceDirectory2 = BlobsStorageResourceProvider.FromClient(container,
                    new BlobStorageResourceContainerOptions() { BlobPrefix = sourceDirectoryName2 });

                // Create destination paths
                StorageResource destinationDirectory1 = LocalFilesStorageResourceProvider.FromDirectory(downloadPath);
                StorageResource destinationDirectory2 = LocalFilesStorageResourceProvider.FromDirectory(downloadPath2);

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
                options.ItemTransferFailed += async (TransferItemFailedEventArgs args) =>
                {
                    //await LogFailedFileAsync(args.SourceFileUri, args.DestinationFileClient.Uri, args.Exception.Message);
                };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
                BlobsStorageResourceProvider blobs = new(tokenCredential);

                // this is just a directory copy within a container, but they can be separate containers as well
                BlobContainerClient sourceContainer = container;
                BlobContainerClient destinationContainer = container;
                #region Snippet:s2sCopyBlobContainer
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                sourceResource: await blobs.FromContainerAsync(
                    sourceContainerUri,
                    new BlobStorageResourceContainerOptions()
                    {
                        BlobPrefix = sourceDirectoryName
                    }),
                destinationResource: await blobs.FromContainerAsync(
                    destinationContainerUri,
                    new BlobStorageResourceContainerOptions()
                    {
                        // all source blobs will be copied as a single type of destination blob
                        // defaults to block blobs if unspecified
                        BlobType = BlobType.Block,
                        BlobPrefix = downloadPath
                    }));
                await transferOperation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Basic pause and resume flow from <see cref="TransferManager"/>.
        /// </summary>
        [Test]
        public async Task PauseAndResumeAsync_TransferManager()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateIfNotExistsAsync();
            try
            {
                // Get a temporary path on disk where we can download the file
                string downloadPath = CreateTempPath();

                // Copy the public MacBeth copy to a Blob
                BlockBlobClient sourceBlob = container.GetBlockBlobClient("MacBeth.txt");
                await sourceBlob.SyncUploadFromUriAsync(new Uri("https://www.gutenberg.org/cache/epub/1533/pg1533.txt"));

                // Create transfer manager
                #region Snippet:SetupTransferManagerForResume
                TokenCredential tokenCredential = new DefaultAzureCredential();
                BlobsStorageResourceProvider blobs = new(tokenCredential);
                TransferManager transferManager = new(new TransferManagerOptions()
                {
                    ProvidersForResuming = new List<StorageResourceProvider>() { blobs },
                });
                #endregion

                // Create source and destination resource
                StorageResource sourceResource = BlobsStorageResourceProvider.FromClient(sourceBlob);
                StorageResource destinationResource = LocalFilesStorageResourceProvider.FromFile(downloadPath);

                // Create simple transfer single blob download job
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);
                string transferId = transferOperation.Id;

                // Pause from the Transfer Manager using the Transfer Id
                #region Snippet:PauseFromManager
                await transferManager.PauseTransferAsync(transferId);
                #endregion

                // Resume a single transfer
                #region Snippet:DataMovement_ResumeSingle
                TransferOperation resumedTransfer = await transferManager.ResumeTransferAsync(transferId);
                #endregion

                // Wait for download to finish
                await resumedTransfer.WaitForCompletionAsync();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Basic pause and resume flow from <see cref="TransferOperation"/>.
        /// </summary>
        [Test]
        public async Task PauseAndResumeAsync_TransferOperation()
        {
            string connectionString = ConnectionString;
            TokenCredential tokenCredential = new DefaultAzureCredential();
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateIfNotExistsAsync();
            try
            {
                // Get a temporary path on disk where we can download the file
                string downloadPath = CreateTempPath();

                // Copy the public MacBeth copy to a Blob
                BlockBlobClient sourceBlob = container.GetBlockBlobClient("MacBeth.txt");
                await sourceBlob.SyncUploadFromUriAsync(new Uri("https://www.gutenberg.org/cache/epub/1533/pg1533.txt"));

                // Create transfer manager
                BlobsStorageResourceProvider blobs = new(tokenCredential);
                TransferManager transferManager = new(new TransferManagerOptions()
                {
                    ProvidersForResuming = new List<StorageResourceProvider>() { blobs },
                });

                // Create source and destination resource
                StorageResource sourceResource = BlobsStorageResourceProvider.FromClient(sourceBlob);
                StorageResource destinationResource = LocalFilesStorageResourceProvider.FromFile(downloadPath);

                // Create simple transfer single blob download job
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);

                // Pause from the TransferOperation object
                #region Snippet:PauseFromTransfer
                await transferOperation.PauseAsync();
                #endregion

                TransferOperation resumedTransfer = await transferManager.ResumeTransferAsync(transferOperation.Id);

                // Wait for download to finish
                await resumedTransfer.WaitForCompletionAsync();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Show show to resume all transfers from <see cref="TransferManager"/>.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PauseAndResumeAsync_ResumeAll()
        {
            TokenCredential tokenCredential = new DefaultAzureCredential();
            BlobsStorageResourceProvider blobs = new(tokenCredential);
            TransferManager transferManager = new(new TransferManagerOptions()
            {
                ProvidersForResuming = new List<StorageResourceProvider>() { blobs },
            });

            // ... start multiple transfers

            #region Snippet:ResumeAllTransfers
            // Resume all transfers
            List<TransferOperation> transfers = await transferManager.ResumeAllTransfersAsync();
            #endregion

            // Wait for all transfers to finish
            Task[] resumedTasks = transfers.Select(t => t.WaitForCompletionAsync()).ToArray();
            await Task.WhenAll(resumedTasks);
        }

        /// <summary>
        /// Use the <see cref="BlobContainerClient.UploadDirectory"/> extension method to upload an entire directory.
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
                    TransferOperation transfer = await container.UploadDirectoryAsync(WaitUntil.Started, localPath);

                    await transfer.WaitForCompletionAsync();
                    #endregion
                }
                {
                    // upload files with to a specific directory prefix
                    #region Snippet:ExtensionMethodSimpleUploadToDirectoryPrefix
                    TransferOperation transfer = await container.UploadDirectoryAsync(WaitUntil.Started, localPath, blobDirectoryPrefix);

                    await transfer.WaitForCompletionAsync();
                    #endregion
                }
                {
                    #region Snippet:ExtensionMethodSimpleUploadWithOptions
                    BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
                    {
                        BlobContainerOptions = new BlobStorageResourceContainerOptions
                        {
                            BlobPrefix = blobDirectoryPrefix
                        },
                        TransferOptions = new TransferOptions()
                        {
                            CreationMode = StorageResourceCreationMode.OverwriteIfExists,
                        }
                    };

                    TransferOperation transfer = await container.UploadDirectoryAsync(WaitUntil.Started, localPath, options);

                    await transfer.WaitForCompletionAsync();
                    #endregion
                }
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Use the <see cref="BlobContainerClient.UploadDirectory"/> extension method to upload an entire directory.
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
                    TransferOperation transfer = await container.DownloadToDirectoryAsync(WaitUntil.Started, localDirectoryPath);

                    await transfer.WaitForCompletionAsync();
                    #endregion
                }
                {
                    // download a virtual directory, with a specific prefix, within the container
                    #region Snippet:ExtensionMethodSimpleDownloadContainerDirectory
                    TransferOperation transfer = await container.DownloadToDirectoryAsync(WaitUntil.Started, localDirectoryPath2, blobDirectoryPrefix);

                    await transfer.WaitForCompletionAsync();
                    #endregion
                }
                {
                    #region Snippet:ExtensionMethodSimpleDownloadContainerDirectoryWithOptions
                    BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
                    {
                        BlobContainerOptions = new BlobStorageResourceContainerOptions
                        {
                            BlobPrefix = blobDirectoryPrefix
                        },
                        TransferOptions = new TransferOptions()
                        {
                            CreationMode = StorageResourceCreationMode.OverwriteIfExists,
                        }
                    };

                    TransferOperation transfer = await container.DownloadToDirectoryAsync(WaitUntil.Started, localDirectoryPath2, options);

                    await transfer.WaitForCompletionAsync();
                    #endregion
                }
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task MonitorUploadAsync()
        {
            string sourceLocalPath = CreateTempFile(SampleFileContent);
            BlobContainerClient container = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            await container.CreateIfNotExistsAsync();

            try
            {
                // Get a reference to a source local file
                StorageResource sourceResource = LocalFilesStorageResourceProvider.FromFile(sourceLocalPath);

                // Get a reference to a destination blob
                TransferManager transferManager = new TransferManager();

                string logFile = CreateTempPath();

                #region Snippet:EnumerateTransfers
                async Task CheckTransfersAsync(TransferManager transferManager)
                {
                    await foreach (TransferOperation transfer in transferManager.GetTransfersAsync())
                    {
                        using StreamWriter logStream = File.AppendText(logFile);
                        logStream.WriteLine(Enum.GetName(typeof(TransferStatus), transfer.Status));
                    }
                }
                #endregion

                #region Snippet:ListenToTransferEvents
                async Task<TransferOperation> ListenToTransfersAsync(TransferManager transferManager,
                    StorageResource source, StorageResource destination)
                {
                    TransferOptions transferOptions = new();
                    transferOptions.ItemTransferCompleted += (TransferItemCompletedEventArgs args) =>
                    {
                        using StreamWriter logStream = File.AppendText(logFile);
                        logStream.WriteLine($"File Completed Transfer: {args.Source.Uri.LocalPath}");
                        return Task.CompletedTask;
                    };
                    return await transferManager.StartTransferAsync(
                        source,
                        destination,
                        transferOptions);
                }
                #endregion

                #region Snippet:ListenToProgress
                async Task<TransferOperation> ListenToProgressAsync(TransferManager transferManager, IProgress<TransferProgress> progress,
                    StorageResource source, StorageResource destination)
                {
                    TransferOptions transferOptions = new()
                    {
                        ProgressHandlerOptions = new()
                        {
                            ProgressHandler = progress,
                            // optionally include the below if progress updates on bytes transferred are desired
                            TrackBytesTransferred = true,
                        }
                    };
                    return await transferManager.StartTransferAsync(
                        source,
                        destination,
                        transferOptions);
                }
                #endregion

                StorageResource destinationResource1 = BlobsStorageResourceProvider.FromClient(container.GetBlockBlobClient("sample-blob-1"));
                StorageResource destinationResource2 = BlobsStorageResourceProvider.FromClient(container.GetBlockBlobClient("sample-blob-2"));
                TransferOperation dataTransfer1 = await ListenToTransfersAsync(transferManager, sourceResource, destinationResource1);
                TransferOperation dataTransfer2 = await ListenToProgressAsync(transferManager, new Progress<TransferProgress>(p => { }), sourceResource, destinationResource2);
                await CheckTransfersAsync(transferManager);
                await dataTransfer1.WaitForCompletionAsync();

                #region Snippet:LogTotalTransferFailure
                await dataTransfer2.WaitForCompletionAsync();
                if (dataTransfer2.Status.State == TransferState.Completed
                    && dataTransfer2.Status.HasFailedItems)
                {
                    using (StreamWriter logStream = File.AppendText(logFile))
                    {
                        logStream.WriteLine($"Failure for TransferId: {dataTransfer2.Id}");
                    }
                }
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        public void CreateTransferOptionCreationMode()
        {
            #region Snippet:TransferOptionsOverwrite
            TransferOptions optionsOverwriteIfExists = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists,
            };
            #endregion
            #region Snippet:TransferOptionsSkipIfExists
            TransferOptions optionsSkipIfExists = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.SkipIfExists,
            };
            #endregion
        }

        public async Task ResumeTransfersStoredAsync()
        {
            #region Snippet:TransferManagerResumeTransfers
            TokenCredential tokenCredential = new DefaultAzureCredential();
            BlobsStorageResourceProvider blobs = new(tokenCredential);
            TransferManager transferManager = new TransferManager(new TransferManagerOptions()
            {
                ProvidersForResuming = new List<StorageResourceProvider>() { blobs }
            });
            // Get resumable transfers from transfer manager
            await foreach (TransferProperties properties in transferManager.GetResumableTransfersAsync())
            {
                // Resume the transfer
                if (properties.SourceUri.AbsoluteUri == "https://storageaccount.blob.core.windows.net/containername/blobpath")
                {
                    await transferManager.ResumeTransferAsync(properties.TransferId);
                }
            }
            #endregion
        }

        #region Snippet:EnumerateTransfersStatus
        public async Task CheckTransfersStatusAsync(TransferManager transferManager)
        {
            string logFile = CreateTempPath();
            await foreach (TransferOperation transfer in transferManager.GetTransfersAsync())
            {
                using StreamWriter logStream = File.AppendText(logFile);
                logStream.WriteLine(Enum.GetName(typeof(TransferStatus), transfer.Status));
            }
        }
        #endregion

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
