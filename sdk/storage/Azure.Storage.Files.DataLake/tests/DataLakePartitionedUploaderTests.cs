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
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Azure.Storage.Files.DataLake.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class DataLakePartitionedUploaderTests
    {
        private readonly bool _async;

        // Use constants to verify that we flow them everywhere
        private static readonly PathHttpHeaders s_pathHttpHeaders = new PathHttpHeaders()
        {
            CacheControl = "Please do",
            ContentEncoding = "Yes"
        };
        private static readonly DataLakeRequestConditions s_conditions = new DataLakeRequestConditions()
        {
            LeaseId = "MyImportantLease"
        };
        private static readonly Dictionary<string, string> s_metadata = new Dictionary<string, string>
        {
            { "key", "value" }
        };
        private static readonly string s_permissions = "permissions";
        private static readonly string s_umask = "umask";
        private static readonly Progress<long> s_progress = new Progress<long>();
        private static readonly UploadTransferValidationOptions s_validationNone = new UploadTransferValidationOptions
        {
            ChecksumAlgorithm = StorageChecksumAlgorithm.None
        };
        private static readonly Response<PathInfo> s_response = Response.FromValue(
            new PathInfo(),
            new MockResponse(200));

        public DataLakePartitionedUploaderTests(bool async)
        {
            _async = async;
        }

        [Test]
        public async Task UploadsStreamInBlocksIfLengthNotAvailable()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestStream content = new TestStream(_async, null, TestStream.Read(0, 10));
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict,
                new Uri("http://mock"),
                new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                transferOptions: default,
                transferValidation: s_validationNone,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(1, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        [Test]
        public async Task UploadsStreamInBlocksIfLengthIsOverTheLimit()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            PredictableStream content = new PredictableStream(30);
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions { MaximumTransferLength = 20, InitialTransferLength = 20 },
                transferValidation: s_validationNone,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(2, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
        }

        [Test]
        public async Task UploadsStreamInBlocksUnderSize()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestStream content = new TestStream(_async, null,
                TestStream.Read(0, 10),
                TestStream.Read(1, 10)
            );
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions() { MaximumTransferLength = 10 },
                transferValidation: s_validationNone,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(2, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            AssertAppended(sink, content);

            Assert.AreEqual(2, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
        }

        [Test]
        public async Task MergesLotsOfSmallBlocks()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestStream content = new TestStream(_async, null,
                Enumerable.Range(1, 250).Select(b => TestStream.Read((byte)b, b)).ToArray()
            );

            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                transferOptions: default,
                transferValidation: s_validationNone,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(1, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        [Test]
        public async Task SmallMaxWriteSize()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestStream content = new TestStream(_async, null,
                Enumerable.Range(1, 1000).Select(b => TestStream.Read((byte)b, 2)).ToArray()
            );

            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions() { MaximumTransferLength = 100 },
                transferValidation: s_validationNone,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(0, testPool.CurrentCount);
            Assert.AreEqual(20, testPool.TotalRents);
            AssertAppended(sink, content);

            foreach ((byte[] bytes, _) in sink.Appended.Values)
            {
                Assert.LessOrEqual(bytes.Length, 100);
                Assert.GreaterOrEqual(bytes.Length, 50);
            }
        }

        [Test]
        public async Task MergesBlocksUntilTheyReachOverHalfMaxSize()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestStream content = new TestStream(_async, null,
                TestStream.Read(0, 5),
                TestStream.Read(1, 5),
                TestStream.Read(2, 10)
            );
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions() { MaximumTransferLength = 10 },
                transferValidation: s_validationNone,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(2, sink.Appended.Count);
            // First two should be merged
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 }, sink.Appended[0].Data);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(2, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        [Test]
        [Explicit]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12312")]
        public async Task CanHandleLongAppendBufferedUpload()
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            const long blockSize = int.MaxValue + 1024L;
            const int numBlocks = 2;
            Stream content = new Storage.Tests.Shared.PredictableStream(numBlocks * blockSize);
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink(false); // sink can't hold long blocks, and we don't need to look at their data anyway.

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientConfiguration.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.ClientConfiguration.ClientOptions.Version).CallBase();
            SetupInternalStaging(clientMock, sink, cts);

            var uploader = new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                DataLakeFileClient.GetPartitionedUploaderBehaviors(clientMock.Object),
                new StorageTransferOptions
                {
                    InitialTransferSize = 1, // forces buffered upload
                    MaximumTransferSize = blockSize,
                    MaximumConcurrency = 2
                },
                transferValidation: default,
                arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content, cts);

            Assert.AreEqual(s_response, info);
            foreach (var block in sink.Appended.Values)
            {
                Assert.AreEqual(blockSize, block.Length);
            }
        }

        private async Task<Response<PathInfo>> InvokeUploadAsync(
            PartitionedUploader<DataLakeFileUploadOptions, PathInfo> uploader,
            Stream content,
            CancellationTokenSource cts)
            => await uploader.UploadInternal(
                content,
                expectedContentLength: default,
                new DataLakeFileUploadOptions
                {
                    HttpHeaders = s_pathHttpHeaders,
                    Conditions = s_conditions,
                    Umask = s_umask,
                    Permissions = s_permissions
                },
                s_progress,
                _async,
                cts.Token);

        private void SetupInternalStaging(
            Mock<DataLakeFileClient> clientMock,
            AppendSink sink,
            CancellationTokenSource cts)
        {
            clientMock.Setup(
                c => c.CreateInternal(
                    IsAny<PathResourceType>(),
                    s_pathHttpHeaders,
                    default,
                    s_permissions,
                    s_umask,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    s_conditions,
                    _async,
                    cts.Token
                )).Returns<PathResourceType, PathHttpHeaders, IDictionary<string, string>, string, string, string, string, IList<PathAccessControlItem>, string, TimeSpan?, TimeSpan?, DateTimeOffset?, string, DataLakeRequestConditions, bool, CancellationToken>(sink.CreateInternal);

            clientMock.Setup(
                c => c.AppendInternal(
                    IsAny<Stream>(),
                    IsAny<long>(),
                    IsAny<UploadTransferValidationOptions>(),
                    IsAny<string>(),
                    IsAny<DataLakeLeaseAction?>(),
                    IsAny<TimeSpan?>(),
                    IsAny<string>(),
                    IsAny<IProgress<long>>(),
                    IsAny<bool?>(),
                    _async,
                    cts.Token
                )).Returns<Stream, long, UploadTransferValidationOptions, string, DataLakeLeaseAction?, TimeSpan?, string, IProgress<long>, bool?, bool, CancellationToken>(sink.AppendInternal);

            clientMock.Setup(
                c => c.FlushInternal(
                    IsAny<long>(),
                    IsAny<bool?>(),
                    IsAny<bool?>(),
                    s_pathHttpHeaders,
                    IsAny<DataLakeRequestConditions>(),
                    IsAny<DataLakeLeaseAction?>(),
                    IsAny<TimeSpan?>(),
                    IsAny<string>(),
                    _async,
                    cts.Token
                )).Returns<long, bool?, bool?, PathHttpHeaders, DataLakeRequestConditions, DataLakeLeaseAction?, TimeSpan?, string, bool, CancellationToken>(sink.FlushInternal);
        }

        private static void AssertAppended(AppendSink sink, TestStream stream)
        {
            Assert.AreEqual(sink.Appended.Count, sink.Appended.Count);

            CollectionAssert.AreEqual(
                stream.AllBytes,
                sink.Appended.OrderBy(kv => kv.Key).SelectMany(kv => kv.Value.Data));
        }

        private class AppendSink
        {
            private readonly bool _saveBytes;

            public Dictionary<long, (byte[] Data, long? Length)> Appended { get; }

            public AppendSink(bool saveBytes = true)
            {
                _saveBytes = saveBytes;
                Appended = new Dictionary<long, (byte[] Data, long? Length)>();
            }

            public async Task<Response<PathInfo>> CreateInternal(
                PathResourceType type,
                PathHttpHeaders httpHeaders,
                IDictionary<string, string> metadata,
                string permissions,
                string umask,
                string owner,
                string group,
                IList<PathAccessControlItem> accessControlList,
                string leaseId,
                TimeSpan? leaseDuration,
                TimeSpan? timeToExpire,
                DateTimeOffset? expiresOn,
                string encryptionContext,
                DataLakeRequestConditions conditions,
                bool async,
                CancellationToken cancellationToken)
            {
                if (async)
                {
                    await Task.Delay(25);
                }
                return s_response;
            }

            public async Task<Response<PathInfo>> FlushInternal(
                long position,
                bool? retainUncommittedData,
                bool? close,
                PathHttpHeaders httpHeaders,
                DataLakeRequestConditions conditions,
                DataLakeLeaseAction? leaseAction,
                TimeSpan? leaseDuration,
                string proposedLeaseId,
                bool async,
                CancellationToken cancellationToken)
            {
                if (async)
                {
                    await Task.Delay(25);
                }
                return s_response;
            }

            public async Task<Response> AppendInternal(
                Stream stream,
                long offset,
                UploadTransferValidationOptions validationOptions,
                string leaseId,
                DataLakeLeaseAction? leaseAction,
                TimeSpan? leaseDuration,
                string proposedLeaseId,
                IProgress<long> progressHandler,
                bool? flush,
                bool async,
                CancellationToken cancellationToken)
            {
                if (async)
                {
                    await Task.Delay(25);
                }
                progressHandler.Report(stream.Length);

                byte[] data = default;
                if (_saveBytes)
                {
                    var memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    data = memoryStream.ToArray();
                }
                lock (Appended)
                {
                    Appended.Add(offset, (data, stream.Length));
                }
                return new MockResponse(200);
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

        private class TestStream : Stream
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
                if (_async)
                    throw new InvalidOperationException();

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
                if (!_async)
                    throw new InvalidOperationException();

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
