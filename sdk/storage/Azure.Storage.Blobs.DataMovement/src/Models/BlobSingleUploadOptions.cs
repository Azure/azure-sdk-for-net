// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Single Upload Options
    /// </summary>
    public class BlobSingleUploadOptions : BlobUploadOptions
    {
        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<StorageTransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<StorageTransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;

        /// <summary>
        /// Number of Files Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<BlobUploadFailedEventArgs> UploadFailedEventHandler;

        internal SyncAsyncEventHandler<BlobUploadFailedEventArgs> GetUploadFailed() => UploadFailedEventHandler;
    }
}
