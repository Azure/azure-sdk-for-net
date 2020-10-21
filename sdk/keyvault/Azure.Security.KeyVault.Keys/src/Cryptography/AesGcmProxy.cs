// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Since System.Security.Cryptography.AesGcm requires targeting netstandard2.1,
    /// for needing this instance only we will proxy calls via reflection instead of multi-targeting.
    /// This feature will light up on netcoreapp3.0 or newer.
    /// </summary>
    internal class AesGcmProxy : IDisposable
    {
        public const int NonceByteSize = 12;

        private static MethodInfo s_decryptMethod;
        private static MethodInfo s_encryptMethod;

        private readonly object _aes;

        private AesGcmProxy(object aes)
        {
            _aes = aes ?? throw new ArgumentNullException(nameof(aes));
        }

        public static bool TryCreate(byte[] key, out AesGcmProxy proxy)
        {
            Type t = typeof(Aes).Assembly.GetType("System.Security.Cryptography.AesGcm", false);
            if (t != null)
            {
                try
                {
                    object aes = Activator.CreateInstance(t, key);

                    proxy = new AesGcmProxy(aes);
                    return true;
                }
                catch
                {
                }
            }

            proxy = null;
            return false;
        }

        public void Decrypt(byte[] nonce, byte[] ciphertext, byte[] tag, byte[] plaintext, byte[] associatedData = default)
        {
            if (s_decryptMethod is null)
            {
                s_decryptMethod = _aes.GetType().GetMethod(nameof(Decrypt), new Type[] { typeof(byte[]), typeof(byte[]), typeof(byte[]), typeof(byte[]), typeof(byte[]) }) ??
                    throw new InvalidOperationException($"{nameof(Decrypt)} method not found");
            }

            s_decryptMethod.Invoke(_aes, new object[] { nonce, ciphertext, tag, plaintext, associatedData });
        }

        public void Encrypt(byte[] nonce, byte[] plaintext, byte[] ciphertext, byte[] tag, byte[] associatedData = default)
        {
            if (s_encryptMethod is null)
            {
                s_encryptMethod = _aes.GetType().GetMethod(nameof(Encrypt), new Type[] { typeof(byte[]), typeof(byte[]), typeof(byte[]), typeof(byte[]), typeof(byte[]) }) ??
                    throw new InvalidOperationException($"{nameof(Encrypt)} method not found");
            }

            s_encryptMethod.Invoke(_aes, new object[] { nonce, plaintext, ciphertext, tag, associatedData });
        }

        public void Dispose() => ((IDisposable)_aes)?.Dispose();
    }
}
