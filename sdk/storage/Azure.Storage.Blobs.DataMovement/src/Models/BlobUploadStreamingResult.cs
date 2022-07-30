// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Blob uploading stream disposable
    /// </summary>
    internal class BlobUploadStreamingResult : IDisposable
    {
        public BlobContentInfo ContentInfo { get; set; }
        public Response response { get; set; }
        public Exception exception { get; set; }
        /// <summary>
        /// Disposes the <see cref="BlobUploadStreamingResult"/> by calling Dispose on the underlying stream.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
