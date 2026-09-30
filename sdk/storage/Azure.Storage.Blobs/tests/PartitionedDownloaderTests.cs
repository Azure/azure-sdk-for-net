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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();
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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<DownloadTransferValidationOptions>(),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
                _async,
                s_cancellationToken)).ThrowsAsync(e);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions() { MaximumTransferLength = 10 },
                transferValidation: s_validationOptions);

            Exception thrown = Assert.ThrowsAsync<Exception>(async () => await InvokeDownloadToAsync(downloader, stream));

            Assert.AreSame(e, thrown);
        }

        [Test]
        public async Task DataLocality_FetchesLayoutAndRoutesChunksToLayoutEndpoints()
        {
            // Arrange - 100 byte blob with data locality enabled and download hint present
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] expectedSegments = new[]
            {
                new BlobLayoutSegment { Start = 20, End = 45, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 46, End = 82, Endpoint = "https://host-b:443" },
                new BlobLayoutSegment { Start = 83, End = 99, Endpoint = "https://host-c:443" },
            };

            SetupGetLayout(blockClient, expectedSegments);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content downloaded correctly
            AssertContent(100, stream);
            Assert.NotNull(result);

            // With initial=20, chunk=10, total=100 we expect exactly:
            //   1 initial call (no layout cache) + 8 subsequent chunk calls
            //   Chunks [20-29],[30-39],[40-49] → host-a  (3 chunks)
            //   Chunks [50-59],[60-69],[70-79],[80-89] → host-b  (4 chunks)
            //   Chunks [90-99] → host-c  (1 chunk)
            Assert.AreEqual(9, capturedCalls.Count, "Expected 1 initial + 8 subsequent chunk calls");

            // First call (initial download) has no layout cache
            Assert.IsNull(capturedCalls[0].LayoutCache);
            Assert.AreEqual(new HttpRange(0, 20), capturedCalls[0].Range);

            // Verify every subsequent chunk resolves to the correct layout endpoint.
            // Resolving the cache here triggers the underlying GetLayout/GetLayoutAsync
            // mock since DownloadStreamingInternal itself is mocked.
            AutoRefreshingCache<BlobLayoutSegmentCacheValue> sharedCache = capturedCalls[1].LayoutCache;
            int hostACount = 0;
            int hostBCount = 0;
            int hostCCount = 0;
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                var (range, layoutCache) = capturedCalls[i];
                Assert.NotNull(range);
                Assert.IsNotNull(layoutCache, $"Chunk {i} at range [{range.Offset}] should have layout cache");
                Assert.AreSame(sharedCache, layoutCache,
                    $"Chunk {i} should receive the same AutoRefreshingCache instance as chunk 1");

                BlobLayoutSegmentCacheValue cached = await layoutCache.GetAsync(async: _async, CancellationToken.None);
                BlobLayoutSegment[] segments = cached.Segments;
                Assert.IsNotNull(segments, $"Chunk {i} at range [{range.Offset}] should have layout segments");

                string LayoutEndpoint = BlobExtensions.GetLayoutEndpoint(range, segments);
                Assert.IsNotNull(LayoutEndpoint, $"Chunk at range [{range.Offset}] should resolve to a layout endpoint");

                if (range.Offset < 46)
                {
                    Assert.AreEqual("https://host-a:443", LayoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-a");
                    hostACount++;
                }
                else if (range.Offset < 83)
                {
                    Assert.AreEqual("https://host-b:443", LayoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-b");
                    hostBCount++;
                }
                else
                {
                    Assert.AreEqual("https://host-c:443", LayoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-c");
                    hostCCount++;
                }
            }

            // Assert - GetLayout was called exactly once (cache de-duplicates concurrent acquires)
            // and was invoked with the remaining range only: HttpRange(initialLength, totalLength - initialLength)
            // = HttpRange(20, 80) for this test (initial=20, total=100).
            if (_async)
            {
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.Is<BlobGetLayoutOptions>(o => (o == null ? default(HttpRange) : o.Range).Offset == 20 && (o == null ? default(HttpRange) : o.Range).Length == 80),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.Is<BlobGetLayoutOptions>(o => (o == null ? default(HttpRange) : o.Range).Offset == 20 && (o == null ? default(HttpRange) : o.Range).Length == 80),
                    It.IsAny<CancellationToken>()), Times.Once);
            }

            Assert.AreEqual(3, hostACount, "Exactly 3 chunks ([20-29]..[40-49]) should route to host-a");
            Assert.AreEqual(4, hostBCount, "Exactly 4 chunks ([50-59]..[80-89]) should route to host-b");
            Assert.AreEqual(1, hostCCount, "Exactly 1 chunk ([90-99]) should route to host-c");
        }

        [Test]
        public async Task DataLocality_NoDownloadHint_SkipsLayout()
        {
            // Arrange - 100 byte blob with NO download hint
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: default);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content correct
            AssertContent(100, stream);
            Assert.NotNull(result);

            // Assert - GetLayout was NOT called
            blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);

            Assert.AreEqual(9, capturedCalls.Count, "Expected 1 initial + 8 subsequent chunk calls");

            // Assert - all calls received null layout cache (no routing would occur)
            foreach (var (range, layoutCache) in capturedCalls)
            {
                Assert.NotNull(range);
                Assert.IsNull(layoutCache, $"Layout cache should be null for chunk at offset {range.Offset} when download hint is absent");
            }
        }

        [Test]
        public async Task DataLocality_Disabled_SkipsLayout()
        {
            // Arrange - 100 byte blob with download hint present but feature disabled
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            // layoutAwareRouting: LayoutAwareRouting.Disabled (default)
            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Disabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content correct
            AssertContent(100, stream);
            Assert.NotNull(result);

            // Assert - GetLayout was NOT called
            blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);

            Assert.AreEqual(9, capturedCalls.Count, "Expected 1 initial + 8 subsequent chunk calls");

            // Assert - all calls received null layout cache (no routing would occur)
            foreach (var (range, layoutCache) in capturedCalls)
            {
                Assert.NotNull(range);
                Assert.IsNull(layoutCache, $"Layout cache should be null for chunk at offset {range.Offset} when data locality is disabled");
            }
        }

        [TestCase(400)]
        [TestCase(503)]
        public async Task DataLocality_GetLayoutSoftFailure_CachesNullAndDownloadSucceeds(int status)
        {
            // Arrange - 100 byte blob; GetLayout fails with a soft (400 or 5xx) error.
            // FetchLayoutInternal should swallow it, the cache should store a
            // null-Segments value for the full TTL, and the download should
            // still complete successfully (chunks fall back to the original endpoint).
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            RequestFailedException softFailure = new RequestFailedException(
                status: status,
                message: $"Soft failure ({status})",
                errorCode: null,
                innerException: null);

            blockClient.Setup(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(softFailure);
            blockClient.Setup(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(softFailure);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content downloaded correctly despite layout failure
            AssertContent(100, stream);
            Assert.NotNull(result);

            // Assert - chunked calls received a cache whose resolved value has null Segments
            Assert.AreEqual(9, capturedCalls.Count, "Expected 1 initial + 8 subsequent chunk calls");
            Assert.IsNull(capturedCalls[0].LayoutCache, "Initial download has no layout cache");

            for (int i = 1; i < capturedCalls.Count; i++)
            {
                Assert.IsNotNull(capturedCalls[i].LayoutCache, $"Chunk {i} should have a layout cache");
                BlobLayoutSegmentCacheValue cached = await capturedCalls[i].LayoutCache.GetAsync(async: _async, CancellationToken.None);
                Assert.IsNull(cached.Segments, $"Chunk {i} should see null Segments after a soft GetLayout failure");
            }

            // Assert - GetLayout invoked at most once across all chunks (cache de-dups the failure)
            if (_async)
            {
                blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [Test]
        public async Task DataLocality_EmptyLayoutResponse_CachesEmptyArrayAndDownloadSucceeds()
        {
            // Arrange - 100 byte blob; service returns an explicitly-empty layout
            // (no ranges/endpoints). FetchLayoutInternal should normalize this to
            // an empty array, the cache should store it for the full TTL, and the
            // download should complete with chunks falling back to the original endpoint.
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            // Empty array → SetupGetLayout produces a BlobLayoutInfo with no ranges/endpoints
            SetupGetLayout(blockClient, Array.Empty<BlobLayoutSegment>());

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content downloaded correctly
            AssertContent(100, stream);
            Assert.NotNull(result);

            Assert.AreEqual(9, capturedCalls.Count, "Expected 1 initial + 8 subsequent chunk calls");
            Assert.IsNull(capturedCalls[0].LayoutCache);

            // Assert - chunked calls see an empty (non-null) Segments array
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                Assert.IsNotNull(capturedCalls[i].LayoutCache, $"Chunk {i} should have a layout cache");
                BlobLayoutSegmentCacheValue cached = await capturedCalls[i].LayoutCache.GetAsync(async: _async, CancellationToken.None);
                Assert.IsNotNull(cached.Segments, $"Chunk {i} should see a non-null empty Segments array (not soft-failure null)");
                Assert.AreEqual(0, cached.Segments.Length, $"Chunk {i} should see an empty Segments array");
            }

            // Assert - GetLayout was called exactly once across all chunks
            if (_async)
            {
                blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [TestCase(401)]
        [TestCase(404)]
        public void DataLocality_GetLayoutNonSoftFailure_PropagatesException(int status)
        {
            // Arrange - 100 byte blob; GetLayout fails with a non-soft status.
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
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
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string, bool, CancellationToken>(
                async (range, conditions, validation, progress, operationName, layoutCache, LayoutEndpoint, async, cancellation) =>
                {
                    if (layoutCache != null)
                    {
                        await layoutCache.GetAsync(async, cancellation).ConfigureAwait(false);
                    }
                    return async
                        ? await dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation).ConfigureAwait(false)
                        : dataSource.GetStream(range, conditions, validation, progress: progress, cancellation);
                });

            RequestFailedException nonSoftFailure = new RequestFailedException(
                status: status,
                message: $"Non-soft failure ({status})",
                errorCode: null,
                innerException: null);

            blockClient.Setup(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(nonSoftFailure);
            blockClient.Setup(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(nonSoftFailure);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act + Assert - the non-soft RequestFailedException propagates out of DownloadToInternal.
            RequestFailedException thrown = Assert.ThrowsAsync<RequestFailedException>(
                async () => await InvokeDownloadToAsync(downloader, stream));
            Assert.AreEqual(status, thrown.Status);
        }

        [Test]
        public async Task DataLocality_MultiPageLayoutResponse_AggregatesSegmentsAcrossPages()
        {
            // Arrange - 100 byte blob; GetLayout returns segments split across 2 pages.
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            // Page 1: covers [20-49] on host-a
            BlobLayoutSegment[] page1Segments = new[]
            {
                new BlobLayoutSegment { Start = 20, End = 49, Endpoint = "https://host-a:443" },
            };
            // Page 2: covers [50-99] on host-b
            BlobLayoutSegment[] page2Segments = new[]
            {
                new BlobLayoutSegment { Start = 50, End = 99, Endpoint = "https://host-b:443" },
            };

            SetupGetLayoutPages(blockClient, new[] { page1Segments, page2Segments });

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);
            AssertContent(100, stream);
            Assert.NotNull(result);

            // Assert - resolved cache contains BOTH pages' segments, in page order.
            Assert.AreEqual(9, capturedCalls.Count, "Expected 1 initial + 8 subsequent chunk calls");
            BlobLayoutSegmentCacheValue cached = await capturedCalls[1].LayoutCache.GetAsync(async: _async, CancellationToken.None);
            Assert.IsNotNull(cached.Segments);
            Assert.AreEqual(2, cached.Segments.Length, "Aggregated segments from both pages should be preserved");
            Assert.AreEqual("https://host-a:443", cached.Segments[0].Endpoint);
            Assert.AreEqual("https://host-b:443", cached.Segments[1].Endpoint);

            // Assert - chunks in each page route to the correct endpoint, proving
            // the aggregated array is usable end-to-end (not just stored).
            int hostACount = 0;
            int hostBCount = 0;
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                var (range, layoutCache) = capturedCalls[i];
                BlobLayoutSegmentCacheValue resolved = await layoutCache.GetAsync(async: _async, CancellationToken.None);
                string LayoutEndpoint = BlobExtensions.GetLayoutEndpoint(range, resolved.Segments);

                if (range.Offset < 50)
                {
                    Assert.AreEqual("https://host-a:443", LayoutEndpoint,
                        $"Chunk at offset {range.Offset} (page-1 range) should route to host-a");
                    hostACount++;
                }
                else
                {
                    Assert.AreEqual("https://host-b:443", LayoutEndpoint,
                        $"Chunk at offset {range.Offset} (page-2 range) should route to host-b");
                    hostBCount++;
                }
            }

            Assert.AreEqual(3, hostACount, "Chunks [20-29],[30-39],[40-49] should resolve via the page-1 segment");
            Assert.AreEqual(5, hostBCount, "Chunks [50-59]..[90-99] should resolve via the page-2 segment");

            // Assert - GetLayout was called exactly once even though it returned 2 pages.
            if (_async)
            {
                blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [Test]
        public async Task DataLocality_LayoutCacheIsPerDownload_NotSharedAcrossInvocations()
        {
            // Arrange - one PartitionedDownloader instance, two DownloadToInternal calls.
            // The layout cache lives inside DownloadToInternal, so each download should
            // perform its own GetLayout — guarding against a refactor that promotes the
            // cache to a field and accidentally shares stale layouts across downloads.
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            MockDataSource dataSource = new MockDataSource(100, downloadHint: DownloadHint.Layout);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 20, End = 99, Endpoint = "https://host-a:443" },
            };
            SetupGetLayout(blockClient, segments);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act - run the download twice on the same downloader. After each
            // download, resolve the cache once to force a GetLayout invocation
            // (DownloadStreamingInternal is mocked, so it never resolves the
            // cache on its own).
            MemoryStream stream1 = new MemoryStream();
            Response result1 = await InvokeDownloadToAsync(downloader, stream1);
            int firstDownloadCallCount = capturedCalls.Count;
            AutoRefreshingCache<BlobLayoutSegmentCacheValue> firstDownloadCache = capturedCalls[1].LayoutCache;
            Assert.IsNotNull(firstDownloadCache, "First download should construct a layout cache");
            await firstDownloadCache.GetAsync(async: _async, CancellationToken.None);

            MemoryStream stream2 = new MemoryStream();
            Response result2 = await InvokeDownloadToAsync(downloader, stream2);
            AutoRefreshingCache<BlobLayoutSegmentCacheValue> secondDownloadCache = capturedCalls[firstDownloadCallCount + 1].LayoutCache;
            Assert.IsNotNull(secondDownloadCache, "Second download should construct a layout cache");
            await secondDownloadCache.GetAsync(async: _async, CancellationToken.None);

            // Assert - both downloads complete correctly
            AssertContent(100, stream1);
            AssertContent(100, stream2);
            Assert.NotNull(result1);
            Assert.NotNull(result2);

            // Assert - the two downloads received distinct cache instances. This is
            // what guarantees per-download isolation; GetLayout call count alone
            // wouldn't catch a refactor that shared a single cache field — within a
            // 5-min TTL the second download would still return the cached value
            // without re-issuing GetLayout.
            Assert.AreNotSame(firstDownloadCache, secondDownloadCache,
                "Each DownloadToInternal call should construct its own AutoRefreshingCache");

            // Assert - GetLayout was invoked once per download (one per cache resolve).
            if (_async)
            {
                blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
            }
        }

        [Test]
        public async Task DataLocality_OneShotDownload_DoesNotConstructLayoutCache()
        {
            // Arrange - blob fits entirely in the initial range. Even with data locality
            // enabled and a download hint present, no chunked downloads occur, so
            // GetLayout must not be called and no AutoRefreshingCache should be built.
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(10, downloadHint: DownloadHint.Layout);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            // Initial range (20) >= blob size (10) → one-shot path
            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                layoutAwareRouting: LayoutAwareRouting.Enabled);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content correct, exactly one DownloadStreamingInternal call, no layout
            AssertContent(10, stream);
            Assert.NotNull(result);
            Assert.AreEqual(1, capturedCalls.Count, "One-shot download should issue exactly one DownloadStreamingInternal call");
            Assert.IsNull(capturedCalls[0].LayoutCache, "One-shot download should not construct a layout cache");

            blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);
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

        private void SetupDownloadWithCapture(
            Mock<BlobBaseClient> blockClient,
            MockDataSource dataSource,
            List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)> capturedCalls)
        {
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options != s_validationOptions && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, layoutCache, LayoutEndpoint, async, cancellation) =>
                {
                    lock (capturedCalls)
                    {
                        capturedCalls.Add((range, layoutCache));
                    }
                    return async
                        ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation));
                });
        }

        private void SetupGetLayout(Mock<BlobBaseClient> blockClient, BlobLayoutSegment[] segments)
        {
            // Build a BlobLayoutInfo that will convert to the given segments
            var rangeItems = new List<BlobLayoutRange>();
            var endpointItems = new List<BlobLayoutEndpoint>();
            var endpointMap = new Dictionary<string, int>();

            foreach (var seg in segments)
            {
                if (!endpointMap.TryGetValue(seg.Endpoint, out int idx))
                {
                    idx = endpointMap.Count;
                    endpointMap[seg.Endpoint] = idx;
                    endpointItems.Add(BlobsModelFactory.BlobLayoutEndpoint(index: idx, value: seg.Endpoint));
                }
                rangeItems.Add(BlobsModelFactory.BlobLayoutRange(start: seg.Start, end: seg.End, endpointIndex: idx));
            }

            BlobLayoutInfo layoutInfo = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(rangeItems),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(endpointItems),
            };

            // Setup GetLayoutAsync (for async path)
            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<BlobGetLayoutOptions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockAsyncPageable(layoutInfo));

            // Setup GetLayout (for sync path)
            blockClient.Setup(c => c.GetLayout(
                It.IsAny<BlobGetLayoutOptions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockPageable(layoutInfo));
        }

        private void SetupGetLayoutPages(Mock<BlobBaseClient> blockClient, BlobLayoutSegment[][] pages)
        {
            // Build one BlobLayoutInfo per page so the pageable yields multiple pages.
            BlobLayoutInfo[] layoutInfos = new BlobLayoutInfo[pages.Length];
            for (int p = 0; p < pages.Length; p++)
            {
                BlobLayoutSegment[] segments = pages[p];
                var rangeItems = new List<BlobLayoutRange>();
                var endpointItems = new List<BlobLayoutEndpoint>();
                var endpointMap = new Dictionary<string, int>();

                foreach (var seg in segments)
                {
                    if (!endpointMap.TryGetValue(seg.Endpoint, out int idx))
                    {
                        idx = endpointMap.Count;
                        endpointMap[seg.Endpoint] = idx;
                        endpointItems.Add(BlobsModelFactory.BlobLayoutEndpoint(index: idx, value: seg.Endpoint));
                    }
                    rangeItems.Add(BlobsModelFactory.BlobLayoutRange(start: seg.Start, end: seg.End, endpointIndex: idx));
                }

                layoutInfos[p] = new BlobLayoutInfo
                {
                    Ranges = BlobsModelFactory.BlobLayoutRanges(rangeItems),
                    Endpoints = BlobsModelFactory.BlobLayoutEndpoints(endpointItems),
                };
            }

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<BlobGetLayoutOptions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockAsyncPageable(layoutInfos));

            blockClient.Setup(c => c.GetLayout(
                It.IsAny<BlobGetLayoutOptions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockPageable(layoutInfos));
        }

        /// <summary>
        /// Creates a strict <see cref="Mock{BlobBaseClient}"/> with the boilerplate
        /// setups (<see cref="BlobBaseClient.ClientConfiguration"/> and
        /// <see cref="BlobBaseClient.UsingClientSideEncryption"/>) every test in this
        /// fixture needs.
        /// </summary>
        private static Mock<BlobBaseClient> CreateMockBlobClient()
        {
            Mock<BlobBaseClient> client = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            client.SetupGet(c => c.ClientConfiguration).CallBase();
            client.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            return client;
        }

        /// <summary>
        /// Builds a fully-populated <see cref="BlobDownloadDetails"/> with the standard
        /// boilerplate fields used by mock responses. Callers may mutate fields on the
        /// returned instance for test-specific values.
        /// </summary>
        private static BlobDownloadDetails CreateMockDetails(HttpRange range, long contentLength, long totalBlobLength = 100)
        {
            return new BlobDownloadDetails()
            {
                BlobType = BlobType.Page,
                ContentLength = contentLength,
                ContentType = "test",
                ContentHash = new byte[] { 1, 2, 3 },
                LastModified = DateTimeOffset.Now,
                Metadata = new Dictionary<string, string>() { { "meta", "data" } },
                ContentRange = $"bytes {range.Offset}-{Math.Max(1, range.Offset + contentLength - 1)}/{totalBlobLength}",
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
            };
        }

        /// <summary>
        /// Builds a <see cref="Response{BlobDownloadStreamingResult}"/> wrapping a given
        /// content stream and the standard mock details.
        /// </summary>
        private static Response<BlobDownloadStreamingResult> CreateMockResponse(
            HttpRange range,
            Stream content,
            long contentLength,
            MockResponse rawResponse = null,
            long totalBlobLength = 100)
        {
            return Response.FromValue(
                new BlobDownloadStreamingResult()
                {
                    Content = content,
                    Details = CreateMockDetails(range, contentLength, totalBlobLength),
                },
                rawResponse ?? new MockResponse(200));
        }

        /// <summary>
        /// Creates a <see cref="MockResponse"/> tagged with the structured-message header.
        /// </summary>
        private static MockResponse CreateStructuredMessageResponse(int status = 200)
        {
            MockResponse response = new MockResponse(status);
            response.AddHeader(Constants.StructuredMessage.StructuredMessageHeader, "1.0");
            return response;
        }

        /// <summary>
        /// Rewraps an existing response with the structured-message header, preserving its
        /// content stream and details.
        /// </summary>
        private static Response<BlobDownloadStreamingResult> WrapWithStructuredMessageHeader(Response<BlobDownloadStreamingResult> original)
        {
            return Response.FromValue(
                new BlobDownloadStreamingResult { Content = original.Value.Content, Details = original.Value.Details },
                CreateStructuredMessageResponse());
        }

        /// <summary>
        /// Sets up <see cref="BlobBaseClient.DownloadStreamingInternal"/> on the given
        /// mock to invoke <paramref name="handler"/> for every request. Matches any
        /// non-null <see cref="DownloadTransferValidationOptions"/> with
        /// <c>AutoValidateChecksum=false</c> (the wrapped options the downloader forwards
        /// to the underlying client).
        /// </summary>
        private void SetupDownloadStreaming(
            Mock<BlobBaseClient> client,
            Func<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, bool, CancellationToken, ValueTask<Response<BlobDownloadStreamingResult>>> handler)
        {
            client.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options => options != null && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
                _async,
                It.IsAny<CancellationToken>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, layoutCache, layoutEndpoint, async, cancellation) =>
                    handler(range, conditions, validation, progress, async, cancellation));
        }

        /// <summary>
        /// Configures the client so that the first range request returns normal data
        /// from <paramref name="dataSource"/> and subsequent requests are handled by
        /// <paramref name="laterRangeHandler"/> (which may throw or return an alternate
        /// response). Optionally rewraps the first response via
        /// <paramref name="firstResponseDecorator"/>.
        /// </summary>
        private void SetupFirstSuccessThenLaterFailure(
            Mock<BlobBaseClient> client,
            MockDataSource dataSource,
            Func<HttpRange, ValueTask<Response<BlobDownloadStreamingResult>>> laterRangeHandler,
            Func<Response<BlobDownloadStreamingResult>, Response<BlobDownloadStreamingResult>> firstResponseDecorator = null)
        {
            int requestCount = 0;
            SetupDownloadStreaming(client, (range, conditions, validation, progress, async, cancellation) =>
            {
                int current = Interlocked.Increment(ref requestCount);
                if (current > 1)
                {
                    return laterRangeHandler(range);
                }
                if (async)
                {
                    return DecorateAsync(
                        dataSource.GetStreamAsync(range, conditions, validation, progress, cancellation),
                        firstResponseDecorator);
                }
                Response<BlobDownloadStreamingResult> sync = dataSource.GetStream(range, conditions, validation, progress, cancellation);
                return new ValueTask<Response<BlobDownloadStreamingResult>>(firstResponseDecorator != null ? firstResponseDecorator(sync) : sync);
            });
        }

        private static async ValueTask<Response<BlobDownloadStreamingResult>> DecorateAsync(
            ValueTask<Response<BlobDownloadStreamingResult>> inner,
            Func<Response<BlobDownloadStreamingResult>, Response<BlobDownloadStreamingResult>> decorator)
        {
            Response<BlobDownloadStreamingResult> result = await inner.ConfigureAwait(false);
            return decorator != null ? decorator(result) : result;
        }

        /// <summary>
        /// Constructs a <see cref="PartitionedDownloader"/> with test-default transfer options.
        /// </summary>
        private static PartitionedDownloader CreateDownloader(
            BlobBaseClient client,
            int maximumTransferLength = 10,
            int initialTransferLength = 10,
            DownloadTransferValidationOptions validation = null,
            ArrayPool<byte> arrayPool = null,
            IProgress<long> progress = null)
        {
            return new PartitionedDownloader(
                client,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = maximumTransferLength,
                    InitialTransferLength = initialTransferLength,
                },
                transferValidation: validation ?? s_validationOptions,
                arrayPool: arrayPool,
                progress: progress);
        }

        private void SetupDownload(Mock<BlobBaseClient> blockClient, MockDataSource dataSource)
        {
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options != s_validationOptions && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, layoutCache, LayoutEndpoint, async, cancellation) => async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation)));
        }

        private void SetupDownloadEmptyBlob(Mock<BlobBaseClient> blockClient, MockDataSource dataSource)
        {
            // empty blob with a range header, expect error
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.Is<HttpRange>(r => !r.Equals(default(HttpRange))),
                It.IsAny<BlobRequestConditions>(),
                It.Is<DownloadTransferValidationOptions>(options =>
                    options != null && options.ChecksumAlgorithm != StorageChecksumAlgorithm.None && !options.AutoValidateChecksum),
                It.IsAny<IProgress<long>>(),
                $"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadStreaming)}",
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
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
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>(),
                _async,
                s_cancellationToken)
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string, bool, CancellationToken>(
                (range, conditions, validation, progress, operationName, layoutCache, LayoutEndpoint, async, cancellation) => async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation)));
        }

        private async Task<Response> InvokeDownloadToAsync(PartitionedDownloader downloader, Stream stream)
        {
            return await downloader.DownloadToInternal(stream, s_conditions, _async, s_cancellationToken);
        }

        private class MockAsyncPageable : AsyncPageable<BlobLayoutInfo>
        {
            private readonly BlobLayoutInfo[] _layoutInfos;

            public MockAsyncPageable(BlobLayoutInfo layoutInfo)
                : this(new[] { layoutInfo })
            {
            }

            public MockAsyncPageable(BlobLayoutInfo[] layoutInfos)
            {
                _layoutInfos = layoutInfos;
            }

            public override async IAsyncEnumerable<Page<BlobLayoutInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await Task.CompletedTask;
                foreach (BlobLayoutInfo layoutInfo in _layoutInfos)
                {
                    yield return Page<BlobLayoutInfo>.FromValues(new[] { layoutInfo }, null, new MockResponse(200));
                }
            }
        }

        private class MockPageable : Pageable<BlobLayoutInfo>
        {
            private readonly BlobLayoutInfo[] _layoutInfos;

            public MockPageable(BlobLayoutInfo layoutInfo)
                : this(new[] { layoutInfo })
            {
            }

            public MockPageable(BlobLayoutInfo[] layoutInfos)
            {
                _layoutInfos = layoutInfos;
            }

            public override IEnumerable<Page<BlobLayoutInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (BlobLayoutInfo layoutInfo in _layoutInfos)
                {
                    yield return Page<BlobLayoutInfo>.FromValues(new[] { layoutInfo }, null, new MockResponse(200));
                }
            }
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
            const int totalLength = 100;

            MemoryStream destination = new MemoryStream();
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            SetupDownloadStreaming(blockClient, (range, conditions, validation, progress, async, cancellation) =>
            {
                Response<BlobDownloadStreamingResult> response = CreateResponseWithCrc64(range, totalLength);
                return async
                    ? new ValueTask<Response<BlobDownloadStreamingResult>>(Task.Delay(25).ContinueWith(_ => response))
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(response);
            });

            DownloadTransferValidationOptions checksumValidation = new DownloadTransferValidationOptions()
            {
                AutoValidateChecksum = true,
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
            };

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, validation: checksumValidation);

            Response result = await InvokeDownloadToAsync(downloader, destination);

            AssertContent(totalLength, destination);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned after a fully successful
        /// multi-partition download. Locks the invariant that the buffered (async) path's
        /// happy case is balanced w.r.t. ArrayPool rent/return, not just the error paths.
        /// </summary>
        [Test]
        public async Task ReturnsArrayPoolBuffersOnSuccessfulDownload()
        {
            MemoryStream destination = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            TrackingArrayPool trackingPool = new TrackingArrayPool();
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();
            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

            Response result = await InvokeDownloadToAsync(downloader, destination);

            AssertContent(100, destination);
            Assert.NotNull(result);
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after successful download");
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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();
            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            // Simulate the server rejecting subsequent requests because the blob
            // was modified after the initial download (ETag mismatch).
            SetupFirstSuccessThenLaterFailure(blockClient, dataSource, range =>
                throw new RequestFailedException(
                    status: 412,
                    errorCode: BlobErrorCode.ConditionNotMet.ToString(),
                    message: "The condition specified using HTTP conditional header(s) is not met.",
                    innerException: null));

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            SetupFirstSuccessThenLaterFailure(blockClient, dataSource, range =>
                throw new RequestFailedException(500, "Internal Server Error"));

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            // Cancel the token before returning the second response;
            // BufferResponseAsync/CopyToInternal will check it before reading.
            int requestCount = 0;
            SetupDownloadStreaming(blockClient, (range, conditions, validation, progress, async, cancellation) =>
            {
                int current = Interlocked.Increment(ref requestCount);
                if (current > 1)
                {
                    cts.Cancel();
                }
                return async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress, cancellation));
            });

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            SetupDownloadStreaming(blockClient, (range, conditions, validation, progressArg, async, cancellation) =>
            {
                long contentLength = Math.Min(range.Length ?? 0, 100);
                // Simulate the underlying client reporting progress
                progressArg?.Report(contentLength);

                MemoryStream content = new MemoryStream();
                for (int i = 0; i < contentLength; i++)
                    content.WriteByte((byte)(range.Offset + i));
                content.Position = 0;

                Response<BlobDownloadStreamingResult> response = CreateMockResponse(range, content, contentLength);
                return async
                    ? new ValueTask<Response<BlobDownloadStreamingResult>>(Task.Delay(25).ContinueWith(_ => response))
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(response);
            });

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, progress: progress);

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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            SetupFirstSuccessThenLaterFailure(blockClient, dataSource, range =>
            {
                long contentLength = Math.Min(range.Length ?? 0, 100);
                return new ValueTask<Response<BlobDownloadStreamingResult>>(
                    CreateMockResponse(range, new ThrowingStream(), contentLength));
            });

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

            Assert.ThrowsAsync<IOException>(async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after exception");
        }

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned when a structured
        /// message stream throws during reading, simulating a CRC validation
        /// failure during structured message decoding. The mock responses include
        /// the x-ms-structured-body header; subsequent (buffered) responses use a
        /// ThrowingStream to simulate decoding failure, triggering an IOException
        /// inside BufferResponseAsync.
        /// </summary>
        [Test]
        public async Task ReturnsArrayPoolBuffersOnChecksumMismatch()
        {
            // Structured message buffer cleanup only applies to the async/multi-worker path
            if (!_async)
            {
                Assert.Ignore("Structured message buffer cleanup only exists in the buffered (async) path");
            }

            MemoryStream destination = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            TrackingArrayPool trackingPool = new TrackingArrayPool();
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            // First request: normal data wrapped with structured-message header so the
            // initial CopyToInternal skips hasher-based validation and succeeds.
            // Later requests: a structured-message response whose stream throws on read,
            // simulating a CRC mismatch during decoding.
            SetupFirstSuccessThenLaterFailure(
                blockClient,
                dataSource,
                laterRangeHandler: range =>
                {
                    long contentLength = range.Length ?? 10;
                    return new ValueTask<Response<BlobDownloadStreamingResult>>(
                        CreateMockResponse(range, new ThrowingStream(), contentLength, CreateStructuredMessageResponse()));
                },
                firstResponseDecorator: WrapWithStructuredMessageHeader);

            DownloadTransferValidationOptions checksumValidation = new DownloadTransferValidationOptions()
            {
                AutoValidateChecksum = true,
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
            };

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, validation: checksumValidation, arrayPool: trackingPool);

            Assert.CatchAsync<IOException>(async () => await InvokeDownloadToAsync(downloader, destination));
            Assert.AreEqual(0, trackingPool.OutstandingRentals, "All array pool buffers should be returned after structured message decoding failure");
        }

        /// <summary>
        /// Verifies that all ArrayPool buffers are returned when the response
        /// stream contains more data than the Content-Length header indicates.
        /// This guard only exists in BufferResponseAsync (async/multi-worker path),
        /// so the test is skipped for the sync fixture. An OverflowByOneStream returns
        /// exactly ContentLength + 1 bytes then EOF, which specifically validates
        /// that the overflow guard compares against the declared Content-Length
        /// rather than the (potentially larger) ArrayPool buffer size.
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
            Mock<BlobBaseClient> blockClient = CreateMockBlobClient();

            // Later requests return a stream that produces exactly one more byte than
            // Content-Length indicates, to specifically test the overflow guard catches
            // this even when ArrayPool returns a larger buffer.
            SetupFirstSuccessThenLaterFailure(blockClient, dataSource, range =>
            {
                long contentLength = range.Length ?? 10;
                return new ValueTask<Response<BlobDownloadStreamingResult>>(
                    CreateMockResponse(range, new OverflowByOneStream((int)contentLength), contentLength));
            });

            PartitionedDownloader downloader = CreateDownloader(blockClient.Object, arrayPool: trackingPool);

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

        /// A stream that returns exactly <paramref name="declaredLength"/> + 1 bytes
        /// then EOF. Unlike InfiniteStream, this specifically tests the overflow guard
        /// when the pooled buffer may be larger than the declared Content-Length.
        /// </summary>
        private class OverflowByOneStream : Stream
        {
            private readonly int _totalBytes;
            private int _bytesRemaining;

            public OverflowByOneStream(int declaredLength)
            {
                _totalBytes = declaredLength + 1;
                _bytesRemaining = _totalBytes;
            }

            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position { get; set; }
            public override void Flush() { }
            public override int Read(byte[] buffer, int offset, int count)
            {
                int toRead = Math.Min(count, _bytesRemaining);
                for (int i = offset; i < offset + toRead; i++)
                    buffer[i] = 0xAA;
                _bytesRemaining -= toRead;
                return toRead;
            }
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                return Task.FromResult(Read(buffer, offset, count));
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

            StorageCrc64HashAlgorithm crc = StorageCrc64HashAlgorithm.Create();
            crc.Append(data);
            byte[] crcHash = new byte[8];
            crc.GetCurrentHash(crcHash);

            MockResponse mockResponse = new MockResponse(200);
            mockResponse.AddHeader("x-ms-content-crc64", Convert.ToBase64String(crcHash));

            return CreateMockResponse(range, new MemoryStream(data), contentLength, mockResponse, totalBlobLength: totalLength);
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
            private readonly DownloadHint _downloadHint;

            public List<(HttpRange Range, BlobRequestConditions Conditions)> Requests { get; } = new List<(HttpRange Range, BlobRequestConditions Conditions)>();

            public MockDataSource(int length, DownloadHint downloadHint = default)
            {
                _length = length;
                _downloadHint = downloadHint;
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

                long contentLength = Math.Min(range.Length ?? 0, _length);

                MemoryStream memoryStream = new MemoryStream();
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
                        AccessTier = "Hot",
                        AccessTierInferred = true,
                        AccessTierChangedOn = DateTimeOffset.Now,
                        SmartAccessTier = "Cool",
                        DownloadHint = _downloadHint,
                    }
                }, new MockResponse(200));
            }
        }
    }
}
