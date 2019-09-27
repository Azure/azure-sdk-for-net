using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;

namespace Azure.Storage.Blobs.Tests
{
    internal class SymmetricKey : IKeyEncryptionKey
    {
        private readonly byte[] Key;

        public Uri KeyId { get; }

        /// <summary>
        /// Randomly generates an insecure symmetric key for testing purposes.
        /// </summary>
        public SymmetricKey(string keyId = default, int keySizeBits = 256)
        {
            KeyId = new Uri($"http//:myaccount.com/{keyId ?? Guid.NewGuid().ToString()}");
            Key = new byte[keySizeBits >> 3];
            new Random().NextBytes(Key);
        }

        public Memory<byte> UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Memory<byte>> UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Memory<byte> WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Memory<byte>> WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
