﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Access conditions used to open the write stream.
        /// </summary>
        public ShareFileRequestConditions OpenConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Required if overwrite is set to true, or the underlying
        /// file is being created for the first time.
        /// Specifies the size of the new Page Blob.
        /// </summary>
        public long? MaxSize { get; set; }
    }
}
