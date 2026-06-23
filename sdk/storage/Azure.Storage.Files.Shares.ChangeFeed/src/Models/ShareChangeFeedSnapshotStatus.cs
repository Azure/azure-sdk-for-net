// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Describes the state of a file share snapshot as recorded in the Azure Files
    /// change feed. Returned by
    /// <see cref="ShareChangeFeedClient.GetSnapshotStatus(string, System.Threading.CancellationToken)"/>
    /// and its async counterpart.
    /// </summary>
    public enum ShareChangeFeedSnapshotStatus
    {
        /// <summary>
        /// No snapshot metadata was found in the change feed for the requested timestamp.
        /// Either the snapshot was never taken, the change feed has not yet published its
        /// metadata, or the timestamp does not correspond to a share snapshot.
        /// </summary>
        NotFound = 0,

        /// <summary>
        /// Snapshot metadata exists in the change feed but the snapshot has not yet been
        /// finalized. Querying change feed events that reference this snapshot may return
        /// incomplete results until finalization completes.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Snapshot metadata exists in the change feed and the snapshot has been finalized.
        /// The snapshot can be used as an endpoint for
        /// <see cref="ShareChangeFeedClient.GetChangesBetweenSnapshots(string, string)"/>
        /// queries.
        /// </summary>
        Finalized = 2,
    }
}
