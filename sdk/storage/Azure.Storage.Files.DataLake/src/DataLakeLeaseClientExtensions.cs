// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> and
    /// <see cref="BlobClient"/> for easily creating <see cref="DataLakeLeaseClient"/>
    /// instances.
    /// </summary>
    public static partial class DataLakeLeaseClientExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="PathClient"/> representing the path being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static DataLakeLeaseClient GetDataLakeLeaseClient(
            this PathClient client,
            string leaseId = null) =>
            new DataLakeLeaseClient(client, leaseId);

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="FileSystemClient"/> representing the file system being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static DataLakeLeaseClient GetDataLakeLeaseClient(
            this FileSystemClient client,
            string leaseId = null) =>
            new DataLakeLeaseClient(client, leaseId);
    }
}
