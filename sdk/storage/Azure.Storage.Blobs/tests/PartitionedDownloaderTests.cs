// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class PartitionedDownloaderTests
    {
        private readonly bool _async;

        // Use constants to verify that we flow them everywhere
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;
        private static readonly BlobRequestConditions s_conditions = new BlobRequestConditions()
        {
            IfModifiedSince = DateTimeOffset.Now,
            LeaseId = "MyImportantLease"
        };
        private static readonly DownloadTransferValidationOptions s_validationOptions = new DownloadTransferValidationOptions();
        private static readonly ETag s_etag = new ETag("0xQWERTY");

        public PartitionedDownloaderTests(bool async)
        {
            _async = async;
        }

        [Test]
        public async Task ReturnsPropertiesForZeroLength()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(0);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            SetupDownloadEmptyBlob(blockClient, dataSource);

            DownloadTransferValidationOptions validationOptions = new DownloadTransferValidationOptions()
            {
                AutoValidateChecksum = true,
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64
            };

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                transferValidation: validationOptions);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(0, stream.Length);
            Assert.NotNull(result);
        }

        [Test]
        public async Task DownloadsInOneBlockIfUnderLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(10);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                transferValidation: s_validationOptions);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            AssertContent(10, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task DownloadsInBlocksWhenOverTheLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();
            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 9);
            AssertContent(100, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task RespectsInitialTransferSizeBeforeDownloadingInBlocks()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 40,
                    InitialTransferLength = 10
                },
                transferValidation: s_validationOptions);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 4);
            AssertContent(100, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task IncludesEtagInConditions()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 10
                },
                transferValidation: s_validationOptions);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 10);
            AssertContent(100, stream);
            Assert.NotNull(result);

            bool first = true;
            foreach ((HttpRange Range, BlobRequestConditions Conditions) request in dataSource.Requests)
            {
                Assert.AreEqual(s_conditions.LeaseId, request.Conditions.LeaseId);
                Assert.AreEqual(s_conditions.IfModifiedSince, request.Conditions.IfModifiedSince);
                Assert.AreEqual(s_conditions.IfUnmodifiedSince, request.Conditions.IfUnmodifiedSince);
                Assert.AreEqual(s_conditions.IfNoneMatch, request.Conditions.IfNoneMatch);
                if (first)
                {
                    first = false;
                }
                else
                {
                    Assert.AreEqual(s_etag, request.Conditions.IfMatch);
                }
            }
        }

        [Test]
        public void SurfacesDownloadExceptions()
        {
            Exception e = new Exception();

            MemoryStream stream = new MemoryStream();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<DownloadTransferValidationOptions>(),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)).ThrowsAsync(e);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions() { MaximumTransferLength = 10 },
                transferValidation: s_validationOptions);

            Exception thrown = Assert.ThrowsAsync<Exception>(async () => await InvokeDownloadToAsync(downloader, stream));

            Assert.AreSame(e, thrown);
        }

        private void AssertContent(int expectedLength, MemoryStream stream)
        {
            Assert.AreEqual(expectedLength, stream.Length);

            byte[] array = stream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual((byte)i, array[i]);
            }
        }

        private void SetupDownload(Mock<BlobBaseClient> blockClient, MockDataSource dataSource)
        {
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options != s_validationOptions && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, async, cancellation) => async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation)));
        }

        private void SetupDownloadEmptyBlob(Mock<BlobBaseClient> blockClient, MockDataSource dataSource)
        {
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            // empty blob with a range header, expect error
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.Is<HttpRange>(r => !r.Equals(default(HttpRange))),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options.ChecksumAlgorithm != StorageChecksumAlgorithm.None && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)
            ).ThrowsAsync(new RequestFailedException(
                status: 416,
                errorCode: BlobErrorCode.InvalidRange.ToString(),
                message: "The specified range is invalid.",
                innerException: null));

            // empty blob with no range header, expect complete
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.Is<HttpRange>(r => r.Equals(default(HttpRange))),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options.ChecksumAlgorithm == StorageChecksumAlgorithm.None),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, async, cancellation) => async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation)));
        }

        private async Task<Response> InvokeDownloadToAsync(PartitionedDownloader downloader, Stream stream)
        {
            return await downloader.DownloadToInternal(stream, s_conditions, _async, s_cancellationToken);
        }

        [Test]
        public async Task ReturnsArrayPoolBuffersOnStreamReadException()
        {
            MemoryStream destination = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            TrackingArrayPool trackingPool = new TrackingArrayPool();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            int requestCount = 0;
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options != s_validationOptions && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, async, cancellation) =>
                {
                    int current = Interlocked.Increment(ref requestCount);
                    if (current > 1)
                    {
                        // Return a response whose stream throws on read
                        long contentLength = Math.Min(range.Length ?? 0, 100);
                        return new ValueTask<Response<BlobDownloadStreamingResult>>(
                            Response.FromValue(new BlobDownloadStreamingResult()
                            {
                                Content = new ThrowingStream(),
                                Details = new BlobDownloadDetails()
                                {
                                    BlobType = BlobType.Page,
                                    ContentLength = contentLength,
                                    ContentType = "test",
                                    ContentHash = new byte[] { 1, 2, 3 },
                                    LastModified = DateTimeOffset.Now,
                                    Metadata = new Dictionary<string, string>() { { "meta", "data" } },
                                    ContentRange = $"bytes {range.Offset}-{Math.Max(1, range.Offset + contentLength - 1)}/100",
                                    ETag = s_etag,
                                    ContentEncoding = "test",
                                    CacheControl = "test",
                                    ContentDisposition = "test",
                                    ContentLanguage = "test",
                                    BlobSequenceNumber = 12,
                                    CopyCompletedOn = DateTimeOffset.Now,
                                    CopyStatusDescription = "test",
                                    CopyId = "test",
                                    CopyProgress = "test",
                                    CopySource = new Uri("http://example.com"),
                                    CopyStatus = CopyStatus.Failed,
                                    LeaseDuration = LeaseDurationType.Fixed,
                                    LeaseState = LeaseState.Expired,
                                    LeaseStatus = LeaseStatus.Unlocked,
                                    AcceptRanges = "test",
                                    BlobCommittedBlockCount = 5,
                                    IsServerEncrypted = true,
                                    EncryptionKeySha256 = "test",
                                }
                            }, new MockResponse(200)));
                    }
                    // First request returns normal data
                    return async
                        ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation));
                });

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 10
                },
                transferValidation: s_validationOptions,
                arrayPool: trackingPool);

            Assert.ThrowsAsync<IOException>(async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after exception");
        }

        [Test]
        public async Task ReturnsArrayPoolBuffersOnChecksumMismatch()
        {
            MemoryStream destination = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            TrackingArrayPool trackingPool = new TrackingArrayPool();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, async, cancellation) => async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation)));

            // Enable CRC64 validation — MockDataSource responses lack checksum headers,
            // so the computed hash will never match, triggering a hash mismatch exception.
            DownloadTransferValidationOptions checksumValidation = new DownloadTransferValidationOptions()
            {
                AutoValidateChecksum = true,
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64
            };

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 10
                },
                transferValidation: checksumValidation,
                arrayPool: trackingPool);

            Assert.CatchAsync<InvalidDataException>(async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after checksum mismatch");
        }

        [Test]
        public async Task ReturnsArrayPoolBuffersOnContentLengthOverflow()
        {
            // The Content-Length overflow guard only exists in BufferResponseAsync (async/multi-worker path)
            if (!_async)
            {
                Assert.Ignore("Content-Length overflow guard only exists in the buffered (async) path");
            }

            MemoryStream destination = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            TrackingArrayPool trackingPool = new TrackingArrayPool();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            int requestCount = 0;
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options != s_validationOptions && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, async, cancellation) =>
                {
                    int current = Interlocked.Increment(ref requestCount);
                    if (current > 1)
                    {
                        // Return a response whose stream produces more data than Content-Length indicates
                        long contentLength = range.Length ?? 10;
                        return new ValueTask<Response<BlobDownloadStreamingResult>>(
                            Response.FromValue(new BlobDownloadStreamingResult()
                            {
                                Content = new InfiniteStream(),
                                Details = new BlobDownloadDetails()
                                {
                                    BlobType = BlobType.Page,
                                    ContentLength = contentLength,
                                    ContentType = "test",
                                    ContentHash = new byte[] { 1, 2, 3 },
                                    LastModified = DateTimeOffset.Now,
                                    Metadata = new Dictionary<string, string>() { { "meta", "data" } },
                                    ContentRange = $"bytes {range.Offset}-{Math.Max(1, range.Offset + contentLength - 1)}/100",
                                    ETag = s_etag,
                                    ContentEncoding = "test",
                                    CacheControl = "test",
                                    ContentDisposition = "test",
                                    ContentLanguage = "test",
                                    BlobSequenceNumber = 12,
                                    CopyCompletedOn = DateTimeOffset.Now,
                                    CopyStatusDescription = "test",
                                    CopyId = "test",
                                    CopyProgress = "test",
                                    CopySource = new Uri("http://example.com"),
                                    CopyStatus = CopyStatus.Failed,
                                    LeaseDuration = LeaseDurationType.Fixed,
                                    LeaseState = LeaseState.Expired,
                                    LeaseStatus = LeaseStatus.Unlocked,
                                    AcceptRanges = "test",
                                    BlobCommittedBlockCount = 5,
                                    IsServerEncrypted = true,
                                    EncryptionKeySha256 = "test",
                                }
                            }, new MockResponse(200)));
                    }
                    // First request returns normal data
                    return async
                        ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation));
                });

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 10
                },
                transferValidation: s_validationOptions,
                arrayPool: trackingPool);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after content-length overflow");
        }

        /// <summary>
        /// A stream that throws IOException on any read operation, used to simulate
        /// download failures in BufferResponseAsync.
        /// </summary>
        private class ThrowingStream : Stream
        {
            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => 0;
            public override long Position { get; set; }
            public override void Flush() { }
            public override int Read(byte[] buffer, int offset, int count) => throw new IOException("Simulated read failure");
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
                => Task.FromException<int>(new IOException("Simulated read failure"));
        }

        /// <summary>
        /// A stream that always returns data on read, used to simulate a response
        /// with more data than the Content-Length header indicates.
        /// </summary>
        private class InfiniteStream : Stream
        {
            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position { get; set; }
            public override void Flush() { }
            public override int Read(byte[] buffer, int offset, int count)
            {
                for (int i = offset; i < offset + count; i++)
                    buffer[i] = 0xAA;
                return count;
            }
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                for (int i = offset; i < offset + count; i++)
                    buffer[i] = 0xAA;
                return Task.FromResult(count);
            }
        }

        /// <summary>
        /// An ArrayPool wrapper that tracks outstanding rentals to verify proper cleanup.
        /// </summary>
        private class TrackingArrayPool : ArrayPool<byte>
        {
            private readonly ArrayPool<byte> _inner = ArrayPool<byte>.Shared;
            private int _rentCount;
            private int _returnCount;

            public int OutstandingRentals => _rentCount - _returnCount;

            public override byte[] Rent(int minimumLength)
            {
                Interlocked.Increment(ref _rentCount);
                return _inner.Rent(minimumLength);
            }

            public override void Return(byte[] array, bool clearArray = false)
            {
                Interlocked.Increment(ref _returnCount);
                _inner.Return(array, clearArray);
            }
        }

        private class MockDataSource
        {
            private readonly int _length;

            public List<(HttpRange Range, BlobRequestConditions Conditions)> Requests { get; } = new List<(HttpRange Range, BlobRequestConditions Conditions)>();

            public MockDataSource(int length)
            {
                _length = length;
            }

            public async Task<Response<BlobDownloadStreamingResult>> GetStreamInternal(
                HttpRange range,
                BlobRequestConditions conditions,
                DownloadTransferValidationOptions transferValidation,
                IProgress<long> progress,
                string operationName,
                bool async,
                CancellationToken cancellationToken)
            {
                if (async)
                {
                    await Task.Delay(25);
                }
                return GetStream(
                    range,
                    conditions,
                    transferValidation,
                    progress,
                    cancellationToken);
            }

            public async ValueTask<Response<BlobDownloadStreamingResult>> GetStreamAsync(HttpRange range, BlobRequestConditions conditions = default, DownloadTransferValidationOptions validation = default, IProgress<long> progress = default, CancellationToken token = default)
            {
                await Task.Delay(25);
                return GetStream(range, conditions, validation, progress, token);
            }

            public HttpRange FullRange => new HttpRange(0, _length);

            public Response<BlobDownloadStreamingResult> GetStream(HttpRange range, BlobRequestConditions conditions, DownloadTransferValidationOptions validation, IProgress<long> progress, CancellationToken token)
            {
                lock (Requests)
                {
                    Requests.Add((range, conditions));
                }

                var contentLength = Math.Min(range.Length ?? 0, _length);

                var memoryStream = new MemoryStream();
                for (int i = 0; i < contentLength; i++)
                {
                    if (i > _length)
                    {
                        throw new InvalidOperationException();
                    }

                    memoryStream.WriteByte((byte)(range.Offset + i));
                }

                memoryStream.Position = 0;

                return Response.FromValue(new BlobDownloadStreamingResult()
                {
                    Content = memoryStream,
                    Details = new BlobDownloadDetails()
                    {
                        BlobType = BlobType.Page,
                        ContentLength = contentLength,
                        ContentType = "test",
                        ContentHash = new byte[] { 1, 2, 3 },
                        LastModified = DateTimeOffset.Now,
                        Metadata = new Dictionary<string, string>() { { "meta", "data" } },
                        ContentRange = $"bytes {range.Offset}-{Math.Max(1, range.Offset + contentLength - 1)}/{_length}",
                        ETag = s_etag,
                        ContentEncoding = "test",
                        CacheControl = "test",
                        ContentDisposition = "test",
                        ContentLanguage = "test",
                        BlobSequenceNumber = 12,
                        CopyCompletedOn = DateTimeOffset.Now,
                        CopyStatusDescription = "test",
                        CopyId = "test",
                        CopyProgress = "test",
                        CopySource = new Uri("http://example.com"),
                        CopyStatus = CopyStatus.Failed,
                        LeaseDuration = LeaseDurationType.Fixed,
                        LeaseState = LeaseState.Expired,
                        LeaseStatus = LeaseStatus.Unlocked,
                        AcceptRanges = "test",
                        BlobCommittedBlockCount = 5,
                        IsServerEncrypted = true,
                        EncryptionKeySha256 = "test",
                    }
                }, new MockResponse(200));
            }
        }
    }
}
