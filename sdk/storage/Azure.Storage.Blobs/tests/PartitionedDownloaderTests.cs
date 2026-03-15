// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage;
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

        /// <summary>
        /// Verifies that downloading a zero-length blob succeeds and returns
        /// a valid response. The first ranged request returns HTTP 416 (InvalidRange),
        /// causing the downloader to retry without a range header and detect the
        /// empty blob via ContentLength == 0.
        /// </summary>
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

        /// <summary>
        /// Verifies that a blob smaller than the initial transfer size is downloaded
        /// in a single request (one-shot path) and the destination stream contains
        /// the correct bytes.
        /// </summary>
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

        /// <summary>
        /// Verifies that a blob larger than the maximum transfer size is split
        /// into multiple range requests. With 100 bytes, InitialTransferLength=20,
        /// and MaximumTransferLength=10, expects 9 requests (1 initial + 8 subsequent)
        /// and correct byte content in the destination.
        /// </summary>
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

        /// <summary>
        /// Verifies that InitialTransferLength and MaximumTransferLength are
        /// honored independently. The first request uses InitialTransferLength=10,
        /// and subsequent requests use MaximumTransferLength=40, resulting in
        /// 4 total requests for 100 bytes (10 + 40 + 40 + 10).
        /// </summary>
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

        /// <summary>
        /// Verifies that the ETag from the initial download response is captured
        /// and included as an IfMatch condition on all subsequent range requests.
        /// This prevents reading inconsistent data if the blob is modified
        /// mid-download. Also verifies that user-provided conditions (LeaseId,
        /// IfModifiedSince, etc.) are forwarded on every request.
        /// </summary>
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

        /// <summary>
        /// Verifies that an exception thrown by the first DownloadStreamingInternal
        /// call propagates directly to the caller without being wrapped or swallowed.
        /// </summary>
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

        /// <summary>
        /// Verifies the end-to-end CRC64 checksum validation happy path for a
        /// multi-block download. Each mock response includes a correct
        /// x-ms-content-crc64 header computed from the range data. This exercises:
        /// (1) per-partition checksum computation and comparison in both
        /// BufferResponseAsync (async) and CopyToInternal (sync),
        /// (2) master CRC composition via StorageCrc64Composer across partitions,
        /// and (3) final master CRC validation in ValidateFinalCrc comparing the
        /// composed CRC against an independently calculated whole-blob CRC.
        /// </summary>
        [Test]
        public async Task DownloadsSuccessfullyWithCrc64Validation()
        {
            MemoryStream destination = new MemoryStream();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);

            const int totalLength = 100;
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
                (range, conditions, validation, progress, operationName, async, cancellation) =>
                {
                    var response = CreateResponseWithCrc64(range, totalLength);
                    return async
                        ? new ValueTask<Response<BlobDownloadStreamingResult>>(Task.Delay(25).ContinueWith(_ => response))
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(response);
                });

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
                transferValidation: checksumValidation);

            Response result = await InvokeDownloadToAsync(downloader, destination);

            AssertContent(totalLength, destination);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned when the destination
        /// stream throws during a write. In the async/multi-worker path, this
        /// exercises the two-layer cleanup: ConsumeBufferedTask's finally block
        /// returns the current task's buffer, and the outer finally block in
        /// DownloadToInternal cleans up any remaining queued tasks.
        /// </summary>
        [Test]
        public async Task ReturnsArrayPoolBuffersOnDestinationWriteFailure()
        {
            TrackingArrayPool trackingPool = new TrackingArrayPool();
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
                transferValidation: s_validationOptions,
                arrayPool: trackingPool);

            Assert.CatchAsync<IOException>(async () => await InvokeDownloadToAsync(downloader, new ThrowingDestinationStream()));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after destination write failure");
        }

        /// <summary>
        /// Verifies that a 412 Precondition Failed response (caused by the blob's
        /// ETag changing mid-download) propagates as a RequestFailedException and
        /// that all ArrayPool buffers are properly cleaned up. The downloader pins
        /// the ETag from the initial response via IfMatch on subsequent requests;
        /// if the blob is modified, the server returns 412 ConditionNotMet.
        /// </summary>
        [Test]
        public async Task PropagatesEtagMismatchAndCleansUpBuffers()
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
                        // Simulate the server rejecting the request because the blob
                        // was modified after the initial download (ETag mismatch).
                        throw new RequestFailedException(
                            status: 412,
                            errorCode: BlobErrorCode.ConditionNotMet.ToString(),
                            message: "The condition specified using HTTP conditional header(s) is not met.",
                            innerException: null);
                    }
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

            RequestFailedException thrown = Assert.ThrowsAsync<RequestFailedException>(
                async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(412, thrown.Status);
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after ETag mismatch");
        }

        /// <summary>
        /// Verifies buffer cleanup when the initial download succeeds but a
        /// subsequent range request fails with an HTTP error (500). Unlike
        /// SurfacesDownloadExceptions which fails on the first request, this
        /// exercises the cleanup of mixed completed/in-flight tasks in the queue
        /// when a later DownloadStreamingInternal call throws.
        /// </summary>
        [Test]
        public async Task ReturnsArrayPoolBuffersOnLaterRangeFailure()
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
                        throw new RequestFailedException(500, "Internal Server Error");
                    }
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

            Assert.CatchAsync<RequestFailedException>(async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after later range HTTP failure");
        }

        /// <summary>
        /// Verifies buffer cleanup when a CancellationToken is cancelled mid-download.
        /// The token is cancelled in the mock callback for the second range request.
        /// When BufferResponseAsync or CopyToInternal checks the token via
        /// CancellationHelper.ThrowIfCancellationRequested, it throws
        /// OperationCanceledException. All rented ArrayPool buffers must still
        /// be returned despite the cancellation.
        /// </summary>
        [Test]
        public async Task ReturnsArrayPoolBuffersOnCancellation()
        {
            MemoryStream destination = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            TrackingArrayPool trackingPool = new TrackingArrayPool();
            CancellationTokenSource cts = new CancellationTokenSource();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            int requestCount = 0;
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                _async,
                It.IsAny<CancellationToken>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, async, cancellation) =>
                {
                    int current = Interlocked.Increment(ref requestCount);
                    if (current > 1)
                    {
                        // Cancel the token before returning the response;
                        // BufferResponseAsync/CopyToInternal will check it before reading.
                        cts.Cancel();
                    }
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

            Assert.CatchAsync<OperationCanceledException>(
                async () => await downloader.DownloadToInternal(destination, s_conditions, _async, cts.Token));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after cancellation");
        }

        /// <summary>
        /// Verifies that an IProgress&lt;long&gt; provided to the PartitionedDownloader
        /// constructor receives progress reports during download. The constructor
        /// wraps the user's handler in an AggregatingProgressIncrementer, which
        /// accumulates incremental byte counts and reports cumulative totals.
        /// The mock simulates the underlying client calling progress.Report()
        /// for each range, and we verify the final reported value equals the
        /// total bytes downloaded.
        /// </summary>
        [Test]
        public async Task ReportsProgressDuringDownload()
        {
            MemoryStream destination = new MemoryStream();
            TestProgress progress = new TestProgress();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

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
                (range, conditions, validation, progressArg, operationName, async, cancellation) =>
                {
                    long contentLength = Math.Min(range.Length ?? 0, 100);
                    // Simulate the underlying client reporting progress
                    progressArg?.Report(contentLength);

                    var memoryStream = new MemoryStream();
                    for (int i = 0; i < contentLength; i++)
                        memoryStream.WriteByte((byte)(range.Offset + i));
                    memoryStream.Position = 0;

                    var response = Response.FromValue(new BlobDownloadStreamingResult()
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
                    }, new MockResponse(200));

                    return async
                        ? new ValueTask<Response<BlobDownloadStreamingResult>>(Task.Delay(25).ContinueWith(_ => response))
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(response);
                });

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 10
                },
                transferValidation: s_validationOptions,
                progress: progress);

            Response result = await InvokeDownloadToAsync(downloader, destination);

            AssertContent(100, destination);
            Assert.NotNull(result);
            // AggregatingProgressIncrementer reports cumulative totals to the inner handler.
            // The final reported value should be the total bytes downloaded.
            Assert.AreEqual(100, progress.LastReportedValue);
        }

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned when the response
        /// stream throws IOException during ReadAsync. In the async path, this
        /// exercises the catch block in BufferResponseAsync that returns both
        /// the data buffer and checksum buffer before re-throwing. In the sync
        /// path, CopyToInternal propagates the exception through the using block
        /// that holds the rented checksum buffer.
        /// </summary>
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

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned when per-partition
        /// checksum validation fails. CRC64 validation is enabled but the mock
        /// responses lack x-ms-content-crc64 headers, so the computed hash
        /// (non-empty) never matches the empty response hash, triggering
        /// InvalidDataException from Errors.HashMismatchOnStreamedDownload.
        /// </summary>
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

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned when the response
        /// stream contains more data than the Content-Length header indicates.
        /// This guard only exists in BufferResponseAsync (async/multi-worker path),
        /// so the test is skipped for the sync fixture. An InfiniteStream always
        /// returns data on read, filling the rented buffer and then producing an
        /// extra byte on the overflow check, triggering InvalidOperationException.
        /// </summary>
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
        /// A stream that throws IOException on any write operation, used to simulate
        /// destination stream failures during download.
        /// </summary>
        private class ThrowingDestinationStream : MemoryStream
        {
            public override void Write(byte[] buffer, int offset, int count)
                => throw new IOException("Simulated destination write failure");
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
                => Task.FromException(new IOException("Simulated destination write failure"));
        }

        /// <summary>
        /// Simple IProgress implementation that tracks reported values.
        /// </summary>
        private class TestProgress : IProgress<long>
        {
            public long LastReportedValue { get; private set; }
            public int ReportCount { get; private set; }

            public void Report(long value)
            {
                LastReportedValue = value;
                ReportCount++;
            }
        }

        /// <summary>
        /// Creates a response with a valid CRC64 header matching the data content.
        /// Data bytes follow the MockDataSource pattern: (byte)(range.Offset + i).
        /// </summary>
        private static Response<BlobDownloadStreamingResult> CreateResponseWithCrc64(HttpRange range, int totalLength)
        {
            int contentLength = (int)Math.Min(range.Length ?? 0, totalLength);

            byte[] data = new byte[contentLength];
            for (int i = 0; i < contentLength; i++)
                data[i] = (byte)(range.Offset + i);

            var crc = StorageCrc64HashAlgorithm.Create();
            crc.Append(data);
            byte[] crcHash = new byte[8];
            crc.GetCurrentHash(crcHash);

            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader("x-ms-content-crc64", Convert.ToBase64String(crcHash));

            return Response.FromValue(new BlobDownloadStreamingResult()
            {
                Content = new MemoryStream(data),
                Details = new BlobDownloadDetails()
                {
                    BlobType = BlobType.Page,
                    ContentLength = contentLength,
                    ContentType = "test",
                    ContentHash = new byte[] { 1, 2, 3 },
                    LastModified = DateTimeOffset.Now,
                    Metadata = new Dictionary<string, string>() { { "meta", "data" } },
                    ContentRange = $"bytes {range.Offset}-{Math.Max(1, range.Offset + contentLength - 1)}/{totalLength}",
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
            }, mockResponse);
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
