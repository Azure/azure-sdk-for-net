// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Describes the state of a file share snapshot as recorded in the Azure Files
    /// change feed. Returned by
    /// <see cref="ShareChangeFeedClient.GetSnapshotStatus(string, System.Threading.CancellationToken)"/>
    /// and its async counterpart.
    /// </summary>
    public readonly struct ShareChangeFeedSnapshotStatus : IEquatable<ShareChangeFeedSnapshotStatus>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedSnapshotStatus"/> with a custom string value.
        /// </summary>
        /// <param name="value">The snapshot status string.</param>
        public ShareChangeFeedSnapshotStatus(string value) { _value = value ?? throw ShareChangeFeedErrors.ArgumentNull(nameof(value)); }

        /// <summary>
        /// No snapshot metadata was found in the change feed for the requested timestamp.
        /// Either the snapshot was never taken, the change feed has not yet published its
        /// metadata, or the timestamp does not correspond to a share snapshot.
        /// </summary>
        public static ShareChangeFeedSnapshotStatus NotFound { get; } = new ShareChangeFeedSnapshotStatus("NotFound");

        /// <summary>
        /// Snapshot metadata exists in the change feed but the snapshot has not yet been
        /// finalized. Querying change feed events that reference this snapshot may return
        /// incomplete results until finalization completes.
        /// </summary>
        public static ShareChangeFeedSnapshotStatus Pending { get; } = new ShareChangeFeedSnapshotStatus("Pending");

        /// <summary>
        /// Snapshot metadata exists in the change feed and the snapshot has been finalized.
        /// The snapshot can be used as an endpoint for
        /// <see cref="ShareChangeFeedClient.GetChangesBetweenSnapshots(string, string)"/>
        /// queries.
        /// </summary>
        public static ShareChangeFeedSnapshotStatus Finalized { get; } = new ShareChangeFeedSnapshotStatus("Finalized");

        public static implicit operator ShareChangeFeedSnapshotStatus(string value) => new ShareChangeFeedSnapshotStatus(value);
        public static implicit operator ShareChangeFeedSnapshotStatus?(string value) => value == null ? null : new ShareChangeFeedSnapshotStatus(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ShareChangeFeedSnapshotStatus other && Equals(other);
        public bool Equals(ShareChangeFeedSnapshotStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
        public static bool operator ==(ShareChangeFeedSnapshotStatus left, ShareChangeFeedSnapshotStatus right) => left.Equals(right);
        public static bool operator !=(ShareChangeFeedSnapshotStatus left, ShareChangeFeedSnapshotStatus right) => !left.Equals(right);
    }
}
