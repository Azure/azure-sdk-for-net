// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Blob Virtual Directory.
    /// </summary>
    public class BlobFolderUploadOptions
    {
        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on each blob uploaded.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Progress Handler
        /// </summary>
        public IProgress<BlobFolderUploadProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public BlobImmutabilityPolicy ImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional for using transactional
        /// hashing on uploads.
        /// </summary>
        ///public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }

        /// <summary>
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Number of files/blobs transferred succesfully
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadSuccessEventArgs> UploadCompletedEventHandler;
        internal SyncAsyncEventHandler<BlobUploadSuccessEventArgs> GetUploadCompleted() => UploadCompletedEventHandler;

        /// <summary>
        /// Number of directories transferred
        /// </summary>
        public event SyncAsyncEventHandler<BlobFolderUploadSuccessEventArgs> FolderCompletedEventHandler;
        internal SyncAsyncEventHandler<BlobFolderUploadSuccessEventArgs> GetFolderCompleted() => FolderCompletedEventHandler;

        /// <summary>
        /// Number of Files Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadFailedEventArgs> UploadFailedEventHandler;

        internal SyncAsyncEventHandler<BlobUploadFailedEventArgs> GetUploadFailed() => UploadFailedEventHandler;

        /// <summary>
        /// Number of Files Skipped during Transfer due to no overwrite allowed as specified.
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadSkippedEventArgs> UploadSkippedEventHandler;

        internal SyncAsyncEventHandler<BlobUploadSkippedEventArgs> GetUploadSkipped() => UploadSkippedEventHandler;

        /// <summary>
        /// Number of directories skipped transfer. Due to inaccessability not sure if we should keep track if a few files in a folder are unable to transfer
        /// </summary>
        public event SyncAsyncEventHandler<BlobFolderUploadFailedEventArgs> FolderFailedEventHandler;
        internal SyncAsyncEventHandler<BlobFolderUploadFailedEventArgs> GetFolderFailed() => FolderFailedEventHandler;

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<StorageTransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<StorageTransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;
    }
}
