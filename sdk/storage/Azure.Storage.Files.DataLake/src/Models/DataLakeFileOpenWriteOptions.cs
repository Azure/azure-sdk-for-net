// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Shared;

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
        /// The size of the buffer to use.  Default is 4 MB,
        /// max is 4000 MB.  See <see cref="DataLakeFileClient.MaxUploadLongBytes"/>.
        /// </summary>
        public long BufferSize { get; set; }

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
