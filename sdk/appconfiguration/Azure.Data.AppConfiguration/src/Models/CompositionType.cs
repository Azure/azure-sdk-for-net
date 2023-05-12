// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The composition type describes how the key-values within the snapshot are composed. The 'key' composition type ensures there are no two key-values containing the same key. The 'key_label' composition type ensures there are no two key-values containing the same key and label. </summary>
    public readonly partial struct CompositionType : IEquatable<CompositionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CompositionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CompositionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KeyValue = "key";
        private const string KeyLabelValue = "key_label";

        /// <summary> The 'key' composition type ensures there are no two key-values containing the same key. </summary>
        public static CompositionType Key { get; } = new CompositionType(KeyValue);
        /// <summary> The 'key_label' composition type ensures there are no two key-values containing the same key and label. </summary>
        public static CompositionType KeyLabel { get; } = new CompositionType(KeyLabelValue);
        /// <summary> Determines if two <see cref="CompositionType"/> values are the same. </summary>
        public static bool operator ==(CompositionType left, CompositionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CompositionType"/> values are not the same. </summary>
        public static bool operator !=(CompositionType left, CompositionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CompositionType"/>. </summary>
        public static implicit operator CompositionType(string value) => new CompositionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CompositionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CompositionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
