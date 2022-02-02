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
    public enum StorageTransferType
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
        /// Single Copy Transfer
        /// </summary>
        SingleServiceCopy,

        /// <summary>
        /// Directory Copy Transfer
        /// </summary>
        DirectoryServiceCopy
    }
}
