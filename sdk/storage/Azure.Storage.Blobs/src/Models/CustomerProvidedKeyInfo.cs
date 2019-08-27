// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Wrapper for an encryption key to be used with client provided key encryption.
    /// </summary>
    public struct CustomerProvidedKeyInfo : IEquatable<CustomerProvidedKeyInfo>
    {
        /// <summary>
        /// Base64 encoded string of the encryption key.
        /// </summary>
        public string EncryptionKey { get; internal set; }

        /// <summary>
        /// Base64 encoded string of the encryption key's SHA256 hash.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// The algorithm for Azure Blob Storage to encrypt with.
        /// Azure Blob Storage only offers AES256 encryption.
        /// </summary>
        public EncryptionAlgorithmType EncryptionAlgorithm { get; internal set; }

        /// <summary>
        /// Creates a new wrapper for a client provided key.
        /// </summary>
        /// <param name="key">The encryption key encoded as a base64 string.</param>
        public CustomerProvidedKeyInfo(string key)
        {
            this.EncryptionKey = key;
            this.EncryptionAlgorithm = EncryptionAlgorithmType.AES256;
            using var sha256 = SHA256.Create();
            var encodedHash = sha256.ComputeHash(Convert.FromBase64String(key));
            this.EncryptionKeySha256 = Convert.ToBase64String(encodedHash);
        }

        /// <summary>
        /// Creates a new wrapper for a client provided key.
        /// </summary>
        /// <param name="key">The encryption key bytes.</param>
        public CustomerProvidedKeyInfo(byte[] key)
        {
            this.EncryptionKey = Convert.ToBase64String(key);
            this.EncryptionAlgorithm = EncryptionAlgorithmType.AES256;
            using var sha256 = SHA256.Create();
            this.EncryptionKeySha256 = Convert.ToBase64String(sha256.ComputeHash(key));
        }

        /// <summary>
        /// Checks if two CustomerProvidedKeyInfo are equal to each other.
        /// </summary>
        /// <param name="obj">The other instance to compare to.</param>
        public override bool Equals(object obj)
            => obj is CustomerProvidedKeyInfo other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the CustomerProvidedKeyInfo.
        /// </summary>
        /// <returns>Hash code for the CustomerProvidedKeyInfo.</returns>
        public override int GetHashCode()
            => this.EncryptionKey.GetHashCode()
            ^ this.EncryptionKeySha256.GetHashCode()
            ^ this.EncryptionAlgorithm.GetHashCode()
            ;

        /// <summary>
        /// Check if two CustomerProvidedKeyInfo instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(CustomerProvidedKeyInfo left, CustomerProvidedKeyInfo right) => left.Equals(right);

        /// <summary>
        /// Check if two CustomerProvidedKeyInfo instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(CustomerProvidedKeyInfo left, CustomerProvidedKeyInfo right) => !(left == right);

        /// <summary>
        /// Checks if two CustomerProvidedKeyInfo are equal to each other.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns></returns>
        public bool Equals(CustomerProvidedKeyInfo other)
         => this.EncryptionKey == other.EncryptionKey
            && this.EncryptionKeySha256 == other.EncryptionKeySha256
            && this.EncryptionAlgorithm == other.EncryptionAlgorithm
            ;

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
            => $"[{nameof(CustomerProvidedKeyInfo)}:{nameof(this.EncryptionKey)}={this.EncryptionKey};{nameof(this.EncryptionKeySha256)}={this.EncryptionKeySha256};{nameof(this.EncryptionAlgorithm)}={this.EncryptionAlgorithm}]";
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new CustomerProvidedKeyInfo instance for mocking.
        /// </summary>
        public static CustomerProvidedKeyInfo CustomerProvidedKeyInfo(
            string encryptionKey,
            string encryptionKeySha256,
            EncryptionAlgorithmType encryptionAlgorithm) => new CustomerProvidedKeyInfo()
            {
                EncryptionKey = encryptionKey,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionAlgorithm = encryptionAlgorithm
            };

    }
}
