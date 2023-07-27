// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Infrastructure.Models.ClientSideEncryption
{
    /// <summary>
    /// Local <see cref="IKeyEncryptionKey"/> mock implementation for performance testing
    /// client-side encryption. This not be accurate of end-to-end performance when using
    /// a real implementation.
    /// <para/>
    /// This class does not use a secure keywrap. It just NOTs the bits for a reversable
    /// transformation. This should only be used for mocking out a real keystore for the
    /// purposes of testing.
    /// </summary>
    internal class LocalKeyEncryptionKey : IKeyEncryptionKey
    {
        public string KeyId => "Azure.Storage.Blobs.Perf.Infrastructure.Models.ClientSideEncryption.LocalKeyEncryptionKey static mocked key";

        public byte[] UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            return Not(encryptedKey.ToArray());
        }

        public Task<byte[]> UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Not(encryptedKey.ToArray()));
        }

        public byte[] WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            return Not(key.ToArray());
        }

        public Task<byte[]> WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Not(key.ToArray()));
        }

        private static byte[] Not(byte[] contents)
        {
            var result = new byte[contents.Length];
            // just bitflip the contents
            new System.Collections.BitArray(contents).Not().CopyTo(result, 0);

            return result;
        }
    }
}