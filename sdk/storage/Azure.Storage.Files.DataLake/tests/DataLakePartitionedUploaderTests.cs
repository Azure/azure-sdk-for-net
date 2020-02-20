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
using Azure.Core.Testing;
using Azure.Storage.Files.DataLake.Models;
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
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;
        private static readonly PathHttpHeaders s_pathHttpHeaders = new PathHttpHeaders()
        {
            CacheControl = "Please do",
            ContentEncoding = "Yes"
        };
        private static readonly DataLakeRequestConditions s_conditions = new DataLakeRequestConditions()
        {
            LeaseId = "MyImportantLease"
        };
        private static readonly Progress<long> s_progress = new Progress<long>();
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
            TestStream content = new TestStream(_async, null, TestStream.Read(0, 10));
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict,
                new Uri("http://mock"),
                new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.Version).CallBase();
            SetupAsyncStaging(clientMock, sink);

            DataLakePartitionedUploader uploader = new DataLakePartitionedUploader(clientMock.Object, default, arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        [Test]
        public async Task UploadsStreamInBlocksIfLengthIsOverTheLimit()
        {
            TestStream content = new TestStream(_async, 30, TestStream.Read(0, 10));
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.Version).CallBase();
            SetupAsyncStaging(clientMock, sink);

            DataLakePartitionedUploader uploader = new DataLakePartitionedUploader(
                clientMock.Object, new StorageTransferOptions { MaximumTransferLength = 20, InitialTransferLength = 20 }, arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(2, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        [Test]
        public async Task UploadsStreamInBlocksUnderSize()
        {
            TestStream content = new TestStream(_async, null,
                TestStream.Read(0, 10),
                TestStream.Read(1, 10)
            );
            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.Version).CallBase();
            SetupAsyncStaging(clientMock, sink);

            DataLakePartitionedUploader uploader = new DataLakePartitionedUploader(
                clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 20 }, arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            AssertAppended(sink, content);

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
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.Version).CallBase();
            SetupAsyncStaging(clientMock, sink);

            DataLakePartitionedUploader uploader = new DataLakePartitionedUploader(
                clientMock.Object, default, arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(1, sink.Appended.Count);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(1, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        [Test]
        public async Task SmallMaxWriteSize()
        {
            TestStream content = new TestStream(_async, null,
                Enumerable.Range(1, 1000).Select(b => TestStream.Read((byte)b, 2)).ToArray()
            );

            TrackingArrayPool testPool = new TrackingArrayPool();
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(
                MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.Version).CallBase();
            SetupAsyncStaging(clientMock, sink);

            DataLakePartitionedUploader uploader = new DataLakePartitionedUploader(
                clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 100 }, arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(s_response, info);
            Assert.AreEqual(0, testPool.CurrentCount);
            Assert.AreEqual(41, testPool.TotalRents);
            AssertAppended(sink, content);

            foreach (byte[] bytes in sink.Appended.Values)
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
            AppendSink sink = new AppendSink();

            Mock<DataLakeFileClient> clientMock = new Mock<DataLakeFileClient>(MockBehavior.Strict, new Uri("http://mock"), new DataLakeClientOptions());
            clientMock.SetupGet(c => c.ClientDiagnostics).CallBase();
            clientMock.SetupGet(c => c.Version).CallBase();
            SetupAsyncStaging(clientMock, sink);

            DataLakePartitionedUploader uploader = new DataLakePartitionedUploader(clientMock.Object, new StorageTransferOptions() { MaximumTransferLength = 20 }, arrayPool: testPool);
            Response<PathInfo> info = await InvokeUploadAsync(uploader, content);

            Assert.AreEqual(2, sink.Appended.Count);
            // First two should be merged
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 }, sink.Appended[0]);
            Assert.AreEqual(s_response, info);
            Assert.AreEqual(3, testPool.TotalRents);
            Assert.AreEqual(0, testPool.CurrentCount);
            AssertAppended(sink, content);
        }

        private async Task<Response<PathInfo>> InvokeUploadAsync(DataLakePartitionedUploader uploader, TestStream content)
        {
            if (_async)
            {
                return await uploader.UploadAsync(content, s_pathHttpHeaders, s_conditions, s_progress, s_cancellationToken);
            }
            else
            {
                return uploader.Upload(content, s_pathHttpHeaders, s_conditions, s_progress, s_cancellationToken);
            }
        }

        private void SetupAsyncStaging(Mock<DataLakeFileClient> clientMock, AppendSink sink)
        {
            if (_async)
            {
                clientMock.Setup(
                    c => c.CreateAsync(
                        s_pathHttpHeaders,
                        default,
                        default,
                        default,
                        s_conditions,
                        s_cancellationToken
                    )).Returns<PathHttpHeaders, IDictionary<string, string>, string, string, DataLakeRequestConditions, CancellationToken>(sink.CreateAsync);

                clientMock.Setup(
                    c => c.AppendAsync(
                        IsAny<Stream>(),
                        IsAny<long>(),
                        IsAny<byte[]>(),
                        IsAny<string>(),
                        IsAny<IProgress<long>>(),
                        s_cancellationToken
                    )).Returns<Stream, long, byte[], string, IProgress<long>, CancellationToken>(sink.AppendAsync);

                clientMock.Setup(
                    c => c.FlushAsync(
                        IsAny<long>(),
                        IsAny<bool?>(),
                        IsAny<bool?>(),
                        s_pathHttpHeaders,
                        IsAny<DataLakeRequestConditions>(),
                        s_cancellationToken
                    )).Returns<long, bool?, bool?, PathHttpHeaders, DataLakeRequestConditions, CancellationToken>(sink.FlushAsync);
            }
            else
            {
                clientMock.Setup(
                    c => c.Create(
                        s_pathHttpHeaders,
                        default,
                        default,
                        default,
                        s_conditions,
                        s_cancellationToken
                    )).Returns<PathHttpHeaders, IDictionary<string, string>, string, string, DataLakeRequestConditions, CancellationToken>(sink.Create);

                clientMock.Setup(
                    c => c.Append(
                        IsAny<Stream>(),
                        IsAny<long>(),
                        IsAny<byte[]>(),
                        IsAny<string>(),
                        IsAny<IProgress<long>>(),
                        s_cancellationToken
                    )).Returns<Stream, long, byte[], string, IProgress<long>, CancellationToken>(sink.Append);

                clientMock.Setup(
                    c => c.Flush(
                        IsAny<long>(),
                        IsAny<bool?>(),
                        IsAny<bool?>(),
                        s_pathHttpHeaders,
                        IsAny<DataLakeRequestConditions>(),
                        s_cancellationToken
                    )).Returns<long, bool?, bool?, PathHttpHeaders, DataLakeRequestConditions, CancellationToken>(sink.Flush);
            }
        }

        private static void AssertAppended(AppendSink sink, TestStream stream)
        {
            Assert.AreEqual(sink.Appended.Count, sink.Appended.Count);
            CollectionAssert.AreEqual(
                stream.AllBytes,
                sink.Appended.OrderBy(kv => kv.Key).SelectMany(kv => kv.Value));
        }

        private class AppendSink
        {
            public Dictionary<long, byte[]> Appended { get; }

            public AppendSink()
            {
                Appended = new Dictionary<long, byte[]>();
            }

            public async Task<Response<PathInfo>> CreateAsync(
                PathHttpHeaders httpHeaders,
                IDictionary<string, string> metadata,
                string permissions,
                string umask,
                DataLakeRequestConditions conditions,
                CancellationToken cancellationToken)
            {
                await Task.Delay(25);
                return Create(httpHeaders, metadata, permissions, umask, conditions, cancellationToken);
            }

            public Response<PathInfo> Create(
                PathHttpHeaders httpHeaders,
                IDictionary<string, string> metadata,
                string permissions,
                string umask,
                DataLakeRequestConditions conditions,
                CancellationToken cancellationToken)
            {
                return s_response;
            }

            public async Task<Response<PathInfo>> FlushAsync(
                long position,
                bool? retainUncommittedData,
                bool? close,
                PathHttpHeaders httpHeaders,
                DataLakeRequestConditions conditions,
                CancellationToken cancellationToken)
            {
                await Task.Delay(25);
                return Flush(position, retainUncommittedData, close, httpHeaders, conditions, cancellationToken);
            }

            public Response<PathInfo> Flush(
                long position,
                bool? retainUncommittedData,
                bool? close,
                PathHttpHeaders httpHeaders,
                DataLakeRequestConditions conditions,
                CancellationToken cancellationToken)
            {
                return s_response;
            }

            public async Task<Response> AppendAsync(
                Stream stream,
                long offset,
                byte[] hash,
                string leaseId,
                IProgress<long> progress,
                CancellationToken cancellationToken)
            {
                await Task.Delay(25);
                return Append(stream, offset, hash, leaseId, progress, cancellationToken);
            }

            public Response Append(
                Stream stream,
                long offset,
                byte[] hash,
                string leaseId,
                IProgress<long> progress,
                CancellationToken cancellationToken)
            {
                progress.Report(stream.Length);
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                lock (Appended)
                {
                    Appended.Add(offset, memoryStream.ToArray());
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
