// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Append Blob Open Write.
    /// </summary>
    public class AppendBlobOpenWriteOptions
    {
        /// <summary>
        /// The size of the buffer to use.  Default is 4 MB,
        /// max is 4 MB. See <see cref="AppendBlobClient.AppendBlobMaxAppendBlockBytes"/>.
        /// </summary>
        public long? BufferSize { get; set; }

        /// <summary>
        /// Access conditions used to open the write stream.
        /// </summary>
        public AppendBlobRequestConditions OpenConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="UploadTransferValidationOptions"/> for using transfer validation
        /// on write. Intermittent flushes will calculate a transactional checksum to validate
        /// transfers. Transactional checksums are discarded after use.
        ///
        /// OpenWrite does not accept precalculated checksums.
        /// </summary>
        public UploadTransferValidationOptions ValidationOptions { get; set; }
    }
}
