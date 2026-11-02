// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class ClientSideEncryptionIvShortReadTests
    {
        private const string KeyWrapAlgorithm = "test-wrap";
        private const int MaxBytesPerRead = 8;

        [Test]
        public void DecryptRead_V1_IvInStream_ShortReads_DecryptsOriginal_Sync()
        {
            (byte[] expectedPlaintext, Stream ciphertext, ClientSideDecryptor decryptor, EncryptionData encryptionData) =
                CreateV1IvInStreamScenario();

            using Stream limitedCiphertext = new LimitedReadStream(ciphertext, MaxBytesPerRead);
            Stream plaintext = decryptor.DecryptReadInternal(
                limitedCiphertext,
                encryptionData,
                ivInStream: true,
                noPadding: false,
                initialAuthRegion: 0,
                async: false,
                CancellationToken.None).GetAwaiter().GetResult();

            using MemoryStream decrypted = new MemoryStream();
            plaintext.CopyTo(decrypted);

            Assert.AreEqual(expectedPlaintext, decrypted.ToArray());
        }

        [Test]
        public async Task DecryptRead_V1_IvInStream_ShortReads_DecryptsOriginal_Async()
        {
            (byte[] expectedPlaintext, Stream ciphertext, ClientSideDecryptor decryptor, EncryptionData encryptionData) =
                CreateV1IvInStreamScenario();

            using Stream limitedCiphertext = new LimitedReadStream(ciphertext, MaxBytesPerRead);
            Stream plaintext = await decryptor.DecryptReadInternal(
                limitedCiphertext,
                encryptionData,
                ivInStream: true,
                noPadding: false,
                initialAuthRegion: 0,
                async: true,
                CancellationToken.None).ConfigureAwait(false);

            using MemoryStream decrypted = new MemoryStream();
            await plaintext.CopyToAsync(decrypted).ConfigureAwait(false);

            Assert.AreEqual(expectedPlaintext, decrypted.ToArray());
        }

        [Test]
        public void DecryptRead_V1_IvInStream_TruncatedIv_Throws_Sync()
        {
            (_, Stream ciphertext, ClientSideDecryptor decryptor, EncryptionData encryptionData) =
                CreateV1IvInStreamScenario();

            byte[] truncatedIv = new byte[MaxBytesPerRead];
            Assert.AreEqual(MaxBytesPerRead, ciphertext.Read(truncatedIv, 0, truncatedIv.Length));

            using Stream truncatedStream = new LimitedReadStream(new MemoryStream(truncatedIv), MaxBytesPerRead);
            InvalidDataException ex = Assert.Throws<InvalidDataException>(() =>
                decryptor.DecryptReadInternal(
                    truncatedStream,
                    encryptionData,
                    ivInStream: true,
                    noPadding: false,
                    initialAuthRegion: 0,
                    async: false,
                    CancellationToken.None).GetAwaiter().GetResult());

            StringAssert.Contains("IV", ex.Message);
        }

        [Test]
        public void DecryptRead_V1_IvInStream_TruncatedIv_Throws_Async()
        {
            (_, Stream ciphertext, ClientSideDecryptor decryptor, EncryptionData encryptionData) =
                CreateV1IvInStreamScenario();

            byte[] truncatedIv = new byte[MaxBytesPerRead];
            Assert.AreEqual(MaxBytesPerRead, ciphertext.Read(truncatedIv, 0, truncatedIv.Length));

            using Stream truncatedStream = new LimitedReadStream(new MemoryStream(truncatedIv), MaxBytesPerRead);
            InvalidDataException ex = Assert.ThrowsAsync<InvalidDataException>(async () =>
                await decryptor.DecryptReadInternal(
                    truncatedStream,
                    encryptionData,
                    ivInStream: true,
                    noPadding: false,
                    initialAuthRegion: 0,
                    async: true,
                    CancellationToken.None).ConfigureAwait(false));

            StringAssert.Contains("IV", ex.Message);
        }

        private static (byte[] ExpectedPlaintext, Stream Ciphertext, ClientSideDecryptor Decryptor, EncryptionData EncryptionData)
            CreateV1IvInStreamScenario()
        {
            byte[] fullPlaintext = new byte[48];
            for (int i = 0; i < fullPlaintext.Length; i++)
            {
                fullPlaintext[i] = (byte)(i + 1);
            }

            byte[] contentEncryptionKey = new byte[32];
            byte[] contentEncryptionIv = new byte[Constants.ClientSideEncryption.EncryptionBlockSize];
            for (int i = 0; i < contentEncryptionKey.Length; i++)
            {
                contentEncryptionKey[i] = (byte)(200 - i);
            }
            for (int i = 0; i < contentEncryptionIv.Length; i++)
            {
                contentEncryptionIv[i] = (byte)(i + 30);
            }

            byte[] ciphertext;
            using (Aes aes = Aes.Create())
            {
                aes.Key = contentEncryptionKey;
                aes.IV = contentEncryptionIv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using ICryptoTransform encryptor = aes.CreateEncryptor();
                ciphertext = encryptor.TransformFinalBlock(fullPlaintext, 0, fullPlaintext.Length);
            }

            byte[] expectedPlaintext = new byte[fullPlaintext.Length - Constants.ClientSideEncryption.EncryptionBlockSize];
            Array.Copy(
                fullPlaintext,
                Constants.ClientSideEncryption.EncryptionBlockSize,
                expectedPlaintext,
                0,
                expectedPlaintext.Length);

            IdentityKeyEncryptionKey key = new IdentityKeyEncryptionKey();
#pragma warning disable CS0618 // obsolete
            ClientSideEncryptionOptions options = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = key,
                KeyWrapAlgorithm = KeyWrapAlgorithm
            };
#pragma warning restore CS0618 // obsolete

            EncryptionData encryptionData = new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                ContentEncryptionIV = contentEncryptionIv,
                EncryptionAgent = new EncryptionAgent
                {
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesCbc256,
#pragma warning disable CS0618 // obsolete
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V1_0,
#pragma warning restore CS0618 // obsolete
                },
                WrappedContentKey = new KeyEnvelope
                {
                    Algorithm = KeyWrapAlgorithm,
                    EncryptedKey = contentEncryptionKey,
                    KeyId = key.KeyId
                }
            };

            return (expectedPlaintext, new MemoryStream(ciphertext), new ClientSideDecryptor(options), encryptionData);
        }

        private sealed class IdentityKeyEncryptionKey : IKeyEncryptionKey
        {
            public string KeyId { get; } = "test-key";

            public byte[] WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken)
                => key.ToArray();

            public Task<byte[]> WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken)
                => Task.FromResult(key.ToArray());

            public byte[] UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken)
                => encryptedKey.ToArray();

            public Task<byte[]> UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken)
                => Task.FromResult(encryptedKey.ToArray());
        }

        private sealed class LimitedReadStream : Stream
        {
            private readonly Stream _inner;
            private readonly int _maxBytesPerRead;

            public LimitedReadStream(Stream inner, int maxBytesPerRead)
            {
                _inner = inner;
                _maxBytesPerRead = maxBytesPerRead;
            }

            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
                => _inner.Read(buffer, offset, Math.Min(count, _maxBytesPerRead));

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
                => _inner.ReadAsync(buffer, offset, Math.Min(count, _maxBytesPerRead), cancellationToken);

            public override void Flush() => _inner.Flush();
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _inner.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}
