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
        /// Optional.  Specifies if the file last write time should be set to the current time,
        /// or the last write time currently associated with the file should be preserved.
        /// </summary>
        public FileLastWrittenMode? FileLastWrittenMode { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        ///// <summary>
        ///// Optional <see cref="UploadTransactionalHashingOptions"/> for using transactional
        ///// hashing on uploads.
        ///// </summary>
        // TODO #27253
        //public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
