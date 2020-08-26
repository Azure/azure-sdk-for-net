// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Page Blob Open Write.
    /// </summary>
    public class BlockBlobOpenWriteOptions
    {
        /// <summary>
        /// The size of the buffer to use.  Default is 4 MB,
        /// max is 4000 MB.  See <see cref="BlockBlobClient.BlockBlobMaxStageBlockLongBytes"/>.
        /// </summary>
        public long? BufferSize { get; set; }

        /// <summary>
        /// Access conditions used to open the write stream.
        /// </summary>
        public BlobRequestConditions OpenConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }
    }
}
