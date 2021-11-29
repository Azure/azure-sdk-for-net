// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.TestFramework;
using Moq;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// Provides extensions on various classes for getting <see cref="Core.Cryptography"/>
    /// type implementations for use in testing.
    /// </summary>
    public static class ClientSideEncryptionTestExtensions
    {
        public const string s_algorithmName = "some algorithm name";

        public static Mock<IKeyEncryptionKey> GetIKeyEncryptionKey(
            this RecordedTestBase testBase,
            byte[] userKeyBytes = default,
            string keyId = default,
            CancellationToken? expectedCancellationToken = default)
        {
            if (userKeyBytes == default)
            {
                const int keySizeBits = 256;
                var bytes = new byte[keySizeBits >> 3];
                new RNGCryptoServiceProvider().GetBytes(bytes);
                userKeyBytes = bytes;
            }
            keyId ??= Guid.NewGuid().ToString();

            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.KeyId).Returns(keyId);
            if (testBase.IsAsync)
            {
                keyMock.Setup(k => k.WrapKeyAsync(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, key, cancellationToken) => Task.FromResult(Xor(userKeyBytes, key.ToArray())));
                keyMock.Setup(k => k.UnwrapKeyAsync(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, wrappedKey, cancellationToken) => Task.FromResult(Xor(userKeyBytes, wrappedKey.ToArray())));
            }
            else
            {
                keyMock.Setup(k => k.WrapKey(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, key, cancellationToken) => Xor(userKeyBytes, key.ToArray()));
                keyMock.Setup(k => k.UnwrapKey(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, wrappedKey, cancellationToken) => Xor(userKeyBytes, wrappedKey.ToArray()));
            }

            return keyMock;
        }

        public static Mock<IKeyEncryptionKeyResolver> GetIKeyEncryptionKeyResolver(
            this RecordedTestBase testBase,
            IKeyEncryptionKey iKey,
            CancellationToken? expectedCancellationToken = default)
        {
            var resolverMock = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            if (testBase.IsAsync)
            {
                resolverMock.Setup(r => r.ResolveAsync(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, CancellationToken>((keyId, cancellationToken) => iKey?.KeyId == keyId ? Task.FromResult(iKey) : throw new Exception("Mock resolver couldn't resolve key id."));
            }
            else
            {
                resolverMock.Setup(r => r.Resolve(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, CancellationToken>((keyId, cancellationToken) => iKey?.KeyId == keyId ? iKey : throw new Exception("Mock resolver couldn't resolve key id."));
            }

            return resolverMock;
        }

        private static byte[] Xor(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException("Keys must be the same length for this mock implementation.");
            }

            var aBits = new System.Collections.BitArray(a);
            var bBits = new System.Collections.BitArray(b);

            var result = new byte[a.Length];
            aBits.Xor(bBits).CopyTo(result, 0);

            return result;
        }
    }
}
