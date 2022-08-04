// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Wrapper for an encryption key to be used with client provided key server-side encryption.
    /// Note that encryption is applied is applied on a per-file basis.
    /// </summary>
    public readonly struct DataLakeCustomerProvidedKey : IEquatable<DataLakeCustomerProvidedKey>
    {
        /// <summary>
        /// Base64 encoded string of the AES256 encryption key.
        /// </summary>
        public readonly string EncryptionKey { get; }

        /// <summary>
        /// Base64 encoded string of the AES256 encryption key's SHA256 hash.
        /// </summary>
        public readonly string EncryptionKeyHash { get; }

        /// <summary>
        /// The algorithm for Azure Blob Storage to encrypt with.
        /// Azure Blob Storage only offers AES256 encryption.
        /// </summary>
        public readonly DataLakeEncryptionAlgorithmType EncryptionAlgorithm { get; }

        /// <summary>
        /// Creates a new CustomerProvidedKey for use in server-side encryption.
        /// </summary>
        /// <param name="key">The encryption key encoded as a base64 string.</param>
        public DataLakeCustomerProvidedKey(string key)
        {
            EncryptionKey = key;
            EncryptionAlgorithm = DataLakeEncryptionAlgorithmType.Aes256;
            using var sha256 = SHA256.Create();
            var encodedHash = sha256.ComputeHash(Convert.FromBase64String(key));
            EncryptionKeyHash = Convert.ToBase64String(encodedHash);
        }

        /// <summary>
        /// Creates a new CustomerProvidedKey for use in server-side encryption.
        /// </summary>
        /// <param name="key">The encryption key bytes.</param>
        public DataLakeCustomerProvidedKey(byte[] key) : this(Convert.ToBase64String(key)) { }

        /// <summary>
        /// Checks if two CustomerProvidedKeyInfo are equal to each other.
        /// </summary>
        /// <param name="obj">The other instance to compare to.</param>
        public override bool Equals(object obj)
            => obj is DataLakeCustomerProvidedKey other && Equals(other);

        /// <summary>
        /// Get a hash code for the CustomerProvidedKeyInfo.
        /// </summary>
        /// <returns>Hash code for the CustomerProvidedKeyInfo.</returns>
        public override int GetHashCode()
            => EncryptionKey.GetHashCode()
            ^ EncryptionKeyHash.GetHashCode()
            ^ EncryptionAlgorithm.GetHashCode()
            ;

        /// <summary>
        /// Check if two CustomerProvidedKeyInfo instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(DataLakeCustomerProvidedKey left, DataLakeCustomerProvidedKey right) => left.Equals(right);

        /// <summary>
        /// Check if two CustomerProvidedKeyInfo instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(DataLakeCustomerProvidedKey left, DataLakeCustomerProvidedKey right) => !(left == right);

        /// <summary>
        /// Checks if two CustomerProvidedKeyInfo are equal to each other.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns></returns>
        public bool Equals(DataLakeCustomerProvidedKey other)
         => EncryptionKey == other.EncryptionKey
            && EncryptionKeyHash == other.EncryptionKeyHash
            && EncryptionAlgorithm == other.EncryptionAlgorithm
            ;

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
            => $"[{nameof(DataLakeCustomerProvidedKey)}:{nameof(EncryptionKey)}={EncryptionKey};{nameof(EncryptionKeyHash)}={EncryptionKeyHash};{nameof(EncryptionAlgorithm)}={EncryptionAlgorithm}]";
    }
}
