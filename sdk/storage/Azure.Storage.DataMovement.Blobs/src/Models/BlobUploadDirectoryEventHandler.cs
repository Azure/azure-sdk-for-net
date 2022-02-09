// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Contains the progress and results for the ongoing transfers
    /// </summary>
    public class BlobUploadDirectoryEventHandler
    {
        /// <summary>
        /// Number of files/blobs transferred succesfully
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadTransferSuccessEventArgs> FilesTransferred;
        internal SyncAsyncEventHandler<BlobUploadTransferSuccessEventArgs> GetFilesTransferred() => FilesTransferred;

        /// <summary>
        /// Number of directories transferred
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadDirectoryTransferSuccessEventArgs> DirectoriesTransferred;
        internal SyncAsyncEventHandler<BlobUploadDirectoryTransferSuccessEventArgs> GetDirectoriesTransferred() => DirectoriesTransferred;

        /// <summary>
        /// Number of Files Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadTransferFailedEventArgs> FilesFailedTransferred;

        internal SyncAsyncEventHandler<BlobUploadTransferFailedEventArgs> GetTransferFailedHandlers() => FilesFailedTransferred;

        /// <summary>
        /// Number of Files Skipped during Transfer due to no overwrite allowed as specified.
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadTransferSkippedEventArgs> FilesSkippedTransferred;

        internal SyncAsyncEventHandler<BlobUploadTransferSkippedEventArgs> GetFilesSkippedHandlers() => FilesSkippedTransferred;

        /// <summary>
        /// Number of directories skipped transfer. Due to inaccessability not sure if we should keep track if a few files in a folder are unable to transfer
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadDirectoryTransferFailedEventArgs> DirectoriesFailed;
        internal SyncAsyncEventHandler<BlobUploadDirectoryTransferFailedEventArgs> GetDirectoriesFailed() => DirectoriesFailed;
    }
}
