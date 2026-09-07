// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Tests.Shared;
using Moq;
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
            public int DisposeCount { get; private set; }

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
                DisposeCount++;
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

        /// <summary>
        /// Inner stream whose writes always fail, to exercise a final flush that throws
        /// out of Dispose.
        /// </summary>
        private class ThrowOnWriteStream : MemoryStream
        {
            public bool Disposed { get; private set; }

            public override void Write(byte[] buffer, int offset, int count)
                => throw new IOException("inner stream write failed");

            protected override void Dispose(bool disposing)
            {
                Disposed = true;
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// The stream accepts every pairing of transform direction (encrypt/decrypt) and stream
        /// direction (read/write), and sizes its buffer differently depending on the pairing, so
        /// disposal tests cover all four.
        /// </summary>
        private static AuthenticatedRegionCryptoStream CreateStreamForDisposalTest(
            bool encrypt,
            CryptoStreamMode streamMode,
            ArrayPool<byte> arrayPool = default)
            => new AuthenticatedRegionCryptoStream(
                new MemoryStream(GetRandomBytes(_totalAuthRegionLength)),
                encrypt
                    ? new MockEncryptTransform(_nonceLength, _tagLength, _nonceByte, _tagByte)
                    : (IAuthenticatedCryptographicTransform)new MockDecryptTransform(_nonceLength, _tagLength),
                _authRegionDataLength,
                streamMode,
                arrayPool);

        /// <summary>
        /// Array pool that delegates to <see cref="ArrayPool{T}.Shared"/> while recording every
        /// array it hands out and every array handed back, so tests can check that each rental is
        /// returned exactly once.
        /// </summary>
        private static Mock<ArrayPool<byte>> CreateTrackingArrayPool(List<byte[]> rented, List<byte[]> returned)
        {
            Mock<ArrayPool<byte>> arrayPool = new Mock<ArrayPool<byte>>();
            arrayPool.Setup(pool => pool.Rent(It.IsAny<int>()))
                .Returns<int>(size =>
                {
                    byte[] array = ArrayPool<byte>.Shared.Rent(size);
                    rented.Add(array);
                    return array;
                });
            arrayPool.Setup(pool => pool.Return(It.IsAny<byte[]>(), It.IsAny<bool>()))
                .Callback<byte[], bool>((array, clear) =>
                {
                    returned.Add(array);
                    ArrayPool<byte>.Shared.Return(array, clear);
                });
            return arrayPool;
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
            [Values(Constants.KB / 2, Constants.KB - 5, Constants.KB, 2 * Constants.KB)] int readSize)
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

        [Test]
        public void DetectRegionReorderWrite([Values(true, false)] bool detectReorder)
        {
            const int regionDataLen = 1024;
            const int dataLen = regionDataLen * 4;
            byte[] plaintext = GetRandomBytes(dataLen);
            byte[] cek = GetRandomBytes(256 / 8);

            // encrypt data
            var destStream = new MemoryStream();
            var writeStream = new AuthenticatedRegionCryptoStream(
                destStream,
                new GcmAuthenticatedCryptographicTransform(cek, TransformMode.Encrypt),
                regionDataLen,
                CryptoStreamMode.Write);
            new MemoryStream(plaintext).CopyTo(writeStream);
            writeStream.FlushFinalInternal(false, CancellationToken.None).EnsureCompleted();
            var ciphertext = destStream.ToArray();

            // reorder regions
            SwapRegions(ciphertext, 2, 3, regionDataLen + _nonceLength + _tagLength);

            // detect on decrypt
            IAuthenticatedCryptographicTransform transform = new GcmAuthenticatedCryptographicTransform(cek, TransformMode.Decrypt);
            if (detectReorder)
            {
                transform = new ForceSequentialNonceAuthenticatedCryptographicTransform(transform, 0);
            }
            destStream = new MemoryStream();
            writeStream = new AuthenticatedRegionCryptoStream(
                destStream,
                transform,
                regionDataLen,
                CryptoStreamMode.Write);

            TestDelegate action = () => new MemoryStream(ciphertext).CopyTo(writeStream);
            if (detectReorder)
            {
                Assert.Throws<CryptographicException>(action);
            }
            else
            {
                Assert.DoesNotThrow(action);
            }
        }

        [Test]
        public void DetectRegionReorderRead([Values(true, false)] bool detectReorder)
        {
            const int regionDataLen = 1024;
            const int dataLen = regionDataLen * 4;
            byte[] plaintext = GetRandomBytes(dataLen);
            byte[] cek = GetRandomBytes(256 / 8);

            // encrypt data
            var destStream = new MemoryStream();
            var readStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(plaintext),
                new GcmAuthenticatedCryptographicTransform(cek, TransformMode.Encrypt),
                regionDataLen,
                CryptoStreamMode.Read);
            readStream.CopyTo(destStream);
            var ciphertext = destStream.ToArray();

            // reorder regions
            SwapRegions(ciphertext, 2, 3, regionDataLen + _nonceLength + _tagLength);

            // detect on decrypt
            IAuthenticatedCryptographicTransform transform = new GcmAuthenticatedCryptographicTransform(cek, TransformMode.Decrypt);
            if (detectReorder)
            {
                transform = new ForceSequentialNonceAuthenticatedCryptographicTransform(transform, 0);
            }
            destStream = new MemoryStream();
            readStream = new AuthenticatedRegionCryptoStream(
                new MemoryStream(ciphertext),
                transform,
                regionDataLen,
                CryptoStreamMode.Read);

            TestDelegate action = () => readStream.CopyTo(destStream);
            if (detectReorder)
            {
                Assert.Throws<CryptographicException>(action);
            }
            else
            {
                Assert.DoesNotThrow(action);
            }
        }

        /// <summary>
        /// Disposal must be idempotent, per .NET conventions.
        /// </summary>
        [Test]
        [Combinatorial]
        public void MultipleDisposeDoesNotThrow(
            [Values(true, false)] bool encrypt,
            [Values(CryptoStreamMode.Read, CryptoStreamMode.Write)] CryptoStreamMode streamMode)
        {
            AuthenticatedRegionCryptoStream stream = CreateStreamForDisposalTest(encrypt, streamMode);

            stream.Dispose();

            Assert.DoesNotThrow(() => stream.Dispose());
            Assert.DoesNotThrow(() => stream.Dispose());
        }

        /// <summary>
        /// A repeated Dispose used to return the rented buffer to the <see cref="ArrayPool{T}"/>
        /// more than once, which lets two unrelated callers rent the same array instance and
        /// silently corrupt each other's data.
        /// </summary>
        [Test]
        [Combinatorial]
        public void MultipleDisposeReturnsBufferToPoolOnce(
            [Values(true, false)] bool encrypt,
            [Values(CryptoStreamMode.Read, CryptoStreamMode.Write)] CryptoStreamMode streamMode)
        {
            List<byte[]> rented = new List<byte[]>();
            List<byte[]> returned = new List<byte[]>();
            Mock<ArrayPool<byte>> arrayPool = CreateTrackingArrayPool(rented, returned);

            AuthenticatedRegionCryptoStream stream = CreateStreamForDisposalTest(encrypt, streamMode, arrayPool.Object);

            // nothing was read or written, so the only rental is the stream's own buffer
            arrayPool.Verify(pool => pool.Rent(It.IsAny<int>()), Times.Once());
            byte[] streamBuffer = rented.Single();

            stream.Dispose();
            stream.Dispose();
            stream.Dispose();

            arrayPool.Verify(pool => pool.Return(streamBuffer, It.IsAny<bool>()), Times.Once());
            arrayPool.Verify(pool => pool.Return(It.IsAny<byte[]>(), It.IsAny<bool>()), Times.Once());
        }

        /// <summary>
        /// Dispose flushes the final block before releasing anything, and that flush writes to
        /// the inner stream, so it can throw. Since the idempotence gate stops any later Dispose
        /// call from getting that far, cleanup has to happen on the way out regardless.
        /// </summary>
        [Test]
        public void DisposeCleansUpWhenFinalFlushThrows()
        {
            List<byte[]> rented = new List<byte[]>();
            List<byte[]> returned = new List<byte[]>();
            Mock<ArrayPool<byte>> arrayPool = CreateTrackingArrayPool(rented, returned);

            MockEncryptTransform transform = new MockEncryptTransform(_nonceLength, _tagLength, _nonceByte, _tagByte);
            ThrowOnWriteStream innerStream = new ThrowOnWriteStream();
            AuthenticatedRegionCryptoStream stream = new AuthenticatedRegionCryptoStream(
                innerStream,
                transform,
                _authRegionDataLength,
                CryptoStreamMode.Write,
                arrayPool.Object);

            // partial region, so nothing is written until Dispose forces the final flush
            stream.Write(GetRandomBytes(16), 0, 16);

            Assert.Throws<IOException>(() => stream.Dispose());

            Assert.IsTrue(innerStream.Disposed, "inner stream was left undisposed");
            Assert.AreEqual(1, transform.DisposeCount, "transform was left undisposed");
            // the stream's own buffer and the flush's scratch buffer were both released, once each
            CollectionAssert.AreEquivalent(rented, returned, "every rented array must be returned exactly once");
            // and with the buffer gone, the stream no longer accepts writes
            Assert.Throws<NotSupportedException>(() => stream.Write(new byte[1], 0, 1));

            // the failed Dispose still counts as the one Dispose that does the work
            Assert.DoesNotThrow(() => stream.Dispose());
            Assert.AreEqual(1, transform.DisposeCount, "transform was disposed more than once");
            CollectionAssert.AreEquivalent(rented, returned, "a later Dispose must not return anything again");
        }

        private void Swap(byte[] buf, int i, int j)
        {
            byte temp = buf[i];
            buf[i] = buf[j];
            buf[j] = temp;
        }
        private void SwapRegions(byte[] buf, int leftRegion, int rightRegion, int regionLen)
        {
            int leftOffset = leftRegion * regionLen;
            int rightOffset = rightRegion * regionLen;
            foreach (int i in Enumerable.Range(0, regionLen))
            {
                Swap(buf, leftOffset + i, rightOffset + i);
            }
        }
    }
}
