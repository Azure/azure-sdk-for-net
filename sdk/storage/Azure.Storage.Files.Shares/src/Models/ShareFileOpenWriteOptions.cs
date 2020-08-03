// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for File Open Write.
    /// </summary>
    public class ShareFileOpenWriteOptions
    {
        /// <summary>
        /// The size of the buffer to use.  Default is 4 MB,
        /// max is 4 MB.
        /// </summary>
        public long? BufferSize { get; set; }

        /// <summary>
        /// Required if Overwrite is set to true.
        /// Specifies the size of the new File.
        /// </summary>
        public long MaxSize { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add
        /// conditions on appending content to this file.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }
    }
}
