// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.TestFramework;
using Moq;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// Provides extensions on various classes for getting <see cref="Core.Cryptography"/>
    /// type implementations for use in testing.
    /// </summary>
    public static class ClientSideEncryptionTestExtensions
    {
        public const string s_algorithmName = "some algorithm name";

        public static byte[] GenerateKeyBytes(this RecordedTestBase testBase)
        {
            const int keySizeBits = 256;
            var bytes = new byte[keySizeBits >> 3];
            testBase.Recording.Random.NextBytes(bytes);
            return bytes;
        }

        public static string GenerateKeyId(this RecordedTestBase testBase)
        {
            return testBase.Recording.Random.NewGuid().ToString();
        }

        public static Mock<IKeyEncryptionKey> GetIKeyEncryptionKey(
            this RecordedTestBase testBase,
            CancellationToken? expectedCancellationToken,
            byte[] userKeyBytes = default,
            string keyId = default,
            TimeSpan optionalDelay = default)
        {
            userKeyBytes ??= GenerateKeyBytes(testBase);
            keyId ??= GenerateKeyId(testBase);

            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.KeyId).Returns(keyId);
            if (testBase.IsAsync)
            {
                keyMock.Setup(k => k.WrapKeyAsync(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>(async (algorithm, key, cancellationToken) =>
                    {
                        await Task.Delay(optionalDelay);
                        return KeyWrapImpl(userKeyBytes, key.ToArray());
                    });
                keyMock.Setup(k => k.UnwrapKeyAsync(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>(async (algorithm, wrappedKey, cancellationToken) =>
                    {
                        await Task.Delay(optionalDelay);
                        return KeyUnwrapImpl(userKeyBytes, wrappedKey.ToArray());
                    });
            }
            else
            {
                keyMock.Setup(k => k.WrapKey(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, key, cancellationToken) =>
                    {
                        Thread.Sleep(optionalDelay);
                        return KeyWrapImpl(userKeyBytes, key.ToArray());
                    });
                keyMock.Setup(k => k.UnwrapKey(s_algorithmName, It.IsNotNull<ReadOnlyMemory<byte>>(), It.IsAny<CancellationToken>()))
                    .Returns<string, ReadOnlyMemory<byte>, CancellationToken>((algorithm, wrappedKey, cancellationToken) =>
                    {
                        Thread.Sleep(optionalDelay);
                        return KeyUnwrapImpl(userKeyBytes, wrappedKey.ToArray());
                    });
            }

            return keyMock;
        }

        public static Mock<IKeyEncryptionKeyResolver> GetIKeyEncryptionKeyResolver(
            this RecordedTestBase testBase,
            CancellationToken? expectedCancellationToken,
            params IKeyEncryptionKey[] keys)
        {
            IKeyEncryptionKey Resolve(string keyId, CancellationToken cancellationToken)
                => keys.FirstOrDefault(k => k.KeyId == keyId) ?? throw new Exception("Mock resolver couldn't resolve key id.");

            var resolverMock = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            if (testBase.IsAsync)
            {
                resolverMock.Setup(r => r.ResolveAsync(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, CancellationToken>((keyId, cancellationToken) => Task.FromResult(Resolve(keyId, cancellationToken)));
            }
            else
            {
                resolverMock.Setup(r => r.Resolve(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                    .Returns<string, CancellationToken>(Resolve);
                ;
            }

            return resolverMock;
        }

        public static Mock<IKeyEncryptionKeyResolver> GetAlwaysFailsKeyResolver(this RecordedTestBase testBase, CancellationToken? expectedCancellationToken, bool throws)
        {
            var mock = new Mock<IKeyEncryptionKeyResolver>(MockBehavior.Strict);
            if (testBase.IsAsync)
            {
                if (throws)
                {
                    mock.Setup(r => r.ResolveAsync(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                        .Throws<Exception>();
                }
                else
                {
                    mock.Setup(r => r.ResolveAsync(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                        .Returns(Task.FromResult<IKeyEncryptionKey>(null));
                }
            }
            else
            {
                if (throws)
                {
                    mock.Setup(r => r.Resolve(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                        .Throws<Exception>();
                }
                else
                {
                    mock.Setup(r => r.Resolve(It.IsNotNull<string>(), expectedCancellationToken ?? It.IsAny<CancellationToken>()))
                        .Returns((IKeyEncryptionKey)null);
                }
            }

            return mock;
        }

        public static Mock<Microsoft.Azure.KeyVault.Core.IKey> GetTrackOneIKey(this RecordedTestBase testBase, byte[] userKeyBytes = default, string keyId = default)
        {
            if (userKeyBytes == default)
            {
                const int keySizeBits = 256;
                var bytes = new byte[keySizeBits >> 3];
#if NET6_0_OR_GREATER
                RandomNumberGenerator.Create().GetBytes(bytes);
#else
                new RNGCryptoServiceProvider().GetBytes(bytes);
#endif
                userKeyBytes = bytes;
            }
            keyId ??= Guid.NewGuid().ToString();

            var keyMock = new Mock<Microsoft.Azure.KeyVault.Core.IKey>(MockBehavior.Strict);
            keyMock.SetupGet(k => k.Kid).Returns(keyId);
            keyMock.SetupGet(k => k.DefaultKeyWrapAlgorithm).Returns(s_algorithmName);
            // track one had async-only key wrapping
            keyMock.Setup(k => k.WrapKeyAsync(It.IsNotNull<byte[]>(), It.IsAny<string>(), It.IsNotNull<CancellationToken>())) // track 1 doesn't pass in the algorithm name, it lets the implementation return the default algorithm it chose
                .Returns<byte[], string, CancellationToken>((key, algorithm, cancellationToken) => Task.FromResult(
                    Tuple.Create(KeyWrapImpl(userKeyBytes, key), s_algorithmName)));
            keyMock.Setup(k => k.UnwrapKeyAsync(It.IsNotNull<byte[]>(), s_algorithmName, It.IsNotNull<CancellationToken>()))
                .Returns<byte[], string, CancellationToken>((wrappedKey, algorithm, cancellationToken) => Task.FromResult(
                    KeyUnwrapImpl(userKeyBytes, wrappedKey)));

            return keyMock;
        }

        public static Mock<Microsoft.Azure.KeyVault.Core.IKeyResolver> GetTrackOneIKeyResolver(this RecordedTestBase testBase, Microsoft.Azure.KeyVault.Core.IKey iKey)
        {
            var resolverMock = new Mock<Microsoft.Azure.KeyVault.Core.IKeyResolver>(MockBehavior.Strict);
            resolverMock.Setup(r => r.ResolveKeyAsync(It.IsNotNull<string>(), It.IsNotNull<CancellationToken>())) // track 1 doesn't pass in the same cancellation token?
                .Returns<string, CancellationToken>((keyId, cancellationToken) => iKey?.Kid == keyId ? Task.FromResult(iKey) : throw new Exception("Mock resolver couldn't resolve key id."));

            return resolverMock;
        }

        private static byte[] KeyWrapImpl(byte[] key, byte[] contents)
        {
            var result = new byte[contents.Length];

            if (contents.Length == 0) return result;

            // Move each byte one position to the left
            new Span<byte>(contents, 1, contents.Length - 1).CopyTo(result);

            // Fill the last byte with the first byte (loop-around)
            result[contents.Length - 1] = contents[0];

            return result;
        }

        private static byte[] KeyUnwrapImpl(byte[] key, byte[] contents)
        {
            var result = new byte[contents.Length];

            if (contents.Length == 0) return result;

            // Move each byte one position to the right
            new Span<byte>(contents, 0, contents.Length - 1).CopyTo(new Span<byte>(result, 1, result.Length - 1));

            // Fill the first byte with the last byte (loop-around)
            result[0] = contents[contents.Length - 1];

            return result;
        }
    }
}
