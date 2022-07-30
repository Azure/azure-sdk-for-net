// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Blob SIngle Download Options
    /// </summary>
    public class BlobSingleDownloadOptions : BlobDownloadToOptions
    {
        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<StorageTransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<StorageTransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;
    }
}
