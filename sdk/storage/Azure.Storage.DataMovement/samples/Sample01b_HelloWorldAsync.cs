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
using System.Threading;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System.Collections.Generic;
using System.Linq;

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

                // Create the transfer manager
                #region Snippet:CreateTransferManagerSimple_BasePackage
                TransferManager transferManager = new TransferManager(new TransferManagerOptions());
                #endregion

                // Create simple transfer single blob upload job
                #region Snippet:SimpleBlobUpload_BasePackage
                LocalFilesStorageResourceProvider files = new();
                BlobsStorageResourceProvider blobs = new(tokenCredential);
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    files.FromFile("C:/path/to/file.txt"),
                    blobs.FromBlob("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
                    cancellationToken: cancellationToken);
                await dataTransfer.WaitForCompletionAsync(cancellationToken);
                #endregion

                await TransferAsync(
                    new LocalFileStorageResource(sourceLocalPath),
                    new BlockBlobStorageResource(destinationBlob));
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
                StorageResource sourceResource = new LocalFileStorageResource(sourceLocalPath);

                // Get a reference to a destination blob
                TransferManager transferManager = new TransferManager();

                string logFile = CreateTempPath();

                #region Snippet:EnumerateTransfers
                async Task CheckTransfersAsync(TransferManager transferManager)
                {
                    await foreach (DataTransfer transfer in transferManager.GetTransfersAsync())
                    {
                        using StreamWriter logStream = File.AppendText(logFile);
                        logStream.WriteLine(Enum.GetName(typeof(StorageTransferStatus), transfer.TransferStatus));
                    }
                }
                #endregion

                #region Snippet:ListenToTransferEvents
                async Task<DataTransfer> ListenToTransfersAsync(TransferManager transferManager,
                    StorageResource source, StorageResource destination)
                {
                    TransferOptions transferOptions = new();
                    transferOptions.SingleTransferCompleted += (SingleTransferCompletedEventArgs args) =>
                    {
                        using StreamWriter logStream = File.AppendText(logFile);
                        logStream.WriteLine($"File Completed Transfer: {args.SourceResource.Path}");
                        return Task.CompletedTask;
                    };
                    return await transferManager.StartTransferAsync(
                        source,
                        destination,
                        transferOptions);
                }
                #endregion

                #region Snippet:ListenToProgress
                async Task<DataTransfer> ListenToProgressAsync(TransferManager transferManager, IProgress<StorageTransferProgress> progress,
                    StorageResource source, StorageResource destination)
                {
                    TransferOptions transferOptions = new()
                    {
                        ProgressHandler = progress,
                        // optionally include the below if progress updates on bytes transferred are desired
                        ProgressHandlerOptions = new()
                        {
                            TrackBytesTransferred = true
                        }
                    };
                    return await transferManager.StartTransferAsync(
                        source,
                        destination,
                        transferOptions);
                }
                #endregion

                StorageResource destinationResource1 = new BlockBlobStorageResource(container.GetBlockBlobClient("sample-blob-1"));
                StorageResource destinationResource2 = new BlockBlobStorageResource(container.GetBlockBlobClient("sample-blob-2"));
                DataTransfer t1 = await ListenToTransfersAsync(transferManager, sourceResource, destinationResource1);
                DataTransfer t2 = await ListenToProgressAsync(transferManager, new Progress<StorageTransferProgress>(p => {}), sourceResource, destinationResource2);
                await CheckTransfersAsync(transferManager);
                await t1.WaitForCompletionAsync();
                await t2.WaitForCompletionAsync();
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task PauseTransferAsync()
        {
            string sourceLocalPath = CreateTempFile(SampleFileContent);
            BlobContainerClient container = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            await container.CreateIfNotExistsAsync();

            try
            {
                StorageResource sourceResource = new LocalFileStorageResource(sourceLocalPath);
                StorageResource destinationResource = new BlockBlobStorageResource(container.GetBlockBlobClient("sample-blob"));

                // Get a reference to a destination blob
                TransferManager transferManager = new TransferManager();
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource, destinationResource);

                CancellationToken cancellationToken = CancellationToken.None;
                #region Snippet:PauseFromTransfer
                await dataTransfer.PauseIfRunningAsync(cancellationToken);
                #endregion

                string transferId = dataTransfer.Id;
                #region Snippet:PauseFromManager
                await transferManager.PauseTransferIfRunningAsync(transferId, cancellationToken);
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task ResumeTransferAsync()
        {
            string sourceLocalPath = CreateTempFile(SampleFileContent);
            BlobContainerClient container = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            await container.CreateIfNotExistsAsync();

            try
            {
                StorageResource sourceResource = new LocalFileStorageResource(sourceLocalPath);
                StorageResource destinationResource = new BlockBlobStorageResource(container.GetBlockBlobClient("sample-blob"));

                StorageSharedKeyCredential credential = new(StorageAccountName, StorageAccountKey);
                async Task<(StorageResource Source, StorageResource Destination)> MakeResourcesAsync(DataTransferProperties info)
                {
                    StorageResource sourceResource = null, destinationResource = null;
                    // ask DataMovement.Blobs if it can recreate source or destination resources to Blob Storage
                    if (BlobStorageResources.TryGetResourceProviders(
                        info,
                        out BlobStorageResourceProvider blobSrcProvider,
                        out BlobStorageResourceProvider blobDstProvider))
                    {
                        sourceResource ??= await blobSrcProvider?.MakeResourceAsync(credential);
                        destinationResource ??= await blobSrcProvider?.MakeResourceAsync(credential);
                    }
                    // ask DataMovement if it can recreate source or destination resources to local storage
                    if (LocalStorageResources.TryGetResourceProviders(
                        info,
                        out LocalStorageResourceProvider localSrcProvider,
                        out LocalStorageResourceProvider localDstProvider))
                    {
                        sourceResource ??= localSrcProvider?.MakeResource();
                        destinationResource ??= localDstProvider?.MakeResource();
                    }
                    return (sourceResource, destinationResource);
                }

                // Get a reference to a destination blob
                TransferManager transferManager = new TransferManager();
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource, destinationResource);

                List<DataTransfer> resumedTransfers = new();
                await foreach (DataTransferProperties transferProperties in transferManager.GetResumableTransfersAsync())
                {
                    (StorageResource resumeSource, StorageResource resumeDestination) = await MakeResourcesAsync(transferProperties);
                    resumedTransfers.Add(await transferManager.ResumeTransferAsync(transferProperties.TransferId, resumeSource, resumeDestination));
                }

                await Task.WhenAll(resumedTransfers.Select(transfer => transfer.WaitForCompletionAsync()));
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task HandleFailedTransfer()
        {
            string sourceLocalPath = CreateTempFile(SampleFileContent);
            BlobContainerClient container = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            await container.CreateIfNotExistsAsync();
            string logFile = CreateTempPath();

            try
            {
                StorageResource sourceResource = new LocalFileStorageResource(sourceLocalPath);
                StorageResource destinationResource = new BlockBlobStorageResource(container.GetBlockBlobClient("sample-blob"));

                TransferOptions transferOptions = new();
                #region Snippet:LogIndividualTransferFailures
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

                TransferManager transferManager = new TransferManager();
                DataTransfer dataTransfer = await transferManager.StartTransferAsync(
                    sourceResource, destinationResource);

                #region Snippet:LogTotalTransferFailure
                await dataTransfer.WaitForCompletionAsync();
                if (dataTransfer.TransferStatus == StorageTransferStatus.CompletedWithFailedTransfers)
                {
                    using (StreamWriter logStream = File.AppendText(logFile))
                    {
                        logStream.WriteLine($"Failure for TransferId: {dataTransfer.Id}");
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
