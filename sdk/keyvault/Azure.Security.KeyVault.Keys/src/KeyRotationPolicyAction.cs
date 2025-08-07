// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The action that will be executed when key rotation is triggered.
    /// </summary>
    public readonly struct KeyRotationPolicyAction : IEquatable<KeyRotationPolicyAction>
    {
        internal const string NotifyValue = "Notify";
        internal const string RotateValue = "Rotate";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRotationPolicyAction"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public KeyRotationPolicyAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a <see cref="KeyRotationPolicyAction"/> that will trigger event grid events.
        /// </summary>
        public static KeyRotationPolicyAction Notify { get; } = new KeyRotationPolicyAction(NotifyValue);

        /// <summary>
        /// Gets a <see cref="KeyRotationPolicyAction"/> action that will rotate the key based on the key policy.
        /// </summary>
        public static KeyRotationPolicyAction Rotate { get; } = new KeyRotationPolicyAction(RotateValue);

        /// <summary>
        /// Determines if two <see cref="KeyRotationPolicyAction"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyRotationPolicyAction"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyRotationPolicyAction"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyRotationPolicyAction left, KeyRotationPolicyAction right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyRotationPolicyAction"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyRotationPolicyAction"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyRotationPolicyAction"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyRotationPolicyAction left, KeyRotationPolicyAction right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="KeyRotationPolicyAction"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyRotationPolicyAction(string value) => new(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyRotationPolicyAction other && Equals(other);

        /// <inheritdoc/>
        // Comparison is case-insensitive due to https://github.com/Azure/azure-rest-api-specs/pull/24475.
        public bool Equals(KeyRotationPolicyAction other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Comparison is case-insensitive due to https://github.com/Azure/azure-rest-api-specs/pull/24475.
        public override int GetHashCode() => _value?.ToLowerInvariant().GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
