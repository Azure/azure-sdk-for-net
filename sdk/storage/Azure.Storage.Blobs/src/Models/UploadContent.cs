// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob content to be uploaded by a <see cref="Specialized.BlobBaseClient"/>.
    /// </summary>
    public class UploadContent
    {
        /// <summary>
        /// Content stream to upload.
        /// </summary>
        public Stream ContentStream { get; set; }

        /// <summary>
        /// Content metadata to upload.
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
