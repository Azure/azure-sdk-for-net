// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class AesGcmTests
    {
        private static readonly RandomNumberGenerator s_rng = RandomNumberGenerator.Create();

        [TestCase(128)]
        [TestCase(192)]
        [TestCase(256)]
        public void EncryptDecryptRoundtrip(int keySize)
        {
            byte[] k = Create(keySize >> 3);
            if (!AesGcmProxy.TryCreate(k, out AesGcmProxy aes))
            {
                Assert.Ignore($"Cannot create AesGcm on {RuntimeInformation.FrameworkDescription} on {RuntimeInformation.OSDescription}");
            }

            byte[] iv = Create(12);
            byte[] tag = Create(16, empty: true);
            byte[] aad = Create(16);

            byte[] plaintext = Create(1024 >> 3);
            byte[] ciphertext = Create(plaintext.Length, empty: true);

            aes.Encrypt(iv, plaintext, ciphertext, tag, aad);

            byte[] decrypted = Create(plaintext.Length, empty: true);
            aes.Decrypt(iv, ciphertext, tag, decrypted, aad);

            CollectionAssert.AreEqual(plaintext, decrypted);
        }

        private static byte[] Create(int byteSize, bool empty = false)
        {
            byte[] buffer = (byte[])Array.CreateInstance(typeof(byte), byteSize);
            if (!empty)
            {
                s_rng.GetBytes(buffer);
            }

            return buffer;
        }
    }
}
