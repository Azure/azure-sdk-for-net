// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobInfo.
    /// </summary>
    public class BlobInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was last modified.
        /// Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The current sequence number for a page blob. This header is not
        /// returned for block blobs or append blobs.
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// The versionId of the blob version that was created.
        /// If null, a new blob version was not created.
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal BlobInfo() { }
    }
}
