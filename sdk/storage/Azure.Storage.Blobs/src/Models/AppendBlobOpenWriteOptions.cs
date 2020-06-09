// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Append Blob Open Write.
    /// </summary>
    public class AppendBlobOpenWriteOptions
    {
        /// <summary>
        /// Whether the upload should overwrite any existing blobs.
        /// The default value is false.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// The size of the buffer to use.  Default is 1 MB, and the max
        /// buffer size is 4 MB.
        /// </summary>
        public int BufferSize { get; set; }

        /// <summary>
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </summary>
        public AppendBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }
    }
}
