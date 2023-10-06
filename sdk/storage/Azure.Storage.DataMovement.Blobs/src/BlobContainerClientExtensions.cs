// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Data movement extension methods for the <see cref="Azure.Storage.Blobs.BlobContainerClient"/>.
    /// </summary>
    public static class BlobContainerClientExtensions
    {
        private static Lazy<TransferManager> s_defaultTransferManager = new Lazy<TransferManager>(() => new TransferManager(default));
        private static Lazy<LocalFilesStorageResourceProvider> s_filesProvider = new();
        private static Lazy<BlobsStorageResourceProvider> s_blobsProvider = new();

        /// <summary>
        /// Uploads the entire contents of local directory to the blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="localDirectoryPath">The full path to the local directory to be uploaded.</param>
        /// <param name="blobDirectoryPrefix">Optionally specifies the directory prefix to be prepended to all uploaded files.</param>
        /// <returns>A <see cref="DataTransfer"/> instance which can be used track progress and wait for completion with <see cref="DataTransfer.WaitForCompletionAsync"/>.</returns>
        public static Task<DataTransfer> StartUploadDirectoryAsync(
            this BlobContainerClient client,
            string localDirectoryPath,
            string blobDirectoryPrefix = default)
            => StartUploadDirectoryAsync(
                client,
                localDirectoryPath,
                new BlobContainerClientTransferOptions
                {
                    BlobContainerOptions = new()
                    {
                        BlobDirectoryPrefix = blobDirectoryPrefix,
                    }
                });

        /// <summary>
        /// Uploads the entire contents of local directory to the blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="localDirectoryPath">The full path to the local directory to be uploaded.</param>
        /// <param name="options">Options which control the directory upload.</param>
        /// <returns>A <see cref="DataTransfer"/> instance which can be used track progress and wait for completion with <see cref="DataTransfer.WaitForCompletionAsync"/>.</returns>
        public static async Task<DataTransfer> StartUploadDirectoryAsync(this BlobContainerClient client, string localDirectoryPath, BlobContainerClientTransferOptions options)
        {
            StorageResource localDirectory = s_filesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource blobDirectory = s_blobsProvider.Value.FromClient(client, options?.BlobContainerOptions);

            return await s_defaultTransferManager.Value.StartTransferAsync(localDirectory, blobDirectory, options?.TransferOptions).ConfigureAwait(false);
        }

        /// <summary>
        /// Downloads the contents of a blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="localDirectoryPath">The full path to the local directory where files will be dowloaded.</param>
        /// <param name="blobDirectoryPrefix">Optionally restricts the downloaded content to blobs with the specified directory prefix.</param>
        /// <returns></returns>
        public static Task<DataTransfer> StartDownloadToDirectoryAsync(
            this BlobContainerClient client,
            string localDirectoryPath,
            string blobDirectoryPrefix = default)
            => StartDownloadToDirectoryAsync(
                client,
                localDirectoryPath,
                new BlobContainerClientTransferOptions
                {
                    BlobContainerOptions = new()
                    {
                        BlobDirectoryPrefix = blobDirectoryPrefix
                    },
                });

        /// <summary>
        /// Downloads the contents of a blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="localDirectoryPath">The full path to the local directory where files will be dowloaded.</param>
        /// <param name="options">Options which control the container download.</param>
        /// <returns></returns>
        public static async Task<DataTransfer> StartDownloadToDirectoryAsync(this BlobContainerClient client, string localDirectoryPath, BlobContainerClientTransferOptions options)
        {
            StorageResource localDirectory = s_filesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource blobDirectory = s_blobsProvider.Value.FromClient(client, options?.BlobContainerOptions);

            return await s_defaultTransferManager.Value.StartTransferAsync(blobDirectory, localDirectory, options?.TransferOptions).ConfigureAwait(false);
        }
    }
}
