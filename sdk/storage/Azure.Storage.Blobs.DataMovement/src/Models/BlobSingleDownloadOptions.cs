// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Blob SIngle Download Options
    /// </summary>
    internal class BlobSingleDownloadOptions : BlobDownloadToOptions
    {
        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<TransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;

        /// <summary>
        /// Number of Files Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobDownloadFailedEventArgs> DownloadFailedEventHandler;

        internal SyncAsyncEventHandler<BlobDownloadFailedEventArgs> GetDownloadFailed() => DownloadFailedEventHandler;
    }
}
