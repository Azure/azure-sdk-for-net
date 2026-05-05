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
                s_cancellationToken)).ThrowsAsync(e);

            PartitionedDownloader downloader = new PartitionedDownloader(
                blockClient.Object,
                new StorageTransferOptions() { MaximumTransferLength = 10 },
                transferValidation: s_validationOptions);

            Exception thrown = Assert.ThrowsAsync<Exception>(async () => await InvokeDownloadToAsync(downloader, stream));

            Assert.AreSame(e, thrown);
        }

        [Test]
        public async Task DataLocality_FetchesLayoutAndRoutesChunksToIdealEndpoints()
        {
            // Arrange - 100 byte blob with data locality enabled and download hint present
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: "layout");
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

            // Verify every subsequent chunk resolves to the correct ideal endpoint.
            // Resolving the cache here triggers the underlying GetLayout/GetLayoutAsync
            // mock since DownloadStreamingInternal itself is mocked.
            BlobBaseClient endpointResolver = new BlobBaseClient(new Uri("https://account.blob.core.windows.net/c/b"));
            int hostACount = 0;
            int hostBCount = 0;
            int hostCCount = 0;
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                var (range, layoutCache) = capturedCalls[i];
                Assert.NotNull(range);
                Assert.IsNotNull(layoutCache, $"Chunk {i} at range [{range.Offset}] should have layout cache");

                BlobLayoutSegmentCacheValue cached = await layoutCache.GetAsync(async: _async, CancellationToken.None);
                BlobLayoutSegment[] segments = cached.Segments;
                Assert.IsNotNull(segments, $"Chunk {i} at range [{range.Offset}] should have layout segments");

                string idealEndpoint = endpointResolver.GetIdealEndpoint(range, segments);
                Assert.IsNotNull(idealEndpoint, $"Chunk at range [{range.Offset}] should resolve to an ideal endpoint");

                if (range.Offset < 46)
                {
                    Assert.AreEqual("https://host-a:443", idealEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-a");
                    hostACount++;
                }
                else if (range.Offset < 83)
                {
                    Assert.AreEqual("https://host-b:443", idealEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-b");
                    hostBCount++;
                }
                else
                {
                    Assert.AreEqual("https://host-c:443", idealEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-c");
                    hostCCount++;
                }
            }

            // Assert - GetLayout was called exactly once (cache de-duplicates concurrent acquires)
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

            Assert.AreEqual(3, hostACount, "Exactly 3 chunks ([20-29]..[40-49]) should route to host-a");
            Assert.AreEqual(4, hostBCount, "Exactly 4 chunks ([50-59]..[80-89]) should route to host-b");
            Assert.AreEqual(1, hostCCount, "Exactly 1 chunk ([90-99]) should route to host-c");
        }

        [Test]
        public async Task DataLocality_LayoutCacheDeduplicatesAcrossChunks()
        {
            // Arrange - 100 byte blob with data locality enabled and download hint present
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: "layout");
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict, new Uri("http://mock"), new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();

            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] expectedSegments = new[]
            {
                new BlobLayoutSegment { Start = 20, End = 99, Endpoint = "https://host-a:443" },
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

            // Assert - all chunked calls share the SAME cache instance
            AutoRefreshingCache<BlobLayoutSegmentCacheValue> sharedCache = capturedCalls[1].LayoutCache;
            Assert.IsNotNull(sharedCache, "Cache should be constructed for chunked calls");
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                Assert.AreSame(sharedCache, capturedCalls[i].LayoutCache,
                    $"Chunk {i} should receive the same AutoRefreshingCache instance as chunk 1");
            }

            // Resolve the cache many times — far more than the chunk count — to prove
            // de-duplication. Every resolve should return the exact same Segments array
            // reference, and GetLayout should still have been invoked exactly once.
            BlobLayoutSegmentCacheValue first = await sharedCache.GetAsync(async: _async, CancellationToken.None);
            Assert.IsNotNull(first.Segments);
            Assert.AreEqual(1, first.Segments.Length);

            for (int i = 0; i < 50; i++)
            {
                BlobLayoutSegmentCacheValue resolved = await sharedCache.GetAsync(async: _async, CancellationToken.None);
                Assert.AreSame(first.Segments, resolved.Segments,
                    "Repeated GetAsync calls within the TTL should return the same cached Segments array");
            }

            // Assert - GetLayout was called exactly once across all chunks + 51 explicit resolves
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

            AssertContent(100, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task DataLocality_NoDownloadHint_SkipsLayout()
        {
            // Arrange - 100 byte blob with NO download hint
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100, downloadHint: null);
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
            MockDataSource dataSource = new MockDataSource(100, downloadHint: "layout");
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
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache) =>
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
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache) => async
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
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache) => async
                    ? dataSource.GetStreamAsync(range, conditions, validation, progress: progress, cancellation)
                    : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range, conditions, validation, progress: progress, cancellation)));
        }

        private async Task<Response> InvokeDownloadToAsync(PartitionedDownloader downloader, Stream stream)
        {
            return await downloader.DownloadToInternal(stream, s_conditions, _async, s_cancellationToken);
        }

        private class MockAsyncPageable : AsyncPageable<BlobLayoutInfo>
        {
            private readonly BlobLayoutInfo _layoutInfo;

            public MockAsyncPageable(BlobLayoutInfo layoutInfo)
            {
                _layoutInfo = layoutInfo;
            }

            public override async IAsyncEnumerable<Page<BlobLayoutInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await Task.CompletedTask;
                yield return Page<BlobLayoutInfo>.FromValues(new[] { _layoutInfo }, null, new MockResponse(200));
            }
        }

        private class MockPageable : Pageable<BlobLayoutInfo>
        {
            private readonly BlobLayoutInfo _layoutInfo;

            public MockPageable(BlobLayoutInfo layoutInfo)
            {
                _layoutInfo = layoutInfo;
            }

            public override IEnumerable<Page<BlobLayoutInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                yield return Page<BlobLayoutInfo>.FromValues(new[] { _layoutInfo }, null, new MockResponse(200));
            }
        }

        private class MockDataSource
        {
            private readonly int _length;
            private readonly string _downloadHint;

            public List<(HttpRange Range, BlobRequestConditions Conditions)> Requests { get; } = new List<(HttpRange Range, BlobRequestConditions Conditions)>();

            public MockDataSource(int length, string downloadHint = null)
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
