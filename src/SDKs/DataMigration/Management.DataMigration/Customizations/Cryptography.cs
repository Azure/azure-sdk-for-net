// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cryptography.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.Management.DataMigration
{
    /// <summary>
    /// Provides helper methods for performing RSA encryption
    /// </summary>
    public static class Cryptography
    {
        /// <summary>Encrypts binary data.</summary>
        /// <param name="key">The public key used for encryption.</param>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>Returns the encrypted ciphertext as a base64-encoded string.</returns>
        public static string Encrypt(string key, string plaintext)
        {
            if (plaintext == null) { throw new ArgumentNullException("plaintext"); }
            return Convert.ToBase64String(Encrypt(key, Encoding.UTF8.GetBytes(plaintext)));
        }

        private static byte[] Encrypt(string key, byte[] plaintext)
        {
            if (plaintext == null) { throw new ArgumentNullException("plaintext"); }
            RSAParameters rsaKey = DeserializePublicKey(key);
#if NETSTANDARD1_4
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(rsaKey);
                return rsa.Encrypt(plaintext, RSAEncryptionPadding.Pkcs1);
            }
#else
            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                rsaProvider.ImportParameters(rsaKey);
                return rsaProvider.Encrypt(plaintext, true);
            }
#endif
        }

        private static RSAParameters DeserializePublicKey(string key)
        {
            if (key == null) { throw new ArgumentNullException("key"); }
            var parts = key.Split(';');
            if (parts.Length != 3) { throw new FormatException(); } // public key should have 3 parts
            if (parts[0] != "0") { throw new NotSupportedException("Unsupported key version."); }
            return new RSAParameters() { Exponent = Convert.FromBase64String(parts[1]), Modulus = Convert.FromBase64String(parts[2]) };
        }
    }
}