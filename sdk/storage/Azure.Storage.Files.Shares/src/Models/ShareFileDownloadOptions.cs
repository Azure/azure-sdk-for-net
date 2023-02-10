// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for downloading a range of a file with
    /// <see cref="ShareFileClient.DownloadAsync(ShareFileDownloadOptions, CancellationToken)"/>.
    /// </summary>
    public class ShareFileDownloadOptions
    {
        /// <summary>
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire file.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions on
        /// downloading this file.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="ShareClientOptions.TransferValidation"/> settings.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidation { get; set; }
    }
}
