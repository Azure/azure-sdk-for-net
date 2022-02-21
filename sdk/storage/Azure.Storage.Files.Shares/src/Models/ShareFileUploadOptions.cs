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
        /// Optional <see cref="UploadTransferValidationOptions"/> for using transfer validation
        /// on upload. Network transfers will calculate transactional checksums to validate
        /// transfers. Transactional checksums are discarded after use.
        ///
        /// Upload does not accept precalculated checksums.
        /// </summary>
        public UploadTransferValidationOptions ValidationOptions { get; set; }
    }
}
