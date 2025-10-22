// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Tests.Shared;
using Iced.Intel;
using Moq;
using NUnit;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    /// <summary>
    /// This test theoretically belongs in common, but common's testing dependency on storage blobs combined with
    /// our compile-include strategy makes that extremely difficult. Simpler to just have it in here.
    /// </summary>
    public class AuthenticatedRegionCryptoStreamTest
    {
        private const int _authRegionDataLength = Constants.KB;
        private const int _totalAuthRegionLength = _authRegionDataLength + _nonceLength + _tagLength;
        private const int _nonceLength = 12;
        private const int _tagLength = 16;
        private const byte _nonceByte = 0xC3;
        private const byte _tagByte = 0x3c;

        /// <summary>
        /// Mock encryption transform which adds a predictable nonce and tag around the input bytes.
        /// Input bytes remain untransformed.
        /// </summary>
        internal class MockEncryptTransform : IAuthenticatedCryptographicTransform
        {
            public TransformMode TransformMode => TransformMode.Encrypt;
            public int NonceLength { get; }
            public int TagLength { get; }
            public byte RepeatingNonceByte { get; }
            public byte RepeatingTagByte { get; }

            public MockEncryptTransform(int nonceLength, int tagLength, byte repeatingNonceByte, byte repeatingTagByte)
            {
                NonceLength = nonceLength;
                TagLength = tagLength;
                RepeatingNonceByte = repeatingNonceByte;
                RepeatingTagByte = repeatingTagByte;
            }

            public int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output)
            {
                Assert.LessOrEqual(input.Length + NonceLength + TagLength, output.Length);

                var nonce = new Span<byte>(new byte[NonceLength]);
                for (int i = 0; i < nonce.Length; i++)
                {
                    nonce[i] = RepeatingNonceByte;
                }
                var tag = new Span<byte>(new byte[TagLength]);
                for (int i = 0; i < tag.Length; i++)
                {
                    tag[i] = RepeatingTagByte;
                }

                nonce.CopyTo(output.Slice(0, NonceLength));
                input.CopyTo(output.Slice(NonceLength, input.Length));
                tag.CopyTo(output.Slice(NonceLength + input.Length, TagLength));

                return NonceLength + input.Length + TagLength;
            }

            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Mock encryption transform which strips known-length nonce and tag from bytes.
        /// Input bytes remain untransformed.
        /// </summary>
        internal class MockDecryptTransform : IAuthenticatedCryptographicTransform
        {
            public TransformMode TransformMode => TransformMode.Decrypt;
            public int NonceLength { get; }
            public int TagLength { get; }

            public MockDecryptTransform(int nonceLength, int tagLength)
            {
                NonceLength = nonceLength;
                TagLength = tagLength;
            }
            public int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output)
            {
                Assert.LessOrEqual(input.Length, output.Length + NonceLength + TagLength);
                int bytesToCopy = input.Length - NonceLength - TagLength;
                input.Slice(NonceLength, bytesToCopy).CopyTo(output);
                return bytesToCopy;
            }

            public void Dispose()
            {
            }
        }

        private static byte[] GetRandomBytes(int length)
        {
            byte[] bytes = new byte[length];
            new Random().NextBytes(bytes);
            return bytes;
        }

        [Test]
        [Combinatorial]
        public void TransformEncryptWrite(
            [Values(true, false)] bool alligned,
            [Values(1, 3)] int numAuthBlocks,
            [Values(200, _authRegionDataLength, null)] int? streamWriteLength,
            [Values(true, false)] bool flushEveryWrite)
        {
            // Arrange
            int plaintextLength = (alligned ? _authRegionDataLength : 500) + ((numAuthBlocks - 1) * _authRegionDataLength);
            byte[] plaintext = GetRandomBytes(plaintextLength);

            var destStream = new MemoryStream();
            var writeStream = new AuthenticatedRegionCryptoStream(
                destStream,
                new MockEncryptTransform(_nonceLength, _tagLength, _nonceByte, _tagByte),
                _authRegionDataLength,
                CryptoStreamMode.Write);

            // Act
            if (streamWriteLength.HasValue)
            {
                for (int i = 0; i < plaintextLength; i += streamWriteLength.Value)
                {
                    writeStream.Write(plaintext, i, Math.Min(streamWriteLength.Value, plaintext.Length - i));
                    if (flushEveryWrite)
                        writeStream.Flush();
                }
            }
            else
            {
                writeStream.Write(plaintext.ToArray(), 0, plaintext.Length);
                if (flushEveryWrite)
                    writeStream.Flush();
            }
            writeStream.FlushFinalInternal(async: false, cancellationToken: default).Wait();

            var ciphertextResult = new ReadOnlySpan<byte>(destStream.ToArray());

            // Assert
            foreach (int authBlock in Enumerable.Range(0, numAuthBlocks))
            {
                int plaintextOffset = authBlock * _authRegionDataLength;
                ReadOnlySpan<byte> plaintextAuthBlock = new ReadOnlySpan<byte>(
                    plaintext,
                    plaintextOffset,
                    Math.Min(_authRegionDataLength, plaintext.Length - plaintextOffset));

                int ciphertextOffset = authBlock * _totalAuthRegionLength;
                ReadOnlySpan<byte> ciphertextAuthBlock = ciphertextResult.Slice(
                    ciphertextOffset,
                    Math.Min(_totalAuthRegionLength, ciphertextResult.Length - ciphertextOffset));

                CollectionAssert.AreEqual(
                    Enumerable.Repeat(_nonceByte, _nonceLength),
                    ciphertextAuthBlock.Slice(0, _nonceLength).ToArray());
                CollectionAssert.AreEqual(
                    plaintextAuthBlock.ToArray(),
                    ciphertextAuthBlock.Slice(
                        _nonceLength,
                        Math.Min(_authRegionDataLength, ciphertextAuthBlock.Length - _nonceLength - _tagLength)).ToArray());
                CollectionAssert.AreEqual(
                    Enumerable.Repeat(_tagByte, _tagLength),
                    ciphertextAuthBlock.Slice(ciphertextAuthBlock.Length - _tagLength).ToArray());
            }
        }

        [Test]
        [Combinatorial]
        public void TransformDecryptWrite(
            [Values(true, false)] bool alligned,
            [Values(1, 3)] int numAuthBlocks,
            [Values(200, _totalAuthRegionLength, null)] int? streamWriteLength,
            [Values(true, false)] bool flushEveryWrite)
        {
            // Arrange
            int ciphertextLength = (alligned ? _totalAuthRegionLength : 500) + ((numAuthBlocks - 1) * _totalAuthRegionLength);
            byte[] ciphertext = GetRandomBytes(ciphertextLength);

            var destStream = new MemoryStream();
            var writeStream = new AuthenticatedRegionCryptoStream(
                destStream,
                new MockDecryptTransform(_nonceLength, _tagLength),
                _authRegionDataLength,
                CryptoStreamMode.Write);

            // Act
            if (streamWriteLength.HasValue)
            {
                for (int i = 0; i < ciphertextLength; i += streamWriteLength.Value)
                {
                    writeStream.Write(ciphertext, i, Math.Min(streamWriteLength.Value, ciphertext.Length - i));
                    if (flushEveryWrite)
                        writeStream.Flush();
                }
            }
            else
            {
                writeStream.Write(ciphertext.ToArray(), 0, ciphertext.Length);
                if (flushEveryWrite)
                    writeStream.Flush();
            }
            writeStream.FlushFinalInternal(async: false, cancellationToken: default).Wait();

            var plaintextResult = new ReadOnlySpan<byte>(destStream.ToArray());

            // Assert
            foreach (int authBlock in Enumerable.Range(0, numAuthBlocks))
            {
                int plaintextOffset = authBlock * _authRegionDataLength;
                ReadOnlySpan<byte> plaintextAuthBlock = plaintextResult.Slice(
                    plaintextOffset,
                    Math.Min(_authRegionDataLength, plaintextResult.Length - plaintextOffset));

                int ciphertextOffset = authBlock * _totalAuthRegionLength;
                ReadOnlySpan<byte> ciphertextAuthBlock = new ReadOnlySpan<byte>(
                    ciphertext,
                    ciphertextOffset,
                    Math.Min(_totalAuthRegionLength, ciphertext.Length - ciphertextOffset));

                CollectionAssert.AreEqual(
                    plaintextAuthBlock.ToArray(),
                    ciphertextAuthBlock.Slice(
                        _nonceLength,
                        Math.Min(_authRegionDataLength, ciphertextAuthBlock.Length - _nonceLength - _tagLength)).ToArray());
            }
        }

        [Test]
        [Combinatorial]
        public void TransformEncryptRead(
            [Values(true, false)] bool alligned,
            [Values(1, 3)] int numAuthBlocks,
            [Values(200, _totalAuthRegionLength, null)] int? streamReadLength)
        {
            // Arrange
            int plaintextLength = (alligned ? _authRegionDataLength : 500) + ((numAuthBlocks - 1) * _authRegionDataLength);
            ReadOnlySpan<byte> plaintext = new ReadOnlySpan<byte>(GetRandomBytes(plaintextLength));

            var readStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(plaintext.ToArray()),
                new MockEncryptTransform(_nonceLength, _tagLength, _nonceByte, _tagByte),
                _authRegionDataLength,
                CryptoStreamMode.Read);

            // Act
            int read;
            int totalRead = 0;
            byte[] ciphertextResult = new byte[plaintextLength + (numAuthBlocks * (_nonceLength + _tagLength))];
            do
            {
                read = streamReadLength.HasValue
                    ? readStream.Read(ciphertextResult, totalRead, Math.Min(streamReadLength.Value, ciphertextResult.Length - totalRead))
                    : readStream.Read(ciphertextResult, totalRead, ciphertextResult.Length - totalRead);
                totalRead += read;
            } while (read != 0);

            // Assert
            Assert.AreEqual(ciphertextResult.Length, totalRead);
            foreach (int authBlock in Enumerable.Range(0, numAuthBlocks))
            {
                int plaintextOffset = authBlock * _authRegionDataLength;
                ReadOnlySpan<byte> plaintextAuthBlock = plaintext.Slice(
                    plaintextOffset,
                    Math.Min(_authRegionDataLength, plaintext.Length - plaintextOffset));

                int ciphertextOffset = authBlock * _totalAuthRegionLength;
                ReadOnlySpan<byte> ciphertextAuthBlock = new ReadOnlySpan<byte>(
                    ciphertextResult,
                    ciphertextOffset,
                    Math.Min(_totalAuthRegionLength, ciphertextResult.Length - ciphertextOffset));

                CollectionAssert.AreEqual(
                    Enumerable.Repeat(_nonceByte, _nonceLength),
                    ciphertextAuthBlock.Slice(0, _nonceLength).ToArray());
                CollectionAssert.AreEqual(
                    plaintextAuthBlock.ToArray(),
                    ciphertextAuthBlock.Slice(
                        _nonceLength,
                        Math.Min(_authRegionDataLength, ciphertextAuthBlock.Length - _nonceLength - _tagLength)).ToArray());
                CollectionAssert.AreEqual(
                    Enumerable.Repeat(_tagByte, _tagLength),
                    ciphertextAuthBlock.Slice(ciphertextAuthBlock.Length - _tagLength).ToArray());
            }
        }

        [Test]
        [Combinatorial]
        public void TransformDecryptRead(
            [Values(true, false)] bool alligned,
            [Values(1, 3)] int numAuthBlocks,
            [Values(200, _authRegionDataLength, null)] int? streamReadLength)
        {
            // Arrange
            int ciphertextLength = (alligned ? _totalAuthRegionLength : 500) + ((numAuthBlocks - 1) * _totalAuthRegionLength);
            ReadOnlySpan<byte> ciphertext = new ReadOnlySpan<byte>(GetRandomBytes(ciphertextLength));

            var readStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(ciphertext.ToArray()),
                new MockDecryptTransform(_nonceLength, _tagLength),
                _authRegionDataLength,
                CryptoStreamMode.Read);

            // Act
            int read;
            int totalRead = 0;
            byte[] plaintextResult = new byte[ciphertextLength - (numAuthBlocks * (_nonceLength + _tagLength))];
            do
            {
                read = streamReadLength.HasValue
                    ? readStream.Read(plaintextResult, totalRead, Math.Min(streamReadLength.Value, plaintextResult.Length - totalRead))
                    : readStream.Read(plaintextResult, totalRead, plaintextResult.Length - totalRead);
                totalRead += read;
            } while (read != 0);

            // Assert
            Assert.AreEqual(plaintextResult.Length, totalRead);
            foreach (int authBlock in Enumerable.Range(0, numAuthBlocks))
            {
                int plaintextOffset = authBlock * _authRegionDataLength;
                ReadOnlySpan<byte> plaintextAuthBlock = new ReadOnlySpan<byte>(
                    plaintextResult,
                    plaintextOffset,
                    Math.Min(_authRegionDataLength, plaintextResult.Length - plaintextOffset));

                int ciphertextOffset = authBlock * _totalAuthRegionLength;
                ReadOnlySpan<byte> ciphertextAuthBlock = ciphertext.Slice(
                    ciphertextOffset,
                    Math.Min(_totalAuthRegionLength, ciphertext.Length - ciphertextOffset));

                CollectionAssert.AreEqual(
                    plaintextAuthBlock.ToArray(),
                    ciphertextAuthBlock.Slice(
                        _nonceLength,
                        Math.Min(_authRegionDataLength, ciphertextAuthBlock.Length - _nonceLength - _tagLength)).ToArray());
            }
        }

        [Test]
        [Combinatorial]
        public void RoundTrip_Read(
            [Values(true, false)] bool alligned,
            [Values(1, 3)] int numAuthBlocks)
        {
            // Arrange
            int plaintextLength = (alligned ? _authRegionDataLength : 500) + ((numAuthBlocks - 1) * _authRegionDataLength);
            ReadOnlySpan<byte> plaintext = new ReadOnlySpan<byte>(GetRandomBytes(plaintextLength));
            byte[] key = GetRandomBytes(Constants.ClientSideEncryption.EncryptionKeySizeBits / 8);

            var encryptingReadStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(plaintext.ToArray()),
                new MockEncryptTransform(_nonceLength, _tagLength, _nonceByte, _tagByte),
                _authRegionDataLength,
                CryptoStreamMode.Read);

            var decryptingReadStream = new AuthenticatedRegionCryptoStream(
                encryptingReadStream,
                new MockDecryptTransform(_nonceLength, _tagLength),
                _authRegionDataLength,
                CryptoStreamMode.Read);

            // Act
            var roundtrippedPlaintext = new byte[plaintext.Length];
            decryptingReadStream.CopyTo(new MemoryStream(roundtrippedPlaintext));

            // Assert
            CollectionAssert.AreEqual(plaintext.ToArray(), roundtrippedPlaintext);
        }

        /// <summary>
        /// A buffer can end up partially filled. Ensure when capping read lengths we cap
        /// according to known populated length of buffer, not total buffer size.
        ///
        /// Test this with data and read size far smaller than auth region size and ensure
        /// we don't read past the expected length.
        /// </summary>
        /// <param name="readSize"></param>
        [Test]
        public void VerySmallSourceStreamRead(
            [Values(Constants.KB/2, Constants.KB - 5, Constants.KB, 2 * Constants.KB)] int readSize)
        {
            const int bufferSize = Constants.ClientSideEncryption.V2.EncryptionRegionDataSize;
            const int dataLength = Constants.KB;
            const int expectedOutputLength = dataLength + _tagLength + _nonceLength;

            // Arrange
            ReadOnlySpan<byte> plaintext = new ReadOnlySpan<byte>(GetRandomBytes(dataLength));

            var readStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(plaintext.ToArray()),
                new MockEncryptTransform(_nonceLength, _tagLength, _nonceByte, _tagByte),
                bufferSize,
                System.Security.Cryptography.CryptoStreamMode.Read);

            // Act
            int read;
            int totalRead = 0;
            byte[] ciphertextResult = new byte[bufferSize];
            do
            {
                read = readStream.Read(ciphertextResult, totalRead, readSize);
                totalRead += read;

                if (totalRead > expectedOutputLength)
                    Assert.Fail("Read past partial buffer.");
            } while (read != 0);

            // Assert
            Assert.AreEqual(expectedOutputLength, totalRead);
        }

        [Test]
        public void AvoidFlushInnerStreamEveryBlock()
        {
            byte[] key = new byte[Constants.ClientSideEncryption.EncryptionKeySizeBits / 8];
            new Random().NextBytes(key);
            Mock<MemoryStream> ms = new()
            {
                CallBase = true,
            };
            using AuthenticatedRegionCryptoStream cryptoStream = new(
                ms.Object,
                new GcmAuthenticatedCryptographicTransform(key, TransformMode.Encrypt),
                Constants.ClientSideEncryption.V2.EncryptionRegionDataSize,
                CryptoStreamMode.Write);

            using Stream sourceStream = new PredictableStream(4 * Constants.ClientSideEncryption.V2.EncryptionRegionDataSize);

            sourceStream.CopyTo(cryptoStream);

            ms.Verify(s => s.Flush(), Times.Never);
            ms.Verify(s => s.FlushAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
