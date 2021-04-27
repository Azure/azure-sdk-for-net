// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly CancellationToken s_cancellation = new CancellationToken();

        public PartitionedUploaderTests(bool async)
        {
            IsAsync = async;
        }

        private Mock<PartitionedUploader<object, object>.CreateScope> GetMockCreateScope()
        {
            var mock = new Mock<PartitionedUploader<object, object>.CreateScope>(MockBehavior.Strict);
            mock.Setup(del => del(s_operationName))
                .Returns(new Core.Pipeline.DiagnosticScope(s_operationName, new DiagnosticListener("Azure.Storage.Tests")));
            return mock;
        }

        private Mock<PartitionedUploader<object, object>.SingleUploadInternal> GetMockSingleUploadInternal(int expectedSize)
        {
            var mock = new Mock<PartitionedUploader<object, object>.SingleUploadInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Stream>(), s_objectArgs, It.IsAny<IProgress<long>>(), s_operationName, IsAsync, s_cancellation))
                .Returns<Stream, object, IProgress<long>, string, bool, CancellationToken>((stream, obj, progress, operation, async, cancellation) =>
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

        private Mock<PartitionedUploader<object, object>.InitializeDestinationInternal> GetMockInitializeDestinationInternal()
        {
            var mock = new Mock<PartitionedUploader<object, object>.InitializeDestinationInternal>(MockBehavior.Strict);
            mock.Setup(del => del(s_objectArgs, IsAsync, s_cancellation))
                .Returns(Task.CompletedTask);

            return mock;
        }

        private Mock<PartitionedUploader<object, object>.UploadPartitionInternal> GetMockUploadPartitionInternal(int maxSize)
        {
            var mock = new Mock<PartitionedUploader<object, object>.UploadPartitionInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Stream>(), It.IsAny<long>(), s_objectArgs, It.IsAny<IProgress<long>>(), IsAsync, s_cancellation))
                .Returns<Stream, long, object, IProgress<long>, bool, CancellationToken>((stream, offset, obj, progress, async, cancellation) =>
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

        private Mock<PartitionedUploader<object, object>.CommitPartitionedUploadInternal> GetMockCommitPartitionedUploadInternal()
        {
            var mock = new Mock<PartitionedUploader<object, object>.CommitPartitionedUploadInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<List<(long Offset, long Size)>>(), s_objectArgs, IsAsync, s_cancellation))
                .Returns(Task.FromResult(new Mock<Response<object>>(MockBehavior.Loose).Object));

            return mock;
        }

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
            var singleUpload = GetMockSingleUploadInternal(streamSize);
            var uploadPartition = GetMockUploadPartitionInternal(blockSize);
            var commitPartitions = GetMockCommitPartitionedUploadInternal();
            var partitionedUploader = new PartitionedUploader<object, object>(
                new PartitionedUploader<object, object>.Behaviors
                {
                    Scope = createScope.Object,
                    InitializeDestination = initializeDestination.Object,
                    SingleUpload = singleUpload.Object,
                    UploadPartition = uploadPartition.Object,
                    CommitPartitionedUpload = commitPartitions.Object
                },
                new StorageTransferOptions()
                {
                    InitialTransferSize = blockSize,
                    MaximumTransferSize = blockSize,
                    MaximumConcurrency = 1 // sequential upload
                },
                operationName: s_operationName);

            Response<object> result = await partitionedUploader.UploadInternal(stream.Object, s_objectArgs, s_progress, IsAsync, s_cancellation).ConfigureAwait(false);

            // assert streams were actually sent to delegates; the delegates themselves threw if conditions weren't met
            Assert.Greater(singleUpload.Invocations.Count + uploadPartition.Invocations.Count, 0);
        }
    }
}
