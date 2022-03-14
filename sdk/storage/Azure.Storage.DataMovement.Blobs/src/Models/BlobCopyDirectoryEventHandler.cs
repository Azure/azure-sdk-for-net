// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Contains the progress and results for the ongoing transfers.
    /// </summary>
    public class BlobCopyDirectoryEventHandler
    {
        /// <summary>
        /// If a blob gets transferred successfully the event will get added to this handler
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopySingleTransferSuccessEventArgs> BlobTransferred;
        internal SyncAsyncEventHandler<BlobCopySingleTransferSuccessEventArgs> GetBlobTransferred() => BlobTransferred;

        /// <summary>
        /// If a directory gets transferred successfully the event will get added to this handler.
        /// When all blobs are transferred in the respective directory an event argument will be added to this event handler.
        ///
        /// Empty directories cannot be transferred because empty directories do not exist in a flat namespace, therfore will not be included in this count
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopyDirectoryTransferSuccessEventArgs> DirectoriesTransferred;
        internal SyncAsyncEventHandler<BlobCopyDirectoryTransferSuccessEventArgs> GetDirectoriesTransferred() => DirectoriesTransferred;

        /// <summary>
        /// If a blob transfer fails, the event will get added to this handler
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopySingleTransferFailedEventArgs> BlobFailed;

        internal SyncAsyncEventHandler<BlobCopySingleTransferFailedEventArgs> GetBlobFailed() => BlobFailed;

        /// <summary>
        /// If a directory transfer fails, the event will get added to this handler.
        /// This is due to either due to access one of any blobs in the directory or to transfer all the blobs in the directory.
        ///
        /// Empty directories cannot be transferred because empty directories do not exist in a flat namespace, therefore will not be included in this count
        /// </summary>
        public event SyncAsyncEventHandler<BlobCopyDirectoryTransferFailedEventArgs> DirectoriesFailed;
        internal SyncAsyncEventHandler<BlobCopyDirectoryTransferFailedEventArgs> GetDirectoriesFailed() => DirectoriesFailed;
    }
}
