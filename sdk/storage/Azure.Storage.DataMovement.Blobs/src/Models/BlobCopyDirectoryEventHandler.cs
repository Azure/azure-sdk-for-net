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
    public class BlobCopyDirectoryEventHandler
    {
        /// <summary>
        /// Number of files/blobs transferred succesfully
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopyTransferSuccessEventArgs> FilesTransferred;
        internal SyncAsyncEventHandler<BlobCopyTransferSuccessEventArgs> GetFilesTransferred() => FilesTransferred;

        /// <summary>
        /// Number of directories transferred
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopyDirectoryTransferSuccessEventArgs> DirectoriesTransferred;
        internal SyncAsyncEventHandler<BlobCopyDirectoryTransferSuccessEventArgs> GetDirectoriesTransferred() => DirectoriesTransferred;

        /// <summary>
        /// Number of Files Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopyTransferFailedEventArgs> FilesFailedTransferred;

        internal SyncAsyncEventHandler<BlobCopyTransferFailedEventArgs> GetFilesFailed() => FilesFailedTransferred;

        /// <summary>
        /// Number of directories skipped transfer. Due to inaccessability not sure if we should keep track if a few files in a folder are unable to transfer
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopyDirectoryTransferFailedEventArgs> DirectoriesFailed;
        internal SyncAsyncEventHandler<BlobCopyDirectoryTransferFailedEventArgs> GetDirectoriesFailed() => DirectoriesFailed;
    }
}
