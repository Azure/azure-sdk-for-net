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
        public enum DataType
        {
            SeekableStream,
            UnseekableStream,
            BinaryData
        }

        private readonly bool IsAsync;

        private const string s_operationName = "PartitionedUploaderTests.Operation";
        private readonly object s_objectArgs = "an object";
        private readonly IProgress<long> s_progress = new Progress<long>();
        private readonly UploadTransferValidationOptions s_validationOptions = new UploadTransferValidationOptions();
        private readonly CancellationToken s_cancellation = new CancellationToken();

        private static readonly ActivitySource s_activitySource = new ActivitySource("Azure.Storage.Tests");

        public PartitionedUploaderTests(bool async)
        {
            IsAsync = async;
        }

        private Mock<PartitionedUploader<object, object>.CreateScope> GetMockCreateScope()
        {
            var mock = new Mock<PartitionedUploader<object, object>.CreateScope>(MockBehavior.Strict);
            mock.Setup(del => del(s_operationName))
                .Returns(new Core.Pipeline.DiagnosticScope("Azure.Storage.Tests", new DiagnosticListener("Azure.Storage.Tests"), null, s_activitySource, ActivityKind.Client, false));
            return mock;
        }

        private Mock<PartitionedUploader<object, object>.SingleUploadStreamingInternal> GetMockSingleUploadStreamingInternal(
            int expectedSize,
            Action<UploadTransferValidationOptions> validationOptionsAssertion = default)
        {
            var mock = new Mock<PartitionedUploader<object, object>.SingleUploadStreamingInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Stream>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), s_operationName, IsAsync, s_cancellation))
                .Returns<Stream, object, IProgress<long>, UploadTransferValidationOptions, string, bool, CancellationToken>((stream, obj, progress, validationOptions, operation, async, cancellation) =>
                {
                    Assert.IsTrue(stream.CanSeek, "PartitionedUploader sent non-seekable stream to the REST client");
                    Assert.AreEqual(expectedSize, stream.Read(new byte[expectedSize], 0, expectedSize));
                    validationOptionsAssertion?.Invoke(validationOptions);
                    return Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object);
                });

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.SingleUploadBinaryDataInternal> GetMockSingleUploadBinaryDataInternal(
            int expectedSize,
            Action<UploadTransferValidationOptions> validationOptionsAssertion = default)
        {
            var mock = new Mock<PartitionedUploader<object, object>.SingleUploadBinaryDataInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<BinaryData>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), s_operationName, IsAsync, s_cancellation))
                .Returns<BinaryData, object, IProgress<long>, UploadTransferValidationOptions, string, bool, CancellationToken>((content, obj, progress, validationOptions, operation, async, cancellation) =>
                {
                    Assert.AreEqual(expectedSize, content.ToMemory().Length);
                    validationOptionsAssertion?.Invoke(validationOptions);
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

        private Mock<PartitionedUploader<object, object>.UploadPartitionStreamingInternal> GetMockUploadPartitionStreamingInternal(
            int maxSize,
            Action<UploadTransferValidationOptions> validationOptionsAssertion = default)
        {
            var mock = new Mock<PartitionedUploader<object, object>.UploadPartitionStreamingInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Stream>(), It.IsAny<long>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), IsAsync, s_cancellation))
                .Returns<Stream, long, object, IProgress<long>, UploadTransferValidationOptions, bool, CancellationToken>((stream, offset, obj, progress, validationOptions, async, cancellation) =>
                {
                    Assert.IsTrue(stream.CanSeek, "PartitionedUploader sent non-seekable stream to the REST client");
                    Assert.GreaterOrEqual(maxSize, stream.Read(new byte[maxSize], 0, maxSize));
                    validationOptionsAssertion?.Invoke(validationOptions);
                    return Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object);
                });

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.UploadPartitionBinaryDataInternal> GetMockUploadPartitionBinaryDataInternal(
            int maxSize,
            Action<UploadTransferValidationOptions> validationOptionsAssertion = default)
        {
            var mock = new Mock<PartitionedUploader<object, object>.UploadPartitionBinaryDataInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<BinaryData>(), It.IsAny<long>(), s_objectArgs, It.IsAny<IProgress<long>>(), It.IsAny<UploadTransferValidationOptions>(), IsAsync, s_cancellation))
                .Returns<BinaryData, long, object, IProgress<long>, UploadTransferValidationOptions, bool, CancellationToken>((content, offset, obj, progress, validationOptions, async, cancellation) =>
                {
                    Assert.GreaterOrEqual(maxSize, content.ToMemory().Length);
                    validationOptionsAssertion?.Invoke(validationOptions);
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

        private MockBehaviors GetMockBehaviors(
            int dataSize,
            int blockSize,
            Action<UploadTransferValidationOptions> validationOptionsAssertion = default)
            => new MockBehaviors
            {
                CreateScope = GetMockCreateScope(),
                Initialize = GetMockInitializeDestinationInternal(),
                SingleUploadStream = GetMockSingleUploadStreamingInternal(dataSize, validationOptionsAssertion),
                SingleUploadBinaryData = GetMockSingleUploadBinaryDataInternal(dataSize, validationOptionsAssertion),
                PartitionUploadStream = GetMockUploadPartitionStreamingInternal(blockSize, validationOptionsAssertion),
                PartitionUploadBinaryData = GetMockUploadPartitionBinaryDataInternal(blockSize, validationOptionsAssertion),
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
            var mocks = GetMockBehaviors(streamSize, blockSize);
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
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
            Assert.Greater(mocks.SingleUploadStream.Invocations.Count + mocks.PartitionUploadStream.Invocations.Count, 0);
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

            var mocks = GetMockBehaviors(dataSize, blockSize);
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
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
                Assert.AreEqual(1, mocks.SingleUploadStream.Invocations.Count);
                Assert.IsEmpty(mocks.PartitionUploadStream.Invocations);
                Assert.IsEmpty(mocks.Commit.Invocations);
            }
            else
            {
                Assert.IsEmpty(mocks.SingleUploadStream.Invocations);
                Assert.AreEqual(numPartitions, mocks.PartitionUploadStream.Invocations.Count);
                Assert.AreEqual(1, mocks.Commit.Invocations.Count);
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

        [TestCase(DataType.BinaryData, true)]       // calculates because it's in-place
        [TestCase(DataType.UnseekableStream, true)] // calculates because the partitioned does the buffering of the stream
        [TestCase(DataType.SeekableStream, false)]  // delegates to upload API, as it can calculate while streaming to network
        public async Task OneShotUploadCalculatesChecksum(DataType dataType, bool expectCalculation)
        {
            // Given data for a oneshot upload with content validation
            const int dataSize = Constants.KB;
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = dataSize * 2
            };
            var data = TestHelper.GetRandomBuffer(dataSize);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.Auto,
                PrecalculatedChecksum = ReadOnlyMemory<byte>.Empty
            };

            // and mocks to detect a calculated checksum
            var mocks = GetMockBehaviors(dataSize, dataSize,
                validationOptionsAssertion: vo => Assert.AreNotEqual(expectCalculation, vo.PrecalculatedChecksum.IsEmpty));

            // and a configured uploader
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
                transferOptions,
                validationOptions,
                operationName: s_operationName);

            // When upload through uploader
            await (dataType switch
            {
                DataType.SeekableStream => partitionedUploader.UploadInternal(new MemoryStream(data), default,
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                DataType.UnseekableStream => partitionedUploader.UploadInternal(new NonSeekableMemoryStream(data), data.Length,
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                DataType.BinaryData => partitionedUploader.UploadInternal(BinaryData.FromBytes(data),
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                _ => throw Errors.InvalidArgument(nameof(dataType)),
            });

            // Then oneshot occured
            Assert.AreEqual(1, dataType switch
            {
                DataType.SeekableStream => mocks.SingleUploadStream.Invocations.Count,
                DataType.UnseekableStream => mocks.SingleUploadStream.Invocations.Count,
                DataType.BinaryData => mocks.SingleUploadBinaryData.Invocations.Count,
                _ => throw Errors.InvalidArgument(nameof(dataType)),
            });
        }

        [TestCase(DataType.BinaryData)]
        [TestCase(DataType.UnseekableStream)]
        [TestCase(DataType.SeekableStream)]
        public void UseCallerCrcPartitionedUpload(DataType dataType)
        {
            // Given data for a partitioned upload
            const int dataSize = 10 * Constants.KB;
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferSize = Constants.KB
            };
            var data = TestHelper.GetRandomBuffer(dataSize);

            // and a bad checksum
            var garbageCrc = TestHelper.GetRandomBuffer(Constants.StorageCrc64SizeInBytes);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
                PrecalculatedChecksum = new ReadOnlyMemory<byte>(garbageCrc)
            };

            // and a configured uploader
            var mocks = GetMockBehaviors(dataSize, dataSize);
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
                transferOptions,
                validationOptions,
                operationName: s_operationName);

            // Fail on upload since master CRC won't match composed block crcs, proof that the caller-supplied CRC was used
            InvalidDataException exception = Assert.ThrowsAsync<InvalidDataException>(async () => await (dataType switch
            {
                DataType.SeekableStream => partitionedUploader.UploadInternal(new MemoryStream(data), default,
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                DataType.UnseekableStream => partitionedUploader.UploadInternal(new NonSeekableMemoryStream(data), data.Length,
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                DataType.BinaryData => partitionedUploader.UploadInternal(BinaryData.FromBytes(data),
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                _ => throw Errors.InvalidArgument(nameof(dataType)),
            }));

            Assert.IsTrue(exception.Message.Contains(Convert.ToBase64String(garbageCrc)));
        }

        [TestCase(DataType.BinaryData)]
        [TestCase(DataType.UnseekableStream)]
        [TestCase(DataType.SeekableStream)]
        public async Task UseCallerCrcOneShotUpload(DataType dataType)
        {
            // Given data for a oneshot upload
            const int dataSize = Constants.KB;
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = dataSize * 2,
                MaximumTransferSize = dataSize * 2,
            };
            var data = TestHelper.GetRandomBuffer(dataSize);

            // and a bad checksum
            var garbageCrc = new ReadOnlyMemory<byte>(TestHelper.GetRandomBuffer(Constants.StorageCrc64SizeInBytes));
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
                PrecalculatedChecksum = garbageCrc
            };

            // and a configured uploader
            var mocks = GetMockBehaviors(dataSize, dataSize, validationOptionsAssertion: options =>
                // Mock asserts the garbage CRC was passed to the client
                Assert.IsTrue(garbageCrc.Span.SequenceEqual(options.PrecalculatedChecksum.Span)));
            var partitionedUploader = new PartitionedUploader<object, object>(
                mocks.ToBehaviors(),
                transferOptions,
                validationOptions,
                operationName: s_operationName);

            // Act
            await (dataType switch
            {
                DataType.SeekableStream => partitionedUploader.UploadInternal(new MemoryStream(data), default,
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                DataType.UnseekableStream => partitionedUploader.UploadInternal(new NonSeekableMemoryStream(data), data.Length,
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                DataType.BinaryData => partitionedUploader.UploadInternal(BinaryData.FromBytes(data),
                    s_objectArgs, s_progress, IsAsync, s_cancellation),
                _ => throw Errors.InvalidArgument(nameof(dataType)),
            });

            // mock will assert caller-crc was passed to client
        }
    }
}
