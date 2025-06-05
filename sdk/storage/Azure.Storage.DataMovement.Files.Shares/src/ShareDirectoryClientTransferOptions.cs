// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    /// <summary>
    /// Options applying to data transfer uploads and downloads using the <see cref="ShareDirectoryClient"/> extension methods
    /// <see cref="ShareDirectoryClientExtensions.DownloadToDirectoryAsync(ShareDirectoryClient, WaitUntil, string, ShareDirectoryClientTransferOptions, CancellationToken)"/> and
    /// <see cref="ShareDirectoryClientExtensions.UploadDirectoryAsync(ShareDirectoryClient, WaitUntil, string, ShareDirectoryClientTransferOptions, CancellationToken)"/>.
    /// </summary>
    public class ShareDirectoryClientTransferOptions
    {
        /// <summary>
        /// Options pertaining to the share file directory used in the data transfer.
        /// </summary>
        public ShareFileStorageResourceOptions ShareDirectoryOptions { get; set; }

        /// <summary>
        /// Options pertaining to the data transfer.
        /// </summary>
        public TransferOptions TransferOptions { get; set; }
    }
}
