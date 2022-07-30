// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// BlobContentInfo for each blob uploaded to the directory
    ///
    /// See <see cref="BlobContentInfo"/> for more details.
    /// </summary>
    public class SingleBlobContentInfo
    {
        /// <summary>
        /// The Blob Uri for the blob that was uploaded.
        /// </summary>
        public Uri BlobUri { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Response<BlobContentInfo> ContentInfo { get; internal set; }

        /// <summary>
        /// Any exceptions caught during the process
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of SingleBlobContentInfo instances.
        /// You can use BlobsModelFactory.SingleBlobContentInfo instead.
        /// </summary>
        internal SingleBlobContentInfo() { }
    }
}
