// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Models;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional paratmers for downloading some range of a file.
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
        /// Optional transactional hashing options.
        /// </summary>
        public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
