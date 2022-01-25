// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Audience for retrieving and AAD token.
    /// </summary>
    public readonly struct BlobAudience : IEquatable<BlobAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="BlobAudience"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is null.
        /// </exception>
        public BlobAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StorageValue = "https://storage.azure.com/.default";
        private const string DiskComputeValue = "https://disk.compute.azure.com/.default";

        /// <summary>
        /// Storage audience.
        /// </summary>
        public static BlobAudience Storage { get; } = new BlobAudience(StorageValue);

        /// <summary>
        /// Disk compute audience.
        /// </summary>
        public static BlobAudience DiskCompute { get; } = new BlobAudience(DiskComputeValue);

        /// <summary>
        /// Determines if two <see cref="BlobAudience"/> values are the same.
        /// </summary>
        public static bool operator ==(BlobAudience left, BlobAudience right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="BlobAudience"/> values are not the same.
        /// </summary>
        public static bool operator !=(BlobAudience left, BlobAudience right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="BlobAudience"/>.
        /// </summary>
        public static implicit operator BlobAudience(string value) => new BlobAudience(value);

        /// <inheritdoc/>
        public bool Equals(BlobAudience other)
            => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        public override string ToString() => _value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is BlobAudience && Equals((BlobAudience)obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    }
}
