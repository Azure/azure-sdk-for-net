// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// Mock for a key encryption key. Not meant for production use.
    /// </summary>
    internal class MockKeyEncryptionKey : IKeyEncryptionKey, IKeyEncryptionKeyResolver
    {
        public ReadOnlyMemory<byte> KeyEncryptionKey { get; }

        public string KeyId { get; }

        /// <summary>
        /// Generates a key encryption key with the given properties.
        /// </summary>
        public MockKeyEncryptionKey(int keySizeBits = 256, string keyId = default)
        {
            KeyId = keyId ?? Guid.NewGuid().ToString();
            using (var random = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[keySizeBits >> 3];
                random.GetBytes(bytes);
                KeyEncryptionKey = bytes;
            }
        }

        public Memory<byte> UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            return Xor(encryptedKey.ToArray(), KeyEncryptionKey.ToArray());
        }

        public Task<Memory<byte>> UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(UnwrapKey(algorithm, encryptedKey, cancellationToken));
        }

        public Memory<byte> WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            return Xor(key.ToArray(), KeyEncryptionKey.ToArray());
        }

        public Task<Memory<byte>> WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(WrapKey(algorithm, key, cancellationToken));
        }

        private static byte[] Xor(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException("Keys must be the same length for this mock implementation.");
            }

            var aBits = new BitArray(a);
            var bBits = new BitArray(b);

            var result = new byte[a.Length];
            aBits.Xor(bBits).CopyTo(result, 0);

            return result;
        }

        public IKeyEncryptionKey Resolve(string keyId, CancellationToken cancellationToken = default)
        {
            if (keyId != this.KeyId.ToString())
            {
                throw new ArgumentException("Mock key resolver cannot find this keyId.");
            }

            return this;
        }

        public Task<IKeyEncryptionKey> ResolveAsync(string keyId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Resolve(keyId, cancellationToken));
        }
    }
}
