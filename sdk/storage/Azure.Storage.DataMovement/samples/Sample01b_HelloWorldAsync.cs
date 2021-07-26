// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Samples
{
    /// <summary>
    /// Basic Azure Data Movement Storage samples
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Upload a file to a blob using DataMovement.
        /// </summary>
        [Test]
        public async Task UploadAsync()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            string filePath = CreateTempFile(SampleFileContent);
            string transferStatePath = CreateTempPath();
            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            try
            {
                await container.CreateAsync();

                #region Snippet:SampleSnippetsDataMovement_BlobUpload
                // Create StorageTransferManager and allocate a path to create log.
                var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
                var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
                StorageTransferManager transferManager = new StorageTransferManager(transferStatePath);

                BlobUploadOptions uploadOptions = new BlobUploadOptions()
                {
                    TransferOptions = new StorageTransferOptions()
                    {
                        MaximumConcurrency = 4
                    },
                    ProgressHandler = progressHandler
                };

                // Get a reference to a destination blob named "sample-file" in a container named "sample-container"
                BlobClient destinationBlob = container.GetBlobClient(blobName);

                // Upload local file
                await transferManager.ScheduleUploadAsync(filePath, destinationBlob, uploadOptions, CancellationToken.None);
                #endregion Snippet:SampleSnippetsDataMovement_BlobUpload

                // Verify we uploaded some content
                BlobProperties properties = await destinationBlob.GetPropertiesAsync();
                Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
            }
            finally
            {
                // Cleanup
                await container.DeleteIfExistsAsync();
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
            string transferStatePath = CreateTempPath();

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
                BlobClient sourceBlob = container.GetBlobClient(Randomize("sample-file"));

                // First upload something the blob so we have something to download
                await sourceBlob.UploadAsync(File.OpenRead(originalPath));

                #region Snippet:SampleSnippetsDataMovement_BlobDownload
                // Create StorageTransferManager and allocate a path to create log.
                var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
                var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
                StorageTransferManager transferManager = new StorageTransferManager(transferStatePath);

                StorageTransferOptions transferOptions = new StorageTransferOptions()
                {
                    MaximumConcurrency = 4
                };

                // Upload local file
                await transferManager.ScheduleDownloadAsync(sourceBlob, downloadPath, transferOptions, CancellationToken.None);
                #endregion Snippet:SampleSnippetsDataMovement_BlobDownload

                // Download the blob's contents and save it to a file
                await sourceBlob.DownloadToAsync(downloadPath);

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
        /// Upload a local directory to a blob directory using Data Movement.
        /// </summary>
        [Test]
        public async Task UploadDirectoryAsync()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");
            string blobDirectoryPath = Randomize("sample-directory-path");
            string sourceDirectoryPath = CreateTempPath();
            string transferStatePath = CreateTempPath();
            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            try
            {
                await container.CreateAsync();

                #region Snippet:SampleSnippetsDataMovement_BlobUpload
                // Create StorageTransferManager and allocate a path to create log.
                var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
                var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
                StorageTransferManager transferManager = new StorageTransferManager(transferStatePath);

                BlobDirectoryUploadOptions uploadOptions = new BlobDirectoryUploadOptions()
                {
                    TransferOptions = new StorageTransferOptions()
                    {
                        MaximumConcurrency = 4
                    },
                    ProgressHandler = progressHandler
                };

                // Get a reference to a destination blob named "sample-file" in a container named "sample-container"
                BlobDirectoryClient destinationBlob = new BlobDirectoryClient(connectionString, containerName, blobDirectoryPath);

                // Upload local file
                await transferManager.ScheduleUploadDirectoryAsync(sourceDirectoryPath, destinationBlob, uploadOptions, CancellationToken.None);
                #endregion Snippet:SampleSnippetsDataMovement_BlobUpload

                // TODO: Assert / verification
            }
            finally
            {
                // Cleanup
                await container.DeleteIfExistsAsync();
            }
        }

        /// <summary>
        /// Download blob directory to a local directory using DataMovement.
        /// </summary>
        [Test]
        public async Task DownloadDirectoryAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);
            string transferStatePath = CreateTempPath();
            string containerName = Randomize("sample-container");
            string blobDirectoryPath = "sample-directory";
            string blobName = Randomize("sample-blob");

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateAsync();
            try
            {
                // Get a reference to a destination blob directory named "sample-directory" in a container named "sample-container"
                BlobDirectoryClient sourcedirectoryClient = new BlobDirectoryClient(connectionString, containerName, blobDirectoryPath);

                // Get a reference to a blob named "sample-file"
                BlobClient blob = container.GetBlobClient(blobDirectoryPath + "/" + blobName);

                // First upload something the blob so we have something to download and the virtual directory is created
                await blob.UploadAsync(File.OpenRead(originalPath));

                #region Snippet:SampleSnippetsDataMovement_BlobDownloadDirectory
                // Create StorageTransferManager and allocate a path to create log.
                var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
                var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
                StorageTransferManager transferManager = new StorageTransferManager(transferStatePath);

                BlobDirectoryDownloadOptions downloadOptions = new BlobDirectoryDownloadOptions()
                {
                    transferOptions = new StorageTransferOptions()
                    {
                        MaximumConcurrency = 4
                    },
                    ProgressHandler = progressHandler
                };

                // Upload local file
                await transferManager.ScheduleDownloadDirectoryAsync(sourcedirectoryClient, downloadPath, downloadOptions, CancellationToken.None);
                #endregion Snippet:SampleSnippetsDataMovement_BlobDownloadDirectory

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
        /// Copy a source blob directory to destination blob directory.
        /// </summary>
        [Test]
        public async Task CopyDirectoryAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);
            string transferStatePath = CreateTempPath();
            string containerName = Randomize("sample-container");
            string sourceDirectoryPath = "source-directory";
            string destinationDirectoryPath = "destination-directory";
            string blobName = Randomize("sample-blob");

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            await container.CreateAsync();
            try
            {
                // Get a reference to a source blob directory named "source-directory" in a container named "sample-container"
                BlobDirectoryClient sourceDirectoryClient = new BlobDirectoryClient(connectionString, containerName, sourceDirectoryPath);

                // Get a reference to a blob named "sample-file"
                BlobClient blob = container.GetBlobClient(sourceDirectoryPath + "/" + blobName);

                // First upload something the blob so we have something to download and the virtual directory is created
                await blob.UploadAsync(File.OpenRead(originalPath));

                BlobDirectoryClient destinationDirectoryClient = new BlobDirectoryClient(connectionString, containerName, destinationDirectoryPath);

                #region Snippet:SampleSnippetsDataMovement_BlobCopyDirectory
                // Create StorageTransferManager and allocate a path to create log.
                var progressBag = new System.Collections.Concurrent.ConcurrentBag<BlobCopyInfo>();
                var progressHandler = new Progress<Response<BlobCopyInfo>>(progress => progressBag.Add(progress));
                StorageTransferManager transferManager = new StorageTransferManager(transferStatePath);

                BlobDirectoryCopyFromUriOptions copyOptions = new BlobDirectoryCopyFromUriOptions()
                {
                    ProgressHandler = progressHandler
                };

                // Upload local file
                // TODO: renable when Copy API is made
                // await transferManager.ScheduleServiceCopyJob(sourceDirectoryClient, destinationDirectoryPath, copyOptions, CancellationToken.None);
                #endregion Snippet:SampleSnippetsDataMovement_BlobCopyDirectory

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
    }
}
