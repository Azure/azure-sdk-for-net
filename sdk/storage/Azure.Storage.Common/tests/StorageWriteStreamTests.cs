// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageWriteStreamTests
    {
        private static readonly string s_append = "Append";
        private static readonly string s_flush = "Flush";

        /// <summary>
        /// This test uses a 1 KB buffer, and calls WriteAsync() 9 times.
        /// We expect 2 Append calls, 1 Flush call, and 9 writes to the buffer.
        /// In the current implementation, there will also be 2 writes to the buffer with count = 0.
        /// </summary>
        [Test]
        public async Task BasicTest()
        {
            // Arrange
            int bufferSize = Constants.KB;
            int writeSize = 256;
            int writeCount = 9;

            Mock<PooledMemoryStream> mockBuffer = new(
                MockBehavior.Loose,
                ArrayPool<byte>.Shared,
                Constants.MB,
                default(int?))
            {
                CallBase = true,
            };

            StorageWriteStreamImplementation stream = new StorageWriteStreamImplementation(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object);

            List<byte[]> data = new List<byte[]>();
            for (int i = 0; i < writeCount; i++)
            {
                data.Add(GetRandomBuffer(writeSize));
            }

            // Act
            for (int i = 0; i < writeCount; i++)
            {
                await stream.WriteAsync(data[i], 0, writeSize);
            }

            await stream.FlushAsync();

            // Assert
            Assert.AreEqual(4, stream.ApiCalls.Count);     // 1280 bytes to write (writeSize=256 * writeCount=9)
            Assert.AreEqual(s_append, stream.ApiCalls[0]); // first bufferSize=1024 bytes
            Assert.AreEqual(s_append, stream.ApiCalls[1]); // next bufferSize=1024 bytes
            Assert.AreEqual(s_append, stream.ApiCalls[2]); // remaining 256 bytes
            Assert.AreEqual(s_flush, stream.ApiCalls[3]);

            for (int i = 0; i < writeCount; i++)
            {
                mockBuffer.Verify(r => r.WriteAsync(
                    data[i],
                    0,
                    writeSize,
                    default));
            }
        }

        /// <summary>
        /// In this test, we are using a 1 KB buffer, and doing 5 writes of 500 bytes each.
        /// We expect 2 Append calls, 1 Flush call, and 7 writes to the buffer.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task NonAlignedWrites()
        {
            // Arrange
            int bufferSize = Constants.KB;
            int writeSize = 500;
            int writeCount = 5;

            Mock<PooledMemoryStream> mockBuffer = new(
                MockBehavior.Loose,
                ArrayPool<byte>.Shared,
                Constants.MB,
                default(int?))
            {
                CallBase = true,
            };

            StorageWriteStreamImplementation stream = new StorageWriteStreamImplementation(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object);

            List<byte[]> data = new List<byte[]>();
            for (int i = 0; i < writeCount; i++)
            {
                data.Add(GetRandomBuffer(writeSize));
            }

            // Act
            for (int i = 0; i < writeCount; i++)
            {
                await stream.WriteAsync(data[i], 0, writeSize);
            }
            await stream.FlushAsync();

            // Assert
            Assert.AreEqual(4, stream.ApiCalls.Count);     // write 2500 bytes
            Assert.AreEqual(s_append, stream.ApiCalls[0]); // 1024
            Assert.AreEqual(s_append, stream.ApiCalls[1]); // 2048
            Assert.AreEqual(s_append, stream.ApiCalls[2]); // 2500
            Assert.AreEqual(s_flush, stream.ApiCalls[3]);

            mockBuffer.Verify(r => r.WriteAsync(data[0], 0, writeSize, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 0, writeSize, default));
            mockBuffer.Verify(r => r.WriteAsync(data[2], 0, 24, default));
            mockBuffer.Verify(r => r.WriteAsync(data[2], 24, 476, default));
            mockBuffer.Verify(r => r.WriteAsync(data[3], 0, writeSize, default));
            mockBuffer.Verify(r => r.WriteAsync(data[4], 0, 48, default));
            mockBuffer.Verify(r => r.WriteAsync(data[4], 48, 452, default));
        }

        /// <summary>
        /// In this test, we have a 1 KB buffer, and are making 2 writes of 2000 bytes.
        /// We expect 3 Append calls, 1 flush call, and 5 calls to buffer.Write.
        /// </summary>
        [Test]
        public async Task WritesLargerThanBufferNonAligned()
        {
            // Arrange
            int bufferSize = Constants.KB;
            int writeSize = 2000;
            int writeCount = 2;

            Mock<PooledMemoryStream> mockBuffer = new(
                MockBehavior.Loose,
                ArrayPool<byte>.Shared,
                Constants.MB,
                default(int?))
            {
                CallBase = true,
            };

            StorageWriteStreamImplementation stream = new StorageWriteStreamImplementation(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object);

            List<byte[]> data = new List<byte[]>();
            for (int i = 0; i < writeCount; i++)
            {
                data.Add(GetRandomBuffer(writeSize));
            }

            // Act
            for (int i = 0; i < writeCount; i++)
            {
                await stream.WriteAsync(data[i], 0, writeSize);
            }
            await stream.FlushAsync();

            // Assert
            Assert.AreEqual(5, stream.ApiCalls.Count);     // total of 4000 bytes to be written
            Assert.AreEqual(s_append, stream.ApiCalls[0]); // 1024
            Assert.AreEqual(s_append, stream.ApiCalls[1]); // 2048
            Assert.AreEqual(s_append, stream.ApiCalls[2]); // 3072
            Assert.AreEqual(s_append, stream.ApiCalls[3]); // 4000
            Assert.AreEqual(s_flush, stream.ApiCalls[4]);

            mockBuffer.Verify(r => r.WriteAsync(data[0], 0, bufferSize, default));
            mockBuffer.Verify(r => r.WriteAsync(data[0], bufferSize, 976, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 0, 48, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 48, 1024, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 1072, 928, default));
        }

        [Test]
        public async Task ErrorsInCommitCleanupArrayPoolOnDispose()
        {
            // Arrange
            int bufferSize = Constants.KB;
            int writeSize = 256;

            Mock<PooledMemoryStream> mockBuffer = new(
                MockBehavior.Loose,
                ArrayPool<byte>.Shared,
                Constants.MB,
                default(int?))
            {
                CallBase = true,
            };

            RentReturnTrackingArrayPool<byte> bufferPool = new RentReturnTrackingArrayPool<byte>();

            StorageWriteStreamWithFlushError stream = new StorageWriteStreamWithFlushError(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object,
                bufferPool: bufferPool);

            // Act
            // Do one write, and then explicitly dispose
            // This dispose will raise an exception (as it has a Commit/Flush failure),
            // and then we will assert that after the dispose, the proper ArrayPool calls were made.
            await stream.WriteAsync(GetRandomBuffer(writeSize), 0, writeSize);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(stream.Dispose);

            // Assert
            Assert.AreEqual(2, stream.ApiCalls.Count);
            Assert.AreEqual(s_append, stream.ApiCalls[0]);
            Assert.AreEqual(s_flush, stream.ApiCalls[1]);
            Assert.AreEqual(ex.Message, "Flush failed");

            Assert.AreEqual(3, bufferPool.RentCount); // Crc, Checksum, and buffer is rented from the bufferPool
            Assert.AreEqual(3, bufferPool.ReturnCount, "Not all allocated array pool arrays were properly returned");
        }

        internal class StorageWriteStreamImplementation : StorageWriteStream
        {
            public List<string> ApiCalls;
            public PooledMemoryStream Buffer { get; private set; }

            public StorageWriteStreamImplementation(
                long position,
                long bufferSize,
                IProgress<long> progressHandler,
                PooledMemoryStream buffer)
                : base(
                      position,
                      bufferSize,
                      progressHandler,
                      transferValidation: new UploadTransferValidationOptions
                      {
                          ChecksumAlgorithm = StorageChecksumAlgorithm.Auto
                      },
                      buffer)
            {
                ApiCalls = new List<string>();
            }

            protected override Task AppendInternal(
                UploadTransferValidationOptions validationOptions,
                bool async,
                CancellationToken cancellationToken)
            {
                ApiCalls.Add(s_append);
                _buffer.Clear();
                return Task.CompletedTask;
            }

            protected override Task CommitInternal(
                bool async,
                CancellationToken cancellationToken)
            {
                ApiCalls.Add(s_flush);
                return Task.CompletedTask;
            }

            protected override void ValidateBufferSize(long bufferSize)
            {
            }
        }

        internal class StorageWriteStreamWithFlushError : StorageWriteStream
        {
            public List<string> ApiCalls;

            public StorageWriteStreamWithFlushError(
                long position,
                long bufferSize,
                IProgress<long> progressHandler,
                PooledMemoryStream buffer,
                RentReturnTrackingArrayPool<byte> bufferPool)
                : base(
                    position,
                    bufferSize,
                    progressHandler,
                    transferValidation: new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.Auto
                    },
                    buffer,
                    bufferPool)
            {
                ApiCalls = new List<string>();
            }

            protected override Task AppendInternal(UploadTransferValidationOptions validationOptions, bool async, CancellationToken cancellationToken)
            {
                ApiCalls.Add(s_append);
                return Task.CompletedTask;
            }

            protected override Task CommitInternal(bool async, CancellationToken cancellationToken)
            {
                ApiCalls.Add(s_flush);
                throw new InvalidOperationException("Flush failed");
            }

            protected override void ValidateBufferSize(long bufferSize)
            {
            }
        }

        internal class RentReturnTrackingArrayPool<T> : ArrayPool<T>
        {
            private int _rentCount = 0;
            private int _returnCount = 0;

            public int RentCount => _rentCount;
            public int ReturnCount => _returnCount;

            public override T[] Rent(int minimumLength)
            {
                Interlocked.Increment(ref _rentCount);
                return Shared.Rent(minimumLength);
            }

            public override void Return(T[] array, bool clearArray = false)
            {
                Interlocked.Increment(ref _returnCount);
                Shared.Return(array, clearArray);
            }
        }

        private static byte[] GetRandomBuffer(long size)
        {
            Random random = new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }
    }
}
