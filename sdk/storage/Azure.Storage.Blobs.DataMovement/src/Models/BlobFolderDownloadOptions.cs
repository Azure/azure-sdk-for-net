// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Core;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Optional parameters for downloading to a Blob Directory.
    /// </summary>
    public class BlobFolderDownloadOptions
    {
        /// <summary>
        /// Optional <see cref="IProgress{BlobDownloadDirectoryProgress}"/> to provide
        /// progress updates about data transfers.
        /// TODO: replace long value with appropriate model similar to BlobUploadDirectoryResponse
        /// </summary>
        public IProgress<BlobFolderDownloadProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Transactional hashing options for data integrity checks.
        /// </summary>
        ///public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }

        /// <summary>
        /// Optional <see cref="DownloadOverwriteMethod"/> to configure overwrite
        /// behavior. Will default to <see cref="DownloadOverwriteMethod.Overwrite"/>.
        /// </summary>
        public DownloadOverwriteMethod OverwriteOptions { get; set; }

        /// <summary>
        /// If a blob gets transferred successfully the event will get added to this handler
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadCompletedEventArgs> DownloadCompletedEventHandler;
        internal SyncAsyncEventHandler<BlobDownloadCompletedEventArgs> GetDownloadCompleted() => DownloadCompletedEventHandler;

        /// <summary>
        /// Number of directories transferred
        /// </summary>
        public event SyncAsyncEventHandler<BlobFolderDownloadTransferSuccessEventArgs> FolderCompletedEventHandler;
        internal SyncAsyncEventHandler<BlobFolderDownloadTransferSuccessEventArgs> GetFolderCompleted() => FolderCompletedEventHandler;

        /// <summary>
        /// Number of Files Skipped during Transfer due to no overwrite allowed as specified.
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadSkippedEventArgs> DownloadSkippedEventHandler;

        internal SyncAsyncEventHandler<BlobUploadSkippedEventArgs> GetDownloadSkipped() => DownloadSkippedEventHandler;

        /// <summary>
        /// Number of blobs Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadFailedEventArgs> DownloadFailedEventHandler;

        internal SyncAsyncEventHandler<BlobDownloadFailedEventArgs> GetDownloadFailed() => DownloadFailedEventHandler;

        /// <summary>
        /// Number of directories skipped transfer. Due to inaccessability not sure if we should keep track if a few blobs in a folder are unable to transfer
        /// </summary>
        public event SyncAsyncEventHandler<BlobFolderDownloadTransferFailedEventArgs> FolderFailedEventHandler;
        internal SyncAsyncEventHandler<BlobFolderDownloadTransferFailedEventArgs> GetFolderFailed() => FolderFailedEventHandler;

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<StorageTransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<StorageTransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;
    }
}
