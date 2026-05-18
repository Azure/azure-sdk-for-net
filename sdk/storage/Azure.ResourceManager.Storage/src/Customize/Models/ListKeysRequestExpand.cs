// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: New extensible enum with implicit conversions to/from old
// StorageListKeyExpand type. Bridges the type rename from prior GA.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies type of the key to be listed. Possible value is kerb. </summary>
    public readonly partial struct ListKeysRequestExpand : IEquatable<ListKeysRequestExpand>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ListKeysRequestExpand"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ListKeysRequestExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KerbValue = "kerb";

        /// <summary> kerb. </summary>
        public static ListKeysRequestExpand Kerb { get; } = new ListKeysRequestExpand(KerbValue);

        /// <summary> Determines if two <see cref="ListKeysRequestExpand"/> values are the same. </summary>
        public static bool operator ==(ListKeysRequestExpand left, ListKeysRequestExpand right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ListKeysRequestExpand"/> values are not the same. </summary>
        public static bool operator !=(ListKeysRequestExpand left, ListKeysRequestExpand right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ListKeysRequestExpand"/>. </summary>
        public static implicit operator ListKeysRequestExpand(string value) => new ListKeysRequestExpand(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ListKeysRequestExpand other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ListKeysRequestExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        // Backward-compatible: Converts to StorageListKeyExpand.
        public static implicit operator StorageListKeyExpand(ListKeysRequestExpand value) => new StorageListKeyExpand(value._value);
        // Backward-compatible: Converts from StorageListKeyExpand.
        public static implicit operator ListKeysRequestExpand(StorageListKeyExpand value) => new ListKeysRequestExpand(value.ToString());
    }

    // Backward-compatible alias for ListKeysRequestExpand.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct StorageListKeyExpand : IEquatable<StorageListKeyExpand>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageListKeyExpand"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageListKeyExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KerbValue = "kerb";

        /// <summary> kerb. </summary>
        public static StorageListKeyExpand Kerb { get; } = new StorageListKeyExpand(KerbValue);

        /// <summary> Determines if two <see cref="StorageListKeyExpand"/> values are the same. </summary>
        public static bool operator ==(StorageListKeyExpand left, StorageListKeyExpand right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageListKeyExpand"/> values are not the same. </summary>
        public static bool operator !=(StorageListKeyExpand left, StorageListKeyExpand right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="StorageListKeyExpand"/>. </summary>
        public static implicit operator StorageListKeyExpand(string value) => new StorageListKeyExpand(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageListKeyExpand other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageListKeyExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
