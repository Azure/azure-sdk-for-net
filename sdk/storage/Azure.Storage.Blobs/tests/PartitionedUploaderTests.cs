// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Azure.Storage.Blobs.Test
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
        private static readonly Dictionary<string, string> s_tags = new Dictionary<string, string>() { { "tagKey", "tagValue" } };
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
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), default, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(2, testPool.TotalRents); // while conceptually there is one rental, the second rental occurs upon checking for stream end on a Read() call
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertStaged(sink, content);
        }

        [Test]
        public async Task UploadsStreamInBlocksIfLengthIsOverTheLimit()
        {
            PredictableStream content = new PredictableStream(30);
            StagingSink sink = new StagingSink();
            TrackingArrayPool testPool = new TrackingArrayPool();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(
                BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions
                {
                    MaximumTransferLength = 20,
                    InitialTransferSize = 20,
                    MaximumConcurrency = 1 // forces us through same code path
                },
                arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
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
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), new StorageTransferOptions() { MaximumTransferLength = 20}, arrayPool: testPool);
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
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), default, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(2, testPool.TotalRents); // while conceptually there is one rental, the second rental occurs upon checking for stream end on a Read() call
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
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), new StorageTransferOptions() { MaximumTransferLength = 100 }, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(0, testPool.CurrentCount);
            Assert.AreEqual(41, testPool.TotalRents);
            AssertStaged(sink, content);

            foreach (byte[] bytes in sink.Staged.Values.Select(val => val.Data))
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
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), new StorageTransferOptions() { MaximumTransferLength = 20}, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Staged.Count);
            // First two should be merged
            CollectionAssert.AreEqual(new byte[] {0, 0, 0, 0, 0, 1, 1, 1, 1, 1 }, sink.Staged[sink.Blocks.First()].Data);
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
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), new StorageTransferOptions() { MaximumTransferLength = 20});
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
                        c => c.UploadInternal(content, s_blobHttpHeaders, s_metadata, s_tags, s_conditions, s_accessTier, s_progress, default, true, s_cancellationToken))
                    .ReturnsAsync(s_response);
            }
            else
            {
                clientMock.Setup(c => c.UploadInternal(content, s_blobHttpHeaders, s_metadata, s_tags, s_conditions, s_accessTier, s_progress, default, false, s_cancellationToken))
                    .ReturnsAsync(s_response);
            }

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object), default, arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(0, testPool.TotalRents);
        }

        [Test]
        [Explicit]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12312")]
        public async Task CanHandleLongBlockBufferedUpload()
        {
            const long blockSize = int.MaxValue + 1024L;
            const int numBlocks = 2;
            Stream content = new Storage.Tests.Shared.PredictableStream(numBlocks * blockSize, revealsLength: false); // lack of Stream.Length forces buffered upload
            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink(false); // sink can't hold long blocks, and we don't need to look at their data anyway.

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(
                BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions
                {
                    InitialTransferSize = 1,
                    MaximumTransferSize = blockSize,
                },
                arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(numBlocks, sink.Staged.Count);
            Assert.AreEqual(numBlocks, sink.Blocks.Length);
            foreach (var block in sink.Staged.Values)
            {
                Assert.AreEqual(blockSize, block.StreamLength);
            }
        }

        [Test]
        public async Task NoBufferWhenUploadInSequenceOnSeekableStream()
        {
            const int blockSize = 10;

            TestStream content = new TestStream(
                _async,
                2 * blockSize, // stream needs length to avoid buffered upload
                TestStream.Read(0, blockSize),
                TestStream.Read(1, blockSize)
            );
            TrackingArrayPool testPool = new TrackingArrayPool();
            StagingSink sink = new StagingSink();

            Mock<BlockBlobClient> clientMock = new Mock<BlockBlobClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            SetupInternalStaging(clientMock, sink);

            var uploader = new PartitionedUploader<BlobUploadOptions, BlobContentInfo>(
                BlockBlobClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions()
                {
                    MaximumTransferSize = blockSize,
                    InitialTransferSize = blockSize, // known stream length means we need to specify this to force paritioned upload
                    MaximumConcurrency = 1 // concurrency=1 puts us into upload from sequence
                },
                arrayPool: testPool);
            Response<BlobContentInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Staged.Count);
            Assert.AreEqual(s_response, info);
            AssertStaged(sink, content);

            Assert.AreEqual(0, testPool.TotalRents); // if we rented, we did a buffered upload
            Assert.AreEqual(0, testPool.CurrentCount);
        }

        private async Task<Response<BlobContentInfo>> InvokeUploadAsync(PartitionedUploader<BlobUploadOptions, BlobContentInfo> uploader, Stream content)
        {
            return await uploader.UploadInternal(
                content,
                new BlobUploadOptions
                {
                    HttpHeaders = s_blobHttpHeaders,
                    Metadata = s_metadata,
                    Tags = s_tags,
                    Conditions = s_conditions,
                    AccessTier = s_accessTier,
                },
                s_progress,
                _async,
                s_cancellationToken).ConfigureAwait(false);
        }

        private void SetupInternalStaging(Mock<BlockBlobClient> clientMock, StagingSink sink)
        {
            clientMock.Setup(
                c => c.StageBlockInternal(
                    IsAny<string>(),
                    IsAny<Stream>(),
                    IsAny<byte[]>(),
                    s_conditions,
                    IsAny<IProgress<long>>(),
                    _async,
                    s_cancellationToken
                )).Returns<string, Stream, byte[], BlobRequestConditions, IProgress<long>, bool, CancellationToken>(sink.StageInternal);

            clientMock.Setup(
                c => c.CommitBlockListInternal(
                    IsAny<IEnumerable<string>>(),
                    s_blobHttpHeaders,
                    s_metadata,
                    s_tags,
                    s_conditions,
                    s_accessTier,
                    _async,
                    s_cancellationToken
                )).Returns<IEnumerable<string>, BlobHttpHeaders, Dictionary<string, string>, Dictionary<string, string>, BlobRequestConditions, AccessTier?, bool, CancellationToken>(sink.CommitInternal);
        }

        private static void AssertStaged(StagingSink sink, TestStream stream)
        {
            Assert.AreEqual(sink.Blocks.Length, sink.Staged.Count);
            CollectionAssert.AreEqual(
                stream.AllBytes,
                sink.Blocks.SelectMany(block => sink.Staged[block].Data));
        }

        private class StagingSink
        {
            private readonly bool _saveBytes;

            public string[] Blocks { get; set; }

            public Dictionary<string, (byte[] Data, long? StreamLength)> Staged { get; }

            public StagingSink(bool saveBytes = true)
            {
                _saveBytes = saveBytes;
                Staged = new Dictionary<string, (byte[], long?)>();
            }

            public async Task<Response<BlobContentInfo>> CommitInternal(
                IEnumerable<string> blocks,
                BlobHttpHeaders headers,
                Dictionary<string, string> metadata,
                Dictionary<string, string> tags,
                BlobRequestConditions accessConditions,
                AccessTier? accessTier,
                bool async,
                CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                Blocks = blocks.ToArray();
                return s_response;
            }

            public async Task<Response<BlockInfo>> StageInternal(string s, Stream stream, byte[] hash, BlobRequestConditions accessConditions, IProgress<long> progress, bool async, CancellationToken cancellationToken)
            {
                if (async)
                {
                    await Task.Delay(25);
                }
                progress.Report(stream.Length);
                byte[] data = default;
                if (_saveBytes)
                {
                    var memoryStream = new MemoryStream();
                    if (async)
                    {
                        await stream.CopyToAsync(memoryStream).ConfigureAwait(false);
                    }
                    else
                    {
                        stream.CopyTo(memoryStream);
                    }
                    memoryStream.Position = 0;
                    data = memoryStream.ToArray();
                }
                lock (Staged)
                {
                    Staged.Add(s, (data, stream.Length));
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

                Position += read.Length;
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
