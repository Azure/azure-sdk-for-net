// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage
{
    /// <summary>
    /// Audience for retrieving and AAD token.
    /// </summary>
    public readonly struct StorageAudience : IEquatable<StorageAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="StorageAudience"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is null.
        /// </exception>
        public StorageAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StorageValue = "Storage";
        private const string DiskComputeValue = "DiskCompute";

        /// <summary>
        /// Storage audience.
        /// </summary>
        public static StorageAudience Storage { get; } = new StorageAudience(StorageValue);

        /// <summary>
        /// Disk compute audience.
        /// </summary>
        public static StorageAudience DiskCompute { get; } = new StorageAudience(DiskComputeValue);

        /// <summary>
        /// Determines if two <see cref="StorageAudience"/> values are the same.
        /// </summary>
        public static bool operator ==(StorageAudience left, StorageAudience right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="StorageAudience"/> values are not the same.
        /// </summary>
        public static bool operator !=(StorageAudience left, StorageAudience right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="StorageAudience"/>.
        /// </summary>
        public static implicit operator StorageAudience(string value) => new StorageAudience(value);

        /// <inheritdoc/>
        public bool Equals(StorageAudience other)
            => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        public override string ToString() => _value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is StorageAudience && Equals((StorageAudience)obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    }
}
