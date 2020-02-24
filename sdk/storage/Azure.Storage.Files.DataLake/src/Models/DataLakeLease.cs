// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Lease.
    /// </summary>
    public class DataLakeLease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request service version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the file system or path was last modified.
        /// Any operation that modifies the file system or path, including an update of the its metadata or properties,
        /// changes the last-modified time of the filesystem or path..
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Uniquely identifies a file system's or path's lease.
        /// </summary>
        public string LeaseId { get; internal set; }

        /// <summary>
        /// Gets the approximate time remaining in the lease period, in
        /// seconds.  This is only provided when breaking a lease.
        /// </summary>
        public int? LeaseTime { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of Lease instances.
        /// You can use DataLakeModelFactory.Lease instead.
        /// </summary>
        internal DataLakeLease() { }
    }
}
