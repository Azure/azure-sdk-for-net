// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The composition type describes how the key-values within the snapshot are composed. The 'key' composition type ensures there are no two key-values containing the same key. The 'key_label' composition type ensures there are no two key-values containing the same key and label. </summary>
    public readonly partial struct SnapshotComposition : IEquatable<SnapshotComposition>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SnapshotComposition"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SnapshotComposition(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KeyValue = "key";
        private const string KeyLabelValue = "key_label";

        /// <summary> The 'key' composition type ensures there are no two key-values containing the same key. </summary>
        public static SnapshotComposition Key { get; } = new SnapshotComposition(KeyValue);
        /// <summary> The 'key_label' composition type ensures there are no two key-values containing the same key and label. </summary>
        public static SnapshotComposition KeyLabel { get; } = new SnapshotComposition(KeyLabelValue);
        /// <summary> Determines if two <see cref="SnapshotComposition"/> values are the same. </summary>
        public static bool operator ==(SnapshotComposition left, SnapshotComposition right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SnapshotComposition"/> values are not the same. </summary>
        public static bool operator !=(SnapshotComposition left, SnapshotComposition right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SnapshotComposition"/>. </summary>
        public static implicit operator SnapshotComposition(string value) => new SnapshotComposition(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SnapshotComposition other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SnapshotComposition other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
