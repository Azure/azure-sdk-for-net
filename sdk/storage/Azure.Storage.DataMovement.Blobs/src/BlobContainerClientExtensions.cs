// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Data movement extension methods for the <see cref="BlobContainerClient"/>.
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
        /// <param name="waitUntil">Indicates whether this invocation should wait until the transfer is complete to return or return immediately.</param>
        /// <param name="localDirectoryPath">The full path to the local directory to be uploaded.</param>
        /// <param name="blobDirectoryPrefix">Optionally specifies the directory prefix to be prepended to all uploaded files.</param>
        /// <returns>A <see cref="TransferOperation"/> instance which can be used track progress and wait for completion with <see cref="TransferOperation.WaitForCompletionAsync"/>.</returns>
        public static Task<TransferOperation> UploadDirectoryAsync(
            this BlobContainerClient client,
            WaitUntil waitUntil,
            string localDirectoryPath,
            string blobDirectoryPrefix = default)
            => UploadDirectoryAsync(
                client,
                waitUntil,
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
        /// <param name="waitUntil">Indicates whether this invocation should wait until the transfer is complete to return or return immediately.</param>
        /// <param name="localDirectoryPath">The full path to the local directory to be uploaded.</param>
        /// <param name="options">Options which control the directory upload.</param>
        /// <returns>A <see cref="TransferOperation"/> instance which can be used track progress and wait for completion with <see cref="TransferOperation.WaitForCompletionAsync"/>.</returns>
        public static async Task<TransferOperation> UploadDirectoryAsync(this BlobContainerClient client, WaitUntil waitUntil, string localDirectoryPath, BlobContainerClientTransferOptions options)
        {
            StorageResource localDirectory = s_filesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource blobDirectory = s_blobsProvider.Value.FromClient(client, options?.BlobContainerOptions);

            TransferOperation transfer = await s_defaultTransferManager.Value.StartTransferAsync(
                localDirectory,
                blobDirectory,
                options?.TransferOptions).ConfigureAwait(false);
            if (waitUntil == WaitUntil.Completed)
            {
                await transfer.WaitForCompletionAsync().ConfigureAwait(false);
            }

            return transfer;
        }

        /// <summary>
        /// Downloads the contents of a blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="waitUntil">Indicates whether this invocation should wait until the transfer is complete to return or return immediately.</param>
        /// <param name="localDirectoryPath">The full path to the local directory where files will be dowloaded.</param>
        /// <param name="blobDirectoryPrefix">Optionally restricts the downloaded content to blobs with the specified directory prefix.</param>
        /// <returns></returns>
        public static Task<TransferOperation> DownloadToDirectoryAsync(
            this BlobContainerClient client,
            WaitUntil waitUntil,
            string localDirectoryPath,
            string blobDirectoryPrefix = default)
            => DownloadToDirectoryAsync(
                client,
                waitUntil,
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
        /// <param name="waitUntil">Indicates whether this invocation should wait until the transfer is complete to return or return immediately.</param>
        /// <param name="localDirectoryPath">The full path to the local directory where files will be dowloaded.</param>
        /// <param name="options">Options which control the container download.</param>
        /// <returns></returns>
        public static async Task<TransferOperation> DownloadToDirectoryAsync(this BlobContainerClient client, WaitUntil waitUntil, string localDirectoryPath, BlobContainerClientTransferOptions options)
        {
            StorageResource localDirectory = s_filesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource blobDirectory = s_blobsProvider.Value.FromClient(client, options?.BlobContainerOptions);

            TransferOperation transfer = await s_defaultTransferManager.Value.StartTransferAsync(
                blobDirectory,
                localDirectory,
                options?.TransferOptions).ConfigureAwait(false);
            if (waitUntil == WaitUntil.Completed)
            {
                await transfer.WaitForCompletionAsync().ConfigureAwait(false);
            }

            return transfer;
        }
    }
}
