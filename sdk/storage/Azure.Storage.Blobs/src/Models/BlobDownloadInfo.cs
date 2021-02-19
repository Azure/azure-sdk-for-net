﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The details and Content returned from downloading a blob
    /// </summary>
    public class BlobDownloadInfo : IDisposable, IDownloadedContent
    {
        /// <summary>
        /// The blob's type.
        /// </summary>
        public BlobType BlobType { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content { get; internal set; }

        /// <summary>
        /// The media type of the body of the response. For Download Blob this is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Details returned when downloading a Blob
        /// </summary>
        public BlobDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal BlobDownloadInfo() { }

        /// <summary>
        /// Disposes the BlobDownloadInfo by calling Dispose on the underlying Content stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
