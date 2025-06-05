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
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Files.Shares;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Samples
{
    /// <summary>
    /// Samples for migrating from Microsoft.Azure.Storage.DataMovement
    /// to Azure.Storage.DataMovement.
    /// </summary>
    public class Sample01b_Migration : SampleTest
    {
        public Random _rand = new Random();

        public (Uri AccountUri, StorageSharedKeyCredential AccountCredential) GetSharedKeyAccessAccount()
        {
            // Get a Storage account name and shared key
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

            // Create a SharedKeyCredential that we can use to authenticate
            return (StorageAccountBlobUri, new StorageSharedKeyCredential(accountName, accountKey));
        }

        [Test]
        public async Task UploadBlob()
        {
            #region Snippet:DataMovementMigration_UploadSingleFile_VarDeclaration
            // these values provided by your code
            string filePath;
            Uri blobUri;
            BlobsStorageResourceProvider blobs;
            TransferManager transferManager;
            #endregion

            // Create a temporary Lorem Ipsum file on disk to upload
            filePath = CreateTempFile();

            // Get account and shared key access
            // (see implementation for details)
            (Uri accountUri, StorageSharedKeyCredential credential) = GetSharedKeyAccessAccount();

            // generate a container and blob name for purposes of sample
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            blobUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            }.ToUri();

            // Create the container for this sample to upload a file to
            BlobContainerClient container = new BlobServiceClient(accountUri, credential)
                .GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            try
            {
                transferManager = new TransferManager();
                blobs = new BlobsStorageResourceProvider(credential);

                #region Snippet:DataMovementMigration_UploadSingleFile
                // upload blob
                TransferOperation operation = await transferManager.StartTransferAsync(
                    LocalFilesStorageResourceProvider.FromFile(filePath),
                    await blobs.FromBlobAsync(blobUri));
                await operation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task UploadBlobDirectory()
        {
            #region Snippet:DataMovementMigration_UploadBlobDirectory_VarDeclaration
            // these values provided by your code
            string directoryPath, blobDirectoryPath;
            Uri containerUri;
            BlobsStorageResourceProvider blobs;
            TransferManager transferManager;
            #endregion

            // Create a temporary populated directory on disk to upload
            directoryPath = CreateLocalTestDirectory(3);

            // Get account and shared key access
            // (see implementation for details)
            (Uri accountUri, StorageSharedKeyCredential credential) = GetSharedKeyAccessAccount();

            // generate a container and blob name for purposes of sample
            string containerName = Randomize("sample-container");
            blobDirectoryPath = Randomize("sample-blob-dir");
            containerUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
            }.ToUri();

            // Create the container for this sample to upload a file to
            BlobContainerClient container = new BlobServiceClient(accountUri, credential)
                .GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            try
            {
                transferManager = new TransferManager();
                blobs = new BlobsStorageResourceProvider(credential);

                #region Snippet:DataMovementMigration_UploadBlobDirectory
                // upload blobs
                TransferOperation operation = await transferManager.StartTransferAsync(
                    LocalFilesStorageResourceProvider.FromDirectory(directoryPath),
                    await blobs.FromContainerAsync(containerUri, new BlobStorageResourceContainerOptions()
                    {
                        BlobPrefix = blobDirectoryPath,
                    }));
                await operation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task DownloadBlob()
        {
            #region Snippet:DataMovementMigration_DownloadBlob_VarDeclaration
            // these values provided by your code
            string filePath;
            Uri blobUri;
            BlobsStorageResourceProvider blobs;
            TransferManager transferManager;
            #endregion

            // Create a temporary populated directory on disk to upload
            filePath = CreateTempPath();

            // Get account and shared key access
            // (see implementation for details)
            (Uri accountUri, StorageSharedKeyCredential credential) = GetSharedKeyAccessAccount();

            // generate a container and blob name for purposes of sample
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            blobUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            }.ToUri();

            BlobContainerClient container = null;
            try
            {
                // Create the container & blob for this sample download
                container = new BlobServiceClient(accountUri, credential)
                    .GetBlobContainerClient(containerName);
                await container.CreateIfNotExistsAsync();
                await container.GetBlobClient(blobName)
                    .UploadAsync(BinaryData.FromString(SampleFileContent));

                transferManager = new TransferManager();
                blobs = new BlobsStorageResourceProvider(credential);

                #region Snippet:DataMovementMigration_DownloadBlob
                // download blob
                TransferOperation operation = await transferManager.StartTransferAsync(
                    await blobs.FromBlobAsync(blobUri),
                    LocalFilesStorageResourceProvider.FromFile(filePath));
                await operation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container?.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task DownloadBlobDirectory()
        {
            #region Snippet:DataMovementMigration_DownloadBlobDirectory_VarDeclaration
            // these values provided by your code
            string directoryPath, blobDirectoryPath;
            Uri containerUri;
            BlobsStorageResourceProvider blobs;
            TransferManager transferManager;
            #endregion

            // Create a temporary populated directory on disk to upload
            directoryPath = CreateLocalTestDirectory(3);

            // Get account and shared key access
            // (see implementation for details)
            (Uri accountUri, StorageSharedKeyCredential credential) = GetSharedKeyAccessAccount();

            // generate a container and blob name for purposes of sample
            string containerName = Randomize("sample-container");
            blobDirectoryPath = Randomize("sample-blob-dir");
            containerUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
            }.ToUri();

            // Create the container for this sample to upload a file to
            BlobContainerClient container = new BlobServiceClient(accountUri, credential)
                .GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            try
            {
                transferManager = new TransferManager();
                blobs = new BlobsStorageResourceProvider(credential);

                #region Snippet:DataMovementMigration_DownloadBlobDirectory
                // download blob directory
                TransferOperation operation = await transferManager.StartTransferAsync(
                    await blobs.FromContainerAsync(containerUri, new BlobStorageResourceContainerOptions()
                    {
                        BlobPrefix = blobDirectoryPath,
                    }),
                    LocalFilesStorageResourceProvider.FromDirectory(directoryPath));
                await operation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CopyBlob()
        {
            #region Snippet:DataMovementMigration_CopyBlobToBlob_VarDeclaration
            // these values provided by your code
            Uri srcBlobUri, dstBlobUri;
            BlobsStorageResourceProvider blobs;
            TransferManager transferManager;
            #endregion

            // Get account and shared key access
            // (see implementation for details)
            (Uri accountUri, StorageSharedKeyCredential credential) = GetSharedKeyAccessAccount();

            // generate a container and blob name for purposes of sample
            string containerName = Randomize("sample-container");
            string srcBlobName = Randomize("sample-blob");
            string dstBlobName = Randomize("sample-blob");
            srcBlobUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
                BlobName = srcBlobName,
            }.ToUri();
            dstBlobUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
                BlobName = dstBlobName,
            }.ToUri();

            BlobContainerClient container = null;
            try
            {
                // Create the container & blob for this sample download
                container = new BlobServiceClient(accountUri, credential)
                    .GetBlobContainerClient(containerName);
                await container.CreateIfNotExistsAsync();
                await container.GetBlobClient(srcBlobName)
                    .UploadAsync(BinaryData.FromString(SampleFileContent));

                transferManager = new TransferManager();
                blobs = new BlobsStorageResourceProvider(credential);

                #region Snippet:DataMovementMigration_CopyBlobToBlob
                // upload blob
                TransferOperation operation = await transferManager.StartTransferAsync(
                    await blobs.FromBlobAsync(srcBlobUri),
                    await blobs.FromBlobAsync(dstBlobUri));
                await operation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CopyBlobToShare()
        {
            #region Snippet:DataMovementMigration_CopyBlobToShareFile_VarDeclaration
            // these values provided by your code
            Uri blobUri, fileUri;
            BlobsStorageResourceProvider blobs;
            ShareFilesStorageResourceProvider files;
            TransferManager transferManager;
            #endregion

            // Get account and shared key access
            // (see implementation for details)
            (Uri accountUri, StorageSharedKeyCredential credential) = GetSharedKeyAccessAccount();

            // generate a container and blob name for purposes of sample
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            string filePath = $"{Randomize("sample-folder")}/{Randomize("sample-file")}";
            blobUri = new BlobUriBuilder(accountUri)
            {
                BlobContainerName = containerName,
                BlobName = blobName,
            }.ToUri();
            fileUri = new ShareUriBuilder(accountUri)
            {
                ShareName = containerName,
                DirectoryOrFilePath = filePath,
            }.ToUri();

            BlobContainerClient container = null;
            ShareClient share = null;
            try
            {
                // Create the container & blob for this sample download
                container = new BlobServiceClient(accountUri, credential)
                    .GetBlobContainerClient(containerName);
                await container.CreateIfNotExistsAsync();
                await container.GetBlobClient(blobName)
                    .UploadAsync(BinaryData.FromString(SampleFileContent));

                // create the share to copy to
                share = new ShareClient(accountUri, credential);
                await share.CreateIfNotExistsAsync();

                transferManager = new TransferManager();
                blobs = new BlobsStorageResourceProvider(credential);
                files = new ShareFilesStorageResourceProvider(credential);

                #region Snippet:DataMovementMigration_CopyBlobToShareFile
                // upload blob
                TransferOperation operation = await transferManager.StartTransferAsync(
                    await blobs.FromBlobAsync(blobUri),
                    await files.FromFileAsync(fileUri));
                await operation.WaitForCompletionAsync();
                #endregion
            }
            finally
            {
                await container?.DeleteIfExistsAsync();
                await share?.DeleteIfExistsAsync();
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

            var dirPath = Path.Combine(basePath, Randomize("sample-dir"));

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
    }
}
