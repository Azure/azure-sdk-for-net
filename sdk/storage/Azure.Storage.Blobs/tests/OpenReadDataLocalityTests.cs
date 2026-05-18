// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    /// <summary>
    /// Unit tests for <see cref="BlobBaseClient.OpenReadInternal"/> with data
    /// locality enabled.
    /// </summary>
    [TestFixture(true)]
    [TestFixture(false)]
    public class OpenReadDataLocalityTests
    {
        private readonly bool _async;

        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;
        private static readonly ETag s_etag = new ETag("0xQWERTY");

        public OpenReadDataLocalityTests(bool async)
        {
            _async = async;
        }

        [Test]
        public async Task EnableDataLocality_FetchesLayoutAndRoutesChunksToLayoutEndpoints()
        {
            // Arrange - 100 byte blob, 20 byte buffer ⇒ 5 chunked reads at
            // offsets 0, 20, 40, 60, 80. Layout splits the blob across two hosts.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] expectedSegments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 49, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 50, End = 99, Endpoint = "https://host-b:443" },
            };
            SetupGetLayout(blockClient, expectedSegments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: true);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content is intact end-to-end
            AssertContent(blobLength, destination);

            // Assert - exactly 5 chunked DownloadStreamingInternal calls were made,
            // and EVERY call (including the first) received the same layout cache.
            Assert.AreEqual(5, capturedCalls.Count, "Expected 5 buffer-fill downloads (100 bytes / 20-byte buffer)");

            AutoRefreshingCache<BlobLayoutSegmentCacheValue> sharedCache = capturedCalls[0].LayoutCache;
            Assert.IsNotNull(sharedCache, "OpenRead with EnableDataLocality=true should pass a layout cache to the very first chunk");

            int hostACount = 0;
            int hostBCount = 0;
            for (int i = 0; i < capturedCalls.Count; i++)
            {
                var (range, layoutCache) = capturedCalls[i];
                Assert.AreSame(sharedCache, layoutCache,
                    $"Chunk {i} at offset {range.Offset} should receive the same AutoRefreshingCache instance as chunk 0");

                BlobLayoutSegmentCacheValue cached = await layoutCache.GetAsync(async: _async, CancellationToken.None);
                BlobLayoutSegment[] segments = cached.Segments;
                Assert.IsNotNull(segments, $"Chunk {i} at offset {range.Offset} should have layout segments");

                string layoutEndpoint = BlobExtensions.GetLayoutEndpoint(range, segments);
                Assert.IsNotNull(layoutEndpoint, $"Chunk at offset {range.Offset} should resolve to a layout endpoint");

                if (range.Offset < 50)
                {
                    Assert.AreEqual("https://host-a:443", layoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-a");
                    hostACount++;
                }
                else
                {
                    Assert.AreEqual("https://host-b:443", layoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-b");
                    hostBCount++;
                }
            }

            Assert.AreEqual(3, hostACount, "Chunks at offsets 0, 20, 40 should route to host-a");
            Assert.AreEqual(2, hostBCount, "Chunks at offsets 60, 80 should route to host-b");

            // Assert - GetLayout was invoked exactly once and over the FULL blob
            // (default range). This is the OpenRead bootstrap+seed contract: a single
            // GetLayout call supplies both the layout AND the BlobContentLength/ETag/Metadata
            // headers, so OpenRead does not also issue GetProperties on the success path.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [TestCase(0)] // position == 0 (no-op range)
        [TestCase(1)] // very small offset
        [TestCase(50)] // mid-blob (boundary between two layout segments)
        [TestCase(99)] // last byte
        public async Task EnableDataLocality_Position_ReturnsRangedData(long position)
        {
            // Arrange - 100 byte blob, 20 byte buffer, layout split across two hosts.
            // OpenRead is invoked with a non-zero starting position; the returned
            // stream should expose the full blob length but only contain bytes
            // [position, blobLength) starting at offset position in the stream.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 49, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 50, End = 99, Endpoint = "https://host-b:443" },
            };
            SetupGetLayout(blockClient, segments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: true, position: position);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - stream length is the full blob length, but only the bytes
            // from `position` onward were actually downloaded.
            Assert.AreEqual(blobLength, readStream.Length);
            Assert.AreEqual(blobLength - position, destination.Length);

            // The MockDataSource writes byte (offset + i) at each position, so the
            // first byte returned at this position should equal (byte)position.
            byte[] downloaded = destination.ToArray();
            for (int i = 0; i < downloaded.Length; i++)
            {
                Assert.AreEqual((byte)(position + i), downloaded[i],
                    $"Byte {i} (blob offset {position + i}) did not match expected payload");
            }

            // Assert - every chunk download started at or after `position`.
            // OpenRead must never request bytes before the user's starting position.
            Assert.IsTrue(capturedCalls.Count > 0, "Expected at least one chunk download");
            foreach (var (range, _) in capturedCalls)
            {
                Assert.GreaterOrEqual(range.Offset, position,
                    $"DownloadStreamingInternal at offset {range.Offset} requested data before position {position}");
            }

            // Assert - the bootstrap GetLayout contract is unchanged by `position`:
            // OpenRead still seeds the layout cache for the full blob (default range)
            // so backward seeks remain layout-routed.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [Test]
        public async Task DataLocality_Disabled_NoLayoutCacheConstructed()
        {
            // Arrange - feature disabled. No cache should be constructed and GetLayout
            // must not be called even though the data source could supply layout.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: false);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content correct
            AssertContent(blobLength, destination);

            // Assert - GetLayout was NOT called
            blockClient.Verify(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()), Times.Never);

            // Assert - every chunk received a null cache
            Assert.AreEqual(5, capturedCalls.Count);
            foreach (var (range, layoutCache) in capturedCalls)
            {
                Assert.IsNull(layoutCache, $"Layout cache should be null at offset {range.Offset} when EnableDataLocality is false");
            }
        }

        [TestCase(400)]
        [TestCase(503)]
        public async Task DataLocality_GetLayoutSoftFailure_OpenReadStillSucceeds(int status)
        {
            // Arrange - GetLayout fails with a soft (400 or 5xx) error. The shared
            // FetchLayoutInternal helper should swallow it, the cache should store a
            // null-Segments value, and OpenRead should still complete successfully
            // (chunks fall back to the original endpoint via null layout endpoint).
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

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

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: true);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content downloaded correctly despite layout failure
            AssertContent(blobLength, destination);

            Assert.AreEqual(5, capturedCalls.Count);
            for (int i = 0; i < capturedCalls.Count; i++)
            {
                Assert.IsNotNull(capturedCalls[i].LayoutCache, $"Chunk {i} should have a layout cache");
                BlobLayoutSegmentCacheValue cached = await capturedCalls[i].LayoutCache.GetAsync(async: _async, CancellationToken.None);
                Assert.IsNull(cached.Segments, $"Chunk {i} should see null Segments after a soft GetLayout failure");
            }

            // Assert - GetLayout invoked exactly once across the bootstrap (and the
            // cache stores the failure as a null-Segments value so subsequent chunks
            // don't retry it). The seeding range still covers the entire blob.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);

            // Assert - on soft GetLayout failure we DO fall back to GetProperties exactly
            // once (this is the only branch in OpenRead that issues GetProperties when
            // EnableDataLocality is true).
            VerifyGetPropertiesCalledOnce(blockClient);
        }

        [TestCase(401)] // Unauthorized
        [TestCase(403)] // Forbidden
        [TestCase(404)] // NotFound
        [TestCase(409)] // Conflict
        public void DataLocality_GetLayoutHardFailure_PropagatesToCaller(int status)
        {
            // Arrange - GetLayout fails with a HARD error (anything that is NOT 400 and
            // NOT >= 500). FetchLayoutInternal only swallows 400/5xx, so any
            // other status MUST propagate. This guards against a regression that would
            // accidentally widen the soft-failure catch and mask a permissions/state error
            // (e.g., 401/403/404) by silently falling back to GetProperties.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            // Intentionally still set up GetProperties so a regression that wrongly
            // falls back to it surfaces as an explicit Verify(Times.Never) failure
            // rather than a Moq strict-mode "no setup" exception (clearer signal).
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            RequestFailedException hardFailure = new RequestFailedException(
                status: status,
                message: $"Hard failure ({status})",
                errorCode: null,
                innerException: null);

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>())).Throws(hardFailure);
            blockClient.Setup(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>())).Throws(hardFailure);

            // Act + Assert - OpenRead must propagate the exception unchanged.
            RequestFailedException thrown = Assert.ThrowsAsync<RequestFailedException>(
                async () => await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: true));

            Assert.AreEqual(status, thrown.Status, "OpenRead should propagate the original status");
            Assert.AreSame(hardFailure, thrown, "OpenRead should propagate the original exception instance, not wrap it");

            // Assert - GetLayout was attempted exactly once (the bootstrap call); the
            // exception must short-circuit OpenRead before any chunk download is issued.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            Assert.AreEqual(0, capturedCalls.Count,
                "No chunk downloads should be issued when GetLayout hard-fails during bootstrap");

            // Assert - critically, the hard failure must NOT silently fall back to
            // GetProperties. Doing so would mask the real error (e.g., turn a 403 into
            // a successful read of stale data, or a 404 into a property-fetch 404).
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [Test]
        public async Task EnableDataLocality_LayoutCacheSharedAcrossEveryChunk()
        {
            // Arrange - assert that the same AutoRefreshingCache instance is passed
            // to every buffer-fill download. This guards against a refactor that
            // accidentally rebuilds the cache per chunk and would defeat both the
            // de-dup of GetLayout and the locality routing.
            const int blobLength = 100;
            const int bufferSize = 25;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 99, Endpoint = "https://host-a:443" },
            };
            SetupGetLayout(blockClient, segments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: true);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - 4 chunks, one shared cache, one GetLayout call.
            AssertContent(blobLength, destination);
            Assert.AreEqual(4, capturedCalls.Count, "Expected 4 buffer-fill downloads (100 bytes / 25-byte buffer)");

            AutoRefreshingCache<BlobLayoutSegmentCacheValue> shared = capturedCalls[0].LayoutCache;
            Assert.IsNotNull(shared);
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                Assert.AreSame(shared, capturedCalls[i].LayoutCache,
                    $"Chunk {i} should reuse the same AutoRefreshingCache instance as chunk 0");
            }

            // The mocked DownloadStreamingInternal short-circuits the production code path
            // that resolves the layout cache, so trigger the resolve here to drive
            // GetLayout/GetLayoutAsync exactly once and validate the seeding range.
            BlobLayoutSegmentCacheValue resolved = await shared.GetAsync(async: _async, CancellationToken.None);
            Assert.IsNotNull(resolved.Segments, "Resolved layout cache should expose segments returned by GetLayout");

            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [Test]
        public async Task EnableDataLocality_DoesNotCallGetProperties_GetLayoutOnceEvenAcrossChunks()
        {
            // This test locks in the bootstrap-swap contract directly:
            //   1. With EnableDataLocality=true, OpenRead must NOT call GetProperties.
            //      The single GetLayout call supplies ETag, BlobContentLength, and Metadata.
            //   2. GetLayout must be called exactly once for the entire OpenRead lifetime,
            //      even when many chunk-downloads happen (the layout cache de-dups them).
            //
            // Use a small buffer to force many chunk downloads and prove the invariant
            // holds across all of them, not just on the first chunk.
            const int blobLength = 200;
            const int bufferSize = 10; // ⇒ 20 buffer-fill DownloadStreamingInternal calls

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            // Intentionally still set up GetProperties so a regression that calls it
            // surfaces as an explicit Verify(Times.Never) failure rather than a Moq
            // strict-mode "no setup" exception (which would obscure the contract).
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 199, Endpoint = "https://host-a:443" },
            };
            SetupGetLayout(blockClient, segments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, enableDataLocality: true);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content correct end-to-end
            AssertContent(blobLength, destination);

            // Assert - many chunk downloads happened (sanity check the test is exercising
            // the multi-chunk path, not just a single buffer fill).
            Assert.AreEqual(20, capturedCalls.Count, "Expected 20 buffer-fill downloads (200 bytes / 10-byte buffer)");

            // The mocked DownloadStreamingInternal short-circuits the production code path
            // that resolves the layout cache, so trigger the resolve here to drive
            // GetLayout/GetLayoutAsync exactly once. In production, the very first chunk's
            // layout-aware download routing would resolve the cache and seed it from the
            // bootstrap segments; subsequent chunks reuse the cached value and never re-call
            // GetLayout.
            BlobLayoutSegmentCacheValue resolved = await capturedCalls[0].LayoutCache.GetAsync(async: _async, CancellationToken.None);
            Assert.IsNotNull(resolved.Segments, "Bootstrap should seed the cache with segments returned by GetLayout");

            // Resolve the cache from every chunk to model what production routing does.
            // None of these resolves should trigger an additional GetLayout call because
            // the cache is seeded once at bootstrap and reused for the lifetime of the stream.
            for (int i = 0; i < capturedCalls.Count; i++)
            {
                BlobLayoutSegmentCacheValue perChunk = await capturedCalls[i].LayoutCache.GetAsync(async: _async, CancellationToken.None);
                Assert.IsNotNull(perChunk.Segments, $"Chunk {i} should see the seeded layout segments");
            }

            // The two invariants the user asked us to lock in.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        #region Helpers

        private Mock<BlobBaseClient> CreateMockBlobBaseClient()
        {
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(
                MockBehavior.Strict,
                new Uri("http://mock"),
                new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            return blockClient;
        }

        private static void SetupGetProperties(Mock<BlobBaseClient> blockClient, long contentLength)
        {
            BlobProperties properties = BlobsModelFactory.BlobProperties(
                contentLength: contentLength,
                eTag: s_etag,
                lastModified: DateTimeOffset.UtcNow,
                metadata: new Dictionary<string, string>());

            Response<BlobProperties> response = Response.FromValue(properties, new MockResponse(200));

            blockClient.Setup(c => c.GetPropertiesInternal(
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<bool>(),
                It.IsAny<RequestContext>(),
                It.IsAny<string>())).ReturnsAsync(response);
        }

        private void SetupDownloadStreamingWithCapture(
            Mock<BlobBaseClient> blockClient,
            MockDataSource dataSource,
            List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)> capturedCalls)
        {
            // NOTE: cannot match the cancellation token with a literal here. The OpenRead path
            // returns a stream and subsequent Read/ReadAsync invocations route through
            // LazyLoadingReadOnlyStream, which forwards whatever token the caller passes in
            // (CancellationToken.None when CopyTo/CopyToAsync are invoked without args). The
            // _async parameter is still forwarded faithfully and so can be matched directly.
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<DownloadTransferValidationOptions>(),
                It.IsAny<IProgress<long>>(),
                It.IsAny<string>(),
                _async,
                It.IsAny<CancellationToken>(),
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache, layoutEndpoint) =>
                {
                    lock (capturedCalls)
                    {
                        capturedCalls.Add((range, layoutCache));
                    }
                    return async
                        ? dataSource.GetStreamAsync(range)
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range));
                });
        }

        private static void SetupGetLayout(Mock<BlobBaseClient> blockClient, BlobLayoutSegment[] segments, long blobContentLength)
        {
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

            // OpenRead bootstraps from GetLayout when EnableDataLocality is true, so the
            // returned BlobLayoutInfo must carry the headers that previously came from
            // GetProperties (BlobContentLength, ETag, Metadata).
            BlobLayoutInfo layoutInfo = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(rangeItems),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(endpointItems),
                BlobContentLength = blobContentLength,
                ETag = s_etag,
                Metadata = new Dictionary<string, string>(),
            };

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockAsyncPageable(layoutInfo));

            blockClient.Setup(c => c.GetLayout(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockPageable(layoutInfo));
        }

        private void VerifyGetLayoutCalledOnceForFullBlob(Mock<BlobBaseClient> blockClient)
        {
            // OpenRead bootstrap doesn't yet know the blob's length, so it calls
            // GetLayout with the default HttpRange (offset 0, length null) which the
            // service interprets as "the whole blob". This is the contract we lock in.
            if (_async)
            {
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.Is<HttpRange>(r => r.Offset == 0 && r.Length == null),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.Is<HttpRange>(r => r.Offset == 0 && r.Length == null),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        private static void VerifyGetPropertiesNotCalled(Mock<BlobBaseClient> blockClient)
        {
            // With EnableDataLocality=true and a successful GetLayout, OpenRead must not
            // also issue a GetProperties call — the layout response carries the headers
            // (ETag, BlobContentLength, Metadata) needed to bootstrap the stream.
            blockClient.Verify(c => c.GetPropertiesInternal(
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<bool>(),
                It.IsAny<RequestContext>(),
                It.IsAny<string>()), Times.Never);
        }

        private static void VerifyGetPropertiesCalledOnce(Mock<BlobBaseClient> blockClient)
        {
            // The locality soft-failure path falls back to a single GetProperties call to
            // recover ETag/length/metadata when GetLayout returned a 400/5xx.
            blockClient.Verify(c => c.GetPropertiesInternal(
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<bool>(),
                It.IsAny<RequestContext>(),
                It.IsAny<string>()), Times.Once);
        }

        private async Task<Stream> InvokeOpenReadAsync(BlobBaseClient client, int bufferSize, bool enableDataLocality, long position = 0)
        {
            BlobOpenReadOptions options = new BlobOpenReadOptions(allowModifications: false)
            {
                BufferSize = bufferSize,
                EnableDataLocality = enableDataLocality,
                Position = position,
            };

            // Internal overload exposes the enableDataLocality + async + cancellationToken parameters directly.
            return await client.OpenReadInternal(
                position: options.Position,
                bufferSize: options.BufferSize,
                conditions: options.Conditions,
                allowModifications: false,
                transferValidationOverride: options.TransferValidation,
                enableDataLocality: options.EnableDataLocality,
                async: _async,
                cancellationToken: s_cancellationToken).ConfigureAwait(false);
        }

        private async Task CopyAsync(Stream source, Stream destination)
        {
            if (_async)
            {
                await source.CopyToAsync(destination).ConfigureAwait(false);
            }
            else
            {
                source.CopyTo(destination);
            }
        }

        private static void AssertContent(int expectedLength, MemoryStream stream)
        {
            Assert.AreEqual(expectedLength, stream.Length);

            byte[] array = stream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual((byte)i, array[i]);
            }
        }

        #endregion

        #region Mock Plumbing

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

            public MockDataSource(int length)
            {
                _length = length;
            }

            public async ValueTask<Response<BlobDownloadStreamingResult>> GetStreamAsync(HttpRange range)
            {
                await Task.Delay(1).ConfigureAwait(false);
                return GetStream(range);
            }

            public Response<BlobDownloadStreamingResult> GetStream(HttpRange range)
            {
                long offset = range.Offset;
                long requested = range.Length ?? (_length - offset);
                long remaining = Math.Max(0, _length - offset);
                int contentLength = (int)Math.Min(requested, remaining);

                MemoryStream memoryStream = new MemoryStream();
                for (int i = 0; i < contentLength; i++)
                {
                    memoryStream.WriteByte((byte)(offset + i));
                }
                memoryStream.Position = 0;

                string contentRange = $"bytes {offset}-{Math.Max(offset, offset + contentLength - 1)}/{_length}";

                // LazyLoadingReadOnlyStream parses the blob length from the raw Content-Range
                // response header (not from BlobDownloadDetails.ContentRange), so it must be
                // present on the underlying MockResponse for OpenRead chunked reads.
                MockResponse rawResponse = new MockResponse(200);
                rawResponse.AddHeader("Content-Range", contentRange);

                return Response.FromValue(new BlobDownloadStreamingResult()
                {
                    Content = memoryStream,
                    Details = new BlobDownloadDetails()
                    {
                        BlobType = BlobType.Block,
                        ContentLength = contentLength,
                        ContentType = "test",
                        LastModified = DateTimeOffset.UtcNow,
                        Metadata = new Dictionary<string, string>(),
                        ContentRange = contentRange,
                        ETag = s_etag,
                    }
                }, rawResponse);
            }
        }

        #endregion
    }
}
