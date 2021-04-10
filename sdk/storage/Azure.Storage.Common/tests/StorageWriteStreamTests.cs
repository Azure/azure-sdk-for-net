// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
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

            Mock<PooledMemoryStream> mockBuffer = new Mock<PooledMemoryStream>(MockBehavior.Strict);
            StorageWriteStreamImplementation stream = new StorageWriteStreamImplementation(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object);

            mockBuffer.SetupSequence(r => r.WriteAsync(
                It.IsAny<byte[]>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask);

            mockBuffer.SetupSequence(r => r.Position)
                .Returns(0)
                .Returns(256)
                .Returns(512)
                .Returns(768)
                .Returns(1024)
                .Returns(1024)
                .Returns(0)
                .Returns(256)
                .Returns(512)
                .Returns(1024)
                .Returns(1024);

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
            Assert.AreEqual(3, stream.ApiCalls.Count);
            Assert.AreEqual(s_append, stream.ApiCalls[0]);
            Assert.AreEqual(s_append, stream.ApiCalls[1]);
            Assert.AreEqual(s_flush, stream.ApiCalls[2]);

            mockBuffer.Verify(r => r.Position, Times.Exactly(11));
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

            Mock<PooledMemoryStream> mockBuffer = new Mock<PooledMemoryStream>(MockBehavior.Strict);
            StorageWriteStreamImplementation stream = new StorageWriteStreamImplementation(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object);

            mockBuffer.SetupSequence(r => r.WriteAsync(
                It.IsAny<byte[]>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask);

            mockBuffer.SetupSequence(r => r.Position)
                .Returns(0)
                .Returns(500)
                .Returns(1000)
                .Returns(1000)
                .Returns(476)
                .Returns(976)
                .Returns(976);

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
            Assert.AreEqual(3, stream.ApiCalls.Count);
            Assert.AreEqual(s_append, stream.ApiCalls[0]);
            Assert.AreEqual(s_append, stream.ApiCalls[1]);
            Assert.AreEqual(s_flush, stream.ApiCalls[2]);

            mockBuffer.Verify(r => r.Position, Times.Exactly(7));

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

            Mock<PooledMemoryStream> mockBuffer = new Mock<PooledMemoryStream>(MockBehavior.Strict);
            StorageWriteStreamImplementation stream = new StorageWriteStreamImplementation(
                position: 0,
                bufferSize: bufferSize,
                progressHandler: null,
                buffer: mockBuffer.Object);

            mockBuffer.SetupSequence(r => r.WriteAsync(
                It.IsAny<byte[]>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask)
                    .Returns(Task.CompletedTask);

            mockBuffer.SetupSequence(r => r.Position)
                .Returns(0)
                .Returns(0)
                .Returns(976)
                .Returns(976);

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
            Assert.AreEqual(4, stream.ApiCalls.Count);
            Assert.AreEqual(s_append, stream.ApiCalls[0]);
            Assert.AreEqual(s_append, stream.ApiCalls[1]);
            Assert.AreEqual(s_append, stream.ApiCalls[2]);
            Assert.AreEqual(s_flush, stream.ApiCalls[3]);

            mockBuffer.Verify(r => r.Position, Times.Exactly(4));

            mockBuffer.Verify(r => r.WriteAsync(data[0], 0, bufferSize, default));
            mockBuffer.Verify(r => r.WriteAsync(data[0], bufferSize, 976, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 0, 48, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 48, 1024, default));
            mockBuffer.Verify(r => r.WriteAsync(data[1], 1072, 928, default));
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
                : base(position, bufferSize, progressHandler, buffer)
            {
                ApiCalls = new List<string>();
            }

            protected override Task AppendInternal(bool async, CancellationToken cancellationToken)
            {
                ApiCalls.Add(s_append);
                return Task.CompletedTask;
            }

            protected override Task FlushInternal(bool async, CancellationToken cancellationToken)
            {
                ApiCalls.Add(s_flush);
                return Task.CompletedTask;
            }

            protected override void ValidateBufferSize(long bufferSize)
            {
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
