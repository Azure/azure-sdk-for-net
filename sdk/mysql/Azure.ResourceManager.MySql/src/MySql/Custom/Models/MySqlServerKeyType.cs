// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The key type like 'AzureKeyVault'. </summary>
    public readonly partial struct MySqlServerKeyType : IEquatable<MySqlServerKeyType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlServerKeyType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlServerKeyType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureKeyVaultValue = "AzureKeyVault";

        /// <summary> AzureKeyVault. </summary>
        public static MySqlServerKeyType AzureKeyVault { get; } = new MySqlServerKeyType(AzureKeyVaultValue);
        /// <summary> Determines if two <see cref="MySqlServerKeyType"/> values are the same. </summary>
        public static bool operator ==(MySqlServerKeyType left, MySqlServerKeyType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlServerKeyType"/> values are not the same. </summary>
        public static bool operator !=(MySqlServerKeyType left, MySqlServerKeyType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlServerKeyType"/>. </summary>
        public static implicit operator MySqlServerKeyType(string value) => new MySqlServerKeyType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlServerKeyType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlServerKeyType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}