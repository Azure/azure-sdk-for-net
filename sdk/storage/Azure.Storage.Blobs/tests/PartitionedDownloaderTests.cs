// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                s_cancellationToken,
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())).ThrowsAsync(e);

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
                enableDataLocality: true);

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
                    It.Is<HttpRange>(r => r.Offset == 20 && r.Length == 80),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.Is<HttpRange>(r => r.Offset == 20 && r.Length == 80),
                    It.IsAny<BlobRequestConditions>(),
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
                enableDataLocality: true);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content correct
            AssertContent(100, stream);
            Assert.NotNull(result);

            // Assert - GetLayout was NOT called
            blockClient.Verify(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);

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

            // enableDataLocality: false (default)
            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                enableDataLocality: false);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content correct
            AssertContent(100, stream);
            Assert.NotNull(result);

            // Assert - GetLayout was NOT called
            blockClient.Verify(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);

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

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>())).Throws(softFailure);
            blockClient.Setup(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>())).Throws(softFailure);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                enableDataLocality: true);

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
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
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
                enableDataLocality: true);

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
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
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
                _async,
                s_cancellationToken,
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string>(
                async (range, conditions, validation, progress, operationName, async, cancellation, layoutCache, LayoutEndpoint) =>
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

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>())).Throws(nonSoftFailure);
            blockClient.Setup(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>())).Throws(nonSoftFailure);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                },
                transferValidation: s_validationOptions,
                enableDataLocality: true);

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
                enableDataLocality: true);

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
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
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
                enableDataLocality: true);

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
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Exactly(2));
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.IsAny<HttpRange>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Exactly(2));
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
                enableDataLocality: true);

            // Act
            Response result = await InvokeDownloadToAsync(downloader, stream);

            // Assert - content correct, exactly one DownloadStreamingInternal call, no layout
            AssertContent(10, stream);
            Assert.NotNull(result);
            Assert.AreEqual(1, capturedCalls.Count, "One-shot download should issue exactly one DownloadStreamingInternal call");
            Assert.IsNull(capturedCalls[0].LayoutCache, "One-shot download should not construct a layout cache");

            blockClient.Verify(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);
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
                _async,
                s_cancellationToken,
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache, LayoutEndpoint) =>
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
            var rangeItems = new List<BlobLayoutRangesRangeItem>();
            var endpointItems = new List<BlobLayoutEndpointsEndpointItem>();
            var endpointMap = new Dictionary<string, int>();

            foreach (var seg in segments)
            {
                if (!endpointMap.TryGetValue(seg.Endpoint, out int idx))
                {
                    idx = endpointMap.Count;
                    endpointMap[seg.Endpoint] = idx;
                    endpointItems.Add(BlobsModelFactory.BlobLayoutEndpointsEndpointItem(index: idx, value: seg.Endpoint));
                }
                rangeItems.Add(BlobsModelFactory.BlobLayoutRangesRangeItem(start: seg.Start, end: seg.End, endpointIndex: idx));
            }

            BlobLayoutInfo layoutInfo = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(rangeItems),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(endpointItems),
            };

            // Setup GetLayoutAsync (for async path)
            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockAsyncPageable(layoutInfo));

            // Setup GetLayout (for sync path)
            blockClient.Setup(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
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
                var rangeItems = new List<BlobLayoutRangesRangeItem>();
                var endpointItems = new List<BlobLayoutEndpointsEndpointItem>();
                var endpointMap = new Dictionary<string, int>();

                foreach (var seg in segments)
                {
                    if (!endpointMap.TryGetValue(seg.Endpoint, out int idx))
                    {
                        idx = endpointMap.Count;
                        endpointMap[seg.Endpoint] = idx;
                        endpointItems.Add(BlobsModelFactory.BlobLayoutEndpointsEndpointItem(index: idx, value: seg.Endpoint));
                    }
                    rangeItems.Add(BlobsModelFactory.BlobLayoutRangesRangeItem(start: seg.Start, end: seg.End, endpointIndex: idx));
                }

                layoutInfos[p] = new BlobLayoutInfo
                {
                    Ranges = BlobsModelFactory.BlobLayoutRanges(rangeItems),
                    Endpoints = BlobsModelFactory.BlobLayoutEndpoints(endpointItems),
                };
            }

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockAsyncPageable(layoutInfos));

            blockClient.Setup(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockPageable(layoutInfos));
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
                s_cancellationToken,
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache, LayoutEndpoint) => async
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
                s_cancellationToken,
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
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
                s_cancellationToken,
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache, LayoutEndpoint) => async
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
                        DownloadHint = _downloadHint,
                    }
                }, new MockResponse(200));
            }
        }
    }
}
