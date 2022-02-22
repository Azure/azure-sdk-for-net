// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Defines the type of transfer the job is performing.
    /// This is used in the <see cref="BlobTransferJobProperties"/>.
    /// </summary>
    public enum BlobTransferType
    {
        /// <summary>
        /// Single Upload Transfer.
        /// </summary>
        SingleUpload,

        /// <summary>
        /// Single Download Transfer.
        /// </summary>
        SingleDownload,

        /// <summary>
        /// Directory Upload Transfer
        /// </summary>
        DirectoryUpload,

        /// <summary>
        /// Directory Download Transfer
        /// </summary>
        DirectoryDownload,

        /// <summary>
        /// Single Sync Copy Transfer
        /// </summary>
        SingleSyncCopy,

        /// <summary>
        /// Directory Sync Copy Transfer
        /// </summary>
        DirectorySyncCopy,

        /// <summary>
        /// Single Async Copy Transfer
        /// </summary>
        SingleAsyncCopy,

        /// <summary>
        /// Directory Async Copy Transfer
        /// </summary>
        DirectoryAsyncCopy,

        /// <summary>
        /// Single Round Trip Copy Transfer
        /// </summary>
        SingleRoundTripCopy,

        /// <summary>
        /// Directory Round Trip Copy Transfer
        /// </summary>
        DirectoryRoundTripCopy,

        /// <summary>
        /// Single Round Trip Copy Transfer
        /// </summary>
        SingleSyncUploadUriCopy,

        /// <summary>
        /// Directory Round Trip Copy Transfer
        /// </summary>
        DirectorySyncUploadUriCopy,
    }
}
