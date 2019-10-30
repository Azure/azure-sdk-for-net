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
        /// Last-Modified
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// LeaseStatus
        /// </summary>
        public LeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// LeaseState
        /// </summary>
        public LeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// LeaseDuration
        /// </summary>
        public LeaseDurationType? LeaseDuration { get; internal set; }

        /// <summary>
        /// PublicAccess
        /// </summary>
        public PublicAccessType? PublicAccess { get; internal set; }

        /// <summary>
        /// HasImmutabilityPolicy
        /// </summary>
        public bool? HasImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// HasLegalHold
        /// </summary>
        public bool? HasLegalHold { get; internal set; }

        /// <summary>
        /// ETag
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemProperties instances.
        /// You can use BlobsModelFactory.FileSystemProperties instead.
        /// </summary>
        internal FileSystemProperties() { }
    }
}
