// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for staging a block for a block blob with
    /// <see cref="BlockBlobClient.StageBlockAsync(string, Stream, BlockBlobStageBlockOptions, CancellationToken)"/>.
    /// </summary>
    public class BlockBlobStageBlockOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this Block Blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

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
