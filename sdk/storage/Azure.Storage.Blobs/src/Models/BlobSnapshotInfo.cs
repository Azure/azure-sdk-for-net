// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobSnapshotInfo
    /// </summary>
    public class BlobSnapshotInfo
    {
        /// <summary>
        /// Uniquely identifies the snapshot and indicates the snapshot version. It may be used in subsequent requests to access the snapshot.
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob,
        /// including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A DateTime value returned by the service that uniquely identifies the blob.
        /// The value of this header indicates the blob version, and may be used in subsequent requests to access this version of the blob.
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// True if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// For a snapshot request, this header is set to true when metadata was provided in the request and encrypted with a customer-provided key.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of BlobSnapshotInfo instances.
        /// You can use BlobsModelFactory.BlobSnapshotInfo instead.
        /// </summary>
        internal BlobSnapshotInfo() { }
    }
}
