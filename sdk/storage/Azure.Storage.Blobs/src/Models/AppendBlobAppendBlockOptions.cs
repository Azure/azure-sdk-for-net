// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for appending a block with
    /// <see cref="AppendBlobClient.AppendBlockAsync(Stream, AppendBlobAppendBlockOptions, CancellationToken)"/>.
    /// </summary>
    public class AppendBlobAppendBlockOptions
    {
        /// <summary>
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the upload of this Append Blob.
        /// </summary>
        public AppendBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        ///
        /// AppendBlock accepts precalcualted checksums, but the method will calculate
        /// one if not provided.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }
    }
}
