// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for File Open Write.
    /// </summary>
    public class DataLakeFileOpenWriteOptions
    {
        /// <summary>
        /// Whether the upload should overwrite any existing blobs.
        /// The default value is false.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// The size of the buffer to use.  Default is 1 MB, and the max
        /// buffer size is 100 MB.
        /// </summary>
        public int BufferSize { get; set; }

        /// <summary>
        /// Required if <see cref="Overwrite"/> is set to true.
        /// Specifies the size of the new Page Blob.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on appending content to this file.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }
    }
}
