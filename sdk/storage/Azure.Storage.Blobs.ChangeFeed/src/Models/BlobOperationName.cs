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
        /// Unspecified event type.
        /// </summary>
        public static BlobOperationName UnspecifiedEventType { get; } = new BlobOperationName("UnspecifiedEventType");

        /// <summary>
        /// Put Blob.
        /// </summary>
        public static BlobOperationName PutBlob { get; } = new BlobOperationName("PutBlob");

        /// <summary>
        /// Delete Blob.
        /// </summary>
        public static BlobOperationName DeleteBlob { get; } = new BlobOperationName("DeleteBlob");

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
