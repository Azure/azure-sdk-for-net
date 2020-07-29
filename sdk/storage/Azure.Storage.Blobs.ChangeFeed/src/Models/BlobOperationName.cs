// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    /// <summary>
    /// The name of the API operation associated with a <see cref="BlobChangeFeedEventData"/>.
    /// </summary>
    public readonly struct BlobOperationName : IEquatable<BlobOperationName>
    {
        private readonly string _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        public BlobOperationName(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        /// <summary>
        /// Unspecified Api.
        /// </summary>
        public static BlobOperationName UnspecifiedApi { get; } = new BlobOperationName("UnspecifiedApi");

        /// <summary>
        /// Put Blob.
        /// </summary>
        public static BlobOperationName PutBlob { get; } = new BlobOperationName("PutBlob");

        /// <summary>
        /// Put Block List.
        /// </summary>
        public static BlobOperationName PutBlockList { get; } = new BlobOperationName("PutBlockList");

        /// <summary>
        /// Copy Blob.
        /// </summary>
        public static BlobOperationName CopyBlob { get; } = new BlobOperationName("CopyBlob");

        /// <summary>
        /// Delete Blob.
        /// </summary>
        public static BlobOperationName DeleteBlob { get; } = new BlobOperationName("DeleteBlob");

        /// <summary>
        /// Set Blob Metadata.
        /// </summary>
        public static BlobOperationName SetBlobMetadata { get; } = new BlobOperationName("SetBlobMetadata");

        /// <summary>
        /// Control Event.
        /// </summary>
        public static BlobOperationName ControlEvent { get; } = new BlobOperationName("ControlEvent");

        /// <summary>
        /// Undelete Blob.
        /// </summary>
        public static BlobOperationName UndeleteBlob { get; } = new BlobOperationName("UndeleteBlob");

        /// <summary>
        /// Set Blob Properties.
        /// </summary>
        public static BlobOperationName SetBlobProperties { get; } = new BlobOperationName("SetBlobProperties");

        /// <summary>
        /// Snapshot Blob.
        /// </summary>
        public static BlobOperationName SnapshotBlob { get; } = new BlobOperationName("SnapshotBlob");

        /// <summary>
        /// Set Blob Tier.
        /// </summary>
        public static BlobOperationName SetBlobTier { get; } = new BlobOperationName("SetBlobTier");

        /// <summary>
        /// Abort Copy Blob.
        /// </summary>
        public static BlobOperationName AbortCopyBlob { get; } = new BlobOperationName("AbortCopyBlob");

        ///<inheritdoc/>
        public static bool operator ==(BlobOperationName left, BlobOperationName right) => left.Equals(right);

        ///<inheritdoc/>
        public static bool operator !=(BlobOperationName left, BlobOperationName right) => !left.Equals(right);

        ///<inheritdoc/>
        public static implicit operator BlobOperationName(string value) => new BlobOperationName(value);

        ///<inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BlobOperationName other && Equals(other);

        ///<inheritdoc/>
        public bool Equals(BlobOperationName other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        ///<inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        ///<inheritdoc/>
        public override string ToString() => _value;
    }
}
