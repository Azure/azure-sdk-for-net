// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for uploading a file range with
    /// <see cref="ShareFileClient.UploadRange(HttpRange, Stream, ShareFileUploadRangeOptions, CancellationToken)"/>.
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
        /// Optional <see cref="UploadTransferValidationOptions"/> for using additional
        /// transactional validation on upload range. Transactional checksums are discarded after use.
        ///
        /// UploadRange accepts precalcualted checksums, but the method will calculate
        /// one if not provided.
        /// </summary>
        public UploadTransferValidationOptions TransactionalValidationOptions { get; set; }
    }
}
