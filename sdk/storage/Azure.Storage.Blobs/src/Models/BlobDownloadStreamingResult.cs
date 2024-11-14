// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The details and Content returned from downloading a blob.
    /// </summary>
    public class BlobDownloadStreamingResult : IDisposable, IDownloadedContent
    {
        internal BlobDownloadStreamingResult() { }

        /// <summary>
        /// Details returned when downloading a Blob.
        /// </summary>
        public BlobDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Content.
        /// </summary>
        public Stream Content { get; internal set; }

        /// <summary>
        /// Disposes the <see cref="BlobDownloadStreamingResult"/> by calling Dispose on the underlying <see cref="Content"/> stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
