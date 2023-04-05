// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Data movement extension methods for the <see cref="Azure.Storage.Blobs.BlobContainerClient"/>.
    /// </summary>
    public static class BlobContainerClientExtensions
    {
        private static Lazy<TransferManager> s_defaultTransferManager = new Lazy<TransferManager>();

        //public static async Task<DataTransfer> StartUploadDirectoryAsync(this BlobContainerClient client, string localDirectoryPath, string blobDirectoryPrefix = default) => await StartUploadDirectoryAsync(client, localDirectoryPath, blobDirectoryPrefix, default).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        /// <param name="localDirectoryPath"></param>
        /// <param name="blobDirectoryPrefix"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<DataTransfer> StartUploadDirectoryAsync(this BlobContainerClient client, string localDirectoryPath, string blobDirectoryPrefix = default, BlobContainerClientTransferOptions options = default)
        {
            StorageResourceContainer localDirectory = new LocalDirectoryStorageResourceContainer(localDirectoryPath);

            StorageResourceContainer blobDirectory = new BlobDirectoryStorageResourceContainer(client, blobDirectoryPrefix, options?.BlobContainerOptions);

            return await s_defaultTransferManager.Value.StartTransferAsync(localDirectory, blobDirectory, options?.TransferOptions).ConfigureAwait(false);
        }

        //public static async Task<DataTransfer> StartDownloadDirectoryAsync(this BlobContainerClient client, string localDirectoryPath, string blobDirectoryPrefix = default) => await StartDownloadDirectoryAsync(client, localDirectoryPath, blobDirectoryPrefix, default).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        /// <param name="localDirectoryPath"></param>
        /// <param name="blobDirectoryPrefix"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<DataTransfer> StartDownloadDirectoryAsync(this BlobContainerClient client, string localDirectoryPath, string blobDirectoryPrefix = default, BlobContainerClientTransferOptions options = default)
        {
            StorageResourceContainer localDirectory = new LocalDirectoryStorageResourceContainer(localDirectoryPath);

            StorageResourceContainer blobDirectory = new BlobDirectoryStorageResourceContainer(client, blobDirectoryPrefix, options?.BlobContainerOptions);

            return await s_defaultTransferManager.Value.StartTransferAsync(blobDirectory, localDirectory, options?.TransferOptions).ConfigureAwait(false);
        }
    }
}
