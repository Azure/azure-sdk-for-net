// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The actions required for private link service connection. </summary>
    public readonly partial struct MySqlPrivateLinkServiceConnectionStateRequiredAction : IEquatable<MySqlPrivateLinkServiceConnectionStateRequiredAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlPrivateLinkServiceConnectionStateRequiredAction"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlPrivateLinkServiceConnectionStateRequiredAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";

        /// <summary> None. </summary>
        public static MySqlPrivateLinkServiceConnectionStateRequiredAction None { get; } = new MySqlPrivateLinkServiceConnectionStateRequiredAction(NoneValue);
        /// <summary> Determines if two <see cref="MySqlPrivateLinkServiceConnectionStateRequiredAction"/> values are the same. </summary>
        public static bool operator ==(MySqlPrivateLinkServiceConnectionStateRequiredAction left, MySqlPrivateLinkServiceConnectionStateRequiredAction right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlPrivateLinkServiceConnectionStateRequiredAction"/> values are not the same. </summary>
        public static bool operator !=(MySqlPrivateLinkServiceConnectionStateRequiredAction left, MySqlPrivateLinkServiceConnectionStateRequiredAction right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlPrivateLinkServiceConnectionStateRequiredAction"/>. </summary>
        public static implicit operator MySqlPrivateLinkServiceConnectionStateRequiredAction(string value) => new MySqlPrivateLinkServiceConnectionStateRequiredAction(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlPrivateLinkServiceConnectionStateRequiredAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlPrivateLinkServiceConnectionStateRequiredAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}