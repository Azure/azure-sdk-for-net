// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Contains results for each job.
    /// </summary>
    public class StorageTransferStatus
    {
        /// <summary>
        /// Number of files/blobs transferred succesfully
        /// </summary>
        public event SyncAsyncEventHandler<PathTransferSuccessEventArgs> FilesTransferred;
        internal SyncAsyncEventHandler<PathTransferSuccessEventArgs> GetFilesTransferred() => FilesTransferred;

        /// <summary>
        /// Number of directories transferred
        /// </summary>
        public event SyncAsyncEventHandler<PathTransferSuccessEventArgs> DirectoriesTransferred;
        internal SyncAsyncEventHandler<PathTransferSuccessEventArgs> GetDirectoriesTransferred() => DirectoriesTransferred;

        /// <summary>
        /// Number of Files Failing Transfer either due to no access or just failing transfer in general
        /// </summary>
        public event SyncAsyncEventHandler<PathTransferFailedEventArgs> FilesFailedTransferred;

        internal SyncAsyncEventHandler<PathTransferFailedEventArgs> GetTransferFailedHandlers() => FilesFailedTransferred;

        /// <summary>
        /// Number of directories skipped transfer. Due to inaccessability not sure if we should keep track if a few files in a folder are unable to transfer
        /// </summary>
        public event SyncAsyncEventHandler<PathTransferSkippedEventArgs> DirectoriesSkipped;
        internal SyncAsyncEventHandler<PathTransferSkippedEventArgs> GetDirectoriesSkipped() => DirectoriesSkipped;
    }
}
