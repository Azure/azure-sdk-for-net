// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    public readonly partial struct KeyVaultDataAction : IEquatable<KeyVaultDataAction>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultDataAction"/> structure.
        /// </summary>
        /// <param name="value">The string value of the data action.</param>
        public KeyVaultDataAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <inheritdoc/>
        public bool Equals(KeyVaultDataAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is KeyVaultDataAction other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Converts a string to a <see cref="KeyVaultDataAction"/>. </summary>
        public static implicit operator KeyVaultDataAction(string value) => new KeyVaultDataAction(value);
    }
}
