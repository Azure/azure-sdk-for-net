// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    public readonly partial struct KeyVaultRoleType
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultRoleType"/> structure.
        /// </summary>
        /// <param name="value">The role type value.</param>
        public KeyVaultRoleType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Built-in role.
        /// </summary>
        public static KeyVaultRoleType BuiltInRole { get; } = new KeyVaultRoleType("AKVBuiltInRole");

        /// <summary>
        /// Custom role.
        /// </summary>
        public static KeyVaultRoleType CustomRole { get; } = new KeyVaultRoleType("CustomRole");

        /// <summary>
        /// Returns the string representation of the role type.
        /// </summary>
        public override string ToString() => _value;

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        public static implicit operator KeyVaultRoleType(string value) => new KeyVaultRoleType(value);

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        public static implicit operator string(KeyVaultRoleType roleType) => roleType._value;

        /// <summary>
        /// Determines if two values are equal.
        /// </summary>
        public static bool operator ==(KeyVaultRoleType left, KeyVaultRoleType right) => left._value == right._value;

        /// <summary>
        /// Determines if two values are not equal.
        /// </summary>
        public static bool operator !=(KeyVaultRoleType left, KeyVaultRoleType right) => left._value != right._value;

        /// <summary>
        /// Determines if this instance and a specified object are equal.
        /// </summary>
        public override bool Equals(object obj) => obj is KeyVaultRoleType other && _value == other._value;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    }
}
