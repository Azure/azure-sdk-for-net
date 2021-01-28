// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// An operation that can be performed with the key.
    /// </summary>
    public readonly struct KeyOperation : IEquatable<KeyOperation>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyOperation"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public KeyOperation(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a value that indicates the key can be used to encrypt with the <see cref="CryptographyClient.EncryptAsync(EncryptionAlgorithm, byte[], CancellationToken)"/> or <see cref="CryptographyClient.Encrypt(EncryptionAlgorithm, byte[], CancellationToken)"/> methods.
        /// </summary>
        public static KeyOperation Encrypt { get; } = new KeyOperation("encrypt");

        /// <summary>
        /// Gets a value that indicates the key can be used to decrypt with the <see cref="CryptographyClient.DecryptAsync(EncryptionAlgorithm, byte[], CancellationToken)"/> or <see cref="CryptographyClient.Decrypt(EncryptionAlgorithm, byte[], CancellationToken)"/> methods.
        /// </summary>
        public static KeyOperation Decrypt { get; } = new KeyOperation("decrypt");

        /// <summary>
        /// Gets a value that indicates the key can be used to sign with the <see cref="CryptographyClient.SignAsync"/> or <see cref="CryptographyClient.Sign"/> methods.
        /// </summary>
        public static KeyOperation Sign { get; } = new KeyOperation("sign");

        /// <summary>
        /// Gets a value that indicates the key can be used to verify with the <see cref="CryptographyClient.VerifyAsync"/> or <see cref="CryptographyClient.Verify"/> methods.
        /// </summary>
        public static KeyOperation Verify { get; } = new KeyOperation("verify");

        /// <summary>
        /// Gets a value that indicates the key can be used to wrap another key with the <see cref="CryptographyClient.WrapKeyAsync"/> or <see cref="CryptographyClient.WrapKey"/> methods.
        /// </summary>
        public static KeyOperation WrapKey { get; } = new KeyOperation("wrapKey");

        /// <summary>
        /// Gets a value that indicates the key can be used to unwrap another key with the <see cref="CryptographyClient.UnwrapKeyAsync"/> or <see cref="CryptographyClient.UnwrapKey"/> methods.
        /// </summary>
        public static KeyOperation UnwrapKey { get; } = new KeyOperation("unwrapKey");

        /// <summary>
        /// Gets a value that indicates the key can be imported during creation using the <see cref="KeyClient.ImportKeyAsync(ImportKeyOptions, CancellationToken)"/> or <see cref="KeyClient.ImportKey(ImportKeyOptions, CancellationToken)"/> methods.
        /// </summary>
        public static KeyOperation Import { get; } = new KeyOperation("import");

        /// <summary>
        /// Gets a value that indicates the key can be exported using the <see cref="KeyClient.ExportKeyAsync(string, string, CancellationToken)"/> or <see cref="KeyClient.ExportKey(string, string, CancellationToken)"/> methods.
        /// </summary>
        public static KeyOperation Export { get; } = new KeyOperation("export");

        /// <summary>
        /// Determines if two <see cref="KeyOperation"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyOperation"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyOperation"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyOperation left, KeyOperation right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyOperation"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyOperation"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyOperation"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyOperation left, KeyOperation right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="KeyOperation"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyOperation(string value) => new KeyOperation(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyOperation other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyOperation other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
