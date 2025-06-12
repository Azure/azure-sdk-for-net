// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    public readonly partial struct KeyVaultRoleScope
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultRoleScope"/> structure.
        /// </summary>
        /// <param name="resourceId">The Resource Id for the given Resource.</param>
        public KeyVaultRoleScope(Uri resourceId)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            // Remove the version segment from a Key Id, if present.
            string[] segments = resourceId.Segments;

            if (resourceId.AbsolutePath.StartsWith("/keys/", StringComparison.Ordinal) && segments.Length == 4)
            {
                _value = resourceId.AbsolutePath.Remove(resourceId.AbsolutePath.Length - segments[3].Length - 1);
            }
            else
            {
                _value = resourceId.AbsolutePath;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultRoleScope"/> structure.
        /// </summary>
        /// <param name="value">The scope value.</param>
        public KeyVaultRoleScope(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// The global scope ("/").
        /// </summary>
        public static KeyVaultRoleScope Global { get; } = new KeyVaultRoleScope("/");

        /// <summary>
        /// The keys scope ("/keys").
        /// </summary>
        public static KeyVaultRoleScope Keys { get; } = new KeyVaultRoleScope("/keys");

        /// <summary>
        /// Returns the string representation of the scope.
        /// </summary>
        public override string ToString() => _value;

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        public static implicit operator KeyVaultRoleScope(string value) => new KeyVaultRoleScope(value);

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        public static implicit operator string(KeyVaultRoleScope scope) => scope._value;

        /// <summary>
        /// Determines if two values are equal.
        /// </summary>
        public static bool operator ==(KeyVaultRoleScope left, KeyVaultRoleScope right) => left._value == right._value;

        /// <summary>
        /// Determines if two values are not equal.
        /// </summary>
        public static bool operator !=(KeyVaultRoleScope left, KeyVaultRoleScope right) => left._value != right._value;

        /// <summary>
        /// Determines if this instance and a specified object are equal.
        /// </summary>
        public override bool Equals(object obj) => obj is KeyVaultRoleScope other && _value == other._value;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
     }
}
