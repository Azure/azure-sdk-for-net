// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Files.Shares;

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// Data movement extension methods for the <see cref="ShareDirectoryClient"/>.
    /// </summary>
    public static class ShareDirectoryClientExtensions
    {
        private static Lazy<TransferManager> s_defaultTransferManager = new(() => new TransferManager(default));
        private static Lazy<LocalFilesStorageResourceProvider> s_localFilesProvider = new();
        private static Lazy<ShareFilesStorageResourceProvider> s_shareFilesProvider = new();

        /// <summary>
        /// Uploads the entire contents of local directory to the share directory.
        /// </summary>
        /// <param name="client">
        /// The <see cref="ShareDirectoryClient"/> used for service operations.
        /// </param>
        /// <param name="localDirectoryPath">
        /// The full path to the local directory to be uploaded.
        /// </param>
        /// <param name="options">
        /// Options which control the directory upload.
        /// </param>
        /// <returns>
        /// A <see cref="DataTransfer"/> instance which can be used track progress and wait for
        /// completion with <see cref="DataTransfer.WaitForCompletionAsync"/>.
        /// </returns>
        public static async Task<DataTransfer> StartUploadDirectoryAsync(
            this ShareDirectoryClient client,
            string localDirectoryPath,
            ShareDirectoryClientTransferOptions options = default)
        {
            StorageResource localDirectory = s_localFilesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource shareDirectory = s_shareFilesProvider.Value.FromClient(client, options?.ShareDirectoryOptions);

            return await s_defaultTransferManager.Value.StartTransferAsync(
                localDirectory, shareDirectory, options?.TransferOptions).ConfigureAwait(false);
        }

        /// <summary>
        /// Downloads the contents of a share directory.
        /// </summary>
        /// <param name="client">The <see cref="ShareDirectoryClient"/> used for service operations.</param>
        /// <param name="localDirectoryPath">The full path to the local directory where files will be dowloaded.</param>
        /// <param name="options">Options which control the container download.</param>
        /// <returns></returns>
        public static async Task<DataTransfer> StartDownloadToDirectoryAsync(
            this ShareDirectoryClient client,
            string localDirectoryPath,
            ShareDirectoryClientTransferOptions options = default)
        {
            StorageResource localDirectory = s_localFilesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource shareDirectory = s_shareFilesProvider.Value.FromClient(client, options?.ShareDirectoryOptions);

            return await s_defaultTransferManager.Value.StartTransferAsync(
                shareDirectory, localDirectory, options?.TransferOptions).ConfigureAwait(false);
        }
    }
}
