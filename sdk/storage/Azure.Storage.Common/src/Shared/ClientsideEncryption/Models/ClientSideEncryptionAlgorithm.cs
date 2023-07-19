// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Cryptography.Models
{
    /// <summary>
    /// Specifies the encryption algorithm used to encrypt and decrypt a blob.
    /// </summary>
    internal readonly struct ClientSideEncryptionAlgorithm
    {
        internal const string AesCbc256Value = "AES_CBC_256";

        internal const string AesGcm256Value = "AES_GCM_256";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSideEncryptionAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public ClientSideEncryptionAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// AES-CBC using a 256 bit key.
        /// </summary>
        public static ClientSideEncryptionAlgorithm AesCbc256 { get; } = new ClientSideEncryptionAlgorithm(AesCbc256Value);

        /// <summary>
        /// AES-GCM using a 256 bit key.
        /// </summary>
        public static ClientSideEncryptionAlgorithm AesGcm256 { get; } = new ClientSideEncryptionAlgorithm(AesGcm256Value);

        /// <summary>
        /// Determines if two <see cref="ClientSideEncryptionAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="ClientSideEncryptionAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="ClientSideEncryptionAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(ClientSideEncryptionAlgorithm left, ClientSideEncryptionAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ClientSideEncryptionAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ClientSideEncryptionAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="ClientSideEncryptionAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(ClientSideEncryptionAlgorithm left, ClientSideEncryptionAlgorithm right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="ClientSideEncryptionAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator ClientSideEncryptionAlgorithm(string value) => new ClientSideEncryptionAlgorithm(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ClientSideEncryptionAlgorithm other && Equals(other);

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="ClientSideEncryptionAlgorithm"/> are equal
        /// </summary>
        public bool Equals(ClientSideEncryptionAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
