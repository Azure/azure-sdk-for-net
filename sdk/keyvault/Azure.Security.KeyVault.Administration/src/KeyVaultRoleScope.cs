// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// A scope of the role assignment.
    /// </summary>
    public readonly struct KeyVaultRoleScope : IEquatable<KeyVaultRoleScope>
    {
        internal const string GlobalValue = "/";
        internal const string KeysValue = "/keys";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultRoleScope"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public KeyVaultRoleScope(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

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
        /// Role assignments apply to everything on the resource.
        /// </summary>
        public static KeyVaultRoleScope Global { get; } = new KeyVaultRoleScope(GlobalValue);

        /// <summary>
        /// Role assignments apply to all Keys.
        /// </summary>
        public static KeyVaultRoleScope Keys { get; } = new KeyVaultRoleScope(KeysValue);

        /// <summary>
        /// Determines if two <see cref="KeyVaultRoleScope"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyVaultRoleScope"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyVaultRoleScope"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyVaultRoleScope left, KeyVaultRoleScope right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyVaultRoleScope"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyVaultRoleScope"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyVaultRoleScope"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyVaultRoleScope left, KeyVaultRoleScope right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="KeyVaultRoleScope"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyVaultRoleScope(string value) => new KeyVaultRoleScope(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyVaultRoleScope other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyVaultRoleScope other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
