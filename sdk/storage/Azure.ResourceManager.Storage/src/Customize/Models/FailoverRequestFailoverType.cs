// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: New extensible enum type with implicit conversions to/from old
// StorageAccountFailoverType. Bridges the type rename from old GA to new generated type.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameter is set to 'Planned' to indicate whether a Planned failover is requested. </summary>
    public readonly partial struct FailoverRequestFailoverType : IEquatable<FailoverRequestFailoverType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FailoverRequestFailoverType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FailoverRequestFailoverType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PlannedValue = "Planned";

        /// <summary> Planned. </summary>
        public static FailoverRequestFailoverType Planned { get; } = new FailoverRequestFailoverType(PlannedValue);

        /// <summary> Determines if two <see cref="FailoverRequestFailoverType"/> values are the same. </summary>
        public static bool operator ==(FailoverRequestFailoverType left, FailoverRequestFailoverType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FailoverRequestFailoverType"/> values are not the same. </summary>
        public static bool operator !=(FailoverRequestFailoverType left, FailoverRequestFailoverType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="FailoverRequestFailoverType"/>. </summary>
        public static implicit operator FailoverRequestFailoverType(string value) => new FailoverRequestFailoverType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FailoverRequestFailoverType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FailoverRequestFailoverType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        // Backward-compatible: Converts to StorageAccountFailoverType.
        public static implicit operator StorageAccountFailoverType(FailoverRequestFailoverType value) => new StorageAccountFailoverType(value._value);
        // Backward-compatible: Converts from StorageAccountFailoverType.
        public static implicit operator FailoverRequestFailoverType(StorageAccountFailoverType value) => new FailoverRequestFailoverType(value.ToString());
    }

    // Backward-compatible alias for FailoverRequestFailoverType.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct StorageAccountFailoverType : IEquatable<StorageAccountFailoverType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageAccountFailoverType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageAccountFailoverType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PlannedValue = "Planned";

        /// <summary> Planned. </summary>
        public static StorageAccountFailoverType Planned { get; } = new StorageAccountFailoverType(PlannedValue);

        /// <summary> Determines if two <see cref="StorageAccountFailoverType"/> values are the same. </summary>
        public static bool operator ==(StorageAccountFailoverType left, StorageAccountFailoverType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageAccountFailoverType"/> values are not the same. </summary>
        public static bool operator !=(StorageAccountFailoverType left, StorageAccountFailoverType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="StorageAccountFailoverType"/>. </summary>
        public static implicit operator StorageAccountFailoverType(string value) => new StorageAccountFailoverType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountFailoverType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageAccountFailoverType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
