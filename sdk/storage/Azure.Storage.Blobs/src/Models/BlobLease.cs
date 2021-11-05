// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobLease.
    /// </summary>
    public class BlobLease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Uniquely identifies a container's or blob's lease
        /// </summary>
        public string LeaseId { get; internal set; }

        /// <summary>
        /// Gets the approximate time remaining in the lease period, in
        /// seconds.  This is only provided when breaking a lease.
        /// </summary>
        public int? LeaseTime { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of BlobLease instances.
        /// You can use BlobsModelFactory.BlobLease instead.
        /// </summary>
        internal BlobLease() { }
    }
}
