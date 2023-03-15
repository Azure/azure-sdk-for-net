// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for creating a file or directory..
    /// </summary>
    public class DataLakePathCreateOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
        /// </summary>
        public PathHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this file or directory.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Access options to set on the newly-created path.
        /// </summary>
        public DataLakeAccessOptions AccessOptions { get; set; }

        /// <summary>
        /// Optional.  Proposed LeaseId.
        /// Does not apply to directories.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Optional.  Specifies the duration of the lease, in seconds, or specify
        /// <see cref="DataLakeLeaseClient.InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// Does not apply to directories.
        /// </summary>
        public TimeSpan? LeaseDuration { get; set; }

        /// <summary>
        /// Options for scheduling the deletion of a path.
        /// </summary>
        public DataLakePathScheduleDeletionOptions ScheduleDeletionOptions { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional encryption context that can be set the file.
        /// Encryption context is file metadata that is not encrypted when stored on the file.
        /// The primary application of this field is to store non-encrypted data that can be used to derive the customer-provided key
        /// for a file.
        /// Not applicable for directories.
        /// </summary>
        public string EncryptionContext { get; set; }
    }
}
