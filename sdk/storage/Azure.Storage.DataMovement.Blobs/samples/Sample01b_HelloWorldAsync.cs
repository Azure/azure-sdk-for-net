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

                    // Get local filesystem provider
                    LocalFilesStorageResourceProvider files = new();

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
                    StorageResource container = blobs.FromContainer(
                        new Uri("https://myaccount.blob.core.windows.net/container"));

                    // Block blobs are the default if no options are specified
                    StorageResource blockBlob = blobs.FromBlob(
                        new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-block"),
                        new BlockBlobStorageResourceOptions());
                    StorageResource pageBlob = blobs.FromBlob(
                        new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-page"),
                        new PageBlobStorageResourceOptions());
                    StorageResource appendBlob = blobs.FromBlob(
                        new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-append"),
                        new AppendBlobStorageResourceOptions());
                    #endregion
                }
                {
                    StorageSharedKeyCredential sharedKeyCredential = new(StorageAccountName, StorageAccountKey);
                    // Get blobs provider with credential
                    AzureSasCredential GenerateSas(Uri uri, bool readOnly)
                    {
                        // Construct your SAS according to your needs
                        BlobUriBuilder blobUri = new(uri);
                        BlobSasBuilder sas = new(BlobSasPermissions.All, DateTimeOffset.Now.AddHours(1))
                        {
                            BlobContainerName = blobUri.BlobContainerName,
                            BlobName = blobUri.BlobName,
                        };
                        return new AzureSasCredential(sas.ToSasQueryParameters(sharedKeyCredential).ToString());
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
                LocalFilesStorageResourceProvider files = new();
                StorageResource sourceResource = files.FromFile(sourceLocalPath);

                // Get a reference to a destination blobs
                BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient("sample-blob-block");
                PageBlobClient pageBlobClient = blobContainerClient.GetPageBlobClient("sample-blob-page");
                AppendBlobClient appendBlobClient = blobContainerClient.GetAppendBlobClient("sample-blob-append");

                await pageBlobClient.CreateAsync(Constants.KB);
                await appendBlobClient.CreateAsync();

                // Construct simple blob resources for data movement
                #region Snippet:ResourceConstruction_FromClients_Blobs
                BlobsStorageResourceProvider blobs = new();
                StorageResource containerResource = blobs.FromClient(blobContainerClient);
                StorageResource blockBlobResource = blobs.FromClient(blockBlobClient);
                StorageResource pageBlobResource = blobs.FromClient(pageBlobClient);
                StorageResource appendBlobResource = blobs.FromClient(appendBlobClient);
                #endregion

                // Construct a blob container resource that is scoped to a blob prefix (virtual directory).
                #region Snippet:ResourceConstruction_Blobs_WithOptions_VirtualDirectory
                BlobStorageResourceContainerOptions virtualDirectoryOptions = new()
                {
                    BlobDirectoryPrefix = "blob/directory/prefix"
                };

                StorageResource virtualDirectoryResource = blobs.FromClient(
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
                StorageResource leasedBlockBlobResource = blobs.FromClient(
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

                #region Snippet:SimpleBlobUpload_BasePackage
                LocalFilesStorageResourceProvider files = new();
                BlobsStorageResourceProvider blobs = new(tokenCredential);

                // Create simple transfer single blob upload job
                #region Snippet:SimpleBlobUpload
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: files.FromFile(sourceLocalPath),
                    destinationResource: blobs.FromBlob(destinationBlobUri));
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
                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();

                // Simple Download Single Blob Job
                #region Snippet:SimpleBlockBlobDownload
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: blobs.FromBlob(sourceBlobUri),
                    destinationResource: files.FromFile(downloadPath));
                await transferOperation.WaitForCompletionAsync();
                #endregion

                StorageResource sourceResource2 = blobs.FromClient(sourceBlobClient);
                StorageResource destinationResource2 = files.FromFile(downloadPath2);

                await transferManager.StartTransferAsync(
                    sourceResource: blobs.FromClient(sourceBlobClient, new BlockBlobStorageResourceOptions()
                    {
                        DestinationConditions = new BlobRequestConditions(){ LeaseId = "xyz" }
                    }),
                    destinationResource: files.FromFile(downloadPath2));
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
                LocalFilesStorageResourceProvider files = new();

                // Create BlobTransferManager with event handler in Options bag
                TransferManagerOptions transferManagerOptions = new TransferManagerOptions();
                TransferOptions options = new TransferOptions()
                {
                    MaximumTransferChunkSize = 4 * Constants.MB,
                    CreationPreference = StorageResourceCreationMode.OverwriteIfExists,
                };
                TransferManager transferManager = new TransferManager(transferManagerOptions);

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                string optionalDestinationPrefix = "sample-directory2";
                #region Snippet:SimpleDirectoryUpload
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: files.FromDirectory(sourcePath),
                    destinationResource: blobs.FromContainer(
                        blobContainerUri,
                        new BlobStorageResourceContainerOptions()
                        {
                            // Block blobs are the default if not specified
                            BlobType = BlobType.Block,
                            BlobDirectoryPrefix = optionalDestinationPrefix,
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
                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();
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
                    files.FromDirectory(sourcePath),
                    blobs.FromClient(
                        container,
                        new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = "sample-blob-directory" }));
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
                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();

                // Create simple transfer directory upload job which uploads the directory and the contents of that directory
                TransferOperation uploadDirectoryJobId = await transferManager.StartTransferAsync(
                    files.FromDirectory(sourcePath),
                    blobs.FromClient(
                        container,
                        new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = "sample-blob-directory" }));
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
            TokenCredential credential = new DefaultAzureCredential();

            // Create a client that can authenticate using our token credential
            BlobServiceClient service = new BlobServiceClient(ActiveDirectoryBlobUri, credential);
            string containerName = Randomize("sample-container");

            // Create a client that can authenticate with a connection string
            BlobContainerClient blobContainerClient = service.GetBlobContainerClient(containerName);
            Uri blobContainerUri = blobContainerClient.Uri;

            // Make a service request to verify we've successfully authenticated
            await blobContainerClient.CreateIfNotExistsAsync();

            // Prepare to download
            try
            {
                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();
                // Get a reference to a source blobs and upload sample content to download
                StorageResource sourceDirectory = blobs.FromClient(blobContainerClient,
                    new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = "sample-blob-directory" });
                StorageResource sourceDirectory2 = blobs.FromClient(blobContainerClient,
                    new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = "sample-blob-directory2" });
                StorageResource destinationDirectory = files.FromDirectory(downloadPath);
                StorageResource destinationDirectory2 = files.FromDirectory(downloadPath2);

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
                #region Snippet:SimpleDirectoryDownload_Blob
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: blobs.FromContainer(
                        blobContainerUri,
                        new BlobStorageResourceContainerOptions()
                        {
                            BlobDirectoryPrefix = optionalSourcePrefix
                        }),
                    destinationResource: files.FromDirectory(downloadPath));
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
                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();

                // Create simple transfer single blob upload job
                #region Snippet:s2sCopyBlob
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: blobs.FromBlob(sourceBlobUri),
                    destinationResource: blobs.FromBlob(destinationBlobUri, new AppendBlobStorageResourceOptions()));
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
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a connection string
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);
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

                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();
                // Get a reference to a source blobs and upload sample content to download
                StorageResource sourceDirectory1 = blobs.FromClient(container,
                    new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = sourceDirectoryName });
                StorageResource sourceDirectory2 = blobs.FromClient(container,
                    new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = sourceDirectoryName2 });

                // Create destination paths
                StorageResource destinationDirectory1 = files.FromDirectory(downloadPath);
                StorageResource destinationDirectory2 = files.FromDirectory(downloadPath2);

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

                // this is just a directory copy within a container, but they can be separate containers as well
                BlobContainerClient sourceContainer = container;
                BlobContainerClient destinationContainer = container;
                #region Snippet:s2sCopyBlobContainer
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                sourceResource: blobs.FromContainer(
                    sourceContainerUri,
                    new BlobStorageResourceContainerOptions()
                    {
                        BlobDirectoryPrefix = sourceDirectoryName
                    }),
                destinationResource: blobs.FromContainer(
                    destinationContainerUri,
                    new BlobStorageResourceContainerOptions()
                    {
                        // all source blobs will be copied as a single type of destination blob
                        // defaults to block blobs if unspecified
                        BlobType = BlobType.Block,
                        BlobDirectoryPrefix = downloadPath
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

                // Download the public MacBeth copy at https://www.gutenberg.org/cache/epub/1533/pg1533.txt
                BlockBlobClient sourceBlob = new BlockBlobClient(new Uri("https://www.gutenberg.org/cache/epub/1533/pg1533.txt"));
                await sourceBlob.DownloadToAsync(downloadPath);

                // Create a token credential that can use our Azure Active
                // Directory application to authenticate with Azure Storage
                TokenCredential tokenCredential = new DefaultAzureCredential();

                // Create transfer manager
                #region Snippet:SetupTransferManagerForResume
                LocalFilesStorageResourceProvider files = new();
                BlobsStorageResourceProvider blobs = new(tokenCredential);
                TransferManager transferManager = new(new TransferManagerOptions()
                {
                    ResumeProviders = new List<StorageResourceProvider>() { files, blobs },
                });
                #endregion

                // Create source and destination resource
                StorageResource sourceResource = blobs.FromClient(sourceBlob);
                StorageResource destinationResource = files.FromFile(downloadPath);

                // Create simple transfer single blob download job
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);
                string transferId = transferOperation.Id;

                // Pause from the Transfer Manager using the Transfer Id
                #region Snippet:PauseFromManager
                await transferManager.PauseTransferAsync(transferId);
                #endregion

                // Resume all transfers
                List<TransferOperation> transfers = await transferManager.ResumeAllTransfersAsync();

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

                // Download the public MacBeth copy at https://www.gutenberg.org/cache/epub/1533/pg1533.txt
                BlockBlobClient sourceBlob = new BlockBlobClient(new Uri("https://www.gutenberg.org/cache/epub/1533/pg1533.txt"));
                await sourceBlob.DownloadToAsync(downloadPath);

                // Create transfer manager
                BlobsStorageResourceProvider blobs = new();
                LocalFilesStorageResourceProvider files = new();
                TransferManagerOptions options = new TransferManagerOptions();
                options.ResumeProviders = new List<StorageResourceProvider>() { files, blobs };
                TransferManager transferManager = new TransferManager(options);

                // Create source and destination resource
                StorageResource sourceResource = blobs.FromClient(sourceBlob);
                StorageResource destinationResource = files.FromFile(downloadPath);

                // Create simple transfer single blob download job
                TransferOperation transferOperation = await transferManager.StartTransferAsync(
                    sourceResource: sourceResource,
                    destinationResource: destinationResource);

                // Pause from the TransferOperation object
                #region Snippet:PauseFromTransfer
                await transferOperation.PauseAsync();
                #endregion

                TransferOperation resumedTransfer = await transferManager.ResumeTransferAsync(
                    transferId: transferOperation.Id);

                // Wait for download to finish
                await resumedTransfer.WaitForCompletionAsync();
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
                            BlobDirectoryPrefix = blobDirectoryPrefix
                        },
                        TransferOptions = new TransferOptions()
                        {
                            CreationPreference = StorageResourceCreationMode.OverwriteIfExists,
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
                            BlobDirectoryPrefix = blobDirectoryPrefix
                        },
                        TransferOptions = new TransferOptions()
                        {
                            CreationPreference = StorageResourceCreationMode.OverwriteIfExists,
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
                LocalFilesStorageResourceProvider files = new();
                StorageResource sourceResource = files.FromFile(sourceLocalPath);

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

                BlobsStorageResourceProvider blobs = new();
                StorageResource destinationResource1 = blobs.FromClient(container.GetBlockBlobClient("sample-blob-1"));
                StorageResource destinationResource2 = blobs.FromClient(container.GetBlockBlobClient("sample-blob-2"));
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
