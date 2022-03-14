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
    public class BlobDownloadDirectoryEventHandler
    {
        /// <summary>
        /// If a blob gets transferred successfully the event will get added to this handler
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadTransferSuccessEventArgs> BlobTransferred;
        internal SyncAsyncEventHandler<BlobDownloadTransferSuccessEventArgs> GetBlobsTransferred() => BlobTransferred;

        /// <summary>
        /// Number of directories transferred
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadDirectoryTransferSuccessEventArgs> DirectoriesTransferred;
        internal SyncAsyncEventHandler<BlobDownloadDirectoryTransferSuccessEventArgs> GetDirectoriesTransferred() => DirectoriesTransferred;

        /// <summary>
        /// Number of blobs Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadTransferFailedEventArgs> BlobsFailedTransferred;

        internal SyncAsyncEventHandler<BlobDownloadTransferFailedEventArgs> GetBlobFailed() => BlobsFailedTransferred;

        /// <summary>
        /// Number of directories skipped transfer. Due to inaccessability not sure if we should keep track if a few blobs in a folder are unable to transfer
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadDirectoryTransferFailedEventArgs> DirectoriesFailed;
        internal SyncAsyncEventHandler<BlobDownloadDirectoryTransferFailedEventArgs> GetDirectoriesFailed() => DirectoriesFailed;
    }
}
