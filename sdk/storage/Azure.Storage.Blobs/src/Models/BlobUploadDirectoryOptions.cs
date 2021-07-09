// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob Upload Directory Options
    /// <see cref="BlobUploadOptions"/> for more options.
    /// </summary>
    public class BlobUploadDirectoryOptions : BlobUploadOptions
    {
        /// <summary>
        /// Optional Blob Type to Upload. Defaults to upload Block Blobs.
        /// </summary>
        public BlobType blobType { get; set; }

        /// <summary>
        /// Describes whether or not the directory being uploaded should
        /// be located under it's own subdirectory serverside.
        /// </summary>
        public bool? uploadToSubdirectory { get; set; }
    }
}
