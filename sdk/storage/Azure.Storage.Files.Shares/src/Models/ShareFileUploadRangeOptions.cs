// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional paratmers for uploading a file range.
    /// </summary>
    public class ShareFileUploadRangeOptions
    {
        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add
        /// conditions on the upload of this file range.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="UploadTransactionalHashingOptions"/> for using transactional
        /// hashing on uploads.
        /// </summary>
        public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
