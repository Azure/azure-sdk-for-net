// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.DataLake;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for appending data to a file with DataLakeFileClient.Append() and .AppendAsync().
    /// </summary>
    public class DataLakeFileAppendOptions
    {
        /// <summary>
        /// Optional lease ID for accessing this blob.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Lease action.
        /// <see cref="LeaseAction.Acquire"/> will attempt to acquire a new lease on the file, with <see cref="ProposedLeaseId"/> as the lease ID.
        /// <see cref="LeaseAction.AcquireRelease"/> will attempt to acquire a new lease on the file, with <see cref="ProposedLeaseId"/> as the lease ID.  The lease will be released once the Append operation is complete.  Only applicable if <see cref="Flush"/> is set to true.
        /// <see cref="LeaseAction.AutoRenew"/> will attempt to renew the lease specified by <see cref="LeaseId"/>.
        /// <see cref="LeaseAction.Release"/> will attempt to release the least speified by <see cref="LeaseId"/>.  Only applicable if <see cref="Flush"/> is set to true.
        /// </summary>
        public LeaseAction? LeaseAction { get; set; }

        /// <summary>
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="DataLakeLeaseClient.InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// </summary>
        public TimeSpan? LeaseDuration { get; set; }

        /// <summary>
        /// Proposed lease ID. Valid with <see cref="LeaseAction.Acquire"/> and <see cref="LeaseAction.AcquireRelease"/>.
        /// </summary>
        public string ProposedLeaseId { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </summary>
        public byte[] ContentHash { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="DataLakeClientOptions.TransferValidation"/> settings.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }

        /// <summary>
        /// Optional.  If true, the file will be flushed after the append.
        /// </summary>
        public bool? Flush { get; set; }
    }
}
