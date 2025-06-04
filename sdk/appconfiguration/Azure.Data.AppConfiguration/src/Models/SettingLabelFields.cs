// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> Fields to retrieve from a label. </summary>
    public readonly partial struct SettingLabelFields : IEquatable<SettingLabelFields>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SettingLabelFields"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SettingLabelFields(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NameValue = "name";

        /// <summary> Name field. </summary>
        public static SettingLabelFields Name { get; } = new SettingLabelFields(NameValue);

        /// <summary> Determines if two <see cref="SettingLabelFields"/> values are the same. </summary>
        public static bool operator ==(SettingLabelFields left, SettingLabelFields right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SettingLabelFields"/> values are not the same. </summary>
        public static bool operator !=(SettingLabelFields left, SettingLabelFields right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SettingLabelFields"/>. </summary>
        public static implicit operator SettingLabelFields(string value) => new SettingLabelFields(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SettingLabelFields other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SettingLabelFields other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
