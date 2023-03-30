// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class PartitionedUploaderTests
    {
        private readonly bool IsAsync;

        private const string s_operationName = "PartitionedUploaderTests.Operation";
        private readonly object s_objectArgs = "an object";
        private readonly IProgress<long> s_progress = new Progress<long>();
        private readonly UploadTransferValidationOptions s_validationOptions = new UploadTransferValidationOptions();
        private readonly CancellationToken s_cancellation = new CancellationToken();

        public PartitionedUploaderTests(bool async)
        {
            IsAsync = async;
        }

        private Mock<PartitionedUploader<object, object>.CreateScope> GetMockCreateScope()
        {
            var mock = new Mock<PartitionedUploader<object, object>.CreateScope>(MockBehavior.Strict);
            mock.Setup(del => del(s_operationName))
                .Returns(new Core.Pipeline.DiagnosticScope("Azure.Storage.Tests", s_operationName, new DiagnosticListener("Azure.Storage.Tests"), DiagnosticScope.ActivityKind.Client, false));
            return mock;
        }

        private Mock<PartitionedUploader<object, object>.SingleUploadStreamingInternal> GetMockSingleUploadStreamingInternal(int expectedSize)
        {
            var mock = new Mock<PartitionedUploader<object, object>.SingleUploadStreamingInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Stream>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), s_operationName, IsAsync, s_cancellation))
                .Returns<Stream, object, IProgress<long>, UploadTransferValidationOptions, string, bool, CancellationToken>((stream, obj, progress, validationOptions, operation, async, cancellation) =>
                {
                    if (!stream.CanSeek)
                    {
                        throw new Exception("PartitionedUploader sent non-seekable stream to the REST client");
                    }
                    Assert.AreEqual(expectedSize, stream.Read(new byte[expectedSize], 0, expectedSize));
                    return Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object);
                });

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.SingleUploadBinaryDataInternal> GetMockSingleUploadBinaryDataInternal(int expectedSize)
        {
            var mock = new Mock<PartitionedUploader<object, object>.SingleUploadBinaryDataInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<BinaryData>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), s_operationName, IsAsync, s_cancellation))
                .Returns<BinaryData, object, IProgress<long>, UploadTransferValidationOptions, string, bool, CancellationToken>((content, obj, progress, validationOptions, operation, async, cancellation) =>
                {
                    Assert.AreEqual(expectedSize, content.ToMemory().Length);
                    return Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object);
                });

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.InitializeDestinationInternal> GetMockInitializeDestinationInternal()
        {
            var mock = new Mock<PartitionedUploader<object, object>.InitializeDestinationInternal>(MockBehavior.Strict);
            mock.Setup(del => del(s_objectArgs, IsAsync, s_cancellation))
                .Returns(Task.CompletedTask);

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.UploadPartitionStreamingInternal> GetMockUploadPartitionStreamingInternal(int maxSize)
        {
            var mock = new Mock<PartitionedUploader<object, object>.UploadPartitionStreamingInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Stream>(), It.IsAny<long>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), IsAsync, s_cancellation))
                .Returns<Stream, long, object, IProgress<long>, UploadTransferValidationOptions, bool, CancellationToken>((stream, offset, obj, progress, validationOptions, async, cancellation) =>
                {
                    if (!stream.CanSeek)
                    {
                        throw new Exception("PartitionedUploader sent non-seekable stream to the REST client");
                    }
                    Assert.GreaterOrEqual(maxSize, stream.Read(new byte[maxSize], 0, maxSize));
                    return Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object);
                });

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.UploadPartitionBinaryDataInternal> GetMockUploadPartitionBinaryDataInternal(int maxSize)
        {
            var mock = new Mock<PartitionedUploader<object, object>.UploadPartitionBinaryDataInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<BinaryData>(), It.IsAny<long>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), IsAsync, s_cancellation))
                .Returns<BinaryData, long, object, IProgress<long>, UploadTransferValidationOptions, bool, CancellationToken>((content, offset, obj, progress, validationOptions, async, cancellation) =>
                {
                    Assert.GreaterOrEqual(maxSize, content.ToMemory().Length);
                    return Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object);
                });

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.CommitPartitionedUploadInternal> GetMockCommitPartitionedUploadInternal()
        {
            var mock = new Mock<PartitionedUploader<object, object>.CommitPartitionedUploadInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<List<(long Offset, long Size)>>(), s_objectArgs, IsAsync, s_cancellation))
                .Returns(Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object));

            return mock;
        }

        private class MockBehaviors
        {
            public Mock<PartitionedUploader<object, object>.CreateScope> CreateScope { get; set; }
            public Mock<PartitionedUploader<object, object>.InitializeDestinationInternal> Initialize { get; set; }
            public Mock<PartitionedUploader<object, object>.SingleUploadStreamingInternal> SingleUploadStream { get; set; }
            public Mock<PartitionedUploader<object, object>.UploadPartitionStreamingInternal> PartitionUploadStream { get; set; }
            public Mock<PartitionedUploader<object, object>.SingleUploadBinaryDataInternal> SingleUploadBinaryData { get; set; }
            public Mock<PartitionedUploader<object, object>.UploadPartitionBinaryDataInternal> PartitionUploadBinaryData { get; set; }
            public Mock<PartitionedUploader<object, object>.CommitPartitionedUploadInternal> Commit { get; set; }

            public PartitionedUploader<object, object>.Behaviors ToBehaviors()
                => new PartitionedUploader<object, object>.Behaviors
                {
                    Scope = CreateScope.Object,
                    InitializeDestination = Initialize.Object,
                    SingleUploadStreaming = SingleUploadStream.Object,
                    SingleUploadBinaryData = SingleUploadBinaryData.Object,
                    UploadPartitionStreaming = PartitionUploadStream.Object,
                    UploadPartitionBinaryData = PartitionUploadBinaryData.Object,
                    CommitPartitionedUpload = Commit.Object
                };
        }

        private MockBehaviors GetMockBehaviors(int dataSize, int blockSize)
            => new MockBehaviors
            {
                CreateScope = GetMockCreateScope(),
                Initialize = GetMockInitializeDestinationInternal(),
                SingleUploadStream = GetMockSingleUploadStreamingInternal(dataSize),
                SingleUploadBinaryData = GetMockSingleUploadBinaryDataInternal(dataSize),
                PartitionUploadStream = GetMockUploadPartitionStreamingInternal(blockSize),
                PartitionUploadBinaryData = GetMockUploadPartitionBinaryDataInternal(blockSize),
                Commit = GetMockCommitPartitionedUploadInternal()
            };

        [TestCase(Constants.KB, 64, true)]
        [TestCase(64, Constants.KB, true)]
        [TestCase(Constants.KB, 64, false)]
        [TestCase(64, Constants.KB, false)]
        public async Task AlwaysUploadSeekableStreamsSequentialUploads(int streamSize, int blockSize, bool baseStreamSeekable)
        {
            var data = TestHelper.GetRandomBuffer(streamSize);
            var stream = new Mock<MemoryStream>(MockBehavior.Loose, data);
            stream.CallBase = true;
            if (!baseStreamSeekable)
            {
                stream.SetupGet(s => s.CanSeek).Returns(false);
                stream.SetupGet(s => s.Position).Throws(new NotSupportedException());
                stream.SetupSet(s => s.Position = default).Throws(new NotSupportedException());
                stream.Setup(s => s.Seek(It.IsAny<long>(), It.IsAny<SeekOrigin>())).Throws(new NotSupportedException());
                stream.SetupGet(s => s.Length).Throws(new NotSupportedException());
                stream.Setup(s => s.SetLength(It.IsAny<long>())).Throws(new NotSupportedException());
            }

            // all stream-accepting delegates are rigged to throw if they get a non-seekable stream
            var createScope = GetMockCreateScope();
            var initializeDestination = GetMockInitializeDestinationInternal();
            var singleUploadStreaming = GetMockSingleUploadStreamingInternal(streamSize);
            var uploadPartitionStreaming = GetMockUploadPartitionStreamingInternal(blockSize);
            var singleUploadContent = GetMockSingleUploadBinaryDataInternal(streamSize);
            var uploadPartitionContent = GetMockUploadPartitionBinaryDataInternal(blockSize);
            var commitPartitions = GetMockCommitPartitionedUploadInternal();
            var partitionedUploader = new PartitionedUploader<object, object>(
                new PartitionedUploader<object, object>.Behaviors
                {
                    Scope = createScope.Object,
                    InitializeDestination = initializeDestination.Object,
                    SingleUploadStreaming = singleUploadStreaming.Object,
                    SingleUploadBinaryData = singleUploadContent.Object,
                    UploadPartitionStreaming = uploadPartitionStreaming.Object,
                    UploadPartitionBinaryData = uploadPartitionContent.Object,
                    CommitPartitionedUpload = commitPartitions.Object
                },
                new StorageTransferOptions()
                {
                    InitialTransferSize = blockSize,
                    MaximumTransferSize = blockSize,
                    MaximumConcurrency = 1 // sequential upload
                },
                s_validationOptions,
                operationName: s_operationName);

            Response<object> result = await partitionedUploader.UploadInternal(stream.Object, default, s_objectArgs, s_progress, IsAsync, s_cancellation).ConfigureAwait(false);

            // assert streams were actually sent to delegates; the delegates themselves threw if conditions weren't met
            Assert.Greater(singleUploadStreaming.Invocations.Count + uploadPartitionStreaming.Invocations.Count, 0);
        }

        [Test]
        public async Task InterpretsLengthNonSeekableStream([Values(true, false)] bool oneshot)
        {
            // Arrange
            const int dataSize = Constants.KB;
            const int numPartitions = 2;
            var data = TestHelper.GetRandomBuffer(dataSize);
            int blockSize = oneshot ? dataSize * 2 : dataSize / numPartitions;

            var stream = new Mock<MemoryStream>(MockBehavior.Loose, data);
            stream.CallBase = true;

            // make stream unseekable (can't get length from stream)
            stream.SetupGet(s => s.CanSeek).Returns(false);
            stream.SetupGet(s => s.Position).Throws(new NotSupportedException());
            stream.SetupSet(s => s.Position = default).Throws(new NotSupportedException());
            stream.Setup(s => s.Seek(It.IsAny<long>(), It.IsAny<SeekOrigin>())).Throws(new NotSupportedException());
            stream.SetupGet(s => s.Length).Throws(new NotSupportedException());
            stream.Setup(s => s.SetLength(It.IsAny<long>())).Throws(new NotSupportedException());

            // confirm our stream cannot give a length
            Assert.Throws<NotSupportedException>(() => _ = stream.Object.Length);

            var createScope = GetMockCreateScope();
            var initializeDestination = GetMockInitializeDestinationInternal();
            var singleUploadStreaming = GetMockSingleUploadStreamingInternal(dataSize);
            var uploadPartitionStreaming = GetMockUploadPartitionStreamingInternal(blockSize);
            var singleUploadContent = GetMockSingleUploadBinaryDataInternal(dataSize);
            var uploadPartitionContent = GetMockUploadPartitionBinaryDataInternal(blockSize);
            var commitPartitions = GetMockCommitPartitionedUploadInternal();
            var partitionedUploader = new PartitionedUploader<object, object>(
                new PartitionedUploader<object, object>.Behaviors
                {
                    Scope = createScope.Object,
                    InitializeDestination = initializeDestination.Object,
                    SingleUploadStreaming = singleUploadStreaming.Object,
                    SingleUploadBinaryData = singleUploadContent.Object,
                    UploadPartitionStreaming = uploadPartitionStreaming.Object,
                    UploadPartitionBinaryData = uploadPartitionContent.Object,
                    CommitPartitionedUpload = commitPartitions.Object
                },
                new StorageTransferOptions()
                {
                    InitialTransferSize = blockSize,
                    MaximumTransferSize = blockSize,
                    MaximumConcurrency = 1
                },
                s_validationOptions,
                operationName: s_operationName);

            // Act
            // give uploader an expected content length for unseekable stream
            Response<object> result = await partitionedUploader.UploadInternal(stream.Object, dataSize, s_objectArgs, s_progress, IsAsync, s_cancellation);

            // Assert
            if (oneshot)
            {
                Assert.AreEqual(1, singleUploadStreaming.Invocations.Count);
                Assert.IsEmpty(uploadPartitionStreaming.Invocations);
                Assert.IsEmpty(commitPartitions.Invocations);
            }
            else
            {
                Assert.IsEmpty(singleUploadStreaming.Invocations);
                Assert.AreEqual(numPartitions, uploadPartitionStreaming.Invocations.Count);
                Assert.AreEqual(1, commitPartitions.Invocations.Count);
            }
        }

        [TestCase(1024, 2048, 2048)]
        [TestCase(1024, 500, 200)]
        public async Task CorrectStreamingBehaviorCalls(
            int dataSize,
            int initialTransfer,
            int maxTransfer)
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(dataSize);

            var stream = new Mock<MemoryStream>(MockBehavior.Loose, data)
            {
                CallBase = true
            };

            var mocks = GetMockBehaviors(dataSize, maxTransfer);
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
                new StorageTransferOptions()
                {
                    InitialTransferSize = initialTransfer,
                    MaximumTransferSize = maxTransfer,
                },
                s_validationOptions,
                operationName: s_operationName);

            // Act
            Response<object> result = await partitionedUploader.UploadInternal(stream.Object, dataSize, s_objectArgs, s_progress, IsAsync, s_cancellation);

            // Assert
            (int expectedSingleUpload, int expectedPartitionUpload, int expectedCommit) = dataSize <= maxTransfer
                ? (1, 0, 0)
                : (0, (int)Math.Ceiling((double)dataSize / maxTransfer), 1);

            Assert.AreEqual(expectedSingleUpload, mocks.SingleUploadStream.Invocations.Count);
            Assert.AreEqual(expectedPartitionUpload, mocks.PartitionUploadStream.Invocations.Count);
            Assert.AreEqual(expectedCommit, mocks.Commit.Invocations.Count);
            Assert.AreEqual(0, mocks.SingleUploadBinaryData.Invocations.Count);
            Assert.AreEqual(0, mocks.PartitionUploadBinaryData.Invocations.Count);
        }

        [TestCase(1024, 2048, 2048)]
        [TestCase(1024, 500, 200)]
        public async Task CorrectBinaryDataBehaviorCalls(
            int dataSize,
            int initialTransfer,
            int maxTransfer)
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(dataSize);

            var mocks = GetMockBehaviors(dataSize, maxTransfer);
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
                new StorageTransferOptions()
                {
                    InitialTransferSize = initialTransfer,
                    MaximumTransferSize = maxTransfer,
                },
                s_validationOptions,
                operationName: s_operationName);

            // Act
            Response<object> result = await partitionedUploader.UploadInternal(BinaryData.FromBytes(data), s_objectArgs, s_progress, IsAsync, s_cancellation);

            // Assert
            (int expectedSingleUpload, int expectedPartitionUpload, int expectedCommit) = dataSize <= maxTransfer
                ? (1, 0, 0)
                : (0, (int)Math.Ceiling((double)dataSize / maxTransfer), 1);

            Assert.AreEqual(expectedSingleUpload, mocks.SingleUploadBinaryData.Invocations.Count);
            Assert.AreEqual(expectedPartitionUpload, mocks.PartitionUploadBinaryData.Invocations.Count);
            Assert.AreEqual(expectedCommit, mocks.Commit.Invocations.Count);
            Assert.AreEqual(0, mocks.SingleUploadStream.Invocations.Count);
            Assert.AreEqual(0, mocks.PartitionUploadStream.Invocations.Count);
        }

        [TestCase(Constants.KB)]
        public async Task ReleasesMemoryOnKnownLengthUnseekableStream(int dataLength)
        {
            // Given mock array pool that actually calls to a real one
            var arraypool = new Mock<ArrayPool<byte>>();
            arraypool.Setup(pool => pool.Rent(It.IsAny<int>()))
                .Returns<int>(size => ArrayPool<byte>.Shared.Rent(size));
            arraypool.Setup(pool => pool.Return(It.IsAny<byte[]>(), It.IsAny<bool>()))
                .Callback<byte[], bool>((array, clear) => ArrayPool<byte>.Shared.Return(array, clear));

            // and a partitioneduploader
            var mocks = GetMockBehaviors(dataLength, dataLength);
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
                transferOptions: default,
                s_validationOptions,
                arrayPool: arraypool.Object,
                operationName: s_operationName);

            // upload a nonseekable stream with provided length and properly dispose after
            using (var stream = new NonSeekableMemoryStream(TestHelper.GetRandomBuffer(dataLength)))
            {
                Response<object> result = await partitionedUploader.UploadInternal(
                    content: stream,
                    expectedContentLength: dataLength,
                    s_objectArgs,
                    s_progress,
                    IsAsync,
                    s_cancellation);
            }

            // assert every pool rental was returned
            int rents = arraypool.Invocations.Where(i => i.Method.Name == "Rent").Count();
            int returns = arraypool.Invocations.Where(i => i.Method.Name == "Return").Count();
            Assert.Greater(rents, 0);
            Assert.AreEqual(rents, returns);
        }
    }
}
