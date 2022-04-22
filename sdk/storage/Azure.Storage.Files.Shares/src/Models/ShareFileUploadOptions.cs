// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Options for uploading a file.
    /// </summary>
    public class ShareFileUploadOptions
    {
        /// <summary>
        /// Progress handler for tracking upload progress.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Request conditions for upload
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Options for transactional hash content verification.
        /// </summary>
        public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
