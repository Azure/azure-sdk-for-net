// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class PartitionedUploaderTests
    {
        private readonly bool _async;

        // Use constants to verify that we flow them everywhere
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;
        private static readonly BlobHttpHeaders s_blobHttpHeaders = new BlobHttpHeaders() { CacheControl = "Please do", ContentEncoding = "Yes" };
        private static readonly Dictionary<string, string> s_metadata = new Dictionary<string, string>() { { "Key", "Value" } };
        private static readonly BlobRequestConditions s_conditions = new BlobRequestConditions() { LeaseId = "MyImportantLease" };
        private static readonly AccessTier s_accessTier = AccessTier.Cool;
        private static readonly Progress<long> s_progress = new Progress<long>();
        private static readonly Response<BlobContentInfo> s_response = Response.FromValue(new BlobContentInfo(), new MockResponse(200));

        public PartitionedUploaderTests(bool async)
        {
            _async = async;
        }

        [Test]
        public async Task UploadsStreamInBlocksIfLengthNotAvailable()
        {
            TestStream content = new TestStream(_async, null, TestStream.Read(0, 10));
            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, default, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertStaged(sink, content);

        }

        [Test]
        public async Task UploadsStreamInBlocksIfLengthIsOverTheLimit()
        {
            TestStream content = new TestStream(_async, 30, TestStream.Read(0, 10));
            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, default, singleUploadThreshold: 20, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertStaged(sink, content);

        }

        [Test]
        public async Task UploadsStreamInBlocksUnderSize()
        {
            TestStream content = new TestStream(_async, null,
                TestStream.Read(0, 10),
                TestStream.Read(1, 10)
            );
            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 20}, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            AssertStaged(sink, content);

            Assert.AreEqual(3, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
        }

        [Test]
        public async Task MergesLotsOfSmallBlocks()
        {
            TestStream content = new TestStream(_async, null,
                Enumerable.Range(1, 250).Select(b => TestStream.Read((byte)b, b)).ToArray()
            );

            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, default, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertStaged(sink, content);
        }

        [Test]
        public async Task SmallMaxWriteSize()
        {
            TestStream content = new TestStream(_async, null,
                Enumerable.Range(1, 1000).Select(b => TestStream.Read((byte)b, 2)).ToArray()
            );

            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 100 }, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(0, testPool.CurrentCount);
            Assert.AreEqual(41, testPool.TotalRents);
            AssertStaged(sink, content);

            foreach (byte[] bytes in sink.Staged.Values)
            {
                Assert.LessOrEqual(bytes.Length, 100);
                Assert.GreaterOrEqual(bytes.Length, 50);
            }
        }

        [Test]
        public async Task MergesBlocksUntilTheyReachOverHalfMaxSize()
        {
            TestStream content = new TestStream(_async, null,
                TestStream.Read(0, 5),
                TestStream.Read(1, 5),
                TestStream.Read(2, 10)
            );
            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 20}, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Staged.Count);
            // First two should be merged
            CollectionAssert.AreEqual(new byte[] {0, 0, 0, 0, 0, 1, 1, 1, 1, 1 }, sink.Staged[sink.Blocks.First()]);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(3, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertStaged(sink, content);
        }


        [Test]
        public async Task BlockIdsAre64BytesUniqueBase64Strings()
        {
            TestStream content = new TestStream(_async, null,
                TestStream.Read(0, 10),
                TestStream.Read(0, 10)
            );

            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupAsyncStaging(clientMock, sink);

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 20});
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Staged.Count);
            foreach (string blockId in sink.Staged.Keys)
            {
                Assert.AreEqual(64, blockId.Length);
                // Should be base64 string
                Assert.NotNull(Convert.FromBase64String(blockId));
            }

            CollectionAssert.AllItemsAreUnique(sink.Staged.Keys);
            Assert.AreEqual(s_response, info);
            AssertStaged(sink, content);
        }

        [Test]
        public async Task AsyncUploadsAsSingleBlockIfUnderLimit()
        {
            TestStream content = new TestStream(true, 10, TestStream.Read(0, 10));
            TrackingArrayPool testPool = new TrackingArrayPool();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict);

            if (_async)
            {
                clientMock.Setup(
                        c => c.UploadAsync(content, s_blobHttpHeaders, s_metadata, s_conditions, s_accessTier, s_progress, s_cancellationToken))
                    .ReturnsAsync(s_response);
            }
            else
            {
                clientMock.Setup(c => c.Upload(content, s_blobHttpHeaders, s_metadata, s_conditions, s_accessTier, s_progress, s_cancellationToken))
                    .Returns(s_response);
            }

            PartitionedUploader uploader = new PartitionedUploader(clientMock.Object, default, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(0, testPool.TotalRents);
        }

        private async Task<Response<BlobContentInfo>> InvokeUploadAsync(PartitionedUploader uploader, TestStream content)
        {
            if (_async)
            {
                return await uploader.UploadAsync(content, s_blobHttpHeaders, s_metadata, s_conditions, s_progress, s_accessTier, s_cancellationToken);
            }
            else
            {
                return uploader.Upload(content, s_blobHttpHeaders, s_metadata, s_conditions, s_progress, s_accessTier, s_cancellationToken);
            }
        }

        private void SetupAsyncStaging(Mock<BlockBlobClient> clientMock, StagingSink sink)
        {
            if (_async)
            {
                clientMock.Setup(
                    c => c.StageBlockAsync(
                        IsAny<string>(),
                        IsAny<Stream>(),
                        IsAny<byte[]>(),
                        s_conditions,
                        s_progress,
                        s_cancellationToken
                    )).Returns<string, Stream, byte[], BlobRequestConditions, IProgress<long>, CancellationToken>(sink.StageAsync);

                clientMock.Setup(
                    c => c.CommitBlockListAsync(
                        IsAny<IEnumerable<string>>(),
                        s_blobHttpHeaders,
                        s_metadata,
                        s_conditions,
                        s_accessTier,
                        s_cancellationToken
                    )).Returns<IEnumerable<string>, BlobHttpHeaders, Dictionary<string, string>, BlobRequestConditions, AccessTier?, CancellationToken>(sink.CommitAsync);
            }
            else
            {
                clientMock.Setup(
                    c => c.StageBlock(
                        IsAny<string>(),
                        IsAny<Stream>(),
                        IsAny<byte[]>(),
                        s_conditions,
                        s_progress,
                        s_cancellationToken
                    )).Returns<string, Stream, byte[], BlobRequestConditions, IProgress<long>, CancellationToken>(sink.Stage);

                clientMock.Setup(
                    c => c.CommitBlockList(
                        IsAny<IEnumerable<string>>(),
                        s_blobHttpHeaders,
                        s_metadata,
                        s_conditions,
                        s_accessTier,
                        s_cancellationToken
                    )).Returns<IEnumerable<string>, BlobHttpHeaders, Dictionary<string, string>, BlobRequestConditions, AccessTier?, CancellationToken>(sink.Commit);
            }
        }

        private static void AssertStaged(StagingSink sink, TestStream stream)
        {
            Assert.AreEqual(sink.Blocks.Length, sink.Staged.Count);
            CollectionAssert.AreEqual(
                stream.AllBytes,
                sink.Blocks.SelectMany(block => sink.Staged[block]));
        }

        private class StagingSink
        {
            public string[] Blocks { get; set; }

            public Dictionary<string, byte[]> Staged { get; }

            public StagingSink()
            {
                Staged = new Dictionary<string, byte[]>();
            }

            public async Task<Response<BlobContentInfo>> CommitAsync(IEnumerable<string> blocks, BlobHttpHeaders headers, Dictionary<string, string> metadata, BlobRequestConditions accessConditions, AccessTier? accessTier, CancellationToken cancellationToken)
            {
                await Task.Delay(25);
                return Commit(blocks, headers, metadata, accessConditions, accessTier, cancellationToken);
            }

            public Response<BlobContentInfo> Commit(IEnumerable<string> blocks, BlobHttpHeaders headers, Dictionary<string, string> metadata, BlobRequestConditions accessConditions, AccessTier? accessTier, CancellationToken cancellationToken)
            {
                Blocks = blocks.ToArray();
                return s_response;
            }

            public async  Task<Response<BlockInfo>> StageAsync(string s, Stream stream, byte[] hash, BlobRequestConditions accessConditions, IProgress<long> progress, CancellationToken cancellationToken)
            {
                await Task.Delay(25);
                return Stage(s, stream, hash, accessConditions, progress, cancellationToken);
            }

            public Response<BlockInfo> Stage(string s, Stream stream, byte[] hash, BlobRequestConditions accessConditions, IProgress<long> progress, CancellationToken cancellationToken)
            {
                progress.Report(stream.Length);
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                lock (Staged)
                {
                    Staged.Add(s, memoryStream.ToArray());
                }
                return Response.FromValue(new BlockInfo(), new MockResponse(200));
            }
        }

        public class TrackingArrayPool : ArrayPool<byte>
        {
            private ArrayPool<byte> _innerPool = ArrayPool<byte>.Shared;
            public int TotalRents;

            public int CurrentCount;

            public override byte[] Rent(int minimumLength)
            {
                Interlocked.Increment(ref TotalRents);
                Interlocked.Increment(ref CurrentCount);

                return _innerPool.Rent(minimumLength);
            }

            public override void Return(byte[] array, bool clearArray = false)
            {
                Interlocked.Decrement(ref CurrentCount);
                _innerPool.Return(array, true);
            }
        }

        private class TestStream: Stream
        {
            private readonly bool _async;

            private readonly int? _length;

            private readonly TestStreamRead[] _reads;

            private int _readIndex = 0;

            public TestStream(bool async, int? length, params TestStreamRead[] reads)
            {
                _async = async;
                _length = length;
                _reads = reads;
            }

            public override void Flush()
            {
                throw new System.NotImplementedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (_async) throw new InvalidOperationException();

                return ReadCore(buffer, offset);
            }

            private int ReadCore(byte[] buffer, int offset)
            {
                if (_readIndex == _reads.Length)
                {
                    return 0;
                }

                TestStreamRead read = _reads[_readIndex++];

                read.Data.CopyTo(buffer, offset);

                return read.Length;
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                if (!_async) throw new InvalidOperationException();

                return Task.FromResult(ReadCore(buffer, offset));
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new System.NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new System.NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new System.NotImplementedException();
            }

            public override bool CanRead { get; }
            public override bool CanSeek => _length.HasValue;
            public override bool CanWrite { get; }

            public override long Length => _length.Value;

            public override long Position { get; set; }
            public IEnumerable<byte> AllBytes => _reads.SelectMany(r => r.Data);

            public static TestStreamRead Read(byte readId, int length)
            {
                var data = new byte[length];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = readId;
                }
                return new TestStreamRead(length, data);
            }

            public readonly struct TestStreamRead
            {
                public int Length { get; }
                public byte[] Data { get; }

                public TestStreamRead(int length, byte[] data)
                {
                    Length = length;
                    Data = data;
                }
            }
        }
    }
}
