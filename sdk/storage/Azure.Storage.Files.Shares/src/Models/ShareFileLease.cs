// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileLease.
    /// </summary>
    public class ShareFileLease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the share or its properties updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Uniquely identifies a file's lease.
        /// </summary>
        public string LeaseId { get; internal set; }

        /// <summary>
        /// Gets the approximate time remaining in the lease period, in
        /// seconds.  This is only provided when breaking a lease.
        /// </summary>
        public int? LeaseTime { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileLease instances.
        /// You can use ShareModelFactory.ShareFileLease instead.
        /// </summary>
        internal ShareFileLease() { }
    }
}
