// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Enable Storage Auto Grow. </summary>
    public readonly partial struct MySqlStorageAutogrow : IEquatable<MySqlStorageAutogrow>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlStorageAutogrow"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlStorageAutogrow(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "Enabled";
        private const string DisabledValue = "Disabled";

        /// <summary> Enabled. </summary>
        public static MySqlStorageAutogrow Enabled { get; } = new MySqlStorageAutogrow(EnabledValue);
        /// <summary> Disabled. </summary>
        public static MySqlStorageAutogrow Disabled { get; } = new MySqlStorageAutogrow(DisabledValue);
        /// <summary> Determines if two <see cref="MySqlStorageAutogrow"/> values are the same. </summary>
        public static bool operator ==(MySqlStorageAutogrow left, MySqlStorageAutogrow right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlStorageAutogrow"/> values are not the same. </summary>
        public static bool operator !=(MySqlStorageAutogrow left, MySqlStorageAutogrow right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlStorageAutogrow"/>. </summary>
        public static implicit operator MySqlStorageAutogrow(string value) => new MySqlStorageAutogrow(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlStorageAutogrow other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlStorageAutogrow other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}