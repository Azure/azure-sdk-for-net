// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </summary>
    public readonly partial struct MySqlPublicNetworkAccessEnum : IEquatable<MySqlPublicNetworkAccessEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlPublicNetworkAccessEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlPublicNetworkAccessEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "Enabled";
        private const string DisabledValue = "Disabled";

        /// <summary> Enabled. </summary>
        public static MySqlPublicNetworkAccessEnum Enabled { get; } = new MySqlPublicNetworkAccessEnum(EnabledValue);
        /// <summary> Disabled. </summary>
        public static MySqlPublicNetworkAccessEnum Disabled { get; } = new MySqlPublicNetworkAccessEnum(DisabledValue);
        /// <summary> Determines if two <see cref="MySqlPublicNetworkAccessEnum"/> values are the same. </summary>
        public static bool operator ==(MySqlPublicNetworkAccessEnum left, MySqlPublicNetworkAccessEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlPublicNetworkAccessEnum"/> values are not the same. </summary>
        public static bool operator !=(MySqlPublicNetworkAccessEnum left, MySqlPublicNetworkAccessEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlPublicNetworkAccessEnum"/>. </summary>
        public static implicit operator MySqlPublicNetworkAccessEnum(string value) => new MySqlPublicNetworkAccessEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlPublicNetworkAccessEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlPublicNetworkAccessEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}