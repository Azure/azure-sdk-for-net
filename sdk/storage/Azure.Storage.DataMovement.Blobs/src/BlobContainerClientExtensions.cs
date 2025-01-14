// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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
        /// <param name="cancellationToken">
        /// Cancels starting the operation or if <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>,
        /// cancels waiting for the operation. Cancelling this token does not cancel the operation itself.
        /// </param>
        /// <returns>
        /// A <see cref="TransferOperation"/> instance which contains information about the transfer and its status.
        /// </returns>
        /// <remarks>
        /// This is an async long-running operation which means the operation may not be complete when this methods returns. If <paramref name="waitUntil"/>
        /// is set to <see cref="WaitUntil.Started"/>, the method will return as soon as a transfer is started and <see cref="TransferOperation.WaitForCompletionAsync"/>
        /// can be used to wait for the transfer to complete. If <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>, the method will wait
        /// for the entire transfer to complete.
        /// In either case, the caller must check the status of the transfer using the returned <see cref="TransferOperation"/> instance to determine if the transfer
        /// completed successfully or not. This method will not throw an exception if the transfer fails, but the <see cref="TransferOperation.Status"/> will indicate a failure.
        /// </remarks>
        public static Task<TransferOperation> UploadDirectoryAsync(
            this BlobContainerClient client,
            WaitUntil waitUntil,
            string localDirectoryPath,
            string blobDirectoryPrefix = default,
            CancellationToken cancellationToken = default)
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
                },
                cancellationToken);

        /// <summary>
        /// Uploads the entire contents of local directory to the blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="waitUntil">Indicates whether this invocation should wait until the transfer is complete to return or return immediately.</param>
        /// <param name="localDirectoryPath">The full path to the local directory to be uploaded.</param>
        /// <param name="options">Options which control the directory upload.</param>
        /// <param name="cancellationToken">
        /// Cancels starting the operation or if <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>,
        /// cancels waiting for the operation. Cancelling this token does not cancel the operation itself.
        /// </param>
        /// <returns>
        /// A <see cref="TransferOperation"/> instance which contains information about the transfer and its status.
        /// </returns>
        /// <remarks>
        /// This is an async long-running operation which means the operation may not be complete when this methods returns. If <paramref name="waitUntil"/>
        /// is set to <see cref="WaitUntil.Started"/>, the method will return as soon as a transfer is started and <see cref="TransferOperation.WaitForCompletionAsync"/>
        /// can be used to wait for the transfer to complete. If <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>, the method will wait
        /// for the entire transfer to complete.
        /// In either case, the caller must check the status of the transfer using the returned <see cref="TransferOperation"/> instance to determine if the transfer
        /// completed successfully or not. This method will not throw an exception if the transfer fails, but the <see cref="TransferOperation.Status"/> will indicate a failure.
        /// </remarks>
        public static async Task<TransferOperation> UploadDirectoryAsync(
            this BlobContainerClient client,
            WaitUntil waitUntil,
            string localDirectoryPath,
            BlobContainerClientTransferOptions options,
            CancellationToken cancellationToken = default)
        {
            StorageResource localDirectory = s_filesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource blobDirectory = s_blobsProvider.Value.FromClient(client, options?.BlobContainerOptions);

            TransferOperation transfer = await s_defaultTransferManager.Value.StartTransferAsync(
                localDirectory,
                blobDirectory,
                options?.TransferOptions,
                cancellationToken).ConfigureAwait(false);

            if (waitUntil == WaitUntil.Completed)
            {
                await transfer.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">
        /// Cancels starting the operation or if <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>,
        /// cancels waiting for the operation. Cancelling this token does not cancel the operation itself.
        /// </param>
        /// <returns>
        /// A <see cref="TransferOperation"/> instance which contains information about the transfer and its status.
        /// </returns>
        /// <remarks>
        /// This is an async long-running operation which means the operation may not be complete when this methods returns. If <paramref name="waitUntil"/>
        /// is set to <see cref="WaitUntil.Started"/>, the method will return as soon as a transfer is started and <see cref="TransferOperation.WaitForCompletionAsync"/>
        /// can be used to wait for the transfer to complete. If <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>, the method will wait
        /// for the entire transfer to complete.
        /// In either case, the caller must check the status of the transfer using the returned <see cref="TransferOperation"/> instance to determine if the transfer
        /// completed successfully or not. This method will not throw an exception if the transfer fails, but the <see cref="TransferOperation.Status"/> will indicate a failure.
        /// </remarks>
        public static Task<TransferOperation> DownloadToDirectoryAsync(
            this BlobContainerClient client,
            WaitUntil waitUntil,
            string localDirectoryPath,
            string blobDirectoryPrefix = default,
            CancellationToken cancellationToken = default)
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
                },
                cancellationToken);

        /// <summary>
        /// Downloads the contents of a blob container.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/> used for service operations.</param>
        /// <param name="waitUntil">Indicates whether this invocation should wait until the transfer is complete to return or return immediately.</param>
        /// <param name="localDirectoryPath">The full path to the local directory where files will be dowloaded.</param>
        /// <param name="options">Options which control the container download.</param>
        /// <param name="cancellationToken">
        /// Cancels starting the operation or if <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>,
        /// cancels waiting for the operation. Cancelling this token does not cancel the operation itself.
        /// </param>
        /// <returns>
        /// A <see cref="TransferOperation"/> instance which contains information about the transfer and its status.
        /// </returns>
        /// <remarks>
        /// This is an async long-running operation which means the operation may not be complete when this methods returns. If <paramref name="waitUntil"/>
        /// is set to <see cref="WaitUntil.Started"/>, the method will return as soon as a transfer is started and <see cref="TransferOperation.WaitForCompletionAsync"/>
        /// can be used to wait for the transfer to complete. If <paramref name="waitUntil"/> is set to <see cref="WaitUntil.Completed"/>, the method will wait
        /// for the entire transfer to complete.
        /// In either case, the caller must check the status of the transfer using the returned <see cref="TransferOperation"/> instance to determine if the transfer
        /// completed successfully or not. This method will not throw an exception if the transfer fails, but the <see cref="TransferOperation.Status"/> will indicate a failure.
        /// </remarks>
        public static async Task<TransferOperation> DownloadToDirectoryAsync(
            this BlobContainerClient client,
            WaitUntil waitUntil,
            string localDirectoryPath,
            BlobContainerClientTransferOptions options,
            CancellationToken cancellationToken = default)
        {
            StorageResource localDirectory = s_filesProvider.Value.FromDirectory(localDirectoryPath);
            StorageResource blobDirectory = s_blobsProvider.Value.FromClient(client, options?.BlobContainerOptions);

            TransferOperation transfer = await s_defaultTransferManager.Value.StartTransferAsync(
                blobDirectory,
                localDirectory,
                options?.TransferOptions,
                cancellationToken).ConfigureAwait(false);

            if (waitUntil == WaitUntil.Completed)
            {
                await transfer.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }

            return transfer;
        }
    }
}
