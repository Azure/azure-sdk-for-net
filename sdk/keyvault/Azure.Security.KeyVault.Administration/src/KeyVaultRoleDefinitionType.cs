// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    public readonly partial struct KeyVaultRoleDefinitionType
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultRoleDefinitionType"/> structure.
        /// </summary>
        /// <param name="value">The role definition type value.</param>
        public KeyVaultRoleDefinitionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Microsoft-defined role definitions.
        /// </summary>
        public static KeyVaultRoleDefinitionType MicrosoftAuthorizationRoleDefinitions { get; } = new KeyVaultRoleDefinitionType("Microsoft.Authorization/roleDefinitions");

        /// <summary>
        /// Returns the string representation of the role definition type.
        /// </summary>
        public override string ToString() => _value;

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        public static implicit operator KeyVaultRoleDefinitionType(string value) => new KeyVaultRoleDefinitionType(value);

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        public static implicit operator string(KeyVaultRoleDefinitionType roleDefinitionType) => roleDefinitionType._value;

        /// <summary>
        /// Determines if two values are equal.
        /// </summary>
        public static bool operator ==(KeyVaultRoleDefinitionType left, KeyVaultRoleDefinitionType right) => left._value == right._value;

        /// <summary>
        /// Determines if two values are not equal.
        /// </summary>
        public static bool operator !=(KeyVaultRoleDefinitionType left, KeyVaultRoleDefinitionType right) => left._value != right._value;

        /// <summary>
        /// Determines if this instance and a specified object are equal.
        /// </summary>
        public override bool Equals(object obj) => obj is KeyVaultRoleDefinitionType other && _value == other._value;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    }
}
