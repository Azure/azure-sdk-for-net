// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    /// <summary>
    /// BlobChangeFeedEventType.
    /// </summary>
    public readonly struct BlobChangeFeedEventType : IEquatable<BlobChangeFeedEventType>
    {
        private readonly string _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BlobChangeFeedEventType(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        /// <summary>
        /// Unspecified Event Type.
        /// </summary>
        public static BlobChangeFeedEventType UnspecifiedEventType { get; } = new BlobChangeFeedEventType("UnspecifiedEventType");

        /// <summary>
        /// Blob Created.
        /// </summary>
        public static BlobChangeFeedEventType BlobCreated { get; } = new BlobChangeFeedEventType("BlobCreated");

        /// <summary>
        /// Blob Deleted.
        /// </summary>
        public static BlobChangeFeedEventType BlobDeleted { get; } = new BlobChangeFeedEventType("BlobDeleted");

        /// <summary>
        /// Blob Properties Updated.
        /// </summary>
        public static BlobChangeFeedEventType BlobPropertiesUpdated { get; } = new BlobChangeFeedEventType("BlobPropertiesUpdated");

        /// <summary>
        /// Blob Snapshot Created.
        /// </summary>
        public static BlobChangeFeedEventType BlobSnapshotCreated { get; } = new BlobChangeFeedEventType("BlobSnapshotCreated");

        /// <summary>
        /// Control.
        /// </summary>
        public static BlobChangeFeedEventType Control { get; } = new BlobChangeFeedEventType("Control");

        /// <summary>
        /// Blob Tier Changed.
        /// </summary>
        public static BlobChangeFeedEventType BlobTierChanged { get; } = new BlobChangeFeedEventType("BlobTierChanged");

        /// <summary>
        /// Blob Async Operation Initiated.
        /// </summary>
        public static BlobChangeFeedEventType BlobAsyncOperationInitiated { get; } = new BlobChangeFeedEventType("BlobAsyncOperationInitiated");

        ///<inheritdoc/>
        public static bool operator ==(BlobChangeFeedEventType left, BlobChangeFeedEventType right) => left.Equals(right);

        ///<inheritdoc/>
        public static bool operator !=(BlobChangeFeedEventType left, BlobChangeFeedEventType right) => !left.Equals(right);

        ///<inheritdoc/>
        public static implicit operator BlobChangeFeedEventType(string value) => new BlobChangeFeedEventType(value);

        ///<inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BlobChangeFeedEventType other && Equals(other);

        ///<inheritdoc/>
        public bool Equals(BlobChangeFeedEventType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        ///<inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        ///<inheritdoc/>
        public override string ToString() => _value;
    }
}
