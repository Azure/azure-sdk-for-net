// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Properties of a file system.
    /// </summary>
    public class FileSystemProperties
    {
        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> the file system was last modified. Any operation that modifies the
        /// file system, including an update of the file systems's metadata or properties, changes the last-modified
        /// time of the file system.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// <see cref="LeaseStatus"/> of the file system.
        /// </summary>
        public DataLakeLeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// <see cref="LeaseState"/> of the file system.
        /// </summary>
        public DataLakeLeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// <see cref="DataLakeLeaseDuration"/> of the file system.
        /// </summary>
        public DataLakeLeaseDuration? LeaseDuration { get; internal set; }

        /// <summary>
        /// <see cref="PublicAccessType"/> of the file system.
        /// </summary>
        public PublicAccessType? PublicAccess { get; internal set; }

        /// <summary>
        /// Version 2017-11-09 and newer. Indicates whether the file system has an immutability policy set on it.
        /// Value is true if there is a policy set, false otherwise.
        /// </summary>
        public bool? HasImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// Version 2017-11-09 and newer. Indicates whether the file system has a legal hold.
        /// Value is true if there is one or more legal hold(s), false otherwise.
        /// </summary>
        public bool? HasLegalHold { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally on the file system.
        /// If the request service version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The file systems's metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// DeletedTime.
        /// </summary>
        public System.DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// RemainingRetentionDays.
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// DefaultEncryptionScope.
        /// </summary>
        public string DefaultEncryptionScope { get; internal set; }

        /// <summary>
        /// DenyEncryptionScopeOverride.
        /// </summary>
        public bool? PreventEncryptionScopeOverride { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemProperties instances.
        /// You can use BlobsModelFactory.FileSystemProperties instead.
        /// </summary>
        internal FileSystemProperties() { }
    }
}
